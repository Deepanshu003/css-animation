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
    public partial class indexmain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTop2ActiveEntertainmentForHome();
                //BindTop1ActiveEatAndDrinkDataForHome();
                BindAllActivePackageDataPriceByDisplayOnHome();
                BindTopOneActiveCouponCodeForHomePage();
                BindTop6ActiveActiveRoomForHome();
                BindAllActiveWeddeingEventDataForHomeDisplayOnHome();
                BindTop6ActiveTestimonialVideoHome();
            }
        }

        #region Entertainment
        private void BindTop2ActiveEntertainmentForHome()
        {
            EntertainmentData ObjEntertainmentData = new EntertainmentData();
            DataSet ds = new DataSet();
            ds = ObjEntertainmentData.SelectTop2ActiveEntertainmentForHome();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrEntertainmentForHome.DataSource = ds.Tables[0];
                RptrEntertainmentForHome.DataBind();
                RptrEntertainmentForHome.Visible = true;
            }
            else
            {
                RptrEntertainmentForHome.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjEntertainmentData = null;
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

        #region Package
        private void BindAllActivePackageDataPriceByDisplayOnHome()
        {
            PackageData ObjPackageData = new PackageData();
            DataSet ds = new DataSet();
            ds = ObjPackageData.SelectAllActivePackageDataPriceByDisplayOnHome();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrPackageData.DataSource = ds.Tables[0];
                RptrPackageData.DataBind();
                RptrPackageData.Visible = true;

                RptrPackageData1.DataSource = ds.Tables[0];
                RptrPackageData1.DataBind();
                RptrPackageData1.Visible = true;
                PnlPackageData.Visible = true;
            }
            else
            {
                RptrPackageData.Visible = false;
                RptrPackageData1.Visible = false;
                PnlPackageData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjPackageData = null;
        }
        #endregion

        #region Coupons Data
        private void BindTopOneActiveCouponCodeForHomePage()
        {
            CouponData ObjCouponData = new CouponData();
            DataSet ds = new DataSet();
            ds = ObjCouponData.SelectTopOneActiveCouponCodeForHomePage();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrCouponsData.DataSource = ds.Tables[0];
                RptrCouponsData.DataBind();
                RptrCouponsData.Visible = true;
                pnlCouponsData.Visible = true;
            }
            else
            {
                RptrCouponsData.Visible = false;
                pnlCouponsData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
        }
        #endregion

        #region Rooms
        private void BindTop6ActiveActiveRoomForHome()
        {
            RoomData ObjRoomData = new RoomData();
            DataSet ds = new DataSet();
            ds = ObjRoomData.SelectTop6ActiveActiveRoomForHome();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRoomData.DataSource = ds.Tables[0];
                RptrRoomData.DataBind();
                RptrRoomData.Visible = true;
                pnlRoomData.Visible = true;
            }
            else
            {
                RptrRoomData.Visible = false;
                pnlRoomData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomData = null;
        }
        #endregion

        #region Celebrate
        private void BindAllActiveWeddeingEventDataForHomeDisplayOnHome()
        {
            WeddeingEventData ObjWeddeingEventData = new WeddeingEventData();
            DataSet ds = new DataSet();
            ds = ObjWeddeingEventData.SelectAllActiveWeddeingEventDataForHomeDisplayOnHome();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt0 = ds.Tables[0].DefaultView.ToTable(true, "WeddeingEventType");
                RptrWeddeingEventType.DataSource = dt0;
                RptrWeddeingEventType.DataBind();
                RptrWeddeingEventType.Visible = true;

                RptrWeddeingEventType1.DataSource = dt0;
                RptrWeddeingEventType1.DataBind();
                RptrWeddeingEventType1.Visible = true;
                pnlWeddeingEventType.Visible = true;
                foreach (RepeaterItem item in RptrWeddeingEventType1.Items)
                {
                    HiddenField hndWeddeingEventType = (HiddenField)item.FindControl("hndWeddeingEventType");
                    Repeater RptrWeddeingEventData = (Repeater)item.FindControl("RptrWeddeingEventData");
                    DataTable dt1 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "WeddeingEventType='" + hndWeddeingEventType.Value + "'";
                    dt1 = dataView.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        RptrWeddeingEventData.DataSource = dt1;
                        RptrWeddeingEventData.DataBind();
                        RptrWeddeingEventData.Visible = true;
                    }
                    else
                        RptrWeddeingEventData.Visible = false;

                }                
            }
            else
            {
                RptrWeddeingEventType.Visible = false;
                RptrWeddeingEventType1.Visible = false;
                pnlWeddeingEventType.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjWeddeingEventData = null;
        }
        #endregion

        #region Testimonial Data
        private void BindTop6ActiveTestimonialVideoHome()
        {
            VideoGallery ObjVideoGallery = new VideoGallery();
            DataSet ds = new DataSet();
            ds = ObjVideoGallery.SelectTop6ActiveTestimonialVideoHome();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrTestimonial1.DataSource = ds.Tables[0].AsEnumerable().Take(3).CopyToDataTable();
                RptrTestimonial1.DataBind();
                RptrTestimonial1.Visible = true;
                PnlTestimonial1.Visible = true;
                DataView dataView1 = ds.Tables[0].DefaultView;
                DataTable dt1 = dataView1.ToTable();
                if (dt1.Rows.Count > 3)
                {
                    int totalLeftRows = (Convert.ToInt16(dt1.Rows.Count) - 3);
                    dataView1.Sort = "DisplayOrder DESC";
                    DataTable Dtnew1 = dataView1.ToTable();
                    RptrTestimonial2.DataSource = Dtnew1.AsEnumerable().Take(totalLeftRows).CopyToDataTable();
                    RptrTestimonial2.DataBind();
                    RptrTestimonial2.Visible = true;
                    PnlTestimonial2.Visible = true;
                }
                else
                {
                    RptrTestimonial2.Visible = false;
                    PnlTestimonial2.Visible = false;
                }

                PnlTestimonial.Visible = true;
            }
            else
            {
                RptrTestimonial1.Visible = false;
                PnlTestimonial.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjVideoGallery = null;
        }
        #endregion
    }
}