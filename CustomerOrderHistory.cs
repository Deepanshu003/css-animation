using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class CustomerOrderHistory
    {
        public CustomerOrderHistory()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _CustomerOrderHistoryID = 0;

        public int CustomerOrderHistoryID
        {
            get { return _CustomerOrderHistoryID; }
            set { _CustomerOrderHistoryID = value; }
        }
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
        private string _RoomType = string.Empty;

        public string RoomType
        {
            get { return _RoomType; }
            set { _RoomType = value; }
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
        private int _TotalNight = 0;

        public int TotalNight
        {
            get { return _TotalNight; }
            set { _TotalNight = value; }
        }
        private string _RoomNo = string.Empty;

        public string RoomNo
        {
            get { return _RoomNo; }
            set { _RoomNo = value; }
        }
        private int _TotalAdults = 0;

        public int TotalAdults
        {
            get { return _TotalAdults; }
            set { _TotalAdults = value; }
        }
        private int _Totalkids = 0;

        public int Totalkids
        {
            get { return _Totalkids; }
            set { _Totalkids = value; }
        }
        private int _KidsOneAge = 0;

        public int KidsOneAge
        {
            get { return _KidsOneAge; }
            set { _KidsOneAge = value; }
        }
        private int _KidsTwoAge = 0;

        public int KidsTwoAge
        {
            get { return _KidsTwoAge; }
            set { _KidsTwoAge = value; }
        }
        private int _RoomPrice = 0;

        public int RoomPrice
        {
            get { return _RoomPrice; }
            set { _RoomPrice = value; }
        }
        private int _RoomTaxes = 0;

        public int RoomTaxes
        {
            get { return _RoomTaxes; }
            set { _RoomTaxes = value; }
        }
        private int _ExtraCharges = 0;

        public int ExtraCharges
        {
            get { return _ExtraCharges; }
            set { _ExtraCharges = value; }
        }
        private int _ExtraChargesTax = 0;

        public int ExtraChargesTax
        {
            get { return _ExtraChargesTax; }
            set { _ExtraChargesTax = value; }
        }
        private int _TotalPrice = 0;

        public int TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
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

        #region Front End
        public int SaveNewRoomOrderHistoryRoomWise()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[20];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewRoomOrderHistoryRoomWise");
                _SqlParameter[1] = new SqlParameter("@CustomerOrderListID", CustomerOrderListID);
                _SqlParameter[2] = new SqlParameter("@OrderNo", OrderNo);
                _SqlParameter[3] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[4] = new SqlParameter("@RoomName", RoomName);
                _SqlParameter[5] = new SqlParameter("@RoomImage", RoomImage);
                _SqlParameter[6] = new SqlParameter("@RoomType", RoomType);
                _SqlParameter[7] = new SqlParameter("@CheckInDate", CheckInDate);
                _SqlParameter[8] = new SqlParameter("@CheckOutDate", CheckOutDate);
                _SqlParameter[9] = new SqlParameter("@TotalNight", TotalNight);
                _SqlParameter[10] = new SqlParameter("@RoomNo", RoomNo);
                _SqlParameter[11] = new SqlParameter("@TotalAdults", TotalAdults);
                _SqlParameter[12] = new SqlParameter("@Totalkids", Totalkids);
                _SqlParameter[13] = new SqlParameter("@KidsOneAge", KidsOneAge);
                _SqlParameter[14] = new SqlParameter("@KidsTwoAge", KidsTwoAge);
                _SqlParameter[15] = new SqlParameter("@RoomPrice", RoomPrice);
                _SqlParameter[16] = new SqlParameter("@RoomTaxes", RoomTaxes);
                _SqlParameter[17] = new SqlParameter("@ExtraCharges", ExtraCharges);
                _SqlParameter[18] = new SqlParameter("@ExtraChargesTax", ExtraChargesTax);
                _SqlParameter[19] = new SqlParameter("@TotalPrice", TotalPrice);
                return ObjSql.ExcuteProce("Mst_Sp_CustomerOrderHistory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewRoomOrderHistoryRoomWise()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CustomerOrderHistory", _SqlParameter);
        }
        #endregion

    }
}
