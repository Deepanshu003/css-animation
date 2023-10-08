using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utility;
using System.Data;
namespace Component
{
    public  class EntertainmentData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public EntertainmentData()
        {
        }
        private int _EntertainmentID = 0;
        private string _EntertainmentName = string.Empty;
        private string _EntertainmentNameAlias = string.Empty;
        private int _categoryID = 0;
        private string _EntertainmentTiming = string.Empty;        
        //private int _feesAdult = 0;       
        //private int _feesCouples = 0;       
        //private int _feesChild = 0;        
        //private int _feesSeniorCitizen = 0;        
        private string _EntertainmentDefaultImage = string.Empty;
        private string _EntertainmentImage1 = string.Empty;
        private string _EntertainmentImage2 = string.Empty;
        private string _EntertainmentImage3 = string.Empty;
        private string _EntertainmentImage4 = string.Empty;
        private string _EntertainmentImage5 = string.Empty;
        private string _EntertainmentBannerImg = string.Empty;      
        private string _EntertainmentSmallDescription = string.Empty;
        private string _EntertainmentFullDescription = string.Empty;
        private string _EntertainmentVideoLink = string.Empty;
        private string _entertainmentVideo = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private int _displayOnHome = 0;
        private string _metaTitle = string.Empty;
        private string _metaKeyword = string.Empty;
        private string _metaDescription = string.Empty;
        private string _metaSchema = string.Empty;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _EntertainmentSearch = string.Empty;

