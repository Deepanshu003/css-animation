using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class FestivalChargesData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public FestivalChargesData()
        {
        }

        int _FestivalChargesID = 0;
        private int _packageID = 0;

        public int PackageID
        {
            get { return _packageID; }
            set { _packageID = value; }
        }
        private string _festivalChargesType = string.Empty;

        public string FestivalChargesType
        {
            get { return _festivalChargesType; }
            set { _festivalChargesType = value; }
        }
        private string _festivalDayName = string.Empty;

        public string FestivalDayName
        {
            get { return _festivalDayName; }
            set { _festivalDayName = value; }
        }  
        string _FestivalChargesName = string.Empty;
        DateTime _FestivalChargesStartDate = DateTime.UtcNow;
        DateTime _FestivalChargesEndDate = DateTime.UtcNow;
        int _KidsPrice = 0;
        int _AdultPrice = 0;
        int _ActiveStatus = 0;
        DateTime _PostedDate = DateTime.UtcNow;
        string _UpdatedBy = string.Empty;
        DateTime _UpdatedOn = DateTime.UtcNow;
        private int _uniqueID = 0;

        public int UniqueID
        {
            get { return _uniqueID; }
            set { _uniqueID = value; }
        }

        public int FestivalChargesID
        {
            get { return _FestivalChargesID; }
            set { _FestivalChargesID = value; }
        }
        public string FestivalChargesName
        {
            get { return _FestivalChargesName; }
            set { _FestivalChargesName = value; }
        }
        public DateTime FestivalChargesStartDate
        {
            get { return _FestivalChargesStartDate; }
            set { _FestivalChargesStartDate = value; }
        }
        public DateTime FestivalChargesEndDate
        {
            get { return _FestivalChargesEndDate; }
            set { _FestivalChargesEndDate = value; }
        }
        public int KidsPrice
        {
            get { return _KidsPrice; }
            set { _KidsPrice = value; }
        }
        public int AdultPrice
        {
            get { return _AdultPrice; }
            set { _AdultPrice = value; }
        }
        public int ActiveStatus
        {
            get { return _ActiveStatus; }
            set { _ActiveStatus = value; }
        }
        public DateTime PostedDate
        {
            get { return _PostedDate; }
            set { _PostedDate = value; }
        }
        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        public DateTime UpdatedOn
        {
            get { return _UpdatedOn; }
            set { _UpdatedOn = value; }
        }

        #region Admin Panle
        public void SelectAllFestivalCharges(System.Web.UI.WebControls.GridView AmenitiesAmenitiesGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllFestivalCharges");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                _SqlParameter[2] = new SqlParameter("@FestivalDayName", FestivalDayName);
                _SqlParameter[3] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(AmenitiesAmenitiesGrid, "Mst_Sp_FestivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllFestivalCharges()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectFestivalChargesDataByFestivalUniqueID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectFestivalChargesDataByFestivalUniqueID");
                _SqlParameter[1] = new SqlParameter("@UniqueID", UniqueID);
                return ObjSql.GetDatareaderProc("Mst_Sp_festivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectFestivalChargesDataByFestivalChargesID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_festivalChargesData", _SqlParameter);
        }

        public int SaveNewFestivalChargesData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[13];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewFestivalChargesData");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                _SqlParameter[2] = new SqlParameter("@FestivalChargesName", FestivalChargesName);
                _SqlParameter[3] = new SqlParameter("@FestivalDayName", FestivalDayName);
                _SqlParameter[4] = new SqlParameter("@FestivalChargesStartDate", FestivalChargesStartDate);
                _SqlParameter[5] = new SqlParameter("@FestivalChargesEndDate", FestivalChargesEndDate);
                _SqlParameter[6] = new SqlParameter("@KidsPrice", KidsPrice);
                _SqlParameter[7] = new SqlParameter("@AdultPrice", AdultPrice);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[10] = new SqlParameter("@UpdatedOn", UpdatedOn);
                _SqlParameter[11] = new SqlParameter("@PostedDate", PostedDate);
                _SqlParameter[12] = new SqlParameter("@UniqueID", UniqueID);
                return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewFestivalChargesData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
        }

        public int UpdateFestivalChargesDataByFestivalChargesID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[9];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateFestivalChargesDataByFestivalChargesID");
                _SqlParameter[1] = new SqlParameter("@FestivalChargesName", FestivalChargesName);
                _SqlParameter[2] = new SqlParameter("@FestivalChargesStartDate", FestivalChargesStartDate);
                _SqlParameter[3] = new SqlParameter("@FestivalChargesEndDate", FestivalChargesEndDate);
                _SqlParameter[4] = new SqlParameter("@KidsPrice", KidsPrice);
                _SqlParameter[5] = new SqlParameter("@AdultPrice", AdultPrice);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[8] = new SqlParameter("@FestivalChargesID", FestivalChargesID);
                return ObjSql.ExcuteProce("Mst_Sp_FestivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateFestivalChargesDataByFestivalChargesID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_FestivalChargesData", _SqlParameter);
        }

        public int DeleteFestivalChargesByFestivalChargesID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteFestivalChargesByFestivalChargesID");
                _SqlParameter[1] = new SqlParameter("@FestivalChargesID", FestivalChargesID);
                return ObjSql.ExcuteProce("Mst_Sp_FestivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteFestivalChargesByFestivalChargesID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_FestivalChargesData", _SqlParameter);
        }

        public int SelectMaxUniqueID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxUniqueID");
                return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxUniqueID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
        }

        public int DeleteFestivalChargesByFestivalUniqueID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteFestivalChargesByFestivalUniqueID");
                _SqlParameter[1] = new SqlParameter("@UniqueID", UniqueID);
                return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteFestivalChargesByFestivalUniqueID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
        }

        public int SaveAndUpdateFestivalChargesByServiceBasePrice()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveAndUpdateFestivalChargesByServiceBasePrice");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                _SqlParameter[2] = new SqlParameter("@FestivalChargesName", FestivalChargesName);
                _SqlParameter[3] = new SqlParameter("@FestivalDayName", FestivalDayName);
                _SqlParameter[4] = new SqlParameter("@FestivalChargesStartDate", FestivalChargesStartDate);
                _SqlParameter[5] = new SqlParameter("@FestivalChargesEndDate", FestivalChargesEndDate);
                _SqlParameter[6] = new SqlParameter("@KidsPrice", KidsPrice);
                _SqlParameter[7] = new SqlParameter("@AdultPrice", AdultPrice);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[10] = new SqlParameter("@UpdatedOn", UpdatedOn);
                _SqlParameter[11] = new SqlParameter("@PostedDate", PostedDate);
                return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveAndUpdateFestivalChargesByServiceBasePrice()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_festivalChargesData", _SqlParameter);
        }
        #endregion

        #region Front End Panle
        public DataSet SelectAllActiveFestivalChargesData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveFestivalChargesData");
                return ObjSql.GetDsetProc("Mst_Sp_festivalChargesData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveFestivalChargesData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_festivalChargesData", _SqlParameter);
        }
        #endregion
    }
}
