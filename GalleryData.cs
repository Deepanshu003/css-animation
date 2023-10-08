using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class GalleryData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public GalleryData()
        {
        }

        private int _GalleryID = 0;
        private string _GalleryFor = string.Empty;
        private string _galleryTitle = string.Empty;
        private string _galleryTitleURL = string.Empty;
        private int _ActivityID = 0;
        private string _smallImg = string.Empty;
        private string _largeImg = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;        
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;

        public int GalleryID
        {
            get { return _GalleryID; }
            set { _GalleryID = value; }
        }
        public string GalleryFor
        {
            get { return _GalleryFor; }
            set { _GalleryFor = value; }
        }
        public string GalleryTitle
        {
            get { return _galleryTitle; }
            set { _galleryTitle = value; }
        }
        public string GalleryTitleURL
        {
            get { return _galleryTitleURL; }
            set { _galleryTitleURL = value; }
        }
        public int ActivityID
        {
            get { return _ActivityID; }
            set { _ActivityID = value; }
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
        public DataSet SelectAllGalleryImges()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllGalleryImges");
                _SqlParameter[1] = new SqlParameter("@GalleryFor", GalleryFor);
                _SqlParameter[2] = new SqlParameter("@ActivityID", ActivityID);
                return ObjSql.GetDsetProc("Mst_Sp_GalleryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllGalleryImges()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_GalleryData", _SqlParameter);
        }

        public int SaveNewGalleryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewGalleryData");
                _SqlParameter[1] = new SqlParameter("@GalleryFor", GalleryFor);
                _SqlParameter[2] = new SqlParameter("@ActivityID", ActivityID);
                _SqlParameter[3] = new SqlParameter("@GalleryTitle", GalleryTitle);
                _SqlParameter[4] = new SqlParameter("@SmallImg", SmallImg);
                return ObjSql.ExcuteProce("Mst_Sp_GalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewGalleryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_GalleryData", _SqlParameter);
        }

        public int DeleteGalleryByGalleryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteGalleryByGalleryID");
                _SqlParameter[1] = new SqlParameter("@GalleryFor", GalleryFor);
                _SqlParameter[2] = new SqlParameter("@GalleryID", GalleryID);
                return ObjSql.ExcuteProce("Mst_Sp_GalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteGalleryByGalleryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_GalleryData", _SqlParameter);
        }
        #endregion
    }
}
