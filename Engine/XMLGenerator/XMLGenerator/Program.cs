using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

using XMLGenerator.WCFCompetition;

namespace XMLGenerator
{
    class Program
    {
        public static string xmlOutputPath = string.Empty;

        static void Main(string[] args)
        {
            try
            {
                xmlOutputPath = ConfigurationManager.AppSettings["XMLOutputPath"].ToString();
                System.IO.Directory.CreateDirectory(xmlOutputPath);
                //GenerateScheduleJson();
                //GenerateMedalStandingJson();
                //GenerateScheduleXML();
                //GenerateMedalStanding();
                //GenerateLatestMedallistXML();
            }
            catch(Exception ex)
            {
                string sSource;
                string sLog;

                sSource = "SEM.Result.XML Generator";
                sLog = "Application";

                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);

                StringBuilder strBuilder = new StringBuilder();
                if (ex.InnerException != null)
                {
                    strBuilder.AppendLine("Inner Exception Type: ");
                    strBuilder.AppendLine(ex.InnerException.GetType().ToString());
                    strBuilder.AppendLine("Inner Exception: ");
                    strBuilder.AppendLine(ex.InnerException.Message);
                    strBuilder.AppendLine("Inner Source: ");
                    strBuilder.AppendLine(ex.InnerException.Source);
                    if (ex.InnerException.StackTrace != null)
                    {
                        strBuilder.AppendLine("Inner Stack Trace: ");
                        strBuilder.AppendLine(ex.InnerException.StackTrace);
                    }
                }
                strBuilder.AppendLine("Exception Type: ");
                strBuilder.AppendLine(ex.GetType().ToString());
                strBuilder.AppendLine("Exception: " + ex.Message);
                strBuilder.AppendLine("Source: " + sSource);
                strBuilder.AppendLine("Stack Trace: ");
                if (ex.StackTrace != null)
                {
                    strBuilder.AppendLine(ex.StackTrace);
                    strBuilder.AppendLine();
                }

                EventLog.WriteEntry(sSource, strBuilder.ToString());
                EventLog.WriteEntry(sSource, strBuilder.ToString(), EventLogEntryType.Warning);
            }

            return;
        }

        static void GenerateScheduleJson()
        {
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            DateTime[] genDates = new DateTime[]
            {
                new DateTime(2015, 12, 03),
                new DateTime(2015, 12, 04),
                new DateTime(2015, 12, 05),
                new DateTime(2015, 12, 06),
                new DateTime(2015, 12, 07),
                new DateTime(2015, 12, 08),
                new DateTime(2015, 12, 09),
            };

            foreach (DateTime genDate in genDates)
            {
                CompetitionDS requestDS = new CompetitionDS();
                CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
                row.ScheduleDateTime = genDate;
                requestDS.ScheduleDetail.AddScheduleDetailRow(row);

                responseDS = svc.GetXMLSchedule(requestDS);

                String outputFile = System.IO.Path.Combine(xmlOutputPath, "Schedule_" + genDate.ToString("yyyyMMdd") + ".txt");

                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                string content = "";

                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Newtonsoft.Json.Formatting.Indented;

                    writer.WriteStartObject();
                    writer.WritePropertyName("date");
                    writer.WriteValue(genDate.ToString("yyyy-MM-dd"));
                    writer.WritePropertyName("scheduleUnit");
                    writer.WriteStartArray();
                    foreach (CompetitionDS.ScheduleDetailRow schedule in responseDS.ScheduleDetail)
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName("discipline");
                        writer.WriteValue(schedule["SportCode"].ToString()); writer.WritePropertyName("sex");
                        writer.WriteValue(schedule["GenderName"].ToString());
                        writer.WritePropertyName("event");
                        writer.WriteValue(schedule["EventID"].ToString());
                        writer.WritePropertyName("unit");
                        writer.WriteValue(schedule["ScheduleID"].ToString());
                        writer.WritePropertyName("startTime");
                        writer.WriteValue(Convert.ToDateTime(schedule["ScheduleDateTime"]).ToString("HH:mm"));
                        writer.WritePropertyName("venue");
                        writer.WriteValue(schedule["Venue"].ToString());
                        writer.WritePropertyName("location");
                        writer.WriteValue(schedule["Location"].ToString());
                        writer.WritePropertyName("hasMedal");
                        writer.WriteValue(schedule["IsMedalGame"].ToString().ToLower());
                        writer.WritePropertyName("eventDesc");
                        writer.WriteValue(schedule["EventName"].ToString());
                        writer.WritePropertyName("eventUnitDesc");
                        writer.WriteValue(schedule["ScheduleName"].ToString());
                        writer.WritePropertyName("status");
                        writer.WriteValue(schedule["StatusCodeID"].ToString());
                        writer.WritePropertyName("isH2H");
                        writer.WriteValue(schedule["HeadToHead"].ToString().ToLower());
                        writer.WritePropertyName("player1Code");
                        writer.WriteValue(schedule["ParticipantID1"].ToString());
                        writer.WritePropertyName("player1Name");
                        writer.WriteValue(schedule["IsIndividualGame"].ToString() == "0" ? schedule["TeamName1"].ToString() : schedule["FullName1"].ToString());
                        writer.WritePropertyName("player1Country");
                        writer.WriteValue(schedule["CountryName1"].ToString());
                        writer.WritePropertyName("player1Score");
                        writer.WriteValue(schedule["ScoreFinal1"].ToString());
                        writer.WritePropertyName("player1IsWinner");
                        writer.WriteValue(schedule["Winner1"].ToString());
                        writer.WritePropertyName("player2Code");
                        writer.WriteValue(schedule["ParticipantID2"].ToString());
                        writer.WritePropertyName("player2Name");
                        writer.WriteValue(schedule["IsIndividualGame"].ToString() == "0" ? schedule["TeamName2"].ToString() : schedule["FullName2"].ToString());
                        writer.WritePropertyName("player2Country");
                        writer.WriteValue(schedule["CountryName2"].ToString());
                        writer.WritePropertyName("player2Score");
                        writer.WriteValue(schedule["ScoreFinal2"].ToString());
                        writer.WritePropertyName("player2IsWinner");
                        writer.WriteValue(schedule["Winner2"].ToString());
                        writer.WriteEndObject();
                    }
                    writer.WriteEnd();
                    writer.WriteEndObject();
                    
                    content = sw.ToString();
                }


