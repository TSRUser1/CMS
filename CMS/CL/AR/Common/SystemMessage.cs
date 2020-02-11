using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM.CMS.CL.AR.Common
{
    public class SystemMessage
    {
        #region System code
        public const string Generic_Fail_Code = "99999";
        public const string Generic_Success_Code = "10000";
        public const string User_Exist_Code = "10001";
        public const string Generic_Failed_Code = "10002";
        public const string Generic_Record_Not_Found_Code = "10003";
        #endregion

        #region System message 
        public const string Generic_Fail_Msg = "Fail.";
        public const string Generic_Success_Msg = "Successful.";
        public const string User_Exist_Msg = "User already exist.";
        public const string Generic_Failed_Msg = "Failed.";
        public const string Generic_Record_Not_Found_Msg = "Record Not Found.";
        #endregion

        #region Admin login 20000
        public const string MA_LoginSuccess_INFO_CODE = "20000";
        public const string MA_InvalidLoginUser_ERROR_CODE = "20002";
        public const string MA_IncorrectLoginPassword_ERROR_CODE = "20003";

        public const string MA_LoginSuccess_INFO_MSG = "Login successful.";
        public const string MA_InvalidLoginUser_ERROR_MSG = "Administrator not found.";
        public const string MA_IncorrectLoginPassword_ERROR_MSG = "Incorrect password.";
        #endregion
    }
}
