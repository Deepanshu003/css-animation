using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AapnoGharWeb
{
    public partial class RoomPackages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddMetaTags();
            }
        }

        private void AddMetaTags()
        {
            Page.Title = "Room Packages - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Room Packages - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Room Packages - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Room Packages - AapnoGhar";
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = "";

            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
        }
    }
}