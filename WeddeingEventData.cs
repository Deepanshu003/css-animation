using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utility;
using System.Data;
namespace Component
{
    public class WeddeingEventData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public WeddeingEventData()
        {
        }
        private int _WeddeingEventID = 0;
        private string _weddeingEventType = string.Empty;
        private string _WeddeingEventName = string.Empty;
        private string _WeddeingEventAlias = string.Empty;
        private string _WeddeingEventDefaultImage = string.Empty;
        private string _WeddeingEventLargeImage = string.Empty;
        private string _weddeingEventVideoLink = string.Empty;
        private string _WeddeingEventSamllDescription = string.Empty;
        private string _WeddeingEventDescription = string.Empty;
        private int _DisplayOnHome = 0;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _WeddeingEventMetaTitle = string.Empty;
        private string _WeddeingEventMetaKeywords = string.Empty;
        private string _WeddeingEventMetaDescription = string.Empty;
        private string _WeddeingEventMetaSchema = string.Empty;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _WeddeingEventSearch = string.Empty;

        public int WeddeingEventID
        {
            get { return _WeddeingEventID; }
            set { _WeddeingEventID = value; }
        }
        public string WeddeingEventType
        {
            get { return _weddeingEventType; }
            set { _weddeingEventType = value; }
        }
        public string WeddeingEventName
        {
            get { return _WeddeingEventName; }
            set { _WeddeingEventName = value; }
        }
        public string WeddeingEventAlias
        {
            get { return _WeddeingEventAlias; }
            set { _WeddeingEventAlias = value; }
        }
        public string WeddeingEventDefaultImage
        {
            get { return _WeddeingEventDefaultImage; }
            set { _WeddeingEventDefaultImage = value; }
        }
        public string WeddeingEventLargeImage
        {
            get { return _WeddeingEventLargeImage; }
            set { _WeddeingEventLargeImage = value; }
        }
        public string WeddeingEventVideoLink
        {
            get { return _weddeingEventVideoLink; }
            set { _weddeingEventVideoLink = value; }
        }
        public string WeddeingEventSamllDescription
        {
            get { return _WeddeingEventSamllDescription; }
            set { _WeddeingEventSamllDescription = value; }
        }
        public string WeddeingEventDescription
        {
            get { return _WeddeingEventDescription; }
            set { _WeddeingEventDescription = value; }
        }
        public int DisplayOnHome
        {
            get { return _DisplayOnHome; }
            set { _DisplayOnHome = value; }
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
        public string WeddeingEventMetaTitle
        {
            get { return _WeddeingEventMetaTitle; }
            set { _WeddeingEventMetaTitle = value; }
        }
        public string WeddeingEventMetaKeywords
        {
            get { return _WeddeingEventMetaKeywords; }
            set { _WeddeingEventMetaKeywords = value; }
        }
        public string WeddeingEventMetaDescription
        {
            get { return _WeddeingEventMetaDescription; }
            set { _WeddeingEventMetaDescription = value; }
        }
        public string WeddeingEventMetaSchema
        {
            get { return _WeddeingEventMetaSchema; }
            set { _WeddeingEventMetaSchema = value; }
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
        public void SelectAllWeddeingEventData(System.Web.UI.WebControls.GridView GvWeddeingEventdataGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllWeddeingEventData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[2] = new SqlParameter("@WeddeingEventType", WeddeingEventType);
                ObjSql.GdBind_SNO(GvWeddeingEventdataGrid, "Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllWeddeingEventData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectWeddeingEventByWeddeingEventID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectWeddeingEventByWeddeingEventID");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventID", WeddeingEventID);
                return ObjSql.GetDatareaderProc("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectWeddeingEventByWeddeingEventID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public int SaveNewWeddeingEventData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[16];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewWeddeingEventData");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventType", WeddeingEventType);
                _SqlParameter[2] = new SqlParameter("@WeddeingEventName", WeddeingEventName);
                _SqlParameter[3] = new SqlParameter("@WeddeingEventAlias", WeddeingEventAlias);
                _SqlParameter[4] = new SqlParameter("@WeddeingEventDefaultImage", WeddeingEventDefaultImage);
                _SqlParameter[5] = new SqlParameter("@WeddeingEventLargeImage", WeddeingEventLargeImage);
                _SqlParameter[6] = new SqlParameter("@WeddeingEventVideoLink", WeddeingEventVideoLink);
                _SqlParameter[7] = new SqlParameter("@WeddeingEventSamllDescription", WeddeingEventSamllDescription);
                _SqlParameter[8] = new SqlParameter("@WeddeingEventDescription", WeddeingEventDescription);
                _SqlParameter[9] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[10] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[11] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[12] = new SqlParameter("@WeddeingEventMetaTitle", WeddeingEventMetaTitle);
                _SqlParameter[13] = new SqlParameter("@WeddeingEventMetaKeywords", WeddeingEventMetaKeywords);
                _SqlParameter[14] = new SqlParameter("@WeddeingEventMetaDescription", WeddeingEventMetaDescription);
                _SqlParameter[15] = new SqlParameter("@WeddeingEventMetaSchema", WeddeingEventMetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewWeddeingEventData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public int UpdateWeddeingEventByWeddeingEventID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[17];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateWeddeingEventByWeddeingEventID");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventType", WeddeingEventType);
                _SqlParameter[2] = new SqlParameter("@WeddeingEventName", WeddeingEventName);
                _SqlParameter[3] = new SqlParameter("@WeddeingEventAlias", WeddeingEventAlias);
                _SqlParameter[4] = new SqlParameter("@WeddeingEventDefaultImage", WeddeingEventDefaultImage);
                _SqlParameter[5] = new SqlParameter("@WeddeingEventLargeImage", WeddeingEventLargeImage);
                _SqlParameter[6] = new SqlParameter("@WeddeingEventVideoLink", WeddeingEventVideoLink);
                _SqlParameter[7] = new SqlParameter("@WeddeingEventSamllDescription", WeddeingEventSamllDescription);
                _SqlParameter[8] = new SqlParameter("@WeddeingEventDescription", WeddeingEventDescription);
                _SqlParameter[9] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[10] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[11] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[12] = new SqlParameter("@WeddeingEventMetaTitle", WeddeingEventMetaTitle);
                _SqlParameter[13] = new SqlParameter("@WeddeingEventMetaKeywords", WeddeingEventMetaKeywords);
                _SqlParameter[14] = new SqlParameter("@WeddeingEventMetaDescription", WeddeingEventMetaDescription);
                _SqlParameter[15] = new SqlParameter("@WeddeingEventMetaSchema", WeddeingEventMetaSchema);
                _SqlParameter[16] = new SqlParameter("@WeddeingEventID", WeddeingEventID);
                return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateWeddeingEventByWeddeingEventID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public int DeleteWeddeingEventByWeddeingEventID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteWeddeingEventByWeddeingEventID");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventID", WeddeingEventID);
                return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteWeddeingEventByWeddeingEventID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public int UpdateWeddeingEventDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateWeddeingEventDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventID", WeddeingEventID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateWeddeingEventDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_DineWineData", _SqlParameter);
        }
        #endregion

