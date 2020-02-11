using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SVC.Web
{
    public partial class Server : System.Web.UI.Page
    {
        //use webbase class for these values, name the parameters accordingly
        private const string REQUEST_PARAMETER1 = "Parameter1";
        private const string REQUEST_PARAMETER2 = "Parameter2";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ProcessRequest(); // put breakpoint here when debug
        }

        public void ProcessRequest()
        {
            try
            {
                HttpContext context = HttpContext.Current;
                var parameter1 = context.Request[REQUEST_PARAMETER1];
                var parameter2 = context.Request[REQUEST_PARAMETER2];

                //Once you have the parameter, you can do anything you like

                Response.Write("Response1");
                Response.Write("Response2");
            }
            catch
            {
                Response.Write("Failed. System error.");
            }
        }
    }
}