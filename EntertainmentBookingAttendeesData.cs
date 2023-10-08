using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class EntertainmentBookingAttendeesData
    {
        public EntertainmentBookingAttendeesData()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _EntertainmentBookingAttendeesID = 0;

        public int EntertainmentBookingAttendeesID
        {
            get { return _EntertainmentBookingAttendeesID; }
            set { _EntertainmentBookingAttendeesID = value; }
        }
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
        private string _AttendeesType = string.Empty;

        public string AttendeesType
        {
            get { return _AttendeesType; }
            set { _AttendeesType = value; }
        }
        private string _AttendeesNames1 = string.Empty;

        public string AttendeesNames1
        {
            get { return _AttendeesNames1; }
            set { _AttendeesNames1 = value; }
        }
        private string _AttendeesNames2 = string.Empty;

        public string AttendeesNames2
        {
            get { return _AttendeesNames2; }
            set { _AttendeesNames2 = value; }
        }

        #region Front End Panel
        public int SaveNewBookingAttendeesByAndEntertainmentBookingIDBookingOrderNo()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewBookingAttendeesByAndEntertainmentBookingIDBookingOrderNo");
                _SqlParameter[1] = new SqlParameter("@BookingOrderNo", BookingOrderNo);
                _SqlParameter[2] = new SqlParameter("@EntertainmentBookingID", EntertainmentBookingID);
                _SqlParameter[3] = new SqlParameter("@EntertainmentBookingHistoryID", EntertainmentBookingHistoryID);
                _SqlParameter[4] = new SqlParameter("@AttendeesType", AttendeesType);
                _SqlParameter[5] = new SqlParameter("@AttendeesNames1", AttendeesNames1);
                _SqlParameter[6] = new SqlParameter("@AttendeesNames2", AttendeesNames2);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentBookHistoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewBookingAttendeesByAndEntertainmentBookingIDBookingOrderNo()", Ex);
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
