using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utility;
using System.Data;

namespace Component
{
    public class CMSData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public CMSData()
        {
        }
        private int _CMSID = 0;
        private string _CMSName = string.Empty;
        private string _CMSAlias = string.Empty;
        private string _CMSBannerImage = string.Empty;
        private string _CMSDescription = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _CMSMetaTitle = string.Empty;
        private string _CMSMetaKeywords = string.Empty;
        private string _CMSMetaDescription = string.Empty;
        private string _CMSMetaSchema = string.Empty;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _CMSSearch = string.Empty;

        public int CMSID
        {
            get { return _CMSID; }
            set { _CMSID = value; }
        }
        public string CMSName
        {
            get { return _CMSName; }
            set { _CMSName = value; }
        }
        public string CMSAlias
        {
            get { return _CMSAlias; }
            set { _CMSAlias = value; }
        }
        public string CMSBannerImage
        {
            get { return _CMSBannerImage; }
            set { _CMSBannerImage = value; }
        }
        public string CMSDescription
        {
            get { return _CMSDescription; }
            set { _CMSDescription = value; }
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
        public string CMSMetaTitle
        {
            get { return _CMSMetaTitle; }
            set { _CMSMetaTitle = value; }
        }
        public string CMSMetaKeywords
        {
            get { return _CMSMetaKeywords; }
            set { _CMSMetaKeywords = value; }
        }
        public string CMSMetaDescription
        {
            get { return _CMSMetaDescription; }
            set { _CMSMetaDescription = value; }
        }
        public string CMSMetaSchema
        {
            get { return _CMSMetaSchema; }
            set { _CMSMetaSchema = value; }
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
        public void SelectAllCMSData(System.Web.UI.WebControls.GridView GvCMSdataGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCMSData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(GvCMSdataGrid, "Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllCMSData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectCMSByCMSID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCMSByCMSID");
                _SqlParameter[1] = new SqlParameter("@CMSID", CMSID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCMSByCMSID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CMSData", _SqlParameter);
        }

        public int SaveNewCMSData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[11];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewCMSData");
                _SqlParameter[1] = new SqlParameter("@CMSName", CMSName);
                _SqlParameter[2] = new SqlParameter("@CMSAlias", CMSAlias);
                _SqlParameter[3] = new SqlParameter("@CMSBannerImage", CMSBannerImage);
                _SqlParameter[4] = new SqlParameter("@CMSDescription", CMSDescription);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@CMSMetaTitle", CMSMetaTitle);
                _SqlParameter[8] = new SqlParameter("@CMSMetaKeywords", CMSMetaKeywords);
                _SqlParameter[9] = new SqlParameter("@CMSMetaDescription", CMSMetaDescription);
                _SqlParameter[10] = new SqlParameter("@CMSMetaSchema", CMSMetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewCMSData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
        }

        public int UpdateCMSByCMSID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCMSByCMSID");
                _SqlParameter[1] = new SqlParameter("@CMSName", CMSName);
                _SqlParameter[2] = new SqlParameter("@CMSAlias", CMSAlias);
                _SqlParameter[3] = new SqlParameter("@CMSBannerImage", CMSBannerImage);
                _SqlParameter[4] = new SqlParameter("@CMSDescription", CMSDescription);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@CMSMetaTitle", CMSMetaTitle);
                _SqlParameter[8] = new SqlParameter("@CMSMetaKeywords", CMSMetaKeywords);
                _SqlParameter[9] = new SqlParameter("@CMSMetaDescription", CMSMetaDescription);
                _SqlParameter[10] = new SqlParameter("@CMSMetaSchema", CMSMetaSchema);
                _SqlParameter[11] = new SqlParameter("@CMSID", CMSID);
                return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCMSByCMSID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
        }

        public int DeleteCMSByCMSID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteCMSByCMSID");
                _SqlParameter[1] = new SqlParameter("@CMSID", CMSID);
                return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteCMSByCMSID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
        }

        public int UpdateCMSDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCMSDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@CMSID", CMSID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCMSDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CMSData", _SqlParameter);
        }
        #endregion

        #region Front End Data
        public int SelectActiveCMSIDbyURL(string CMSAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveCMSIDbyURL");
                _SqlParameter[1] = new SqlParameter("@CMSAlias", CMSAlias);

                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_CMSData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveCMSIDbyURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectActiveCMSDataByCMSID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveCMSDataByCMSID");
                _SqlParameter[1] = new SqlParameter("@CMSID", CMSID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CMSData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveCMSDataByCMSID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CMSData", _SqlParameter);
        }
        #endregion
    }
}
