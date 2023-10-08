using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class CareerJob
    {
        public CareerJob()
        { }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        string _RemarksIfAny = string.Empty;

        public string RemarksIfAny
        {
            get { return _RemarksIfAny; }
            set { _RemarksIfAny = value; }
        }
        int _careerID = 0;
        string _name = string.Empty;
        string _emailID = string.Empty;
        string _phoneNo = string.Empty;
        string _attachedFile = string.Empty;
        DateTime _postedDate = DateTime.UtcNow;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _attachedFile2 = string.Empty;

        int _JobCategoryID = 0;

        public int JobCategoryID
        {
            get { return _JobCategoryID; }
            set { _JobCategoryID = value; }
        }
        public string AttachedFile2
        {
            get { return _attachedFile2; }
            set { _attachedFile2 = value; }
        }
        string _attachedFile3 = string.Empty;

        public string AttachedFile3
        {
            get { return _attachedFile3; }
            set { _attachedFile3 = value; }
        }
        string _attachedFile4 = string.Empty;

        public string AttachedFile4
        {
            get { return _attachedFile4; }
            set { _attachedFile4 = value; }
        }


        public int CareerID
        {
            get { return _careerID; }
            set { _careerID = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }
        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }

        public string AttachedFile
        {
            get { return _attachedFile; }
            set { _attachedFile = value; }
        }
        public DateTime PostedDate
        {
            get { return _postedDate; }
            set { _postedDate = value; }
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

        #region AdminPanel
        public void SelectAllCareerForm(System.Web.UI.WebControls.GridView CareerGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCareerForm");
                ObjSql.GdBind_SNO(CareerGrid, "Mst_Sp_Career", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllCareerForm()", Ex);
            }
        }

        public void SelectAll(System.Web.UI.WebControls.GridView CareerGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCareerForm");
                _SqlParameter[1] = new SqlParameter("@JobCategoryID", JobCategoryID);
                ObjSql.GdBind_SNO(CareerGrid, "Mst_Sp_Career", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAll()", Ex);
            }
        }

        public void SelectAllSellForm(System.Web.UI.WebControls.GridView CareerGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllSellForm");
                ObjSql.GdBind_SNO(CareerGrid, "Mst_Sp_Career", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllSellForm()", Ex);
            }
        }

        public SqlDataReader SelectCareerByCareerID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCareerByCareerID");
                _SqlParameter[1] = new SqlParameter("@CareerID", CareerID);
                return ObjSql.GetDatareaderProc("Mst_Sp_Career", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetCareerData()", Ex);
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_Career", _SqlParameter);
        }
        public int DeleteCareerFormDataByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteCareerFormDataByID");
                _SqlParameter[1] = new SqlParameter("@CareerID", CareerID);
                return ObjSql.ExcuteProce("Mst_Sp_Career", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteCareerFormDataByID()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_Sp_Career", _SqlParameter);
        }
        #endregion AdminPanel

        #region FrontEndPanel
        public int SaveNewCareerFormData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewCareerFormData");
                _SqlParameter[1] = new SqlParameter("@Name", Name);
                _SqlParameter[2] = new SqlParameter("@EmailID", EmailID);
                _SqlParameter[3] = new SqlParameter("@PhoneNo", PhoneNo);                
                _SqlParameter[4] = new SqlParameter("@AttachedFile", AttachedFile);
                _SqlParameter[5] = new SqlParameter("@JobCategoryID", JobCategoryID);
                _SqlParameter[6] = new SqlParameter("@RemarksIfAny", RemarksIfAny);
                return ObjSql.ExcuteProce("Mst_Sp_Career", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveCareer()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_Sp_Career", _SqlParameter);
        }
        #endregion FrontEndPanel
    }
}
