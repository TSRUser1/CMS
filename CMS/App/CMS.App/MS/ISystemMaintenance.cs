using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SEM.CMS.CL.MS.DS.SystemMaintenanceDataset;

namespace SEM.CMS.App.MS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISystemMaintenance" in both code and config file together.
    [ServiceContract]
    public interface ISystemMaintenance
    {
        [OperationContract]
        SystemMaintenanceDS DeleteDataGridColumn(SystemMaintenanceDS inputDS);

        [OperationContract]
        SystemMaintenanceDS GetDataColumnByDataGridName(string DataGridName);

        [OperationContract]
        SystemMaintenanceDS GetDataColumnList(string DataGridName);

        [OperationContract]
        SystemMaintenanceDS GetDataColumnName();

        [OperationContract]
        SystemMaintenanceDS GetReferenceByReferenceCategoryID(SystemMaintenanceDS inputDS);

        [OperationContract]
        SystemMaintenanceDS InsertDataGridColumn(SystemMaintenanceDS inputDS);

        [OperationContract]
        SystemMaintenanceDS UpdateDataGridColumn(SystemMaintenanceDS inputDS);
    }
}
