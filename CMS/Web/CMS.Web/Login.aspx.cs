using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.Web.WCFAdministration;

namespace SEM.CMS.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtLoginID.AutoCompleteType = AutoCompleteType.Disabled;
                txtPassword.AutoCompleteType = AutoCompleteType.Disabled;

                IsValidSession();
                txtLoginID.Focus();
                if (Request.QueryString[WebBase.QS_ACTION] != null)
                {
                    if (Request.QueryString[WebBase.QS_ACTION] == "logout")
                    {
                        Session.Abandon();
                        Session.Clear();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    }
                }

                img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=1"; //whenever pass New > 0, code will be refreshed
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValidCaptchaCode())
            {
                AdministrationClient admininstrationSVC = new AdministrationClient();
                AdministrationDS reqDS = new AdministrationDS();
                string sessionGUID = Guid.NewGuid().ToString(); // Generate GUID

                #region ProcessAdministrationLogin
                AdministrationDS.AdminUserRow signInRow = reqDS.AdminUser.NewAdminUserRow();
                signInRow.LoginID = txtLoginID.Text;
                signInRow.Password = txtPassword.Text;
                signInRow.LoginSessionGUID = sessionGUID;
                reqDS.AdminUser.AddAdminUserRow(signInRow);

                AdministrationDS adminLoginDS = new AdministrationDS();
                adminLoginDS = admininstrationSVC.ProcessAdministrationLogin(reqDS);  // Call svc process admin login
                #endregion

                bool isAutenticated = false;
                string sSystemMsg = "";
                if (adminLoginDS.AdminUser.Rows.Count != 0)
                {
                    if (adminLoginDS.Response[0].ResponseCode == SystemMessage.MA_LoginSuccess_INFO_CODE) // from the response, determine if the member is login
                    {
                        isAutenticated = true;
                    }
                    else
                    {
                        sSystemMsg = adminLoginDS.Response[0].ResponseMessage;
                    }
                }

                if (isAutenticated)
                {
                    lblLoginRespMsg.Visible = false;
                    Session[WebBase.SESSION_ADMINDS] = adminLoginDS;
                    Session[WebBase.SESSION_ADMINID] = adminLoginDS.AdminUser[0].AdminUserID;
                    Session[WebBase.SESSION_ADMINUSERNAME] = txtLoginID.Text;
                    Session[WebBase.SESSION_ADMIN_SESSION_GUIDID] = sessionGUID;  // add the GUID to session
                    reqDS.AdminUser[0].AdminUserID = adminLoginDS.AdminUser[0].AdminUserID;
                    AdministrationDS ds = new AdministrationDS();
                    ds = admininstrationSVC.UpdateAdminLoginSessionGUID(reqDS); // insert GUID to DB

                    #region GatherAdminAccessibleModule
                    if (adminLoginDS != null)
                    {
                        string sAccessSports = "";
                        string sAccessPages = "";

                        foreach (AdministrationDS.ModuleRow row in adminLoginDS.Module)
                        {
                            if (!sAccessSports.Contains(row.FunctionName.ToString()))
                            {
                                sAccessSports = sAccessSports + ((sAccessSports == "") ? "" : ",") + "'" + row.FunctionName.ToString() + "'";
                            }

                            if (!sAccessPages.Contains(row.PageName.ToString()))
                            {
                                sAccessPages = sAccessPages + ((sAccessPages == "") ? "" : ",") + "'" + row.PageName.ToString() + "'";
                            }
                        }

                        Session[WebBase.SESSION_ACCESSSPORTS] = sAccessSports;
                        Session[WebBase.SESSION_ACCESSPAGES] = sAccessPages;
                    }
                    #endregion

                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    lblLoginRespMsg.Visible = true;
                    lblLoginRespMsg.Text = sSystemMsg;
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=" + rand.Next(1, 100); // if New=0, then no refresh
                    UpdatePanelCaptcha.Update();
                }
            }
            else
            {
                lblLoginRespMsg.Visible = true;
                lblLoginRespMsg.Text = "Invalid Code!";
                Random rand = new Random((int)DateTime.Now.Ticks);
                img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=" + rand.Next(1, 100); // if New=0, then no refresh
                UpdatePanelCaptcha.Update();
            }
        }

        private Boolean IsValidCaptchaCode()
        {
            img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=0"; // New = 0 so that captcha not accidentally refreshed  
            string code = Session[WebBase.SESSION_CAPTCHACODE_LOGIN].ToString();

            //check robot
            if (Session[WebBase.SESSION_CAPTCHACODE_LOGIN] != null && txtCode.Text == Session[WebBase.SESSION_CAPTCHACODE_LOGIN].ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void img_captcha_Click(object sender, ImageClickEventArgs e)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            img_captcha.ImageUrl = "~/CreateCaptcha.aspx?Page=login&New=" + rand.Next(1, 100); // if New=0, then no refresh
            UpdatePanelCaptcha.Update();
        }

        private void IsValidSession()
        {
            if (Session[WebBase.SESSION_ADMINID] == null)
            {
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            }
        }
    }
}