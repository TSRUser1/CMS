using SEM.CMS.CL.AR.Common;
using SEM.CMS.Result.Web.WCFCompetition;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Result.Web.Event
{
    public partial class Results : System.Web.UI.Page
    {
        protected bool IsTeamGame;
        protected bool IsMedalGame;
        protected bool HasRecord;
        protected bool IsHeadtoHead;
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
                GetScheduleList();
                GetParticipantAndScore();
                GetRefereeList();
                GetStartListName();

                if (IsTeamGame)
                {
                    this.GetStatiscticList();
                }
                BindData();
            }
        }

        protected void GetScheduleList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS editedDS = new CompetitionDS();

            CompetitionDS.ScheduleListRow row = requestDS.ScheduleList.NewScheduleListRow();
            if (Request.QueryString.AllKeys.Count() > 0)
            {
                if (ViewState[WebBase.VS_EVENTID] != null)
                {
                    row.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
                }
            }
            requestDS.ScheduleList.AddScheduleListRow(row);

            #region GetScheduleListForBanner
            responseDS = svc.GetScheduleListForBanner(requestDS);
            ViewState[WebBase.VS_COMPETITION_DS] = responseDS.ScheduleList;
            #endregion
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
                sportEventScheduleRow = responseDS.SportEventSchedule[0];
                if (!sportEventScheduleRow.IsShowResult)
                {
                    if (!sportEventScheduleRow.IsShowMedal)
                    {
                        if (!sportEventScheduleRow.IsShowAthelete)
                        {
                            if (!sportEventScheduleRow.IsShowRecord)
                            {
                                if (!sportEventScheduleRow.IsShowReport)
                                {
                                    if (!sportEventScheduleRow.IsShowSummary)
                                    {
                                        Response.Redirect("~/Schedule/General.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("~/Event/Summary.aspx?" + Request.QueryString.ToString());
                                    }
                                }
                                else
                                {
                                    Response.Redirect("~/Event/Report.aspx?" + Request.QueryString.ToString());
                                }
                            }
                            else if (sportEventScheduleRow.HasRecord)
                            {
                                Response.Redirect("~/Event/Record.aspx?" + Request.QueryString.ToString());
                            }
                            else
                            {
                                if (!sportEventScheduleRow.IsShowReport)
                                {
                                    if (!sportEventScheduleRow.IsShowSummary)
                                    {
                                        Response.Redirect("~/Schedule/General.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("~/Event/Summary.aspx?" + Request.QueryString.ToString());
                                    }
                                }
                                else
                                {
                                    Response.Redirect("~/Event/Report.aspx?" + Request.QueryString.ToString());
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("~/Event/Athletes.aspx?" + Request.QueryString.ToString());
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Event/FinalRankings.aspx?" + Request.QueryString.ToString());
                    }
                }

                if ((ReferenceNum.EventType)sportEventScheduleRow.EventTypeID == ReferenceNum.EventType.Individual)
                {
                    IsTeamGame = false;
                }
                else
                {
                    IsTeamGame = true;
                }

                if (sportEventScheduleRow.IsMedalGame)
                {
                    IsMedalGame = true;
                }

                HasRecord = sportEventScheduleRow.HasRecord;
                IsHeadtoHead = sportEventScheduleRow.HeadToHead;

                if (!sportEventScheduleRow.IsScheduleFooterNoteNull())
                {
                    litScheduleFooterNote.Text = sportEventScheduleRow.ScheduleFooterNote;
                }

                //if (!sportEventScheduleRow.IsEventFooterNoteNull())
                //{
                //    litEventFooterNote.Text = sportEventScheduleRow.EventFooterNote;
                //}

                if (!sportEventScheduleRow.IsStartListFooterNull())
                {
                    litStartListFooter.Text = sportEventScheduleRow.StartListFooter;
                }
            }
            #endregion
        }

        protected void GetParticipantAndScore()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScoreRow row = requestDS.Score.NewScoreRow();

            // Get Schedule ID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            requestDS.Score.AddScoreRow(row);

            #region GetScoreList
            if (IsTeamGame)
            {
                responseDS = svc.GetTeamAndScore(requestDS);
                ViewState[WebBase.VS_TEAMSCORE_DS] = responseDS.Score;
            }

            responseDS = svc.GetPartcipantAndScore(requestDS);
            ViewState[WebBase.VS_SCORE_DS] = responseDS.Score;
            #endregion
        }

        protected void GetScoreName()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScoreNameRow row = requestDS.ScoreName.NewScoreNameRow();

            // Get ScheduleID
            if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
            {
                row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
            }

            requestDS.ScoreName.AddScoreNameRow(row);

            #region GetScoreName
            responseDS = svc.GetScoreName(requestDS);

            ViewState[WebBase.VS_SCORENAME_DS] = responseDS.ScoreName;
            #endregion
        }

        protected void GetStartListName()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.StartlistNameRow row = requestDS.StartlistName.NewStartlistNameRow();

            // Get ScheduleID
            if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
            {
                row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
            }

            requestDS.StartlistName.AddStartlistNameRow(row);

            #region GetStartListName
            responseDS = svc.GetStartListName(requestDS);

            ViewState[WebBase.VS_STARTLISTNAME_DS] = responseDS.StartlistName;
            #endregion
        }

        protected void GetRefereeList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.RefereeRow row = requestDS.Referee.NewRefereeRow();

            // Get Schedule ID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            requestDS.Referee.AddRefereeRow(row);

            #region GetReferee
            responseDS = svc.GetReferee(requestDS);

            ViewState[WebBase.VS_REFEREE_DS] = responseDS.Referee;
            #endregion
        }

        protected void GetStatisticName()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.StatisticNameRow row = requestDS.StatisticName.NewStatisticNameRow();

            // Get Schedule ID
            if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
            {
                row.ScheduleID = Convert.ToInt32(Request.QueryString[WebBase.QS_SCHEDULEID]);
            }

            requestDS.StatisticName.AddStatisticNameRow(row);

            #region GetScoreNameList
            responseDS = svc.GetStatisticName(requestDS);
            ViewState[WebBase.VS_STATISTICNAME_DS] = responseDS.StatisticName;
            #endregion
        }

        protected void GetStatiscticList()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.StatisticRow row = requestDS.Statistic.NewStatisticRow();

            // Get Schedule ID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            requestDS.Statistic.AddStatisticRow(row);

            #region GetPartcipantAndStatistic
            responseDS = svc.GetPartcipantAndStatistic(requestDS);

            ViewState[WebBase.VS_STATISTIC_DS] = responseDS.Statistic;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS.ScheduleListDataTable scheduleList = new CompetitionDS.ScheduleListDataTable();

            #region Schedule List
            scheduleList = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_COMPETITION_DS];

            if (scheduleList.Count > 1)
            {
                rptScheduleList.DataSource = scheduleList;
                rptScheduleList.DataBind();
                controlScheduleList.Visible = true;
            }
            else if (scheduleList.Count == 1)
            {
                if (!scheduleList[0].IsScheduleDateTimeNull())
                {
                    Label lblScheduleDateTime = (Label)SubMenu.FindControl("lblScheduleDateTime");

                    if (lblScheduleDateTime != null)
                    {
                        lblScheduleDateTime.Visible = true;
                        lblScheduleDateTime.Text = scheduleList[0].ScheduleDateTime.ToString(WebBase.DATETIME_dd_MMM_yyyy_hh_mm_FORMAT);
                    }
                }
            }

            if (scheduleList.Count > 0)
            {
                sectionSchList.Attributes["style"] = "schedule-list";
            }
            else
            {
                sectionSchList.Attributes["style"] = "display:none";
            }
            #endregion

            #region Startlist
            if (IsTeamGame)
            {
                GenerateStartListForTeam();
            }
            else
            {
                GenerateStartListForIndividual();
            }

            #endregion

            #region Result
            if (IsTeamGame)
            {
                CompetitionDS.ScoreDataTable scoreDS = new CompetitionDS.ScoreDataTable();
                scoreDS = (CompetitionDS.ScoreDataTable)ViewState[WebBase.VS_TEAMSCORE_DS];

                if (!IsHeadtoHead)
                {
                    scoreDS.DefaultView.Sort = "Ordering Asc, ResultPosition Asc";
                }

                dgResultLst.DataSource = scoreDS;
                dgResultLst.DataBind();
            }
            else
            {
                CompetitionDS.ScoreDataTable scoreDS = new CompetitionDS.ScoreDataTable();
                scoreDS = (CompetitionDS.ScoreDataTable)ViewState[WebBase.VS_SCORE_DS];
                if (!IsHeadtoHead)
                { 
                    scoreDS.DefaultView.Sort = "Ordering Asc, ResultPosition Asc";
                }

                dgResultLst.DataSource = scoreDS;
                dgResultLst.DataBind();
            }

            #endregion

            #region Referee
            DataTable dt = new DataTable();
            dt.Columns.Add("RerefeeTitle", typeof(string));
            dt.Columns.Add("RefereeName", typeof(string));

            CompetitionDS.RefereeDataTable refereeDS = new CompetitionDS.RefereeDataTable();
            refereeDS = (CompetitionDS.RefereeDataTable)ViewState[WebBase.VS_REFEREE_DS];
            if (refereeDS.Count > 0)
            {
                CompetitionDS.RefereeRow row = refereeDS[0];
                if (!row.IsRefereeTitle1Null() && row.RefereeTitle1 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle1, row.RefereeName1);
                }

                if (!row.IsRefereeTitle2Null() && row.RefereeTitle2 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle2, row.RefereeName2);
                }

                if (!row.IsRefereeTitle3Null() && row.RefereeTitle3 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle3, row.RefereeName3);
                }

                if (!row.IsRefereeTitle4Null() && row.RefereeTitle4 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle4, row.RefereeName4);
                }

                if (!row.IsRefereeTitle5Null() && row.RefereeTitle5 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle5, row.RefereeName5);
                }

                if (!row.IsRefereeTitle6Null() && row.RefereeTitle6 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle6, row.RefereeName6);
                }

                if (!row.IsRefereeTitle7Null() && row.RefereeTitle7 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle7, row.RefereeName7);
                }

                if (!row.IsRefereeTitle8Null() && row.RefereeTitle8 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle8, row.RefereeName8);
                }

                if (!row.IsRefereeTitle9Null() && row.RefereeTitle9 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle9, row.RefereeName9);
                }

                if (!row.IsRefereeTitle10Null() && row.RefereeTitle10 != string.Empty)
                {
                    dt.Rows.Add(row.RefereeTitle10, row.RefereeName10);
                }

                if (dt.Rows.Count > 0)
                {
                    pnlReferee.Visible = true;
                }

                dgReferee.DataSource = dt;
                dgReferee.DataBind();
            }
            else
            {
                pnlReferee.Visible = false;
            }
            #endregion

            #region Statistic
            if (IsTeamGame)
            {
                GetStatisticName();
                CompetitionDS.StatisticNameDataTable statisticNameDS = new CompetitionDS.StatisticNameDataTable();
                statisticNameDS = (CompetitionDS.StatisticNameDataTable)ViewState[WebBase.VS_STATISTICNAME_DS];

                if (statisticNameDS != null && statisticNameDS.Count > 0 && !statisticNameDS[0].IsStatisticName1Null() && statisticNameDS[0].StatisticName1 != string.Empty)
                {
                    pnlTeamStatistic.Visible = true;
                    CompetitionDS.StatisticDataTable statisticDS = new CompetitionDS.StatisticDataTable();
                    statisticDS = (CompetitionDS.StatisticDataTable)ViewState[WebBase.VS_STATISTIC_DS];
                    dgTeamStatistic.DataSource = statisticDS;
                    dgTeamStatistic.DataBind();
                }
            }
            #endregion

            #region UI Controls

            CompetitionDS.ScoreDataTable score = new CompetitionDS.ScoreDataTable();

            if (IsTeamGame)
            {
                score = (CompetitionDS.ScoreDataTable)ViewState[WebBase.VS_TEAMSCORE_DS];
            }
            else
            {
                score = (CompetitionDS.ScoreDataTable)ViewState[WebBase.VS_SCORE_DS];
            }

            if (score.Count > 0)
            {
                if (score[0].IsScoreIDNull())
                {
                    tab1.CssClass = "tab-pane active";
                    tab2.CssClass = "tab-pane";
                    liStartList.Attributes.Add("class", "active");
                }
                else
                {
                    tab1.CssClass = "tab-pane";
                    tab2.CssClass = "tab-pane active";
                    liResult.Attributes.Add("class", "active");
                }
            }
            else
            {
                tab1.CssClass = "tab-pane active";
                tab2.CssClass = "tab-pane";
                liStartList.Attributes.Add("class", "active");
            }


            #endregion
        }

        protected void rptScheduleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView row = (DataRowView)e.Item.DataItem;
                Repeater nestedRepeater = e.Item.FindControl("rptCountryList") as Repeater;
                nestedRepeater.DataSource = row["FlagImageFilePath"].ToString().Split(',');
                nestedRepeater.DataBind();
            }
        }

        protected string GetItemClass(int scheduleID)
        {
            if (ViewState[WebBase.VS_SCHEDULEID] != null && Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]) == scheduleID)
            {
                return "class='highlight'";
            }

            return string.Empty;
        }

        protected bool IsScheduleListExist()
        {
            CompetitionDS.ScheduleListDataTable scheduleList = new CompetitionDS.ScheduleListDataTable();

            // Schedule List
            scheduleList = (CompetitionDS.ScheduleListDataTable)ViewState[WebBase.VS_COMPETITION_DS];
            if (scheduleList.Count > 0)
            {
                return true;
            }

            return false;
        }

        protected void dgResultLst_Init(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            GetScoreName();

            CompetitionDS.ScoreNameDataTable scoreNameDS = new CompetitionDS.ScoreNameDataTable();
            scoreNameDS = (CompetitionDS.ScoreNameDataTable)ViewState[WebBase.VS_SCORENAME_DS];

            int startIndex = 5;

            if (scoreNameDS.Count > 0)
            {
                CompetitionDS.ScoreNameRow row = scoreNameDS[0];
                if (row.ScoreName1 != string.Empty)
                {
                    gridView.Columns[startIndex + 1].Visible = true;
                    gridView.Columns[startIndex + 1].HeaderText = (row.ScoreName1 == "-1") ? "" : row.ScoreName1;
                }
                if (row.ScoreName2 != string.Empty)
                {
                    gridView.Columns[startIndex + 2].Visible = true;
                    gridView.Columns[startIndex + 2].HeaderText = (row.ScoreName2 == "-1") ? "" : row.ScoreName2;
                }
                if (row.ScoreName3 != string.Empty)
                {
                    gridView.Columns[startIndex + 3].Visible = true;
                    gridView.Columns[startIndex + 3].HeaderText = (row.ScoreName3 == "-1") ? "" : row.ScoreName3;
                }
                if (row.ScoreName4 != string.Empty)
                {
                    gridView.Columns[startIndex + 4].Visible = true;
                    gridView.Columns[startIndex + 4].HeaderText = (row.ScoreName4 == "-1") ? "" : row.ScoreName4;
                }
                if (row.ScoreName5 != string.Empty)
                {
                    gridView.Columns[startIndex + 5].Visible = true;
                    gridView.Columns[startIndex + 5].HeaderText = (row.ScoreName5 == "-1") ? "" : row.ScoreName5;
                }
                if (row.ScoreName6 != string.Empty)
                {
                    gridView.Columns[startIndex + 6].Visible = true;
                    gridView.Columns[startIndex + 6].HeaderText = (row.ScoreName6 == "-1") ? "" : row.ScoreName6;
                }
                if (row.ScoreName7 != string.Empty)
                {
                    gridView.Columns[startIndex + 7].Visible = true;
                    gridView.Columns[startIndex + 7].HeaderText = (row.ScoreName7 == "-1") ? "" : row.ScoreName7;
                }
                if (row.ScoreName8 != string.Empty)
                {
                    gridView.Columns[startIndex + 8].Visible = true;
                    gridView.Columns[startIndex + 8].HeaderText = (row.ScoreName8 == "-1") ? "" : row.ScoreName8;
                }
                if (row.ScoreName9 != string.Empty)
                {
                    gridView.Columns[startIndex + 9].Visible = true;
                    gridView.Columns[startIndex + 9].HeaderText = (row.ScoreName9 == "-1") ? "" : row.ScoreName9;
                }
                if (row.ScoreName10 != string.Empty)
                {
                    gridView.Columns[startIndex + 10].Visible = true;
                    gridView.Columns[startIndex + 10].HeaderText = (row.ScoreName10 == "-1") ? "" : row.ScoreName10;
                }
                if (row.ScoreName11 != string.Empty)
                {
                    gridView.Columns[startIndex + 11].Visible = true;
                    gridView.Columns[startIndex + 11].HeaderText = (row.ScoreName11 == "-1") ? "" : row.ScoreName11;
                }
                if (row.ScoreName12 != string.Empty)
                {
                    gridView.Columns[startIndex + 12].Visible = true;
                    gridView.Columns[startIndex + 12].HeaderText = (row.ScoreName12 == "-1") ? "" : row.ScoreName12;
                }
                if (row.ScoreName13 != string.Empty)
                {
                    gridView.Columns[startIndex + 13].Visible = true;
                    gridView.Columns[startIndex + 13].HeaderText = (row.ScoreName13 == "-1") ? "" : row.ScoreName13;
                }
                if (row.ScoreName14 != string.Empty)
                {
                    gridView.Columns[startIndex + 14].Visible = true;
                    gridView.Columns[startIndex + 14].HeaderText = (row.ScoreName14 == "-1") ? "" : row.ScoreName14;
                }
                if (row.ScoreName15 != string.Empty)
                {
                    gridView.Columns[startIndex + 15].Visible = true;
                    gridView.Columns[startIndex + 15].HeaderText = (row.ScoreName15 == "-1") ? "" : row.ScoreName15;
                }
                if (row.ScoreName16 != string.Empty)
                {
                    gridView.Columns[startIndex + 16].Visible = true;
                    gridView.Columns[startIndex + 16].HeaderText = (row.ScoreName16 == "-1") ? "" : row.ScoreName16;
                }
                if (row.ScoreName17 != string.Empty)
                {
                    gridView.Columns[startIndex + 17].Visible = true;
                    gridView.Columns[startIndex + 17].HeaderText = (row.ScoreName17 == "-1") ? "" : row.ScoreName17;
                }
                if (row.ScoreName18 != string.Empty)
                {
                    gridView.Columns[startIndex + 18].Visible = true;
                    gridView.Columns[startIndex + 18].HeaderText = (row.ScoreName18 == "-1") ? "" : row.ScoreName18;
                }
                if (row.ScoreName19 != string.Empty)
                {
                    gridView.Columns[startIndex + 19].Visible = true;
                    gridView.Columns[startIndex + 19].HeaderText = (row.ScoreName19 == "-1") ? "" : row.ScoreName19;
                }
                if (row.ScoreName20 != string.Empty)
                {
                    gridView.Columns[startIndex + 20].Visible = true;
                    gridView.Columns[startIndex + 20].HeaderText = (row.ScoreName20 == "-1") ? "" : row.ScoreName20;
                }
                if (row.ScoreNameFinal != string.Empty)
                {
                    gridView.Columns[startIndex + 21].Visible = true;
                    gridView.Columns[startIndex + 21].HeaderText = (row.ScoreNameFinal == "-1") ? "" : row.ScoreNameFinal;
                }
            }

            
        }

        protected void dgResultLst_Load(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;

            gridView.Columns[2].Visible = false;
            gridView.Columns[1].Visible = false;

            if (IsHeadtoHead)
            {
                gridView.Columns[0].Visible = false;
            }

            if (IsTeamGame)
            {
                // Set Visability False of Bib
                gridView.Columns[4].Visible = false;
                gridView.Columns[5].Visible = true;
            }
            else
            {
                gridView.Columns[5].Visible = false;
            }

            gridView.Columns[gridView.Columns.Count - 2].Visible = (HasRecord) ? true : false;
            
        }

        protected void dgResultLst_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region handle_DNS_and_DNF_order
            int value;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (int.TryParse(e.Row.Cells[0].Text, out value))
                {
                    if (Convert.ToInt32(e.Row.Cells[0].Text) >= 100) //for E101,E102,etc
                    {
                        e.Row.Cells[0].Text = "";
                    }
                }
            }
            #endregion
        }

        protected void dgTeamStatistic_Init(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            GetStatisticName();

            CompetitionDS.StatisticNameDataTable statisticNameDS = new CompetitionDS.StatisticNameDataTable();
            statisticNameDS = (CompetitionDS.StatisticNameDataTable)ViewState[WebBase.VS_STATISTICNAME_DS];

            int startIndex = 2;

            if (statisticNameDS.Count > 0 && !statisticNameDS[0].IsStatisticName1Null())
            {
                CompetitionDS.StatisticNameRow row = statisticNameDS[0];

                if (row.StatisticName1 != string.Empty)
                {
                    gridView.Columns[startIndex + 1].Visible = true;
                    gridView.Columns[startIndex + 1].HeaderText = row.StatisticName1;
                }

                if (row.StatisticName2 != string.Empty)
                {
                    gridView.Columns[startIndex + 2].Visible = true;
                    gridView.Columns[startIndex + 2].HeaderText = row.StatisticName2;
                }

                if (row.StatisticName3 != string.Empty)
                {
                    gridView.Columns[startIndex + 3].Visible = true;
                    gridView.Columns[startIndex + 3].HeaderText = row.StatisticName3;
                }

                if (row.StatisticName4 != string.Empty)
                {
                    gridView.Columns[startIndex + 4].Visible = true;
                    gridView.Columns[startIndex + 4].HeaderText = row.StatisticName4;
                }

                if (row.StatisticName5 != string.Empty)
                {
                    gridView.Columns[startIndex + 5].Visible = true;
                    gridView.Columns[startIndex + 5].HeaderText = row.StatisticName5;
                }

                if (row.StatisticName6 != string.Empty)
                {
                    gridView.Columns[startIndex + 6].Visible = true;
                    gridView.Columns[startIndex + 6].HeaderText = row.StatisticName6;
                }

                if (row.StatisticName7 != string.Empty)
                {
                    gridView.Columns[startIndex + 7].Visible = true;
                    gridView.Columns[startIndex + 7].HeaderText = row.StatisticName7;
                }

                if (row.StatisticName8 != string.Empty)
                {
                    gridView.Columns[startIndex + 8].Visible = true;
                    gridView.Columns[startIndex + 8].HeaderText = row.StatisticName8;
                }

                if (row.StatisticName9 != string.Empty)
                {
                    gridView.Columns[startIndex + 9].Visible = true;
                    gridView.Columns[startIndex + 9].HeaderText = row.StatisticName9;
                }

                if (row.StatisticName10 != string.Empty)
                {
                    gridView.Columns[startIndex + 10].Visible = true;
                    gridView.Columns[startIndex + 10].HeaderText = row.StatisticName10;
                }
            }
        }

        protected void dgTeamStatistic_DataBound(object sender, EventArgs e)
        {
            if (IsTeamGame)
            {
                GridView grid = (GridView)sender;

                for (int i = grid.Rows.Count - 1; i > 0; i--)
                {
                    GridViewRow row = grid.Rows[i];
                    GridViewRow previousRow = grid.Rows[i - 1];

                    HiddenField hidCountryID = (HiddenField)row.Cells[1].FindControl("hidCountryID");
                    HiddenField prevhidCountryID = (HiddenField)previousRow.Cells[1].FindControl("hidCountryID");

                    if (hidCountryID.Value.Equals(prevhidCountryID.Value))
                    {
                        if (previousRow.Cells[1].RowSpan == 0)
                        {
                            if (row.Cells[1].RowSpan == 0)
                            {
                                previousRow.Cells[1].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                            }

                            row.Cells[1].Visible = false;
                        }
                    }
                }
            }
        }

        protected void GenerateStartListForTeam()
        {
            if (sportEventScheduleRow != null && !sportEventScheduleRow.IsIsPublishStartListNull() && sportEventScheduleRow.IsPublishStartList)
            {
                Table tblStartlist = new Table();
                tblStartlist.CssClass = "table table-striped";

                #region Generate Header
                GetScoreName();
                CompetitionDS.ScoreNameDataTable scoreNameDS = new CompetitionDS.ScoreNameDataTable();
                CompetitionDS.StartlistNameDataTable startListNameDS = new CompetitionDS.StartlistNameDataTable();
                CompetitionDS.ScoreNameRow scoreNameRow;
                CompetitionDS.StartlistNameRow startListRow = startListNameDS.NewStartlistNameRow();

                scoreNameDS = (CompetitionDS.ScoreNameDataTable)ViewState[WebBase.VS_SCORENAME_DS];
                startListNameDS = (CompetitionDS.StartlistNameDataTable)ViewState[WebBase.VS_STARTLISTNAME_DS];

                if (startListNameDS != null && startListNameDS.Count > 0)
                {
                    startListRow = startListNameDS[0];
                }

                TableHeaderRow thead = new TableHeaderRow();
                TableHeaderCell thcell;

                thcell = new TableHeaderCell();
                thcell.ColumnSpan = 25;
                thcell.CssClass = "header";
                thcell.Text = "&nbsp;";
                thead.Cells.Add(thcell);
                tblStartlist.Rows.Add(thead);

                TableRow tbody = new TableRow();

                thcell = new TableHeaderCell();
                thcell.Text = "Country";
                thcell.CssClass = "country";
                tbody.Cells.Add(thcell);

                if (!startListRow.IsStartListName1Null() && startListRow.StartListName1 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName1 == "-1") ? "" : startListRow.StartListName1;
                    thcell.CssClass = "target";
                    tbody.Cells.Add(thcell);
                }

                thcell = new TableHeaderCell();
                thcell.Text = "Name";
                thcell.CssClass = "target";
                tbody.Cells.Add(thcell);

                thcell = new TableHeaderCell();
                thcell.Text = "Birth Date";
                thcell.CssClass = "dob";
                tbody.Cells.Add(thcell);

                if (!startListRow.IsStartListName2Null() && startListRow.StartListName2 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName2 == "-1") ? "" : startListRow.StartListName2;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName3Null() && startListRow.StartListName3 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName3 == "-1") ? "" : startListRow.StartListName3;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName4Null() && startListRow.StartListName4 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName4 == "-1") ? "" : startListRow.StartListName4;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName5Null() && startListRow.StartListName5 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName5 == "-1") ? "" : startListRow.StartListName5;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName6Null() && startListRow.StartListName6 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName6 == "-1") ? "" : startListRow.StartListName6;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName7Null() && startListRow.StartListName7 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName7 == "-1") ? "" : startListRow.StartListName7;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName8Null() && startListRow.StartListName8 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName8 == "-1") ? "" : startListRow.StartListName8;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName9Null() && startListRow.StartListName9 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName9 == "-1") ? "" : startListRow.StartListName9;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName10Null() && startListRow.StartListName10 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName10 == "-1") ? "" : startListRow.StartListName10;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (scoreNameDS != null && scoreNameDS != null && scoreNameDS.Count > 0)
                {
                    scoreNameRow = scoreNameDS[0];

                    if (!scoreNameRow.IsIsVisible1Null() && scoreNameRow.IsVisible1 && scoreNameRow.ScoreName1 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName1 == "-1") ? "" : scoreNameRow.ScoreName1;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible2Null() && scoreNameRow.IsVisible2 && scoreNameRow.ScoreName2 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName2 == "-1") ? "" : scoreNameRow.ScoreName2;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible3Null() && scoreNameRow.IsVisible3 && scoreNameRow.ScoreName3 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName3 == "-1") ? "" : scoreNameRow.ScoreName3;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible4Null() && scoreNameRow.IsVisible4 && scoreNameRow.ScoreName4 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName4 == "-1") ? "" : scoreNameRow.ScoreName4;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible5Null() && scoreNameRow.IsVisible5 && scoreNameRow.ScoreName5 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName5 == "-1") ? "" : scoreNameRow.ScoreName5;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible6Null() && scoreNameRow.IsVisible6 && scoreNameRow.ScoreName6 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName6 == "-1") ? "" : scoreNameRow.ScoreName6;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible7Null() && scoreNameRow.IsVisible7 && scoreNameRow.ScoreName7 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName7 == "-1") ? "" : scoreNameRow.ScoreName7;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible8Null() && scoreNameRow.IsVisible8 && scoreNameRow.ScoreName8 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName8 == "-1") ? "" : scoreNameRow.ScoreName8;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible9Null() && scoreNameRow.IsVisible9 && scoreNameRow.ScoreName9 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName9 == "-1") ? "" : scoreNameRow.ScoreName9;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible10Null() && scoreNameRow.IsVisible10 && scoreNameRow.ScoreName10 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName10 == "-1") ? "" : scoreNameRow.ScoreName10;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible11Null() && scoreNameRow.IsVisible11 && scoreNameRow.ScoreName11 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName11 == "-1") ? "" : scoreNameRow.ScoreName11;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible12Null() && scoreNameRow.IsVisible12 && scoreNameRow.ScoreName12 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName12 == "-1") ? "" : scoreNameRow.ScoreName12;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible13Null() && scoreNameRow.IsVisible13 && scoreNameRow.ScoreName13 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName13 == "-1") ? "" : scoreNameRow.ScoreName13;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible14Null() && scoreNameRow.IsVisible14 && scoreNameRow.ScoreName14 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName14 == "-1") ? "" : scoreNameRow.ScoreName14;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible15Null() && scoreNameRow.IsVisible15 && scoreNameRow.ScoreName15 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName15 == "-1") ? "" : scoreNameRow.ScoreName15;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible16Null() && scoreNameRow.IsVisible16 && scoreNameRow.ScoreName16 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName16 == "-1") ? "" : scoreNameRow.ScoreName16;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible17Null() && scoreNameRow.IsVisible17 && scoreNameRow.ScoreName17 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName17 == "-1") ? "" : scoreNameRow.ScoreName17;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible18Null() && scoreNameRow.IsVisible18 && scoreNameRow.ScoreName18 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName18 == "-1") ? "" : scoreNameRow.ScoreName18;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible19Null() && scoreNameRow.IsVisible19 && scoreNameRow.ScoreName19 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName19 == "-1") ? "" : scoreNameRow.ScoreName19;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible20Null() && scoreNameRow.IsVisible20 && scoreNameRow.ScoreName20 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName20 == "-1") ? "" : scoreNameRow.ScoreName20;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }
                }

                tblStartlist.Rows.Add(tbody);

                #endregion

                #region Generate Data
                CompetitionDS.ScoreDataTable scoreDS = (CompetitionDS.ScoreDataTable)ViewState[WebBase.VS_SCORE_DS];
                if (scoreDS != null && scoreDS.Count > 0)
                {
                    DataTable countryTable = scoreDS.DefaultView.ToTable(true, "CountryName", "CountryImage", "CountryID", "TeamID");
                    DataTable participantTypeTable = scoreDS.DefaultView.ToTable(true, "ParticipantType");

                    foreach (DataRow countryRow in countryTable.Rows)
                    {
                        TableRow tableRow = new TableRow();
                        TableCell tableCell;
                        TableHeaderCell tableHeaderCell;

                        DataRow[] participantInCountry = scoreDS.Select("CountryName='" + countryRow["CountryName"] + "' and TeamID='" + countryRow["TeamID"] + "'");

                        tableCell = new TableCell();
                        tableCell.Text = "<a href='../Schedule/ScheduleCountry.aspx?CountryID=" + countryRow["CountryID"] + "'><img src=' " + countryRow["CountryImage"].ToString().Replace("~", "..") + " '/></a>";
                        tableCell.CssClass = "country";
                        tableCell.RowSpan = participantInCountry.Length + participantTypeTable.Rows.Count;
                        tableRow.Cells.Add(tableCell);
                        
                        for (int i = 0; i < participantTypeTable.Rows.Count; i++)
                        {
                            DataRow pTypeRow = participantTypeTable.Rows[i];
                            if (i != 0)
                            {
                                tableRow = new TableRow();
                            }

                            if (participantTypeTable.Rows.Count > 1)
                            {
                                tableHeaderCell = new TableHeaderCell();
                                tableHeaderCell.Text = pTypeRow["ParticipantType"].ToString();
                                tableHeaderCell.ColumnSpan = 20;
                                tableHeaderCell.CssClass = "subheader";
                                tableRow.Cells.Add(tableHeaderCell);
                            }

                            tblStartlist.Rows.Add(tableRow);
                            
                            foreach (DataRow participantRow in participantInCountry)
                            {
                                tableRow = new TableRow();

                                if (pTypeRow["ParticipantType"].ToString() == participantRow["ParticipantType"].ToString())
                                {
                                    if (!startListRow.IsStartListName1Null() && startListRow.StartListName1 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList1"].ToString();
                                        tableCell.CssClass = "target";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    tableCell = new TableCell();
                                    tableCell.Text = "<a href='../Athletes/Biography.aspx?AthleteID=" + participantRow["ParticipantID"] + "'>" + participantRow["FullName"].ToString() + "</a>";
                                    tableCell.CssClass = "country";
                                    tableRow.Cells.Add(tableCell);

                                    tableCell = new TableCell();
                                    if (participantRow["DateOfBirth"] == DBNull.Value)
                                    {
                                        tableCell.Text = "";
                                    }
                                    else
                                    { 
                                        tableCell.Text = Convert.ToDateTime(participantRow["DateOfBirth"].ToString()).ToString("dd MMM yyyy");
                                    }
                                    tableCell.CssClass = "dob";
                                    tableRow.Cells.Add(tableCell);

                                    if (!startListRow.IsStartListName2Null() && startListRow.StartListName2 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList2"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName3Null() && startListRow.StartListName3 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList3"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName4Null() && startListRow.StartListName4 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList4"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName5Null() && startListRow.StartListName5 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList5"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName6Null() && startListRow.StartListName6 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList6"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName7Null() && startListRow.StartListName7 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList7"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName8Null() && startListRow.StartListName8 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList8"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName9Null() && startListRow.StartListName9 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList9"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (!startListRow.IsStartListName10Null() && startListRow.StartListName10 != string.Empty)
                                    {
                                        tableCell = new TableCell();
                                        tableCell.Text = participantRow["StartList10"].ToString();
                                        tableCell.CssClass = "first-round";
                                        tableRow.Cells.Add(tableCell);
                                    }

                                    if (scoreNameDS.Count > 0)
                                    {
                                        scoreNameRow = scoreNameDS[0];

                                        if (!scoreNameRow.IsIsVisible1Null() && scoreNameRow.IsVisible1 && scoreNameRow.ScoreName1 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score1"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible2Null() && scoreNameRow.IsVisible2 && scoreNameRow.ScoreName2 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score2"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible3Null() && scoreNameRow.IsVisible3 && scoreNameRow.ScoreName3 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score3"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible4Null() && scoreNameRow.IsVisible4 && scoreNameRow.ScoreName4 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score4"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible5Null() && scoreNameRow.IsVisible5 && scoreNameRow.ScoreName5 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score5"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible6Null() && scoreNameRow.IsVisible6 && scoreNameRow.ScoreName6 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score6"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible7Null() && scoreNameRow.IsVisible7 && scoreNameRow.ScoreName7 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score7"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible8Null() && scoreNameRow.IsVisible8 && scoreNameRow.ScoreName8 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score8"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible9Null() && scoreNameRow.IsVisible9 && scoreNameRow.ScoreName9 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score9"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible10Null() && scoreNameRow.IsVisible10 && scoreNameRow.ScoreName10 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score10"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible11Null() && scoreNameRow.IsVisible11 && scoreNameRow.ScoreName11 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score11"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible12Null() && scoreNameRow.IsVisible12 && scoreNameRow.ScoreName12 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score12"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible13Null() && scoreNameRow.IsVisible13 && scoreNameRow.ScoreName13 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score13"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible14Null() && scoreNameRow.IsVisible14 && scoreNameRow.ScoreName14 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score14"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible15Null() && scoreNameRow.IsVisible15 && scoreNameRow.ScoreName15 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score15"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible16Null() && scoreNameRow.IsVisible16 && scoreNameRow.ScoreName16 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score16"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible17Null() && scoreNameRow.IsVisible17 && scoreNameRow.ScoreName17 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score17"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible18Null() && scoreNameRow.IsVisible18 && scoreNameRow.ScoreName18 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score18"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible19Null() && scoreNameRow.IsVisible19 && scoreNameRow.ScoreName19 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score19"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }

                                        if (!scoreNameRow.IsIsVisible20Null() && scoreNameRow.IsVisible20 && scoreNameRow.ScoreName20 != string.Empty)
                                        {
                                            tableCell = new TableCell();
                                            tableCell.Text = participantRow["Score20"].ToString();
                                            tableCell.CssClass = "first-round";
                                            tableRow.Cells.Add(tableCell);
                                        }
                                    }

                                    tblStartlist.Rows.Add(tableRow);
                                }

                            }
                        }
                    }
                }
                else
                {
                    TableRow tableRow = new TableRow();
                    TableCell tableCell = new TableCell();
                    tableCell.Text = "The official start list will be available here after the Technical / Team Manager’s Meeting.";
                    tableCell.CssClass = "country";
                    tableCell.ColumnSpan = 30;
                    tableRow.HorizontalAlign = HorizontalAlign.Center;
                    tableRow.Cells.Add(tableCell);

                    tblStartlist.Rows.Add(tableRow);
                }
                #endregion

                pnlStartListItem.Controls.Add(tblStartlist);
            }
            else
            {
                Label lblStartList = new Label();
                lblStartList.Text = "The official start list will be available here after the Technical / Team Manager’s Meeting";
                pnlStartListItem.Controls.Add(lblStartList);
            }


        }

        protected void GenerateStartListForIndividual()
        {
            if (sportEventScheduleRow != null && !sportEventScheduleRow.IsIsPublishStartListNull() && sportEventScheduleRow.IsPublishStartList)
            {
                Table tblStartlist = new Table();
                tblStartlist.CssClass = "table table-striped";

                #region Generate Header
                GetScoreName();

                CompetitionDS.ScoreNameDataTable scoreNameDS = new CompetitionDS.ScoreNameDataTable();
                CompetitionDS.StartlistNameDataTable startListNameDS = new CompetitionDS.StartlistNameDataTable();
                CompetitionDS.ScoreNameRow scoreNameRow;
                CompetitionDS.StartlistNameRow startListRow = startListNameDS.NewStartlistNameRow();

                scoreNameDS = (CompetitionDS.ScoreNameDataTable)ViewState[WebBase.VS_SCORENAME_DS];
                startListNameDS = (CompetitionDS.StartlistNameDataTable)ViewState[WebBase.VS_STARTLISTNAME_DS];

                if (startListNameDS != null && startListNameDS.Count > 0)
                {
                    startListRow = startListNameDS[0];
                }

                TableHeaderRow thead = new TableHeaderRow();
                TableHeaderCell thcell;

                thcell = new TableHeaderCell();
                thcell.ColumnSpan = 25;
                thcell.CssClass = "header";
                thcell.Text = "&nbsp;";
                thead.Cells.Add(thcell);
                tblStartlist.Rows.Add(thead);

                TableRow tbody = new TableRow();

                thcell = new TableHeaderCell();
                thcell.Text = "Country";
                thcell.CssClass = "country";
                tbody.Cells.Add(thcell);

                if (!startListRow.IsStartListName1Null() && startListRow.StartListName1 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName1 == "-1") ? "" : startListRow.StartListName1;
                    thcell.CssClass = "target";
                    tbody.Cells.Add(thcell);
                }

                thcell = new TableHeaderCell();
                thcell.Text = "Name";
                thcell.CssClass = "target";
                tbody.Cells.Add(thcell);

                thcell = new TableHeaderCell();
                thcell.Text = "Birth Date";
                thcell.CssClass = "dob";
                tbody.Cells.Add(thcell);

                if (!startListRow.IsStartListName2Null() && startListRow.StartListName2 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName2 == "-1") ? "" : startListRow.StartListName2;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName3Null() && startListRow.StartListName3 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName3 == "-1") ? "" : startListRow.StartListName3;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName4Null() && startListRow.StartListName4 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName4 == "-1") ? "" : startListRow.StartListName4;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName5Null() && startListRow.StartListName5 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName5 == "-1") ? "" : startListRow.StartListName5;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName6Null() && startListRow.StartListName6 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName6 == "-1") ? "" : startListRow.StartListName6;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName7Null() && startListRow.StartListName7 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName7 == "-1") ? "" : startListRow.StartListName7;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName8Null() && startListRow.StartListName8 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName8 == "-1") ? "" : startListRow.StartListName8;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName9Null() && startListRow.StartListName9 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName9 == "-1") ? "" : startListRow.StartListName9;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (!startListRow.IsStartListName10Null() && startListRow.StartListName10 != string.Empty)
                {
                    thcell = new TableHeaderCell();
                    thcell.Text = (startListRow.StartListName10 == "-1") ? "" : startListRow.StartListName10;
                    thcell.CssClass = "first-round";
                    tbody.Cells.Add(thcell);
                }

                if (scoreNameDS.Count > 0)
                {
                    scoreNameRow = scoreNameDS[0];

                    if (!scoreNameRow.IsIsVisible1Null() && scoreNameRow.IsVisible1 && scoreNameRow.ScoreName1 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName1 == "-1") ? "" : scoreNameRow.ScoreName1;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible2Null() && scoreNameRow.IsVisible2 && scoreNameRow.ScoreName2 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName2 == "-1") ? "" : scoreNameRow.ScoreName2;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible3Null() && scoreNameRow.IsVisible3 && scoreNameRow.ScoreName3 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName3 == "-1") ? "" : scoreNameRow.ScoreName3;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible4Null() && scoreNameRow.IsVisible4 && scoreNameRow.ScoreName4 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName4 == "-1") ? "" : scoreNameRow.ScoreName4;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible5Null() && scoreNameRow.IsVisible5 && scoreNameRow.ScoreName5 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName5 == "-1") ? "" : scoreNameRow.ScoreName5;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible6Null() && scoreNameRow.IsVisible6 && scoreNameRow.ScoreName6 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName6 == "-1") ? "" : scoreNameRow.ScoreName6;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible7Null() && scoreNameRow.IsVisible7 && scoreNameRow.ScoreName7 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName7 == "-1") ? "" : scoreNameRow.ScoreName7;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible8Null() && scoreNameRow.IsVisible8 && scoreNameRow.ScoreName8 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName8 == "-1") ? "" : scoreNameRow.ScoreName8;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible9Null() && scoreNameRow.IsVisible9 && scoreNameRow.ScoreName9 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName9 == "-1") ? "" : scoreNameRow.ScoreName9;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible10Null() && scoreNameRow.IsVisible10 && scoreNameRow.ScoreName10 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName10 == "-1") ? "" : scoreNameRow.ScoreName10;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible11Null() && scoreNameRow.IsVisible11 && scoreNameRow.ScoreName11 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName11 == "-1") ? "" : scoreNameRow.ScoreName11;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible12Null() && scoreNameRow.IsVisible12 && scoreNameRow.ScoreName12 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName12 == "-1") ? "" : scoreNameRow.ScoreName12;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible13Null() && scoreNameRow.IsVisible13 && scoreNameRow.ScoreName13 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName13 == "-1") ? "" : scoreNameRow.ScoreName13;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible14Null() && scoreNameRow.IsVisible14 && scoreNameRow.ScoreName14 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName14 == "-1") ? "" : scoreNameRow.ScoreName14;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible15Null() && scoreNameRow.IsVisible15 && scoreNameRow.ScoreName15 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName15 == "-1") ? "" : scoreNameRow.ScoreName15;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible16Null() && scoreNameRow.IsVisible16 && scoreNameRow.ScoreName16 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName16 == "-1") ? "" : scoreNameRow.ScoreName16;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible17Null() && scoreNameRow.IsVisible17 && scoreNameRow.ScoreName17 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName17 == "-1") ? "" : scoreNameRow.ScoreName17;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible18Null() && scoreNameRow.IsVisible18 && scoreNameRow.ScoreName18 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName18 == "-1") ? "" : scoreNameRow.ScoreName18;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible19Null() && scoreNameRow.IsVisible19 && scoreNameRow.ScoreName19 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName19 == "-1") ? "" : scoreNameRow.ScoreName19;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }

                    if (!scoreNameRow.IsIsVisible20Null() && scoreNameRow.IsVisible20 && scoreNameRow.ScoreName20 != string.Empty)
                    {
                        thcell = new TableHeaderCell();
                        thcell.Text = (scoreNameRow.ScoreName20 == "-1") ? "" : scoreNameRow.ScoreName20;
                        thcell.CssClass = "first-round";
                        tbody.Cells.Add(thcell);
                    }
                }

                tblStartlist.Rows.Add(tbody);
                #endregion

                #region Generate Data
                CompetitionDS.ScoreDataTable scoreDS = (CompetitionDS.ScoreDataTable)ViewState[WebBase.VS_SCORE_DS];
                if (scoreDS != null && scoreDS.Count > 0)
                {
                    foreach (CompetitionDS.ScoreRow row in scoreDS)
                    {
                        TableRow tableRow = new TableRow();
                        TableCell tableCell;

                        tableCell = new TableCell();
                        tableCell.Text = "<img src=' " + row.CountryImage.Replace("~", "..") + " '/>";
                        tableCell.CssClass = "country";
                        tableRow.Cells.Add(tableCell);

                        if (!startListRow.IsStartListName1Null() && startListRow.StartListName1 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList1;
                            tableCell.CssClass = "target";
                            tableRow.Cells.Add(tableCell);
                        }

                        tableCell = new TableCell();
                        tableCell.Text = "<a href='../Athletes/Biography.aspx?AthleteID=" + row["ParticipantID"] + "'>" + row["FullName"].ToString() + "</a>";
                        tableCell.CssClass = "country";
                        tableRow.Cells.Add(tableCell);

                        tableCell = new TableCell();
                        tableCell.Text = (row.IsDateOfBirthNull()) ? "" : row.DateOfBirth.ToString("dd MMM yyyy");
                        tableCell.CssClass = "dob";
                        tableRow.Cells.Add(tableCell);

                        if (!startListRow.IsStartListName2Null() && startListRow.StartListName2 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList2;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName3Null() && startListRow.StartListName3 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList3;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName4Null() && startListRow.StartListName4 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList4;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName5Null() && startListRow.StartListName5 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList5;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName6Null() && startListRow.StartListName6 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList6;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName7Null() && startListRow.StartListName7 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList7;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName8Null() && startListRow.StartListName8 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList8;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName9Null() && startListRow.StartListName9 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList9;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (!startListRow.IsStartListName10Null() && startListRow.StartListName10 != string.Empty)
                        {
                            tableCell = new TableCell();
                            tableCell.Text = row.StartList10;
                            tableCell.CssClass = "first-round";
                            tableRow.Cells.Add(tableCell);
                        }

                        if (scoreNameDS.Count > 0)
                        {
                            scoreNameRow = scoreNameDS[0];

                            if (!scoreNameRow.IsIsVisible1Null() && scoreNameRow.IsVisible1 && scoreNameRow.ScoreName1 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score1;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible2Null() && scoreNameRow.IsVisible2 && scoreNameRow.ScoreName2 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score2;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible3Null() && scoreNameRow.IsVisible3 && scoreNameRow.ScoreName3 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score3;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible4Null() && scoreNameRow.IsVisible4 && scoreNameRow.ScoreName4 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score4;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible5Null() && scoreNameRow.IsVisible5 && scoreNameRow.ScoreName5 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score5;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible6Null() && scoreNameRow.IsVisible6 && scoreNameRow.ScoreName6 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score6;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible7Null() && scoreNameRow.IsVisible7 && scoreNameRow.ScoreName7 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score7;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible8Null() && scoreNameRow.IsVisible8 && scoreNameRow.ScoreName8 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score8;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible9Null() && scoreNameRow.IsVisible9 && scoreNameRow.ScoreName9 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score9;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible10Null() && scoreNameRow.IsVisible10 && scoreNameRow.ScoreName10 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score10;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible11Null() && scoreNameRow.IsVisible11 && scoreNameRow.ScoreName11 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score11;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible12Null() && scoreNameRow.IsVisible12 && scoreNameRow.ScoreName12 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score12;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible13Null() && scoreNameRow.IsVisible13 && scoreNameRow.ScoreName13 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score13;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible14Null() && scoreNameRow.IsVisible14 && scoreNameRow.ScoreName14 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score14;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible15Null() && scoreNameRow.IsVisible15 && scoreNameRow.ScoreName15 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score15;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible16Null() && scoreNameRow.IsVisible16 && scoreNameRow.ScoreName16 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score16;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible17Null() && scoreNameRow.IsVisible17 && scoreNameRow.ScoreName17 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score17;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible18Null() && scoreNameRow.IsVisible18 && scoreNameRow.ScoreName18 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score18;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible19Null() && scoreNameRow.IsVisible19 && scoreNameRow.ScoreName19 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score19;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }

                            if (!scoreNameRow.IsIsVisible20Null() && scoreNameRow.IsVisible20 && scoreNameRow.ScoreName20 != string.Empty)
                            {
                                tableCell = new TableCell();
                                tableCell.Text = row.Score20;
                                tableCell.CssClass = "first-round";
                                tableRow.Cells.Add(tableCell);
                            }
                        }

                        tblStartlist.Rows.Add(tableRow);
                    }
                }
                else
                {
                    TableRow tableRow = new TableRow();
                    TableCell tableCell = new TableCell();
                    tableCell.Text = "The official start list will be available here after the Technical / Team Manager’s Meeting.";
                    tableCell.CssClass = "country";
                    tableCell.ColumnSpan = 30;
                    tableRow.HorizontalAlign = HorizontalAlign.Center;
                    tableRow.Cells.Add(tableCell);

                    tblStartlist.Rows.Add(tableRow);
                }
                #endregion

                pnlStartListItem.Controls.Add(tblStartlist);
            }
            else
            {
                Label lblStartList = new Label();
                lblStartList.Text = "The official start list will be available here after the Technical / Team Manager’s Meeting";
                pnlStartListItem.Controls.Add(lblStartList);
            }
        }

        protected void dgResultLst_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Creating a gridview object            
                GridView objGridView = (GridView)sender;

                //Creating a gridview row object
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Creating a table cell object
                TableHeaderCell objtablecell = new TableHeaderCell();

                objtablecell.ColumnSpan = 25;
                objtablecell.CssClass = "header";

                if (sportEventScheduleRow != null && !sportEventScheduleRow.IsIsOfficialNull())
                {
                    if (sportEventScheduleRow.IsOfficial)
                    {
                        objtablecell.Text = "OFFICIAL";
                    }
                    else
                    {
                        objtablecell.Text = "&nbsp;";
                    }
                }
                else
                {
                    objtablecell.Text = "&nbsp;";
                }

                objgridviewrow.Cells.Add(objtablecell);

                objGridView.Controls[0].Controls.AddAt(0, objgridviewrow);
            }
        }

        protected void dgTeamStatistic_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Creating a gridview object            
                GridView objGridView = (GridView)sender;

                //Creating a gridview row object
                GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Creating a table cell object
                TableHeaderCell objtablecell = new TableHeaderCell();

                objtablecell.ColumnSpan = 25;
                objtablecell.CssClass = "header";

                objgridviewrow.Cells.Add(objtablecell);

                objGridView.Controls[0].Controls.AddAt(0, objgridviewrow);
            }
        }

        
    }
}