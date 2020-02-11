using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFCompetition;
using SEM.CMS.Web.WCFSystemMaintenance;
using System.IO;

namespace SEM.CMS.Web
{
    public partial class ResultMaintenance : System.Web.UI.Page
    {
        protected string VS_ISTEAMGAME = "ViewStateIsTeamGame";
        protected string VS_ISLEAGUE = "ViewStateIsLeague";
        protected string VS_GROUPCODE = "ViewStateGroupCode";
        protected bool IsTeamGame;
        protected bool IsLeague;
        protected CompetitionDS.SportEventScheduleRow sportEventScheduleRow;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState[VS_ISTEAMGAME] != null && ViewState[VS_ISTEAMGAME].ToString() != string.Empty)
            {
                IsTeamGame = Convert.ToBoolean(ViewState[VS_ISTEAMGAME]);
            }
            else
            {
                IsTeamGame = false;
            }

            if (ViewState[VS_ISLEAGUE] != null && ViewState[VS_ISLEAGUE].ToString() != string.Empty)
            {
                IsLeague = Convert.ToBoolean(ViewState[VS_ISLEAGUE]);
            }
            else
            {
                IsLeague = false;
            }

            if (!IsPostBack)
            {
                IsTeamGame = false;
                if (Request.QueryString[WebBase.QS_SCHEDULEID] != null)
                {
                    ViewState[WebBase.VS_SCHEDULEID] = Request.QueryString[WebBase.QS_SCHEDULEID];
                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnLoadFromCsv.Enabled = false;
                    btnFileUpload.Enabled = false;
                }

                if (Request.QueryString[WebBase.QS_EVENTID] != null)
                {
                    ViewState[WebBase.VS_EVENTID] = Request.QueryString[WebBase.QS_EVENTID];
                }

                this.GetSportEventSchedule();
                this.GetScoreName();
                this.GetRefereeList();

                if (IsTeamGame)
                {
                    this.GetStatisticName();
                }

                if (IsLeague)
                {
                    this.GetLeague();
                }

                BindData();
                this.DGScoreDetail();
                this.DGParticipantStatistic();
            }

            this.GetScoreList();

            if (IsTeamGame)
            {
                this.GetStatiscticList();
            }

            this.BindynamicData();
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

