using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utility;
using System.Data;

namespace Component
{
    public class EatAndDrinkData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public EatAndDrinkData()
        {
        }
        private int _EatAndDrinkID = 0;
        private string _EatAndDrinkName = string.Empty;
        private string _EatAndDrinkAlias = string.Empty;
        private string _EatAndDrinkDefaultImage = string.Empty;
        private string _EatAndDrinkBannerImage = string.Empty;
        private string _EatAndDrinkSamallDescription = string.Empty;

        public string EatAndDrinkSamallDescription
        {
            get { return _EatAndDrinkSamallDescription; }
            set { _EatAndDrinkSamallDescription = value; }
        }
        private string _EatAndDrinkDescription = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _EatAndDrinkMetaTitle = string.Empty;
        private string _EatAndDrinkMetaKeywords = string.Empty;
        private string _EatAndDrinkMetaDescription = string.Empty;
        private string _EatAndDrinkMetaSchema = string.Empty;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _EatAndDrinkSearch = string.Empty;

        public int EatAndDrinkID
        {
            get { return _EatAndDrinkID; }
            set { _EatAndDrinkID = value; }
        }
        public string EatAndDrinkName
        {
            get { return _EatAndDrinkName; }
            set { _EatAndDrinkName = value; }
        }
        public string EatAndDrinkAlias
        {
            get { return _EatAndDrinkAlias; }
            set { _EatAndDrinkAlias = value; }
        }

        public string EatAndDrinkDefaultImage
        {
            get { return _EatAndDrinkDefaultImage; }
            set { _EatAndDrinkDefaultImage = value; }
        }
        public string EatAndDrinkBannerImage
        {
            get { return _EatAndDrinkBannerImage; }
            set { _EatAndDrinkBannerImage = value; }
        }
        public string EatAndDrinkDescription
        {
            get { return _EatAndDrinkDescription; }
            set { _EatAndDrinkDescription = value; }
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
        public string EatAndDrinkMetaTitle
        {
            get { return _EatAndDrinkMetaTitle; }
            set { _EatAndDrinkMetaTitle = value; }
        }
        public string EatAndDrinkMetaKeywords
        {
            get { return _EatAndDrinkMetaKeywords; }
            set { _EatAndDrinkMetaKeywords = value; }
        }
        public string EatAndDrinkMetaDescription
        {
            get { return _EatAndDrinkMetaDescription; }
            set { _EatAndDrinkMetaDescription = value; }
        }
        public string EatAndDrinkMetaSchema
        {
            get { return _EatAndDrinkMetaSchema; }
            set { _EatAndDrinkMetaSchema = value; }
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
        public void SelectAllEatAndDrinkData(System.Web.UI.WebControls.GridView GvEatAndDrinkdataGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEatAndDrinkData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(GvEatAndDrinkdataGrid, "Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEatAndDrinkData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectEatAndDrinkByEatAndDrinkID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEatAndDrinkByEatAndDrinkID");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkID", EatAndDrinkID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEatAndDrinkByEatAndDrinkID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public int SaveNewEatAndDrinkData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[13];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewEatAndDrinkData");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkName", EatAndDrinkName);
                _SqlParameter[2] = new SqlParameter("@EatAndDrinkAlias", EatAndDrinkAlias);
                _SqlParameter[3] = new SqlParameter("@EatAndDrinkDefaultImage", EatAndDrinkDefaultImage);
                _SqlParameter[4] = new SqlParameter("@EatAndDrinkBannerImage", EatAndDrinkBannerImage);
                _SqlParameter[5] = new SqlParameter("@EatAndDrinkSamallDescription", EatAndDrinkSamallDescription);
                _SqlParameter[6] = new SqlParameter("@EatAndDrinkDescription", EatAndDrinkDescription);
                _SqlParameter[7] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@EatAndDrinkMetaTitle", EatAndDrinkMetaTitle);
                _SqlParameter[10] = new SqlParameter("@EatAndDrinkMetaKeywords", EatAndDrinkMetaKeywords);
                _SqlParameter[11] = new SqlParameter("@EatAndDrinkMetaDescription", EatAndDrinkMetaDescription);
                _SqlParameter[12] = new SqlParameter("@EatAndDrinkMetaSchema", EatAndDrinkMetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewEatAndDrinkData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public int UpdateEatAndDrinkByEatAndDrinkID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[14];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEatAndDrinkByEatAndDrinkID");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkName", EatAndDrinkName);
                _SqlParameter[2] = new SqlParameter("@EatAndDrinkAlias", EatAndDrinkAlias);
                _SqlParameter[3] = new SqlParameter("@EatAndDrinkDefaultImage", EatAndDrinkDefaultImage);
                _SqlParameter[4] = new SqlParameter("@EatAndDrinkBannerImage", EatAndDrinkBannerImage);
                _SqlParameter[5] = new SqlParameter("@EatAndDrinkSamallDescription", EatAndDrinkSamallDescription);
                _SqlParameter[6] = new SqlParameter("@EatAndDrinkDescription", EatAndDrinkDescription);
                _SqlParameter[7] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@EatAndDrinkMetaTitle", EatAndDrinkMetaTitle);
                _SqlParameter[10] = new SqlParameter("@EatAndDrinkMetaKeywords", EatAndDrinkMetaKeywords);
                _SqlParameter[11] = new SqlParameter("@EatAndDrinkMetaDescription", EatAndDrinkMetaDescription);
                _SqlParameter[12] = new SqlParameter("@EatAndDrinkMetaSchema", EatAndDrinkMetaSchema);
                _SqlParameter[13] = new SqlParameter("@EatAndDrinkID", EatAndDrinkID);
                return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEatAndDrinkByEatAndDrinkID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public int DeleteEatAndDrinkByEatAndDrinkID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteEatAndDrinkByEatAndDrinkID");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkID", EatAndDrinkID);
                return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteEatAndDrinkByEatAndDrinkID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public int UpdateEatAndDrinkDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEatAndDrinkDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkID", EatAndDrinkID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEatAndDrinkDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }
        #endregion

        #region Front End Data
        public DataSet SelectAllActiveEatAndDrinkDataForListing()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveEatAndDrinkDataForListing");
                return ObjSql.GetDsetProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveEatAndDrinkDataForListing()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public DataSet SelectTop1ActiveEatAndDrinkDataForHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop1ActiveEatAndDrinkDataForHome");
                return ObjSql.GetDsetProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop1ActiveEatAndDrinkDataForHome()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public int SelectActiveEatAndDrinkIDbyURL(string EatAndDrinkAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveEatAndDrinkIDbyURL");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkAlias", EatAndDrinkAlias);

                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_EatAndDrinkData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveEatAndDrinkIDbyURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectActiveEatAndDrinkDataByEatAndDrinkID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveEatAndDrinkDataByEatAndDrinkID");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkID", EatAndDrinkID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveEatAndDrinkDataByEatAndDrinkID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }

        public DataSet SelectTop10ActiveRealtedEatAndDrinkData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop10ActiveRealtedEatAndDrinkData");
                _SqlParameter[1] = new SqlParameter("@EatAndDrinkID", EatAndDrinkID);
                return ObjSql.GetDsetProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop10ActiveRealtedEatAndDrinkData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EatAndDrinkData", _SqlParameter);
        }
        #endregion
    }
}