        public int EntertainmentID
        {
            get { return _EntertainmentID; }
            set { _EntertainmentID = value; }
        }
        public string EntertainmentName
        {
            get { return _EntertainmentName; }
            set { _EntertainmentName = value; }
        }
        public string EntertainmentNameAlias
        {
            get { return _EntertainmentNameAlias; }
            set { _EntertainmentNameAlias = value; }
        }
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        public string EntertainmentTiming
        {
            get { return _EntertainmentTiming; }
            set { _EntertainmentTiming = value; }
        }
        //public int FeesAdult
        //{
        //    get { return _feesAdult; }
        //    set { _feesAdult = value; }
        //}
        //public int FeesCouples
        //{
        //    get { return _feesCouples; }
        //    set { _feesCouples = value; }
        //}
        //public int FeesChild
        //{
        //    get { return _feesChild; }
        //    set { _feesChild = value; }
        //}
        //public int FeesSeniorCitizen
        //{
        //    get { return _feesSeniorCitizen; }
        //    set { _feesSeniorCitizen = value; }
        //}
        public string EntertainmentDefaultImage
        {
            get { return _EntertainmentDefaultImage; }
            set { _EntertainmentDefaultImage = value; }
        }
        public string EntertainmentImage1
        {
            get { return _EntertainmentImage1; }
            set { _EntertainmentImage1 = value; }
        }
        public string EntertainmentImage2
        {
            get { return _EntertainmentImage2; }
            set { _EntertainmentImage2 = value; }
        }
        public string EntertainmentImage3
        {
            get { return _EntertainmentImage3; }
            set { _EntertainmentImage3 = value; }
        }
        public string EntertainmentImage4
        {
            get { return _EntertainmentImage4; }
            set { _EntertainmentImage4 = value; }
        }
        public string EntertainmentImage5
        {
            get { return _EntertainmentImage5; }
            set { _EntertainmentImage5 = value; }
        }
        public string EntertainmentBannerImg
        {
            get { return _EntertainmentBannerImg; }
            set { _EntertainmentBannerImg = value; }
        }
        public string EntertainmentSmallDescription
        {
            get { return _EntertainmentSmallDescription; }
            set { _EntertainmentSmallDescription = value; }
        }     
        public string EntertainmentFullDescription
        {
            get { return _EntertainmentFullDescription; }
            set { _EntertainmentFullDescription = value; }
        }
        public string EntertainmentVideoLink
        {
            get { return _EntertainmentVideoLink; }
            set { _EntertainmentVideoLink = value; }
        }
        public string EntertainmentVideo
        {
            get { return _entertainmentVideo; }
            set { _entertainmentVideo = value; }
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
        public int DisplayOnHome
        {
            get { return _displayOnHome; }
            set { _displayOnHome = value; }
        }
        public string MetaTitle
        {
            get { return _metaTitle; }
            set { _metaTitle = value; }
        }
        public string MetaKeyword
        {
            get { return _metaKeyword; }
            set { _metaKeyword = value; }
        }
        public string MetaDescription
        {
            get { return _metaDescription; }
            set { _metaDescription = value; }
        }
        public string MetaSchema
        {
            get { return _metaSchema; }
            set { _metaSchema = value; }
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
        public string EntertainmentSearch
        {
            get { return _EntertainmentSearch; }
            set { _EntertainmentSearch = value; }
        }

        #region Admin Panel
        public void SelectAllEntertainmentsData(System.Web.UI.WebControls.GridView GvEntertainmentGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEntertainmentsData");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[2] = new SqlParameter("@EntertainmentSearch", EntertainmentSearch);
                ObjSql.GdBind_SNO(GvEntertainmentGrid, "Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEntertainmentsData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void SelectEntertainmentForDD(System.Web.UI.WebControls.DropDownList DdEntertainment, string EntertainmentName, string EntertainmentID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentForDD");
                ObjSql.DdBing(DdEntertainment, "Mst_Sp_EntertainmentData", "EntertainmentName", "EntertainmentID", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectEntertainmentByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentByEntertainmentID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public int SaveNewEntertainmentData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[23];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewEntertainmentData");
                _SqlParameter[1] = new SqlParameter("@EntertainmentName", EntertainmentName);
                _SqlParameter[2] = new SqlParameter("@EntertainmentNameAlias", EntertainmentNameAlias);
                _SqlParameter[3] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[4] = new SqlParameter("@EntertainmentTiming", EntertainmentTiming);
                //_SqlParameter[5] = new SqlParameter("@FeesAdult", FeesAdult);
                //_SqlParameter[6] = new SqlParameter("@FeesCouples", FeesCouples);
                //_SqlParameter[7] = new SqlParameter("@FeesChild", FeesChild);
                //_SqlParameter[8] = new SqlParameter("@FeesSeniorCitizen", FeesSeniorCitizen);
                _SqlParameter[5] = new SqlParameter("@EntertainmentDefaultImage", EntertainmentDefaultImage);
                _SqlParameter[6] = new SqlParameter("@EntertainmentImage1", EntertainmentImage1);
                _SqlParameter[7] = new SqlParameter("@EntertainmentImage2", EntertainmentImage2);
                _SqlParameter[8] = new SqlParameter("@EntertainmentImage3", EntertainmentImage3);
                _SqlParameter[9] = new SqlParameter("@EntertainmentImage4", EntertainmentImage4);
                _SqlParameter[10] = new SqlParameter("@EntertainmentImage5", EntertainmentImage5);
                _SqlParameter[11] = new SqlParameter("@EntertainmentBannerImg", EntertainmentBannerImg);
                _SqlParameter[12] = new SqlParameter("@EntertainmentSmallDescription", EntertainmentSmallDescription);
                _SqlParameter[13] = new SqlParameter("@EntertainmentFullDescription", EntertainmentFullDescription);
                _SqlParameter[14] = new SqlParameter("@EntertainmentVideoLink", EntertainmentVideoLink);
                _SqlParameter[15] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[16] = new SqlParameter("@MetaKeyword", MetaKeyword);
                _SqlParameter[17] = new SqlParameter("@MetaDescription", MetaDescription);
                _SqlParameter[18] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[19] = new SqlParameter("@EntertainmentVideo", EntertainmentVideo);
                _SqlParameter[20] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[21] = new SqlParameter("@ActiveStatus", ActiveStatus);              
                _SqlParameter[22] = new SqlParameter("@DisplayOnHome", DisplayOnHome);              
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewEntertainmentData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public int UpdateEntertainmentByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[26];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[2] = new SqlParameter("@EntertainmentName", EntertainmentName);
                _SqlParameter[3] = new SqlParameter("@EntertainmentNameAlias", EntertainmentNameAlias);
                _SqlParameter[4] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[5] = new SqlParameter("@EntertainmentTiming", EntertainmentTiming);
                //_SqlParameter[6] = new SqlParameter("@FeesAdult", FeesAdult);
                //_SqlParameter[7] = new SqlParameter("@FeesCouples", FeesCouples);
                //_SqlParameter[8] = new SqlParameter("@FeesChild", FeesChild);
                //_SqlParameter[9] = new SqlParameter("@FeesSeniorCitizen", FeesSeniorCitizen);
                _SqlParameter[6] = new SqlParameter("@EntertainmentDefaultImage", EntertainmentDefaultImage);
                _SqlParameter[7] = new SqlParameter("@EntertainmentImage1", EntertainmentImage1);
                _SqlParameter[8] = new SqlParameter("@EntertainmentImage2", EntertainmentImage2);
                _SqlParameter[9] = new SqlParameter("@EntertainmentImage3", EntertainmentImage3);
                _SqlParameter[10] = new SqlParameter("@EntertainmentImage4", EntertainmentImage4);
                _SqlParameter[11] = new SqlParameter("@EntertainmentImage5", EntertainmentImage5);
                _SqlParameter[12] = new SqlParameter("@EntertainmentBannerImg", EntertainmentBannerImg);
                _SqlParameter[13] = new SqlParameter("@EntertainmentSmallDescription", EntertainmentSmallDescription);
                _SqlParameter[14] = new SqlParameter("@EntertainmentFullDescription", EntertainmentFullDescription);
                _SqlParameter[15] = new SqlParameter("@EntertainmentVideoLink", EntertainmentVideoLink);
                _SqlParameter[16] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[17] = new SqlParameter("@MetaKeyword", MetaKeyword);
                _SqlParameter[18] = new SqlParameter("@MetaDescription", MetaDescription);
                _SqlParameter[19] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[20] = new SqlParameter("@EntertainmentVideo", EntertainmentVideo);
                _SqlParameter[21] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[22] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[23] = new SqlParameter("@DisplayOnHome", DisplayOnHome);    
                _SqlParameter[24] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[25] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentByEntertainmentID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public int DeleteEntertainmentByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteEntertainmentByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteEntertainmentByEntertainmentID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public int UpdateEntertainmentsDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateEntertainmentsDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateEntertainmentsDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public DataSet SelectAllEntertainmentForAdmin()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEntertainmentForAdmin");
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEntertainmentForAdmin()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
        }
        #endregion

        #region Front End Data
        public DataSet SelectAllActiveEntertainmentForHeader()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveEntertainmentForHeader");
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveEntertainmentForHeader()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public DataSet SelectTop2ActiveEntertainmentForHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop2ActiveEntertainmentForHome");
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop2ActiveEntertainmentForHome()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public DataSet SelectTop2ActiveEntertainmentForAboutUs()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop2ActiveEntertainmentForAboutUs");
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop2ActiveEntertainmentForAboutUs()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public int SelectEntertainmentIDbyEntertainmentNameAlias(string EntertainmentNameAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEntertainmentIDbyEntertainmentNameAlias");
                _SqlParameter[1] = new SqlParameter("@EntertainmentNameAlias", EntertainmentNameAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_EntertainmentData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEntertainmentIDbyEntertainmentNameAlias()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectActiveEntertainmentDataByEntertainmentID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveEntertainmentDataByEntertainmentID");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveEntertainmentDataByEntertainmentID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_EntertainmentData", _SqlParameter);
        }

        public DataSet SelectAllActiveEntertainmentForRelated()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveEntertainmentForRelated");
                _SqlParameter[1] = new SqlParameter("@EntertainmentID", EntertainmentID);
                return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveEntertainmentForRelated()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_EntertainmentData", _SqlParameter);
        }
        #endregion
    }
}
