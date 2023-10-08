using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class Contact
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public Contact()
        {
        }

        int _contactID = 0;
        string _firstName = string.Empty;
        string _lastName = string.Empty;
        string _emailID = string.Empty;
        string _phoneNo = string.Empty;
        DateTime _dateOfVisit = DateTime.UtcNow;
        string _city = string.Empty;
        string _message = string.Empty;
        string _Enquiryfor = string.Empty;
        string _enquiryType = string.Empty;
        string _pageName = string.Empty;
        DateTime _postedDate = DateTime.UtcNow;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;

        public int ContactID
        {
            get { return _contactID; }
            set { _contactID = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }       
        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }
        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }
        public DateTime DateOfVisit
        {
            get { return _dateOfVisit; }
            set { _dateOfVisit = value; }
        }
        public string Enquiryfor
        {
            get { return _Enquiryfor; }
            set { _Enquiryfor = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string EnquiryType
        {
            get { return _enquiryType; }
            set { _enquiryType = value; }
        }
        public string PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
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
        string _enquiryFor = string.Empty;

        public string EnquiryFor
        {
            get { return _enquiryFor; }
            set { _enquiryFor = value; }
        }

        #region AdminPanel

        public void SelectAllEnquiry(System.Web.UI.WebControls.GridView ContactGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEnquiry");
                _SqlParameter[1] = new SqlParameter("@EnquiryFor", EnquiryFor);
                _SqlParameter[2] = new SqlParameter("@EnquiryType", EnquiryType);
                ObjSql.GdBind_SNO(ContactGrid, "Mst_Sp_ContactUs", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEnquiry()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void SelectAllEnquiryFor(System.Web.UI.WebControls.DropDownList DdBlogCategory, string EnquiryFor, string EnquiryFor1)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEnquiryFor");
                ObjSql.DdBing(DdBlogCategory, "Mst_Sp_ContactUs", "EnquiryFor", "EnquiryFor", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdBlogCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void SelectRecent5Enquiry(System.Web.UI.WebControls.GridView ContactGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRecent5Enquiry");
                ObjSql.GdBind_SNO(ContactGrid, "Mst_Sp_ContactUs", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRecent5Enquiry()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void SelectRecent5InquiryForAdminHome(System.Web.UI.WebControls.GridView ContactGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRecent5InquiryForAdminHome");
                ObjSql.GdBind_SNO(ContactGrid, "Mst_Sp_ContactUs", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRecent5InquiryForAdminHome()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void SelectTop5SelectEnquiryDetailsBYEnquiryType(System.Web.UI.WebControls.GridView CustomerOrderGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop5SelectEnquiryDetailsBYEnquiryType");
                _SqlParameter[1] = new SqlParameter("@EnquiryType", EnquiryType);
                ObjSql.GdBind_SNO(CustomerOrderGrid, "Mst_Sp_ContactUs", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllCustomerOrderDetails()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectEnquiryByEnquiryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEnquiryByEnquiryID");
                _SqlParameter[1] = new SqlParameter("@ContactID", ContactID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ContactUs", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEnquiryByEnquiryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ContactUs", _SqlParameter);
        }

        public int DeleteEnquiryByEnquiryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteEnquiryByEnquiryID");
                _SqlParameter[1] = new SqlParameter("@ContactID", ContactID);
                return ObjSql.ExcuteProce("Mst_Sp_ContactUs", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteRecord()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ContactUs", _SqlParameter);
        }

        public DataSet ExportEmailIDsintoExcel()
        {
            SqlParameter[] arrparam = new SqlParameter[3];
            try
            {
                arrparam[0] = new SqlParameter("@Action", "ExportEmailIDsintoExcel");
                arrparam[1] = new SqlParameter("@EnquiryFor", EnquiryFor);
                arrparam[2] = new SqlParameter("@EnquiryType", EnquiryType);
                return ObjSql.GetDsetProc1("Mst_Sp_ContactUs", arrparam);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure BindEmailIDsintoExcel()", ex);
            }
            finally
            {
                arrparam = (SqlParameter[])null;
                ObjSql = (Connect)null;
                ObjEx = (ManageException)null;
            }

            return ObjSql.GetDsetProc1("Mst_Sp_Subscribe", arrparam);
        }


        public void SelectAllContractEnquiryTypeForDD(System.Web.UI.WebControls.DropDownList DdBlogCategory, string Type, string EnquiryFor)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllContractEnquiryTypeForDD");
                _SqlParameter[1] = new SqlParameter("@EnquiryType", EnquiryType);
                ObjSql.DdBing(DdBlogCategory, "Mst_Sp_ContactUs", "Type", "EnquiryFor", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllContractEnquiryTypeForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        #endregion AdminPanel

        #region Front Panel
        public int SaveNewEnquiry()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[10];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewEnquiry");
                _SqlParameter[1] = new SqlParameter("@FirstName", FirstName);
                _SqlParameter[2] = new SqlParameter("@EmailID", EmailID);
                _SqlParameter[3] = new SqlParameter("@PhoneNo", PhoneNo);
                _SqlParameter[4] = new SqlParameter("@DateOfVisit", DateOfVisit);
                _SqlParameter[5] = new SqlParameter("@EnquiryType", EnquiryType);
                _SqlParameter[6] = new SqlParameter("@Enquiryfor", Enquiryfor);
                _SqlParameter[7] = new SqlParameter("@Message", Message);                
                _SqlParameter[8] = new SqlParameter("@PageName", PageName);
                _SqlParameter[9] = new SqlParameter("@PostedDate", PostedDate);
                return ObjSql.ExcuteProce("Mst_Sp_ContactUs", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewEnquiry()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_Sp_ContactUs", _SqlParameter);
        }
        #endregion
    }
}
