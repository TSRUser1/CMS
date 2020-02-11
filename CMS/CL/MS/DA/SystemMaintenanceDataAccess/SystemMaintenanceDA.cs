using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Data;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MS.DS.SystemMaintenanceDataset;

namespace SEM.CMS.CL.MS.DA.SystemMaintenanceDataAccess
{
    public class SystemMaintenanceDA : AppBase
    {
        #region DeleteDataGridColumn
        public SystemMaintenanceDS DeleteDataGridColumn(SystemMaintenanceDS.DataGridColumnRow inputRow)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_D_DeleteDataGridColumn");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_DataGridColumnID", DbType.Int32, inputRow.DataGridColumnID);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.DataGridColumn.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetDataColumnByDataGridName
        public SystemMaintenanceDS GetDataColumnByDataGridName(string DataGridName)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetDataColumnByDataGridName");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_DataGridName", DbType.String, DataGridName);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.DataGridColumn.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetDataColumnList
        public SystemMaintenanceDS GetDataColumnList(string DataGridName)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetDataColumnList");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_DataGridName", DbType.String, DataGridName);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.DataGridColumn.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetDataColumnName
        public SystemMaintenanceDS GetDataColumnName()
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetDataColumnName");

                #region Parameters Initialization
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.DataGridColumn.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetReferenceByReferenceCategoryID
        public SystemMaintenanceDS GetReferenceByReferenceCategoryID(SystemMaintenanceDS.ReferenceRow inputRow)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetReferenceByReferenceCategoryID");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_ReferenceCategoryID", DbType.Int32, inputRow.ReferenceCategoryID);
                if (inputRow.IsLanguageIDNull())
                {
                    db.AddInParameter(dbCommand, "n_LanguageID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_LanguageID", DbType.Int32, inputRow.LanguageID);
                }
                if (inputRow.IsReferenceInternalIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ReferenceInternalID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ReferenceInternalID", DbType.Int32, inputRow.ReferenceInternalID);
                }
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Reference.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertDataGridColumn
        public SystemMaintenanceDS InsertDataGridColumn(SystemMaintenanceDS.DataGridColumnRow inputRow)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_I_InsertDataGridColumn");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "s_DataGridName", DbType.String, inputRow.DataGridName);
                db.AddInParameter(dbCommand, "s_HeaderText", DbType.String, inputRow.HeaderText);
                db.AddInParameter(dbCommand, "s_DataField", DbType.String, inputRow.DataField);
                db.AddInParameter(dbCommand, "n_SortID", DbType.Int32, inputRow.SortID);
                db.AddInParameter(dbCommand, "n_ColumnTypeID", DbType.Int32, inputRow.ColumnTypeID);
                if (inputRow.IsEnumTypeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EnumTypeID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EnumTypeID", DbType.Int32, inputRow.EnumTypeID);
                }
                db.AddInParameter(dbCommand, "s_NavigateURL", DbType.String, inputRow.NavigateURL);
                db.AddInParameter(dbCommand, "s_NavigateURLDataField", DbType.String, inputRow.NavigateURLDataField);
                db.AddInParameter(dbCommand, "n_ColumnWidth", DbType.Int32, inputRow.ColumnWidth);
                db.AddInParameter(dbCommand, "s_CssClass", DbType.String, inputRow.CssClass);
                db.AddInParameter(dbCommand, "b_IsReadOnly", DbType.Boolean, inputRow.IsReadOnly);
                db.AddInParameter(dbCommand, "b_IsAllowHTMLEncode", DbType.Boolean, inputRow.IsAllowHTMLEncode);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ReferenceCategory.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateDataGridColumn
        public SystemMaintenanceDS UpdateDataGridColumn(SystemMaintenanceDS.DataGridColumnRow inputRow)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateDataGridColumn");

                #region Parameters Initialization
                if (inputRow.IsDataGridColumnIDNull())
                {
                    db.AddInParameter(dbCommand, "n_DataGridColumnID", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_DataGridColumnID", DbType.String, inputRow.DataGridColumnID);
                }
                if (inputRow.IsDataGridNameNull())
                {
                    db.AddInParameter(dbCommand, "s_DataGridName", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_DataGridName", DbType.String, inputRow.DataGridName);
                }
                if (inputRow.IsHeaderTextNull())
                {
                    db.AddInParameter(dbCommand, "s_HeaderText", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_HeaderText", DbType.String, inputRow.HeaderText);
                }
                if (inputRow.IsDataFieldNull())
                {
                    db.AddInParameter(dbCommand, "s_DataField", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_DataField", DbType.String, inputRow.DataField);
                }
                if (inputRow.IsSortIDNull())
                {
                    db.AddInParameter(dbCommand, "n_SortID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_SortID", DbType.Int32, inputRow.SortID);
                }
                if (inputRow.IsColumnTypeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_ColumnTypeID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ColumnTypeID", DbType.Int32, inputRow.ColumnTypeID);
                }
                if (inputRow.IsEnumTypeIDNull())
                {
                    db.AddInParameter(dbCommand, "n_EnumTypeID", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_EnumTypeID", DbType.Int32, inputRow.EnumTypeID);
                }
                if (inputRow.IsNavigateURLNull())
                {
                    db.AddInParameter(dbCommand, "s_NavigateURL", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_NavigateURL", DbType.String, inputRow.NavigateURL);
                }
                if (inputRow.IsNavigateURLDataFieldNull())
                {
                    db.AddInParameter(dbCommand, "s_NavigateURLDataField", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_NavigateURLDataField", DbType.String, inputRow.NavigateURLDataField);
                }
                if (inputRow.IsColumnWidthNull())
                {
                    db.AddInParameter(dbCommand, "n_ColumnWidth", DbType.Int32, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "n_ColumnWidth", DbType.Int32, inputRow.ColumnWidth);
                }
                if (inputRow.IsCssClassNull())
                {
                    db.AddInParameter(dbCommand, "s_CssClass", DbType.String, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "s_CssClass", DbType.String, inputRow.CssClass);
                }
                if (inputRow.IsIsReadOnlyNull())
                {
                    db.AddInParameter(dbCommand, "b_IsReadOnly", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsReadOnly", DbType.Boolean, inputRow.IsReadOnly);
                }
                if (inputRow.IsIsAllowHTMLEncodeNull())
                {
                    db.AddInParameter(dbCommand, "b_IsAllowHTMLEncode", DbType.Boolean, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommand, "b_IsAllowHTMLEncode", DbType.Boolean, inputRow.IsAllowHTMLEncode);
                }
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, inputRow.ModifiedBy);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.DataGridColumn.TableName);
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
