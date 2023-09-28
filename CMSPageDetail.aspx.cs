using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Component;
using Utility;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Text;

namespace AapnoGharWeb
{
    public partial class CMSPageDetail : System.Web.UI.Page
    {
        CMSData ObjCMSData = new CMSData();
        ManageException ObjEx = new ManageException();
        SqlDataReader SqlReader;
        Contact ObjContact = new Contact();
        int CMSID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Convert.ToString(Page.RouteData.Values["CMSAlias"]) != string.Empty))
                {
                    CMSID = Convert.ToInt16(ObjCMSData.SelectActiveCMSIDbyURL(Convert.ToString(Page.RouteData.Values["CMSAlias"])));
                    if (CMSID > 0)
                    {
                        ObjCMSData.CMSID = CMSID;
                        SqlReader = ObjCMSData.SelectActiveCMSDataByCMSID();
                        filldata(SqlReader);
                        BindAllGalleryImges(CMSID);
                        BindTop2ActiveEntertainmentForHome();
                    }
                    else
                        Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
                }
                else
                    Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
                
            }
            lnkBtnSubmit.Attributes.Add("OnClick", "return PageCheckCMSMaster();");
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                txtCMSNameType.Text = ltrCMSName.Text = SqlReader["CMSName"].ToString();
                ltrBannerImage.Text = "<img src='/AapnoGharlmages/PageImages/" + SqlReader["CMSBannerImage"].ToString() + "' alt='" + SqlReader["CMSAlias"].ToString() + "' title='" + SqlReader["CMSName"].ToString() + "'/>";
                ltrCMSDescription.Text = SqlReader["CMSDescription"].ToString();
                AddMetaTags(SqlReader["CMSMetaTitle"].ToString(), SqlReader["CMSMetaKeywords"].ToString(), SqlReader["CMSMetaDescription"].ToString(), SqlReader["CMSDefaultImage"].ToString(), SqlReader["CMSMetaSchema"].ToString());
            }
            SqlReader.Close();
            SqlReader.Dispose();
        }

        private void AddMetaTags(string MetaTitle, string MetaKeyword, string MetaDescription, string MetaImg, string MetaSchema)
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
            imageMetaOG.Content = "https://www.aapnoghar.com/AapnoGharlmages/PageImages/" + MetaImg;

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = MetaTitle;
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = MetaDescription;
            HtmlMeta imageMetaTwitter = (HtmlMeta)Master.FindControl("imageMetaTwitter");
            imageMetaTwitter.Content = "https://www.aapnoghar.com/AapnoGharlmages/PageImages/" + MetaImg;

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = MetaTitle;
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = MetaDescription;
            HtmlMeta imageMetaGoogle = (HtmlMeta)Master.FindControl("imageMetaGoogle");
            imageMetaGoogle.Content = "https://www.aapnoghar.com/AapnoGharlmages/PageImages/" + MetaImg;

            if (MetaSchema != "")
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", MetaSchema, false);
        }

        #region Gallery Data
        private void BindAllGalleryImges(int CMSID)
        {
            GalleryData ObjGalleryData = new GalleryData();
            DataSet ds = new DataSet();
            ObjGalleryData.GalleryFor = "CMS Page";
            ObjGalleryData.ActivityID = CMSID;
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

        #region Entertainment
        private void BindTop2ActiveEntertainmentForHome()
        {
            EntertainmentData ObjEntertainmentData = new EntertainmentData();
            DataSet ds = new DataSet();
            ds = ObjEntertainmentData.SelectTop2ActiveEntertainmentForHome();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrEntertainmentForHome.DataSource = ds.Tables[0];
                RptrEntertainmentForHome.DataBind();
                RptrEntertainmentForHome.Visible = true;
            }
            else
            {
                RptrEntertainmentForHome.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentData = null;
        }
        #endregion

        #region CMS Page Enquiry
        protected void lnkBtnSubmit_Click(object sender, EventArgs e)
        {
            int ret;
            if ((txtMainEmail1.Text == "") && (txtCMSName.Text != "") && (txtCMSEmail.Text != "") && (txtCMSPhone.Text != "") && (textarea1.Value != ""))
            {
                bool containsLetter = Regex.IsMatch(txtCMSPhone.Text.TrimStart(), "[A-Z]");
                if (containsLetter == false)
                {
                    try
                    {
                        ObjContact.FirstName = txtCMSName.Text.TrimStart();
                        ObjContact.PhoneNo = txtCMSPhone.Text.TrimStart();
                        ObjContact.EmailID = txtCMSEmail.Text.TrimStart();
                        ObjContact.DateOfVisit = Convert.ToDateTime(txtEventDate.Value);
                        ObjContact.Message = textarea1.Value;
                        ObjContact.Enquiryfor = txtCMSNameType.Text;
                        ObjContact.EnquiryType = "CMS Page";
                        ObjContact.PageName = HttpContext.Current.Request.Url.AbsoluteUri;
                        ObjContact.PostedDate = DateTime.UtcNow;
                        ret = ObjContact.SaveNewEnquiry();
                        if (ret != -1)
                        {
                            SendMailToAdmin();
                            SendMailToUser();
                            txtCMSName.Text = "";
                            txtCMSEmail.Text = "";
                            txtCMSPhone.Text = "";
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
                ObjMail.Subject = "User Details of CMS Page Enquiry";
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
            str.Append("<div style='background:#172061;margin:15px;border-left:solid #a78343 5px;border-right:solid #000 5px;color:#fff'><h2 style='text-transform: uppercase;color: #FFF;margin: 0 0 30px 0;letter-spacing: 4px;font: CMS 22px/1 Verdana, Helvetica;position: relative;padding:8px 0px 8px 20px;'>CMS Page Enquiry : Visitor Details</h2></div>");
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
            str.Append("<td width='85%'>" + txtCMSName.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Email</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtCMSEmail.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Contact No</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtCMSPhone.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Event Date</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + Convert.ToDateTime(txtEventDate.Value).ToString("ddd, dd MMM yyyy") + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Enquiry Type</td>");
            str.Append("<td>:</td>");
            str.Append("<td>CMS Page</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Enquiry For</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtCMSNameType.Text + "</td>");
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
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>" + txtCMSName.Text + "</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("<div style='background:#172061; margin:15px; border-left:solid #a78343 6px; border-right:solid #000 6px; color:#fff; text-align:center;'><h2 style='color:#fff; letter-spacing:4px; font:CMS 22px/1 Verdana, Helvetica; padding:8px 0px; text-align:center;'><a href='https://www.aapnoghar.com/' style='color: #fff; text-decoration:none;'>www.aapnoghar.com</a></h2></div>");
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
                ObjMail.MailTo = txtCMSEmail.Text;
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
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + txtCMSName.Text.TrimStart() + ",<br /><br /></p>");
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