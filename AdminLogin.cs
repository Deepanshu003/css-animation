using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utility;
using System.Data.SqlClient;

namespace Component
{
    public class AdminLogin
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public AdminLogin()
        {
        }

        int _userID = 0;
        string _userName = string.Empty;
        string _passwords = string.Empty;
        string _oldPassword = string.Empty;
        string _newPasswords = string.Empty;
        int _activeStatus = 0;
        DateTime _registerDate = DateTime.UtcNow;
        DateTime _lastLoginDate = DateTime.UtcNow;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Passwords
        {
            get { return _passwords; }
            set { _passwords = value; }
        }
        public string OldPassword
        {
            get { return _oldPassword; }
            set { _oldPassword = value; }
        }
        public string NewPasswords
        {
            get { return _newPasswords; }
            set { _newPasswords = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }
        public DateTime LastLoginDate
        {
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }


        //*******************Check Admin User login ************************//

        public DataSet CheckAdminLogin()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "CheckAdminUser");
                _SqlParameter[1] = new SqlParameter("@UserName", UserName);
                _SqlParameter[2] = new SqlParameter("@Passwords", Passwords);

                return ObjSql.GetDsetProc("Mst_Sp_AdminLogin", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure CheckUserLogin()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_AdminLogin", _SqlParameter);
        }

        public DataSet admindashboardreport()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "admindashboardreport");
                return ObjSql.GetDsetProc("Mst_Sp_AdminLogin", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure admindashboardreport()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_AdminLogin", _SqlParameter);
        }

        //*******************Change Admin Password ************************//
        public int ChangeAdminPassword()
        {
            SqlParameter[] arrProcPram = new SqlParameter[4];
            try
            {
                arrProcPram[0] = new SqlParameter("@Action", "ChangeAdminPassword");
                arrProcPram[1] = new SqlParameter("@OldPassword", OldPassword);
                arrProcPram[2] = new SqlParameter("@NewPassword", NewPasswords);
                arrProcPram[3] = new SqlParameter("@UserName", UserName);
                return ObjSql.ExcuteProce("Mst_Sp_AdminLogin", arrProcPram);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure ChangeCustomerPassword()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_AdminLogin", arrProcPram);
        }
    }
}
