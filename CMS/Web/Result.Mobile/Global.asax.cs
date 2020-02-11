using System;
using System.Threading;

using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Result.Mobile
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            AppBase.BusinessErrorHandling(ex, AppBase.GetCurrentMethod());

            try
            {
                Response.Redirect("~/Error.aspx", true);
            }
            catch (ThreadAbortException)
            {
                // Response.Redirect will always throw ThreadAbortException
                // ignore it
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}