using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class EntertainmentPackagePriceData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public EntertainmentPackagePriceData()
        {
        }

        private int _EntertainmentPackagePriceID = 0;
        private int _EntertainmentID = 0;
        private int _PackageID = 0;
        private string _EntertainmentName = string.Empty;
        private int _KidsPrice = 0;
        private int _AdultPrice = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        public int EntertainmentPackagePriceID
        {
            get { return _EntertainmentPackagePriceID; }
            set { _EntertainmentPackagePriceID = value; }
        }
        public int EntertainmentID
        {
            get { return _EntertainmentID; }
            set { _EntertainmentID = value; }
        }
        public int PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }
        public string EntertainmentName
        {
            get { return _EntertainmentName; }
            set { _EntertainmentName = value; }
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
        public SqlDataReader SelectEntertainmentPackagePriceByPackageID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentPackagePriceByPackageID");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentPackagePriceByPackageID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
        }

        public int SaveEntertainmentPackagePriceByPackageID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[9];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveEntertainmentPackagePriceByPackageID");                
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                _SqlParameter[2] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[3] = new SqlParameter("@EntertainmentName", EntertainmentName);
                _SqlParameter[4] = new SqlParameter("@KidsPrice", KidsPrice);
                _SqlParameter[5] = new SqlParameter("@AdultPrice", AdultPrice);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@UpdatedOn", UpdatedOn);
                _SqlParameter[8] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveEntertainmentPackagePriceByEntertainmentID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
        }


        public int DeleteEntertainmentPackagePriceByPackageID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteEntertainmentPackagePriceByPackageID");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteEntertainmentPackagePriceByPackageID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
        }
        #endregion Admin Panel

        #region Front End Panle
        public DataSet SelectAllActiveEntertainmentPackagePriceByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveEntertainmentPackagePriceByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveEntertainmentPackagePriceByEntertainmentID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentPackagePriceData", _SqlParameter);
        }
        #endregion
    }
}
