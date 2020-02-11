using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEM.CMS.Web.TemplateWF
{
    public partial class TestCaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=1"; //whenever pass New > 0, code will be refreshed

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=0"; // New = 0 so that captcha not accidentally refreshed  
            string code = Session[WebBase.SESSION_CAPTCHACODE_LOGIN].ToString();

            //check robot
            if (Session[WebBase.SESSION_CAPTCHACODE_LOGIN] != null && txtCode.Text == Session[WebBase.SESSION_CAPTCHACODE_LOGIN].ToString())
            {
                lblMsg.Text = "Correct Code!";
            }
            else
            {
                lblMsg.Text = "Incorrect Code!";
            }
        }

        protected void img_captcha_Click(object sender, ImageClickEventArgs e)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=" + rand.Next(1, 100); // if New=0, then no refresh
            UpdatePanelCaptcha.Update();
        }
    }
}