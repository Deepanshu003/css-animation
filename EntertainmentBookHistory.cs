using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class EntertainmentBookHistory
    {
        public EntertainmentBookHistory()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _EntertainmentBookingHistoryID = 0;

        public int EntertainmentBookingHistoryID
        {
            get { return _EntertainmentBookingHistoryID; }
            set { _EntertainmentBookingHistoryID = value; }
        }
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
        private string _SubPackageName = string.Empty;

        public string SubPackageName
        {
            get { return _SubPackageName; }
            set { _SubPackageName = value; }
        }
        private int _TicketPrice = 0;

        public int TicketPrice
        {
            get { return _TicketPrice; }
            set { _TicketPrice = value; }
        }
        private int _TotalTicket = 0;

        public int TotalTicket
        {
            get { return _TotalTicket; }
            set { _TotalTicket = value; }
        }
        private int _TotalAmount = 0;

        public int TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
        private DateTime _PostedDate = DateTime.UtcNow;

        public DateTime PostedDate
        {
            get { return _PostedDate; }
            set { _PostedDate = value; }
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
         
        #region Admin Panel
        public void SelectAllEntertainmentBookingData(System.Web.UI.WebControls.GridView CustomerOrderGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEntertainmentBookingData");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);               
                ObjSql.GdBind_SNO(CustomerOrderGrid, "Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEntertainmentBookingData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        public DataSet SelectEntertainmentBookingDataByBookingOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentBookingDataByBookingOrderNo");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentBookingDataByBookingOrderNo()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentBookData", _SqlParameter);
        }
      
       
        #endregion Admin Panel

        #region Front End Panel
        public int SaveNewBookingHistoryByAndEntertainmentBookingIDBookingOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewBookingHistoryByAndEntertainmentBookingIDBookingOrderNo");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@EntertainmentBookingID", EntertainmentBookingID);
                _SqlParameter[3] = new SqlParameter("@SubPackageName", SubPackageName);
                _SqlParameter[4] = new SqlParameter("@TicketPrice", TicketPrice);
                _SqlParameter[5] = new SqlParameter("@TotalTicket", TotalTicket);
                _SqlParameter[6] = new SqlParameter("@TotalAmount", TotalAmount);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookHistoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewBookingHistoryByAndEntertainmentBookingIDBookingOrderNo()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookHistoryData", _SqlParameter);
        }
        #endregion
    }
}
