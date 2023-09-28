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
    public partial class Packages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Url.AbsoluteUri.ToString().Contains("picnic-packages") == true)
                {
                    BindAllActivePackageDataFroFrontEnd();
                    BindAllActiveEntertainmentPackageForPackagePage();
                    BindAllActiveEntertainmentMealPackageForPackagePage();
                }
                else if (Request.Url.AbsoluteUri.ToString().Contains("family-stay-packages") == true)
                {
                    BindAllActiveRoomsForPackageForListing();
                    BindAllActiveRoomEntertainmentForPackagePage();
                    BindAllActiveRoomFoodEntertainmentForPackagePage();
                }
                //BindAllActivePackageDataFroFrontEnd();                
                //BindAllActiveEntertainmentPackageForPackagePage();
                //BindAllActiveEntertainmentMealPackageForPackagePage();
                //BindAllActiveRoomsForPackageForListing();
                //BindAllActiveRoomEntertainmentForPackagePage();
                //BindAllActiveRoomFoodEntertainmentForPackagePage();
                AddMetaTags();
            }
        }

        #region Package
        private void BindAllActivePackageDataFroFrontEnd()
        {
            PackageData ObjPackageData = new PackageData();
            DataSet ds = new DataSet();
            ds = ObjPackageData.SelectAllActivePackageDataFroFrontEnd();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //RptrPackageData.DataSource = ds.Tables[0];
                //RptrPackageData.DataBind();
                //RptrPackageData.Visible = true;
                ltrPicnicPackages.Text = "<li class='active'><a data-attr='tab_1'>Picnic Packages</a></li>";

                DataTable dt1 = new DataTable();
                DataView dataView = new DataView(ds.Tables[0]);
                dataView.RowFilter = "FestivalDayName='Special Day'";
                dt1 = dataView.ToTable();
                if (dt1.Rows.Count > 0)
                {
                    RptrPackageData1.DataSource = dt1;
                    RptrPackageData1.DataBind();
                    RptrPackageData1.Visible = true;
                }
                DataTable dt2 = new DataTable();
                dataView.RowFilter = "FestivalDayName='Saturday'";
                dt2 = dataView.ToTable();
                if (dt2.Rows.Count > 0)
                {
                    RptrPackageData11.DataSource = dt2;
                    RptrPackageData11.DataBind();
                    RptrPackageData11.Visible = true;
                }
                else
                {
                    dataView.RowFilter = "FestivalDayName='Sunday'";
                    dt2 = dataView.ToTable();
                    if (dt2.Rows.Count > 0)
                    {
                        RptrPackageData11.DataSource = dt2;
                        RptrPackageData11.DataBind();
                        RptrPackageData11.Visible = true;
                    }
                }
                PnlPackageData.Visible = true;
                PnlPacakegItemData.Visible = true;
            }
            else
            {
                //RptrPackageData.Visible = false;
                RptrPackageData1.Visible = false;
                RptrPackageData11.Visible = true;
                PnlPackageData.Visible = false;
                PnlPacakegItemData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjPackageData = null;
        }

        private void BindAllActiveEntertainmentPackageForPackagePage()
        {
            PackageData ObjPackageData = new PackageData();
            DataSet ds = new DataSet();
            ds = ObjPackageData.SelectAllActiveEntertainmentPackageForPackagePage();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataSet ds1 = new DataSet();
                ds1 = ObjPackageData.SelectAllActiveEntertainmentMealPackageForPackagePage();
                DataTable dt = ds.Tables[0].DefaultView.ToTable(true, "PackageID", "PackageTitle");
                RptrPackageData2.DataSource = dt;
                RptrPackageData2.DataBind();
                RptrPackageData2.Visible = true;
                foreach (RepeaterItem item in RptrPackageData2.Items)
                {
                    HiddenField hdnPackageID = (HiddenField)item.FindControl("hdnPackageID");
                    Repeater RptrPackageEntertainmentData = (Repeater)item.FindControl("RptrPackageEntertainmentData");
                    Repeater RptrPackageEntertainmentData1 = (Repeater)item.FindControl("RptrPackageEntertainmentData1");
                    //Repeater RptrDeliciousFood1 = (Repeater)item.FindControl("RptrDeliciousFood1");
                    //Literal ltrDeliciousFood = (Literal)item.FindControl("ltrDeliciousFood");
                    DataTable dt1 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "PackageID=" + hdnPackageID.Value + "";
                    dt1 = dataView.ToTable(true, "PackageID", "EntertainmentID", "EntertainmentName");
                    if (dt1.Rows.Count > 0)
                    {
                        RptrPackageEntertainmentData.DataSource = dt1;
                        RptrPackageEntertainmentData.DataBind();
                        RptrPackageEntertainmentData.Visible = true;

                        RptrPackageEntertainmentData1.DataSource = dt1;
                        RptrPackageEntertainmentData1.DataBind();
                        RptrPackageEntertainmentData1.Visible = true;
                        foreach (RepeaterItem item1 in RptrPackageEntertainmentData1.Items)
                        {
                            HiddenField hdnEntertainmentID = (HiddenField)item1.FindControl("hdnEntertainmentID");
                            Repeater RptrPackageEntertainmentActivitiesData = (Repeater)item1.FindControl("RptrPackageEntertainmentActivitiesData");
                            DataTable dt2 = new DataTable();
                            DataView dataView1 = new DataView(ds.Tables[0]);
                            dataView1.RowFilter = "EntertainmentID=" + hdnEntertainmentID.Value + "";
                            dt2 = dataView1.ToTable(true, "ActivityTitle", "ActivityAlias", "ActivityDefaultImage");
                            if (dt2.Rows.Count > 0)
                            {
                                RptrPackageEntertainmentActivitiesData.DataSource = dt2;
                                RptrPackageEntertainmentActivitiesData.DataBind();
                                RptrPackageEntertainmentActivitiesData.Visible = true;
                            }
                            dataView1.Dispose();
                            dt2.Dispose();
                            dt2.Clear();
                        }
                        dataView.Dispose();
                        dt1.Dispose();
                        dt1.Clear();
                    }
                    else
                    {
                        RptrPackageEntertainmentData.Visible = false;
                        RptrPackageEntertainmentData1.Visible = false;
                    }

                    
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    DataTable dt0 = new DataTable();
                    //    DataView dataView1 = new DataView(ds1.Tables[0]);
                    //    dataView1.RowFilter = "PackageID=" + hdnPackageID.Value + "";
                    //    dt0 = dataView1.ToTable(true, "PackageID", "MealTitle", "MealAlias", "MealDefaultImage", "MealTiming");
                    //    ltrDeliciousFood.Text = "<li><a data-attr='tab_" + hdnPackageID.Value + "_Delicious_Food'>Delicious Food</a></li>";
                    //    RptrDeliciousFood1.DataSource = dt0;
                    //    RptrDeliciousFood1.DataBind();
                    //    RptrDeliciousFood1.Visible = true;
                    //    dataView1.Dispose();
                    //    dt0.Dispose();
                    //    dt0.Clear();
                    //}

                }
                ds1.Dispose();
                ds1.Clear();
                PnlPackageInclusions.Visible = true;
            }
            else
            {
                RptrPackageData2.Visible = false;
                PnlPackageInclusions.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjPackageData = null;
        }

        #region Meals Data
        private void BindAllActiveEntertainmentMealPackageForPackagePage()
        {
            PackageData ObjPackageData = new PackageData();
            DataSet ds = new DataSet();
            ds = ObjPackageData.SelectAllActiveEntertainmentMealPackageForPackagePage();
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataTable dt = ds.Tables[0].DefaultView.ToTable(true, "PackageID", "PackageTitle");
                RptrPackageData3.DataSource = dt;
                RptrPackageData3.DataBind();
                RptrPackageData3.Visible = true;
                foreach (RepeaterItem item in RptrPackageData3.Items)
                {
                    HiddenField hdnPackageID = (HiddenField)item.FindControl("hdnPackageID");
                    Repeater RptrDeliciousFood = (Repeater)item.FindControl("RptrDeliciousFood");
                    Repeater RptrDeliciousFood1 = (Repeater)item.FindControl("RptrDeliciousFood1");

                    DataTable dt0 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    if (hdnPackageID.Value == "2")
                        dataView.RowFilter = "PackageID=" + hdnPackageID.Value + " and (MealTitle Not In('Breakfast', 'Lunch', 'Dinner at the designated area') Or MealTiming Not In('09:30 Am to 11:00 Am', '1:00 Pm To 2:30 Pm', '8:30 pm – 10:30 pm'))";
                    else
                        dataView.RowFilter = "PackageID=" + hdnPackageID.Value + " and (MealTitle Not In('Dinner at the designated area') Or MealTiming Not In('8:30 pm – 10:30 pm'))";
                    dt0 = dataView.ToTable(true, "PackageID", "EntertainmentMealID", "MealTitle", "MealAlias", "MealDefaultImage", "MealTiming");
                    RptrDeliciousFood.DataSource = dt0;
                    RptrDeliciousFood.DataBind();
                    RptrDeliciousFood.Visible = true;

                    RptrDeliciousFood1.DataSource = dt0;
                    RptrDeliciousFood1.DataBind();
                    RptrDeliciousFood1.Visible = true;
                    foreach (RepeaterItem item1 in RptrDeliciousFood1.Items)
                    {
                        HiddenField hndEntertainmentMealID = (HiddenField)item1.FindControl("hndEntertainmentMealID");
                        Repeater RptrDeliciousFoodItems = (Repeater)item1.FindControl("RptrDeliciousFoodItems");
                        DataTable dt1 = new DataTable();
                        DataView dataView1 = new DataView(ds.Tables[0]);
                        dataView1.RowFilter = "PackageID=" + hdnPackageID.Value + " and EntertainmentMealID=" + hndEntertainmentMealID.Value + "";
                        dt1 = dataView1.ToTable(true, "EntertainmentMealID", "MealTitle", "MealAlias", "MealDefaultImage", "MealTiming", "MealItemTitle");
                        if (dt1.Rows.Count > 0)
                        {
                            RptrDeliciousFoodItems.DataSource = dt1;
                            RptrDeliciousFoodItems.DataBind();
                            RptrDeliciousFoodItems.Visible = true;
                        }
                        else
                            RptrDeliciousFoodItems.Visible = false;
                        dataView1.Dispose();
                        dt1.Dispose();
                        dt1.Clear();
                    }
                    dataView.Dispose();
                    dt0.Dispose();
                    dt0.Clear();
                }
                PnlPackageDeliciousFood.Visible = true;
            }
            else
            {
                RptrPackageData3.Visible = false;
                PnlPackageDeliciousFood.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjPackageData = null;
        }
        #endregion
        #endregion

        #region Room Package
        private void BindAllActiveRoomsForPackageForListing()
        {
            RoomData ObjRoomData = new RoomData(); 
            DataSet ds = new DataSet();
            ds = ObjRoomData.SelectAllActiveRoomsForPackageForListing();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptrRoomListingPackage.DataSource = ds.Tables[0];
                RptrRoomListingPackage.DataBind();
                RptrRoomListingPackage.Visible = true;
                PnlRoomPacakeg.Visible = true;
                PnlPackageData.Visible = true;
                ltrFamilyStayPackages.Text = "<li class='active'><a data-attr='tab_2'>Family Stay Packages</a></li>";
                //if (ltrPicnicPackages.Text == "")
                //    ltrFamilyStayPackages.Text = "<li class='active'><a data-attr='tab_2'>Family Stay Packages</a></li>";
                //else
                //    ltrFamilyStayPackages.Text = "<li><a data-attr='tab_2'>Family Stay Packages</a></li>";
                //PnlRoomPacakeg.Attributes.Add("style", "display: block;");
            }
            else
            {
                ltrFamilyStayPackages.Text = "";
                RptrRoomListingPackage.Visible = false;
                PnlRoomPacakeg.Visible = false;
                PnlPackageData.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomData = null;
        }

        private void BindAllActiveRoomEntertainmentForPackagePage()
        {
            RoomEntertainmentData ObjRoomEntertainmentData = new RoomEntertainmentData(); 
            DataSet ds = new DataSet();
            ds = ObjRoomEntertainmentData.SelectAllActiveRoomEntertainmentForPackagePage();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0].DefaultView.ToTable(true, "RoomID", "RoomName");
                RptrRoomListingPackage1.DataSource = dt;
                RptrRoomListingPackage1.DataBind();
                RptrRoomListingPackage1.Visible = true;
                foreach (RepeaterItem item in RptrRoomListingPackage1.Items)
                {
                    HiddenField hdnPackageID = (HiddenField)item.FindControl("hdnPackageID");
                    Repeater RptrPackageEntertainmentData = (Repeater)item.FindControl("RptrPackageEntertainmentData");
                    Repeater RptrPackageEntertainmentData1 = (Repeater)item.FindControl("RptrPackageEntertainmentData1");
                    DataTable dt1 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "RoomID=" + hdnPackageID.Value + "";
                    dt1 = dataView.ToTable(true, "RoomID", "EntertainmentID", "EntertainmentName");
                    if (dt1.Rows.Count > 0)
                    {
                        RptrPackageEntertainmentData.DataSource = dt1;
                        RptrPackageEntertainmentData.DataBind();
                        RptrPackageEntertainmentData.Visible = true;

                        RptrPackageEntertainmentData1.DataSource = dt1;
                        RptrPackageEntertainmentData1.DataBind();
                        RptrPackageEntertainmentData1.Visible = true;
                        foreach (RepeaterItem item1 in RptrPackageEntertainmentData1.Items)
                        {
                            HiddenField hdnEntertainmentID = (HiddenField)item1.FindControl("hdnEntertainmentID");
                            Repeater RptrPackageEntertainmentActivitiesData = (Repeater)item1.FindControl("RptrPackageEntertainmentActivitiesData");
                            DataTable dt2 = new DataTable();
                            DataView dataView1 = new DataView(ds.Tables[0]);
                            dataView1.RowFilter = "EntertainmentID=" + hdnEntertainmentID.Value + "";
                            dt2 = dataView1.ToTable(true, "ActivityTitle", "ActivityAlias", "ActivityDefaultImage");
                            if (dt2.Rows.Count > 0)
                            {
                                RptrPackageEntertainmentActivitiesData.DataSource = dt2;
                                RptrPackageEntertainmentActivitiesData.DataBind();
                                RptrPackageEntertainmentActivitiesData.Visible = true;
                            }
                            dataView1.Dispose();
                            dt2.Dispose();
                            dt2.Clear();
                        }
                        dataView.Dispose();
                        dt1.Dispose();
                        dt1.Clear();
                    }
                    else
                    {
                        RptrPackageEntertainmentData.Visible = false;
                        RptrPackageEntertainmentData1.Visible = false;
                    }
                }
                PnlPackageInclusionsRoom.Visible = true;
            }
            else
            {
                RptrRoomListingPackage1.Visible = false;
                PnlPackageInclusionsRoom.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomEntertainmentData = null;
        }

        #region Meals Data
        private void BindAllActiveRoomFoodEntertainmentForPackagePage()
        {
            RoomEntertainmentData ObjRoomEntertainmentData = new RoomEntertainmentData();
            DataSet ds = new DataSet();
            ds = ObjRoomEntertainmentData.SelectAllActiveRoomFoodEntertainmentForPackagePage();
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataTable dt = ds.Tables[0].DefaultView.ToTable(true, "RoomID", "RoomName");
                RptrRoomListingPackage2.DataSource = dt;
                RptrRoomListingPackage2.DataBind();
                RptrRoomListingPackage2.Visible = true;
                foreach (RepeaterItem item in RptrRoomListingPackage2.Items)
                {
                    HiddenField hdnRoomID = (HiddenField)item.FindControl("hdnRoomID");
                    Repeater RptrDeliciousFood = (Repeater)item.FindControl("RptrDeliciousFood");
                    Repeater RptrDeliciousFood1 = (Repeater)item.FindControl("RptrDeliciousFood1");

                    DataTable dt0 = new DataTable();
                    DataView dataView = new DataView(ds.Tables[0]);
                    dataView.RowFilter = "RoomID=" + hdnRoomID.Value + "";
                    dt0 = dataView.ToTable(true, "EntertainmentMealID", "MealTitle", "MealAlias", "MealDefaultImage", "MealTiming");
                    RptrDeliciousFood.DataSource = dt0;
                    RptrDeliciousFood.DataBind();
                    RptrDeliciousFood.Visible = true;

                    RptrDeliciousFood1.DataSource = dt0;
                    RptrDeliciousFood1.DataBind();
                    RptrDeliciousFood1.Visible = true;
                    foreach (RepeaterItem item1 in RptrDeliciousFood1.Items)
                    {
                        HiddenField hndEntertainmentMealID = (HiddenField)item1.FindControl("hndEntertainmentMealID");
                        Repeater RptrDeliciousFoodItems = (Repeater)item1.FindControl("RptrDeliciousFoodItems");
                        DataTable dt1 = new DataTable();
                        DataView dataView1 = new DataView(ds.Tables[0]);
                        dataView1.RowFilter = "RoomID=" + hdnRoomID.Value + " and EntertainmentMealID=" + hndEntertainmentMealID.Value + "";
                        dt1 = dataView1.ToTable(true, "EntertainmentMealID", "MealTitle", "MealAlias", "MealDefaultImage", "MealTiming", "MealItemTitle");
                        if (dt1.Rows.Count > 0)
                        {
                            RptrDeliciousFoodItems.DataSource = dt1;
                            RptrDeliciousFoodItems.DataBind();
                            RptrDeliciousFoodItems.Visible = true;
                        }
                        else
                            RptrDeliciousFoodItems.Visible = false;
                        dataView1.Dispose();
                        dt1.Dispose();
                        dt1.Clear();
                    }
                    dataView.Dispose();
                    dt0.Dispose();
                    dt0.Clear();
                }
                PnlPackageRoomDeliciousFood.Visible = true;
            }
            else
            {
                RptrRoomListingPackage2.Visible = false;
                PnlPackageRoomDeliciousFood.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjRoomEntertainmentData = null;
        }
        #endregion
        #endregion

        private void AddMetaTags()
        {
            Page.Title = "Packages - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Packages - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Packages - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Packages - AapnoGhar";
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