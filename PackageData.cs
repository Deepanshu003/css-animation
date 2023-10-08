using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class PackageData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public PackageData()
        {
        }

        private int _packageID = 0;        
        private string _packageTitle = string.Empty;        
        private string _packageTitleURL = string.Empty;       
        private string _packageTimming = string.Empty;        
        private string _packagePunchline = string.Empty;        
        private string _packageKidsPunchline1 = string.Empty;        
        private string _packageKidsPunchline2 = string.Empty;        
        private string _packageAdultsPunchline1 = string.Empty;
        private string _PackageImage1 = string.Empty;

        public string PackageImage1
        {
            get { return _PackageImage1; }
            set { _PackageImage1 = value; }
        }
        private string _PackageImage2 = string.Empty;

        public string PackageImage2
        {
            get { return _PackageImage2; }
            set { _PackageImage2 = value; }
        }
        private string _PackageImage3 = string.Empty;

        public string PackageImage3
        {
            get { return _PackageImage3; }
            set { _PackageImage3 = value; }
        }
        private string _PackageImage4 = string.Empty;

        public string PackageImage4
        {
            get { return _PackageImage4; }
            set { _PackageImage4 = value; }
        }
        int _KidsPrice = 0;
        int _AdultPrice = 0;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private int _displayOnHome = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        public int PackageID
        {
            get { return _packageID; }
            set { _packageID = value; }
        }
        public string PackageTitle
        {
            get { return _packageTitle; }
            set { _packageTitle = value; }
        }
        public string PackageTitleURL
        {
            get { return _packageTitleURL; }
            set { _packageTitleURL = value; }
        }
        public string PackageTimming
        {
            get { return _packageTimming; }
            set { _packageTimming = value; }
        }
        public string PackagePunchline
        {
            get { return _packagePunchline; }
            set { _packagePunchline = value; }
        }
        public string PackageKidsPunchline1
        {
            get { return _packageKidsPunchline1; }
            set { _packageKidsPunchline1 = value; }
        }
        public string PackageKidsPunchline2
        {
            get { return _packageKidsPunchline2; }
            set { _packageKidsPunchline2 = value; }
        }
        public string PackageAdultsPunchline1
        {
            get { return _packageAdultsPunchline1; }
            set { _packageAdultsPunchline1 = value; }
        }
        public int KidsPrice
        {
            get { return _KidsPrice; }
            set { _KidsPrice = value; }
        }
        public int AdultPrice
        {
            get { return _AdultPrice; }
            set { _AdultPrice = value; }
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
        public void SelectAllPackageByPackagePackageIDorNot(System.Web.UI.WebControls.GridView PackagePackageGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllPackageByPackagePackageIDorNot");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(PackagePackageGrid, "Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllPackageByPackagePackageIDorNot()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void SelectAllPackageForDD(System.Web.UI.WebControls.DropDownList DdBlogPackage, string PackageTitle, string PackageID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllPackageForDD");
                ObjSql.DdBing(DdBlogPackage, "Mst_Sp_PackageData", "PackageTitle", "PackageID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdBlogPackage()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectPackageDataByPackageID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectPackageDataByPackageID");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                return ObjSql.GetDatareaderProc("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetPackageData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_PackageData", _SqlParameter);
        }

        public int SaveNewPackageData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[19];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewPackageData");
                _SqlParameter[1] = new SqlParameter("@PackageTitle", PackageTitle);
                _SqlParameter[2] = new SqlParameter("@PackageTitleURL", PackageTitleURL);
                _SqlParameter[3] = new SqlParameter("@PackageTimming", PackageTimming);
                _SqlParameter[4] = new SqlParameter("@PackagePunchline", PackagePunchline);
                _SqlParameter[5] = new SqlParameter("@PackageKidsPunchline1", PackageKidsPunchline1);
                _SqlParameter[6] = new SqlParameter("@PackageKidsPunchline2", PackageKidsPunchline2);
                _SqlParameter[7] = new SqlParameter("@PackageAdultsPunchline1", PackageAdultsPunchline1);
                _SqlParameter[8] = new SqlParameter("@PackageImage1", PackageImage1);
                _SqlParameter[9] = new SqlParameter("@PackageImage2", PackageImage2);
                _SqlParameter[10] = new SqlParameter("@PackageImage3", PackageImage3);
                _SqlParameter[11] = new SqlParameter("@PackageImage4", PackageImage4);
                _SqlParameter[12] = new SqlParameter("@KidsPrice", KidsPrice);
                _SqlParameter[13] = new SqlParameter("@AdultPrice", AdultPrice);
                _SqlParameter[14] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[15] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[16] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[17] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[18] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewPackageData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
        }

        public int UpdatePackageDataByPackageID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[20];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePackageDataByPackageID");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                _SqlParameter[2] = new SqlParameter("@PackageTitle", PackageTitle);
                _SqlParameter[3] = new SqlParameter("@PackageTitleURL", PackageTitleURL);
                _SqlParameter[4] = new SqlParameter("@PackageTimming", PackageTimming);
                _SqlParameter[5] = new SqlParameter("@PackagePunchline", PackagePunchline);
                _SqlParameter[6] = new SqlParameter("@PackageKidsPunchline1", PackageKidsPunchline1);
                _SqlParameter[7] = new SqlParameter("@PackageKidsPunchline2", PackageKidsPunchline2);
                _SqlParameter[8] = new SqlParameter("@PackageAdultsPunchline1", PackageAdultsPunchline1);
                _SqlParameter[9] = new SqlParameter("@PackageImage1", PackageImage1);
                _SqlParameter[10] = new SqlParameter("@PackageImage2", PackageImage2);
                _SqlParameter[11] = new SqlParameter("@PackageImage3", PackageImage3);
                _SqlParameter[12] = new SqlParameter("@PackageImage4", PackageImage4);
                _SqlParameter[13] = new SqlParameter("@KidsPrice", KidsPrice);
                _SqlParameter[14] = new SqlParameter("@AdultPrice", AdultPrice);
                _SqlParameter[15] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[16] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[17] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[18] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[19] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdatePackageDataByPackageID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
        }

        public int UpdatePackageDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdatePackageDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdatePackageDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
        }

        public int DeletePackageByPackageID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletePackageByPackageID");
                _SqlParameter[1] = new SqlParameter("@PackageID", PackageID);
                return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletePackageByPackageID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_PackageData", _SqlParameter);
        }

        public DataSet SelectAllPackageDataPrice()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllPackageDataPrice");
                return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllPackageDataPrice()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
        }
        #endregion

        #region Front End Panel
        public DataSet SelectAllActivePackageDataPriceByDisplayOnHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActivePackageDataPriceByDisplayOnHome");
                return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActivePackageDataPriceByDisplayOnHome()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
        }

        public DataSet SelectAllActivePackageDataFroFrontEnd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActivePackageDataFroFrontEnd");
                return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActivePackageDataFroFrontEnd()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
        }

        public DataSet SelectAllActiveEntertainmentPackageForPackagePage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveEntertainmentPackageForPackagePage");
                return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveEntertainmentPackageForPackagePage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
        }

        public DataSet SelectAllActiveEntertainmentMealPackageForPackagePage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveEntertainmentMealPackageForPackagePage");
                return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveEntertainmentMealPackageForPackagePage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_PackageData", _SqlParameter);
        }
        #endregion
    }
}
