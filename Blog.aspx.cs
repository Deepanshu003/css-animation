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
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllActiveBlogForlisting();
                AddMetaTags();
            }
        }

        #region Blog Data
        private void BindAllActiveBlogForlisting()
        {
            BlogData ObjBlogData = new BlogData();
            DataSet ds = new DataSet();
            ds = ObjBlogData.SelectAllActiveBlogForlisting();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrBlogData.DataSource = ds.Tables[0];
                RptrBlogData.DataBind();
                RptrBlogData.Visible = true;
                ltrBlog.Text = "";
            }
            else
            {
                RptrBlogData.Visible = false;
                ltrBlog.Text = "<div class='wdth-pc'><div class='err_div'><div class='img_er'><img src='/assets/images/Not-found.gif' alt=''/></div><div class='msg_fst'><p class='hJKWmk'><b>Empty Blogs</b></p><span class='ShopNow'></span></div></div></div>";
            }
            ds.Dispose();
            ds.Clear();
            ObjBlogData = null;
        }
        #endregion

        private void AddMetaTags()
        {
            Page.Title = "Blog - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Blog - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Blog - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Blog - AapnoGhar";
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