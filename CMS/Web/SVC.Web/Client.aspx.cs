using System;
using System.Collections.Generic;
using System.Collections.Specialized;   //add this for NameValueCollection
using System.IO;    
using System.Linq;
using System.Net;   //add this for WebClient
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SVC.Web
{
    public partial class Client : System.Web.UI.Page
    {
        //------------------------------------
        //Sample:
        //private const string REQUEST_PARAMETER1 = "Parameter1";
        //private const string REQUEST_PARAMETER2 = "Parameter2";
        //------------------------------------
        #region InsertResult_UpdateResult
        private const string REQUEST_PARAMETER1 = "ScheduleID";
        private const string REQUEST_PARAMETER2 = "TeamOrParticipantID";
        private const string REQUEST_PARAMETER3 = "Score1";
        private const string REQUEST_PARAMETER4 = "Score2";
        private const string REQUEST_PARAMETER5 = "Score3";
        private const string REQUEST_PARAMETER6 = "Score4";
        private const string REQUEST_PARAMETER7 = "Score5";
        private const string REQUEST_PARAMETER8 = "Score6";
        private const string REQUEST_PARAMETER9 = "Score7";
        private const string REQUEST_PARAMETER10 = "Score8";
        private const string REQUEST_PARAMETER11 = "Score9";
        private const string REQUEST_PARAMETER12 = "Score10";
        private const string REQUEST_PARAMETER13 = "Score11";
        private const string REQUEST_PARAMETER14 = "Score12";
        private const string REQUEST_PARAMETER15 = "Score13";
        private const string REQUEST_PARAMETER16 = "Score14";
        private const string REQUEST_PARAMETER17 = "Score15";
        private const string REQUEST_PARAMETER18 = "Score16";
        private const string REQUEST_PARAMETER19 = "Score17";
        private const string REQUEST_PARAMETER20 = "Score18";
        private const string REQUEST_PARAMETER21 = "Score19";
        private const string REQUEST_PARAMETER22 = "Score20";
        private const string REQUEST_PARAMETER23 = "ScoreFinal";
        private const string REQUEST_PARAMETER24 = "ScoreName1";
        private const string REQUEST_PARAMETER25 = "ScoreName2";
        private const string REQUEST_PARAMETER26 = "ScoreName3";
        private const string REQUEST_PARAMETER27 = "ScoreName4";
        private const string REQUEST_PARAMETER28 = "ScoreName5";
        private const string REQUEST_PARAMETER29 = "ScoreName6";
        private const string REQUEST_PARAMETER30 = "ScoreName7";
        private const string REQUEST_PARAMETER31 = "ScoreName8";
        private const string REQUEST_PARAMETER32 = "ScoreName9";
        private const string REQUEST_PARAMETER33 = "ScoreName10";
        private const string REQUEST_PARAMETER34 = "ScoreName11";
        private const string REQUEST_PARAMETER35 = "ScoreName12";
        private const string REQUEST_PARAMETER36 = "ScoreName13";
        private const string REQUEST_PARAMETER37 = "ScoreName14";
        private const string REQUEST_PARAMETER38 = "ScoreName15";
        private const string REQUEST_PARAMETER39 = "ScoreName16";
        private const string REQUEST_PARAMETER40 = "ScoreName17";
        private const string REQUEST_PARAMETER41 = "ScoreName18";
        private const string REQUEST_PARAMETER42 = "ScoreName19";
        private const string REQUEST_PARAMETER43 = "ScoreName20";
        private const string REQUEST_PARAMETER44 = "ScoreNameFinal";
        private const string REQUEST_PARAMETER45 = "BreakRecord";
        private const string REQUEST_PARAMETER46 = "MedalID";
        private const string REQUEST_PARAMETER47 = "ResultPosition";
        private const string REQUEST_PARAMETER48 = "IsOfficial";
        #endregion

        #region Insert/Update/Delete Schedule
        private const string REQUEST_PARAMETER_EventID = "EventID";
        private const string REQUEST_PARAMETER_ScheduleID = "ScheduleID";
        private const string REQUEST_PARAMETER_ScheduleName = "ScheduleName";
        private const string REQUEST_PARAMETER_ScheduleDateTime = "ScheduleDateTime";
        private const string REQUEST_PARAMETER_Venue = "Venue";
        private const string REQUEST_PARAMETER_Location = "Location";
        private const string REQUEST_PARAMETER_RoundName = "RoundName";
        private const string REQUEST_PARAMETER_MatchNumber = "MatchNumber";
        private const string REQUEST_PARAMETER_CompetitionStage = "CompetitionStage";
        private const string REQUEST_PARAMETER_TotalParticipant = "TotalParticipant";
        private const string REQUEST_PARAMETER_PlayFormatID = "PlayFormatID";
        private const string REQUEST_PARAMETER_GroupCode = "GroupCode";
        private const string REQUEST_PARAMETER_StatusCodeID = "StatusCodeID";
        private const string REQUEST_PARAMETER_HeadToHead = "HeadToHead";
        private const string REQUEST_PARAMETER_IsMedalGame = "IsMedalGame";
        private const string REQUEST_PARAMETER_IsPublishGame = "IsPublishGame";
        private const string REQUEST_PARAMETER_IsOfficial = "IsOfficial";
        #endregion

        #region Insert/Update StartList
        private const string REQUEST_PARAMETER_ParticipantID = "ParticipantID";
        private const string REQUEST_PARAMETER_TeamID = "TeamID";
        private const string REQUEST_PARAMETER_BibNumber = "BibNumber";
        private const string REQUEST_PARAMETER_Description = "Description";
        private const string REQUEST_PARAMETER_IsDelete = "IsDelete";
        #endregion
        //------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
           // Sample();
            // set this as start page for debug
            using (var client = new WebClient())
            {
                //InsertSchedule(client);
                //UpdateSchedule(client);
                //DeleteSchedule(client);
                InsertResult_UpdateResult(client);
                //DeleteResult(client);
                
                //InsertUpdatStartList(client);
            }
        }

        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return string.Join("&", array);
        }

        private void InsertUpdatStartList(WebClient client)
        {
            #region Insert/Update StartList
            var values = new NameValueCollection
                            {
                                { REQUEST_PARAMETER_ScheduleID, "4" },
                                { REQUEST_PARAMETER_ParticipantID, "1" },
                                { REQUEST_PARAMETER_TeamID, "99" },
                                { REQUEST_PARAMETER_IsDelete, "true" }
                            };

            Uri requestUri = new Uri(Request.Url.ToString());
            //Uri requestUri = new Uri("https://uat-gis.aseanparagames2015.com/");
            UriBuilder uri = new UriBuilder(requestUri);
            uri.Path = "/UpdateStartList.aspx";  //1 aspx for 1 interface, so your 1st 1 would be InsertStartList.aspx
            uri.Query = "";
            uri.Path = "/Services/InsertSchedule.aspx";  //1 aspx for 1 interface, so your 1st 1 would be InsertStartList.aspx
            uri.Query = ToQueryString(values);
            //client.UploadValues(uri.Uri, values);

            byte[] result = client.DownloadData(uri.Uri);
                //byte[] result = client.UploadValues(uri.Uri, values);
            string text = System.Text.Encoding.UTF8.GetString(result);
            Response.Write(text);
            #endregion
        }

        private void DeleteSchedule(WebClient client)
        {
            #region Delete Schedule
                //var values = new NameValueCollection
                //            {
            //                { REQUEST_PARAMETER_ScheduleID, "99" }
                //            };

                //Uri requestUri = new Uri(Request.Url.ToString());
                //UriBuilder uri = new UriBuilder(requestUri);
            //uri.Path = "/DeleteSchedule.aspx";  //1 aspx for 1 interface, so your 1st 1 would be InsertStartList.aspx
                //uri.Query = "";
                ////client.UploadValues(uri.Uri, values);

                //byte[] result = client.UploadValues(uri.Uri, values);
                //string text = System.Text.Encoding.UTF8.GetString(result);
                //Response.Write(text);
            #endregion
        }

        private void UpdateSchedule(WebClient client)
        {
            #region Update Schedule

            string scheduleID = "";
            string scheduleDateTime = "20141018 163706";
            var values = new NameValueCollection
                            {
                            { REQUEST_PARAMETER_ScheduleID, scheduleID },
                            { REQUEST_PARAMETER_ScheduleName, "Test Schedule Name 2" },
                            { REQUEST_PARAMETER_ScheduleDateTime, scheduleDateTime },
                            { REQUEST_PARAMETER_Venue, "Test Venue" },
                            { REQUEST_PARAMETER_Location, "Test Location" },
                            { REQUEST_PARAMETER_RoundName, "Test Round Name" },
                            { REQUEST_PARAMETER_MatchNumber, "9" },
                            { REQUEST_PARAMETER_CompetitionStage, "8" },
                            { REQUEST_PARAMETER_TotalParticipant, "7" },
                            { REQUEST_PARAMETER_PlayFormatID, "1" },
                            { REQUEST_PARAMETER_GroupCode, "Z" },
                            { REQUEST_PARAMETER_StatusCodeID, "1" },
                            { REQUEST_PARAMETER_HeadToHead, "true" },
                            { REQUEST_PARAMETER_IsMedalGame, "true" },
                            { REQUEST_PARAMETER_IsPublishGame, "true" },
                            { REQUEST_PARAMETER_IsOfficial, "false" }
                            };

            //Uri requestUri = new Uri("https://uat-gis.aseanparagames2015.com/");
            Uri requestUri = new Uri("http://localhost:2202//");
            UriBuilder uri = new UriBuilder(requestUri);
            uri.Path = "/Services/UpdateSchedule.aspx"; //1 aspx for 1 interface, so your 1st 1 would be InsertStartList.aspx
            uri.Query = "";
            //client.UploadValues(uri.Uri, values);

            byte[] result = client.UploadValues(uri.Uri, values);
            string text = System.Text.Encoding.UTF8.GetString(result);
            Response.Write(text);
            #endregion
        }

        private void InsertSchedule(WebClient client)
        {
            #region Insert Schedule
            var values = new NameValueCollection
                            {
                                { REQUEST_PARAMETER_EventID, "99" },
                                { REQUEST_PARAMETER_ScheduleName, "Test Schedule Name" },
                                { REQUEST_PARAMETER_ScheduleDateTime, "20141018 163706" },
                                { REQUEST_PARAMETER_Venue, "Test Venue" },
                                { REQUEST_PARAMETER_Location, "Test Location" },
                                { REQUEST_PARAMETER_RoundName, "Test Round Name" },
                                { REQUEST_PARAMETER_MatchNumber, "9" },
                                { REQUEST_PARAMETER_CompetitionStage, "8" },
                                { REQUEST_PARAMETER_TotalParticipant, "7" },
                                { REQUEST_PARAMETER_PlayFormatID, "1" },
                                { REQUEST_PARAMETER_GroupCode, "Z" },
                                { REQUEST_PARAMETER_StatusCodeID, "1" },
                                { REQUEST_PARAMETER_HeadToHead, "true" },
                                { REQUEST_PARAMETER_IsMedalGame, "true" },
                                { REQUEST_PARAMETER_IsPublishGame, "true" },
                                { REQUEST_PARAMETER_IsOfficial, "false" }
                            };

            //Uri requestUri = new Uri(Request.Url.ToString());
            //Uri requestUri = new Uri("https://uat-gis.aseanparagames2015.com/");
            Uri requestUri = new Uri("http://localhost:2202//");
            UriBuilder uri = new UriBuilder(requestUri);
            uri.Path = "/Services/InsertSchedule.aspx";  //1 aspx for 1 interface, so your 1st 1 would be InsertStartList.aspx
            uri.Query = "";

            byte[] result = client.UploadValues(uri.Uri, values);
            string text = System.Text.Encoding.UTF8.GetString(result);
            Response.Write(text);
            #endregion
        }

        private void DeleteResult(WebClient client)
        {
            //------------------------------------
            //DeleteResult:
            //------------------------------------
            #region DeleteResult
                //var values = new NameValueCollection
                //            {
            //                { REQUEST_PARAMETER1, "55" },
            //                { REQUEST_PARAMETER2, "77" }
                //            };

                //Uri requestUri = new Uri(Request.Url.ToString());
                //UriBuilder uri = new UriBuilder(requestUri);
            //uri.Path = "/DeleteResult.aspx"; 
                //uri.Query = "";

                //byte[] result = client.UploadValues(uri.Uri, values);
                //string text = System.Text.Encoding.UTF8.GetString(result);
                //Response.Write(text);
                #endregion
        }

        private void InsertResult_UpdateResult(WebClient client)
        { 
            #region InsertResult_UpdateREsult
            string scheduleID = "927", teamID = "181";  //43
            var values = new NameValueCollection
                            {
                                { REQUEST_PARAMETER1, scheduleID },         //scheduleID
                                { REQUEST_PARAMETER2, teamID },             //teamID
                                { REQUEST_PARAMETER3, "2" },             //Score1
                                { REQUEST_PARAMETER4, "" },
                                { REQUEST_PARAMETER5, "" },
                                { REQUEST_PARAMETER6, "" },
                                { REQUEST_PARAMETER7, "" },
                                { REQUEST_PARAMETER8, "" },
                                { REQUEST_PARAMETER9, "" },
                                { REQUEST_PARAMETER10, "" },
                                { REQUEST_PARAMETER11, "" },
                                { REQUEST_PARAMETER12, "" },
                                { REQUEST_PARAMETER13, "" },
                                { REQUEST_PARAMETER14, "" },
                                { REQUEST_PARAMETER15, "" },
                                { REQUEST_PARAMETER16, "" },
                                { REQUEST_PARAMETER17, "" },
                                { REQUEST_PARAMETER18, "" },
                                { REQUEST_PARAMETER19, "" },
                                { REQUEST_PARAMETER20, "" },
                                { REQUEST_PARAMETER21, "" },
                                { REQUEST_PARAMETER22, "" },
                                { REQUEST_PARAMETER23, "10.87" },           //ScoreFinal
                                { REQUEST_PARAMETER24, "Lane" },
                                { REQUEST_PARAMETER25, "" },
                                { REQUEST_PARAMETER26, "" },
                                { REQUEST_PARAMETER27, "" },
                                { REQUEST_PARAMETER28, "" },
                                { REQUEST_PARAMETER29, "" },
                                { REQUEST_PARAMETER30, "" },
                                { REQUEST_PARAMETER31, "" },
                                { REQUEST_PARAMETER32, "" },
                                { REQUEST_PARAMETER33, "" },
                                { REQUEST_PARAMETER34, "" },
                                { REQUEST_PARAMETER35, "" },
                                { REQUEST_PARAMETER36, "" },
                                { REQUEST_PARAMETER37, "" },
                                { REQUEST_PARAMETER38, "" },
                                { REQUEST_PARAMETER39, "" },
                                { REQUEST_PARAMETER40, "" },
                                { REQUEST_PARAMETER41, "" },
                                { REQUEST_PARAMETER42, "" },
                                { REQUEST_PARAMETER43, "" },
                                { REQUEST_PARAMETER44, "Final" },            //Final
                                { REQUEST_PARAMETER45, "" },            //Record
                                { REQUEST_PARAMETER46, "1" },           //Medal
                                { REQUEST_PARAMETER47, "1" },           //Position
                                { REQUEST_PARAMETER48, "" }
                            };

            //Uri requestUri = new Uri(Request.Url.ToString());
            //Uri requestUri = new Uri("https://uat-gis.aseanparagames2015.com/");
            Uri requestUri = new Uri("http://localhost:2202/");
            UriBuilder uri = new UriBuilder(requestUri);
            uri.Path = "/Services/InsertResult.aspx";  //1 aspx for 1 interface, so your 1st 1 would be InsertStartList.aspx
            uri.Query = "";
            //client.UploadValues(uri.Uri, values);

            byte[] result = client.UploadValues(uri.Uri, values);
            string text = System.Text.Encoding.UTF8.GetString(result);
            Response.Write(text);
                #endregion
        }

        private void Sample()
                            {
            string contents = "";
            string url = "http://ruat.aseanparagames2015.com/Schedule/General.aspx";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            GetPage(url);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
                
            StreamReader reader = new StreamReader( stream );
        
            contents = reader.ReadToEnd();

            string path = @"C:\Data\MyTest.txt";
            File.WriteAllText(path, contents);
        }

        public static void GetPage(String url)
        {
            try
            {
                Uri ourUri = new Uri(url);
                // Creates an HttpWebRequest for the specified URL. 
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(ourUri);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Console.WriteLine("\nThe server did not issue any challenge.  Please try again with a protected resource URL.");
                // Releases the resources of the response.
                myHttpWebResponse.Close();
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                if (response != null)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        string challenge = null;
                        challenge = response.GetResponseHeader("WWW-Authenticate");
                        if (challenge != null)
                            Console.WriteLine("\nThe following challenge was raised by the server:{0}", challenge);
                    }
                    else
                        Console.WriteLine("\nThe following WebException was raised : {0}", e.Message);
                }
                else
                    Console.WriteLine("\nResponse Received from server was null");

            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
        }
    }
}