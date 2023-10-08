using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class EntertainmentActivityData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public EntertainmentActivityData()
        {
        }

        private int _EntertainmentActivityID = 0;
        private string _activityTitle = string.Empty;
        private string _activityAlias = string.Empty;
        private int _EntertainmentID = 0;
        private string _activityDefaultImage = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;

        public int EntertainmentActivityID
        {
            get { return _EntertainmentActivityID; }
            set { _EntertainmentActivityID = value; }
        }
        public string ActivityTitle
        {
            get { return _activityTitle; }
            set { _activityTitle = value; }
        }
        public string ActivityAlias
        {
            get { return _activityAlias; }
            set { _activityAlias = value; }
        }
        public int EntertainmentID
        {
            get { return _EntertainmentID; }
            set { _EntertainmentID = value; }
        }
        public string ActivityDefaultImage
        {
            get { return _activityDefaultImage; }
            set { _activityDefaultImage = value; }
        }
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
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

        #region Admin Panel action
        public void SelectAllEntertainmentActivityData(System.Web.UI.WebControls.GridView EntertainmentActivityGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEntertainmentActivityData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[2] = new SqlParameter("@EntertainmentID", EntertainmentID);
                ObjSql.GdBind_SNO(EntertainmentActivityGrid, "Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEntertainmentActivityData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectEntertainmentActivityByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentActivityByID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentActivityID", EntertainmentActivityID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentActivityByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentActivity", _SqlParameter);
        }

        public int SaveNewEntertainmentActivity()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewEntertainmentActivity");
                _SqlParameter[1] = new SqlParameter("@ActivityTitle", ActivityTitle);
                _SqlParameter[2] = new SqlParameter("@ActivityAlias", ActivityAlias);
                _SqlParameter[3] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[4] = new SqlParameter("@ActivityDefaultImage", ActivityDefaultImage);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewEntertainmentActivity()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
        }

        public int UpdateEntertainmentActivityByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[10];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentActivityByID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentActivityID", EntertainmentActivityID);
                _SqlParameter[2] = new SqlParameter("@ActivityTitle", ActivityTitle);
                _SqlParameter[3] = new SqlParameter("@ActivityAlias", ActivityAlias);
                _SqlParameter[4] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[5] = new SqlParameter("@ActivityDefaultImage", ActivityDefaultImage);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[8] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[9] = new SqlParameter("@Updatedon", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentActivityByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
        }

        public int DeletEntertainmentActivityByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletEntertainmentActivityByID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentActivityID", EntertainmentActivityID);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletEntertainmentActivityByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
        }

        public int UpdateEntertainmentActivityDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentActivityDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@EntertainmentActivityID", EntertainmentActivityID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentActivityDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentActivity", _SqlParameter);
        }
        #endregion

        #region Front End Data
        public DataSet SelectAllActiveEntertainmentActivityByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveEntertainmentActivityByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentActivity", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveEntertainmentActivityByEntertainmentID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentActivity", _SqlParameter);
        }
        #endregion
    }
}
