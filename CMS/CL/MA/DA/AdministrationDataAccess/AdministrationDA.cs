using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Data;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MA.DS.AdministrationDataset;

namespace SEM.CMS.CL.MA.DA.AdministrationDataAccess
{
    public class AdministrationDA : AppBase
    {
        #region DeleteAdminUserDetail
        public AdministrationDS DeleteAdminUserDetail(AdministrationDS.AdminUserRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteAdminUserDetail");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteModule
        public AdministrationDS DeleteModule(AdministrationDS.ModuleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteModule");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ModuleID", DbType.Int32, inputRow.ModuleID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region DeleteRole
        public AdministrationDS DeleteRole(AdministrationDS.RoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteRole");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, inputRow.RoleID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAdminUser
        public AdministrationDS GetAdminUser(AdministrationDS.AdminUserRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                string[] tableArray = new string[] { resDS.AdminUser.TableName,
                                                        resDS.AdminUserInRole.TableName };

                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetAdminUser");

                #region Parameters Initialization
                if (inputRow.IsAdminUserIDNull())
                {
                    db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                }
                if (inputRow.IsLoginIDNull())
                {
                    db.AddInParameter(dbCommand, "s_LoginID", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_LoginID", DbType.String, inputRow.LoginID);
                }
                #endregion

                AdministrationDS ds = new AdministrationDS();
                db.LoadDataSet(dbCommand, resDS, tableArray);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAdminUserByLoginID
        public AdministrationDS GetAdminUserByLoginID(AdministrationDS.AdminUserRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                string[] tableArray = new string[] { resDS.AdminUser.TableName,
                                                        resDS.Module.TableName };

                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetAdminUserByLoginID");

                #region Parameters Initialization
                if (inputRow.IsLoginIDNull())
                {
                    db.AddInParameter(dbCommand, "s_LoginID", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_LoginID", DbType.String, inputRow.LoginID);
                }
                #endregion

                AdministrationDS ds = new AdministrationDS();
                db.LoadDataSet(dbCommand, resDS, tableArray);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAdminLoginSession
        public AdministrationDS GetAdminLoginSession(AdministrationDS.AdminUserRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetAdminLoginSession");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetModule
        public AdministrationDS GetModule(AdministrationDS.ModuleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetModule");

                #region Parameters Initialization
                if (inputRow.IsModuleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ModuleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ModuleID", DbType.Int32, inputRow.ModuleID);
                }
                if (inputRow.IsPageNameNull())
                {
                    db.AddInParameter(dbCommand, "s_PageName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_PageName", DbType.String, inputRow.PageName);
                }
                if (inputRow.IsFunctionNameNull())
                {
                    db.AddInParameter(dbCommand, "s_FunctionName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_FunctionName", DbType.String, inputRow.FunctionName);
                }
                #endregion

                AdministrationDS ds = new AdministrationDS();
                db.LoadDataSet(dbCommand, resDS, resDS.Module.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetPageName");

                #region Parameters Initialization
                #endregion

                AdministrationDS ds = new AdministrationDS();
                db.LoadDataSet(dbCommand, resDS, resDS.Module.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetFunctionName");

                #region Parameters Initialization
                #endregion

                AdministrationDS ds = new AdministrationDS();
                db.LoadDataSet(dbCommand, resDS, resDS.Module.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetRole
        public AdministrationDS GetRole(AdministrationDS.RoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                string[] tableArray = new string[] { resDS.Role.TableName,
                                                        resDS.Module.TableName };

                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetRole");

                #region Parameters Initialization
                if (inputRow.IsRoleIDNull())
                {
                    db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, inputRow.RoleID);
                }
                #endregion

                AdministrationDS ds = new AdministrationDS();
                db.LoadDataSet(dbCommand, resDS, tableArray);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertAdminUserDetail
        public AdministrationDS InsertAdminUserDetail(AdministrationDS.AdminUserRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertAdminUserDetail");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_Password", DbType.String, inputRow.Password);
                db.AddInParameter(dbCommand, "s_LoginID", DbType.String, inputRow.LoginID);
                db.AddInParameter(dbCommand, "s_FullName", DbType.String, inputRow.FullName);
                db.AddInParameter(dbCommand, "s_Designation", DbType.String, inputRow.Designation);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertAdminUserInRole
        public AdministrationDS InsertAdminUserInRole(AdministrationDS.AdminUserInRoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertAdminUserInRole");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, inputRow.RoleID);
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Boolean, inputRow.IsActive);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUserInRole.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertModule
        public AdministrationDS InsertModule(AdministrationDS.ModuleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertModule");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_ModuleName", DbType.String, inputRow.ModuleName);
                db.AddInParameter(dbCommand, "s_PageName", DbType.String, inputRow.PageName);
                db.AddInParameter(dbCommand, "s_FunctionName", DbType.String, inputRow.FunctionName);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Module.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertModuleInRole
        public AdministrationDS InsertModuleInRole(AdministrationDS.ModuleInRoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertModuleInRole");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ModuleID", DbType.Int32, inputRow.ModuleID);
                db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, inputRow.RoleID);
                db.AddInParameter(dbCommand, "b_IsReadOnly", DbType.Boolean, inputRow.IsReadOnly);
                db.AddInParameter(dbCommand, "b_IsReadWrite", DbType.Boolean, inputRow.IsReadWrite);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ModuleInRole.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertRole
        public AdministrationDS InsertRole(AdministrationDS.RoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertRole");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_RoleName", DbType.String, inputRow.RoleName);
                db.AddInParameter(dbCommand, "s_RoleDescription", DbType.String, inputRow.RoleDescription);
                db.AddInParameter(dbCommand, "n_CreatedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_CreatedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Role.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateAdminUserDetail
        public AdministrationDS UpdateAdminUserDetail(AdministrationDS.AdminUserRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateAdminUserDetail");

                #region Parameters Initialization
                if(inputRow.IsPasswordNull())
                {
                    db.AddInParameter(dbCommand, "s_Password", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_Password", DbType.String, inputRow.Password);
                }
                db.AddInParameter(dbCommand, "s_Fullname", DbType.String, inputRow.FullName);
                db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                db.AddInParameter(dbCommand, "s_Designation", DbType.String, inputRow.Designation);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime() );
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateAdminUserInRole
        public AdministrationDS UpdateAdminUserInRole(AdministrationDS.AdminUserInRoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateAdminUserInRole");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, inputRow.RoleID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "n_IsActive", DbType.Int32, inputRow.IsActive);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUserInRole.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateModule
        public AdministrationDS UpdateModule(AdministrationDS.ModuleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateModule");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ModuleID", DbType.Int32, inputRow.ModuleID);
                db.AddInParameter(dbCommand, "s_ModuleName", DbType.String, inputRow.ModuleName);
                db.AddInParameter(dbCommand, "s_PageName", DbType.String, inputRow.PageName);
                db.AddInParameter(dbCommand, "s_FunctionName", DbType.String, inputRow.FunctionName);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Module.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateModuleInRole
        public AdministrationDS UpdateModuleInRole(AdministrationDS.ModuleInRoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateModuleInRole");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ModuleID", DbType.Int32, inputRow.ModuleID);
                db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, inputRow.RoleID);
                db.AddInParameter(dbCommand, "b_IsReadOnly", DbType.Boolean, inputRow.IsReadOnly);
                db.AddInParameter(dbCommand, "b_IsReadWrite", DbType.Boolean, inputRow.IsReadWrite);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ModuleInRole.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateRole
        public AdministrationDS UpdateRole(AdministrationDS.RoleRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateRole");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_RoleID", DbType.Int32, inputRow.RoleID);
                db.AddInParameter(dbCommand, "s_RoleName", DbType.String, inputRow.RoleName);
                db.AddInParameter(dbCommand, "s_RoleDescription", DbType.String, inputRow.RoleDescription);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Role.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateAdminLoginSessionGUID
        public AdministrationDS UpdateAdminLoginSessionGUID(AdministrationDS.AdminUserRow inputRow)
        {
            AdministrationDS resDS = new AdministrationDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateAdminLoginSessionGUID");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                db.AddInParameter(dbCommand, "s_LoginSessionGUID", DbType.String, inputRow.LoginSessionGUID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, DateTime.UtcNow.AddHours(8));
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
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
