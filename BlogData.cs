using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class BlogData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public BlogData()
        {
        }


        private int _blogID = 0;
        private string _blogTitle = string.Empty;
        private string _blogTitleURL = string.Empty;
        private int _blogBlogCategoryID = 0;
        private string _smallImg = string.Empty;
        private string _largeImg = string.Empty;
        private string _smallDescription = string.Empty;
        private string _descriptions = string.Empty;
        private int _displayOnFooter = 0;
        private int _activeStatus = 0;    
        private DateTime _postedDate = DateTime.UtcNow;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _metaTitle = string.Empty;
        private string _metaKeywords = string.Empty;
        private string _metaDescriptions = string.Empty;
        private string _MetaSchema = string.Empty;
                
        public int BlogID
        {
            get { return _blogID; }
            set { _blogID = value; }
        }
        public string BlogTitle
        {
            get { return _blogTitle; }
            set { _blogTitle = value; }
        }
        public string BlogTitleURL
        {
            get { return _blogTitleURL; }
            set { _blogTitleURL = value; }
        }
        public int BlogCategoryID
        {
            get { return _blogBlogCategoryID; }
            set { _blogBlogCategoryID = value; }
        }
        public string SmallImg
        {
            get { return _smallImg; }
            set { _smallImg = value; }
        }
        public string LargeImg
        {
            get { return _largeImg; }
            set { _largeImg = value; }
        }
        public string SmallDescription
        {
            get { return _smallDescription; }
            set { _smallDescription = value; }
        }
        public string Descriptions
        {
            get { return _descriptions; }
            set { _descriptions = value; }
        }
        public int DisplayOnFooter
        {
            get { return _displayOnFooter; }
            set { _displayOnFooter = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
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
        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }

        public void SelectAllBlogByBlogCategoryIDorNot(System.Web.UI.WebControls.GridView BlogCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllBlogByBlogCategoryIDorNot");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                _SqlParameter[2] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(BlogCategoryGrid, "Mst_Sp_BlogData", _SqlParameter);
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

        public SqlDataReader SelectBlogDataByBlogID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBlogDataByBlogID");
                _SqlParameter[1] = new SqlParameter("@BlogID", BlogID);
                return ObjSql.GetDatareaderProc("Mst_Sp_BlogData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetBlogData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_BlogData", _SqlParameter);
        }

        public int SaveNewBlogData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[15];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewBlogData");
                _SqlParameter[1] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                _SqlParameter[2] = new SqlParameter("@BlogTitle", BlogTitle);
                _SqlParameter[3] = new SqlParameter("@BlogTitleURL", BlogTitleURL);
                _SqlParameter[4] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[5] = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[6] = new SqlParameter("@Descriptions", Descriptions);
                _SqlParameter[7] = new SqlParameter("@DisplayOnFooter", DisplayOnFooter);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@PostedDate", PostedDate);
                _SqlParameter[10] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[11] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[12] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[13] = new SqlParameter("@LargeImg", LargeImg);
                _SqlParameter[14] = new SqlParameter("@MetaSchema", MetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_BlogData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewBlogData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogData", _SqlParameter);
        }

        public int UpdateBlogDataByBlogID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[18];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateBlogDataByBlogID");
                _SqlParameter[1] = new SqlParameter("@BlogID", BlogID);
                _SqlParameter[2] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                _SqlParameter[3] = new SqlParameter("@BlogTitle", BlogTitle);
                _SqlParameter[4] = new SqlParameter("@BlogTitleURL", BlogTitleURL);
                _SqlParameter[5] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[6] = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[7] = new SqlParameter("@Descriptions", Descriptions);
                _SqlParameter[8] = new SqlParameter("@DisplayOnFooter", DisplayOnFooter);
                _SqlParameter[9] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[10] = new SqlParameter("@PostedDate", PostedDate);
                _SqlParameter[11] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[12] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[13] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[14] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[15] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[16] = new SqlParameter("@LargeImg", LargeImg);
                _SqlParameter[17] = new SqlParameter("@MetaSchema", MetaSchema);

                return ObjSql.ExcuteProce("Mst_Sp_BlogData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateBlogDataByBlogID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogData", _SqlParameter);
        }

        public int DeleteBlogByBlogID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteBlogByBlogID");
                _SqlParameter[1] = new SqlParameter("@BlogID", BlogID);
                return ObjSql.ExcuteProce("Mst_Sp_BlogData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteBlogByBlogID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_BlogData", _SqlParameter);
        }

        #region Front End data
        public DataSet SelectAllActiveBlogForlisting()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveBlogForlisting");
                return ObjSql.GetDsetProc("Mst_Sp_BlogData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveBlogForlisting()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_BlogData", _SqlParameter);
        }

        public int SelectBlogIDByBlogCategoryIDORBlogTitleURL(string BlogTitleURLs)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBlogIDByBlogCategoryIDORBlogTitleURL");
                //_SqlParameter[1] = new SqlParameter("@BlogCategoryID", BlogCategoryID);
                _SqlParameter[1] = new SqlParameter("@BlogTitleURL", BlogTitleURLs);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_BlogData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectBlogIDByBlogCategoryIDORBlogTitleURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectBlogDataByBlogIDForBlogDetails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBlogDataByBlogIDForBlogDetails");
                _SqlParameter[1] = new SqlParameter("@BlogID", BlogID);
                return ObjSql.GetDatareaderProc("Mst_Sp_BlogData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectBlogDataByBlogIDForBlogDetails()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_BlogData", _SqlParameter);
        }

        public DataSet SelectRelatedActiveBlogData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRelatedActiveBlogData");
                _SqlParameter[1] = new SqlParameter("@BlogID", BlogID);
                return ObjSql.GetDsetProc("Mst_Sp_BlogData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectRelatedActiveBlogData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_BlogData", _SqlParameter);
        }
        #endregion
    }
}
