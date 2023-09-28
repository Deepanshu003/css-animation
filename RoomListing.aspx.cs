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
    public partial class RoomListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllActiveRoomsForListing();
                AddMetaTags();
            }
            btnCheckAvailability.Attributes.Add("OnClick", "return PageCheckCheckAvailabilityMaster();");
        }

        #region Serach Rooms
        protected void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            Response.Redirect("/" + hdnSerachRoomID.Value + "?CheckIn=" + hdnCheckInDate.Value + "&CheckOut=" + hdnCheckOutDate.Value);
        }
        #endregion

        #region Rooms Data
        private void BindAllActiveRoomsForListing()
        {
            RoomData ObjRoomData = new RoomData();
            DataSet ds = new DataSet();
            ds = ObjRoomData.SelectAllActiveRoomsForListing();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRoomListing.DataSource = ds.Tables[0];
                RptrRoomListing.DataBind();
                RptrRoomListing.Visible = true;
                ltrNoRoom.Text = "";

                DataTable dt1 = new DataTable();
                DataView dataView = new DataView(ds.Tables[0]);
                dataView.RowFilter = "DiscountedPrice>0";
                dt1 = dataView.ToTable();
                if (dt1.Rows.Count > 0)
                {
                    RptrRoomForSearchListing.DataSource = dt1;
                    RptrRoomForSearchListing.DataBind();
                    RptrRoomForSearchListing.Visible = true;
                    PnlRoomForSearchListing.Visible = true;
                }
                else
                {
                    RptrRoomForSearchListing.Visible = false;
                    PnlRoomForSearchListing.Visible = false;
                }
                dataView.Dispose();
                dt1.Dispose();
                dt1.Clear();
            }
            else
            {
                RptrRoomForSearchListing.Visible = false;                
                PnlRoomForSearchListing.Visible = false;

                RptrRoomListing.Visible = false;
                ltrNoRoom.Text = "<div class='wdth-pc'><div class='err_div'><div class='img_er'><img src='/assets/images/Not-found.gif' alt=''/></div><div class='msg_fst'><p class='hJKWmk'><b>No Rooms</b></p><span class='ShopNow'></span></div></div></div>";
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomData = null;
        }
        #endregion

        private void AddMetaTags()
        {
            Page.Title = "Best Resort To Stay In Gurgaon | One Day Stay Resort Gurgaon";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Best Resort To Stay In Gurgaon | One Day Stay Resort Gurgaon";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "Visit to best resort in gurgaon for a quick weekend gateway. Aapnoghar provides you best holiday resort for family. Make sure to visit and make your day memorable!!!";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Best Resort To Stay In Gurgaon | One Day Stay Resort Gurgaon";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "Visit to best resort in gurgaon for a quick weekend gateway. Aapnoghar provides you best holiday resort for family. Make sure to visit and make your day memorable!!!";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Best Resort To Stay In Gurgaon | One Day Stay Resort Gurgaon";
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = "Visit to best resort in gurgaon for a quick weekend gateway. Aapnoghar provides you best holiday resort for family. Make sure to visit and make your day memorable!!!";

            HtmlLink urlCanonical1 = (HtmlLink)Master.FindControl("urlCanonical1");
            urlCanonical1.Href = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta url1 = (HtmlMeta)Master.FindControl("url1");
            url1.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
            HtmlMeta urlOG = (HtmlMeta)Master.FindControl("urlOG");
            urlOG.Content = Request.Url.AbsoluteUri.Split(new[] { '?' })[0];
        }
    }
}