using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Utility;

namespace AapnoGharWeb
{
    [WebService(Namespace = "https://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AapnoGharService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region Log In with Facebook
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false)]
        public string SaveDatafaceBook(string fbID, string Name, string EmailFB)
        {
            //Username = noreplyAuthentication347@gmail.com
            //Password = hello@1234
            //App ID = 832658348022208
            //App secret = 2941892dfc2ed8e38a83b318cc76bf38
            CustomerData ObjCustomerData = new CustomerData();
            string UrlAndMSg = "";
            SqlDataReader SqlDataReaderFacebooklogin;
            int ret = 0;
            int retlog = 0;
            string strSTudentImage = string.Empty;
            ObjCustomerData.FBID = fbID;
            ObjCustomerData.CustomerEmailID = EmailFB;
            SqlDataReaderFacebooklogin = ObjCustomerData.SelectCustomerByCustomerFBID();
            if (SqlDataReaderFacebooklogin.HasRows)
            {
                while (SqlDataReaderFacebooklogin.Read())
                {
                    HttpContext.Current.Session["CustomerID"] = SqlDataReaderFacebooklogin["CustomerID"].ToString();
                    HttpContext.Current.Session["CustomerName"] = SqlDataReaderFacebooklogin["CustomerName"].ToString();
                    HttpContext.Current.Session["CustomerMobileNo"] = SqlDataReaderFacebooklogin["CustomerMobileNo"].ToString();
                    HttpContext.Current.Session["CustomerEmailID"] = SqlDataReaderFacebooklogin["CustomerEmailID"].ToString();
                    HttpContext.Current.Session["CustomerGender"] = SqlDataReaderFacebooklogin["CustomerGender"].ToString();
                    HttpContext.Current.Session["StateName"] = SqlDataReaderFacebooklogin["StateName"].ToString();
                    HttpContext.Current.Session["CityName"] = SqlDataReaderFacebooklogin["CityName"].ToString();
                    HttpContext.Current.Session["LocationName"] = SqlDataReaderFacebooklogin["LocationName"].ToString();
                    HttpContext.Current.Session["BillingAddress"] = SqlDataReaderFacebooklogin["BillingAddress"].ToString();
                    HttpContext.Current.Session["CustomerGSTNo"] = SqlDataReaderFacebooklogin["CustomerGSTNo"].ToString();
                    HttpContext.Current.Session["LastLoginDate"] = SqlDataReaderFacebooklogin["LastLoginDate"].ToString();
                    retlog = 1;
                }
                SqlDataReaderFacebooklogin.Dispose();
                SqlDataReaderFacebooklogin.Close();
                if (retlog == 1)
                {
                    if (HttpContext.Current.Session["GoToCartPage"] != null && (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null))
                    {
                        if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                        {
                            if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                                Session["LogIData"] = "Yes";
                        }
                        string GoToCartPage = HttpContext.Current.Session["GoToCartPage"].ToString();
                        HttpContext.Current.Session["GoToCartPage"] = null;
                        HttpContext.Current.Session.Remove("GoToCartPage");
                        UrlAndMSg = GoToCartPage.ToString();
                    }
                    else
                        UrlAndMSg = "/userdashboard";
                }
                else
                    UrlAndMSg = "2";
            }
            else
            {
                if (EmailFB.ToString() != "")
                {
                    ObjCustomerData.CustomerName = Name;
                    ObjCustomerData.CustomerMobileNo = "";
                    ObjCustomerData.CustomerEmailID = EmailFB;
                    ObjCustomerData.FBID = fbID;
                    ret = ObjCustomerData.SaveNewCustomerDataByFaceBook();
                    if (ret != -1)
                    {
                        SqlDataReader SqlReader;
                        ObjCustomerData.CustomerID = ret;
                        SqlReader = ObjCustomerData.SelectCustomerDataByCustomerIDOnlineOrder();
                        while (SqlReader.Read())
                        {
                            HttpContext.Current.Session["CustomerID"] = SqlReader["CustomerID"].ToString();
                            HttpContext.Current.Session["CustomerName"] = SqlReader["CustomerName"].ToString();
                            HttpContext.Current.Session["CustomerMobileNo"] = SqlReader["CustomerMobileNo"].ToString();
                            HttpContext.Current.Session["CustomerEmailID"] = SqlReader["CustomerEmailID"].ToString();
                            HttpContext.Current.Session["CustomerGender"] = SqlReader["CustomerGender"].ToString();
                            HttpContext.Current.Session["StateName"] = SqlReader["StateName"].ToString();
                            HttpContext.Current.Session["CityName"] = SqlReader["CityName"].ToString();
                            HttpContext.Current.Session["LocationName"] = SqlReader["LocationName"].ToString();
                            HttpContext.Current.Session["BillingAddress"] = SqlReader["BillingAddress"].ToString();
                            HttpContext.Current.Session["CustomerGSTNo"] = SqlReader["CustomerGSTNo"].ToString();
                            HttpContext.Current.Session["LastLoginDate"] = SqlReader["LastLoginDate"].ToString();
                            retlog = 1;
                        }
                        SqlReader.Close();
                        SqlReader.Dispose();
                        if (retlog == 1)
                        {
                            if (HttpContext.Current.Session["GoToCartPage"] != null && (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null))
                            {
                                if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                                {
                                    if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                                        Session["LogIData"] = "Yes";
                                }
                                string GoToCartPage = HttpContext.Current.Session["GoToCartPage"].ToString();
                                HttpContext.Current.Session["GoToCartPage"] = null;
                                HttpContext.Current.Session.Remove("GoToCartPage");
                                UrlAndMSg = GoToCartPage.ToString();
                            }
                            else
                                UrlAndMSg = "/";
                        }
                    }
                    else
                        UrlAndMSg = "2";
                }
                else
                    UrlAndMSg = "3";
            }

            return UrlAndMSg.ToString();
        }
        #endregion

