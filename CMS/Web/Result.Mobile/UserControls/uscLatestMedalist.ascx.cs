using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.Result.Mobile.WCFCompetition;

namespace SEM.CMS.Result.Mobile.UserControls
{
    public partial class uscLatestMedalist : System.Web.UI.UserControl
    {
        private int? _CountryID = null;
        private int? _SportID = null;
        private DateTime? _Date = null;

        public int? CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        public int? SportID
        {
            get { return _SportID; }
            set { _SportID = value; }
        }
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetLatestMedallist();
            }
            this.BindData();
        }

        protected void GetLatestMedallist()
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS responseDS = new CompetitionDS();

            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS.MedallistRow row = requestDS.Medallist.NewMedallistRow();

            if (this.SportID.HasValue)
            {
                row.SportID = this.SportID.Value;
            }
            if (this.CountryID.HasValue)
            {
                row.CountryID = this.CountryID.Value;
            }
            if (this.Date.HasValue)
            {
                row.ScheduleDateTime = this.Date.Value;
            }

            row.MedalCode = "GOLD";

            requestDS.Medallist.AddMedallistRow(row);

            #region GetLatestMedallist
            responseDS = svc.GetMedallist(requestDS);

            ViewState[WebBase.VS_LATESTMEDALLIST_DS] = responseDS.Medallist;
            #endregion
        }

        protected void BindData()
        {
            CompetitionDS.MedallistDataTable latestMedallistDT = new CompetitionDS.MedallistDataTable();
            latestMedallistDT = (CompetitionDS.MedallistDataTable)ViewState[WebBase.VS_LATESTMEDALLIST_DS];
            //order by schedule date time, take top 5
            dgLatestMedallist.DataSource = latestMedallistDT.OrderByDescending(a => a.ScheduleDateTime).Take(5);
            dgLatestMedallist.DataBind();

            if (dgLatestMedallist.Items.Count == 0)
                dvFooter.Visible = true;
            else
                dvFooter.Visible = false;

            //if (dgLatestMedallist.Items.Count == 0)
            //{
            //    dgLatestMedallist.ShowFooter = true;
            //}
            //else
            //{
            //    dgLatestMedallist.ShowFooter = false;
            //}
        }

        protected void dgLatestMedallist_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].ColumnSpan = 2;
                e.Row.Cells.RemoveAt(0);
            }
        }

        public void Bind()
        {
            this.GetLatestMedallist();
            this.BindData();
        }

        protected void dgLatestMedallist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (dgLatestMedallist.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                    lblFooter.Visible = true;
                }
            }
        }
      
    }
}