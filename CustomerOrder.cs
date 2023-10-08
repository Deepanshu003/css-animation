using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class CustomerOrder
    {
        public CustomerOrder()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _CustomerOrderListID = 0;

        public int CustomerOrderListID
        {
            get { return _CustomerOrderListID; }
            set { _CustomerOrderListID = value; }
        }
        private int _OrderNo = 0;

        public int OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value; }
        }
        private DateTime _OrderDate = DateTime.UtcNow;

        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
        private int _CustomerID = 0;

        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        private int _RoomID = 0;

        public int RoomID
        {
            get { return _RoomID; }
            set { _RoomID = value; }
        }
        private string _RoomName = string.Empty;

        public string RoomName
        {
            get { return _RoomName; }
            set { _RoomName = value; }
        }
        private string _RoomImage = string.Empty;

        public string RoomImage
        {
            get { return _RoomImage; }
            set { _RoomImage = value; }
        }
        private DateTime _CheckInDate = DateTime.UtcNow;

        public DateTime CheckInDate
        {
            get { return _CheckInDate; }
            set { _CheckInDate = value; }
        }
        private DateTime _CheckOutDate = DateTime.UtcNow;

        public DateTime CheckOutDate
        {
            get { return _CheckOutDate; }
            set { _CheckOutDate = value; }
        }
        private int _TotalRooms = 0;

        public int TotalRooms
        {
            get { return _TotalRooms; }
            set { _TotalRooms = value; }
        }
        private int _TotalGuests = 0;

        public int TotalGuests
        {
            get { return _TotalGuests; }
            set { _TotalGuests = value; }
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
        private string _BookingStatus = string.Empty;

        public string BookingStatus
        {
            get { return _BookingStatus; }
            set { _BookingStatus = value; }
        }
        private string _PaymentStatus = string.Empty;

        public string PaymentStatus
        {
            get { return _PaymentStatus; }
            set { _PaymentStatus = value; }
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
        private string _PaymentStatusRemarks = string.Empty;

        public string PaymentStatusRemarks
        {
            get { return _PaymentStatusRemarks; }
            set { _PaymentStatusRemarks = value; }
        }
        private int _TotalTax = 0;

        public int TotalTax
        {
            get { return _TotalTax; }
            set { _TotalTax = value; }
        }
        #region Admin Panle
        public DataSet SelectAllRoomBookingOrderDetails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllRoomBookingOrderDetails");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                _SqlParameter[2] = new SqlParameter("@CustomerID", CustomerID);
                _SqlParameter[3] = new SqlParameter("@BookingStatus", BookingStatus);
                _SqlParameter[4] = new SqlParameter("@PaymentStatus", PaymentStatus);
                return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllRoomBookingOrderDetails()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public void SelectAllOrderHistoryByCustomerOrderHistoryID(System.Web.UI.WebControls.GridView GvBanquetdataGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllOrderHistoryByCustomerOrderHistoryID");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                ObjSql.GdBind_SNO(GvBanquetdataGrid, "Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllOrderHistoryByCustomerOrderHistoryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectOrderDetailsByOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectOrderDetailsByOrderNo");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                return ObjSql.GetDatareaderProc("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectOrderDetailsByOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public void SelectCustomerForDD(System.Web.UI.WebControls.DropDownList DdCustomer, string CustomerName, string CustomerID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCustomerForDD");
                ObjSql.DdBing(DdCustomer, "Mst_Sp_CustomerOrder", "CustomerName", "CustomerID", _SqlParameter);

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

        public DataSet ExportintoExcelAllDataOFRoomBooking()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "ExportintoExcelAllDataOFRoomBooking");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                _SqlParameter[2] = new SqlParameter("@BookingStatus", BookingStatus);
                _SqlParameter[3] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.GetDsetProc1("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure ExportintoExcelAllDataOFRoomBooking()", ex);
            }
            finally
            {
                _SqlParameter = (SqlParameter[])null;
                ObjSql = (Connect)null;
                ObjEx = (ManageException)null;
            }

            return ObjSql.GetDsetProc1("Mst_Sp_EventBookData", _SqlParameter);
        }

        public DataSet SelectAllTodayRoomBookingOrderDetails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllTodayRoomBookingOrderDetails");
                return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllTodayRoomBookingOrderDetails()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public int UpdateBookingStatusByAdminByOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateBookingStatusByAdminByOrderNo");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                _SqlParameter[2] = new SqlParameter("@BookingStatus", BookingStatus);
                _SqlParameter[3] = new SqlParameter("@RemarksIfAny", RemarksIfAny);
                _SqlParameter[4] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateBookingStatusByAdminByOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public int UpdatePaymentStatusByAdminByOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePaymentStatusByAdminByOrderNo");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                _SqlParameter[2] = new SqlParameter("@PaymentStatus", PaymentStatus);
                _SqlParameter[3] = new SqlParameter("@PaymentStatusRemarks", PaymentStatusRemarks);
                _SqlParameter[4] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdatePaymentStatusByAdminByOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public DataSet SelectTotalSummryOfOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTotalSummryOfOrder");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTotalSummryOfOrder()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
        }
        #endregion

        #region Front End Panle
        public int SelectMaxOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxOrderNo");
                return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public int SaveNewRoomBookingByCustomerData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewRoomBookingByCustomerData");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                _SqlParameter[2] = new SqlParameter("@OrderDate", OrderDate);
                _SqlParameter[3] = new SqlParameter("@CustomerID", CustomerID);
                _SqlParameter[4] = new SqlParameter("@CouponCode", CouponCode);
                _SqlParameter[5] = new SqlParameter("@CouponValue", CouponValue);
                _SqlParameter[6] = new SqlParameter("@OrderTotalAmount", OrderTotalAmount);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewRoomBookingByCustomerData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public int UpdateRoomBookingOnlinePaymentStatus()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[6];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateRoomBookingOnlinePaymentStatus");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                _SqlParameter[2] = new SqlParameter("@PaymentID", PaymentID);
                _SqlParameter[3] = new SqlParameter("@TransactionID", TransactionID);
                _SqlParameter[4] = new SqlParameter("@TransactionStatus", TransactionStatus);
                _SqlParameter[5] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateRoomBookingOnlinePaymentStatus()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public DataSet SelectAllRoomBookingByCustomerIDFroFrontEnd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllRoomBookingByCustomerIDFroFrontEnd");
                _SqlParameter[1] = new SqlParameter("@CustomerID", CustomerID);
                return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllRoomBookingByCustomerIDFroFrontEnd()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public DataSet SelectRoomOrderDetailsByOrderNoForMail()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomOrderDetailsByOrderNoForMail");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomOrderDetailsByOrderNoForMail()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CustomerOrder", _SqlParameter);
        }

        public SqlDataReader SelectRoomOrderDetailsByOrderNoForPaymnets()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomOrderDetailsByOrderNoForPaymnets");
                _SqlParameter[1] = new SqlParameter("@OrderNo", OrderNo);
                return ObjSql.GetDatareaderProc("Mst_Sp_CustomerOrder", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomOrderDetailsByOrderNoForPaymnets()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CustomerOrder", _SqlParameter);
        }
        #endregion
    }
}
