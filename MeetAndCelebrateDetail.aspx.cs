using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Component;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Utility;

namespace AapnoGharWeb
{
    public partial class MeetAndCelebrateDetail : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
        WeddeingEventData objWeddeingEventData = new WeddeingEventData();
        SqlDataReader SqlReader;
        int WeddeingEventID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Convert.ToString(Page.RouteData.Values["WeddeingEventAlias"]) != string.Empty))
                {
                    WeddeingEventID = Convert.ToInt16(objWeddeingEventData.SelectActiveWeddeingEventIDbyURL(Convert.ToString(Page.RouteData.Values["WeddeingEventAlias"])));
                    if (WeddeingEventID > 0)
                    {
                        objWeddeingEventData.WeddeingEventID = WeddeingEventID;
                        SqlReader = objWeddeingEventData.SelectActiveWeddeingEventDataByWeddeingEventID();
                        FillData(SqlReader);
                        BindAllGalleryImges(WeddeingEventID);
                    }
                    else
                        Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
                }
                else
                    Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
            }
            lnkBtnSubmit.Attributes.Add("OnClick", "return PageCheckWeddingEventMaster();");
        }

        #region Weddeing Event Data
        private void FillData(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                txtWeddingEventNameType.Text = ltrTitle.Text = SqlReader["WeddeingEventName"].ToString();

                if (SqlReader["WeddeingEventVideoLink"].ToString() != "")
                    ltrWeddeingEventVideoLink.Text = "<div class='video_icon model-video model-open' data-model='.Model_Video' data-video='" + SqlReader["WeddeingEventVideoLink"].ToString() + "?autoplay=1;rel=0'><img src='assets/icons/play.png' alt=''/></div>";

                if (SqlReader["WeddeingEventSamllDescription"].ToString() != "")
                    ltrWeddeingEventSamllDescription.Text = "<p>" + SqlReader["WeddeingEventSamllDescription"].ToString() + "</p>";
                ltrBannerImage.Text = "<img src='/AapnoGharlmages/WeddeingEventImages/" + SqlReader["WeddeingEventLargeImage"].ToString() + "' alt='" + SqlReader["WeddeingEventAlias"].ToString() + "' title='" + SqlReader["WeddeingEventName"].ToString() + "'/>";
                ltrData.Text = SqlReader["WeddeingEventDescription"].ToString();
                ltrWeddeingEventType.Text = SqlReader["WeddeingEventType"].ToString();
                hdnValueEnquiryType.Value = SqlReader["WeddeingEventType"].ToString();
                BindTop10ActiveRealtedWeddeingEventData(WeddeingEventID, SqlReader["WeddeingEventType"].ToString());
                AddMetaTags(SqlReader["WeddeingEventMetaTitle"].ToString(), SqlReader["WeddeingEventMetaKeywords"].ToString(), SqlReader["WeddeingEventMetaDescription"].ToString(), SqlReader["WeddeingEventMetaSchema"].ToString(), SqlReader["WeddeingEventLargeImage"].ToString());
            }
            SqlReader.Close();
            SqlReader.Dispose();
        }

        private void BindTop10ActiveRealtedWeddeingEventData(int WeddeingEventID, string WeddeingEventType)
        {
            DataSet ds = new DataSet();
            objWeddeingEventData.WeddeingEventID = WeddeingEventID;
            objWeddeingEventData.WeddeingEventType = WeddeingEventType;
            ds = objWeddeingEventData.SelectTop10ActiveRealtedWeddeingEventData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRelatedWeddeingEvent.DataSource = ds.Tables[0];
                RptrRelatedWeddeingEvent.DataBind();
                RptrRelatedWeddeingEvent.Visible = true;
                PnlRelatedWeddeingEvent.Visible = true;
            }
            else
            {
                RptrRelatedWeddeingEvent.Visible = false;
                PnlRelatedWeddeingEvent.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
        }

        #region Gallery Data
        private void BindAllGalleryImges(int WeddeingEventID)
        {
            GalleryData ObjGalleryData = new GalleryData();
            DataSet ds = new DataSet();
            ObjGalleryData.GalleryFor = "Weddeing Event";
            ObjGalleryData.ActivityID = WeddeingEventID;
            ds = ObjGalleryData.SelectAllGalleryImges();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrGalleryData.DataSource = ds.Tables[0];
                RptrGalleryData.DataBind();
                RptrGalleryData.Visible = true;

                RptrGalleryData1.DataSource = ds.Tables[0];
                RptrGalleryData1.DataBind();
                RptrGalleryData1.Visible = true;

                PnlGalleryData.Visible = true;
            }
            else
            {
                RptrGalleryData.Visible = false;
                RptrGalleryData1.Visible = false;

                PnlGalleryData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjGalleryData = null;
        }
        #endregion

        private void AddMetaTags(string MetaTitle, string MetaKeyword, string MetaDescription, string MetaSchema, string MetaImg)
        {
            Page.Title = MetaTitle;
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = MetaKeyword;
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = MetaDescription;
            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri;
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri;

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = MetaTitle;
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = MetaDescription;
            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri;
            HtmlMeta imageMetaOG = (HtmlMeta)Master.FindControl("imageMetaOG");
            imageMetaOG.Content = "https://www.aapnoghar.com/AapnoGharlmages/WeddeingEventImages/" + MetaImg;

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = MetaTitle;
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = MetaDescription;
            HtmlMeta imageMetaTwitter = (HtmlMeta)Master.FindControl("imageMetaTwitter");
            imageMetaTwitter.Content = "https://www.aapnoghar.com/AapnoGharlmages/WeddeingEventImages/" + MetaImg;

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = MetaTitle;
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = MetaDescription;
            HtmlMeta imageMetaGoogle = (HtmlMeta)Master.FindControl("imageMetaGoogle");
            imageMetaGoogle.Content = "https://www.aapnoghar.com/AapnoGharlmages/WeddeingEventImages/" + MetaImg;

            if (MetaSchema != "")
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", MetaSchema, false);
        }
        #endregion

        #region Wedding Event Enquiry
        protected void lnkBtnSubmit_Click(object sender, EventArgs e)
        {
            int ret;
            if ((txtMainEmail1.Text == "") && (txtWeddingEventName.Text != "") && (txtWeddingEventEmail.Text != "") && (txtWeddingEventPhone.Text != "") && (textarea1.Value != ""))
            {
                bool containsLetter = Regex.IsMatch(txtWeddingEventPhone.Text.TrimStart(), "[A-Z]");
                if (containsLetter == false)
                {
                    try
                    {
                        ObjContact.FirstName = txtWeddingEventName.Text.TrimStart();
                        ObjContact.PhoneNo = txtWeddingEventPhone.Text.TrimStart();
                        ObjContact.EmailID = txtWeddingEventEmail.Text.TrimStart();
                        ObjContact.DateOfVisit = Convert.ToDateTime(txtEventDate.Value);
                        ObjContact.Message = textarea1.Value;
                        ObjContact.Enquiryfor = txtWeddingEventNameType.Text;
                        ObjContact.EnquiryType = "Meet & Celebrate";
                        ObjContact.PageName = HttpContext.Current.Request.Url.AbsoluteUri;
                        ObjContact.PostedDate = DateTime.UtcNow;
                        ret = ObjContact.SaveNewEnquiry();
                        if (ret != -1)
                        {
                            SendMailToAdmin();
                            SendMailToUser();
                            txtWeddingEventName.Text = "";
                            txtWeddingEventEmail.Text = "";
                            txtWeddingEventPhone.Text = "";
                            textarea1.Value = "";
                            Session["Frontmsg"] = "We appreciate you for contacting us. We have taken due note of your query and shall revert back soon.";
                            Response.Redirect("/thank-you", false);
                        }
                    }
                    catch (Exception ex)
                    {
                        ObjEx.PublishError("Error in procedure SaveData()", ex);
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
                ObjMail.Subject = "User Details of Meet & Celebrate Enquiry";
                ObjMail.Body = this.GetBody();
                ObjMail.SendMail();
            }
            catch (Exception ex)
            {
                ltrError.Text = "<p>Error-a- " + ex.Message.ToString()+"</p>";
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
            str.Append("<div style='background:#172061;margin:15px;border-left:solid #a78343 5px;border-right:solid #000 5px;color:#fff'><h2 style='text-transform: uppercase;color: #FFF;margin: 0 0 30px 0;letter-spacing: 4px;font: WeddingEvent 22px/1 Verdana, Helvetica;position: relative;padding:8px 0px 8px 20px;'>" + hdnValueEnquiryType.Value + " Enquiry : Visitor Details</h2></div>");
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
            str.Append("<td width='85%'>" + txtWeddingEventName.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Email</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtWeddingEventEmail.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Contact No</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtWeddingEventPhone.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Event Date</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + Convert.ToDateTime(txtEventDate.Value).ToString("ddd, dd MMM yyyy") + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Enquiry Type</td>");
            str.Append("<td>:</td>");
            str.Append("<td>Meet & Celebrate</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Enquiry For</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtWeddingEventNameType.Text + "</td>");
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
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>" + txtWeddingEventName.Text + "</td>");
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
                ObjMail.MailTo = txtWeddingEventEmail.Text;
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
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + txtWeddingEventName.Text.TrimStart() + ",<br /><br /></p>");
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
    }
}