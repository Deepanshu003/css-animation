using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class PhotoData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public PhotoData()
        {
        }

        private int _photoID = 0;
        private string _photoType = string.Empty;
        private int _photoCategoryID = 0;
        private string _photoTitle = string.Empty;
        private string _photoTitleURL = string.Empty;
        private string _smallImg = string.Empty;
        private string _largeImg = string.Empty;
        private int _activeStatus = 0;
        private int _displayOrder = 0;
        private int _displayOnHome = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;

        public int PhotoID
        {
            get { return _photoID; }
            set { _photoID = value; }
        }
        public string PhotoType
        {
            get { return _photoType; }
            set { _photoType = value; }
        }
        public int PhotoCategoryID
        {
            get { return _photoCategoryID; }
            set { _photoCategoryID = value; }
        }
        public string PhotoTitle
        {
            get { return _photoTitle; }
            set { _photoTitle = value; }
        }
        public string PhotoTitleURL
        {
            get { return _photoTitleURL; }
            set { _photoTitleURL = value; }
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
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }
        public int DisplayOnHome
        {
            get { return _displayOnHome; }
            set { _displayOnHome = value; }
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
        public void SelectAllPhotoByPhotoCategoryIDorNot(System.Web.UI.WebControls.GridView PhotoCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllPhotoByPhotoCategoryIDorNot");
                _SqlParameter[1] = new SqlParameter("@PhotoCategoryID", PhotoCategoryID);
                _SqlParameter[2] = new SqlParameter("@PhotoType", PhotoType);
                _SqlParameter[3] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(PhotoCategoryGrid, "Mst_Sp_PhotoData", _SqlParameter);
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

        public SqlDataReader SelectPhotoDataByPhotoID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectPhotoDataByPhotoID");
                _SqlParameter[1] = new SqlParameter("@PhotoID", PhotoID);
                return ObjSql.GetDatareaderProc("Mst_Sp_PhotoData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetPhotoData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_PhotoData", _SqlParameter);
        }

        public int SaveNewPhotoData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[10];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewPhotoData");
                _SqlParameter[1] = new SqlParameter("@PhotoCategoryID", PhotoCategoryID);
                _SqlParameter[2] = new SqlParameter("@PhotoType", PhotoType);
                _SqlParameter[3] = new SqlParameter("@PhotoTitle", PhotoTitle);
                _SqlParameter[4] = new SqlParameter("@PhotoTitleURL", PhotoTitleURL);
                _SqlParameter[5] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[6] = new SqlParameter("@LargeImg", LargeImg);
                _SqlParameter[7] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[8] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[9] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewPhotoData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
        }

        public int UpdatePhotoDataByPhotoID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[13];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePhotoDataByPhotoID");
                _SqlParameter[1] = new SqlParameter("@PhotoID", PhotoID);
                _SqlParameter[2] = new SqlParameter("@PhotoCategoryID", PhotoCategoryID);
                _SqlParameter[3] = new SqlParameter("@PhotoType", PhotoType);
                _SqlParameter[4] = new SqlParameter("@PhotoTitle", PhotoTitle);
                _SqlParameter[5] = new SqlParameter("@PhotoTitleURL", PhotoTitleURL);
                _SqlParameter[6] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[7] = new SqlParameter("@LargeImg", LargeImg);
                _SqlParameter[8] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[9] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[10] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[11] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[12] = new SqlParameter("@Updatedon", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdatePhotoDataByPhotoID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
        }
        public int UpdatePhotoDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePhotoDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@PhotoID", PhotoID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdatePhotoDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
        }
        public int DeletePhotoByPhotoID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletePhotoByPhotoID");
                _SqlParameter[1] = new SqlParameter("@PhotoID", PhotoID);
                return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletePhotoByPhotoID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PhotoData", _SqlParameter);
        }
        #endregion

        #region Front End Panel
        public DataSet SelectAllActivePhotoDataForImages()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActivePhotoDataForImages");
                return ObjSql.GetDsetProc("Mst_Sp_PhotoData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActivePhotoDataForImages()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_PhotoData", _SqlParameter);
        }
        #endregion
    }
}
