using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Component
{
    public class RoomAmenitiesData
    {
        public RoomAmenitiesData()
        {
        }

        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _RoomAmenitiesID = 0;

        public int RoomAmenitiesID
        {
            get { return _RoomAmenitiesID; }
            set { _RoomAmenitiesID = value; }
        }
        private int _RoomID = 0;

        public int RoomID
        {
            get { return _RoomID; }
            set { _RoomID = value; }
        }
        private int _AmenitiesID = 0;

        public int AmenitiesID
        {
            get { return _AmenitiesID; }
            set { _AmenitiesID = value; }
        }
        private int _ActiveStatus = 0;

        public int ActiveStatus
        {
            get { return _ActiveStatus; }
            set { _ActiveStatus = value; }
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
        public int SaveNewRoomAmenitiesData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewRoomAmenitiesData");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[2] = new SqlParameter("@AmenitiesID", AmenitiesID);
                return ObjSql.ExcuteProce("Mst_Sp_RoomAmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewRoomAmenitiesData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomAmenitiesData", _SqlParameter);
        }

        public SqlDataReader SelectRoomAmenitiesByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomAmenitiesByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.GetDatareaderProc("Mst_Sp_RoomAmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomAmenitiesByRoomID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_RoomAmenitiesData", _SqlParameter);
        }

        public int DeleteRoomAmenitiesDataByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteRoomAmenitiesDataByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.ExcuteProce("Mst_Sp_RoomAmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteRoomAmenitiesDataByRoomID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomAmenitiesData", _SqlParameter);
        }

        public DataSet SelectAllActiveRoomAmenitiesByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomAmenitiesByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.GetDsetProc("Mst_Sp_RoomAmenitiesData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveRoomAmenitiesByRoomID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_RoomAmenitiesData", _SqlParameter);
        }
        #endregion
    }
}
