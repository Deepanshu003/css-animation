using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utility;
using System.Data.SqlClient;

namespace Component
{
    public class RoomBookData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public RoomBookData()
        {
        }
        int _RoomBookID = 0;

        public int RoomBookID
        {
            get { return _RoomBookID; }
            set { _RoomBookID = value; }
        }
        int _RoomID = 0;

        public int RoomID
        {
            get { return _RoomID; }
            set { _RoomID = value; }
        }
        int _TotalBookRooms = 0;

        public int TotalBookRooms
        {
            get { return _TotalBookRooms; }
            set { _TotalBookRooms = value; }
        }
        DateTime _BookingDate = DateTime.UtcNow;

        public DateTime BookingDate
        {
            get { return _BookingDate; }
            set { _BookingDate = value; }
        }
        int _ActiveStatus = 0;

        public int ActiveStatus
        {
            get { return _ActiveStatus; }
            set { _ActiveStatus = value; }
        }
        string _UpdatedBy = string.Empty;

        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        DateTime _UpdatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn
        {
            get { return _UpdatedOn; }
            set { _UpdatedOn = value; }
        }

        #region Admin Panle
        public DataSet SelectAllRoomBookDataByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllRoomBookDataByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.GetDsetProc("Mst_Sp_RoomBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllRoomBookDataByRoomID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_RoomBookData", _SqlParameter);
        }

        public int SaveAndUpdateRoomBookingForDate()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveAndUpdateRoomBookingForDate");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[2] = new SqlParameter("@TotalBookRooms", TotalBookRooms);
                _SqlParameter[3] = new SqlParameter("@BookingDate", BookingDate);
                _SqlParameter[4] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_RoomBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveAndUpdateRoomBookingForDate()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomBookData", _SqlParameter);
        }

        public int SaveAndUpdateRoomBookingForDateByAdmin()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveAndUpdateRoomBookingForDateByAdmin");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[2] = new SqlParameter("@TotalBookRooms", TotalBookRooms);
                _SqlParameter[3] = new SqlParameter("@BookingDate", BookingDate);
                _SqlParameter[4] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_RoomBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveAndUpdateRoomBookingForDateByAdmin()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomBookData", _SqlParameter);
        }
        #endregion

        #region Front End
        public int SaveAndUpdateRoomBookingForDateFromFrontEnd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveAndUpdateRoomBookingForDateFromFrontEnd");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[2] = new SqlParameter("@TotalBookRooms", TotalBookRooms);
                _SqlParameter[3] = new SqlParameter("@BookingDate", BookingDate);
                _SqlParameter[4] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_RoomBookData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveAndUpdateRoomBookingForDateFromFrontEnd()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomBookData", _SqlParameter);
        }

        public DataSet SelectRoomBookForByRoomIDAndBookingDate()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomBookForByRoomIDAndBookingDate");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[2] = new SqlParameter("@BookingDate", BookingDate);
                _SqlParameter[3] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.GetDsetProc("Mst_Sp_RoomBookData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomBookForByRoomIDAndBookingDate()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_RoomBookData", _SqlParameter);
        }
        #endregion
    }
}
