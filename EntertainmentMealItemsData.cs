using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class EntertainmentMealItemsData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public EntertainmentMealItemsData()
        {
        }

        private int _mealItemID = 0;
        private string _mealItemTitle = string.Empty;
        private string _mealItemAlias = string.Empty;
        private int _EntertainmentMealID = 0;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;

        public int MealItemID
        {
            get { return _mealItemID; }
            set { _mealItemID = value; }
        }
        public string MealItemTitle
        {
            get { return _mealItemTitle; }
            set { _mealItemTitle = value; }
        }
        public string MealItemAlias
        {
            get { return _mealItemAlias; }
            set { _mealItemAlias = value; }
        }
        public int EntertainmentMealID
        {
            get { return _EntertainmentMealID; }
            set { _EntertainmentMealID = value; }
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
        public SqlDataReader SelectAllEntertainmentMealItemsByEntertainmentMealID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEntertainmentMealItemsByEntertainmentMealID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentMealItems", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEntertainmentMealItemsByEntertainmentMealID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentMealItems", _SqlParameter);
        }

        public int SaveNewEntertainmentMealItemsByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[6];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewEntertainmentMealItemsByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@MealItemTitle", MealItemTitle);
                _SqlParameter[2] = new SqlParameter("@MealItemAlias", MealItemAlias);
                _SqlParameter[3] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                _SqlParameter[4] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewEntertainmentMealItemsByEntertainmentID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
        }

        public int UpdateEntertainmentMealItemsByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[9];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentMealItemsByID");
                _SqlParameter[1] = new SqlParameter("@MealItemID", MealItemID);
                _SqlParameter[2] = new SqlParameter("@MealItemTitle", MealItemTitle);
                _SqlParameter[3] = new SqlParameter("@MealItemAlias", MealItemAlias);
                _SqlParameter[4] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[8] = new SqlParameter("@Updatedon", UpdatedOn);

                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentMealByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
        }

        public int DeleteEntertainmentMealItemsByEntertainmentMealID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteEntertainmentMealItemsByEntertainmentMealID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteEntertainmentMealItemsByEntertainmentMealID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
        }

        public int UpdateEntertainmentMealDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentMealDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@MealItemID", MealItemID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentMealDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMealItems", _SqlParameter);
        }

        
        #endregion
    }
}
