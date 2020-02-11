using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Web.Admin
{
    public partial class Crypto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtFinalText.Text = AppBase.Encryption(txtOriText.Text, txtSecret.Text);
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtFinalText.Text = AppBase.Decryption(txtOriText.Text, txtSecret.Text);
        }
    }
}