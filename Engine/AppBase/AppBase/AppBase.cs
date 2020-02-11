using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Net.Mime;

namespace Universal.X307.AppBase
{
    public class AppBase
    {
        #region Public Variables

        #region AppSetting
        public const string AS_DATABASE_NAME = "Database";
        public const string AS_LOGFILE_PATH = "LogFile";
        public const string AS_WCFIPAddress = "WCFIPAddress";
        public const string AS_SMTPMode = "SMTPMode";
        public const string AS_SMTPRelayServerURL = "SMTPRelayServerURL";
        public const string AS_SMTPRelayServerPort = "SMTPRelayServerPort";
        public const string AS_SMTPHost = "SMTPHost";
        public const string AS_SMTPPort = "SMTPPort";
        public const string AS_SMTPUserID = "SMTPUserID";
        public const string AS_SMTPPassword = "SMTPPassword";
        public const string AS_DEFAULTRETRYCOUNT = "DefaultRetryCount";
        #endregion

        #region Constant
        public const string RELAY = "Relay";
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

        #region SendEmail
        public SmtpStatusCode SendEmail(string receiver, string bccReceiver, string ccReceiver, string subject, string content, string attachment)
        {
            SmtpStatusCode emailStatusCode = SmtpStatusCode.Ok;

            try
            {
                MailMessage message = new MailMessage();
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.Body = content;

                // Add Receive
                if (receiver != string.Empty)
                {
                    foreach (string email in receiver.Split(','))
                    {
                        message.To.Add(new MailAddress(email));
                    }
                }

                // Add BCC Receive
                if (bccReceiver != string.Empty)
                {
                    foreach (string email in bccReceiver.Split(','))
                    {
                        message.To.Add(new MailAddress(email));
                    }
                }

                // Add CC Receive
                if (ccReceiver != string.Empty)
                {
                    foreach (string email in ccReceiver.Split(','))
                    {
                        message.To.Add(new MailAddress(email));
                    }
                }

                // Add Attachment
                if (attachment != string.Empty)
                {
                    foreach (string file in attachment.Split(','))
                    {
                        message.Attachments.Add(new Attachment(file, MediaTypeNames.Application.Octet));
                    }
                }

                // From Address
                message.From = new MailAddress(ConfigurationManager.AppSettings[AS_SMTPUserID]);

                string smtpMode = ConfigurationManager.AppSettings[AS_SMTPMode];
                string smtpHost = "";
                string smtpPort = "";

                if (smtpMode == RELAY)
                {
                    smtpHost = ConfigurationManager.AppSettings[AS_SMTPRelayServerURL];
                    smtpPort = ConfigurationManager.AppSettings[AS_SMTPRelayServerPort];
                }
                else
                {
                    smtpHost = ConfigurationManager.AppSettings[AS_SMTPHost];
                    smtpPort = ConfigurationManager.AppSettings[AS_SMTPPort];
                }

                SmtpClient client = new SmtpClient(smtpHost, Convert.ToInt32(smtpPort));
                client.EnableSsl = true;

                if (smtpMode == RELAY)
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                }
                else
                {
                    //Get email credential
                    string userID = ConfigurationManager.AppSettings[AS_SMTPUserID];
                    string password = ConfigurationManager.AppSettings[AS_SMTPPassword];
                    NetworkCredential cred = new NetworkCredential(userID, password);
                    client.Credentials = cred;
                }

#if(DEBUG)
                client.Send(message);
#endif
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length - 1; i++)
                {
                    emailStatusCode = ex.InnerExceptions[i].StatusCode;
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, receiver + " " + subject);
                emailStatusCode = SmtpStatusCode.GeneralFailure;
            }

            return emailStatusCode;
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

        #endregion
    }
}
