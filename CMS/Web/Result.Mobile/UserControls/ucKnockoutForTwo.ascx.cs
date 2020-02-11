using SEM.CMS.CL.AR.Common;
using SEM.CMS.Result.Mobile.WCFCompetition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Result.Mobile.UserControls
{
    public partial class ucKnockoutForTwo : System.Web.UI.UserControl
    {
        bool isThridPlacing = false;

        public void LoadandBindData(CompetitionDS competitionDS, ReferenceNum.EventType eventType)
        {
            if (competitionDS.KnockoutSummary.Count > 0)
            {
                DataTable roundNameTable = competitionDS.KnockoutSummary.DefaultView.ToTable(true, "RoundName");
                if (roundNameTable.Rows.Count > 0)
                {
                    lblRoundName1.Text = roundNameTable.Rows[0]["RoundName"].ToString();
                }

                if (roundNameTable.Rows.Count > 1)
                {
                    lblRoundName2.Text = roundNameTable.Rows[1]["RoundName"].ToString();
                    isThridPlacing = true;
                }

                DataTable scheduleIDTable = competitionDS.KnockoutSummary.DefaultView.ToTable(true, "ScheduleID");

                for (int i = 0; i < scheduleIDTable.Rows.Count; i++)
                {
                    CompetitionDS.KnockoutSummaryRow summaryRow;
                    var row = scheduleIDTable.Rows[i];
                    CompetitionDS.KnockoutSummaryRow[] temp2 = (CompetitionDS.KnockoutSummaryRow[])(competitionDS.KnockoutSummary
                        .Select("ScheduleID = " + row["ScheduleID"].ToString()));

                    DataRow[] temp3 = temp2.OrderBy(item => item.PreviousMatchNumber).ToArray();

                    #region Row 1
                    if (temp3.Length > 0)
                    {
                        summaryRow = (CompetitionDS.KnockoutSummaryRow)temp3[0];

                        if (!summaryRow.IsMatchNumberNull() && !summaryRow.IsTotalParticipantNull() && !summaryRow.IsCompetitionStageNull())
                        {
                            Label lblName = (Label)FindControl("lblName" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_1");
                            Image imgCountry = (Image)FindControl("imgCountry" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_1");
                            Label lblScore = (Label)FindControl("lblScore" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_1");
                            Image imgMedal = (Image)FindControl("imgMedal" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_1");

                            if (lblName != null)
                            {
                                if (eventType == ReferenceNum.EventType.Doubles || eventType == ReferenceNum.EventType.Team)
                                {
                                    lblName.Text = (summaryRow.IsTeamNameNull()) ? "" : summaryRow.TeamName;
                                }
                                else
                                {
                                    lblName.Text = (summaryRow.IsFullNameNull()) ? "" : summaryRow.FullName;
                                }

                                imgCountry.ImageUrl = (summaryRow.IsIconFilePathNull()) ? "" : ResolveUrl(summaryRow.IconFilePath);
                                lblScore.Text = (summaryRow.IsScoreFinalNull()) ? "" : summaryRow.ScoreFinal;

                                if (imgMedal != null)
                                {
                                    if (!summaryRow.IsMedalIconFilePathNull() && summaryRow.MedalIconFilePath != string.Empty)
                                    {
                                        imgMedal.ImageUrl = ResolveUrl(summaryRow.MedalIconFilePath);
                                    }
                                    else
                                    {
                                        imgMedal.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region Row 2
                    if (temp3.Length > 1)
                    {
                        summaryRow = (CompetitionDS.KnockoutSummaryRow)temp3[1];

                        if (!summaryRow.IsMatchNumberNull() && !summaryRow.IsTotalParticipantNull() && !summaryRow.IsCompetitionStageNull())
                        {
                            Label lblName = (Label)FindControl("lblName" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_2");
                            Image imgCountry = (Image)FindControl("imgCountry" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_2");
                            Label lblScore = (Label)FindControl("lblScore" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_2");
                            Image imgMedal = (Image)FindControl("imgMedal" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_2");

                            if (lblName != null)
                            {
                                if (eventType == ReferenceNum.EventType.Doubles || eventType == ReferenceNum.EventType.Team)
                                {
                                    lblName.Text = (summaryRow.IsTeamNameNull()) ? "" : summaryRow.TeamName;
                                }
                                else
                                {
                                    lblName.Text = (summaryRow.IsFullNameNull()) ? "" : summaryRow.FullName;
                                }

                                imgCountry.ImageUrl = (summaryRow.IsIconFilePathNull()) ? "" : ResolveUrl(summaryRow.IconFilePath);
                                lblScore.Text = (summaryRow.IsScoreFinalNull()) ? "" : summaryRow.ScoreFinal;

                                if (imgMedal != null)
                                {
                                    if (!summaryRow.IsMedalIconFilePathNull() && summaryRow.MedalIconFilePath != string.Empty)
                                    {
                                        imgMedal.ImageUrl = ResolveUrl(summaryRow.MedalIconFilePath);
                                    }
                                    else
                                    {
                                        imgMedal.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    else if (temp3.Length == 1)
                    {
                        summaryRow = (CompetitionDS.KnockoutSummaryRow)temp3[0];

                        if (!summaryRow.IsMatchNumberNull() && !summaryRow.IsTotalParticipantNull() && !summaryRow.IsCompetitionStageNull())
                        {
                            Label lblName = (Label)FindControl("lblName" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_2");
                            Image imgMedal = (Image)FindControl("imgMedal" + summaryRow.CompetitionStage + "_" + summaryRow.MatchNumber + "_2");

                            if (lblName != null)
                            {
                                lblName.Text = "Bye";
                            }

                            if (imgMedal != null)
                            {
                                imgMedal.Visible = false;
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        public string GetStyle()
        {
            return (isThridPlacing) ? "" : "display:none";
        }
    }
}