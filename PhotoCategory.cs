using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class PhotoCategory
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public PhotoCategory()
        {
        }

        private int _photoCategoryID = 0;
        private string _photoCategoryName = string.Empty;
        private string _photoCategoryNameURL = string.Empty;
        private string _photoCategoryImage = string.Empty;
        private string _PhotoCategoryDescription = string.Empty;


        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;


        public int PhotoCategoryID
        {
            get { return _photoCategoryID; }
            set { _photoCategoryID = value; }
        }
        public string PhotoCategoryName
        {
            get { return _photoCategoryName; }
            set { _photoCategoryName = value; }
        }
        public string PhotoCategoryNameURL
        {
            get { return _photoCategoryNameURL; }
            set { _photoCategoryNameURL = value; }
        }
        public string PhotoCategoryImage
        {
            get { return _photoCategoryImage; }
            set { _photoCategoryImage = value; }
        }
        public string PhotoCategoryDescription
        {
            get { return _PhotoCategoryDescription; }
            set { _PhotoCategoryDescription = value; }
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
        public void SelectAllPhotoCategory(System.Web.UI.WebControls.GridView PhotoCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllPhotoCategory");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(PhotoCategoryGrid, "Mst_Sp_photoCategory", _SqlParameter);
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

        public void SelectAllPhotoCategoryForDD(System.Web.UI.WebControls.DropDownList DdPhotoCategory, string PhotoCategoryName, string PhotoCategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllPhotoCategoryForDD");
                ObjSql.DdBing(DdPhotoCategory, "Mst_Sp_photoCategory", "PhotoCategoryName", "PhotoCategoryID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdPhotoCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectPhotoCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectPhotoCategoryByID");
                _SqlParameter[1] = new SqlParameter("@PhotoCategoryID", PhotoCategoryID);
                return ObjSql.GetDatareaderProc("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetPhotoCategoryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_photoCategory", _SqlParameter);
        }

        public int SaveNewPhotoCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewPhotoCategory");
                _SqlParameter[1] = new SqlParameter("@PhotoCategoryName", PhotoCategoryName);
                _SqlParameter[2] = new SqlParameter("@PhotoCategoryNameURL", PhotoCategoryNameURL);
                _SqlParameter[3] = new SqlParameter("@PhotoCategoryImage", PhotoCategoryImage);
                _SqlParameter[4] = new SqlParameter("@PhotoCategoryDescription", PhotoCategoryDescription);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SavePhotoCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
        }

        public int UpdatePhotoCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[10];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePhotoCategoryByID");
                _SqlParameter[1] = new SqlParameter("@PhotoCategoryID", PhotoCategoryID);
                _SqlParameter[2] = new SqlParameter("@PhotoCategoryName", PhotoCategoryName);
                _SqlParameter[3] = new SqlParameter("@PhotoCategoryNameURL", PhotoCategoryNameURL);
                _SqlParameter[4] = new SqlParameter("@PhotoCategoryImage", PhotoCategoryImage);
                _SqlParameter[5] = new SqlParameter("@PhotoCategoryDescription", PhotoCategoryDescription);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[8] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[9] = new SqlParameter("@Updatedon", UpdatedOn);

                return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdatePhotoCategoryByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
        }

        public int UpdatePhotoCategoryDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePhotoCategoryDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@PhotoCategoryID", PhotoCategoryID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateMainMenuDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
        }

        public int DeletPhotoCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletPhotoCategoryByID");
                _SqlParameter[1] = new SqlParameter("@PhotoCategoryID", PhotoCategoryID);
                return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletPhotoCategoryByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_photoCategory", _SqlParameter);
        }
        #endregion

        #region Front End Panel
        public DataSet SelectAllActiveGalCategorydata()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveGalCategorydata");
                return ObjSql.GetDsetProc("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveGalCategorydata()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_photoCategory", _SqlParameter);
        }

        public DataSet SelectTop6ActivePhotoCatDataForHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop6ActivePhotoCatDataForHome");
                return ObjSql.GetDsetProc("Mst_Sp_photoCategory", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop6ActivePhotoCatDataForHome()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_photoCategory", _SqlParameter);
        }
        #endregion
    }
}