            #region GetSchedule
            responseDS = svc.GetSportEventSchedule(requestDS);
            if (responseDS.SportEventSchedule.Count > 0)
            {
                sportEventScheduleRow = responseDS.SportEventSchedule[0];
                IsTeamGame = (ReferenceNum.EventType)sportEventScheduleRow.EventTypeID != ReferenceNum.EventType.Individual;

                if ((ReferenceNum.CompetitionFormatType)sportEventScheduleRow.PlayFormatID == ReferenceNum.CompetitionFormatType.League)
                {
                    IsLeague = sportEventScheduleRow.IsLeague;
                    ViewState[VS_ISLEAGUE] = IsLeague.ToString();
                    ViewState[VS_GROUPCODE] = sportEventScheduleRow.GroupCode;
                }

                ViewState[VS_ISTEAMGAME] = IsTeamGame.ToString();
            }
            #endregion
        }

        protected void GetScoreName()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.ScoreNameRow row = requestDS.ScoreName.NewScoreNameRow();

            // Get Schedule ID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            requestDS.ScoreName.AddScoreNameRow(row);

            #region GetScoreNameList
            responseDS = svc.GetScoreName(requestDS);
            ViewState[WebBase.VS_SCORENAME_DS] = responseDS;
            #endregion
        }

        protected void GetScoreList()
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
            }
            else
            {
                responseDS = svc.GetPartcipantAndScore(requestDS);
            }

            ViewState[WebBase.VS_SCORE_DS] = responseDS;
            #endregion
        }

        protected void GetStatisticName()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.StatisticNameRow row = requestDS.StatisticName.NewStatisticNameRow();

            // Get Schedule ID
            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                row.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            requestDS.StatisticName.AddStatisticNameRow(row);

            #region GetScoreNameList
            responseDS = svc.GetStatisticName(requestDS);
            ViewState[WebBase.VS_STATISTICNAME_DS] = responseDS;
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

            ViewState[WebBase.VS_STATISTIC_DS] = responseDS;
            #endregion
        }

        protected void GetLeague()
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

            // Get Group Code
            if (ViewState[VS_GROUPCODE] != null && ViewState[VS_GROUPCODE].ToString() != string.Empty)
            {
                row.GroupCode = ViewState[VS_GROUPCODE].ToString();
            }

            requestDS.League.AddLeagueRow(row);

            #region GetLeague
            if (IsTeamGame)
            {
                responseDS = svc.GetLeagueForTeam(requestDS);
            }
            else
            {
                responseDS = svc.GetLeagueForIndividual(requestDS);
            }


            ViewState[WebBase.VS_LEAGUE_DS] = responseDS;
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

            ViewState[WebBase.VS_REFEREE_DS] = responseDS;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS scoreOutputDS = new CompetitionDS();

            #region Bind Schedule Details
            if (sportEventScheduleRow != null)
            {
                lblEventDetails.Text = sportEventScheduleRow.SportName.ToUpper() + " - " + sportEventScheduleRow.EventName;
                imgSportImage.ImageUrl = sportEventScheduleRow.ImageFilePath;
                lblScheduleDetails.Text = sportEventScheduleRow.ScheduleName;
                lblScheduleVenueTime.Text = sportEventScheduleRow.Location + " - " + sportEventScheduleRow.ScheduleDateTime.ToString();

                if (!sportEventScheduleRow.IsScheduleFooterNoteNull())
                {
                    ckeScheduleFooter.Text = sportEventScheduleRow.ScheduleFooterNote;
                }

                if (!sportEventScheduleRow.IsEventFooterNoteNull())
                {
                    ckeEventFooter.Text = sportEventScheduleRow.EventFooterNote;
                }

                if (!sportEventScheduleRow.IsIsTogleHtmlModeNull())
                {
                    chkTogleHtmlMode.Checked = sportEventScheduleRow.IsTogleHtmlMode;
                }
            }
            else
            {
                lblEventDetails.Visible = false;
                imgSportImage.Visible = false;
                lblScheduleDetails.Visible = false;
                lblScheduleVenueTime.Visible = false;
            }
            #endregion

            #region Bind Score Name
            scoreOutputDS = (CompetitionDS)ViewState[WebBase.VS_SCORENAME_DS];
            if (scoreOutputDS.ScoreName.Count > 0)
            {
                CompetitionDS.ScoreNameRow row = scoreOutputDS.ScoreName[0];
                hidScoreNameID.Value = row.ScoreNameID.ToString();
                txtScoreName1.Text = row.ScoreName1;
                txtScoreName2.Text = row.ScoreName2;
                txtScoreName3.Text = row.ScoreName3;
                txtScoreName4.Text = row.ScoreName4;
                txtScoreName5.Text = row.ScoreName5;
                txtScoreName6.Text = row.ScoreName6;
                txtScoreName7.Text = row.ScoreName7;
                txtScoreName8.Text = row.ScoreName8;
                txtScoreName9.Text = row.ScoreName9;
                txtScoreName10.Text = row.ScoreName10;
                txtScoreName11.Text = row.ScoreName11;
                txtScoreName12.Text = row.ScoreName12;
                txtScoreName13.Text = row.ScoreName13;
                txtScoreName14.Text = row.ScoreName14;
                txtScoreName15.Text = row.ScoreName15;
                txtScoreName16.Text = row.ScoreName16;
                txtScoreName17.Text = row.ScoreName17;
                txtScoreName18.Text = row.ScoreName18;
                txtScoreName19.Text = row.ScoreName19;
                txtScoreName20.Text = row.ScoreName20;
                txtScoreNameFinal.Text = row.ScoreNameFinal;
            }
            #endregion

            #region Bind StatisticName
            if (IsTeamGame)
            {
                scoreOutputDS = (CompetitionDS)ViewState[WebBase.VS_STATISTICNAME_DS];
                if (scoreOutputDS.StatisticName.Count > 0)
                {
                    CompetitionDS.StatisticNameRow row = scoreOutputDS.StatisticName[0];
                    txtStat1.Text = row.StatisticName1;
                    txtStat1.Text = row.StatisticName1;
                    txtStat2.Text = row.StatisticName2;
                    txtStat3.Text = row.StatisticName3;
                    txtStat4.Text = row.StatisticName4;
                    txtStat5.Text = row.StatisticName5;
                    txtStat6.Text = row.StatisticName6;
                    txtStat7.Text = row.StatisticName7;
                    txtStat8.Text = row.StatisticName8;
                    txtStat9.Text = row.StatisticName9;
                    txtStat10.Text = row.StatisticName10;
                    hidStatNameID.Value = row.StatisticNameID.ToString();
                }
            }
            #endregion

            #region Bind Referee
            scoreOutputDS = (CompetitionDS)ViewState[WebBase.VS_REFEREE_DS];
            if (scoreOutputDS.Referee.Count > 0)
            {
                CompetitionDS.RefereeRow row = scoreOutputDS.Referee[0];
                hidRefereeID.Value = row.RefereeID.ToString();
                txtRefName1.Text = row.RefereeName1;
                txtRefName2.Text = row.RefereeName2;
                txtRefName3.Text = row.RefereeName3;
                txtRefName4.Text = row.RefereeName4;
                txtRefName5.Text = row.RefereeName5;
                txtRefName6.Text = row.RefereeName6;
                txtRefName7.Text = row.RefereeName7;
                txtRefName8.Text = row.RefereeName8;
                txtRefName9.Text = row.RefereeName9;
                txtRefName10.Text = row.RefereeName10;
                txtRefTitle1.Text = row.RefereeTitle1;
                txtRefTitle2.Text = row.RefereeTitle2;
                txtRefTitle3.Text = row.RefereeTitle3;
                txtRefTitle4.Text = row.RefereeTitle4;
                txtRefTitle5.Text = row.RefereeTitle5;
                txtRefTitle6.Text = row.RefereeTitle6;
                txtRefTitle7.Text = row.RefereeTitle7;
                txtRefTitle8.Text = row.RefereeTitle8;
                txtRefTitle9.Text = row.RefereeTitle9;
                txtRefTitle10.Text = row.RefereeTitle10;
            }
            #endregion

            #region Bind League
            CompetitionDS finalScoreOutputDS = new CompetitionDS();
            scoreOutputDS = (CompetitionDS)ViewState[WebBase.VS_LEAGUE_DS];
            if (scoreOutputDS != null && scoreOutputDS.League != null && scoreOutputDS.League.Count > 0)
            {
                if (scoreOutputDS.League[0].IsLeagueIDNull())
                {
                    //CompetitionDS.LeagueRow insertRow = finalScoreOutputDS.League.NewLeagueRow();
                    //insertRow.Rank = 0;
                    //insertRow.FullName = "Lg Name";
                    //insertRow.TeamID = 0;
                    //finalScoreOutputDS.League.AddLeagueRow(insertRow);
                }
                else
                {
                    if (scoreOutputDS.League[0].Rank == 0)
                    {
                        scoreOutputDS.League[0].FullName = "Lg Name";
                    }
                }

                finalScoreOutputDS.League.Merge(scoreOutputDS.League);

                dgLeague.DataSource = finalScoreOutputDS.League;
                dgLeague.DataBind();
            }
            #endregion
        }

        protected void BindynamicData()
        {
            CompetitionDS scoreOutputDS = new CompetitionDS();

            #region Bind Score
            if (ViewState[WebBase.VS_SCORE_DS] != null)
            {
                scoreOutputDS = (CompetitionDS)ViewState[WebBase.VS_SCORE_DS];

                if (scoreOutputDS.Score != null)
                {
                    dgScoreDetail.DataSource = scoreOutputDS.Score;
                    dgScoreDetail.DataBind();
                }
            }
            #endregion

            #region Bind Statistic
            if (IsTeamGame)
            {
                pnlStatistic.Visible = true;
                scoreOutputDS = (CompetitionDS)ViewState[WebBase.VS_STATISTIC_DS];
                if (scoreOutputDS.Statistic != null)
                {
                    dgParticipantStatistic.DataSource = scoreOutputDS.Statistic;
                    dgParticipantStatistic.DataBind();
                }
            }
            #endregion
        }

        protected void DGScoreDetail()
        {
            WebBase.BindColumn("dgScoreDetail", dgScoreDetail);
        }

        protected void DGParticipantStatistic()
        {
            WebBase.BindColumn("dgParticipantStatistic", dgParticipantStatistic);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            WebBase webBase = new WebBase();
            if (!webBase.IsValidModule(Request))
            {
                int id = Convert.ToInt32(Request.QueryString[WebBase.QS_SPORTID]);

                ReferenceNum.Sport sport = (ReferenceNum.Sport)Enum.ToObject(typeof(ReferenceNum.Sport), id);
                string sportName = ReferenceNum.ToEnumString<ReferenceNum.Sport>(sport);
                Master.AjaxPopupMessage("Insufficient rights. Attempt to edit value for " + sportName + " is prohibited.");
                return;
            }

            this.SaveScore();
            this.SaveScoreName();
            this.SaveStatisticName();
            this.SaveStatistic();
            this.SaveScheduleDetails();
            this.SaveReferee();
            this.SaveLeague();

            if (ViewState[WebBase.VS_EVENTID] != null)
            {
                Master.AjaxPopupMessage("Result Saved ...!", "~/Competition/ScheduleMaintenance.aspx?EventID=" + ViewState[WebBase.VS_EVENTID]);
            }

        }

        protected void SaveScore()
        {
            CompetitionClient competitionSVC = new CompetitionClient();

            #region SaveScore
            var dgScoreRow = dgScoreDetail.Rows;
            foreach (GridViewRow row in dgScoreRow)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CompetitionDS responseDS = new CompetitionDS();
                    CompetitionDS requestDS = new CompetitionDS();
                    CompetitionDS.ScoreRow scoreRow = requestDS.Score.NewScoreRow();

                    scoreRow.Score1 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score1Column.ColumnName))).Text;
                    scoreRow.Score2 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score2Column.ColumnName))).Text;
                    scoreRow.Score3 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score3Column.ColumnName))).Text;
                    scoreRow.Score4 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score4Column.ColumnName))).Text;
                    scoreRow.Score5 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score5Column.ColumnName))).Text;
                    scoreRow.Score6 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score6Column.ColumnName))).Text;
                    scoreRow.Score7 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score7Column.ColumnName))).Text;
                    scoreRow.Score8 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score8Column.ColumnName))).Text;
                    scoreRow.Score9 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score9Column.ColumnName))).Text;
                    scoreRow.Score10 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score10Column.ColumnName))).Text;
                    scoreRow.Score11 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score11Column.ColumnName))).Text;
                    scoreRow.Score12 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score12Column.ColumnName))).Text;
                    scoreRow.Score13 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score13Column.ColumnName))).Text;
                    scoreRow.Score14 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score14Column.ColumnName))).Text;
                    scoreRow.Score15 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score15Column.ColumnName))).Text;
                    scoreRow.Score16 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score16Column.ColumnName))).Text;
                    scoreRow.Score17 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score17Column.ColumnName))).Text;
                    scoreRow.Score18 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score18Column.ColumnName))).Text;
                    scoreRow.Score19 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score19Column.ColumnName))).Text;
                    scoreRow.Score20 = ((TextBox)(row.FindControl("txt" + requestDS.Score.Score20Column.ColumnName))).Text;
                    scoreRow.ScoreFinal = ((TextBox)(row.FindControl("txt" + requestDS.Score.ScoreFinalColumn.ColumnName))).Text;
                    scoreRow.BreakRecord = ((TextBox)(row.FindControl("txt" + requestDS.Score.BreakRecordColumn.ColumnName))).Text;
                    scoreRow.MedalID = Convert.ToInt32(((DropDownList)(row.FindControl("ddl" + requestDS.Score.MedalIDColumn.ColumnName))).SelectedValue);
                    scoreRow.ResultPosition = Convert.ToInt32(((DropDownList)(row.FindControl("ddl" + requestDS.Score.ResultPositionColumn.ColumnName))).SelectedValue);
                    scoreRow.Remarks = ((TextBox)(row.FindControl("txt" + requestDS.Score.RemarksColumn.ColumnName))).Text;

                    if (dgScoreDetail.DataKeys[row.RowIndex].Values[requestDS.Score.ScoreIDColumn.ColumnName].ToString() != string.Empty)
                    {
                        scoreRow.ScoreID = Convert.ToInt32(dgScoreDetail.DataKeys[row.RowIndex].Values[requestDS.Score.ScoreIDColumn.ColumnName]);
                        scoreRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                        requestDS.Score.AddScoreRow(scoreRow);
                        competitionSVC.UpdateScore(requestDS);
                    }
                    else
                    {
                        scoreRow.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                        if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
                        {
                            scoreRow.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
                        }

                        if (IsTeamGame)
                        {
                            scoreRow.TeamID = Convert.ToInt32(dgScoreDetail.DataKeys[row.RowIndex].Values[requestDS.Score.TeamIDColumn.ColumnName]);
                            requestDS.Score.AddScoreRow(scoreRow);
                            competitionSVC.InsertScoreForTeamInSchedule(requestDS);
                        }
                        else
                        {
                            scoreRow.ParticipantInScheduleID = Convert.ToInt32(dgScoreDetail.DataKeys[row.RowIndex].Values[requestDS.Score.ParticipantInScheduleIDColumn.ColumnName]);
                            requestDS.Score.AddScoreRow(scoreRow);
                            competitionSVC.InsertScoreForParticipantInSchedule(requestDS);
                        }
                    }
                }
            }
            #endregion
        }

        protected void SaveScoreName()
        {
            #region SaveScoreName
            CompetitionClient competitionSVC = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            CompetitionDS.ScoreNameRow scoreNameRow = requestDS.ScoreName.NewScoreNameRow();
            scoreNameRow.ScoreName1 = txtScoreName1.Text;
            scoreNameRow.ScoreName2 = txtScoreName2.Text;
            scoreNameRow.ScoreName3 = txtScoreName3.Text;
            scoreNameRow.ScoreName4 = txtScoreName4.Text;
            scoreNameRow.ScoreName5 = txtScoreName5.Text;
            scoreNameRow.ScoreName6 = txtScoreName6.Text;
            scoreNameRow.ScoreName7 = txtScoreName7.Text;
            scoreNameRow.ScoreName8 = txtScoreName8.Text;
            scoreNameRow.ScoreName9 = txtScoreName9.Text;
            scoreNameRow.ScoreName10 = txtScoreName10.Text;
            scoreNameRow.ScoreName11 = txtScoreName11.Text;
            scoreNameRow.ScoreName12 = txtScoreName12.Text;
            scoreNameRow.ScoreName13 = txtScoreName13.Text;
            scoreNameRow.ScoreName14 = txtScoreName14.Text;
            scoreNameRow.ScoreName15 = txtScoreName15.Text;
            scoreNameRow.ScoreName16 = txtScoreName16.Text;
            scoreNameRow.ScoreName17 = txtScoreName17.Text;
            scoreNameRow.ScoreName18 = txtScoreName18.Text;
            scoreNameRow.ScoreName19 = txtScoreName19.Text;
            scoreNameRow.ScoreName20 = txtScoreName20.Text;
            scoreNameRow.ScoreNameFinal = txtScoreNameFinal.Text;

            scoreNameRow.IsVisible1 = false;
            scoreNameRow.IsVisible2 = false;
            scoreNameRow.IsVisible3 = false;
            scoreNameRow.IsVisible4 = false;
            scoreNameRow.IsVisible5 = false;
            scoreNameRow.IsVisible6 = false;
            scoreNameRow.IsVisible7 = false;
            scoreNameRow.IsVisible8 = false;
            scoreNameRow.IsVisible9 = false;
            scoreNameRow.IsVisible10 = false;
            scoreNameRow.IsVisible11 = false;
            scoreNameRow.IsVisible12 = false;
            scoreNameRow.IsVisible13 = false;
            scoreNameRow.IsVisible14 = false;
            scoreNameRow.IsVisible15 = false;
            scoreNameRow.IsVisible16 = false;
            scoreNameRow.IsVisible17 = false;
            scoreNameRow.IsVisible18 = false;
            scoreNameRow.IsVisible19 = false;
            scoreNameRow.IsVisible20 = false;

            if (hidScoreNameID.Value == null || hidScoreNameID.Value == string.Empty)
            {
                scoreNameRow.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
                {
                    scoreNameRow.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
                }

                requestDS.ScoreName.AddScoreNameRow(scoreNameRow);
                competitionSVC.InsertScoreName(requestDS);
            }
            else
            {
                scoreNameRow.ScoreNameID = Convert.ToInt32(hidScoreNameID.Value);
                scoreNameRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                requestDS.ScoreName.AddScoreNameRow(scoreNameRow);
                competitionSVC.UpdateScoreName(requestDS);
            }

            #endregion
        }

        protected void SaveStatisticName()
        {
            CompetitionClient competitionSVC = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            #region SaveStatisticName
            if (IsTeamGame)
            {
                CompetitionDS.StatisticNameRow statNameRow = requestDS.StatisticName.NewStatisticNameRow();
                statNameRow.StatisticName1 = txtStat1.Text;
                statNameRow.StatisticName2 = txtStat2.Text;
                statNameRow.StatisticName3 = txtStat3.Text;
                statNameRow.StatisticName4 = txtStat4.Text;
                statNameRow.StatisticName5 = txtStat5.Text;
                statNameRow.StatisticName6 = txtStat6.Text;
                statNameRow.StatisticName7 = txtStat7.Text;
                statNameRow.StatisticName8 = txtStat8.Text;
                statNameRow.StatisticName9 = txtStat9.Text;
                statNameRow.StatisticName10 = txtStat10.Text;

                if (hidStatNameID.Value == null || hidStatNameID.Value == string.Empty)
                {
                    statNameRow.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                    if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
                    {
                        statNameRow.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
                    }

                    requestDS.StatisticName.AddStatisticNameRow(statNameRow);
                    competitionSVC.InsertStatisticName(requestDS);
                }
                else
                {
                    statNameRow.StatisticNameID = Convert.ToInt32(hidStatNameID.Value);
                    statNameRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                    requestDS.StatisticName.AddStatisticNameRow(statNameRow);
                    competitionSVC.UpdateStatisticName(requestDS);
                }
            }

            #endregion
        }

        protected void SaveStatistic()
        {
            CompetitionClient competitionSVC = new CompetitionClient();

            #region SaveStatistic
            if (IsTeamGame)
            {
                var dgStatRow = dgParticipantStatistic.Rows;
                foreach (GridViewRow row in dgStatRow)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CompetitionDS responseDS = new CompetitionDS();
                        CompetitionDS requestDS = new CompetitionDS();
                        CompetitionDS.StatisticRow statRow = requestDS.Statistic.NewStatisticRow();

                        statRow.Statistic1 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic1Column.ColumnName))).Text;
                        statRow.Statistic2 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic2Column.ColumnName))).Text;
                        statRow.Statistic3 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic3Column.ColumnName))).Text;
                        statRow.Statistic4 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic4Column.ColumnName))).Text;
                        statRow.Statistic5 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic5Column.ColumnName))).Text;
                        statRow.Statistic6 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic6Column.ColumnName))).Text;
                        statRow.Statistic7 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic7Column.ColumnName))).Text;
                        statRow.Statistic8 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic8Column.ColumnName))).Text;
                        statRow.Statistic9 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic9Column.ColumnName))).Text;
                        statRow.Statistic10 = ((TextBox)(row.FindControl("txt" + requestDS.Statistic.Statistic10Column.ColumnName))).Text;

                        if (dgParticipantStatistic.DataKeys[row.RowIndex].Values[requestDS.Statistic.StatisticIDColumn.ColumnName].ToString() != string.Empty)
                        {
                            statRow.StatisticID = Convert.ToInt32(dgParticipantStatistic.DataKeys[row.RowIndex].Values[requestDS.Statistic.StatisticIDColumn.ColumnName]);
                            statRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                            requestDS.Statistic.AddStatisticRow(statRow);
                            competitionSVC.UpdateStatistic(requestDS);
                        }
                        else
                        {
                            statRow.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                            statRow.ParticipantInScheduleID = Convert.ToInt32(dgParticipantStatistic.DataKeys[row.RowIndex].Values[requestDS.Score.ParticipantInScheduleIDColumn.ColumnName]);

                            requestDS.Statistic.AddStatisticRow(statRow);
                            competitionSVC.InsertStatisticForParticipantInSchedule(requestDS);
                        }
                    }
                }
            }
            #endregion
        }

        protected void SaveScheduleDetails()
        {
            CompetitionClient competitionSVC = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            #region SaveScheduleDetails
            CompetitionDS.SportEventScheduleRow newSportEventScheduleRow = requestDS.SportEventSchedule.NewSportEventScheduleRow();
            newSportEventScheduleRow.ScheduleFooterNote = ckeScheduleFooter.Text;
            newSportEventScheduleRow.EventFooterNote = ckeEventFooter.Text;
            newSportEventScheduleRow.IsTogleHtmlMode = chkTogleHtmlMode.Checked;

            if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
            {
                newSportEventScheduleRow.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
            }

            if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
            {
                newSportEventScheduleRow.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
            }

            newSportEventScheduleRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

            requestDS.SportEventSchedule.AddSportEventScheduleRow(newSportEventScheduleRow);

            competitionSVC.UpdateScheduleExtraDetail(requestDS);
            #endregion
        }

        protected void SaveReferee()
        {
            CompetitionClient competitionSVC = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS requestDS = new CompetitionDS();

            #region SaveReferee
            CompetitionDS.RefereeRow refereeRow = requestDS.Referee.NewRefereeRow();
            refereeRow.RefereeName3 = txtRefName3.Text;
            refereeRow.RefereeName4 = txtRefName4.Text;
            refereeRow.RefereeName5 = txtRefName5.Text;
            refereeRow.RefereeName6 = txtRefName6.Text;
            refereeRow.RefereeName1 = txtRefName1.Text;
            refereeRow.RefereeName2 = txtRefName2.Text;
            refereeRow.RefereeName7 = txtRefName7.Text;
            refereeRow.RefereeName8 = txtRefName8.Text;
            refereeRow.RefereeName9 = txtRefName9.Text;
            refereeRow.RefereeName10 = txtRefName10.Text;
            refereeRow.RefereeTitle1 = txtRefTitle1.Text;
            refereeRow.RefereeTitle2 = txtRefTitle2.Text;
            refereeRow.RefereeTitle3 = txtRefTitle3.Text;
            refereeRow.RefereeTitle4 = txtRefTitle4.Text;
            refereeRow.RefereeTitle5 = txtRefTitle5.Text;
            refereeRow.RefereeTitle6 = txtRefTitle6.Text;
            refereeRow.RefereeTitle7 = txtRefTitle7.Text;
            refereeRow.RefereeTitle8 = txtRefTitle8.Text;
            refereeRow.RefereeTitle9 = txtRefTitle9.Text;
            refereeRow.RefereeTitle10 = txtRefTitle10.Text;

            if (hidRefereeID.Value == null || hidRefereeID.Value == string.Empty)
            {
                refereeRow.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                if (ViewState[WebBase.VS_SCHEDULEID] != null && ViewState[WebBase.VS_SCHEDULEID].ToString() != string.Empty)
                {
                    refereeRow.ScheduleID = Convert.ToInt32(ViewState[WebBase.VS_SCHEDULEID]);
                }

                requestDS.Referee.AddRefereeRow(refereeRow);
                competitionSVC.InsertReferee(requestDS);
            }
            else
            {
                refereeRow.RefereeID = Convert.ToInt32(hidRefereeID.Value);
                refereeRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);

                requestDS.Referee.AddRefereeRow(refereeRow);
                competitionSVC.UpdateReferee(requestDS);
            }
            #endregion
        }

        protected void SaveLeague()
        {
            CompetitionClient competitionSVC = new CompetitionClient();

            #region SaveLeague
            var dgLeagueRow = dgLeague.Rows;
            foreach (GridViewRow row in dgLeagueRow)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CompetitionDS responseDS = new CompetitionDS();
                    CompetitionDS requestDS = new CompetitionDS();
                    CompetitionDS.LeagueRow leagueRow = requestDS.League.NewLeagueRow();

                    if (((TextBox)row.FindControl("txtRank")).Text != string.Empty)
                    {
                        leagueRow.Rank = Convert.ToInt32(((TextBox)row.FindControl("txtRank")).Text);
                    }
                    else
                    {
                        leagueRow.Rank = 1;
                    }

                    if (((TextBox)row.FindControl("txtLeague1")).Text != string.Empty)
                    {
                        leagueRow.League1 = ((TextBox)row.FindControl("txtLeague1")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague2")).Text != string.Empty)
                    {
                        leagueRow.League2 = ((TextBox)row.FindControl("txtLeague2")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague3")).Text != string.Empty)
                    {
                        leagueRow.League3 = ((TextBox)row.FindControl("txtLeague3")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague4")).Text != string.Empty)
                    {
                        leagueRow.League4 = ((TextBox)row.FindControl("txtLeague4")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague5")).Text != string.Empty)
                    {
                        leagueRow.League5 = ((TextBox)row.FindControl("txtLeague5")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague6")).Text != string.Empty)
                    {
                        leagueRow.League6 = ((TextBox)row.FindControl("txtLeague6")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague7")).Text != string.Empty)
                    {
                        leagueRow.League7 = ((TextBox)row.FindControl("txtLeague7")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague8")).Text != string.Empty)
                    {
                        leagueRow.League8 = ((TextBox)row.FindControl("txtLeague8")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague9")).Text != string.Empty)
                    {
                        leagueRow.League9 = ((TextBox)row.FindControl("txtLeague9")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague10")).Text != string.Empty)
                    {
                        leagueRow.League10 = ((TextBox)row.FindControl("txtLeague10")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague11")).Text != string.Empty)
                    {
                        leagueRow.League11 = ((TextBox)row.FindControl("txtLeague11")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague12")).Text != string.Empty)
                    {
                        leagueRow.League12 = ((TextBox)row.FindControl("txtLeague12")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague13")).Text != string.Empty)
                    {
                        leagueRow.League13 = ((TextBox)row.FindControl("txtLeague13")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague14")).Text != string.Empty)
                    {
                        leagueRow.League14 = ((TextBox)row.FindControl("txtLeague14")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague15")).Text != string.Empty)
                    {
                        leagueRow.League15 = ((TextBox)row.FindControl("txtLeague15")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague16")).Text != string.Empty)
                    {
                        leagueRow.League16 = ((TextBox)row.FindControl("txtLeague16")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague17")).Text != string.Empty)
                    {
                        leagueRow.League17 = ((TextBox)row.FindControl("txtLeague17")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague18")).Text != string.Empty)
                    {
                        leagueRow.League18 = ((TextBox)row.FindControl("txtLeague18")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague19")).Text != string.Empty)
                    {
                        leagueRow.League19 = ((TextBox)row.FindControl("txtLeague19")).Text;
                    }

                    if (((TextBox)row.FindControl("txtLeague20")).Text != string.Empty)
                    {
                        leagueRow.League20 = ((TextBox)row.FindControl("txtLeague20")).Text;
                    }

                    if (dgLeague.DataKeys[row.RowIndex].Values[requestDS.League.LeagueIDColumn.ColumnName].ToString() != string.Empty)
                    {
                        leagueRow.LeagueID = Convert.ToInt32(dgLeague.DataKeys[row.RowIndex].Values[requestDS.League.LeagueIDColumn.ColumnName]);
                        leagueRow.ModifiedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                        requestDS.League.AddLeagueRow(leagueRow);
                        competitionSVC.UpdateLeague(requestDS);
                    }
                    else
                    {
                        leagueRow.CreatedBy = Convert.ToInt32(Session[WebBase.SESSION_ADMINID]);
                        leagueRow.GroupCode = ViewState[VS_GROUPCODE].ToString();
                        if (ViewState[WebBase.VS_EVENTID] != null && ViewState[WebBase.VS_EVENTID].ToString() != string.Empty)
                        {
                            leagueRow.EventID = Convert.ToInt32(ViewState[WebBase.VS_EVENTID]);
                        }

                        if (IsTeamGame)
                        {
                            if (dgLeague.DataKeys[row.RowIndex].Values[requestDS.League.TeamIDColumn.ColumnName].ToString() != string.Empty)
                            {
                                leagueRow.TeamID = Convert.ToInt32(dgLeague.DataKeys[row.RowIndex].Values[requestDS.League.TeamIDColumn.ColumnName]);
                            }
                            else
                            {
                                leagueRow.TeamID = 0;
                            }

                            requestDS.League.AddLeagueRow(leagueRow);
                            competitionSVC.InsertLeagueForTeam(requestDS);
                        }
                        else
                        {
                            if (dgLeague.DataKeys[row.RowIndex].Values[requestDS.League.ParticipantInEventIDColumn.ColumnName].ToString() != string.Empty)
                            {
                                leagueRow.ParticipantInEventID = Convert.ToInt32(dgLeague.DataKeys[row.RowIndex].Values[requestDS.League.ParticipantInEventIDColumn.ColumnName]);
                            }
                            else
                            {
                                leagueRow.ParticipantInEventID = 0;
                            }

                            requestDS.League.AddLeagueRow(leagueRow);
                            competitionSVC.InsertLeagueForIndividual(requestDS);
                        }
                    }
                }
            }
            #endregion
        }

        protected void dgScoreDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SystemMaintenanceDS ds = new SystemMaintenanceDS();
                CompetitionDS compDS = new CompetitionDS();

                ds = GetDataColumnByDataGridName("dgScoreDetail");

                foreach (SystemMaintenanceDS.DataGridColumnRow row in ds.DataGridColumn)
                {
                    switch ((ReferenceNum.DataColumnType)Enum.Parse(typeof(ReferenceNum.DataColumnType), row.ColumnTypeID.ToString()))
                    {
                        case ReferenceNum.DataColumnType.TextBox:
                            TextBox txt = new TextBox();
                            txt.ID = "txt" + row.DataField;

                            object txtValue = DataBinder.Eval(e.Row.DataItem, row.DataField);
                            if (txtValue != DBNull.Value)
                            {
                                txt.Text = txtValue.ToString();
                            }

                            if (e.Row.Cells.Count > 2)
                            {
                                e.Row.Cells[row.SortID + 2].Controls.Add(txt);
                            }

                            break;
                        case ReferenceNum.DataColumnType.DropDown:
                            DropDownList ddl = new DropDownList();
                            ddl.ID = "ddl" + row.DataField;
                            BindDropDownItems(ddl, row.EnumTypeID);

                            object ddlValue = DataBinder.Eval(e.Row.DataItem, row.DataField);
                            if (ddlValue != DBNull.Value)
                            {
                                ddl.SelectedValue = ddlValue.ToString();
                            }

                            if (e.Row.Cells.Count > 2)
                            {
                                e.Row.Cells[row.SortID + 2].Controls.Add(ddl);
                            }
                            break;
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[e.Row.Cells.Count - 1].CssClass = "result-maintenance-highlight";
                e.Row.Cells[e.Row.Cells.Count - 2].CssClass = "result-maintenance-highlight";
                e.Row.Cells[e.Row.Cells.Count - 3].CssClass = "result-maintenance-highlight";
                e.Row.Cells[e.Row.Cells.Count - 4].CssClass = "result-maintenance-highlight";
                e.Row.Cells[e.Row.Cells.Count - 5].CssClass = "result-maintenance-highlight";
            }
        }

        protected void dgParticipantStatistic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SystemMaintenanceDS ds = new SystemMaintenanceDS();
                CompetitionDS compDS = new CompetitionDS();

                ds = GetDataColumnByDataGridName("dgParticipantStatistic");

                foreach (SystemMaintenanceDS.DataGridColumnRow row in ds.DataGridColumn)
                {
                    switch ((ReferenceNum.DataColumnType)Enum.Parse(typeof(ReferenceNum.DataColumnType), row.ColumnTypeID.ToString()))
                    {
                        case ReferenceNum.DataColumnType.TextBox:

                            TextBox txt = new TextBox();
                            txt.ID = "txt" + row.DataField;

                            object txtValue = DataBinder.Eval(e.Row.DataItem, row.DataField);
                            if (txtValue != DBNull.Value)
                            {
                                txt.Text = txtValue.ToString();
                            }


                            if (e.Row.Cells.Count > 2)
                            {
                                e.Row.Cells[row.SortID + 2].Controls.Add(txt);
                            }
                            break;
                    }
                }
            }
        }

        public SystemMaintenanceDS GetDataColumnByDataGridName(string dataGridName)
        {
            //Get data grid from DB
            SystemMaintenanceClient systemMaintenanceSVC = new SystemMaintenanceClient();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();

            ds = systemMaintenanceSVC.GetDataColumnByDataGridName(dataGridName);

            return ds;
        }

        void BindDropDownItems(DropDownList dropDown, int eNum)
        {
            switch ((ReferenceNum.ReferenceCategory)Enum.Parse(typeof(ReferenceNum.ReferenceCategory), eNum.ToString()))
            {
                case ReferenceNum.ReferenceCategory.MedalType:
                    foreach (ReferenceNum.MedalType item in Enum.GetValues(typeof(ReferenceNum.MedalType)).Cast<ReferenceNum.MedalType>())
                    {
                        ListItem listItem = new ListItem();
                        listItem.Value = Convert.ToInt32((ReferenceNum.MedalType)Enum.Parse(typeof(ReferenceNum.MedalType), item.ToString())).ToString();
                        listItem.Text = item.ToString();
                        dropDown.Items.Add(listItem);
                    }
                    break;
                case ReferenceNum.ReferenceCategory.ResultPosition:
                    foreach (ReferenceNum.ResultPosition item in Enum.GetValues(typeof(ReferenceNum.ResultPosition)).Cast<ReferenceNum.ResultPosition>())
                    {
                        ListItem listItem = new ListItem();
                        listItem.Value = Convert.ToInt32((ReferenceNum.ResultPosition)Enum.Parse(typeof(ReferenceNum.ResultPosition), item.ToString())).ToString();
                        listItem.Text = item.ToString();
                        dropDown.Items.Add(listItem);
                    }
                    break;
            }
        }

        protected void btnLoadFromCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnFileUpload.HasFile)
                {
                    string fileName = btnFileUpload.FileName;

                    CompetitionDS scoreNameDS = new CompetitionDS();
                    scoreNameDS = (CompetitionDS)ViewState[WebBase.VS_SCORENAME_DS];

                    CompetitionDS scoreDS = new CompetitionDS();
                    scoreDS = (CompetitionDS)ViewState[WebBase.VS_SCORE_DS];


                    string extension = Path.GetExtension(btnFileUpload.FileName);
                    if (extension == ".csv")
                    {
                        StreamReader strReader = new StreamReader(btnFileUpload.FileContent);
                        while (!strReader.EndOfStream)
                        {
                            if (!WebBase.IsCharacterNDigitNPunctuationNSpaceOnly(strReader.ReadLine()))
                            {
                                Master.AjaxPopupMessage("Uploaded file contains invalid characters. $, +, <, =, >, ^, `, |, ~ are prohibited in the system.");
                                return;
                            }
                        }
                        Stream fs = btnFileUpload.PostedFile.InputStream;
                        fs.Position = 0;

                        StreamReader sr = new StreamReader(btnFileUpload.FileContent);
                        int rowcount = 0;
                        while (!sr.EndOfStream)
                        {
                            //string[] csvRow = sr.ReadLine().Split(',');
                            string[] csvRow = new string[] { };
                            byte[] byteArray = Encoding.UTF8.GetBytes(sr.ReadLine());
                            MemoryStream stream = new MemoryStream(byteArray);
                            if (rowcount > 0)
                            {
                                using (var parser = new TextFieldParser(stream))
                                {
                                    parser.TextFieldType = FieldType.Delimited;
                                    parser.SetDelimiters(",");
                                    while (!parser.EndOfData)
                                    {
                                        csvRow = parser.ReadFields();
                                    }
                                }

                                if (csvRow.Length >= 22 && csvRow[0] == "Score Name")
                                {
                                    if (scoreNameDS.ScoreName.Count > 0)
                                    {
                                        CompetitionDS.ScoreNameRow row = scoreNameDS.ScoreName[0];
                                        row.ScoreName1 = csvRow[1];
                                        row.ScoreName2 = csvRow[2];
                                        row.ScoreName3 = csvRow[3];
                                        row.ScoreName4 = csvRow[4];
                                        row.ScoreName5 = csvRow[5];
                                        row.ScoreName6 = csvRow[6];
                                        row.ScoreName7 = csvRow[7];
                                        row.ScoreName8 = csvRow[8];
                                        row.ScoreName9 = csvRow[9];
                                        row.ScoreName10 = csvRow[10];
                                        row.ScoreName11 = csvRow[11];
                                        row.ScoreName12 = csvRow[12];
                                        row.ScoreName13 = csvRow[13];
                                        row.ScoreName14 = csvRow[14];
                                        row.ScoreName15 = csvRow[15];
                                        row.ScoreName16 = csvRow[16];
                                        row.ScoreName17 = csvRow[17];
                                        row.ScoreName18 = csvRow[18];
                                        row.ScoreName19 = csvRow[19];
                                        row.ScoreName20 = csvRow[20];
                                        row.ScoreNameFinal = csvRow[21];
                                    }

                                    txtScoreName1.Text = csvRow[1];
                                    txtScoreName2.Text = csvRow[2];
                                    txtScoreName3.Text = csvRow[3];
                                    txtScoreName4.Text = csvRow[4];
                                    txtScoreName5.Text = csvRow[5];
                                    txtScoreName6.Text = csvRow[6];
                                    txtScoreName7.Text = csvRow[7];
                                    txtScoreName8.Text = csvRow[8];
                                    txtScoreName9.Text = csvRow[9];
                                    txtScoreName10.Text = csvRow[10];
                                    txtScoreName11.Text = csvRow[11];
                                    txtScoreName12.Text = csvRow[12];
                                    txtScoreName13.Text = csvRow[13];
                                    txtScoreName14.Text = csvRow[14];
                                    txtScoreName15.Text = csvRow[15];
                                    txtScoreName16.Text = csvRow[16];
                                    txtScoreName17.Text = csvRow[17];
                                    txtScoreName18.Text = csvRow[18];
                                    txtScoreName19.Text = csvRow[19];
                                    txtScoreName20.Text = csvRow[20];
                                    txtScoreNameFinal.Text = csvRow[21];
                                }
                                else if (csvRow.Length >= 25)
                                {
                                    foreach (CompetitionDS.ScoreRow scoreRow in scoreDS.Score)
                                    {
                                        if ((!scoreRow.IsAccreditationNumberNull() && scoreRow.AccreditationNumber == csvRow[0]) || (!scoreRow.IsFullNameNull() && scoreRow.FullName.ToUpper().Trim() == csvRow[0].ToUpper().Trim()) || scoreRow.CountryName == csvRow[0])
                                        {
                                            scoreRow.Score1 = csvRow[1];
                                            scoreRow.Score2 = csvRow[2];
                                            scoreRow.Score3 = csvRow[3];
                                            scoreRow.Score4 = csvRow[4];
                                            scoreRow.Score5 = csvRow[5];
                                            scoreRow.Score6 = csvRow[6];
                                            scoreRow.Score7 = csvRow[7];
                                            scoreRow.Score8 = csvRow[8];
                                            scoreRow.Score9 = csvRow[9];
                                            scoreRow.Score10 = csvRow[10];
                                            scoreRow.Score11 = csvRow[11];
                                            scoreRow.Score12 = csvRow[12];
                                            scoreRow.Score13 = csvRow[13];
                                            scoreRow.Score14 = csvRow[14];
                                            scoreRow.Score15 = csvRow[15];
                                            scoreRow.Score16 = csvRow[16];
                                            scoreRow.Score17 = csvRow[17];
                                            scoreRow.Score18 = csvRow[18];
                                            scoreRow.Score19 = csvRow[19];
                                            scoreRow.Score20 = csvRow[20];
                                            scoreRow.ScoreFinal = csvRow[21];
                                            scoreRow.ResultPosition = Convert.ToInt32(csvRow[22]);
                                            scoreRow.MedalID = Convert.ToInt32(csvRow[23]);
                                            scoreRow.BreakRecord = csvRow[24];
                                            break;
                                        }
                                    }
                                }
                            }
                            rowcount++;
                        }
                    }

                    ViewState[WebBase.VS_SCORE_DS] = scoreDS;
                    ViewState[WebBase.VS_SCORENAME_DS] = scoreNameDS;

                    BindData();
                    BindynamicData();
                }
                else
                {
                    Response.Write("<script>alert('Please select CSV file.');</script>");
                }
            }
            catch (Exception ex)
            {
                Master.AjaxPopupMessage("There was an error in attempt to upload the file. Please check the file format.", "");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewState[WebBase.VS_EVENTID] != null)
            {
                Response.Redirect("~/Competition/ScheduleMaintenance.aspx?EventID=" + ViewState[WebBase.VS_EVENTID]);
            }
            else
            {
                Response.Redirect("~/Competition/ScheduleMaintenance.aspx");
            }
        }

        protected void dgLeague_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    TextBox textBox = (TextBox)e.Row.FindControl("txtRank");
                    textBox.Enabled = false;

                    RangeValidator rangeValidator = (RangeValidator)e.Row.FindControl("validRank");
                    rangeValidator.Enabled = false;
                }
            }
        }
    }
}