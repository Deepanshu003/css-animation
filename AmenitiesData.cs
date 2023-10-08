using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class AmenitiesData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public AmenitiesData()
        {
        }


        int _AmenitiesID = 0;
        string _AmenitiesTitle = string.Empty;
        string _smallImg = string.Empty;
        int _activeStatus = 0;
        int _DisplayOrder = 0;
        string _AmenitiesTitleURL = string.Empty;
        DateTime _postedDate = DateTime.UtcNow;
        DateTime _updatedOn = DateTime.UtcNow;
        string _updatedBy = string.Empty;
        public int AmenitiesID
        {
            get { return _AmenitiesID; }
            set { _AmenitiesID = value; }
        }
        public string AmenitiesTitle
        {
            get { return _AmenitiesTitle; }
            set { _AmenitiesTitle = value; }
        }
        public string SmallImg
        {
            get { return _smallImg; }
            set { _smallImg = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public int DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }
        public string AmenitiesTitleURL
        {
            get { return _AmenitiesTitleURL; }
            set { _AmenitiesTitleURL = value; }
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
        #region Admin Panle
        public void SelectAllAmenitiesByAmenitiesAmenitiesIDorNot(System.Web.UI.WebControls.GridView AmenitiesAmenitiesGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAmenitiesByAmenitiesAmenitiesIDorNot");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(AmenitiesAmenitiesGrid, "Mst_Sp_AmenitiesData", _SqlParameter);
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

        public void SelectAllAmenitiesForDD(System.Web.UI.WebControls.DropDownList DdBlogAmenities, string AmenitiesTitle, string AmenitiesID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAmenitiesForDD");
                ObjSql.DdBing(DdBlogAmenities, "Mst_Sp_AmenitiesData", "AmenitiesTitle", "AmenitiesID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdBlogAmenities()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectAmenitiesDataByAmenitiesID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAmenitiesDataByAmenitiesID");
                _SqlParameter[1] = new SqlParameter("@AmenitiesID", AmenitiesID);
                return ObjSql.GetDatareaderProc("Mst_Sp_AmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetAmenitiesData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_AmenitiesData", _SqlParameter);
        }

        public int SaveNewAmenitiesData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewAmenitiesData");
                _SqlParameter[1] = new SqlParameter("@AmenitiesTitle", AmenitiesTitle);
                _SqlParameter[2] = new SqlParameter("@AmenitiesTitleURL", AmenitiesTitleURL);
                _SqlParameter[3] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@Updatedby", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewAmenitiesData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
        }

        public int UpdateAmenitiesDataByAmenitiesID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[8];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateAmenitiesDataByAmenitiesID");
                _SqlParameter[1] = new SqlParameter("@AmenitiesTitle", AmenitiesTitle);
                _SqlParameter[2] = new SqlParameter("@AmenitiesTitleURL", AmenitiesTitleURL);
                _SqlParameter[3] = new SqlParameter("@SmallImg", SmallImg);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[7] = new SqlParameter("@AmenitiesID", AmenitiesID);
                return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateAmenitiesDataByAmenitiesID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
        }

        public int UpdateAmenitiesDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateAmenitiesDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@AmenitiesID", AmenitiesID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateAmenitiesDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
        }

        public int DeleteAmenitiesByAmenitiesID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteAmenitiesByAmenitiesID");
                _SqlParameter[1] = new SqlParameter("@AmenitiesID", AmenitiesID);
                return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteAmenitiesByAmenitiesID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_AmenitiesData", _SqlParameter);
        }

        public DataSet SelectAllAmenitiesForAdmin()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAmenitiesForAdmin");
                return ObjSql.GetDsetProc("Mst_Sp_AmenitiesData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllAmenitiesForAdmin()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_AmenitiesData", _SqlParameter);
        }
        #endregion
    }
}
