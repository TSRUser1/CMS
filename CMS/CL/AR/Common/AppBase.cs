using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SEM.CMS.CL.AR.Common
{
    public class AppBase
    {
        #region Public Variables

        #region AppSetting
        public const string AS_DATABASE_NAME = "Database";
        public const string AS_LOGFILE_PATH = "LogFile";
        public const string AS_WCFIPAddress = "WCFIPAddress";
        public const string AS_FILEPATH = "UploadFilePath";

        #endregion

        #endregion

        #region Public Method

        #region BusinessErrorHandling
        public static void BusinessErrorHandling(Exception ex, string source)
        {
            // Include logic for logging exceptions
            // Get the absolute path to the log file
            string logFile = ConfigurationManager.AppSettings[AS_LOGFILE_PATH];

            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine("********** {0} **********", DateTime.UtcNow.AddHours(8));
            if (ex.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(ex.InnerException.GetType().ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(ex.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(ex.InnerException.Source);
                if (ex.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(ex.InnerException.StackTrace);
                }
            }
            sw.Write("Exception Type: ");
            sw.WriteLine(ex.GetType().ToString());
            sw.WriteLine("Exception: " + ex.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");
            if (ex.StackTrace != null)
            {
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine();
            }
            sw.Close();
        }
        #endregion

        #region Decrypt
        public static string Decrypt(string TextToBeDecrypted)
        {
            string Password = ConfigurationManager.AppSettings["SecretKey"];
            return Decryption(TextToBeDecrypted, Password);
        }
        #endregion

        #region Decryption
        public static string Decryption(string TextToBeDecrypted, string Password)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string DecryptedData;
            try
            {
                byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

                //Making of the key for decryption
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

                //Creates a symmetric Rijndael decryptor object
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);

                //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();

                //Converting to string
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                DecryptedData = TextToBeDecrypted;
            }

            return DecryptedData;
        }
        #endregion

        #region Encrypt
        public static string Encrypt(string TextToBeEncrypted)
        {
            string Password = ConfigurationManager.AppSettings["SecretKey"];
            return Encryption(TextToBeEncrypted, Password);
        }
        #endregion

        #region Encryption
        public static string Encryption(string TextToBeEncrypted, string Password)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

            //Creates a symmetric encryptor object. 
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();

            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);

            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;
        }
        #endregion

        #region GetCurrentMethod
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
        #endregion

        #region GetDatabase
        public Database GetDatabase()
        {
            Database db = DatabaseFactory.CreateDatabase(AS_DATABASE_NAME);
            return db;
        }
        #endregion

        #region GetLocalTime
        public static DateTime GetLocalTime()
        {
            int TimeZone = Convert.ToInt32(ConfigurationManager.AppSettings["TimeDiff"]);
            return DateTime.UtcNow.AddHours(TimeZone);
        }
        #endregion

        #region WCFAuthentication
        public static bool WCFAuthentication()
        {
            string[] separator = { ";" };
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
                prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            string appSetting = ConfigurationManager.AppSettings[AS_WCFIPAddress].ToString();
            string[] whitelist = appSetting.Split(separator, StringSplitOptions.None);
            bool isAuthenticated = false;
            for (int i = 0; i < whitelist.Length; i++)
            {
                if (ip == whitelist[i])
                {
                    isAuthenticated = true;
                    break;
                }
            }
            if (!isAuthenticated)
            {
                Exception ex = new Exception(ip);
                BusinessErrorHandling(ex, GetCurrentMethod());
                throw (ex);
            }

            return isAuthenticated;
        }
        #endregion

        /// <summary>
        /// Serialize given object into XmlElement.
        /// </summary>
        /// <param name="transformObject">Input object for serialization.</param>
        /// <returns>Returns serialized XmlElement.</returns>
        #region Serialize given object into stream.
        public static XmlElement Serialize(object transformObject)
        {
            XmlElement serializedElement = null;
            try
            {
                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(transformObject.GetType());
                serializer.Serialize(memStream, transformObject);
                memStream.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(memStream);
                serializedElement = xmlDoc.DocumentElement;
            }
            catch (Exception SerializeException)
            {
                BusinessErrorHandling(SerializeException, GetCurrentMethod());
            }
            return serializedElement;
        }
        #endregion // End - Serialize given object into stream.

        /// <summary>
        /// Deserialize given XmlElement into object.
        /// </summary>
        /// <param name="xmlElement">xmlElement to deserialize.</param>
        /// <param name="tp">Type of resultant deserialized object.</param>
        /// <returns>Returns deserialized object.</returns>
        #region Deserialize given string into object.
        public static object Deserialize(XmlElement xmlElement, System.Type tp)
        {
            Object transformedObject = null;
            try
            {
                Stream memStream = StringToStream(xmlElement.OuterXml);
                XmlSerializer serializer = new XmlSerializer(tp);
                transformedObject = serializer.Deserialize(memStream);
            }
            catch (Exception DeserializeException)
            {
                BusinessErrorHandling(DeserializeException, GetCurrentMethod());
            }
            return transformedObject;
        }
        #endregion // End - Deserialize given string into object.
        /// <summary>
        /// Conversion from string to stream.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <returns>Returns stream.</returns>
        #region Conversion from string to stream.
        public static Stream StringToStream(String str)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);//new byte[str.Length];
                memStream = new MemoryStream(buffer);
            }
            catch (Exception StringToStreamException)
            {
                BusinessErrorHandling(StringToStreamException, GetCurrentMethod());
            }
            finally
            {
                memStream.Position = 0;
            }

            return memStream;
        }
        #endregion // End - Conversion from string to stream.

        #endregion
    }
}
