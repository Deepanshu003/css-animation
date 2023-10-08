using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class EntertainmentBookData
    {
        public EntertainmentBookData()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _EntertainmentBookingID = 0;

        public int EntertainmentBookingID
        {
            get { return _EntertainmentBookingID; }
            set { _EntertainmentBookingID = value; }
        }
        private int _BookingOrderNo = 0;

        public int BookingOrderNo
        {
            get { return _BookingOrderNo; }
            set { _BookingOrderNo = value; }
        }
        private DateTime _BookingDate = DateTime.UtcNow;

        public DateTime BookingDate
        {
            get { return _BookingDate; }
            set { _BookingDate = value; }
        }
        private DateTime _DateOfVisit = DateTime.UtcNow;

        public DateTime DateOfVisit
        {
            get { return _DateOfVisit; }
            set { _DateOfVisit = value; }
        }
        private int _CustomerID = 0;

        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        private int _PackageID = 0;

        public int PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }
        private string _PackageTitle = string.Empty;

        public string PackageTitle
        {
            get { return _PackageTitle; }
            set { _PackageTitle = value; }
        }
        private string _PackageTitleURL = string.Empty;

        public string PackageTitleURL
        {
            get { return _PackageTitleURL; }
            set { _PackageTitleURL = value; }
        }
        private string _PackageTimming = string.Empty;

        public string PackageTimming
        {
            get { return _PackageTimming; }
            set { _PackageTimming = value; }
        }
        private string _PackagePunchline = string.Empty;

        public string PackagePunchline
        {
            get { return _PackagePunchline; }
            set { _PackagePunchline = value; }
        }
        private string _PackageKidsPunchline1 = string.Empty;

        public string PackageKidsPunchline1
        {
            get { return _PackageKidsPunchline1; }
            set { _PackageKidsPunchline1 = value; }
        }
        private string _PackageKidsPunchline2 = string.Empty;

        public string PackageKidsPunchline2
        {
            get { return _PackageKidsPunchline2; }
            set { _PackageKidsPunchline2 = value; }
        }
        private string _PackageAdultsPunchline1 = string.Empty;

        public string PackageAdultsPunchline1
        {
            get { return _PackageAdultsPunchline1; }
            set { _PackageAdultsPunchline1 = value; }
        }
        private int _KidsPrice = 0;

        public int KidsPrice
        {
            get { return _KidsPrice; }
            set { _KidsPrice = value; }
        }
        private int _AdultPrice = 0;

        public int AdultPrice
        {
            get { return _AdultPrice; }
            set { _AdultPrice = value; }
        }
        private int _TotalKids = 0;

        public int TotalKids
        {
            get { return _TotalKids; }
            set { _TotalKids = value; }
        }
        private int _TotalAdult = 0;

        public int TotalAdult
        {
            get { return _TotalAdult; }
            set { _TotalAdult = value; }
        }
        private int _TotalKidsPrice = 0;

        public int TotalKidsPrice
        {
            get { return _TotalKidsPrice; }
            set { _TotalKidsPrice = value; }
        }
        private int _TotalAdultPrice = 0;

        public int TotalAdultPrice
        {
            get { return _TotalAdultPrice; }
            set { _TotalAdultPrice = value; }
        }
        private string _CouponCode = string.Empty;

        public string CouponCode
        {
            get { return _CouponCode; }
            set { _CouponCode = value; }
        }
        private int _CouponValue = 0;

        public int CouponValue
        {
            get { return _CouponValue; }
            set { _CouponValue = value; }
        }
        private int _TotalTax = 0;

        public int TotalTax
        {
            get { return _TotalTax; }
            set { _TotalTax = value; }
        }
        private int _OrderTotalAmount = 0;

        public int OrderTotalAmount
        {
            get { return _OrderTotalAmount; }
            set { _OrderTotalAmount = value; }
        }
        private string _PaymentOption = string.Empty;

        public string PaymentOption
        {
            get { return _PaymentOption; }
            set { _PaymentOption = value; }
        }
        private string _PaymentID = string.Empty;

        public string PaymentID
        {
            get { return _PaymentID; }
            set { _PaymentID = value; }
        }
        private string _TransactionID = string.Empty;

        public string TransactionID
        {
            get { return _TransactionID; }
            set { _TransactionID = value; }
        }
        private string _TransactionStatus = string.Empty;

        public string TransactionStatus
        {
            get { return _TransactionStatus; }
            set { _TransactionStatus = value; }
        }
        private string _PaymentStatus = string.Empty;

        public string PaymentStatus
        {
            get { return _PaymentStatus; }
            set { _PaymentStatus = value; }
        }
        private string _BookingStatus = string.Empty;

        public string BookingStatus
        {
            get { return _BookingStatus; }
            set { _BookingStatus = value; }
        }
        private string _RemarksIfAny = string.Empty;

        public string RemarksIfAny
        {
            get { return _RemarksIfAny; }
            set { _RemarksIfAny = value; }
        }
        private string _UpdatedBy = string.Empty;

        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        private DateTime _UpdatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn
        {
            get { return _UpdatedOn; }
            set { _UpdatedOn = value; }
        }

        #region Admin Panle
        public DataSet SelectAllFunctionOrderDetails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[6];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllFunctionOrderDetails");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@CustomerID", CustomerID);
                _SqlParameter[3] = new SqlParameter("@BookingStatus", BookingStatus);
                _SqlParameter[4] = new SqlParameter("@PaymentStatus", PaymentStatus);
                _SqlParameter[5] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllFunctionOrderDetails()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public DataSet SelectAllActivityForAdminByEntertainmentBookingID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActivityForAdminByEntertainmentBookingID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentBookingID", EntertainmentBookingID);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActivityForAdminByEntertainmentBookingID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public void SelectCustomerForDD(System.Web.UI.WebControls.DropDownList DdCustomer, string CustomerName, string CustomerID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCustomerForDD");
                ObjSql.DdBing(DdCustomer, "Mst_Sp_EntertainmentBookData", "CustomerName", "CustomerID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCustomerForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public DataSet ExportintoExcelAllDataOFEntertainmentBooking()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "ExportintoExcelAllDataOFEntertainmentBooking");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@BookingStatus", BookingStatus);
                _SqlParameter[3] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.GetDsetProc1("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure ExportintoExcelAllDataOFEntertainmentBooking()", ex);
            }
            finally
            {
                _SqlParameter = (SqlParameter[])null;
                ObjSql = (Connect)null;
                ObjEx = (ManageException)null;
            }

            return ObjSql.GetDsetProc1("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public int UpdateBookingStatusByAdminByBookingOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateBookingStatusByAdminByBookingOrderNo");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@BookingStatus", BookingStatus);
                _SqlParameter[3] = new SqlParameter("@RemarksIfAny", RemarksIfAny);
                _SqlParameter[4] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateBookingStatusByAdminByBookingOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public int UpdatePaymentStatusByAdminByBookingOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePaymentStatusByAdminByBookingOrderNo");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@PaymentStatus", PaymentStatus);
                _SqlParameter[3] = new SqlParameter("@RemarksIfAny", RemarksIfAny);
                _SqlParameter[4] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdatePaymentStatusByAdminByBookingOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }
        #endregion

        #region Front End Panle
        public int SelectMaxBookingOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxBookingOrderNo");
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxBookingOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public int SaveNewPackageBookingByCustomerData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[23];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewPackageBookingByCustomerData");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@BookingDate", BookingDate);
                _SqlParameter[3] = new SqlParameter("@DateOfVisit", DateOfVisit);
                _SqlParameter[4] = new SqlParameter("@CustomerID", CustomerID);
                _SqlParameter[5] = new SqlParameter("@PackageID", PackageID);
                _SqlParameter[6] = new SqlParameter("@PackageTitle", PackageTitle);
                _SqlParameter[7] = new SqlParameter("@PackageTitleURL", PackageTitleURL);
                _SqlParameter[8] = new SqlParameter("@PackageTimming", PackageTimming);
                _SqlParameter[9] = new SqlParameter("@PackagePunchline", PackagePunchline);
                _SqlParameter[10] = new SqlParameter("@PackageKidsPunchline1", PackageKidsPunchline1);
                _SqlParameter[11] = new SqlParameter("@PackageKidsPunchline2", PackageKidsPunchline2);
                _SqlParameter[12] = new SqlParameter("@PackageAdultsPunchline1", PackageAdultsPunchline1);
                _SqlParameter[13] = new SqlParameter("@KidsPrice", KidsPrice);
                _SqlParameter[14] = new SqlParameter("@AdultPrice", AdultPrice);
                _SqlParameter[15] = new SqlParameter("@TotalKids", TotalKids);
                _SqlParameter[16] = new SqlParameter("@TotalAdult", TotalAdult);
                _SqlParameter[17] = new SqlParameter("@TotalKidsPrice", TotalKidsPrice);
                _SqlParameter[18] = new SqlParameter("@TotalAdultPrice", TotalAdultPrice);
                _SqlParameter[19] = new SqlParameter("@CouponCode", CouponCode);
                _SqlParameter[20] = new SqlParameter("@CouponValue", CouponValue);
                _SqlParameter[21] = new SqlParameter("@TotalTax", TotalTax);
                _SqlParameter[22] = new SqlParameter("@OrderTotalAmount", OrderTotalAmount);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewPackageBookingByCustomerData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public int UpdateFunctionBookingOnlinePaymentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateFunctionBookingOnlinePaymentID");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@PaymentID", PaymentID);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateFunctionBookingOnlinePaymentID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public int UpdateFunctionBookingOnlinePaymentStatus()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[6];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateFunctionBookingOnlinePaymentStatus");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@PaymentID", PaymentID);
                _SqlParameter[3] = new SqlParameter("@TransactionID", TransactionID);
                _SqlParameter[4] = new SqlParameter("@TransactionStatus", TransactionStatus);
                _SqlParameter[5] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateFunctionBookingOnlinePaymentStatus()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public DataSet SelectAllEntertainmentOrderDetailsByCustomerIDForDashboard()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEntertainmentOrderDetailsByCustomerIDForDashboard");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEntertainmentOrderDetailsByCustomerIDForDashboard()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public DataSet SelectEntertainmentOrderDetailsByBookingOrderNoForMail()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentOrderDetailsByBookingOrderNoForMail");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentOrderDetailsByBookingOrderNoForMail()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }

        public SqlDataReader SelectFunctionOrderDetailsByBookingOrderNoForPaymnets()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectFunctionOrderDetailsByBookingOrderNoForPaymnets");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectFunctionOrderDetailsByBookingOrderNoForPaymnets()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }
        #endregion
    }
}
