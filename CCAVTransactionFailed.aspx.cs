using Component;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AapnoGharWeb
{
    public partial class CCAVTransactionFailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Payment"] != null)
                    ltrMsg.Text = Request.QueryString["Payment"];

                if (Request.QueryString["AapnoGhar"] != null && Request.QueryString["AapnoGhar"].ToString() != "")
                {
                    SqlDataReader SqlReaderOTP;
                    CustomerData ObjCustomerData = new CustomerData();
                    int CustomerID = Convert.ToInt32(Request.QueryString["AapnoGhar"]);
                    ObjCustomerData.CustomerID = CustomerID;
                    SqlReaderOTP = ObjCustomerData.SelectCustomerDataByCustomerIDOnlineOrder();
                    while (SqlReaderOTP.Read())
                    {
                        Session["CustomerID"] = SqlReaderOTP["CustomerID"].ToString();
                        Session["CustomerName"] = SqlReaderOTP["CustomerName"].ToString();
                        Session["CustomerMobileNo"] = SqlReaderOTP["CustomerMobileNo"].ToString();
                        Session["CustomerEmailID"] = SqlReaderOTP["CustomerEmailID"].ToString();
                        Session["CustomerGender"] = SqlReaderOTP["CustomerGender"].ToString();
                        Session["StateName"] = SqlReaderOTP["StateName"].ToString();
                        Session["CityName"] = SqlReaderOTP["CityName"].ToString();
                        Session["LocationName"] = SqlReaderOTP["LocationName"].ToString();
                        Session["BillingAddress"] = SqlReaderOTP["BillingAddress"].ToString();
                        Session["LastLoginDate"] = SqlReaderOTP["LastLoginDate"].ToString();
                        Session["CustomerGSTNo"] = SqlReaderOTP["CustomerGSTNo"].ToString();
                    }
                    SqlReaderOTP.Dispose();
                    SqlReaderOTP.Dispose();
                    ObjCustomerData = null;
                }

                AddMetaTags();
            }
        }

        private void AddMetaTags()
        {
            Page.Title = "Transaction Failed | Luxury Hotels and Resorts, Accommodation in Meerut";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "Bravura Gold Resort, Luxury Hotels in Meerut,Resorts in Meerut, Hotels in Meerut, Accommodation in Meerut";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "Bravura Gold Resort: A Luxury Hotels and Resorts, Accommodation in Meerut";
            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Transaction Failed | Luxury Hotels and Resorts, Accommodation in Meerut";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "Bravura Gold Resort: A Luxury Hotels and Resorts, Accommodation in Meerut";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "Bravura Gold Resort: A Luxury Hotels and Resorts, Accommodation in Meerut";
            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Transaction Failed | Luxury Hotels and Resorts, Accommodation in Meerut";

            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri;
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri;

            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri;
        }
    }
}