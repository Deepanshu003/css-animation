using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class CustomerData
    {
        public CustomerData()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _customerID = 0;
        private string _customerName = string.Empty;
        private string _customerMobileNo = string.Empty;
        private string _customerEmailID = string.Empty;
        private string _customerPassword = string.Empty;
        private string _customerNewPassword = string.Empty;
        private string _CustomerGender = string.Empty;
        private string _customerDP = string.Empty;
        private string _billingAddress = string.Empty;
        private string _CustomerGSTNo = string.Empty;
        private string _fBID = string.Empty;
        private string _twitterID = string.Empty;
        private int _activeStatus = 0;
        private DateTime _registrationDate = DateTime.UtcNow;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _customerSearchKeywords = string.Empty;
        private string _CustomerCompanyName = string.Empty;

        public string CustomerCompanyName
        {
            get { return _CustomerCompanyName; }
            set { _CustomerCompanyName = value; }
        }

        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        public string CustomerMobileNo
        {
            get { return _customerMobileNo; }
            set { _customerMobileNo = value; }
        }
        public string CustomerEmailID
        {
            get { return _customerEmailID; }
            set { _customerEmailID = value; }
        }
        public string CustomerPassword
        {
            get { return _customerPassword; }
            set { _customerPassword = value; }
        }
        public string CustomerNewPassword
        {
            get { return _customerNewPassword; }
            set { _customerNewPassword = value; }
        }
        public string CustomerDP
        {
            get { return _customerDP; }
            set { _customerDP = value; }
        }
        public string CustomerGSTNo
        {
            get { return _CustomerGSTNo; }
            set { _CustomerGSTNo = value; }
        }
        public string CustomerGender
        {
            get { return _CustomerGender; }
            set { _CustomerGender = value; }
        }
        public string BillingAddress
        {
            get { return _billingAddress; }
            set { _billingAddress = value; }
        }
        public string FBID
        {
            get { return _fBID; }
            set { _fBID = value; }
        }
        public string TwitterID
        {
            get { return _twitterID; }
            set { _twitterID = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
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
        public string CustomerSearchKeywords
        {
            get { return _customerSearchKeywords; }
            set { _customerSearchKeywords = value; }
        }
        private string _GoogleID = string.Empty;

        public string GoogleID
        {
            get { return _GoogleID; }
            set { _GoogleID = value; }
        }
        private string _StateName = string.Empty;

        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }
        private string _CityName = string.Empty;

        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        private string _LocationName = string.Empty;

        public string LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }

        #region Admin Panel
        public void SelectAllCustomerData(System.Web.UI.WebControls.GridView GvCustomer)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCustomerData");           
                _SqlParameter[1] = new SqlParameter("@CustomerSearchKeywords", CustomerSearchKeywords);
                ObjSql.GdBind_SNO(GvCustomer, "Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in Procedure SelectAllLocation()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        public void BindDdCustomerData(System.Web.UI.WebControls.DropDownList DdCustomer, string CustomerName, string CustomerID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCustomerDataForDD");           
                ObjSql.DdBing(DdCustomer, "Mst_Sp_CustomerData", "CustomerName", "CustomerID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdCustomerData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        public int UpdateCustomerDataByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[15];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCustomerDataByID");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                _SqlParameter[2] = new SqlParameter("@CustomerName", CustomerName);
                _SqlParameter[3] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[4] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                _SqlParameter[5] = new SqlParameter("@CustomerGender", CustomerGender);
                _SqlParameter[6] = new SqlParameter("@StateName", StateName);
                _SqlParameter[7] = new SqlParameter("@CityName", CityName);
                _SqlParameter[8] = new SqlParameter("@LocationName", LocationName);
                _SqlParameter[9] = new SqlParameter("@BillingAddress", BillingAddress);
                _SqlParameter[10] = new SqlParameter("@CustomerCompanyName", CustomerCompanyName);
                _SqlParameter[11] = new SqlParameter("@CustomerGSTNo", CustomerGSTNo);
                _SqlParameter[12] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[13] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[14] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in Procedure UpdateLocation()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
        }
        public int DeleteCustomerByCustomerID()
        {
            SqlParameter[] _sqlParameter = new SqlParameter[1];
            try
            {
                _sqlParameter[0] = new SqlParameter("@Action", "DeleteCustomerByCustomerID");              
                _sqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _sqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in Procedure DeleteCustomerByCustomerID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _sqlParameter);
        }
        public SqlDataReader SelectCustomerByCustomerID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCustomerByCustomerID");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCustomerByCustomerID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
        }
        public void SelectTop5SelectAllCustomerData(System.Web.UI.WebControls.GridView CustomerOrderGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop5SelectAllCustomerData");
                ObjSql.GdBind_SNO(CustomerOrderGrid, "Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop5SelectAllCustomerData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        #endregion Admin Panel

        #region Front End
        public int CheckUserLoginOrSignupWithMobileNoOrCustomerEmailID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "CheckUserLoginOrSignupWithMobileNoOrCustomerEmailID");
                _SqlParameter[1] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[2] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure CheckUserLoginOrSignupWithMobileNoOrCustomerEmailID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
        }
        public int UserSignupWithMobileNoOrCustomerEmailID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[6];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UserSignupWithMobileNoOrCustomerEmailID");
                _SqlParameter[1] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[2] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                _SqlParameter[3] = new SqlParameter("@CustomerName", CustomerName);
                _SqlParameter[4] = new SqlParameter("@CustomerPassword", CustomerPassword);
                _SqlParameter[5] = new SqlParameter("@FBID", FBID);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UserSignupWithMobileNoOrCustomerEmailID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
        }
        public SqlDataReader SelectCustomerDataByCustomerMobileNoOrCustomerEmailID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCustomerDataByCustomerMobileNoOrCustomerEmailID");
                _SqlParameter[1] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[2] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCustomerDataByCustomerMobileNoOrCustomerEmailID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
        }
        public int UpdateCustomerPersonalinformationByCustomerIDFromCustomerPanle()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[14];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCustomerPersonalinformationByCustomerIDFromCustomerPanle");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                _SqlParameter[2] = new SqlParameter("@CustomerName", CustomerName);
                _SqlParameter[3] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[4] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                _SqlParameter[5] = new SqlParameter("@CustomerGender", CustomerGender);
                _SqlParameter[6] = new SqlParameter("@StateName", StateName);
                _SqlParameter[7] = new SqlParameter("@CityName", CityName);
                _SqlParameter[8] = new SqlParameter("@LocationName", LocationName);
                _SqlParameter[9] = new SqlParameter("@BillingAddress", BillingAddress);
                _SqlParameter[10] = new SqlParameter("@CustomerCompanyName", CustomerCompanyName);
                _SqlParameter[11] = new SqlParameter("@CustomerGSTNo", CustomerGSTNo);
                _SqlParameter[12] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[13] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in Procedure UpdateCustomerPersonalinformationByCustomerIDFromCustomerPanle()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
        }
        public SqlDataReader SelectCustomerDataByCustomerIDOnlineOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCustomerDataByCustomerIDOnlineOrder");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCustomerDataByCustomerIDOnlineOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
        }
        public DataSet SelectTotalOrderistoryByCustomerID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTotalOrderistoryByCustomerID");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.GetDsetProc("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTotalOrderistoryByCustomerID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CustomerData", _SqlParameter);
        }

        public int UpdateCustomerPersonalinformationByCustomerIDFromOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[9];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCustomerPersonalinformationByCustomerIDFromOrder");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                _SqlParameter[2] = new SqlParameter("@CustomerName", CustomerName);
                _SqlParameter[3] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[4] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                _SqlParameter[5] = new SqlParameter("@CustomerCompanyName", CustomerCompanyName);
                _SqlParameter[6] = new SqlParameter("@CustomerGSTNo", CustomerGSTNo);
                _SqlParameter[7] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[8] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in Procedure UpdateCustomerPersonalinformationByCustomerIDFromOrder()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
        }
        #endregion

        #region FB Login and Google Login
        public SqlDataReader SelectCustomerByCustomerGoogleID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCustomerByCustomerGoogleID");
                _SqlParameter[1] = new SqlParameter("@GoogleID", GoogleID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCustomerByCustomerID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
        }
        public int SaveNewCustomerDataUsingGoogle()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewCustomerDataUsingGoogle");
                _SqlParameter[1] = new SqlParameter("@CustomerName", CustomerName);
                _SqlParameter[2] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[3] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                _SqlParameter[4] = new SqlParameter("@GoogleID", GoogleID);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewCustomerDataUsingFB()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
        }
        public SqlDataReader SelectCustomerByCustomerFBID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCustomerByCustomerFBID");
                _SqlParameter[1] = new SqlParameter("@FBID", FBID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCustomerByCustomerID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CustomerData", _SqlParameter);
        }
        public int SaveNewCustomerDataByFaceBook()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewCustomerDataByFaceBook");
                _SqlParameter[1] = new SqlParameter("@CustomerName", CustomerName);
                _SqlParameter[2] = new SqlParameter("@CustomerMobileNo", CustomerMobileNo);
                _SqlParameter[3] = new SqlParameter("@CustomerEmailID", CustomerEmailID);
                _SqlParameter[4] = new SqlParameter("@FBID", FBID);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewCustomerDataByFaceBook()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerData", _SqlParameter);
        }
        #endregion
    }
}

