using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class RoomPrice
    {
        public RoomPrice()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _RoomPriceID = 0;
        private int _RoomID = 0;
        private string _TypeName = string.Empty;
        private string _RoomDefaultPrice = string.Empty;
        private string _ExtraPersonPrice = string.Empty;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        public int RoomPriceID
        {
            get { return _RoomPriceID; }
            set { _RoomPriceID = value; }
        }       
        public int RoomID
        {
            get { return _RoomID; }
            set { _RoomID = value; }
        }        
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        public string RoomDefaultPrice
        {
            get { return _RoomDefaultPrice; }
            set { _RoomDefaultPrice = value; }
        }        
        public string ExtraPersonPrice
        {
            get { return _ExtraPersonPrice; }
            set { _ExtraPersonPrice = value; }
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

        public SqlDataReader SelectRoomPriceByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomPriceByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.GetDatareaderProc("Mst_Sp_RoomPrice", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomPriceByRoomID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_RoomPrice", _SqlParameter);
        }

        public int SaveRoomPriceByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[8];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveRoomPriceByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                _SqlParameter[2] = new SqlParameter("@TypeName", TypeName);
                _SqlParameter[3] = new SqlParameter("@RoomDefaultPrice", RoomDefaultPrice);
                _SqlParameter[4] = new SqlParameter("@ExtraPersonPrice", ExtraPersonPrice);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6] = new SqlParameter("@UpdatedOn", UpdatedOn);
                _SqlParameter[7] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_RoomPrice", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveState()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomPrice", _SqlParameter);
        }


        public int DeleteRoomPriceByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteRoomPriceByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.ExcuteProce("Mst_Sp_RoomPrice", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteRoomPriceByRoomID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomPrice", _SqlParameter);
        }

        public DataSet SelectRoomDataPriceByRoomID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomDataPriceByRoomID");
                _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
                return ObjSql.GetDsetProc("Mst_Sp_RoomPrice", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomDataPriceByRoomID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_RoomPrice", _SqlParameter);
        }
        #endregion Admin Panel

        
    }
}
