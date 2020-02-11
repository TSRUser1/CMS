using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MA.BF.AdministrationFacade;
using SEM.CMS.CL.MA.DS.AdministrationDataset;

namespace SEM.CMS.App.MA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Administration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Administration.svc or Administration.svc.cs at the Solution Explorer and start debugging.
    public class Administration : IAdministration
    {
        public AdministrationDS DeleteAdminUserDetail(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.DeleteAdminUserDetail(inputDS);
        }

        public AdministrationDS DeleteModule(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.DeleteModule(inputDS);
        }

        public AdministrationDS DeleteRole(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.DeleteRole(inputDS);
        }

        public AdministrationDS GetAdminUser(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.GetAdminUser(inputDS);
        }

        public AdministrationDS GetAdminUserByLoginID(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.GetAdminUserByLoginID(inputDS);
        }

        public AdministrationDS GetAdminLoginSession(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.GetAdminLoginSession(inputDS);
        }

        public AdministrationDS GetModule(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.GetModule(inputDS);
        }

        public AdministrationDS GetFunctionName()
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.GetFunctionName();
        }

        public AdministrationDS GetPageName()
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.GetPageName();
        }

        public AdministrationDS GetRole(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.GetRole(inputDS);
        }

        public AdministrationDS InsertAdminUserDetail(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.InsertAdminUserDetail(inputDS);
        }

        public AdministrationDS InsertModule(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.InsertModule(inputDS);
        }

        public AdministrationDS InsertRole(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.InsertRole(inputDS);
        }

        public AdministrationDS ProcessAdministrationLogin(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.ProcessAdministrationLogin(inputDS);
        }

        public AdministrationDS UpdateAdminUserDetail(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.UpdateAdminUserDetail(inputDS);
        }

        public AdministrationDS UpdateModule(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.UpdateModule(inputDS);
        }

        public AdministrationDS UpdateRole(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.UpdateRole(inputDS);
        }

        public AdministrationDS UpdateAdminLoginSessionGUID(AdministrationDS inputDS)
        {
            AppBase.WCFAuthentication();
            AdministrationBF bf = new AdministrationBF();
            return bf.UpdateAdminLoginSessionGUID(inputDS);
        }

    }
}