        #region Front End Data
        public DataSet SelectAllActiveWeddeingEventDataForHeader()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveWeddeingEventDataForHeader");
                return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveWeddeingEventDataForHeader()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public DataSet SelectAllActiveWeddeingEventDataForHomeDisplayOnHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveWeddeingEventDataForHomeDisplayOnHome");
                return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveWeddeingEventDataForHomeDisplayOnHome()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public DataSet SelectAllActiveWeddeingEventDataForListing()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveWeddeingEventDataForListing");
                return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveWeddeingEventDataForListing()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public int SelectActiveWeddeingEventIDbyURL(string WeddeingEventAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveWeddeingEventIDbyURL");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventAlias", WeddeingEventAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_WeddeingEventData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveWeddeingEventIDbyURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectActiveWeddeingEventDataByWeddeingEventID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveWeddeingEventDataByWeddeingEventID");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventID", WeddeingEventID);
                return ObjSql.GetDatareaderProc("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveWeddeingEventDataByWeddeingEventID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_WeddeingEventData", _SqlParameter);
        }

        public DataSet SelectTop10ActiveRealtedWeddeingEventData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop10ActiveRealtedWeddeingEventData");
                _SqlParameter[1] = new SqlParameter("@WeddeingEventID", WeddeingEventID);
                _SqlParameter[2] = new SqlParameter("@WeddeingEventType", WeddeingEventType);
                return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop10ActiveRealtedWeddeingEventData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_WeddeingEventData", _SqlParameter);
        }
        #endregion
    }
}
