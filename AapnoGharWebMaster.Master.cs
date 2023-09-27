using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Component;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text;
using Utility;
using System.Data;
using System.Net;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;

namespace AapnoGharWeb
{
    public partial class AapnoGharWebMaster : System.Web.UI.MasterPage
    {
        CustomerData ObjCustomerData = new CustomerData();
        EntertainmentBookData ObjEntertainmentBookData = new EntertainmentBookData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["BookingCart"] != null && Session["BookingCart"].ToString() == "Yes")
                //{
                //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //    sb.Append("<script type = 'text/javascript'>");
                //    sb.Append("$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.Popup_Book_ParkModel'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');");
                //    sb.Append("</script>");
                //    Literal1.Text = sb.ToString();
                //    sb.Clear();
                //    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.Popup_Book_ParkModel'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", false);
                //    Session["BookingCart"] = null;
                //}

                if (Session["CustomerID"] != null)
                {
                    //class='current'
                    hdnPageID.Value = "1";
                    txtUserNameFroBooking.Text = Session["CustomerName"].ToString();
                    txtUserEmailID.Text = Session["CustomerEmailID"].ToString();
                    txtUserPhoneNo.Text = Session["CustomerMobileNo"].ToString();
                    txtUserGSTNo.Text = Session["CustomerGSTNo"].ToString();
                    if (txtUserEmailID.Text != "")
                        txtUserEmailID.Enabled = false;
                    if (txtUserNameFroBooking.Text != "")
                        txtUserNameFroBooking.Enabled = false;
                    if (txtUserPhoneNo.Text != "")
                        txtUserPhoneNo.Enabled = false;
                    if (txtUserGSTNo.Text != "")
                        txtUserGSTNo.Enabled = false;
                    ltrAccount.Text = "<li class='has-dropdown'> <a href='/userdashboard' class='userDash-Dropdwon'> <span class='span_login'>My Account</span> </a> <div class='dorp_down_Dash'> <ul> <li><a href='/userdashboard-profile'>My Profile</a></li><li><a href='userdashboard-stay-room'>My Rooms & Suites</a></li><li><a href='/userdashboard-activities'>My Activities</a></li><li><a href='/log-out'>Logout</a></li></ul> </div></li>";
                }
                else
                {
                    hdnPageID.Value = "0";
                    ltrAccount.Text = "<li class='has-dropdown'><a class='model-open' data-model='.login_model' href='javascript:void(0)'>Sign up/Log in</a></li>";
                }
                BindAllActiveRoomForMenu();
                BindAllActiveWeddeingEventDataForHeader();
                BindAllActiveEntertainmentForHeader();
                BindAllActiveCouponCode();
                if (HttpContext.Current.Session["dtCartRoom"] != null)
                    BindRptrCartList();
                else
                    ltrCartItem.Text = "<li class='cart' data-val='0'><a href='/room-booking-cart' ><img src='/assets/icons/shopping-cart.png' /></a></li>";
            }
            BtnLogInwithOTP.Attributes.Add("OnClick", "return PageCheckLogInWithEmailOrMobileNoOtp();");
            BtnVerfyOtp.Attributes.Add("OnClick", "return PageLogInCheckVrifyOTP();");
            btnCustomerBookingPayNow.Attributes.Add("OnClick", "return PageCheckCustomerBookingPayNowMaster();");
            btnQuickSubmit.Attributes.Add("OnClick", "return PageCheckQuickInquiryMaster();");
        }

        #region Header, Footer & Menu Data

        #region Rooms
        private void BindAllActiveRoomForMenu()
        {
            RoomData ObjRoomData = new RoomData();
            DataSet ds = new DataSet();
            ds = ObjRoomData.SelectAllActiveRoomForMenu();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRoomForMenuHrader.DataSource = ds.Tables[0];
                RptrRoomForMenuHrader.DataBind();
                RptrRoomForMenuHrader.Visible = true;
                pnlRoomForheader.Visible = true;

                RptrRoomForMenu.DataSource = ds.Tables[0];
                RptrRoomForMenu.DataBind();
                RptrRoomForMenu.Visible = true;
                pnlRoomForMenu.Visible = true;
            }
            else
            {
                RptrRoomForMenuHrader.Visible = false;
                pnlRoomForheader.Visible = false;

                RptrRoomForMenu.Visible = false;
                pnlRoomForMenu.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomData = null;
        }
        #endregion

        #region Celebrate
        private void BindAllActiveWeddeingEventDataForHeader()
        {
            WeddeingEventData ObjWeddeingEventData = new WeddeingEventData();
            DataSet ds = new DataSet();
            ds = ObjWeddeingEventData.SelectAllActiveWeddeingEventDataForHeader();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt0 = ds.Tables[0].DefaultView.ToTable(true, "WeddeingEventType");
                RptrWeddeingEventType.DataSource = dt0;
                RptrWeddeingEventType.DataBind();
                RptrWeddeingEventType.Visible = true;

                foreach (RepeaterItem item in RptrWeddeingEventType.Items)
                {
                    HiddenField hndWeddeingEventType = (HiddenField)item.FindControl("hndWeddeingEventType");
                    Repeater RptrWeddeingEventData = (Repeater)item.FindControl("RptrWeddeingEventData");
                    DataTable dt1 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "WeddeingEventType='" + hndWeddeingEventType.Value + "'";
                    dt1 = dataView.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        RptrWeddeingEventData.DataSource = dt1;
                        RptrWeddeingEventData.DataBind();
                        RptrWeddeingEventData.Visible = true;
                    }
                    else
                        RptrWeddeingEventData.Visible = false;

                }
                PanleCelevCelebrate.Visible = true;

                RptrWeddeingEventTypeMenu.DataSource = dt0;
                RptrWeddeingEventTypeMenu.DataBind();
                RptrWeddeingEventTypeMenu.Visible = true;

                foreach (RepeaterItem item in RptrWeddeingEventTypeMenu.Items)
                {
                    HiddenField hndWeddeingEventType = (HiddenField)item.FindControl("hndWeddeingEventType");
                    Repeater RptrWeddeingEventData = (Repeater)item.FindControl("RptrWeddeingEventData");
                    DataTable dt1 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "WeddeingEventType='" + hndWeddeingEventType.Value + "'";
                    dt1 = dataView.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        RptrWeddeingEventData.DataSource = dt1;
                        RptrWeddeingEventData.DataBind();
                        RptrWeddeingEventData.Visible = true;
                    }
                    else
                        RptrWeddeingEventData.Visible = false;

                }

            }
            else
            {
                RptrWeddeingEventType.Visible = false;
                PanleCelevCelebrate.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjWeddeingEventData = null;
        }
        #endregion

        #region Entertainment
        private void BindAllActiveEntertainmentForHeader()
        {
            EntertainmentData ObjEntertainmentData = new EntertainmentData();
            DataSet ds = new DataSet();
            ds = ObjEntertainmentData.SelectAllActiveEntertainmentForHeader();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrEntertainment.DataSource = ds.Tables[0];
                RptrEntertainment.DataBind();
                RptrEntertainment.Visible = true;
                pnlEntertainment.Visible = true;

                RptrEntertainmentMenu.DataSource = ds.Tables[0];
                RptrEntertainmentMenu.DataBind();
                RptrEntertainmentMenu.Visible = true;
                PnlEntertainmentMenu.Visible = true;

                DataView dataView4 = new DataView(ds.Tables[0]);
                dataView4.RowFilter = "DisplayOnHome=1";
                DataTable dt4 = dataView4.ToTable(true, "EntertainmentName", "EntertainmentNameAlias", "EntertainmentImage4");
                if (dt4.Rows.Count > 0)
                {
                    RptrEntertainmentForFooter.DataSource = dt4;
                    RptrEntertainmentForFooter.DataBind();
                    RptrEntertainmentForFooter.Visible = true;

                    RptrEntertainmentForFooter1.DataSource = dt4;
                    RptrEntertainmentForFooter1.DataBind();
                    RptrEntertainmentForFooter1.Visible = true;
                }
                else
                {
                    RptrEntertainmentForFooter.Visible = false;
                    RptrEntertainmentForFooter1.Visible = false;
                }

                dataView4.Dispose();
                dt4.Dispose();
                dt4.Clear();
            }
            else
            {
                RptrEntertainment.Visible = false;
                pnlEntertainment.Visible = false;

                RptrEntertainmentMenu.Visible = false;
                PnlEntertainmentMenu.Visible = false;

                RptrEntertainmentForFooter.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentData = null;
        }
        #endregion

        #endregion

        #region Coupons Data
        private void BindAllActiveCouponCode()
        {
            CouponData ObjCouponData = new CouponData();
            DataSet ds = new DataSet();
            ds = ObjCouponData.SelectAllActiveCouponCode();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrCouponsData.DataSource = ds.Tables[0];
                RptrCouponsData.DataBind();
                RptrCouponsData.Visible = true;
                pnlCouponsData.Visible = true;
                pnlCouponsData1.Visible = true;
            }
            else
            {
                RptrCouponsData.Visible = false;
                pnlCouponsData.Visible = false;
                pnlCouponsData1.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
        }
        #endregion

        #region Log In & Signup Of Customer
        protected void BtnLogInwithOTP_Click(object sender, EventArgs e)
        {
            if (txtLogInMobileNoOrEmailID.Text != "")
            {
                bool containsLetter = Regex.IsMatch(txtLogInMobileNoOrEmailID.Text.TrimStart(), "[A-Z]");
                string email = txtLogInMobileNoOrEmailID.Text.TrimStart();
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                int ret = 0;
                if (match.Success)
                {
                    ObjCustomerData.CustomerMobileNo = "";
                    ObjCustomerData.CustomerEmailID = txtLogInMobileNoOrEmailID.Text;
                    ret = ObjCustomerData.CheckUserLoginOrSignupWithMobileNoOrCustomerEmailID();
                    if (ret == 1)
                    {
                        SendOtpToUser();
                        ltrWrongOtp.Text = "<div class='GetOpmnSmng scsfll'><p style='color: green;'>We Sent a Email With a 6-digit code to <small>" + txtLogInMobileNoOrEmailID.Text + "</small>.</p></div>";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login-otp-form').slideDown();$('.login_form').slideUp();", true);
                    }
                    else if (ret == 2)
                    {
                        SendOtpToUser();
                        ltrWrongOtp.Text = "<div class='GetOpmnSmng scsfll'><p style='color: green;'>We Sent a Email With a 6-digit code to <small>" + txtLogInMobileNoOrEmailID.Text + "</small>.</p></div>";
                        Session["UserSignUP"] = "Yes";
                        PnlUserName.Visible = true;
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login-otp-form').slideDown();$('.login_form').slideUp();", true);
                    }
                    else
                        ltrLoginMsg.Text = "<div class='otp_msg'><p style='color:red;'>Please try again after some time, or try to an other email.</p></div>";
                }
                else
                {
                    ObjCustomerData.CustomerEmailID = "";
                    ObjCustomerData.CustomerMobileNo = txtLogInMobileNoOrEmailID.Text;
                    ret = ObjCustomerData.CheckUserLoginOrSignupWithMobileNoOrCustomerEmailID();
                    if (ret == 1)
                    {
                        SendOTPMobileToUser(txtLogInMobileNoOrEmailID.Text);
                        ltrWrongOtp.Text = "<div class='otp_msg'><p style='color: green;'>OTP Sent on <small>" + txtLogInMobileNoOrEmailID.Text + "</small></p></div>";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login-otp-form').slideDown();$('.login_form').slideUp();", true);
                    }
                    else if (ret == 2)
                    {
                        SendOTPMobileToUser(txtLogInMobileNoOrEmailID.Text);
                        ltrWrongOtp.Text = "<div class='otp_msg'><p style='color: green;'>OTP Sent on <small>" + txtLogInMobileNoOrEmailID.Text + "</small></p></div>";
                        Session["UserSignUP"] = "Yes";
                        PnlUserName.Visible = true;
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login-otp-form').slideDown();$('.login_form').slideUp();", true);
                    }
                    else
                        ltrLoginMsg.Text = "<div class='otp_msg'><p style='color: red;'>Please try again after some time, or try to an other mobile no.</p></div>";
                }
            }
            else
                ltrLoginMsg.Text = "<div class='otp_msg'><p style='color: red;'>Enter mobile number/email id.</p></div>";
        }

        protected void BtnVerfyOtp_Click(object sender, EventArgs e)
        {
            int ret = 0;
            int ret1 = 0;
            string Otp = txtLogInOtp.Text;
            SqlDataReader SqlReaderOTP;
            bool containsLetter = Regex.IsMatch(txtLogInMobileNoOrEmailID.Text.TrimStart(), "[A-Z]");
            string email = txtLogInMobileNoOrEmailID.Text.TrimStart();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            //Session["OtpCode"] = "123456";
            if (Otp == Session["OtpCode"].ToString())
            {
                if (Session["UserSignUP"] != null)
                {
                    if (match.Success)
                    {
                        ObjCustomerData.FBID = hdnLogInWithId.Value;
                        ObjCustomerData.CustomerName = txtUserOptName.Text;
                        ObjCustomerData.CustomerMobileNo = "";
                        ObjCustomerData.CustomerEmailID = txtLogInMobileNoOrEmailID.Text;
                        ObjCustomerData.CustomerPassword = Session["OtpCode"].ToString().TrimEnd().TrimStart() + "VSBL";
                        ret1 = ObjCustomerData.UserSignupWithMobileNoOrCustomerEmailID();
                    }
                    else
                    {
                        ObjCustomerData.FBID = hdnLogInWithId.Value;
                        ObjCustomerData.CustomerName = txtUserOptName.Text;
                        ObjCustomerData.CustomerEmailID = "";
                        ObjCustomerData.CustomerMobileNo = txtLogInMobileNoOrEmailID.Text;
                        ObjCustomerData.CustomerPassword = Session["OtpCode"].ToString().TrimEnd().TrimStart() + "VSBL";
                        ret1 = ObjCustomerData.UserSignupWithMobileNoOrCustomerEmailID();
                    }
                }
                if (match.Success)
                {
                    ObjCustomerData.CustomerMobileNo = "";
                    ObjCustomerData.CustomerEmailID = txtLogInMobileNoOrEmailID.Text;
                    SqlReaderOTP = ObjCustomerData.SelectCustomerDataByCustomerMobileNoOrCustomerEmailID();
                }
                else
                {
                    ObjCustomerData.CustomerEmailID = "";
                    ObjCustomerData.CustomerMobileNo = txtLogInMobileNoOrEmailID.Text;
                    SqlReaderOTP = ObjCustomerData.SelectCustomerDataByCustomerMobileNoOrCustomerEmailID();

                }
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
                    Session["CustomerCompanyName"] = SqlReaderOTP["CustomerCompanyName"].ToString();
                    Session["CustomerGSTNo"] = SqlReaderOTP["CustomerGSTNo"].ToString();
                    Session["LastLoginDate"] = SqlReaderOTP["LastLoginDate"].ToString();
                    if (Session["UserSignUP"] != null)
                    {
                        if (Session["UserSignUP"].ToString() == "Yes")
                        {
                            if (match.Success)
                            {
                                SendMailToUserSignUP();
                                Session["UserSignUP"] = null;
                            }
                            else
                            {
                                SendMsg(Session["CustomerMobileNo"].ToString());
                                Session["UserSignUP"] = null;
                            }
                        }
                    }
                    ret = 1;
                }
                SqlReaderOTP.Dispose();
                SqlReaderOTP.Close();
                if (ret == 1)
                {
                    hdnPageID.Value = "1";
                    if (hdnPackageID.Value != "0")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.Popup_Book_ParkModel'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", true);
                        //Session["BookingCart"] = "Yes";
                        //Response.Redirect(Convert.ToString(Request.Url));
                        txtUserNameFroBooking.Text = Session["CustomerName"].ToString();
                        txtUserEmailID.Text = Session["CustomerEmailID"].ToString();
                        txtUserPhoneNo.Text = Session["CustomerMobileNo"].ToString();
                        txtUserGSTNo.Text = Session["CustomerGSTNo"].ToString();
                        if (txtUserEmailID.Text != "")
                            txtUserEmailID.Enabled = false;
                        if (txtUserNameFroBooking.Text != "")
                            txtUserNameFroBooking.Enabled = false;
                        if (txtUserPhoneNo.Text != "")
                            txtUserPhoneNo.Enabled = false;
                        if (txtUserGSTNo.Text != "")
                            txtUserGSTNo.Enabled = false;
                    }
                    else if (Session["dtCartRoom"] != null)
                    {
                        Response.Redirect("/room-booking-guest");
                    }
                    else
                        Response.Redirect("/userdashboard");

                }
                else
                {
                    ltrWrongOtp.Text = "<div class='otp_msg'><p style='color: red;'>Please try again after sometime.</span></p></div>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login-otp-form').slideDown();$('.login_form').slideUp();", true);
                }
            }
            else
            {
                ltrWrongOtp.Text = "<div class='otp_msg'><p style='color: red;'>Invalid OTP - Please Try again.</span></p></div>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login-otp-form').slideDown();$('.login_form').slideUp();", true);
            }
        }

        #region Msg
        public void SendOTPMobileToUser(string Mobile)
        {
            ManageException ObjEx = new ManageException();
            Session["OtpCode"] = CreateRandomPassword(6);
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                WebClient client = new WebClient();
                string baseurl = "http://125.16.147.178/VoicenSMS/webresources/CreateSMSCampaignGet?ukey=I1aBFeA7tKwwAfw2DJ3rQHFAH&msisdn=" + Mobile + "&language=0&credittype=7&senderid=APOGHR&templateid=0&message=Hi, the OTP for logging in on AapnoGhar! is " + Session["OtpCode"] + " It is valid for the next 15 mins. Do not share your OTP with anyone - AapnoGhar.!&filetype=2";
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string ResponseID = reader.ReadToEnd();
                data.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewCustomerData()", ex);
            }
        }

        public void SendMsg(string Mobile)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            WebClient client = new WebClient();
            string baseurl = "http://125.16.147.178/VoicenSMS/webresources/CreateSMSCampaignGet?ukey=I1aBFeA7tKwwAfw2DJ3rQHFAH&msisdn=" + Mobile + "&language=0&credittype=7&senderid=APOGHR&templateid=0&message=You have successfully signed up with%C2%A0AapnoGhar. Welcome to the%C2%A0AapnoGhar!&filetype=2";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string ResponseID = reader.ReadToEnd();
            data.Close();
            reader.Close();
        }
        #endregion

        #region Mail
        private void SendOtpToUser()
        {
            Mail ObjMail = new Mail();
            try
            {
                Session["OtpCode"] = CreateRandomPassword(6);
                ObjMail.MailTo = txtLogInMobileNoOrEmailID.Text;
                ObjMail.Title = "AapnoGhar";
                ObjMail.Subject = "AapnoGhar OTP for login";
                ObjMail.Body = this.GetBodyOtpToUser(Session["OtpCode"].ToString());
                if (txtLogInMobileNoOrEmailID.Text == "test@ibrandox.com")
                    ObjMail.SendMail();
                else
                    ObjMail.SendMailForOTP();
            }
            catch (Exception ex)
            {
                Response.Redirect("/something-went-wrong?mailerror=" + ex.Message);
            }
        }

        private string GetBodyOtpToUser(string OtpCode)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<!DOCTYPE html>");
            str.Append("<html>");
            str.Append("<head>");
            str.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>");
            str.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
            str.Append("<title>Thank you mail</title>");
            str.Append("</head>");
            str.Append("<body style='background: #fff;;'>");
            str.Append("<div style='border:1px solid #172061;width:700px;'>");
            str.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%' style='padding:10px 20px;'>");

            str.Append("<tr>");
            str.Append("<td style='width:40%;'><a href='https://www.aapnoghar.com/' title='logo'><img class='logo' src='https://www.aapnoghar.com/assets/icons/email-logo.png' width='81' alt='logo' /></a></td>");
            str.Append("<td style='color:#000;float:right;padding:15px 5px;'><a href='mailto:info@aapnoghar.com' style='color:#363636;text-decoration:none;font-size:13px;'>Email ID : info@aapnoghar.com</a><br><a href='tel:+917666779997' style='color:#363636;text-decoration:none;font-size:13px;'>Phone : +91-7666779997</a></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan='2' style='color:#000;padding:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>");
            str.Append("<table border='0' cellspacing='0' cellspacing='2' width='100%'>");
            str.Append("<tr>");
            str.Append("<td valign='top' align='left'>");
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi,<br /><br /></p>");
            str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi, the OTP for logging in on AapnoGhar! is " + OtpCode + " It is valid for the next 15 mins. Do not share your OTP with anyone - AapnoGhar.</p>");
            str.Append("<p style='color:#363636;padding-top:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><b>Warm Regards</b>,<br><b>AapnoGhar</b></p>");
            str.Append("</td>");
            str.Append("</tr>");
            str.Append("</table>");

            str.Append("</td>");
            str.Append("</tr>");

            str.Append("</table>");

            str.Append("<div style='background:#172061;border-left:solid #666 5px;border-right:solid #666 5px;color:#fff;text-align:center;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><h2 style='color:#fff;letter-spacing:4px;font:normal 22px/1 Verdana, Helvetica;padding:8px 0px;text-align:center;'><a href='https://www.aapnoghar.com' style='color:#fff;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>www.aapnoghar.com</a></h2></div>");
            str.Append("</div>");
            str.Append("</body>");
            str.Append("</html>");
            return str.ToString();
        }

        private void SendMailToUserSignUP()
        {
            Mail ObjMail = new Mail();
            try
            {
                ObjMail.MailTo = txtLogInMobileNoOrEmailID.Text;
                ObjMail.Title = "AapnoGhar";
                ObjMail.Subject = "Thank you for sign up";
                ObjMail.Body = this.GetBodyUserSignUP();
                //ObjMail.SendMail();
                ObjMail.SendMailForOTP();
            }
            catch (Exception ex)
            {
                ltrWrongOtp.Text = "<p>Error-a- " + ex.Message.ToString() + "</p>";
            }
        }

        private string GetBodyUserSignUP()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<!DOCTYPE html>");
            str.Append("<html>");
            str.Append("<head>");
            str.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>");
            str.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
            str.Append("<title>Thank you mail</title>");
            str.Append("</head>");
            str.Append("<body style='background: #fff;;'>");
            str.Append("<div style='border:1px solid #172061;width:700px;'>");
            str.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%' style='padding:10px 20px;'>");

            str.Append("<tr>");
            str.Append("<td style='width:40%;'><a href='https://www.aapnoghar.com/' title='logo'><img class='logo' src='https://www.aapnoghar.com/assets/icons/email-logo.png' width='81' alt='logo' /></a></td>");
            str.Append("<td style='color:#000;float:right;padding:15px 5px;'><a href='mailto:info@aapnoghar.com' style='color:#363636;text-decoration:none;font-size:13px;'>Email ID : info@aapnoghar.com</a><br><a href='tel:+917666779997' style='color:#363636;text-decoration:none;font-size:13px;'>Phone : +91-7666779997</a></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan='2' style='color:#000;padding:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>");
            str.Append("<table border='0' cellspacing='0' cellspacing='2' width='100%'>");
            str.Append("<tr>");
            str.Append("<td valign='top' align='left'>");
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + txtUserOptName.Text + ",<br /><br /></p>");
            str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>You have successfully signed up with AapnoGhar. Welcome to the AapnoGhar family!</p>");
            str.Append("<p style='color:#363636;padding-top:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><b>Warm Regards</b>,<br><b>AapnoGhar</b></p>");
            str.Append("</td>");
            str.Append("</tr>");
            str.Append("</table>");

            str.Append("</td>");
            str.Append("</tr>");

            str.Append("</table>");

            str.Append("<div style='background:#172061;border-left:solid #666 5px;border-right:solid #666 5px;color:#fff;text-align:center;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><h2 style='color:#fff;letter-spacing:4px;font:normal 22px/1 Verdana, Helvetica;padding:8px 0px;text-align:center;'><a href='https://www.aapnoghar.com' style='color:#fff;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>www.aapnoghar.com</a></h2></div>");
            str.Append("</div>");
            str.Append("</body>");
            str.Append("</html>");
            return str.ToString();
        }
        #endregion

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        #endregion

        #region Pacakge Buy
        protected void btnCustomerBookingPayNow_Click(object sender, EventArgs e)
        {
            int ret = 0;
            if (Session["CustomerID"] != null)
            {
                int retData = 1;
                if ((HttpContext.Current.Session["CustomerName"].ToString() != txtUserNameFroBooking.Text) || (HttpContext.Current.Session["CustomerMobileNo"].ToString() != txtUserPhoneNo.Text) || (HttpContext.Current.Session["CustomerEmailID"].ToString() != txtUserEmailID.Text) || (HttpContext.Current.Session["CustomerGSTNo"].ToString() != txtUserGSTNo.Text))
                {
                    CustomerData ObjCustomerData = new CustomerData();
                    ObjCustomerData.CustomerID = Convert.ToInt16(HttpContext.Current.Session["CustomerID"]);
                    ObjCustomerData.CustomerName = txtUserNameFroBooking.Text;
                    ObjCustomerData.CustomerEmailID = txtUserEmailID.Text;
                    ObjCustomerData.CustomerMobileNo = txtUserPhoneNo.Text;
                    ObjCustomerData.CustomerGSTNo = txtUserGSTNo.Text;
                    retData = ObjCustomerData.UpdateCustomerPersonalinformationByCustomerIDFromOrder();
                    if (retData == 1)
                    {
                        HttpContext.Current.Session["CustomerName"] = txtUserNameFroBooking.Text.ToString();
                        HttpContext.Current.Session["CustomerEmailID"] = txtUserEmailID.Text.ToString();
                        HttpContext.Current.Session["CustomerMobileNo"] = txtUserPhoneNo.Text.ToString();
                        HttpContext.Current.Session["CustomerGSTNo"] = txtUserGSTNo.Text.ToString();
                    }
                }
                if (retData == -1)
                {
                    ltrErrorMsg.Text = "<div class='otp_msg'><p style='color: red;'>Email ID already exists!!</span></p></div>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.booknow_model'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", true);
                }
                else if (retData == -2)
                {
                    ltrErrorMsg.Text = "<div class='otp_msg'><p style='color: red;'>GST No. already exists!!</span></p></div>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.booknow_model'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", true);
                }
                else if (retData == -3)
                {
                    ltrErrorMsg.Text = "<div class='otp_msg'><p style='color: red;'>GST No. already exists!!</span></p></div>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.booknow_model'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", true);
                }
                else if (retData == 1)
                {
                    int BookingOrderNo = Convert.ToInt32(ObjEntertainmentBookData.SelectMaxBookingOrderNo());
                    ObjEntertainmentBookData.BookingOrderNo = BookingOrderNo;
                    ObjEntertainmentBookData.BookingDate = DateTime.UtcNow;
                    CultureInfo MyCultureInfo = new CultureInfo("en-US");
                    DateTime visitorDateofVisit = DateTime.Parse(txtPackageDateofvisit.Value, MyCultureInfo, DateTimeStyles.NoCurrentDateDefault);
                    ObjEntertainmentBookData.DateOfVisit = visitorDateofVisit;
                    ObjEntertainmentBookData.CustomerID = Convert.ToInt16(Session["CustomerID"]);
                    ObjEntertainmentBookData.PackageID = Convert.ToInt16(hdnPageID.Value);
                    ObjEntertainmentBookData.PackageTitle = hdnPackageTitle.Value;
                    ObjEntertainmentBookData.PackageTitleURL = hdnPackageTitle.Value;
                    ObjEntertainmentBookData.PackageTimming = hdnPackageTimming.Value;
                    ObjEntertainmentBookData.PackagePunchline = hdnPackagePunchline.Value;
                    ObjEntertainmentBookData.PackageKidsPunchline1 = hdnPackageKidsPunchline1.Value;
                    ObjEntertainmentBookData.PackageKidsPunchline2 = hdnPackageKidsPunchline2.Value;
                    ObjEntertainmentBookData.PackageAdultsPunchline1 = hdnPackageAdultsPunchline1.Value;
                    if (Convert.ToInt16(hdnTotalKids.Value) > 0)
                    {
                        ObjEntertainmentBookData.KidsPrice = Convert.ToInt16(hdnKidsPrice.Value);
                        ObjEntertainmentBookData.TotalKids = Convert.ToInt16(hdnTotalKids.Value);
                        ObjEntertainmentBookData.TotalKidsPrice = (Convert.ToInt16(hdnTotalKids.Value) * Convert.ToInt16(hdnKidsPrice.Value));
                    }
                    else
                    {
                        ObjEntertainmentBookData.KidsPrice = 0;
                        ObjEntertainmentBookData.TotalKids = 0;
                        ObjEntertainmentBookData.TotalKidsPrice = 0;
                    }
                    if (Convert.ToInt16(hdnTotalAdult.Value) > 0)
                    {
                        ObjEntertainmentBookData.AdultPrice = Convert.ToInt16(hdnAdultPrice.Value);
                        ObjEntertainmentBookData.TotalAdult = Convert.ToInt16(hdnTotalAdult.Value);
                        ObjEntertainmentBookData.TotalAdultPrice = (Convert.ToInt16(hdnTotalAdult.Value) * Convert.ToInt16(hdnAdultPrice.Value));
                    }
                    else
                    {
                        ObjEntertainmentBookData.AdultPrice = 0;
                        ObjEntertainmentBookData.TotalAdult = 0;
                        ObjEntertainmentBookData.TotalAdultPrice = 0;
                    }
                    ObjEntertainmentBookData.CouponCode = hdnCouponCode.Value;
                    ObjEntertainmentBookData.CouponValue = Convert.ToInt16(hdnTotalCoupon.Value);
                    ObjEntertainmentBookData.TotalTax = Convert.ToInt16(hdnTotalTax.Value);
                    ObjEntertainmentBookData.OrderTotalAmount = (Convert.ToInt16(hdnTotalPrice.Value));
                    ret = ObjEntertainmentBookData.SaveNewPackageBookingByCustomerData();
                    if (ret > 0)
                    {
                        //int ret1 = 0;
                        //string txnidtxnid = string.Empty;
                        //if (Convert.ToInt32(BookingOrderNo) < 10)
                        //    txnidtxnid = "APG00000P" + BookingOrderNo.ToString();
                        //else if (Convert.ToInt32(BookingOrderNo) < 100 && Convert.ToInt32(BookingOrderNo) > 10)
                        //    txnidtxnid = "APG0000P" + BookingOrderNo.ToString();
                        //else if (Convert.ToInt32(BookingOrderNo) < 1000 && Convert.ToInt32(BookingOrderNo) > 100)
                        //    txnidtxnid = "APG000P" + BookingOrderNo.ToString();
                        //else if (Convert.ToInt32(BookingOrderNo) < 10000 && Convert.ToInt32(BookingOrderNo) > 1000)
                        //    txnidtxnid = "APG00P" + BookingOrderNo.ToString();
                        //else if (Convert.ToInt32(BookingOrderNo) < 100000 && Convert.ToInt32(BookingOrderNo) > 10000)
                        //    txnidtxnid = "APG0P" + BookingOrderNo.ToString();
                        //else if (Convert.ToInt32(BookingOrderNo) < 1000000)
                        //    txnidtxnid = "APGP" + BookingOrderNo.ToString();
                        //ObjEntertainmentBookData.BookingOrderNo = BookingOrderNo;
                        //ObjEntertainmentBookData.PaymentID = txnidtxnid;
                        //ObjEntertainmentBookData.TransactionID = txnidtxnid;
                        //ObjEntertainmentBookData.TransactionStatus = "Success";
                        //ObjEntertainmentBookData.UpdatedBy = "Online Payments";
                        //ret1 = ObjEntertainmentBookData.UpdateFunctionBookingOnlinePaymentStatus();
                        //if (ret1 > 0)
                        //{
                        //    //if (Session["CustomerEmailID"] != null && Session["CustomerEmailID"].ToString() != "")
                        //    //    SendMailToCustomerToConfirmPayment(BookingOrderNo);
                        //    //if (Session["CustomerMobileNo"] != null && Session["CustomerMobileNo"].ToString() != "")
                        //    //{
                        //    //    ManageException ObjEx = new ManageException();
                        //    //    try
                        //    //    {
                        //    //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                        //    //        WebClient client = new WebClient();
                        //    //        string baseurl = "http://125.16.147.178/VoicenSMS/webresources/CreateSMSCampaignGet?ukey=I1aBFeA7tKwwAfw2DJ3rQHFAH&msisdn=" + Session["CustomerMobileNo"].ToString() + "&language=0&credittype=7&senderid=APOGHR&templateid=0&message=Thank you for your booking. You have got a perfect choice! We have received your booking having " + (Convert.ToInt16(hdnTotalKids.Value) + Convert.ToInt16(hdnTotalAdult.Value)) + " guest tickets on our AapnoGhar against the booking number " + BookingOrderNo + ". If you have any questions, please let us know, We’ll be happy to help!&filetype=2";
                        //    //        Stream data = client.OpenRead(baseurl);
                        //    //        StreamReader reader = new StreamReader(data);
                        //    //        string ResponseID = reader.ReadToEnd();
                        //    //        data.Close();
                        //    //        reader.Close();
                        //    //    }
                        //    //    catch (Exception ex)
                        //    //    {
                        //    //        ObjEx.PublishError("Error in procedure SaveNewCustomerData()", ex);
                        //    //    }
                        //    //}
                        //    //Response.Redirect("/thank-you", false);                            
                        //}
                        Recordholder(BookingOrderNo.ToString(), Convert.ToInt32(hdnTotalPrice.Value));
                        Response.Redirect("/pay-now", true);
                        
                    }
                    else if (ret == -1)
                        ltrErrorMsg.Text = "An error occured, Please try after sometime";
                    else if (ret == -2)
                        ltrErrorMsg.Text = "Phone no is not in correct format";
                    else if (ret == -3)
                        ltrErrorMsg.Text = "Please fill all the details properly";
                }
            }
            else
                Response.Redirect("/");            
        }

        public static void Recordholder(string OrderNo, int Subtotal)
        {
            string Name = "";
            string Email = "";
            string Phone = "";
            string BillingAddress = "";
            string StateName = "";
            string LocationName = "";
            string CityName = "";
            if (HttpContext.Current.Session["CustomerName"] != null && HttpContext.Current.Session["CustomerName"].ToString() != "")
                Name = HttpContext.Current.Session["CustomerName"].ToString();
            else
                Name = "AapnoGhart";
            if (HttpContext.Current.Session["CustomerEmailID"] != null && HttpContext.Current.Session["CustomerEmailID"].ToString() != "")
                Email = HttpContext.Current.Session["CustomerEmailID"].ToString();
            else
                Email = "info@aapnoghar.com";
            if (HttpContext.Current.Session["CustomerMobileNo"] != null && HttpContext.Current.Session["CustomerMobileNo"].ToString() != "")
                Phone = HttpContext.Current.Session["CustomerMobileNo"].ToString();
            else
                Phone = "7666779997";

            if (HttpContext.Current.Session["BillingAddress"] != null && HttpContext.Current.Session["BillingAddress"].ToString() != "")
                BillingAddress = HttpContext.Current.Session["BillingAddress"].ToString();
            else
                BillingAddress = "Aapno Ghar / Airport Motel Amusement & Water Park, 43rd Mile Stone , NH-8 Delhi – Jaipur Expressway, Sec-77";

            if (HttpContext.Current.Session["StateName"] != null && HttpContext.Current.Session["StateName"].ToString() != "")
                StateName = HttpContext.Current.Session["StateName"].ToString();
            else
                StateName = "Haryana";

            if (HttpContext.Current.Session["LocationName"] != null && HttpContext.Current.Session["LocationName"].ToString() != "")
                LocationName = HttpContext.Current.Session["LocationName"].ToString();
            else
                LocationName = "122001";

            if (HttpContext.Current.Session["CityName"] != null && HttpContext.Current.Session["CityName"].ToString() != "")
                CityName = HttpContext.Current.Session["CityName"].ToString();
            else
                CityName = "Gurugram";

            string txnidtxnid = string.Empty;
            if (Convert.ToInt32(OrderNo) < 10)
                txnidtxnid = "APG00000P" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 100 && Convert.ToInt32(OrderNo) > 10)
                txnidtxnid = "APG0000P" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 1000 && Convert.ToInt32(OrderNo) > 100)
                txnidtxnid = "APG000P" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 10000 && Convert.ToInt32(OrderNo) > 1000)
                txnidtxnid = "APG00P" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 100000 && Convert.ToInt32(OrderNo) > 10000)
                txnidtxnid = "APG0P" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 1000000)
                txnidtxnid = "APGP" + OrderNo.ToString();

            Hashtable ObjHashRecord = new Hashtable();
            ObjHashRecord.Add("merchant_id", "2415379");
            ObjHashRecord.Add("paymentid", txnidtxnid);
            ObjHashRecord.Add("order_id", OrderNo);
            ObjHashRecord.Add("amount", Subtotal);
            //ObjHashRecord.Add("amount", 1);
            ObjHashRecord.Add("currency", "INR");
            ObjHashRecord.Add("redirect_url", "https://www.aapnoghar.com/transaction-succesfull?Type=Package&AapnoGhar=" + HttpContext.Current.Session["CustomerID"]);
            ObjHashRecord.Add("cancel_url", "https://www.aapnoghar.com/transaction-failed?AapnoGhar=" + HttpContext.Current.Session["CustomerID"]);
            ObjHashRecord.Add("firstname", Name);
            ObjHashRecord.Add("lastname", Name);
            ObjHashRecord.Add("emailid", Email);
            ObjHashRecord.Add("phone", Phone);
            ObjHashRecord.Add("amountdate", DateTime.Now.ToString());
            ObjHashRecord.Add("billing_name", Name);
            ObjHashRecord.Add("billing_address", BillingAddress);
            ObjHashRecord.Add("billing_city", CityName);
            ObjHashRecord.Add("billing_state", StateName);
            ObjHashRecord.Add("billing_zip", LocationName);
            ObjHashRecord.Add("billing_country", "India");
            ObjHashRecord.Add("billing_tel", Phone);
            ObjHashRecord.Add("billing_email", Email);
            ObjHashRecord.Add("delivery_name", Name);
            ObjHashRecord.Add("delivery_address", BillingAddress);
            ObjHashRecord.Add("delivery_city", CityName);
            ObjHashRecord.Add("delivery_state", StateName);
            ObjHashRecord.Add("delivery_zip", LocationName);
            ObjHashRecord.Add("delivery_country", "India");
            ObjHashRecord.Add("delivery_tel", Phone);
            ObjHashRecord.Add("delivery_email", Email);
            HttpContext.Current.Session["rechold"] = ObjHashRecord;
        }

        private void SendMailToCustomerToConfirmPayment(int BookingOrderNo)
        {
            DataSet ds = new DataSet();
            EntertainmentBookData ObjEntertainmentBookData = new EntertainmentBookData();
            ObjEntertainmentBookData.BookingOrderNo = Convert.ToInt32(BookingOrderNo);
            ds = ObjEntertainmentBookData.SelectEntertainmentOrderDetailsByBookingOrderNoForMail();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0].DefaultView.ToTable(true, "BookingOrderNo", "BookingDate", "DateOfVisit", "PackageTitle", "PackageTitleURL", "PackageTimming", "PackagePunchline", "PackageKidsPunchline1", "PackageKidsPunchline2", "PackageAdultsPunchline1", "KidsPrice", "AdultPrice", "TotalKids", "TotalAdult", "TotalGuest", "TotalKidsPrice", "TotalAdultPrice", "TotalPrice", "CouponCode", "CouponValue", "TotalTax", "OrderTotalAmount", "PaymentOption", "BookingStatus", "PaymentStatus", "TransactionID", "PaymentID");
                string FirstName = Session["CustomerName"].ToString();
                string PhoneNo = Session["CustomerMobileNo"].ToString();
                string EmailID = Session["CustomerEmailID"].ToString();
                string BookingDate = dt.Rows[0]["BookingDate"].ToString();
                string DateOfVisit = dt.Rows[0]["DateOfVisit"].ToString();
                string PackageTitle = dt.Rows[0]["PackageTitle"].ToString();
                string PackageTimming = dt.Rows[0]["PackageTimming"].ToString();
                string PackagePunchline = dt.Rows[0]["PackagePunchline"].ToString();
                string PackageKidsPunchline1 = dt.Rows[0]["PackageKidsPunchline1"].ToString();
                string PackageKidsPunchline2 = dt.Rows[0]["PackageKidsPunchline2"].ToString();
                string PackageAdultsPunchline1 = dt.Rows[0]["PackageAdultsPunchline1"].ToString();
                string TotalKids = dt.Rows[0]["TotalKids"].ToString();
                string KidsPrice = dt.Rows[0]["KidsPrice"].ToString();
                string TotalAdult = dt.Rows[0]["TotalAdult"].ToString();
                string AdultPrice = dt.Rows[0]["AdultPrice"].ToString();
                string TotalGuest = dt.Rows[0]["TotalGuest"].ToString();
                string TotalPrice = dt.Rows[0]["TotalPrice"].ToString();
                string CouponCode = dt.Rows[0]["CouponCode"].ToString();
                string CouponValue = dt.Rows[0]["CouponValue"].ToString();
                string TotalTax = dt.Rows[0]["TotalTax"].ToString();
                string OrderTotalAmount = dt.Rows[0]["OrderTotalAmount"].ToString();
                string PaymentStatus = dt.Rows[0]["PaymentStatus"].ToString();
                string TransactionID = dt.Rows[0]["TransactionID"].ToString();
                string CustomerInvoiceNo = dt.Rows[0]["PaymentID"].ToString();

                #region New Booking Invoice Formate
                StringBuilder str1 = new StringBuilder();
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0' style='padding:10px;margin:10px;'>");

                str1.Append("<tr>");
                str1.Append("<td style='width:50%;text-align:left;vertical-align:top;'><a href='https://www.aapnoghar.com/'><img src='https://www.aapnoghar.com/assets/icons/email-logo.png' height='72' alt='logo' /></a></td>");
                str1.Append("<td style='width:50%;text-align:right;'>" + PackageTitle + " booking details&nbsp;</td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;height:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                #region One -: Booking Details
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' align='left' cellpadding='3' style='color:#000;font-size:10px;'><strong><u>Booking Info</u></strong></td>");
                str1.Append("<td colspan='2' align='left' cellpadding='3' style='color:#000;font-size:10px;'><strong><u>Personal Info</u></strong></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking ID</td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + BookingOrderNo.ToString() + " <span title='Invoice No'>(" + CustomerInvoiceNo + ")</span></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Name</td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + FirstName + "</td>");
                str1.Append("</tr>");
                if (EmailID != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Email ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><a href='mailto:" + EmailID + "'>" + EmailID + "</ a></td>");
                    str1.Append("</tr>");
                }
                else
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Email ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                    str1.Append("</tr>");
                }                
               
                if (PhoneNo != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking Date</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(BookingDate).ToString("dd MMM yyyy") + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Contact Number</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><a href='tel:+91" + PhoneNo + "'>+91-" + PhoneNo + "</a></td>");
                    str1.Append("</tr>");
                }
                else
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking Date</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(BookingDate).ToString("dd MMM yyyy") + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Contact Number</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                str1.Append("<td colspan='4' align='center' style='color:#000;font-size:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");
                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Two -: Event & Venue Details
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='5' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong><u>Address & Venue Details</u></strong></td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Package Name</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageTitle + "</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Date Of Visit</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(DateOfVisit).ToString("dd MMM yyyy") + "</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Organised By</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>AapnoGhar</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Timming</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageTimming + "</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Activity</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackagePunchline + "</td>");
                str1.Append("</tr>");
                if (PackageKidsPunchline1 != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Kids</td>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageKidsPunchline1 + "</td>");
                    str1.Append("</tr>");
                }
                if (PackageAdultsPunchline1 != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Adults</td>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageAdultsPunchline1 + "</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Venue</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>AapnoGhar Sector 77, Gurugram, Haryana 122004</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='5' align='center' style='color:#000;font-size:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Three -: Tickets & Package Details
                int i = 1;
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0.5'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='5' cellpadding='2' align='left' style='color:#000;font-size:10px;background-color:#e7e7e7;vertical-align:middle;'><strong>Tickets & Package Details</strong></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>S.no.</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Type</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Price <span style='color:#000;font-size:8px;'>(per ticket)</span></strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>No of ticket</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Total Price</strong></td>");
                str1.Append("</tr>");

                if (Convert.ToInt16(TotalAdult) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + i + ".</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Adult Price</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + AdultPrice + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + TotalAdult + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + (Convert.ToInt32(AdultPrice) * Convert.ToInt32(TotalAdult)).ToString() + "</td>");
                    str1.Append("</tr>");
                    i = i + 1;
                }
                if (Convert.ToInt16(TotalKids) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + i + ".</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Kids Price</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + KidsPrice + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + TotalKids + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + (Convert.ToInt32(KidsPrice) * Convert.ToInt32(TotalKids)).ToString() + "</td>");
                    str1.Append("</tr>");
                    i = i + 1;
                }
                if (Convert.ToInt32(TotalTax) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Total TAX </td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + TotalTax.ToString() + "</td>");
                    str1.Append("</tr>");
                }
                if (Convert.ToInt32(CouponValue) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Coupon Amount - </td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + CouponValue.ToString() + "</td>");
                    str1.Append("</tr>");
                }

                str1.Append("<tr>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Net Payable Amount - </td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR <strong>" + OrderTotalAmount.ToString() + "/-</strong> only</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Total no of Guests - </td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + TotalGuest + "</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='5' align='left' style='color:#000;font-size:10px;'><br><strong> - Amount in words : </strong>" + NumbersToWords(Convert.ToInt32(OrderTotalAmount)) + " only.<br><strong> - Transaction ID : </strong> " + TransactionID + "<br><br></td>");
                str1.Append("</tr>");

                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Commnet
                //#region Four -: Activity Include
                //DataTable dt1 = new DataTable();
                //DataView dataView = new DataView(ds.Tables[0]);
                //dataView.RowFilter = "BookingOrderNo =" + BookingOrderNo + " and ActivityType='Activity'";
                //dt1 = dataView.ToTable(true, "ActivityType", "ActivityName");
                //if (dt1.Rows.Count > 0)
                //{
                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong>Activity Include</strong></td>");
                //    str1.Append("</tr>");

                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                //    str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
                //    for (int k = 0; k < dt1.Rows.Count; k++)
                //    {
                //        str1.Append("<tr>");
                //        str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>" + (k + 1) + ". </strong>" + dt1.Rows[k]["ActivityName"].ToString() + "</td>");
                //        str1.Append("</tr>");
                //    }
                //    str1.Append("</table>");
                //    str1.Append("</td>");
                //    str1.Append("</tr>");

                //}
                //#endregion

                //#region Five -: Meal Include
                //dataView.RowFilter = "BookingOrderNo =" + BookingOrderNo + " and ActivityType='Meal'";
                //dt1 = dataView.ToTable(true, "ActivityType", "ActivityName");
                //if (dt1.Rows.Count > 0)
                //{
                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong>Meal Include</strong></td>");
                //    str1.Append("</tr>");

                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                //    str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
                //    for (int k = 0; k < dt1.Rows.Count; k++)
                //    {
                //        str1.Append("<tr>");
                //        str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>" + (k + 1) + ". </strong>" + dt1.Rows[k]["ActivityName"].ToString() + "</td>");
                //        str1.Append("</tr>");
                //    }
                //    str1.Append("</table>");
                //    str1.Append("</td>");
                //    str1.Append("</tr>");

                //}
                //#endregion

                //dataView.Dispose();
                //dt1.Dispose();
                //dt1.Clear();
                #endregion

                #region Six -: Terms & Conditions

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong>Terms & Conditions</strong></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>1. </strong>Everything mentioned is included in the " + PackageTitle + " (" + PackagePunchline + ").</td>");
                str1.Append("</tr>");
                if (PackageKidsPunchline2 != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>2. </strong>Kids(below " + PackageKidsPunchline2 + "inches of height) are complimentary</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>3. </strong>Few activities may not be operational due to technical challenges.</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>4. </strong>Swimming costume is mandatory to enjoy water based activities. Costume is available on rental at the AapnoGhar.</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'>&nbsp;</td>");
                str1.Append("</tr>");
                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:8px;padding:15px;margin:15px;'>If you have any query or concern, please feel free to contact us at <a href='tel:+917666779997'><strong>+91-7666779997</strong></a> or email us at <a href='mailto:info@aapnoghar.com'><strong>info@aapnoghar.com</strong></a>.</td>");
                str1.Append("</tr>");
                #endregion

                str1.Append("</table>");

                string InvoiceName = "aapno-ghar-" + BookingOrderNo.ToString() + ".pdf";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                string final = str1.ToString();
                str1.Clear();
                string appPath = HttpContext.Current.Request.ApplicationPath;
                string path = Server.MapPath(appPath + "/AapnoGharlmages/PackageInvoice/" + InvoiceName);

                dynamic output = new FileStream(path, FileMode.Create);
                StringReader sr = new StringReader(final.ToString());
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10, 10, 10, 10);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, output);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();
                #endregion

                #region Customer Mail Body
                StringBuilder str = new StringBuilder();
                str.Append("<!DOCTYPE html>");
                str.Append("<html>");
                str.Append("<head>");
                str.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>");
                str.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
                str.Append("<title>Thank you mail</title>");
                str.Append("</head>");
                str.Append("<body style='background: #fff;;'>");
                str.Append("<div style='border:1px solid #04775c;width:700px;'>");
                str.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%' style='padding:10px 20px;'>");

                str.Append("<tr>");
                str.Append("<td style='float:left;text-align:left;'><a href='https://www.aapnoghar.com/' title='logo'><img class='logo' src='https://www.aapnoghar.com/assets/icons/email-logo.png' width='81' alt='logo' /></a></td>");
                str.Append("<td style='float:right;text-align:right;color:#000;padding:15px 5px;'> <a href='mailto:info@aapnoghar.com' style='color:#000;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Email ID : info@aapnoghar.com</a> <br /> <a href='tel:+917666779997' style='color:#000;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Phone : +91 7666 779 997</a></td>");
                str.Append("</tr>");

                str.Append("<tr>");
                str.Append("<td colspan='2' style='color:#000;padding:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>");
                str.Append("<table border='0' cellspacing='0' cellspacing='2' width='100%'>");
                str.Append("<tr>");
                str.Append("<td valign='top' align='left'>");
                str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + Session["CustomerName"].ToString() + ",<br /><br /></p>");
                if (Convert.ToInt16(TotalGuest) == 1)
                {
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guest tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + BookingOrderNo.ToString() + ".</p>");
                    //str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>If you have any questions, just reply to this email. We’ll be happy to help!</p>");
                    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guest tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br> If you have any questions, please let us know, We’ll be happy to help!";
                    //Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guest tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.<br><br> If you have any questions, please let us know, We’ll be happy to help!";
                }
                else
                {
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guests tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + BookingOrderNo.ToString() + ".</p>");
                    //str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>If you have any questions, just reply to this email. We’ll be happy to help!</p>");
                    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guests tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br> If you have any questions, please let us know, We’ll be happy to help!"; 
                    //Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guests tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.<br><br> If you have any questions, please let us know, We’ll be happy to help!";
                }
                str.Append("<p style='color:#363636;padding-top:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><b>Warm Regards</b>,<br><b>AapnoGhar</b></p>");
                str.Append("</td>");
                str.Append("</tr>");
                str.Append("</table>");

                str.Append("</td>");
                str.Append("</tr>");

                str.Append("</table>");

                str.Append("<div style='background:#172061;border-left:solid #666 5px;border-right:solid #666 5px;color:#fff;text-align:center;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><h2 style='color:#fff;letter-spacing:4px;font:normal 22px/1 Verdana, Helvetica;padding:8px 0px;text-align:center;'><a href='https://www.aapnoghar.com' style='color:#fff;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>www.aapnoghar.com</a></h2></div>");
                str.Append("</div>");
                str.Append("</body>");
                str.Append("</html>");
                #endregion

                #region Send Email to customer
                try
                {
                    Mail ObjMail = new Mail();
                    ObjMail.Subject = "Thankyou for your Booking at AapnoGhar";
                    ObjMail.MailTo = EmailID.ToString();
                    ObjMail.MailCc = "info@aapnoghar.com";
                    ObjMail.Body = str.ToString().Replace(", , ", " ");
                    ObjMail.Title = "AapnoGhar";
                    ObjMail.SendMail();
                    //ObjMail.SendMailInvoice(@Server.MapPath(appPath + "/AapnoGharlmages/PackageInvoice/" + InvoiceName));
                }
                catch (Exception ex)
                {
                    Response.Redirect("/something-went-wrong?error=while sending email", false);
                }
                #endregion
            }
        }

        public string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    //if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Quick Enquiry
        protected void btnQuickSubmit_Click(object sender, EventArgs e)
        {
            Contact ObjContact = new Contact();
            int ret;
            if ((txtMainEmail1.Text == "") && (txtQuickInquiryName.Text != "") && (txtQuickInquiryEmail.Text != "") && (txtQuickInquiryPhone.Text != "") && (textarea1.Value != ""))
            {
                bool containsLetter = Regex.IsMatch(txtQuickInquiryPhone.Text.TrimStart(), "[A-Z]");
                if (containsLetter == false)
                {
                    try
                    {
                        ObjContact.FirstName = txtQuickInquiryName.Text.TrimStart();
                        ObjContact.PhoneNo = txtQuickInquiryPhone.Text.TrimStart();
                        ObjContact.EmailID = txtQuickInquiryEmail.Text.TrimStart();
                        ObjContact.DateOfVisit = Convert.ToDateTime(txtQuickInquiryDate.Value);
                        ObjContact.Message = textarea1.Value;
                        ObjContact.Enquiryfor = hdnInterested.Value;
                        ObjContact.EnquiryType = "Quick Enquiry";
                        ObjContact.PageName = HttpContext.Current.Request.Url.AbsoluteUri;
                        ObjContact.PostedDate = DateTime.UtcNow;
                        ret = ObjContact.SaveNewEnquiry();
                        if (ret != -1)
                        {
                            SendMailToAdmin();
                            SendMailToUser();
                            txtQuickInquiryName.Text = "";
                            txtQuickInquiryEmail.Text = "";
                            txtQuickInquiryPhone.Text = "";
                            textarea1.Value = "";
                            Session["Frontmsg"] = "We appreciate you for contacting us. We have taken due note of your query and shall revert back soon.";
                            ObjContact = null;
                            Response.Redirect("/thank-you", false);
                        }
                    }
                    catch (Exception ex)
                    {
                        ltrError.Text = "<p>Error-a- " + ex.Message.ToString() + "</p>";
                    }
                }
            }
        }

        private void SendMailToAdmin()
        {
            Mail ObjMail = new Mail();
            try
            {
                ObjMail.Title = "AapnoGhar";
                ObjMail.Subject = "User Details of Quick Enquiry";
                ObjMail.Body = this.GetBody();
                ObjMail.SendMail();
            }
            catch (Exception ex)
            {
                ltrError.Text = "<p>Error-a- " + ex.Message.ToString() + "</p>";
            }
        }
        private string GetBody()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<html>");
            str.Append("<head>");
            str.Append("<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />");
            str.Append("<title>User Details of Contact Us Page</title>");
            str.Append("</head>");
            str.Append("<body>");
            str.Append("<div style='padding-top:0px; background-color:#fff; width: 900px; margin:0 auto; border:1px solid #625b84; margin-top: 40px;'>");
            str.Append("<div style='background:#172061;margin:15px;border-left:solid #a78343 5px;border-right:solid #000 5px;color:#fff'><h2 style='text-transform: uppercase;color: #FFF;margin: 0 0 30px 0;letter-spacing: 4px;font: WeddingEvent 22px/1 Verdana, Helvetica;position: relative;padding:8px 0px 8px 20px;'>Quick Enquiry : Visitor Details</h2></div>");
            str.Append("<table width='80%' border='0' cellspacing='5' cellpadding='5' style='margin-left:40px;'>");
            str.Append("<tr>");
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>Dear Sir/Mam,</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>My Details Are--</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>");
            str.Append("<table cellpadding='2' cellspacing='2' border='0' width='90%'>");
            str.Append("<tr>");
            str.Append("<td width='13%'>Name</td>");
            str.Append("<td width='2%'>:</td>");
            str.Append("<td width='85%'>" + txtQuickInquiryName.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Email</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtQuickInquiryEmail.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Contact No</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtQuickInquiryPhone.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Event Date</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + Convert.ToDateTime(txtQuickInquiryDate.Value).ToString("ddd, dd MMM yyyy") + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Enquiry Type</td>");
            str.Append("<td>:</td>");
            str.Append("<td>Quick Enquiry</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Enquiry For</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + hdnInterested.Value + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Message</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + textarea1.Value + "</td>");
            str.Append("</tr>");

            str.Append("</table>");
            str.Append(" </td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>Regards,</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>" + txtQuickInquiryName.Text + "</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("<div style='background:#172061; margin:15px; border-left:solid #a78343 6px; border-right:solid #000 6px; color:#fff; text-align:center;'><h2 style='color:#fff; letter-spacing:4px; font:WeddingEvent 22px/1 Verdana, Helvetica; padding:8px 0px; text-align:center;'><a href='https://www.aapnoghar.com/' style='color: #fff; text-decoration:none;'>www.aapnoghar.com</a></h2></div>");
            str.Append("</div>");
            str.Append("</body>");
            str.Append("</html>");
            return str.ToString();
        }
        private void SendMailToUser()
        {
            Mail ObjMail = new Mail();
            try
            {
                ObjMail.MailTo = txtQuickInquiryEmail.Text;
                ObjMail.Title = "AapnoGhar";
                ObjMail.Subject = "Thank You for contacting us";
                ObjMail.Body = this.GetBody1();
                ObjMail.SendMail();
            }
            catch (Exception ex)
            {
                ltrError.Text = "<p>Error-a- " + ex.Message.ToString() + "</p>";
            }
        }
        private string GetBody1()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<!DOCTYPE html>");
            str.Append("<html>");
            str.Append("<head>");
            str.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>");
            str.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
            str.Append("<title>Thank you mail</title>");
            str.Append("</head>");
            str.Append("<body style='background: #fff;;'>");
            str.Append("<div style='border:1px solid #172061;width:700px;'>");
            str.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%' style='padding:10px 20px;'>");

            str.Append("<tr>");
            str.Append("<td style='width:40%;'><a href='https://www.aapnoghar.com/' title='logo'><img class='logo' src='https://www.aapnoghar.com/assets/icons/email-logo.png' width='81' alt='logo' /></a></td>");
            str.Append("<td style='color:#000;float:right;padding:15px 5px;'><a href='mailto:info@aapnoghar.com' style='color:#363636;text-decoration:none;font-size:13px;'>Email ID : info@aapnoghar.com</a><br><a href='tel:+917666779997' style='color:#363636;text-decoration:none;font-size:13px;'>Phone : +91-7666779997</a></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan='2' style='color:#000;padding:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>");
            str.Append("<table border='0' cellspacing='0' cellspacing='2' width='100%'>");
            str.Append("<tr>");
            str.Append("<td valign='top' align='left'>");
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + txtQuickInquiryName.Text.TrimStart() + ",<br /><br /></p>");
            str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>We appreciate you for contacting us. We have taken due note of your query and shall revert back soon.</p>");
            str.Append("<p style='color:#363636;padding-top:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><b>Warm Regards</b>,<br><b>AapnoGhar</b></p>");
            str.Append("</td>");
            str.Append("</tr>");
            str.Append("</table>");

            str.Append("</td>");
            str.Append("</tr>");

            str.Append("</table>");

            str.Append("<div style='background:#172061;border-left:solid #666 5px;border-right:solid #666 5px;color:#fff;text-align:center;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><h2 style='color:#fff;letter-spacing:4px;font:normal 22px/1 Verdana, Helvetica;padding:8px 0px;text-align:center;'><a href='https://www.aapnoghar.com' style='color:#fff;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>www.aapnoghar.com</a></h2></div>");
            str.Append("</div>");
            str.Append("</body>");
            str.Append("</html>");
            return str.ToString();
        }
        #endregion

        #region Cart Value
        private void BindRptrCartList()
        {
            //int ProductTotalQty = 0;
            if (Session["dtCartRoom"] == null)
                ltrCartItem.Text = "<li class='cart' data-val='0'><a href='/room-booking-cart' ><img src='/assets/icons/shopping-cart.png' /></a></li>";
            else
            {
                DataTable dt = new DataTable();
                dt = ((DataTable)Session["dtCartRoom"]);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    ProductTotalQty = ProductTotalQty + Convert.ToInt32(dt.Rows[i]["Quantity"]);
                //}
                if (dt.Rows.Count > 0)
                    ltrCartItem.Text = "<li class='cart' data-val='" + dt.Rows.Count.ToString() + "'><a href='/room-booking-cart' ><img src='/assets/icons/shopping-cart.png' /></a></li>";
                else
                    ltrCartItem.Text = "<li class='cart' data-val='0'><a href='/room-booking-cart' ><img src='/assets/icons/shopping-cart.png' /></a></li>";
            }
        }
        #endregion

    }
}