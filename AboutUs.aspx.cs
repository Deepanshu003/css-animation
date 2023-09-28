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
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTop2ActiveEntertainmentForAboutUs();
                AddMetaTags();
            }
        }

        #region Entertainment
        private void BindTop2ActiveEntertainmentForAboutUs()
        {
            EntertainmentData ObjEntertainmentData = new EntertainmentData();
            DataSet ds = new DataSet();
            ds = ObjEntertainmentData.SelectTop2ActiveEntertainmentForAboutUs();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrEntertainmentForAboutUs.DataSource = ds.Tables[0];
                RptrEntertainmentForAboutUs.DataBind();
                RptrEntertainmentForAboutUs.Visible = true;
            }
            else
                RptrEntertainmentForAboutUs.Visible = false;
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentData = null;
        }
        #endregion

        private void AddMetaTags()
        {
            Page.Title = "Water Park in Delhi ncr ,Water Park in Gurgaon, Resort - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Water Park in Delhi ncr ,Water Park in Gurgaon, Resort - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "Are you looking to cool down on a hot summery day with your family and friends? Or seeking some weatherproof watery fun with your family and friends? Your best friend AapnoGhar has once again come to your delhi ncr ,gurgaon! It’s time to head to AapnoGhar in Gurgaon, delhi. The Family Water Park";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Water Park in Delhi ncr ,Water Park in Gurgaon, Resort - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "Are you looking to cool down on a hot summery day with your family and friends? Or seeking some weatherproof watery fun with your family and friends? Your best friend AapnoGhar has once again come to your delhi ncr ,gurgaon! It’s time to head to AapnoGhar in Gurgaon, delhi. The Family Water Park";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Water Park in Delhi ncr ,Water Park in Gurgaon, Resort - AapnoGhar";
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = "Are you looking to cool down on a hot summery day with your family and friends? Or seeking some weatherproof watery fun with your family and friends? Your best friend AapnoGhar has once again come to your delhi ncr ,gurgaon! It’s time to head to AapnoGhar in Gurgaon, delhi. The Family Water Park";

            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
        }
    }
}