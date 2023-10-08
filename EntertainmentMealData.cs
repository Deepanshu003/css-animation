using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class EntertainmentMealData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public EntertainmentMealData()
        {
        }

        private int _EntertainmentMealID = 0;
        private string _mealTitle = string.Empty;
        private string _mealAlias = string.Empty;
        private int _EntertainmentID = 0;        
        private string _mealTiming = string.Empty;        
        private string _mealDefaultImage = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;

        public int EntertainmentMealID
        {
            get { return _EntertainmentMealID; }
            set { _EntertainmentMealID = value; }
        }
        public string MealTitle
        {
            get { return _mealTitle; }
            set { _mealTitle = value; }
        }
        public string MealAlias
        {
            get { return _mealAlias; }
            set { _mealAlias = value; }
        }
        public int EntertainmentID
        {
            get { return _EntertainmentID; }
            set { _EntertainmentID = value; }
        }
        public string MealTiming
        {
            get { return _mealTiming; }
            set { _mealTiming = value; }
        }
        public string MealDefaultImage
        {
            get { return _mealDefaultImage; }
            set { _mealDefaultImage = value; }
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
        public void SelectAllEntertainmentMealData(System.Web.UI.WebControls.GridView EntertainmentMealGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEntertainmentMealData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[2] = new SqlParameter("@EntertainmentID", EntertainmentID);
                ObjSql.GdBind_SNO(EntertainmentMealGrid, "Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEntertainmentMealData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectEntertainmentMealByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentMealByID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentMealByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentMeal", _SqlParameter);
        }

        public int SaveNewEntertainmentMeal()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[8];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewEntertainmentMeal");
                _SqlParameter[1] = new SqlParameter("@MealTitle", MealTitle);
                _SqlParameter[2] = new SqlParameter("@MealAlias", MealAlias);
                _SqlParameter[3] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[4] = new SqlParameter("@MealTiming", MealTiming);
                _SqlParameter[5] = new SqlParameter("@MealDefaultImage", MealDefaultImage);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewEntertainmentMeal()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
        }

        public int UpdateEntertainmentMealByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[11];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentMealByID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                _SqlParameter[2] = new SqlParameter("@MealTitle", MealTitle);
                _SqlParameter[3] = new SqlParameter("@MealAlias", MealAlias);
                _SqlParameter[4] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[5] = new SqlParameter("@MealTiming", MealTiming);
                _SqlParameter[6] = new SqlParameter("@MealDefaultImage", MealDefaultImage);
                _SqlParameter[7] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[10] = new SqlParameter("@Updatedon", UpdatedOn);

                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentMealByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
        }

        public int DeletEntertainmentMealByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletEntertainmentMealByID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletEntertainmentMealByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
        }

        public int UpdateEntertainmentMealDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentMealDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@EntertainmentMealID", EntertainmentMealID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentMealDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
        }



        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentMeal", _SqlParameter);
        }
        #endregion

        #region Front End Panel
        public DataSet SelectAllActiveMealDataByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveMealDataByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentMeal", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveMealDataByEntertainmentID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentMeal", _SqlParameter);
        }
        #endregion
    }
}
