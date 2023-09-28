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
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllActivePhotoDataForImages();
                BindAllActiveVideoFroGalleryData();
                if (ltrVideoGallery.Text == "" && ltrPhotoGallery.Text == "")
                    PnlPhotoAndVideoVideo.Visible = false;
                AddMetaTags();
            }
        }

        #region Photo Gallery Data
        public void BindAllActivePhotoDataForImages()
        {
            PhotoData ObjPhotoData = new PhotoData();
            DataSet ds = new DataSet();
            ds = ObjPhotoData.SelectAllActivePhotoDataForImages();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt0 = ds.Tables[0].DefaultView.ToTable(true, "PhotoCategoryID", "PhotoCategoryName", "PhotoCategoryImage");

                RptrPhotoCategory.DataSource = dt0;
                RptrPhotoCategory.DataBind();
                RptrPhotoCategory.Visible = true;
                pnlPhotoCategory.Visible = true;

                RptrPhotoData.DataSource = ds.Tables[0];
                RptrPhotoData.DataBind();
                RptrPhotoData.Visible = true;
                ltrPhotoGallery.Text = "<li class='active'><a data-attr='image'>Photo Gallery</a></li>";
            }
            else
            {
                RptrPhotoCategory.Visible = false;
                pnlPhotoCategory.Visible = false;
                RptrPhotoData.Visible = false;
            }
        }

        #endregion

        #region Video Gallery Data
        private void BindAllActiveVideoFroGalleryData()
        {
            VideoGallery ObjVideoGallery = new VideoGallery();
            DataSet ds = new DataSet();
            ds = ObjVideoGallery.SelectAllActiveVideoFroGalleryData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrVideoGallery.DataSource = ds.Tables[0];
                RptrVideoGallery.DataBind();
                RptrVideoGallery.Visible = true;
                PnlVideoGallery.Visible = true;
                if (ltrPhotoGallery.Text != "")
                {
                    ltrVideoGallery.Text = "<li><a data-attr='video'>Video Gallery</a></li>";
                    PnlVideoGallery.Attributes.Add("style", "display: none;");
                }
                else
                    ltrVideoGallery.Text = "<li><a data-attr='video'>Video Gallery</a></li>";
            }
            else
            {
                RptrVideoGallery.Visible = false;
                PnlVideoGallery.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjVideoGallery = null;
        }
        #endregion

        private void AddMetaTags()
        {
            Page.Title = "All Gallery - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "All Gallery - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "All Gallery - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "All Gallery - AapnoGhar";
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