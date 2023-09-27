using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Component;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

namespace AapnoGharWeb
{
    public partial class BlogDetail : System.Web.UI.Page
    {
        BlogData ObjBlogData = new BlogData();
        int BlogID = 0;
        SqlDataReader SqlReader;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Page.RouteData.Values["BlogTitleURL"]) != string.Empty)
                {
                    BlogID = Convert.ToInt32(ObjBlogData.SelectBlogIDByBlogCategoryIDORBlogTitleURL(Convert.ToString(Page.RouteData.Values["BlogTitleURL"])));
                    if (BlogID > 0)
                    {
                        ObjBlogData.BlogID = Convert.ToInt32(BlogID);
                        SqlReader = ObjBlogData.SelectBlogDataByBlogIDForBlogDetails();
                        fillData(SqlReader);
                        BindRelatedActiveBlogData(BlogID);
                        BindAllActiveEntertainmentForHeader();
                    }
                    else
                        Response.Redirect("/something-went-wrong?MSG=Blog Page not found.");
                }
                else
                    Response.Redirect("/something-went-wrong?MSG=Blog Page not found.");
            }
        }

        #region Blog Data
        private void fillData(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                ltrName.Text = SqlReader["BlogTitle"].ToString();
                ltrImage.Text = "<img src='/AapnoGharlmages/BlogImage/" + SqlReader["LargeImg"].ToString() + "' title='" + SqlReader["BlogTitle"].ToString() + "' alt='" + SqlReader["BlogTitleURL"].ToString() + "'/>'";
                ltrData.Text = SqlReader["Descriptions"].ToString();
                ltrDate.Text = SqlReader["PostedDate"].ToString();
                AddMetaTags(SqlReader["MetaTitle"].ToString(), SqlReader["MetaKeywords"].ToString(), SqlReader["MetaDescriptions"].ToString(), SqlReader["LargeImg"].ToString(), SqlReader["MetaSchema"].ToString());
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
            imageMetaOG.Content = "https://www.aapnoghar.com/AapnoGharlmages/BlogImage/" + MetaImg;

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = MetaTitle;
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = MetaDescription;
            HtmlMeta imageMetaTwitter = (HtmlMeta)Master.FindControl("imageMetaTwitter");
            imageMetaTwitter.Content = "https://www.aapnoghar.com/AapnoGharlmages/BlogImage/" + MetaImg;

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = MetaTitle;
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = MetaDescription;
            HtmlMeta imageMetaGoogle = (HtmlMeta)Master.FindControl("imageMetaGoogle");
            imageMetaGoogle.Content = "https://www.aapnoghar.com/AapnoGharlmages/BlogImage/" + MetaImg;

            if (MetaSchema != "")
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", MetaSchema, false);
        }

        private void BindRelatedActiveBlogData(int BlogID)
        {
            DataSet ds = new DataSet();
            ObjBlogData.BlogID = BlogID;
            ds = ObjBlogData.SelectRelatedActiveBlogData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRelatedBlogData.DataSource = ds.Tables[0];
                RptrRelatedBlogData.DataBind();
                RptrRelatedBlogData.Visible = true;
                PnlRelatedBlogData.Visible = true;
            }
            else
            {
                RptrRelatedBlogData.Visible = false;
                PnlRelatedBlogData.Visible = false;
            }

            ds.Dispose();
            ds.Clear();
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
                RptrEntertainmentForFooter.DataSource = ds.Tables[0];
                RptrEntertainmentForFooter.DataBind();
                RptrEntertainmentForFooter.Visible = true;
            }
            else
                RptrEntertainmentForFooter.Visible = false;
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentData = null;
        }
        #endregion
    }
}