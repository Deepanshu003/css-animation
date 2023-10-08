using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class RoomEntertainmentData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public RoomEntertainmentData()
        {
        }

        private int _RoomEntertainmentID = 0;
        private int _RoomID = 0;
        private int _EntertainmentID = 0;
        private string _EntertainmentName = string.Empty;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        public int RoomEntertainmentID
        {
            get { return _RoomEntertainmentID; }
            set { _RoomEntertainmentID = value; }
        }
        public int RoomID
        {
            get { return _RoomID; }
            set { _RoomID = value; }
        }
        public int EntertainmentID
        {
            get { return _EntertainmentID; }
            set { _EntertainmentID = value; }
        }
        public string EntertainmentName
        {
            get { return _EntertainmentName; }
            set { _EntertainmentName = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
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

        #region Admin Panel
        public SqlDataReader SelectRoomEntertainmentByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomEntertainmentByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.GetDatareaderProc("Mst_Sp_RoomEntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomEntertainmentByRoomID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_RoomEntertainmentData", _SqlParameter);
        }
        public int SaveRoomEntertainmentByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveRoomEntertainmentByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[2] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[3] = new SqlParameter("@EntertainmentName", EntertainmentName);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@UpdatedOn", UpdatedOn);
                _SqlParameter[6] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_RoomEntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveRoomEntertainmentByRoomID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomEntertainmentData", _SqlParameter);
        }
        public int DeleteRoomEntertainmentByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteRoomEntertainmentByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.ExcuteProce("Mst_Sp_RoomEntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteRoomEntertainmentByRoomID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomEntertainmentData", _SqlParameter);
        }
        #endregion Admin Panel

        #region Front End Panle
        public DataSet SelectAllActiveRoomEntertainmentForPackagePage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomEntertainmentForPackagePage");
                return ObjSql.GetDsetProc("Mst_Sp_RoomEntertainmentData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveRoomEntertainmentForPackagePage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_RoomEntertainmentData", _SqlParameter);
        }

        public DataSet SelectAllActiveRoomFoodEntertainmentForPackagePage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomFoodEntertainmentForPackagePage");
                return ObjSql.GetDsetProc("Mst_Sp_RoomEntertainmentData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveRoomFoodEntertainmentForPackagePage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_RoomEntertainmentData", _SqlParameter);
        }
        #endregion
    }
}
