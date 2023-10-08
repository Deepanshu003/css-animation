using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class VideoGallery
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public VideoGallery()
        {
        }
        private int _VideoGalleryID = 0;
        private string _GalleryTitle = string.Empty;
        private string _GalleryTitleURL = string.Empty;
        private string _SmallImg = string.Empty;
        private string _VideoURL = string.Empty;
        private string _SmallDescription = string.Empty;
        private int _activeStatus = 0;
        private int _displayOrder = 0;
        private int _displayOnHome = 0;
        private int _displayOnTestimonial = 0;
        private int _displayOnEntertainment = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        public int VideoGalleryID
        {
            get { return _VideoGalleryID; }
            set { _VideoGalleryID = value; }
        }

        public string GalleryTitle
        {
            get { return _GalleryTitle; }
            set { _GalleryTitle = value; }
        }

        public string GalleryTitleURL
        {
            get { return _GalleryTitleURL; }
            set { _GalleryTitleURL = value; }
        }

        public string SmallImg
        {
            get { return _SmallImg; }
            set { _SmallImg = value; }
        }

        public string VideoURL
        {
            get { return _VideoURL; }
            set { _VideoURL = value; }
        }

        public string SmallDescription
        {
            get { return _SmallDescription; }
            set { _SmallDescription = value; }
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
        public int DisplayOnTestimonial
        {
            get { return _displayOnTestimonial; }
            set { _displayOnTestimonial = value; }
        }
        public int DisplayOnEntertainment
        {
            get { return _displayOnEntertainment; }
            set { _displayOnEntertainment = value; }
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
        public void SelectAllVideoGalleryData(System.Web.UI.WebControls.GridView GalleryCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllVideoGalleryData");
                _SqlParameter[1] = new SqlParameter("@UpdatedOn", UpdatedOn);
                ObjSql.GdBind_SNO(GalleryCategoryGrid, "Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllVideoGalleryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        public SqlDataReader SelectVideoGalleryDataByVideoGalleryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectVideoGalleryDataByVideoGalleryID");
                _SqlParameter[1] = new SqlParameter("@VideoGalleryID", VideoGalleryID);
                return ObjSql.GetDatareaderProc("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectVideoGalleryDataByVideoGalleryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_VideoGalleryData", _SqlParameter);
        }

        public int SaveNewVideoGalleryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[11];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewVideoGalleryData");
                _SqlParameter[1] = new SqlParameter("@GalleryTitle", GalleryTitle);
                _SqlParameter[2] = new SqlParameter("@GalleryTitleURL", GalleryTitleURL);
                _SqlParameter[3] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[4] = new SqlParameter("@VideoURL", VideoURL);
                _SqlParameter[5] = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[8] = new SqlParameter("@DisplayOnTestimonial", DisplayOnTestimonial);
                _SqlParameter[9] = new SqlParameter("@DisplayOnEntertainment", DisplayOnEntertainment);
                _SqlParameter[10] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewGalleryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
        }

        public int UpdateVideoGalleryDataByVideoGalleryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateVideoGalleryDataByVideoGalleryID");
                _SqlParameter[1] = new SqlParameter("@VideoGalleryID", VideoGalleryID);
                _SqlParameter[2] = new SqlParameter("@GalleryTitle", GalleryTitle);
                _SqlParameter[3] = new SqlParameter("@GalleryTitleURL", GalleryTitleURL);
                _SqlParameter[4] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[5] = new SqlParameter("@VideoURL", VideoURL);
                _SqlParameter[6] = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[7] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[8] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[9] = new SqlParameter("@DisplayOnTestimonial", DisplayOnTestimonial);
                _SqlParameter[10] = new SqlParameter("@DisplayOnEntertainment", DisplayOnEntertainment);
                _SqlParameter[11] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateVideoGalleryDataByVideoGalleryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
        }
        public int UpdateVideoGalleryDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateVideoGalleryDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@VideoGalleryID", VideoGalleryID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateGalleryDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
        }
        public int DeleteVideoGalleryByVideoGalleryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteVideoGalleryByVideoGalleryID");
                _SqlParameter[1] = new SqlParameter("@VideoGalleryID", VideoGalleryID);
                return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteGalleryByGalleryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_VideoGalleryData", _SqlParameter);
        }        
        #endregion

        #region Front End Panle
        public DataSet SelectTop6ActiveTestimonialVideoHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop6ActiveTestimonialVideoHome");
                return ObjSql.GetDsetProc("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop6ActiveTestimonialVideoHome()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_VideoGalleryData", _SqlParameter);
        }

        public DataSet SelectAllActiveTestimonialVideoFroEntertainment()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveTestimonialVideoFroEntertainment");
                return ObjSql.GetDsetProc("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveTestimonialVideoFroEntertainment()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_VideoGalleryData", _SqlParameter);
        }

        public DataSet SelectAllActiveVideoFroGalleryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveVideoFroGalleryData");
                return ObjSql.GetDsetProc("Mst_Sp_VideoGalleryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveVideoFroGalleryData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_VideoGalleryData", _SqlParameter);
        }
        #endregion
    }
}
