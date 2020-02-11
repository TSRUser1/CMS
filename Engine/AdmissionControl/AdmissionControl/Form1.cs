using Microsoft.Practices.EnterpriseLibrary.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universal.X307.AppBase;

namespace AdmissionControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                grid_Output.DataSource = null;

                if (txt_Input.Text.Length == 0)
                {
                    MessageBox.Show("Please provide input!");
                    return;
                }

                AdmissionControlBF bf = new AdmissionControlBF();
                AdmissionControlDS inputDS = new AdmissionControlDS();
                AdmissionControlDS.AdminUserRow inputRow = inputDS.AdminUser.NewAdminUserRow();

                inputRow.AdminUserID = Convert.ToInt32(txt_Input.Text);

                inputDS.AdminUser.AddAdminUserRow(inputRow);

                AdmissionControlDS outputDS = bf.GetSingleAdminUser(inputDS);

                if (outputDS.AdminUser.Count == 0)
                {
                    MessageBox.Show("No data with matching input!");
                    return;
                }

                grid_Output.DataSource = outputDS.AdminUser;
            }
            catch (Exception ex)
            {
                AppBase.BusinessErrorHandling(ex, "Input : " + txt_Input.Text);
            }
        }
    }
}
