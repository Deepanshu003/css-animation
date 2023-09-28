using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AapnoGharWeb
{
    public partial class PrivacyPolicy : System.Web.UI.Page
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
            Page.Title = "AapnoGhar Privacy Policy";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "AapnoGhar Privacy Policy";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "PRIVACY POLICY Airport Motel And Baza Restaurant (AapnoGhar) welcomes you to its website and looks forward to a meaningful interaction with you. Airport Motel And Baza Restaurant (AapnoGhar) respects your right to privacy. Any personal information that you share with us, like your name, date of birth, address, marital status, telephone number, credit card particulars and";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "AapnoGhar Privacy Policy";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "PRIVACY POLICY Airport Motel And Baza Restaurant (AapnoGhar) welcomes you to its website and looks forward to a meaningful interaction with you. Airport Motel And Baza Restaurant (AapnoGhar) respects your right to privacy. Any personal information that you share with us, like your name, date of birth, address, marital status, telephone number, credit card particulars and";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "AapnoGhar Privacy Policy";
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = "PRIVACY POLICY Airport Motel And Baza Restaurant (AapnoGhar) welcomes you to its website and looks forward to a meaningful interaction with you. Airport Motel And Baza Restaurant (AapnoGhar) respects your right to privacy. Any personal information that you share with us, like your name, date of birth, address, marital status, telephone number, credit card particulars and";

            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
        }
    }
}