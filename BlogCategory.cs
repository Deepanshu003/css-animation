using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class BlogCategory
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public BlogCategory()
        {
        }

        int _blogBlogCategoryID = 0;
        string _blogCategoryName = string.Empty;
        string _blogCategoryNameURL = string.Empty;
        int _displayOrder = 0;
        int _activeStatus = 0;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;

        public int BlogCategoryID
        {
            get { return _blogBlogCategoryID; }
            set { _blogBlogCategoryID = value; }
        }
        public string BlogCategoryName
        {
            get { return _blogCategoryName; }
            set { _blogCategoryName = value; }
        }
        public string BlogCategoryNameURL
        {
            get { return _blogCategoryNameURL; }
            set { _blogCategoryNameURL = value; }
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
        public string MetaTitle
        {
            get { return _metaTitle; }
            set { _metaTitle = value; }
        }
        public string MetaKeywords
        {
            get { return _metaKeywords; }
            set { _metaKeywords = value; }
        }
        public string MetaDescriptions
        {
            get { return _metaDescriptions; }
            set { _metaDescriptions = value; }
        }
        string _MetaSchema = string.Empty;

        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }

        public void SelectAllBlogCategory(System.Web.UI.WebControls.GridView BlogCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllBlogCategory");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(BlogCategoryGrid, "Mst_Sp_BlogCategory", _SqlParameter);
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

        public void SelectAllBlogCategoryForDD(System.Web.UI.WebControls.DropDownList DdBlogCategory, string BlogCategoryName, string BlogCategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllBlogCategoryForDD");
                ObjSql.DdBing(DdBlogCategory, "Mst_Sp_BlogCategory", "BlogCategoryName", "BlogCategoryID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdBlogCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectBlogCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBlogCategoryByID");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                return ObjSql.GetDatareaderProc("Mst_Sp_BlogCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetBlogCategoryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_BlogCategory", _SqlParameter);
        }

        public int SaveNewBlogCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[9];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewBlogCategory");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryName", BlogCategoryName);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[3] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[4] = new SqlParameter("@BlogCategoryNameURL", BlogCategoryNameURL);
                _SqlParameter[5] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[6] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[7] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[8] = new SqlParameter("@MetaSchema", MetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveBlogCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
        }

        public int UpdateBlogCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateBlogCategoryByID");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                _SqlParameter[2] = new SqlParameter("@BlogCategoryName", BlogCategoryName);
                _SqlParameter[3] = new SqlParameter("@BlogCategoryNameURL", BlogCategoryNameURL);
                _SqlParameter[4] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[7] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[8] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[9] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[10] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[11] = new SqlParameter("@MetaSchema", MetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateBlogCategoryByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
        }

        public int UpdateBlogCategoryDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateBlogCategoryDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateMainMenuDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
        }

        public int DeletBlogCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletBlogCategoryByID");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletBlogCategoryByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogCategory", _SqlParameter);
        }

        #region Front End PAnel
        public DataSet SelectAllActiveBlogCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveBlogCategory");
                return ObjSql.GetDsetProc("Mst_Sp_BlogCategory", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveBlogCategory()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_BlogCategory", _SqlParameter);
        }

        public int SelectBlogCategoryIDByBlogCategoryURL(string BlogCategoryNameURL)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBlogCategoryIDByBlogCategoryURL");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryNameURL", BlogCategoryNameURL);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_BlogCategory", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectBlogCategoryIDByBlogCategoryURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }
        #endregion
    }
}
