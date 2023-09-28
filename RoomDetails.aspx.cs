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
using System.Web.Services;

namespace AapnoGharWeb
{
    public partial class RoomDetails : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
        RoomData ObjRoomData = new RoomData();
        SqlDataReader SqlReader;
        int RoomID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Convert.ToString(Page.RouteData.Values["RoomNameAlias"]) != string.Empty))
                {
                    RoomID = Convert.ToInt16(ObjRoomData.SelectRoomIDbyRoomNameAlias(Convert.ToString(Page.RouteData.Values["RoomNameAlias"])));
                    if (RoomID > 0)
                    {
                        hdnRoomURL.Value = Page.RouteData.Values["RoomNameAlias"].ToString();
                        hdnRoomID.Value = hdnSerachRoomID.Value = RoomID.ToString();
                        ObjRoomData.RoomID = RoomID;
                        SqlReader = ObjRoomData.SelectActiveRoomDataByRoomID();
                        FillData(SqlReader);
                        BindTop6ActiveRoomsForRealted(RoomID);
                        BindRoomDataPriceByRoomID(RoomID);
                        BindAllActiveRoomAmenitiesByRoomID(RoomID);
                        BindAllGalleryImges(RoomID);
                        if (Request.QueryString["CheckIn"] != null && Request.QueryString["CheckIn"].ToString() != "")
                        {
                            txtchecin.Value = Request.QueryString["CheckIn"].ToString();
                            hdnToDate.Value = Request.QueryString["CheckIn"].ToString();
                        }
                        if (Request.QueryString["CheckOut"] != null && Request.QueryString["CheckOut"].ToString() != "")
                        {
                            txtchecout.Value = Request.QueryString["CheckOut"].ToString();
                            hdnEndDate.Value = Request.QueryString["CheckOut"].ToString();
                        }
                        if (Request.QueryString["StayPacakge"] != null && Request.QueryString["StayPacakge"].ToString() != "" && Request.QueryString["StayPacakge"].ToString() == "Stay")
                        {
                            hdnStayPacakge.Value = Request.QueryString["StayPacakge"].ToString();
                        }
                        else
                            hdnStayPacakge.Value = "";
                        if(ltrAmenitiesData.Text == "")
                        {
                            if (ltrRoomCancellationPolicy1.Text != "")
                                ltrRoomCancellationPolicy1.Text = "<li class='active' data-tab='tab_Cancellation'>Cancellation Policy</li>";
                            else
                            {
                                if (ltrRoomResortPolicy1.Text != "")
                                    ltrRoomResortPolicy1.Text = "<li class='active' data-tab='tab_Resort_policy'>Resort Policy</li>";
                                else
                                    PnlAllDetaisl.Visible = false;
                            }
                        }
                        if (hdnToDate.Value != "" && hdnEndDate.Value != "")
                        {
                            DateTime CheckInDate1 = DateTime.ParseExact(hdnToDate.Value.Replace("-", "/"), "MM/dd/yyyy", null);
                            DateTime CheckOutDate1 = DateTime.ParseExact(hdnEndDate.Value.Replace("-", "/"), "MM/dd/yyyy", null);
                            TimeSpan objTimeSpan = CheckOutDate1 - CheckInDate1;
                            //TotalDays  
                            double Days = Convert.ToDouble(objTimeSpan.TotalDays);

                            int TotalNoOfDays = Convert.ToInt16(Days);
                            if (TotalNoOfDays == 0)
                                TotalNoOfDays = 1;
                            hdnTotalNight.Value = TotalNoOfDays.ToString();
                        }
                        if (HttpContext.Current.Session["dtCartRoom"] != null)
                            hdnSerachRoomID.Value = "1";
                    }
                    else
                        Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
                }
                else
                    Response.Redirect("/Something-went-wrong?MSG=Weddeing Event Page Not Found");
            }
        }

        #region Room Data
        private void FillData(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                ltrBanner.Text = "<img src='/AapnoGharlmages/RoomImages/" + SqlReader["RoomBannerImg"].ToString() + "' alt='" + SqlReader["RoomNameAlias"].ToString() + "' title='" + SqlReader["RoomName"].ToString() + "' />";
                hdnRoomName.Value = ltrRoomName.Text = SqlReader["RoomName"].ToString();
                if (SqlReader["RoomSmallDescription"].ToString() != "")
                    ltrRoomSmallDescription.Text = "<p>" + SqlReader["RoomSmallDescription"].ToString() + "</p>";
                if (SqlReader["Room360View"].ToString() != "")
                    ltrRoom360View.Text = "<div class='txview'> <a href='" + SqlReader["Room360View"].ToString() + "' target='_blank'> <p>360<sup>o</sup></p> <span>View</span> </a> </div>";
                ltrRoomDescription.Text = SqlReader["RoomDescription"].ToString();
                if (ltrRoomDescription.Text != "")
                    pnlRoomDescription.Visible = true;
                ltrTotalGuest.Text = SqlReader["TotalGuest"].ToString();

                ltrRoomCancellationPolicy.Text = SqlReader["RoomCancellationPolicy"].ToString();
                if (ltrRoomCancellationPolicy.Text != "")
                {
                    ltrRoomCancellationPolicy1.Text = "<li data-tab='tab_Cancellation'>Cancellation Policy</li>";
                    PnlRoomCancellationPolicy.Visible = true;
                }
                ltrRoomResortPolicy.Text = SqlReader["RoomResortPolicy"].ToString();
                if (ltrRoomResortPolicy.Text != "")
                {
                    ltrRoomResortPolicy1.Text = "<li data-tab='tab_Resort_policy'>Resort Policy</li>";
                    PnlRoomResortPolicy.Visible = true;
                }
                if (SqlReader["RoomOtherDescription"].ToString() != "")
                {
                    ltrRoomOtherDescription1.Text = "<div class='staypackText'> <div class='icon'><img src='assets/icons/tray.png' alt='amusement park' /></div> <p><span>Family Stay Packages for 1 Night</span> <a href='https://www.aapnoghar.com/packages' target='_blank'>Click Here</a></p> </div>";//<a href='javascript:void(0)' data-model='.Model-FamilyStayPacke' class='model-open'>
                    ltrRoomOtherDescription.Text = SqlReader["RoomOtherDescription"].ToString();                    
                }
                else
                    PnlRoomOtherDescription.Visible = false;

                hdnRoomImage.Value = SqlReader["RoomDefaultImage"].ToString();
                hdnRoomSmallDescription.Value = SqlReader["RoomSmallDescription"].ToString();
                hdnNumbersOfRooms.Value = SqlReader["TotalNoRoom"].ToString();
                hdnNumbersOfAdulst.Value = SqlReader["NoofAdults"].ToString();
                hdnNumbersOfChild.Value = SqlReader["NoofChildren"].ToString();
                hdnKidsAgeParameter.Value = SqlReader["KidsAgeParameter"].ToString();
                hdnKidsAgeExtraprice.Value = SqlReader["ChildrenCharges"].ToString();

                AddMetaTags(SqlReader["MetaTitle"].ToString(), SqlReader["MetaKeyword"].ToString(), SqlReader["MetaDescription"].ToString(), SqlReader["MetaSchema"].ToString(), SqlReader["RoomBannerImg"].ToString());
            }
        }

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
            imageMetaOG.Content = "https://www.aapnoghar.com/AapnoGharlmages/RoomImages/" + MetaImg;

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = MetaTitle;
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = MetaDescription;
            HtmlMeta imageMetaTwitter = (HtmlMeta)Master.FindControl("imageMetaTwitter");
            imageMetaTwitter.Content = "https://www.aapnoghar.com/AapnoGharlmages/RoomImages/" + MetaImg;

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = MetaTitle;
            HtmlMeta descriptionGoogle = (HtmlMeta)Master.FindControl("descriptionGoogle");
            descriptionGoogle.Content = MetaDescription;
            HtmlMeta imageMetaGoogle = (HtmlMeta)Master.FindControl("imageMetaGoogle");
            imageMetaGoogle.Content = "https://www.aapnoghar.com/AapnoGharlmages/RoomImages/" + MetaImg;

            if (MetaSchema != "")
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", MetaSchema, false);
        }
        #endregion

        #region Gallery Data
        private void BindAllGalleryImges(int RoomID)
        {
            GalleryData ObjGalleryData = new GalleryData();
            DataSet ds = new DataSet();
            ObjGalleryData.GalleryFor = "Room";
            ObjGalleryData.ActivityID = RoomID;
            ds = ObjGalleryData.SelectAllGalleryImges();
            if (ds.Tables[0].Rows.Count > 0)
            {

                RptrGalleryData1.DataSource = ds.Tables[0];
                RptrGalleryData1.DataBind();
                RptrGalleryData1.Visible = true;
                PnlImageOrGallery.Visible = true;
            }
            else
            {
                RptrGalleryData1.Visible = false;
                PnlImageOrGallery.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjGalleryData = null;
        }
        #endregion

        #region Rooms Price Data
        private void BindRoomDataPriceByRoomID(int RoomID)
        {
            RoomPrice ObjRoomPrice = new RoomPrice();
            DataSet ds = new DataSet();
            ObjRoomPrice.RoomID = RoomID;
            ds = ObjRoomPrice.SelectRoomDataPriceByRoomID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ltrTypeName.Text = ds.Tables[0].Rows[0]["TypeName"].ToString();
                ltrPrice.Text = (Convert.ToInt32(ds.Tables[0].Rows[0]["RoomDefaultPrice"].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[0]["RoomDefaultPriceTaxs"].ToString())).ToString();
                RptrRoomPriceData.DataSource = ds.Tables[0];
                RptrRoomPriceData.DataBind();
                RptrRoomPriceData.Visible = true;
                PnlPrice.Visible = true;
                PnlPrice1.Visible = true;
            }
            else
            {
                RptrRoomPriceData.Visible = false;
                PnlPrice.Visible = false;
                PnlPrice1.Visible = false;
                ltrRoomBookingBySalesTeam.Text = "<div class='no_room_found'><p><b>For booking call to our sales team at <a href='tel:+917666779997'>+91-7666779997</a>.</b></p></div>";
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomPrice = null;
        }
        #endregion

        #region Rooms Amenities Data
        private void BindAllActiveRoomAmenitiesByRoomID(int RoomID)
        {
            RoomAmenitiesData ObjRoomAmenitiesData = new RoomAmenitiesData();
            DataSet ds = new DataSet();
            ObjRoomAmenitiesData.RoomID = RoomID;
            ds = ObjRoomAmenitiesData.SelectAllActiveRoomAmenitiesByRoomID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ltrAmenitiesData.Text = "<li class='active' data-tab='tab_Amenities'>Amenities</li>";
                RptrAmenitiesData.DataSource = ds.Tables[0];
                RptrAmenitiesData.DataBind();
                RptrAmenitiesData.Visible = true;
                PnlAmenitiesData.Visible = true;
            }
            else
            {
                RptrAmenitiesData.Visible = false;
                PnlAmenitiesData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomAmenitiesData = null;
        }
        #endregion

        #region Related Rooms Data
        private void BindTop6ActiveRoomsForRealted(int RoomID)
        {
            RoomData ObjRoomData = new RoomData();
            DataSet ds = new DataSet();
            ObjRoomData.RoomID = RoomID;
            ds = ObjRoomData.SelectTop6ActiveRoomsForRealted();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRelatedRomData.DataSource = ds.Tables[0];
                RptrRelatedRomData.DataBind();
                RptrRelatedRomData.Visible = true;
                PnlRelatedRomData.Visible = true;
            }
            else
            {
                RptrRelatedRomData.Visible = false;
                PnlRelatedRomData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomData = null;
        }
        #endregion

        #region Check Number Of Rooms Available
        [WebMethod]
        public static string CheckNumbersOfRoomAvailable(string RoomID, string CheckInDate, string CheckOutDate)
        {
            DataSet ds = new DataSet();
            RoomBookData ObjRoomBookData = new RoomBookData();
            string FinalResult = "";
            DateTime CheckInDate1 = DateTime.ParseExact(CheckInDate.Replace("-", "/"), "MM/dd/yyyy", null);
            DateTime CheckOutDate1 = DateTime.ParseExact(CheckOutDate.Replace("-", "/"), "MM/dd/yyyy", null);
            ObjRoomBookData.RoomID = Convert.ToInt32(RoomID);
            ObjRoomBookData.BookingDate = CheckInDate1;
            ObjRoomBookData.UpdatedOn = CheckOutDate1;
            ds = ObjRoomBookData.SelectRoomBookForByRoomIDAndBookingDate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                FinalResult = ds.Tables[0].Rows[0]["TotalBookRooms"].ToString();
            }
            else
                FinalResult = "-2";


            return FinalResult.ToString();
        }
        #endregion

        #region Add To Cart
        [WebMethod]
        public static string SaveRoomCartToCart(string Room, string RoomName, string RoomURL, string RoomImage, string RoomSmallDescription, string RoomType, string RoomPrice, string RoomPriceTax, string RoomExPrice, string RoomExPriceTax, string TotalAdults, string TotalKids, string RoomKidsAge, string TotalKidsAge, string TotalKidsAgeTwo, string TotalKidsPrice, string CheckInDate, string CheckOutDate, string TotalNight, string TotalRooms, string NoOfRooms)
        {
            int CreateCartTableNow = 0;
            if (Convert.ToInt16(TotalNight) == 0)
            {
                DateTime CheckInDate1 = DateTime.ParseExact(CheckInDate.Replace("-", "/"), "MM/dd/yyyy", null);
                DateTime CheckOutDate1 = DateTime.ParseExact(CheckOutDate.Replace("-", "/"), "MM/dd/yyyy", null);
                TimeSpan objTimeSpan = CheckOutDate1 - CheckInDate1;
                //TotalDays  
                double Days = Convert.ToDouble(objTimeSpan.TotalDays);

                TotalNight = (Convert.ToInt16(Days)).ToString();
                if (Convert.ToInt16(TotalNight) == 0)
                    TotalNight = "1";
            }
            if (HttpContext.Current.Session["dtCartRoom"] == null)
            {
                CreateCartTableNow = 1;
                CreateCartTable();
            }
            SaveInCartList(Room, RoomName, RoomURL, RoomImage, RoomSmallDescription, RoomType, RoomPrice, RoomPriceTax, RoomExPrice, RoomExPriceTax, TotalAdults, TotalKids, RoomKidsAge, TotalKidsAge, TotalKidsAgeTwo, TotalKidsPrice, CheckInDate, CheckOutDate, TotalNight, TotalRooms, NoOfRooms);
            return TotalNight;
        }

        private static void SaveInCartList(string Room, string RoomName, string RoomURL, string RoomImage, string RoomSmallDescription, string RoomType, string RoomPrice, string RoomPriceTax, string RoomExPrice, string RoomExPriceTax, string TotalAdults, string TotalKids, string RoomKidsAge, string TotalKidsAge, string TotalKidsAgeTwo, string TotalKidsPrice, string CheckInDate, string CheckOutDate, string TotalNight, string TotalRooms, string NoOfRooms)
        {
            ManageException ObjEx = new ManageException();
            bool status = false;
            DataTable dtCartRoom = new DataTable();
            dtCartRoom = (DataTable)HttpContext.Current.Session["dtCartRoom"];
            try
            {
                if (dtCartRoom.Rows.Count > 0)
                {
                    if (status == false)
                        AddToCart(Room, RoomName, RoomURL, RoomImage, RoomSmallDescription, RoomType, RoomPrice, RoomPriceTax, RoomExPrice, RoomExPriceTax, TotalAdults, TotalKids, RoomKidsAge, TotalKidsAge, TotalKidsAgeTwo, TotalKidsPrice, CheckInDate, CheckOutDate, TotalNight, TotalRooms, NoOfRooms);
                }
                else
                    AddToCart(Room, RoomName, RoomURL, RoomImage, RoomSmallDescription, RoomType, RoomPrice, RoomPriceTax, RoomExPrice, RoomExPriceTax, TotalAdults, TotalKids, RoomKidsAge, TotalKidsAge, TotalKidsAgeTwo, TotalKidsPrice, CheckInDate, CheckOutDate, TotalNight, TotalRooms, NoOfRooms);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in function SaveInCartList()", ex);
            }
        }

        private static void AddToCart(string Room, string RoomName, string RoomURL, string RoomImage, string RoomSmallDescription, string RoomType, string RoomPrice, string RoomPriceTax, string RoomExPrice, string RoomExPriceTax, string TotalAdults, string TotalKids, string RoomKidsAge, string TotalKidsAge, string TotalKidsAgeTwo, string TotalKidsPrice, string CheckInDate, string CheckOutDate, string TotalNight, string TotalRooms, string NoOfRooms)
        {
            DataTable dtCartRoom = new DataTable();
            dtCartRoom = (DataTable)HttpContext.Current.Session["dtCartRoom"];
            addrow(Room, RoomName, RoomURL, RoomImage, RoomSmallDescription, RoomType, RoomPrice, RoomPriceTax, RoomExPrice, RoomExPriceTax, TotalAdults, TotalKids, RoomKidsAge, TotalKidsAge, TotalKidsAgeTwo, TotalKidsPrice, CheckInDate, CheckOutDate, TotalNight, TotalRooms, NoOfRooms);
        }

        public static void addrow(string Room, string RoomName, string RoomURL, string RoomImage, string RoomSmallDescription, string RoomType, string RoomPrice, string RoomPriceTax, string RoomExPrice, string RoomExPriceTax, string TotalAdults, string TotalKids, string RoomKidsAge, string TotalKidsAge, string TotalKidsAgeTwo, string TotalKidsPrice, string CheckInDate, string CheckOutDate, string TotalNight, string TotalRooms, string NoOfRooms)
        {
            DataTable dtCartRoom = new DataTable();
            dtCartRoom = (DataTable)HttpContext.Current.Session["dtCartRoom"];
            DataRow dr = dtCartRoom.NewRow();
            dr["RoomID"] = Convert.ToInt32(Room);
            dr["RoomName"] = RoomName;
            dr["RoomURL"] = RoomURL;
            dr["RoomImage"] = RoomImage;
            dr["RoomSmallDescription"] = RoomSmallDescription;
            dr["RoomType"] = RoomType;
            dr["RoomPrice"] = Convert.ToInt32(RoomPrice);
            dr["RoomPriceTax"] = Convert.ToInt32(RoomPriceTax);
            dr["RoomExPrice"] = Convert.ToInt32(RoomExPrice);
            dr["RoomExPriceTax"] = Convert.ToInt32(RoomExPriceTax);
            dr["TotalAdults"] = Convert.ToInt32(TotalAdults);
            dr["TotalKids"] = Convert.ToInt32(TotalKids);
            dr["RoomKidsAge"] = Convert.ToInt32(RoomKidsAge);
            if (Convert.ToInt16(TotalKidsAge) > 0)
                dr["TotalKidsAge1"] = Convert.ToInt32(TotalKidsAge);
            else
                dr["TotalKidsAge1"] = 0;
            if (Convert.ToInt16(TotalKidsAgeTwo) > 0)
                dr["TotalKidsAge2"] = Convert.ToInt32(TotalKidsAgeTwo);
            else
                dr["TotalKidsAge2"] = 0;
            dr["TotalKidsPrice"] = Convert.ToInt32(TotalKidsPrice);
            dr["CheckInDate"] = CheckInDate;
            dr["CheckOutDate"] = CheckOutDate;
            dr["TotalNight"] = Convert.ToInt32(TotalNight);
            dr["TotalRooms"] = Convert.ToInt32(TotalRooms);
            dr["NoOfRooms"] = Convert.ToInt32(NoOfRooms);
            dr["SoldOut"] = 0;
            dtCartRoom.Rows.Add(dr);
            HttpContext.Current.Session["dtCartRoom"] = dtCartRoom;
        }

        public static void CreateCartTable()
        {
            DataTable dtCartRoom = new DataTable();
            dtCartRoom = new DataTable("dtCartRoom");
            dtCartRoom.Columns.Add("AddToCartID", typeof(int));
            dtCartRoom.Columns["AddToCartID"].AutoIncrement = true;
            dtCartRoom.Columns["AddToCartID"].AutoIncrementSeed = 1;
            dtCartRoom.Columns.Add("RoomID", typeof(int));
            dtCartRoom.Columns.Add("RoomName", typeof(string));
            dtCartRoom.Columns.Add("RoomURL", typeof(string));
            dtCartRoom.Columns.Add("RoomImage", typeof(string));            
            dtCartRoom.Columns.Add("RoomSmallDescription", typeof(string));
            dtCartRoom.Columns.Add("RoomType", typeof(string));
            dtCartRoom.Columns.Add("RoomPrice", typeof(int));
            dtCartRoom.Columns.Add("RoomPriceTax", typeof(int));
            dtCartRoom.Columns.Add("RoomExPrice", typeof(int));
            dtCartRoom.Columns.Add("RoomExPriceTax", typeof(int));
            dtCartRoom.Columns.Add("TotalAdults", typeof(int));
            dtCartRoom.Columns.Add("TotalKids", typeof(int));
            dtCartRoom.Columns.Add("RoomKidsAge", typeof(int));
            dtCartRoom.Columns.Add("TotalKidsAge1", typeof(int));
            dtCartRoom.Columns.Add("TotalKidsAge2", typeof(int));
            dtCartRoom.Columns.Add("TotalKidsPrice", typeof(int));
            dtCartRoom.Columns.Add("CheckInDate", typeof(string));
            dtCartRoom.Columns.Add("CheckOutDate", typeof(string));
            dtCartRoom.Columns.Add("TotalNight", typeof(int));
            dtCartRoom.Columns.Add("TotalRooms", typeof(int));
            dtCartRoom.Columns.Add("NoOfRooms", typeof(int));
            dtCartRoom.Columns.Add("SoldOut", typeof(int));
            HttpContext.Current.Session["dtCartRoom"] = dtCartRoom;
        }


        #region Delete From To Cart
        [WebMethod]
        public static string DeleteRoomBookingModuleByListID(string Room)
        {
            string FinalResult = "";
            if (HttpContext.Current.Session["dtCartRoom"] != null)
            {
                int ret = 0;
                StringBuilder sb = new StringBuilder();
                DataTable dt = new DataTable();
                dt = ((DataTable)HttpContext.Current.Session["dtCartRoom"]);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt64(dt.Rows[i]["RoomID"]) == Convert.ToInt16(Room))
                        {
                            dt.Rows[i].Delete();
                            ret = 1;
                        }
                    }
                }
                if (ret > 0)
                    HttpContext.Current.Session["dtCartRoom"] = dt;
                else
                    FinalResult = "";
            }
            else
                FinalResult = "0";
            return FinalResult;
        }
        #endregion Add To Cart
        #endregion Add To Cart
    }
}