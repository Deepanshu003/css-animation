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
    public partial class EntertainmentDetails : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
        EntertainmentData ObjEntertainmentData = new EntertainmentData();
        SqlDataReader SqlReader;
        int EntertainmentID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Convert.ToString(Page.RouteData.Values["EntertainmentNameAlias"]) != string.Empty))
                {
                    EntertainmentID = Convert.ToInt16(ObjEntertainmentData.SelectEntertainmentIDbyEntertainmentNameAlias(Convert.ToString(Page.RouteData.Values["EntertainmentNameAlias"])));
                    if (EntertainmentID > 0)
                    {
                        ObjEntertainmentData.EntertainmentID = EntertainmentID;
                        SqlReader = ObjEntertainmentData.SelectActiveEntertainmentDataByEntertainmentID();
                        FillData(SqlReader);
                        BindAllGalleryImges(EntertainmentID);
                        BindAllActiveEntertainmentActivityByEntertainmentID(EntertainmentID);
                        //BindAllActiveMealDataByEntertainmentID(EntertainmentID);
                        BindAllActiveEntertainmentForRelated(EntertainmentID);
                        //BindTop1ActiveEatAndDrinkDataForHome();
                        BindAllActiveTestimonialVideoFroEntertainment();
                        //BindAllActiveEntertainmentPackagePriceByEntertainmentID(EntertainmentID);
                    }
                    else
                        Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
                }
                else
                    Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
            }
        }

        #region Entertainment Data
        private void FillData(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                ltrEntertainmentImage1.Text = "<img src='/AapnoGharlmages/EntertainmentImages/" + SqlReader["EntertainmentImage1"].ToString() + "' alt='" + SqlReader["EntertainmentNameAlias"].ToString() + "' title='" + SqlReader["EntertainmentName"].ToString() + "' />";
                ltrEntertainmentName.Text = ltrEntertainmentName1.Text = SqlReader["EntertainmentName"].ToString();
                ltrEntertainmentTiming.Text = SqlReader["EntertainmentTiming"].ToString();
                if (SqlReader["EntertainmentImage2"].ToString() != "")
                    ltrEntertainmentImage2.Text = "<div class='item'><figure><img src='/AapnoGharlmages/EntertainmentImages/" + SqlReader["EntertainmentImage2"].ToString() + "' alt='" + SqlReader["EntertainmentNameAlias"].ToString() + "' title='" + SqlReader["EntertainmentName"].ToString() + "' /></figure></div>";
                if (SqlReader["EntertainmentImage3"].ToString() != "")
                    ltrEntertainmentImage3.Text = "<figure><img src='/AapnoGharlmages/EntertainmentImages/" + SqlReader["EntertainmentImage3"].ToString() + "' alt='" + SqlReader["EntertainmentNameAlias"].ToString() + "' title='" + SqlReader["EntertainmentName"].ToString() + "' /></figure>";
                if (SqlReader["ActiveStatus"].ToString() == "1")
                {
                    ltrBookNowActiveOrNot.Text = "<div class='col'><a class='book_btn scrolltopakage' href='/packages'>Book Now</a></div>";
                    ltrBookNowActiveOrNot1.Text = "<div class='link_btn white_btn text-center'><a href='/packages' class='scrolltopakage'>Book Now</a></div>";
                }
                if (SqlReader["EntertainmentVideoLink"].ToString() != "")
                    ltrEntertainmentVideoLink.Text = "<div class='col'><div class='video_icon model-video model-open' data-model='.Model_Video' data-video='" + SqlReader["EntertainmentVideoLink"].ToString() + "?autoplay=1'><img src='/assets/icons/play.png' alt='' /></div></div>";
                if (SqlReader["EntertainmentFullDescription"] != null && SqlReader["EntertainmentFullDescription"].ToString() != "")
                {
                    ltrEntertainmentFullDescription.Text = SqlReader["EntertainmentFullDescription"].ToString();
                    pnlEntertainmentFullDescription.Visible = true;
                }
                AddMetaTags(SqlReader["MetaTitle"].ToString(), SqlReader["MetaKeyword"].ToString(), SqlReader["MetaDescription"].ToString(), SqlReader["MetaSchema"].ToString(), SqlReader["EntertainmentImage1"].ToString());
            }
            SqlReader.Dispose();
            SqlReader.Close();
        }

        #region Related  Entertainment
        private void BindAllActiveEntertainmentForRelated(int EntertainmentID)
        {
            DataSet ds = new DataSet();
            ObjEntertainmentData.EntertainmentID = EntertainmentID;
            ds = ObjEntertainmentData.SelectAllActiveEntertainmentForRelated();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRelatedEntertainmentData.DataSource = ds.Tables[0];
                RptrRelatedEntertainmentData.DataBind();
                RptrRelatedEntertainmentData.Visible = true;
            }
            else
            {
                RptrRelatedEntertainmentData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
        }
        #endregion

        //#region Eat & Drink
        //private void BindTop1ActiveEatAndDrinkDataForHome()
        //{
        //    EatAndDrinkData ObjEatAndDrinkData = new EatAndDrinkData();
        //    DataSet ds = new DataSet();
        //    ds = ObjEatAndDrinkData.SelectTop1ActiveEatAndDrinkDataForHome();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        RptrEatAndDrink.DataSource = ds.Tables[0];
        //        RptrEatAndDrink.DataBind();
        //        RptrEatAndDrink.Visible = true;
        //    }
        //    else
        //    {
        //        RptrEatAndDrink.Visible = false;
        //    }
        //    ds.Dispose();
        //    ds.Clear();
        //    ObjEatAndDrinkData = null;
        //}
        //#endregion

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
            imageMetaOG.Content = "https://www.aapnoghar.com/AapnoGharlmages/EntertainmentImages/" + MetaImg;

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = MetaTitle;
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = MetaDescription;
            HtmlMeta imageMetaTwitter = (HtmlMeta)Master.FindControl("imageMetaTwitter");
            imageMetaTwitter.Content = "https://www.aapnoghar.com/AapnoGharlmages/EntertainmentImages/" + MetaImg;

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = MetaTitle;
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = MetaDescription;
            HtmlMeta imageMetaGoogle = (HtmlMeta)Master.FindControl("imageMetaGoogle");
            imageMetaGoogle.Content = "https://www.aapnoghar.com/AapnoGharlmages/EntertainmentImages/" + MetaImg;

            if (MetaSchema != "")
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", MetaSchema, false);
        }
        #endregion

        #region Gallery Data
        private void BindAllGalleryImges(int EntertainmentID)
        {
            GalleryData ObjGalleryData = new GalleryData();
            DataSet ds = new DataSet();
            ObjGalleryData.GalleryFor = "Entertainment";
            ObjGalleryData.ActivityID = EntertainmentID;
            ds = ObjGalleryData.SelectAllGalleryImges();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ltrGalleryData.Text = "<div class='more_images'> <h3>" + ds.Tables[0].Rows.Count + "+</h3> <p>Images</p> <a class='view-more-img' href='javascript:void(0);' data-fancybox-trigger='gallery16'></a> </div>";

                if (ltrEntertainmentImage3.Text == "")
                    ltrEntertainmentImage3.Text = ltrEntertainmentImage1.Text;

                RptrGalleryData1.DataSource = ds.Tables[0];
                RptrGalleryData1.DataBind();
                RptrGalleryData1.Visible = true;
                pnlImageOrGallery.Attributes.Add("class", "item has_gallery");
            }
            else
            {
                RptrGalleryData1.Visible = false;
                if (ltrEntertainmentImage3.Text == "")
                    pnlImageOrGallery.Visible = true;
            }
            ds.Dispose();
            ds.Clear();
            ObjGalleryData = null;
        }
        #endregion

        #region Activitie Data
        private void BindAllActiveEntertainmentActivityByEntertainmentID(int EntertainmentID)
        {
            EntertainmentActivityData ObjEntertainmentActivityData = new EntertainmentActivityData();
            DataSet ds = new DataSet();
            ObjEntertainmentActivityData.EntertainmentID = EntertainmentID;
            ds = ObjEntertainmentActivityData.SelectAllActiveEntertainmentActivityByEntertainmentID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (EntertainmentID == 1)
                    ltrActivitiesherading.Text = "Water Slides & Activities";
                else if (EntertainmentID == 2)
                    ltrActivitiesherading.Text = "Thrilling Rides";
                else if (EntertainmentID == 3)
                    ltrActivitiesherading.Text = "Adventurous Activities";

                ltrActivities.Text = ds.Tables[0].Rows.Count.ToString();
                RptrActivities.DataSource = ds.Tables[0];
                RptrActivities.DataBind();
                RptrActivities.Visible = true;
                PnlActivities.Visible = true;
            }
            else
            {
                RptrActivities.Visible = false;
                PnlActivities.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentActivityData = null;
        }
        #endregion

        #region Meals Data
        private void BindAllActiveMealDataByEntertainmentID(int EntertainmentID)
        {
            EntertainmentMealData ObjEntertainmentMealData = new EntertainmentMealData();
            DataSet ds = new DataSet();
            ObjEntertainmentMealData.EntertainmentID = EntertainmentID;
            ds = ObjEntertainmentMealData.SelectAllActiveMealDataByEntertainmentID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt0 = ds.Tables[0].DefaultView.ToTable(true, "EntertainmentMealID", "MealTitle", "MealAlias", "MealDefaultImage", "MealTiming", "ActiveStatus");
                RptrDeliciousFood.DataSource = dt0;
                RptrDeliciousFood.DataBind();
                RptrDeliciousFood.Visible = true;

                RptrDeliciousFood1.DataSource = dt0;
                RptrDeliciousFood1.DataBind();
                RptrDeliciousFood1.Visible = true;
                foreach (RepeaterItem item in RptrDeliciousFood1.Items)
                {
                    HiddenField hndEntertainmentMealID = (HiddenField)item.FindControl("hndEntertainmentMealID");
                    Repeater RptrDeliciousFoodItems = (Repeater)item.FindControl("RptrDeliciousFoodItems");
                    DataTable dt1 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "EntertainmentMealID=" + hndEntertainmentMealID.Value + "";
                    dt1 = dataView.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        RptrDeliciousFoodItems.DataSource = dt1;
                        RptrDeliciousFoodItems.DataBind();
                        RptrDeliciousFoodItems.Visible = true;
                    }
                    else
                        RptrDeliciousFoodItems.Visible = false;
                    dataView.Dispose();
                    dt1.Dispose();
                    dt1.Clear();
                }

                PnlDeliciousFood.Visible = true;
            }
            else
            {
                RptrDeliciousFood.Visible = false;
                RptrDeliciousFood1.Visible = false;
                PnlDeliciousFood.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentMealData = null;
        }
        #endregion

        #region Testimonial Data
        private void BindAllActiveTestimonialVideoFroEntertainment()
        {
            VideoGallery ObjVideoGallery = new VideoGallery();
            DataSet ds = new DataSet();
            ds = ObjVideoGallery.SelectAllActiveTestimonialVideoFroEntertainment();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrTestimonial.DataSource = ds.Tables[0];
                RptrTestimonial.DataBind();
                RptrTestimonial.Visible = true;
                PnlTestimonial.Visible = true;
            }
            else
            {
                RptrTestimonial.Visible = false;
                PnlTestimonial.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjVideoGallery = null;
        }
        #endregion

        #region Package Data
        private void BindAllActiveEntertainmentPackagePriceByEntertainmentID(int EntertainmentID)
        {
            EntertainmentPackagePriceData ObjEntertainmentPackagePriceData = new EntertainmentPackagePriceData();
            DataSet ds = new DataSet();
            ObjEntertainmentPackagePriceData.EntertainmentID = EntertainmentID;
            ds = ObjEntertainmentPackagePriceData.SelectAllActiveEntertainmentPackagePriceByEntertainmentID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrEntertainmentPackages.DataSource = ds.Tables[0];
                RptrEntertainmentPackages.DataBind();
                RptrEntertainmentPackages.Visible = true;
                pnlEntertainmentPackages.Visible = true;
            }
            else
            {
                RptrEntertainmentPackages.Visible = false;
                pnlEntertainmentPackages.Visible = false;
                ltrBookNowActiveOrNot1.Text = ltrBookNowActiveOrNot.Text = "";
            }
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentPackagePriceData = null;
        }
        #endregion
    }
}