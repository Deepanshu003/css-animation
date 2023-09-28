using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Component;
using Utility;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AapnoGharWeb
{
    public partial class CareerFront : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        JobCategory ObjJobCategory = new JobCategory();
        CareerJob ObjJobCareer = new CareerJob();
        CommanFunction ObjComm = new CommanFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdJobCategory();
                SelectAllJobData();
                AddMetaTags();
            }
            linkbtnSubmit.Attributes.Add("OnClick", "return pagecheckCareerEnquiry();");
        }

        private void BindDdJobCategory()
        {
            ObjJobCategory.BindDdJobCategory(ddJobCategory, "JobCategoryName", "JobCategoryID");
            ddJobCategory.Items.Insert(0, new ListItem("Select Job Category*", "0"));
        }
        public void SelectAllJobData()
        {
            DataSet ds = new DataSet();
            ds = ObjJobCategory.SelectAllActiveJobCategoryData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptJobOpeningList.DataSource = ds.Tables[0];
                RptJobOpeningList.DataBind();
                RptJobOpeningList.Visible = true;
                PnlJobOpeningList.Visible = true;
                PnlJobOpeningList1.Visible = true;
            }
            ds.Dispose();
            ds.Clear();
        }

        private string getContentType(string strPath)
        {
            string StrPath = Path.GetExtension(strPath).ToString();
            string StrExt = "";
            if (StrPath.ToLower().Equals(".pdf"))
            {
                StrExt = ".pdf";
            }
            else if (StrPath.ToLower().Equals(".doc"))
            {
                StrExt = ".doc";
            }
            else if (StrPath.ToLower().Equals(".docx"))
            {
                StrExt = ".docx";
            }
            else if (StrPath.ToLower().Equals(".txt"))
            {
                StrExt = ".txt";
            }

            return StrExt;
        }
        protected void linkbtnSubmit_Click(object sender, EventArgs e)
        {
            if ((txtNameCareer.Text != "") && (txtEmailIdCareer.Text != ""))
            {
                int ret;
                string file = string.Empty;
                try
                {
                    ObjJobCareer.Name = txtNameCareer.Text.TrimStart();
                    ObjJobCareer.EmailID = txtEmailIdCareer.Text.TrimStart();
                    ObjJobCareer.PhoneNo = txtContactCareer.Text;
                    ObjJobCareer.RemarksIfAny = textarea1.Value;
                    ObjJobCareer.JobCategoryID = Convert.ToInt32(ddJobCategory.SelectedValue);
                    if (UploadedCV_Career.Value != "")
                    {
                        file = txtContactCareer.Text;
                        file = file + getContentType(UploadedCV_Career.Value);
                        ObjJobCareer.AttachedFile = file.ToString();
                    }
                    ObjJobCareer.PostedDate = DateTime.UtcNow;
                    ret = ObjJobCareer.SaveNewCareerFormData();
                    if (ret == 1)
                    {
                        if (UploadedCV_Career.Value != "" && UploadedCV_Career.PostedFile.ContentLength < 2100000)
                        {
                            ObjComm.fileUpLoad(UploadedCV_Career, "/AapnoGharlmages/Resume", file, Server);
                        }
                        SendMailToUser();
                        SendMailToAdmin();
                        Session["Frontmsg"] = "We appreciate you for the resume submission on our website. We’ll analyze your credentials internally and get back to you if you are selected.";
                        Response.Redirect("/thank-you", false);
                    }
                }
                catch (Exception ex)
                {
                    ObjEx.PublishError("Error in procedure SaveData()", ex);
                }
            }
        }

        private void SendMailToAdmin()
        {
            Mail ObjMail = new Mail();
            try
            {
                ObjMail.Title = "AapnoGhar";
                ObjMail.Subject = "User Details of Career Enquiry";
                ObjMail.Body = this.GetBody();
                int contentLength = UploadedCV_Career.PostedFile.ContentLength;
                if (contentLength <= 2100000 && contentLength > 0)
                {
                    ObjMail.SendMail303(UploadedCV_Career);
                }
            }
            catch (Exception ex)
            {
                ltrError.Text = "Error-a- " + ex.Message.ToString();
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
            str.Append("<div style='background:#172061;margin:15px;border-left:solid #a78343 5px;border-right:solid #000 5px;color:#fff'><h2 style='text-transform: uppercase;color: #FFF;margin: 0 0 30px 0;letter-spacing: 4px;font: WeddingEvent 22px/1 Verdana, Helvetica;position: relative;padding:8px 0px 8px 20px;'>Career Enquiry : Visitor Details</h2></div>");
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
            str.Append("<td width='85%'>" + txtNameCareer.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Email</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtEmailIdCareer.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Contact No</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + txtContactCareer.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Company</td>");
            str.Append("<td>:</td>");
            str.Append("<td>" + ddJobCategory.SelectedItem.Text + "</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td>Remarks</td>");
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
            str.Append("<td style='font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px'>" + txtNameCareer.Text + "</td>");
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
                ObjMail.MailTo = txtEmailIdCareer.Text;
                ObjMail.Title = "AapnoGhar";
                ObjMail.Subject = "Thank you for submitting your resume";
                ObjMail.Body = this.GetBody1();
                ObjMail.SendMail();
            }
            catch (Exception ex)
            {
                ltrError.Text = "Error-u- " + ex.Message.ToString();
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
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + txtNameCareer.Text.TrimStart() + ",<br /><br /></p>");
            str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>We appreciate you for the resume submission on our website. We’ll analyze your credentials internally and get back to you if you are selected.</p>");
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

        private void AddMetaTags()
        {
            Page.Title = "Career - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Career - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "Fill Your Details";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Career - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "Fill Your Details";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Career - AapnoGhar";
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = "Fill Your Details";

            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
        }
    }
}