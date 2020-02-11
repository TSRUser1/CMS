using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MA.DA.AdministrationDataAccess;
using SEM.CMS.CL.MA.DS.AdministrationDataset;

namespace SEM.CMS.CL.MA.BF.AdministrationFacade
{
    public class AdministrationBF : AppBase
    {
        string code = "", message = "";

        #region DeleteAdminUserDetail
        public AdministrationDS DeleteAdminUserDetail(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.DeleteAdminUserDetail(inputDS.AdminUser[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteModule
        public AdministrationDS DeleteModule(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.DeleteModule(inputDS.Module[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteRole
        public AdministrationDS DeleteRole(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.DeleteRole(inputDS.Role[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAdminUser
        public AdministrationDS GetAdminUser(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetAdminUser(inputDS.AdminUser[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAdminUserByLoginID
        public AdministrationDS GetAdminUserByLoginID(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetAdminUserByLoginID(inputDS.AdminUser[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAdminLoginSession
        public AdministrationDS GetAdminLoginSession(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetAdminLoginSession(inputDS.AdminUser[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetModule
        public AdministrationDS GetModule(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetModule(inputDS.Module[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetFunctionName
        public AdministrationDS GetFunctionName()
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetFunctionName();
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetPageName
        public AdministrationDS GetPageName()
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetPageName();
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetRole
        public AdministrationDS GetRole(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetRole(inputDS.Role[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertAdminUserDetail
        public AdministrationDS InsertAdminUserDetail(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.GetAdminUser(inputDS.AdminUser[0]);

                if (resDS != null && resDS.AdminUser.Rows.Count > 0)
                {
                    code = SystemMessage.User_Exist_Code;
                    message = SystemMessage.User_Exist_Msg;
                }
                else
                {
                    inputDS.AdminUser[0].Password = Encrypt(inputDS.AdminUser[0].Password);
                    resDS = da.InsertAdminUserDetail(inputDS.AdminUser[0]);
                    code = SystemMessage.Generic_Success_Code;
                    message = SystemMessage.Generic_Success_Msg;

                    foreach (AdministrationDS.AdminUserInRoleRow row in inputDS.AdminUserInRole)
                    {
                        row.AdminUserID = resDS.AdminUser[0].AdminUserID;
                        da.InsertAdminUserInRole(row);
                    }
                }

                resDS.Response.AddResponseRow(code, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertModule
        public AdministrationDS InsertModule(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.InsertModule(inputDS.Module[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertRole
        public AdministrationDS InsertRole(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.InsertRole(inputDS.Role[0]);

                if (resDS != null && resDS.Role.Rows.Count > 0)
                {
                    resDS.Response.AddResponseRow(SystemMessage.Generic_Success_Code, SystemMessage.Generic_Success_Msg);
                    foreach (AdministrationDS.ModuleInRoleRow row in inputDS.ModuleInRole)
                    {
                        row.RoleID = resDS.Role[0].RoleID;
                        da.InsertModuleInRole(row);
                    }
                }
                else
                {
                    resDS.Response.AddResponseRow(SystemMessage.Generic_Fail_Code, SystemMessage.Generic_Fail_Msg);
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region ProcessAdministrationLogin
        public AdministrationDS ProcessAdministrationLogin(AdministrationDS inputDS)
        {
            string statusID = SystemMessage.MA_LoginSuccess_INFO_CODE;
            string message = SystemMessage.MA_LoginSuccess_INFO_MSG;

            //Get admin detail
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA adminDA = new AdministrationDA();
                resDS = adminDA.GetAdminUserByLoginID(inputDS.AdminUser[0]); // Get admin detail by login id
                //Check if member exist
                if (resDS.AdminUser.Rows.Count == 0)
                {
                    statusID = SystemMessage.MA_InvalidLoginUser_ERROR_CODE;
                    message = SystemMessage.MA_InvalidLoginUser_ERROR_MSG;
                }
                else
                {
                    //Decrypt member password
                    string password = Decrypt(resDS.AdminUser[0].Password);
                    //Compare password
                    if (inputDS.AdminUser[0].Password != password)
                    {
                        statusID = SystemMessage.MA_IncorrectLoginPassword_ERROR_CODE;
                        message = SystemMessage.MA_IncorrectLoginPassword_ERROR_MSG;
                    }
                }

                resDS.Response.AddResponseRow(statusID, message);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateAdminUserDetail
        public AdministrationDS UpdateAdminUserDetail(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                inputDS.AdminUser[0].Password = Encrypt(inputDS.AdminUser[0].Password);
                resDS = da.UpdateAdminUserDetail(inputDS.AdminUser[0]);

                foreach (AdministrationDS.AdminUserInRoleRow row in inputDS.AdminUserInRole)
                {
                    if (!row.IsAdminUserInRoleIDNull())
                        da.UpdateAdminUserInRole(row);
                    else
                    {
                        da.InsertAdminUserInRole(row);
                    }
                }
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateModule
        public AdministrationDS UpdateModule(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.UpdateModule(inputDS.Module[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateRole
        public AdministrationDS UpdateRole(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.UpdateRole(inputDS.Role[0]);

                foreach (AdministrationDS.ModuleInRoleRow row in inputDS.ModuleInRole)
                {
                    da.UpdateModuleInRole(row);
                }

                resDS.Response.AddResponseRow(SystemMessage.Generic_Success_Code, SystemMessage.Generic_Success_Msg);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateAdminLoginSessionGUID
        public AdministrationDS UpdateAdminLoginSessionGUID(AdministrationDS inputDS)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                AdministrationDA da = new AdministrationDA();
                resDS = da.UpdateAdminLoginSessionGUID(inputDS.AdminUser[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion
    }
}
