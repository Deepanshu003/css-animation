using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class RoomAddOn
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public RoomAddOn()
        {
        }
        private int _RoomExtraAddOnId = 0;
        private string _AddOnName = string.Empty;
        private string _AddOnsImage = string.Empty;
        private int _AddOnValue = 0;
        private int _AddOnTaxValue = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        public int RoomExtraAddOnId
        {
            get { return _RoomExtraAddOnId; }
            set { _RoomExtraAddOnId = value; }
        }       
        public string AddOnName
        {
            get { return _AddOnName; }
            set { _AddOnName = value; }
        }
        public string AddOnsImage
        {
            get { return _AddOnsImage; }
            set { _AddOnsImage = value; }
        }
        public int AddOnValue
        {
            get { return _AddOnValue; }
            set { _AddOnValue = value; }
        }
        public int AddOnTaxValue
        {
            get { return _AddOnTaxValue; }
            set { _AddOnTaxValue = value; }
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
        public void SelectAllRoomAddOn(System.Web.UI.WebControls.GridView RoomAddOnGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllRoomAddOn");                
                ObjSql.GdBind_SNO(RoomAddOnGrid, "Mst_Sp_RoomAddOn", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAll()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        public SqlDataReader SelectRoomAddOnByRoomExtraAddOnId()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomAddOnByRoomExtraAddOnId");
                _SqlParameter[1] = new SqlParameter("@RoomExtraAddOnId", RoomExtraAddOnId);
                return ObjSql.GetDatareaderProc("Mst_Sp_RoomAddOn", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRoomAddOnByRoomExtraAddOnId()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_RoomAddOn", _SqlParameter);
        }

        public int SaveNewRoomAddOnData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[6];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewRoomAddOnData");
                _SqlParameter[1] = new SqlParameter("@AddOnName", AddOnName);
                _SqlParameter[2] = new SqlParameter("@AddOnsImage", AddOnsImage);
                _SqlParameter[3] = new SqlParameter("@AddOnValue", AddOnValue);
                _SqlParameter[4] = new SqlParameter("@AddOnTaxValue", AddOnTaxValue);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_RoomAddOn", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewRoomAddOnData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomAddOn", _SqlParameter);
        }

        public int UpdateRoomAddOnDataByRoomExtraAddOnId()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateRoomAddOnDataByRoomExtraAddOnId");
                _SqlParameter[1] = new SqlParameter("@AddOnName", AddOnName);
                _SqlParameter[2] = new SqlParameter("@AddOnsImage", AddOnsImage);
                _SqlParameter[3] = new SqlParameter("@AddOnValue", AddOnValue);
                _SqlParameter[4] = new SqlParameter("@AddOnTaxValue", AddOnTaxValue);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6] = new SqlParameter("@RoomExtraAddOnId", RoomExtraAddOnId);
                return ObjSql.ExcuteProce("Mst_Sp_RoomAddOn", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateRoomAddOnDataByRoomExtraAddOnId()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomAddOn", _SqlParameter);
        }

        public int DeleteRoomAddOnDataByRoomExtraAddOnId()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteRoomAddOnDataByRoomExtraAddOnId");
                _SqlParameter[1] = new SqlParameter("@RoomExtraAddOnId", RoomExtraAddOnId);
                return ObjSql.ExcuteProce("Mst_Sp_RoomAddOn", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteRoomAddOnDataByRoomExtraAddOnId()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_RoomAddOn", _SqlParameter);
        }
        #endregion

        #region Front End
        public DataSet SelectAllActiveRoomAddFroFrontEnd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomAddFroFrontEnd");
                return ObjSql.GetDsetProc("Mst_Sp_RoomAddOn", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveRoomAddFroFrontEnd()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_RoomAddOn", _SqlParameter);
        }
        #endregion

    }
}
