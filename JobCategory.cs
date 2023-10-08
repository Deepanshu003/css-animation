using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class JobCategory
    {
        public JobCategory()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        int _jobCategoryID = 0;

        string _JObLocation = string.Empty;

        public string JObLocation
        {
            get { return _JObLocation; }
            set { _JObLocation = value; }
        }

        string _Experience = string.Empty;

        public string Experience
        {
            get { return _Experience; }
            set { _Experience = value; }
        }

        string _JobCategoryDiscription = string.Empty;

        public string JobCategoryDiscription
        {
            get { return _JobCategoryDiscription; }
            set { _JobCategoryDiscription = value; }
        }

        public int JobCategoryID
        {
            get { return _jobCategoryID; }
            set { _jobCategoryID = value; }
        }
        string _jobCategoryName = string.Empty;

        public string JobCategoryName
        {
            get { return _jobCategoryName; }
            set { _jobCategoryName = value; }
        }
        int _displayOrder = 0;

        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        int _ActiveStatus = 0;

        public int ActiveStatus
        {
            get { return _ActiveStatus; }
            set { _ActiveStatus = value; }
        }

        string _updatedBy = string.Empty;

        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        DateTime _updatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }


        public void SelectAll(System.Web.UI.WebControls.GridView JobCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SELECTJOBCATEGORY");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(JobCategoryGrid, "Mst_Sp_JobCategory", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAll()", Ex);
            }
        }

        public void BindDdJobCategory(System.Web.UI.WebControls.DropDownList DdJobCategory, string JobCategoryName, string JobCategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SELECTALLForDD");
                ObjSql.DdBing(DdJobCategory, "Mst_Sp_JobCategory", "JobCategoryName", "JobCategoryID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdJobCategory()", Ex);
            }
        }

        public int SaveJobCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SAVEJOBCATEGORY");
                _SqlParameter[1] = new SqlParameter("@JobCategoryName", JobCategoryName);
                _SqlParameter[2] = new SqlParameter("@JObLocation", JObLocation);
                _SqlParameter[3] = new SqlParameter("@Experience", Experience);
                _SqlParameter[4] = new SqlParameter("@JobCategoryDiscription", JobCategoryDiscription);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveJobCategory()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
        }
        public SqlDataReader GetJobCategoryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "GETJOBCATEGORYDATA");
                _SqlParameter[1] = new SqlParameter("@JobCategoryID", JobCategoryID);
                return ObjSql.GetDatareaderProc("Mst_Sp_JobCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetJobCategoryData()", Ex);
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_JobCategory", _SqlParameter);
        }
        public int DeleteRecord()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DELETEJOBCATEGORY");
                _SqlParameter[1] = new SqlParameter("@JobCategoryID", JobCategoryID);


                return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteRecord()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
        }
        public int UpdateJobCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[10];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UPDATEJOBCATEGORY");
                _SqlParameter[1] = new SqlParameter("@JobCategoryID", JobCategoryID);
                _SqlParameter[2] = new SqlParameter("@JobCategoryName", JobCategoryName);
                _SqlParameter[3] = new SqlParameter("@JObLocation", JObLocation);
                _SqlParameter[4] = new SqlParameter("@Experience", Experience);
                _SqlParameter[5] = new SqlParameter("@JobCategoryDiscription", JobCategoryDiscription);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[8] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[9] = new SqlParameter("@Updatedon", UpdatedOn);

                return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateJobCategory()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
        }

        public int UpdateDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@JobCategoryID", JobCategoryID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateDisplayOrder()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_Sp_JobCategory", _SqlParameter);
        }

        #region FrontEnd Start
        //*******************Bind ALl Active Repeater Blog Data************************//
        public DataSet SelectAllActiveJobCategoryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveJobCategoryData");
                return ObjSql.GetDsetProc("Mst_Sp_JobCategory", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveJobCategoryData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_JobCategory", _SqlParameter);
        }
        //************************END****************************//
        #endregion FrontEnd END
    }
}
