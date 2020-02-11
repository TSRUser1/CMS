using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SEM.CMS.CL.MA.DS.AdministrationDataset;

namespace SEM.CMS.App.MA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdministration" in both code and config file together.
    [ServiceContract]
    public interface IAdministration
    {
        [OperationContract]
        AdministrationDS DeleteAdminUserDetail(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS DeleteModule(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS DeleteRole(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS GetAdminUser(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS GetAdminUserByLoginID(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS GetAdminLoginSession(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS GetModule(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS GetPageName();

        [OperationContract]
        AdministrationDS GetFunctionName();

        [OperationContract]
        AdministrationDS GetRole(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS InsertAdminUserDetail(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS InsertModule(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS InsertRole(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS ProcessAdministrationLogin(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS UpdateAdminUserDetail(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS UpdateModule(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS UpdateRole(AdministrationDS inputDS);

        [OperationContract]
        AdministrationDS UpdateAdminLoginSessionGUID(AdministrationDS inputDS);
    }
}