                //string content = "{\"date\": \"" + genDate.ToString("yyyy-MM-dd") + "\",\"scheduleUnit\": ";
                //content += JsonConvert.SerializeObject(responseDS.ScheduleDetail);
                //content += "}";
                File.WriteAllText(outputFile, content);
            }
        }


        static void GenerateMedalStandingJson()
        {
            DataSet ds = new DataSet();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
            requestDS.ScheduleDetail.AddScheduleDetailRow(row);

            responseDS = svc.GetXMLMedalStanding(requestDS);

            String outputFile = System.IO.Path.Combine(xmlOutputPath, "MedalStanding.txt");
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            string content = "";

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Newtonsoft.Json.Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("code");
                writer.WriteValue("All");
                writer.WritePropertyName("medals");
                writer.WriteStartArray();

                foreach (CompetitionDS.MedalStandingsRow medalStanding in responseDS.MedalStandings)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("country");
                    writer.WriteValue(medalStanding["CountryName"].ToString());
                    writer.WritePropertyName("gold");
                    writer.WriteValue(medalStanding["GoldMedal"].ToString());
                    writer.WritePropertyName("silver");
                    writer.WriteValue(medalStanding["SilverMedal"].ToString());
                    writer.WritePropertyName("bronze");
                    writer.WriteValue(medalStanding["BronzeMedal"].ToString());
                    writer.WritePropertyName("total");
                    writer.WriteValue(medalStanding["Total"].ToString());
                    writer.WriteEndObject();
                }

                writer.WriteEnd();
                writer.WriteEndObject();

                content = sw.ToString();
            }
            File.WriteAllText(outputFile, content);            
        }

        static void GenerateScheduleXML()
        {
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            DateTime[] genDates = new DateTime[]
            {
                new DateTime(2015, 12, 03),
                new DateTime(2015, 12, 04),
                new DateTime(2015, 12, 05),
                new DateTime(2015, 12, 06),
                new DateTime(2015, 12, 07),
                new DateTime(2015, 12, 08),
                new DateTime(2015, 12, 09),
            };

            foreach (DateTime genDate in genDates)
            {
                CompetitionDS requestDS = new CompetitionDS();
                CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
                row.ScheduleDateTime = genDate;
                requestDS.ScheduleDetail.AddScheduleDetailRow(row);

                responseDS = svc.GetXMLSchedule(requestDS);

                String outputFile = System.IO.Path.Combine(xmlOutputPath, "Schedule_" + genDate.ToString("yyyyMMdd") + ".xml");
                XmlWriter writer;
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (writer = XmlWriter.Create(outputFile, xmlWriterSettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("competition");
                    writer.WriteAttributeString("date", genDate.ToString("yyyy-MM-dd"));

                    foreach (CompetitionDS.ScheduleDetailRow schedule in responseDS.ScheduleDetail)
                    {
                        writer.WriteStartElement("scheduleUnit");
                        writer.WriteAttributeString("discipline", schedule["SportCode"].ToString());
                        writer.WriteAttributeString("sex", schedule["GenderName"].ToString());
                        writer.WriteAttributeString("event", schedule["EventID"].ToString());
                        writer.WriteAttributeString("unit", schedule["ScheduleID"].ToString());
                        writer.WriteAttributeString("startTime", Convert.ToDateTime(schedule["ScheduleDateTime"]).ToString("HH:mm"));
                        writer.WriteAttributeString("venue", schedule["Venue"].ToString());
                        writer.WriteAttributeString("location", schedule["Location"].ToString());
                        writer.WriteAttributeString("hasMedal", schedule["IsMedalGame"].ToString().ToLower());
                        writer.WriteAttributeString("eventDesc", schedule["EventName"].ToString());
                        writer.WriteAttributeString("eventUnitDesc", schedule["ScheduleName"].ToString());
                        writer.WriteAttributeString("status", schedule["StatusCodeID"].ToString());
                        writer.WriteAttributeString("isH2H", schedule["HeadToHead"].ToString().ToLower());
                        writer.WriteAttributeString("player1Code", schedule["ParticipantID1"].ToString());
                        writer.WriteAttributeString("player1Name", schedule["IsIndividualGame"].ToString() == "0" ? schedule["TeamName1"].ToString() : schedule["FullName1"].ToString());
                        writer.WriteAttributeString("player1Country", schedule["CountryName1"].ToString());
                        writer.WriteAttributeString("player1Score", schedule["ScoreFinal1"].ToString());
                        writer.WriteAttributeString("player1IsWinner", schedule["Winner1"].ToString());
                        writer.WriteAttributeString("player2Code", schedule["ParticipantID2"].ToString());
                        writer.WriteAttributeString("player2Name", schedule["IsIndividualGame"].ToString() == "0" ? schedule["TeamName2"].ToString() : schedule["FullName2"].ToString());
                        writer.WriteAttributeString("player2Country", schedule["CountryName2"].ToString());
                        writer.WriteAttributeString("player2Score", schedule["ScoreFinal2"].ToString());
                        writer.WriteAttributeString("player2IsWinner", schedule["Winner2"].ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

            }
        }

        static void GenerateMedalStanding()
        {
            DataSet ds = new DataSet();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
            requestDS.ScheduleDetail.AddScheduleDetailRow(row);

            responseDS = svc.GetXMLMedalStanding(requestDS);

            String outputFile = System.IO.Path.Combine(xmlOutputPath, "MedalStanding.xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create(outputFile, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("discipline");
                writer.WriteAttributeString("code", "All");

                foreach (CompetitionDS.MedalStandingsRow medalStanding in responseDS.MedalStandings)
                {
                    writer.WriteStartElement("medals");
                    writer.WriteStartElement("medal");
                    writer.WriteAttributeString("country", medalStanding["CountryName"].ToString());
                    writer.WriteElementString("gold", medalStanding["GoldMedal"].ToString());
                    writer.WriteElementString("silver", medalStanding["SilverMedal"].ToString());
                    writer.WriteElementString("bronze", medalStanding["BronzeMedal"].ToString());
                    writer.WriteElementString("total", medalStanding["Total"].ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        static void GenerateLatestMedallistXML()
        {
            DataSet ds = new DataSet();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionClient svc = new CompetitionClient();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();
            requestDS.ScheduleDetail.AddScheduleDetailRow(row);

            responseDS = svc.GetXMLLatestMedalist(requestDS);

            String outputFile = System.IO.Path.Combine(xmlOutputPath, "LatestMedallist.xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create(outputFile, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("competition");

                foreach (CompetitionDS.LatestMedalistRow latestMedalist in responseDS.LatestMedalist)
                {
                    writer.WriteStartElement("latestMedal");
                    writer.WriteAttributeString("discipline", latestMedalist["SportCode"].ToString());
                    writer.WriteAttributeString("sex", latestMedalist["ReferenceCode"].ToString());
                    writer.WriteAttributeString("event", latestMedalist["EventID"].ToString());
                    writer.WriteAttributeString("eventName", latestMedalist["EventName"].ToString());
                    writer.WriteAttributeString("playerCode", latestMedalist["ParticipantID"].ToString());
                    writer.WriteAttributeString("playerName", latestMedalist["FullName"].ToString());
                    //string filename = Path.GetFileNameWithoutExtension(latestMedalist["IconFilePath"].ToString());
                    writer.WriteAttributeString("playerCountry", latestMedalist["ISOCode3"].ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
