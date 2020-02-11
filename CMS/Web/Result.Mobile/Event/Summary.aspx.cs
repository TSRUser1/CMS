using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Mobile.WCFCompetition;
using SEM.CMS.CL.AR.Common;
using System.Data;
using SEM.CMS.Result.Mobile.UserControls;
using System.Web.UI.HtmlControls;

namespace SEM.CMS.Result.Mobile.Event
{
    public partial class Summary : System.Web.UI.Page
    {
        protected ReferenceNum.EventType eventType;
        protected bool IsMedalGame;
        protected bool IsKnockout;
        protected bool IsLeague;
        protected bool IsTimeDistancePoints;
        protected bool IsTogleHtmlMode;
        protected CompetitionDS.SportEventScheduleRow sportEventScheduleRow;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
                {
                    ViewState[WebBase.VS_SCHEDULEID] = Request.QueryString[WebBase.QS_SCHEDULEID];
                }

                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    ViewState[WebBase.VS_EVENTID] = Request.QueryString[WebBase.QS_EVENTID];
                }

                GetSportEventSchedule();

                if (!IsTogleHtmlMode)
                {
                    if (IsKnockout)
                    {
                        pnlKnockout.Visible = true;
                        GetKnockoutSummary();
                    }

                    if (IsLeague)
                    {
                        pnlLeague.Visible = true;
                        GetLeagueRanking();
                        GetLeagueSummary();
                    }
                }
                else
                {
                    pnlKnockout.Visible = false;
                    pnlLeague.Visible = false;
                }
                
