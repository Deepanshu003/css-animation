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


namespace AapnoGharWeb
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddMetaTags();
                string CorporateMetaSchema = "<script type='application/ld+json'>{\"@context\":\"https://schema.org\",\"@type\":\"Organization\",\"name\":\"AapnoGhar (Resort, Water Park, Amusement Park)\",\"url\":\"https://www.aapnoghar.com/\",\"logo\":\"https://www.aapnoghar.com/assets/images/aapnoghar-resort-water-park-amusement-park.png\",\"sameAs\":[\"https://www.facebook.com/aapnoghargurgaon/\",\"https://www.instagram.com/aapnoghargurgaon/\",\"https://twitter.com/aapnogharresort\", \"https://www.youtube.com/channel/UCdzxHMQ7qLsz-a1Qxbc7kqg\"],\"contactPoint\":[{\"@type\":\"ContactPoint\",\"telephone\":\"+917666779997\",\"contactType\":\"customer service\"}],\"address\":{\"@type\":\"PostalAddress\",\"streetAddress\":\"43rd Mile Stone, NH8, Delhi-Jaipur Expy, Sector 77\",\"addressRegion\":\"Gurugram\",\"postalCode\":\"122004\",\"addressCountry\":\"India\"}}</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", CorporateMetaSchema, false);

                string LocalMetaSchema = "<script type=\"application/ld+json\">{\"@context\":\"https://schema.org\",\"@type\":\"LocalBusiness\",\"name\":\"AapnoGhar (Resort, Water Park, Amusement Park)\",\"url\":\"https://www.aapnoghar.com/\",\"image\":\"https://www.aapnoghar.com/assets/images/aapnoghar-resort-water-park-amusement-park.png\",\"priceRange\":\"AapnoGhar (Resort, Water Park, Amusement Park)\",\"telephone\":\"+917666779997\",\"email\":\"info@aapnoghar.com\",\"address\": {\"@type\":\"PostalAddress\",\"streetAddress\":\"43rd Mile Stone, NH8, Delhi-Jaipur Expy, Sector 77\",\"addressLocality\":\"Gurugram\",\"addressCountry\":\"India\",\"postalCode\":\"122004\"},\"aggregateRating\": {\"@type\":\"AggregateRating\",\"ratingValue\":\"4.5\",\"bestRating\":\"5\",\"reviewCount\":\"1501\"},\"openingHours\":[\"Mon-Sun 10:30 AM - 10.30 PM\"]}</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", LocalMetaSchema, false);
            }
            btnNormalSubmit.Attributes.Add("OnClick", "return PageCheckNormalInquiryMaster();");
        }

        #region Normal Enquiry
        protected void btnNormalSubmit_Click(object sender, EventArgs e)
        {
            Contact ObjContact = new Contact();
            int ret;
            if ((txtMainEmail1.Text == "") && (txtNormalInquiryName.Text != "") && (txtNormalInquiryEmail.Text != "") && (txtNormalInquiryPhone.Text != "") && (textarea1.Value != ""))
            {
                bool containsLetter = Regex.IsMatch(txtNormalInquiryPhone.Text.TrimStart(), "[A-Z]");
                if (containsLetter == false)
                {
                    try
                    {
                        ObjContact.FirstName = txtNormalInquiryName.Text.TrimStart();
                        ObjContact.PhoneNo = txtNormalInquiryPhone.Text.TrimStart();
                        ObjContact.EmailID = txtNormalInquiryEmail.Text.TrimStart();
                        ObjContact.DateOfVisit = Convert.ToDateTime(txtNormalInquiryDate.Value);
                        ObjContact.Message = textarea1.Value;
                        ObjContact.Enquiryfor = hdnInterested.Value;
                        ObjContact.EnquiryType = "Normal Enquiry";
                        ObjContact.PageName = HttpContext.Current.Request.Url.AbsoluteUri;
                        ObjContact.PostedDate = DateTime.UtcNow;
                        ret = ObjContact.SaveNewEnquiry();
                        if (ret != -1)
                        {
                            SendMailToAdmin();
                            SendMailToUser();
                            txtNormalInquiryName.Text = "";
                            txtNormalInquiryEmail.Text = "";
                            txtNormalInquiryPhone.Text = "";
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
                ObjMail.Subject = "User Details of Normal Enquiry";
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
            str.Append("<div style='background:#172061;margin:15px;border-left:solid #a78343 5px;border-right:solid #000 5px;color:#fff'><h2 style='text-transform: uppercase;color: #FFF;margin: 0 0 30px 0;letter-spacing: 4px;font: WeddingEvent 22px/1 Verdana, Helvetica;position: relative;padding:8px 0px 8px 20px;'>Normal Enquiry : Visitor Details</h2></div>");
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
            str.Append("<td width='85%'>" + txtNormalInquiryName.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Email</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtNormalInquiryEmail.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Contact No</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtNormalInquiryPhone.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Event Date</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + Convert.ToDateTime(txtNormalInquiryDate.Value).ToString("ddd, dd MMM yyyy") + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Enquiry Type</td>");
            str.Append("<td>:</td>");
            str.Append("<td>Normal Enquiry</td>");
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
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>" + txtNormalInquiryName.Text + "</td>");
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
                ObjMail.MailTo = txtNormalInquiryEmail.Text;
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
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + txtNormalInquiryName.Text.TrimStart() + ",<br /><br /></p>");
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

        private void AddMetaTags()
        {
            Page.Title = "AapnoGhar Direction | Contact AapnoGhar | Resort Near Delhi ncr";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "AapnoGhar Direction | Contact AapnoGhar | Resort Near Delhi ncr";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "Amusement Park &amp; Water Park, 43rd Mile Stone, Village Shikhopur, Delhi Jaipur Road, NH-8, Gurgaon-122004 - Get Directions. Nearest Metro - MG Road. More Banquets In Gurgaon. Resort in Gurgaon, best picnic place near gurgaon, For Best Price &amp; Instant Booking - Call Now : +91-9717771289";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "AapnoGhar Direction | Contact AapnoGhar | Resort Near Delhi ncr";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "Amusement Park &amp; Water Park, 43rd Mile Stone, Village Shikhopur, Delhi Jaipur Road, NH-8, Gurgaon-122004 - Get Directions. Nearest Metro - MG Road. More Banquets In Gurgaon. Resort in Gurgaon, best picnic place near gurgaon, For Best Price &amp; Instant Booking - Call Now : +91-9717771289";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "AapnoGhar Direction | Contact AapnoGhar | Resort Near Delhi ncr";
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = "Amusement Park &amp; Water Park, 43rd Mile Stone, Village Shikhopur, Delhi Jaipur Road, NH-8, Gurgaon-122004 - Get Directions. Nearest Metro - MG Road. More Banquets In Gurgaon. Resort in Gurgaon, best picnic place near gurgaon, For Best Price &amp; Instant Booking - Call Now : +91-9717771289";

            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
        }
    }
}