        #region Log In with Google
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false)]
        public string SaveDataGoogle(string GoogleID, string Name, string Email)
        {
            //Username = noreply@aapnoghar.com
            //Password = Aapno#@1234
            //ClinetID = 324582137609-cjlmslpp1la30au25oohrs0q2o5l9f38.apps.googleusercontent.com
            //Secret = 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
            //API Key = IzaSyAW3uocb021D-_UbTwnKkZBxRxKYyOppoQ
            string UrlAndMSg = "";
            CustomerData ObjCustomerData = new CustomerData();
            int ret = 0;
            int retlog = 0;
            string strSTudentImage = string.Empty;
            SqlDataReader SqlDataReaderGooglelogin;
            try
            {
                ObjCustomerData.GoogleID = GoogleID;
                SqlDataReaderGooglelogin = ObjCustomerData.SelectCustomerByCustomerGoogleID();
                if (SqlDataReaderGooglelogin.HasRows)
                {
                    while (SqlDataReaderGooglelogin.Read())
                    {
                        HttpContext.Current.Session["CustomerID"] = SqlDataReaderGooglelogin["CustomerID"].ToString();
                        HttpContext.Current.Session["CustomerName"] = SqlDataReaderGooglelogin["CustomerName"].ToString();
                        HttpContext.Current.Session["CustomerMobileNo"] = SqlDataReaderGooglelogin["CustomerMobileNo"].ToString();
                        HttpContext.Current.Session["CustomerEmailID"] = SqlDataReaderGooglelogin["CustomerEmailID"].ToString();
                        HttpContext.Current.Session["CustomerGender"] = SqlDataReaderGooglelogin["CustomerGender"].ToString();
                        HttpContext.Current.Session["StateName"] = SqlDataReaderGooglelogin["StateName"].ToString();
                        HttpContext.Current.Session["CityName"] = SqlDataReaderGooglelogin["CityName"].ToString();
                        HttpContext.Current.Session["LocationName"] = SqlDataReaderGooglelogin["LocationName"].ToString();
                        HttpContext.Current.Session["BillingAddress"] = SqlDataReaderGooglelogin["BillingAddress"].ToString();
                        HttpContext.Current.Session["CustomerGSTNo"] = SqlDataReaderGooglelogin["CustomerGSTNo"].ToString();
                        HttpContext.Current.Session["LastLoginDate"] = SqlDataReaderGooglelogin["LastLoginDate"].ToString();
                        retlog = 1;
                    }
                    SqlDataReaderGooglelogin.Dispose();
                    SqlDataReaderGooglelogin.Close();
                    if (retlog == 1)
                    {
                        if (HttpContext.Current.Session["GoToCartPage"] != null)
                        {

                            if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                            {
                                if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                                    Session["LogIData"] = "Yes";
                            }
                            string GoToCartPage = HttpContext.Current.Session["GoToCartPage"].ToString();
                            HttpContext.Current.Session["GoToCartPage"] = null;
                            HttpContext.Current.Session.Remove("GoToCartPage");
                            UrlAndMSg = GoToCartPage.ToString();
                        }
                        else
                            UrlAndMSg = "/";
                    }
                    else
                        UrlAndMSg = "<div class='GetOpmnSmng scsfll' style='margin-top: 10px;'><p style='color: red;'>Please try agian after sometime.</p></div>";

                }
                else
                {
                    if (Name != "")
                        ObjCustomerData.CustomerName = Name;
                    else
                        ObjCustomerData.CustomerName = Name;
                    ObjCustomerData.CustomerMobileNo = "";
                    ObjCustomerData.CustomerEmailID = Email;
                    ObjCustomerData.GoogleID = GoogleID;
                    ret = ObjCustomerData.SaveNewCustomerDataUsingGoogle();
                    if (ret != -1)
                    {
                        SqlDataReader SqlReader;
                        ObjCustomerData.CustomerID = ret;
                        SqlReader = ObjCustomerData.SelectCustomerDataByCustomerIDOnlineOrder();
                        while (SqlReader.Read())
                        {
                            HttpContext.Current.Session["CustomerID"] = SqlReader["CustomerID"].ToString();
                            HttpContext.Current.Session["CustomerName"] = SqlReader["CustomerName"].ToString();
                            HttpContext.Current.Session["CustomerMobileNo"] = SqlReader["CustomerMobileNo"].ToString();
                            HttpContext.Current.Session["CustomerEmailID"] = SqlReader["CustomerEmailID"].ToString();
                            HttpContext.Current.Session["CustomerGender"] = SqlReader["CustomerGender"].ToString();
                            HttpContext.Current.Session["StateName"] = SqlReader["StateName"].ToString();
                            HttpContext.Current.Session["CityName"] = SqlReader["CityName"].ToString();
                            HttpContext.Current.Session["LocationName"] = SqlReader["LocationName"].ToString();
                            HttpContext.Current.Session["BillingAddress"] = SqlReader["BillingAddress"].ToString();
                            HttpContext.Current.Session["CustomerGSTNo"] = SqlDataReaderGooglelogin["CustomerGSTNo"].ToString();
                            HttpContext.Current.Session["LastLoginDate"] = SqlReader["LastLoginDate"].ToString();
                            retlog = 1;
                        }
                        SqlReader.Close();
                        SqlReader.Dispose();
                        if (retlog == 1)
                        {
                            if (HttpContext.Current.Session["GoToCartPage"] != null && (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null))
                            {
                                if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                                {
                                    if (HttpContext.Current.Session["dtCartRoom"] != null || HttpContext.Current.Session["dtCart"] != null)
                                        Session["LogIData"] = "Yes";
                                }
                                string GoToCartPage = HttpContext.Current.Session["GoToCartPage"].ToString();
                                HttpContext.Current.Session["GoToCartPage"] = null;
                                HttpContext.Current.Session.Remove("GoToCartPage");
                                UrlAndMSg = GoToCartPage.ToString();
                            }
                            else
                                UrlAndMSg = "/userdashboard";
                        }
                    }
                    else
                        UrlAndMSg = "2";
                }
            }
            catch (Exception ex)
            {
                return "2";
            }
            return UrlAndMSg.ToString();
        }
        #endregion
    }
}