                BindData();
            }
        }

        protected void GetSportEventSchedule()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.SportEventScheduleRow row = requestDS.SportEventSchedule.NewSportEventScheduleRow();

            // Get Schedule ID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            requestDS.SportEventSchedule.AddSportEventScheduleRow(row);

            #region GetSportEventSchedule
            responseDS = svc.GetSportEventSchedule(requestDS);
            if (responseDS.SportEventSchedule.Count > 0)
            {
                eventType = ReferenceNum.EventType.Individual;
                IsKnockout = false;
                IsLeague = false;
                IsTimeDistancePoints = false;

                sportEventScheduleRow = responseDS.SportEventSchedule[0];
                IsKnockout = sportEventScheduleRow.IsKnockout;
                IsLeague = sportEventScheduleRow.IsLeague;
                IsTimeDistancePoints = sportEventScheduleRow.IsTimeDistancePoints;
                IsTogleHtmlMode = (sportEventScheduleRow.IsIsTogleHtmlModeNull()) ? false : sportEventScheduleRow.IsTogleHtmlMode;
                eventType = (ReferenceNum.EventType)sportEventScheduleRow.EventTypeID;

                if (!sportEventScheduleRow.IsEventFooterNoteNull())
                {
                    litEventFooterNote.Text = sportEventScheduleRow.EventFooterNote;
                }
            }
            #endregion
        }

        protected void GetKnockoutSummary()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.KnockoutSummaryRow row = requestDS.KnockoutSummary.NewKnockoutSummaryRow();

            // Get Event ID
            if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
            {
                row.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
            }

            requestDS.KnockoutSummary.AddKnockoutSummaryRow(row);

            #region GetKnockoutSummary
            if (eventType == ReferenceNum.EventType.Individual)
            {
                responseDS = svc.GetKnockoutSummary(requestDS);
            }
            else
            {
                responseDS = svc.GetKnockoutSummaryForTeam(requestDS);
            }

            ViewState[WebBase.VS_KNOCKOUTSUMMARY_DS] = responseDS;
            #endregion
        }

        protected void GetLeagueSummary()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.LeagueSummaryRow row = requestDS.LeagueSummary.NewLeagueSummaryRow();

            // Get Event ID
            if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
            {
                row.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
            }

            requestDS.LeagueSummary.AddLeagueSummaryRow(row);

            #region GetKnockoutSummary
            if (eventType == ReferenceNum.EventType.Individual)
            {
                responseDS = svc.GetLeagueSummary(requestDS);
            }
            else
            {
                responseDS = svc.GetLeagueSummaryForTeam(requestDS);
            }

            ViewState[WebBase.VS_LEAGUESUMMARY_DS] = responseDS;
            #endregion
        }

        protected void GetLeagueRanking()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.LeagueRow row = requestDS.League.NewLeagueRow();

            // Get Event ID
            if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
            {
                row.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
            }

            requestDS.League.AddLeagueRow(row);

            #region GetLeague
            if (eventType == ReferenceNum.EventType.Individual)
            {
                responseDS = svc.GetLeagueForIndividual(requestDS);
            }
            else
            {
                responseDS = svc.GetLeagueForTeam(requestDS);
            }

            ViewState[WebBase.VS_LEAGUE_DS] = responseDS;
            #endregion
        }

        protected CompetitionDS GetScoreName(int scheduleID)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScoreNameRow row = requestDS.ScoreName.NewScoreNameRow();

            row.ScheduleID = scheduleID;

            requestDS.ScoreName.AddScoreNameRow(row);

            #region GetScoreName
            responseDS = svc.GetScoreName(requestDS);
            #endregion

            return responseDS;
        }

        protected CompetitionDS GetParticipantAndScore(int scheduleID)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScoreRow row = requestDS.Score.NewScoreRow();

            row.ScheduleID = scheduleID;

            requestDS.Score.AddScoreRow(row);

            #region GetScoreList
            if (eventType != ReferenceNum.EventType.Individual)
            {
                responseDS = svc.GetTeamAndScore(requestDS);
            }
            else
            {
                responseDS = svc.GetPartcipantAndScore(requestDS);
            }
            #endregion
            return responseDS;
        }

        protected CompetitionDS GetSchedule(int eventID)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScheduleDetailRow row = requestDS.ScheduleDetail.NewScheduleDetailRow();

            row.EventID = eventID;

            requestDS.ScheduleDetail.AddScheduleDetailRow(row);

            #region GetSchedule
            responseDS = svc.GetSchedule(requestDS);

            return responseDS;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS competitionDS = new CompetitionDS();

            #region Knockout
            if (!IsTogleHtmlMode && IsKnockout)
            {
                GenerateKnockoutTable();
            }
            #endregion

            #region League
            if (!IsTogleHtmlMode && IsLeague)
            {
                GenerateLeagueRanking();
                GenerateLeagueSummaryTable();
            }
            #endregion

            #region TimeDistancePoints
            if (!IsTogleHtmlMode)
            {
                if (IsTimeDistancePoints)
                {
                    pnlTimeDistance.Visible = true;
                    GenerateTimeDistancePoints();
                }
            }
            else
            {
                pnlTimeDistance.Visible = false;
            }
                
            #endregion
        }

        protected void GenerateKnockoutTable()
        {
            CompetitionDS competitionDS = new CompetitionDS();
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_KNOCKOUTSUMMARY_DS];

            if (competitionDS.KnockoutSummary.Count > 0)
            {
                for (int i = 0; i < competitionDS.KnockoutSummary.Count; i++)
                {
                    CompetitionDS.KnockoutSummaryRow rowA = competitionDS.KnockoutSummary[i];
                    rowA.PreviousMatchNumber = 0;

                    for (int j = 0; j < competitionDS.KnockoutSummary.Count; j++)
                    {
                        CompetitionDS.KnockoutSummaryRow rowB = competitionDS.KnockoutSummary[j];

                        if (!rowA.IsCompetitionStageNull() && !rowB.IsCompetitionStageNull())
                        {
                            if (eventType == ReferenceNum.EventType.Individual)
                            {
                                if (!rowA.IsFullNameNull() && !rowB.IsFullNameNull())
                                {
                                    if ((rowA.CompetitionStage - 1 == rowB.CompetitionStage) && (rowA.FullName == rowB.FullName))
                                    {
                                        rowA.PreviousMatchNumber = rowB.MatchNumber;
                                    }
                                }
                            }
                            else
                            {
                                if (!rowA.IsTeamNameNull() && !rowB.IsTeamNameNull())
                                {
                                    if ((rowA.CompetitionStage - 1 == rowB.CompetitionStage) && (rowA.TeamName == rowB.TeamName))
                                    {
                                        rowA.PreviousMatchNumber = rowB.MatchNumber;
                                    }
                                }
                            }
                        }
                        
                    }
                }

                competitionDS.KnockoutSummary.AcceptChanges();

                switch (competitionDS.KnockoutSummary[0].TotalParticipant)
                {
                    case 2:
                        ucKnockoutForTwo ucSimpleControl2 = LoadControl("~/UserControls/ucKnockoutForTwo.ascx") as ucKnockoutForTwo;
                        ucSimpleControl2.LoadandBindData(competitionDS, eventType);
                        phKnockout.Controls.Add(ucSimpleControl2);
                        break;
                    case 4:
                        ucKnockoutForFour ucSimpleControl4 = LoadControl("~/UserControls/ucKnockoutForFour.ascx") as ucKnockoutForFour;
                        ucSimpleControl4.LoadandBindData(competitionDS, eventType);
                        phKnockout.Controls.Add(ucSimpleControl4);
                        break;
                    case 8:
                        ucKnockoutForEight ucSimpleControl8 = LoadControl("~/UserControls/ucKnockoutForEight.ascx") as ucKnockoutForEight;
                        ucSimpleControl8.LoadandBindData(competitionDS, eventType);
                        phKnockout.Controls.Add(ucSimpleControl8);
                        break;
                    case 16:
                        ucKnockoutForSixTeen ucSimpleControl16 = LoadControl("~/UserControls/ucKnockoutForSixTeen.ascx") as ucKnockoutForSixTeen;
                        ucSimpleControl16.LoadandBindData(competitionDS, eventType);
                        phKnockout.Controls.Add(ucSimpleControl16);
                        break;
                    case 32:
                        ucKnockoutForThirtyTwo ucSimpleControl32 = LoadControl("~/UserControls/ucKnockoutForThirtyTwo.ascx") as ucKnockoutForThirtyTwo;
                        ucSimpleControl32.LoadandBindData(competitionDS, eventType);
                        phKnockout.Controls.Add(ucSimpleControl32);
                        break;
                }
            }
        }

        protected void GenerateLeagueSummaryTable()
        {
            CompetitionDS competitionDS = new CompetitionDS();
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_LEAGUESUMMARY_DS];

            if (competitionDS.LeagueSummary.Count > 0)
            {
                DataTable groupList = competitionDS.LeagueSummary.DefaultView.ToTable(true, "GroupCode", "IsGenerateLeagueSummary");
                
                foreach (DataRow rowGroup in groupList.Rows)
                {
                    string groupCode = rowGroup["GroupCode"].ToString();
                    bool IsGenerateLeagueSummary = (rowGroup["IsGenerateLeagueSummary"].ToString() == string.Empty) ? true : Convert.ToBoolean(rowGroup["IsGenerateLeagueSummary"].ToString());

                    if (IsGenerateLeagueSummary)
                    {
                        DataRow[] competitionStageList = competitionDS.LeagueSummary.DefaultView.ToTable(true, "CompetitionStage", "GroupCode").Select("GroupCode='" + groupCode + "'");

                        foreach (DataRow compStage in competitionStageList)
                        {
                            Table tblLeagueSummary = new Table();
                            string stage = compStage["CompetitionStage"].ToString();
                            DataRow[] countryList = competitionDS.LeagueSummary.DefaultView.ToTable(true, "CountryName", "IconFilePath", "TeamID", "GroupCode", "TeamName", "CompetitionStage").Select("GroupCode='" + groupCode + "' AND CompetitionStage='" + stage + "'");
                            int rows;
                            int columns;

                            columns = countryList.Length + 1;
                            rows = countryList.Length;

                            // Generate Header Row
                            TableHeaderRow thead = new TableHeaderRow();
                            TableHeaderCell theadcell = new TableHeaderCell();
                            theadcell.Text = "Group " + groupCode;
                            if (competitionStageList.Length > 1)
                            {
                                theadcell.Text += " Stage " + stage;
                            }
                            
                            thead.Cells.Add(theadcell);

                            for (int i = 0; i < countryList.Length; i++)
                            {
                                TableHeaderCell thcell = new TableHeaderCell();
                                thcell.CssClass = "country";
                                thcell.Text = "<img src='" + countryList[i]["IconFilePath"].ToString().Replace("~", "..")
                                    + "' alt='" + countryList[i]["CountryName"] + "' title='"
                                    + countryList[i]["CountryName"] + "' /><br />" + countryList[i]["TeamName"];
                                thead.Cells.Add(thcell);
                            }

                            tblLeagueSummary.Rows.Add(thead);

                            for (int rowCtr = 0; rowCtr < rows; rowCtr++)
                            {
                                // Create new row and add it to the table.
                                TableRow tRow = new TableRow();
                                tblLeagueSummary.Rows.Add(tRow);
                                for (int cellCtr = 0; cellCtr < columns; cellCtr++)
                                {
                                    // Create a new cell and add it to the row.
                                    TableCell tCell = new TableCell();
                                    if (cellCtr == 0)
                                    {
                                        tCell.CssClass = "team";
                                        tCell.Text = "<img src='" + countryList[rowCtr]["IconFilePath"].ToString().Replace("~", "..")
                                            + "' alt='" + countryList[rowCtr]["CountryName"] + "' title='"
                                            + countryList[rowCtr]["CountryName"] + "' />&nbsp;" + countryList[rowCtr]["TeamName"];
                                    }
                                    else
                                    {
                                        tCell.CssClass = "country";
                                        if (rowCtr != (cellCtr - 1))
                                        {
                                            string rowCountry = countryList[rowCtr]["CountryName"].ToString();
                                            string rowParti = countryList[rowCtr]["TeamID"].ToString();
                                            string colCountry = countryList[cellCtr - 1]["CountryName"].ToString();
                                            string colParti = countryList[cellCtr - 1]["TeamID"].ToString();

                                            foreach (CompetitionDS.LeagueSummaryRow rowA in competitionDS.LeagueSummary)
                                            {
                                                foreach (CompetitionDS.LeagueSummaryRow rowB in competitionDS.LeagueSummary)
                                                {
                                                    if (rowB.CountryName == rowCountry && rowB.TeamID.ToString() == rowParti && rowB.CompetitionStage.ToString() == stage)
                                                    {
                                                        if (rowB.ScheduleID == rowA.ScheduleID)
                                                        {
                                                            if (rowA.CountryName == colCountry && rowA.TeamID.ToString() == colParti && rowA.CompetitionStage.ToString() == stage)
                                                            {
                                                                if (tCell.Text != "")
                                                                {
                                                                    tCell.Text += "<br />";
                                                                }

                                                                tCell.Text += (rowB.IsScoreFinalNull() ? "" : rowB.ScoreFinal) + "-" + (rowA.IsScoreFinalNull() ? "" : rowA.ScoreFinal);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tCell.Text = "-";
                                        }

                                    }
                                    tRow.Cells.Add(tCell);
                                }
                            }

                            tblLeagueSummary.CssClass = "table table-striped";
                            pnlLeagueSummary.Controls.Add(tblLeagueSummary);
                        }
                    }
                }
            }
        }

        protected void GenerateLeagueRanking()
        {
            CompetitionDS competitionDS = new CompetitionDS();
            competitionDS = (CompetitionDS)ViewState[WebBase.VS_LEAGUE_DS];

            if (competitionDS.League.Count > 0 && !competitionDS.League[0].IsLeague1Null() && competitionDS.League[0].League1 != "")
            {
                DataTable groupList = competitionDS.League.DefaultView.ToTable(true, "GroupCode");
                Table tblLeagueRanking = new Table();
                tblLeagueRanking.CssClass = "table table-striped";

                foreach (DataRow rowGroup in groupList.Rows)
                {
                    if (rowGroup["GroupCode"].ToString() != string.Empty)
                    {
                        string groupCode = rowGroup["GroupCode"].ToString();

                        CompetitionDS.LeagueRow[] leagueRows = (CompetitionDS.LeagueRow[])competitionDS.League.Select("GroupCode='" + groupCode + "'");

                        if (leagueRows.Length > 1)
                        {
                            TableHeaderCell thcell;
                            TableCell tableCell;

                            #region Generate Header Row
                            TableHeaderRow theadfirst = new TableHeaderRow();
                            TableHeaderCell theadcell = new TableHeaderCell();
                            theadcell.Text = "Group " + groupCode;
                            theadcell.ColumnSpan = 20;
                            theadcell.CssClass = "header-row";
                            theadfirst.Cells.Add(theadcell);

                            tblLeagueRanking.Rows.Add(theadfirst);
                            #endregion

                            #region Add Title Header
                            CompetitionDS.LeagueRow headerRow = leagueRows[0];
                            TableHeaderRow thead = new TableHeaderRow();
                            thcell = new TableHeaderCell();
                            thcell.CssClass = "rank";
                            thcell.Text = "Rank";
                            thead.Cells.Add(thcell);

                            thcell = new TableHeaderCell();
                            thcell.CssClass = "team";
                            thcell.Text = "Name";
                            thead.Cells.Add(thcell);

                            if (!headerRow.IsLeague1Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League1;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague2Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League2;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague3Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League3;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague4Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League4;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague5Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League5;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague6Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League6;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague7Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League7;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague8Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League8;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague9Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League9;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague10Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League10;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague11Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League11;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague12Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League12;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague13Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League13;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague14Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League14;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague15Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League15;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague16Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League16;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague17Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League17;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague18Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League18;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague19Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League19;
                                thead.Cells.Add(thcell);
                            }

                            if (!headerRow.IsLeague20Null())
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = headerRow.League20;
                                thead.Cells.Add(thcell);
                            }
                            tblLeagueRanking.Rows.Add(thead);
                            #endregion

                            #region Add Details Row
                            for (int i = 1; i < leagueRows.Length; i++)
                            {
                                CompetitionDS.LeagueRow row = leagueRows[i];
                                if (groupCode == row.GroupCode)
                                {
                                    TableRow tableRow = new TableRow();

                                    tableCell = new TableCell();
                                    tableCell.CssClass = "rank";
                                    tableCell.Text = row.Rank.ToString();
                                    tableRow.Cells.Add(tableCell);

                                    tableCell = new TableCell();
                                    tableCell.CssClass = "name";
                                    if (eventType == ReferenceNum.EventType.Individual)
                                    {
                                        tableCell.Text = "<img src=' " + row.IconFilePath.Replace("~", "..") + " ' alt=' " + row.CountryName + "' title='" + row.CountryName + "' />&nbsp;" + row.FullName;
                                    }
                                    else if (eventType == ReferenceNum.EventType.Doubles)
                                    {
                                        tableCell.Text = "<img src=' " + row.IconFilePath.Replace("~", "..") + " ' alt=' " + row.CountryName + "' title='" + row.CountryName + "' />&nbsp;" + row.TeamName;
                                    }
                                    else
                                    {
                                        tableCell.Text = "<img src=' " + row.IconFilePath.Replace("~", "..") + " ' alt=' " + row.CountryName + "' title='" + row.CountryName + "' />&nbsp;" + row.TeamName;
                                    }

                                    tableRow.Cells.Add(tableCell);

                                    if (!headerRow.IsLeague1Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague1Null() ? " " : row.League1;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague2Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague2Null() ? " " : row.League2;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague3Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague3Null() ? " " : row.League3;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague4Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague4Null() ? " " : row.League4;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague5Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague5Null() ? "" : row.League5;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague6Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague6Null() ? " " : row.League6;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague7Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague7Null() ? " " : row.League7;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague8Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague8Null() ? " " : row.League8;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague9Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague9Null() ? " " : row.League9;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague10Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague10Null() ? " " : row.League10;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague11Null())
                                    {

                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague11Null() ? " " : row.League11;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague12Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague12Null() ? " " : row.League12;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague13Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague13Null() ? " " : row.League13;
                                        tableRow.Cells.Add(tableCell);
                                    }
                                    if (!headerRow.IsLeague14Null())
                                    {

                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague14Null() ? " " : row.League14;
                                        tableRow.Cells.Add(tableCell);
                                    }
                                    if (!headerRow.IsLeague15Null())
                                    {

                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague15Null() ? " " : row.League15;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague16Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague16Null() ? " " : row.League16;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague17Null())
                                    {

                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague17Null() ? " " : row.League17;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague18Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague18Null() ? " " : row.League18;
                                        tableRow.Cells.Add(tableCell);
                                    }
                                    if (!headerRow.IsLeague19Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague19Null() ? " " : row.League19;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!headerRow.IsLeague20Null())
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = row.IsLeague20Null() ? " " : row.League20;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    tblLeagueRanking.Rows.Add(tableRow);
                                }
                            }
                            #endregion

                            pnlLeagueRanking.Controls.Add(tblLeagueRanking);
                        }
                    }
                }
            }
        }

        protected void GenerateTimeDistancePoints()
        {
            CompetitionDS competitionDS = new CompetitionDS();

            // Get Schedule ID
            if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
            {
                competitionDS = GetSchedule(Convert.ToInt32(ViewState[WebBase.VS_EVENTID]));
            }

            if (competitionDS != null && competitionDS.ScheduleDetail != null)
            {
                foreach (CompetitionDS.ScheduleDetailRow scheduleRow in competitionDS.ScheduleDetail)
                {
                    if ((ReferenceNum.CompetitionFormatType)scheduleRow.PlayFormatID == ReferenceNum.CompetitionFormatType.Time_Distance_Points)
                    {
                        var headerLabel = new HtmlGenericControl("h3");
                        headerLabel.InnerText = scheduleRow.ScheduleName;
                        headerLabel.Attributes.Add("class", "game-title");

                        CompetitionDS scoreNameDS = GetScoreName(scheduleRow.ScheduleID);

                        if (scoreNameDS != null && scoreNameDS.ScoreName != null && scoreNameDS.ScoreName.Count > 0)
                        {
                            pnlTimeDistanceItem.Controls.Add(headerLabel);

                            Table tblTimeDistancePoints = new Table();
                            tblTimeDistancePoints.CssClass = "table table-striped";

                            #region Add Title Header
                            TableHeaderCell thcell;
                            CompetitionDS.ScoreNameRow scoreNameRow = scoreNameDS.ScoreName[0];
                            TableHeaderRow thead = new TableHeaderRow();

                            thcell = new TableHeaderCell();
                            thcell.CssClass = "rank";
                            thcell.Text = "Rank";
                            thead.Cells.Add(thcell);

                            thcell = new TableHeaderCell();
                            thcell.CssClass = "team";
                            thcell.Text = "Country";
                            thead.Cells.Add(thcell);

                            if (eventType == ReferenceNum.EventType.Individual)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "team";
                                thcell.Text = "Name";
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName1 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName1 == "-1") ? "" : scoreNameRow.ScoreName1;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName2 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName2 == "-1") ? "" : scoreNameRow.ScoreName2;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName3 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName3 == "-1") ? "" : scoreNameRow.ScoreName3;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName4 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName4 == "-1") ? "" : scoreNameRow.ScoreName4;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName5 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName5 == "-1") ? "" : scoreNameRow.ScoreName5;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName6 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName6 == "-1") ? "" : scoreNameRow.ScoreName6;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName7 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName7 == "-1") ? "" : scoreNameRow.ScoreName7;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName8 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName8 == "-1") ? "" : scoreNameRow.ScoreName8;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName9 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName9 == "-1") ? "" : scoreNameRow.ScoreName9;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName10 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName10 == "-1") ? "" : scoreNameRow.ScoreName10;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName11 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName11 == "-1") ? "" : scoreNameRow.ScoreName11;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName12 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName12 == "-1") ? "" : scoreNameRow.ScoreName12;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName13 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName13 == "-1") ? "" : scoreNameRow.ScoreName13;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName14 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName14 == "-1") ? "" : scoreNameRow.ScoreName14;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName15 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName15 == "-1") ? "" : scoreNameRow.ScoreName15;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName16 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName16 == "-1") ? "" : scoreNameRow.ScoreName16;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName17 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName17 == "-1") ? "" : scoreNameRow.ScoreName17;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName18 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName18 == "-1") ? "" : scoreNameRow.ScoreName18;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName19 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName19 == "-1") ? "" : scoreNameRow.ScoreName19;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreName20 != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreName20 == "-1") ? "" : scoreNameRow.ScoreName20;
                                thead.Cells.Add(thcell);
                            }

                            if (scoreNameRow.ScoreNameFinal != string.Empty)
                            {
                                thcell = new TableHeaderCell();
                                thcell.CssClass = "points";
                                thcell.Text = (scoreNameRow.ScoreNameFinal == "-1") ? "" : scoreNameRow.ScoreNameFinal;
                                thead.Cells.Add(thcell);
                            }

                            thcell = new TableHeaderCell();
                            thcell.CssClass = "points";
                            thcell.Text = "Record";
                            thead.Cells.Add(thcell);

                            tblTimeDistancePoints.Rows.Add(thead);
                            #endregion

                            CompetitionDS scoreDS = GetParticipantAndScore(scheduleRow.ScheduleID);

                            if (!scheduleRow.HeadToHead)
                            {
                                scoreDS.Score.DefaultView.Sort = "Ordering Asc, ResultPosition Asc";
                            }

                            #region Add Details Row
                            if (scoreDS != null && scoreDS.Score != null && scoreDS.Score.Count > 0)
                            {
                                for (int i = 0; i < scoreDS.Score.Count; i++)
                                {
                                    CompetitionDS.ScoreRow row = (CompetitionDS.ScoreRow)scoreDS.Score.DefaultView[i].Row;
                                    TableRow tableRow = new TableRow();
                                    TableCell tableCell;

                                    tableCell = new TableCell();
                                    tableCell.CssClass = "rank";
                                    tableCell.Text = (row.IsResultPositionNull()) ? "" : row.ResultPosition.ToString();
                                    tableRow.Cells.Add(tableCell);

                                    tableCell = new TableCell();
                                    tableCell.CssClass = "team";
                                    tableCell.Text = "<img src=' " + row.CountryImage.Replace("~", "..") + " '/>";
                                    tableRow.Cells.Add(tableCell);

                                    if (eventType == ReferenceNum.EventType.Individual)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "team";
                                        tableCell.Text = row.FullName;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName1 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore1Null()) ? "" : row.Score1;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName2 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore2Null()) ? "" : row.Score2;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName3 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore3Null()) ? "" : row.Score3;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName4 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore4Null()) ? "" : row.Score4;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName5 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore5Null()) ? "" : row.Score5;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName6 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore6Null()) ? "" : row.Score6;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName7 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore7Null()) ? "" : row.Score7;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName8 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore8Null()) ? "" : row.Score8;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName9 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore9Null()) ? "" : row.Score9;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName10 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore10Null()) ? "" : row.Score10;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName11 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore11Null()) ? "" : row.Score11;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName12 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore12Null()) ? "" : row.Score12;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName13 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore13Null()) ? "" : row.Score13;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName14 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore14Null()) ? "" : row.Score14;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName15 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore15Null()) ? "" : row.Score15;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName16 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore16Null()) ? "" : row.Score16;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName17 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore17Null()) ? "" : row.Score17;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName18 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore18Null()) ? "" : row.Score18;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName19 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore19Null()) ? "" : row.Score19;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreName20 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScore20Null()) ? "" : row.Score20;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameRow.ScoreNameFinal != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.CssClass = "points";
                                        tableCell.Text = (row.IsScoreFinalNull()) ? "" : row.ScoreFinal;
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    tableCell = new TableCell();
                                    tableCell.CssClass = "points";
                                    tableCell.Text = (row.IsBreakRecordNull()) ? "" : row.BreakRecord;
                                    tableRow.Cells.Add(tableCell);

                                    tblTimeDistancePoints.Rows.Add(tableRow);
                                }
                            }

                            #endregion

                            pnlTimeDistanceItem.Controls.Add(tblTimeDistancePoints);
                        }
                    }
                }
            }
        }
    }
}
