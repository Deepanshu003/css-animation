using Component;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Utility;

namespace AapnoGharWeb
{
    public partial class RoomBookingGuestDetail : System.Web.UI.Page
    {
        CustomerOrder ObjCustomerOrder = new CustomerOrder();
        CustomerOrderHistory ObjCustomerOrderHistory = new CustomerOrderHistory();
        RoomBookData ObjRoomBookData = new RoomBookData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["CustomerID"] != null) && (Session["dtCartRoom"] != null))
                {
                    BindAllActiveRoomsForBooking();
                    AddMetaTags();
                    txtBookingCustomerName.Text = Session["CustomerName"].ToString();                    
                    txtBookingCustomerMobileNo.Text = Session["CustomerMobileNo"].ToString();
                    txtBookingCustomerEmailID.Text = Session["CustomerEmailID"].ToString();
                    txtBookingCustomerCompanyName.Text = Session["CustomerCompanyName"].ToString();
                    txtBookingCustomerGSTNo.Text = Session["CustomerGSTNo"].ToString();
                    if (txtBookingCustomerName.Text != "" && txtBookingCustomerMobileNo.Text != "" && txtBookingCustomerEmailID.Text != "")
                        pnlGustInfo.Attributes.Add("style", "display: none;");

                    if (Session["FrontDeletrMSG"] != null)
                    {
                        ltrSucMsg.Text = "<p style='color: #00aeef;'>" + Session["FrontDeletrMSG"].ToString() + "</p>";
                        Session["FrontDeletrMSG"] = null;
                        Session.Remove("FrontDeletrMSG");
                    }
                }
                else
                    Response.Redirect("/");
            }
            btnBookingNow.Attributes.Add("OnClick", "return PageCheckRoomBookingNowMaster();");
            btnBookingNow1.Attributes.Add("OnClick", "return PageCheckRoomBookingNowMaster();");
        }

        #region Rooms Data
        private void BindAllActiveRoomsForBooking()
        {
            if (Session["dtCartRoom"] != null)
            {
                DataTable dt = new DataTable();
                dt = ((DataTable)Session["dtCartRoom"]);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataSet ds = new DataSet();
                        int TotalRoom = Convert.ToInt32(dt.Rows[i]["NoOfRooms"]);
                        int TotalRoomAvailable = 0;
                        int TotalRoomSelected = Convert.ToInt32(dt.Rows[i]["TotalRooms"]);
                        DateTime CheckInDate1 = DateTime.ParseExact(dt.Rows[i]["CheckInDate"].ToString().Replace("-", "/"), "MM/dd/yyyy", null);
                        DateTime CheckOutDate1 = DateTime.ParseExact(dt.Rows[i]["CheckOutDate"].ToString().Replace("-", "/"), "MM/dd/yyyy", null);
                        ObjRoomBookData.RoomID = Convert.ToInt32(dt.Rows[i]["RoomID"]);
                        ObjRoomBookData.BookingDate = CheckInDate1;
                        ObjRoomBookData.UpdatedOn = CheckOutDate1;
                        ds = ObjRoomBookData.SelectRoomBookForByRoomIDAndBookingDate();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TotalRoomAvailable = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalBookRooms"]);
                            if (TotalRoomAvailable == TotalRoom)
                            {
                                dt.Rows[i]["SoldOut"] = 1;
                                hdnTotalRooms.Value = "1";
                            }
                            else if (TotalRoomAvailable > 0 && TotalRoomAvailable < TotalRoom)
                            {
                                int LeftRoom = TotalRoom - TotalRoomAvailable;
                                if (TotalRoomSelected > LeftRoom)
                                {
                                    dt.Rows[i]["SoldOut"] = 1;
                                    hdnTotalRooms.Value = "1";
                                }
                                else if (TotalRoomSelected <= LeftRoom)
                                {
                                    dt.Rows[i]["SoldOut"] = 0;
                                    hdnTotalRooms.Value = "0";
                                }

                            }
                        }
                        ds.Dispose();
                        ds.Clear();
                    }
                    HttpContext.Current.Session["dtCartRoom"] = dt;
                }
                dt = ((DataTable)Session["dtCartRoom"]);
                if (dt.Rows.Count > 0)
                {
                    DataTable dt2 = dt.DefaultView.ToTable(true, "RoomID", "RoomName", "RoomImage", "RoomSmallDescription", "RoomType", "RoomPrice", "RoomKidsAge", "TotalRooms", "SoldOut");
                    RptrCartRoom.DataSource = dt2;
                    RptrCartRoom.DataBind();
                    RptrCartRoom.Visible = true;
                    foreach (RepeaterItem item in RptrCartRoom.Items)
                    {
                        HiddenField hdnRoomID = (HiddenField)item.FindControl("hdnRoomID");
                        Repeater RptrCartRooms = (Repeater)item.FindControl("RptrCartRooms");
                        DataTable dt3 = new DataTable();
                        DataView dataView3 = new DataView(dt);
                        dataView3.RowFilter = "RoomID=" + hdnRoomID.Value + "";
                        dt3 = dataView3.ToTable();
                        if (dt3.Rows.Count > 0)
                        {
                            RptrCartRooms.DataSource = dt3;
                            RptrCartRooms.DataBind();
                            RptrCartRooms.Visible = true;
                        }
                        else
                            RptrCartRooms.Visible = false;
                        dataView3.Dispose();
                        dt3.Dispose();
                        dt3.Clear();
                    }
                }
                else
                    Response.Redirect("/");
            }
            else
                Response.Redirect("/");
        }
        #endregion

        #region Show Cart Data For Booking
        [WebMethod]
        public static string ShowRoomBookingModule()
        {
            string FinalResult = "";
            if (HttpContext.Current.Session["dtCartRoom"] != null)
            {
                StringBuilder sb = new StringBuilder();
                DataTable dt = new DataTable();
                dt = ((DataTable)HttpContext.Current.Session["dtCartRoom"]);
                if (dt.Rows.Count > 0)
                {
                    DataTable dt0 = dt.DefaultView.ToTable(true, "RoomID", "RoomName", "RoomType", "CheckInDate", "CheckOutDate", "TotalNight", "SoldOut");
                    if (dt0.Rows.Count > 0)
                    {
                        sb.Append("<div class='list-container list-selectedRomm-js'>");
                        for (int i = 0; i < dt0.Rows.Count; i++)
                        {
                            int TotalNight = Convert.ToInt32(dt0.Rows[i]["TotalNight"].ToString());
                            sb.Append("<div class='checkinout'>");
                            sb.Append("<ul>");
                            sb.Append("<li>");
                            sb.Append("<div class='text'>");
                            sb.Append("<p><span>Check-in</span> <b>" + Convert.ToDateTime(dt0.Rows[i]["CheckInDate"].ToString()).ToString("ddd, dd MMM yyyy") + "</b><b>12:00 Noon</b></p>");
                            sb.Append("</div>");
                            sb.Append("</li>");
                            sb.Append("<li>");
                            sb.Append("<div class='text'>");
                            if (Convert.ToInt32(dt0.Rows[i]["TotalNight"].ToString()) > 1)
                                sb.Append("<p><span>Nights</span> <b>" + dt0.Rows[i]["TotalNight"].ToString() + "</b></p>");
                            else
                                sb.Append("<p><span>Nights</span> <b>" + dt0.Rows[i]["TotalNight"].ToString() + "</b></p>");
                            sb.Append("</div>");
                            sb.Append("</li>");
                            sb.Append("<li>");
                            sb.Append("<div class='text'>");
                            sb.Append("<p><span>Check-out</span> <b>" + Convert.ToDateTime(dt0.Rows[i]["CheckOutDate"].ToString()).ToString("ddd, dd MMM yyyy") + "</b><b>10:30 AM </b></p>");
                            sb.Append("</div>");
                            sb.Append("</li>");
                            sb.Append("</ul>");
                            sb.Append("</div>");
                            sb.Append("<div class='list' data-id='R" + dt0.Rows[i]["RoomID"].ToString() + "'>");
                            sb.Append("<div class='card'>");
                            #region Room data
                            sb.Append("<div class='card-header'>");
                            sb.Append("<div class='romname jsrommname'>" + dt0.Rows[i]["RoomName"].ToString() + "</div>");
                            sb.Append("<div class='altr jsaltr'>" + dt0.Rows[i]["RoomType"].ToString() + "</div>");
                            if (Convert.ToInt32(dt0.Rows[i]["TotalNight"].ToString()) > 1)
                                sb.Append("<div class='forday jsforday'>" + Convert.ToDateTime(dt0.Rows[i]["CheckInDate"].ToString()).ToString("ddd, dd MMM yyyy") + ", " + Convert.ToDateTime(dt0.Rows[i]["CheckOutDate"].ToString()).ToString("ddd, dd MMM yyyy") + " | " + dt0.Rows[i]["TotalNight"].ToString() + " Nights</div>");
                            else
                                sb.Append("<div class='forday jsforday'>" + Convert.ToDateTime(dt0.Rows[i]["CheckInDate"].ToString()).ToString("ddd, dd MMM yyyy") + ", " + Convert.ToDateTime(dt0.Rows[i]["CheckOutDate"].ToString()).ToString("ddd, dd MMM yyyy") + " | " + dt0.Rows[i]["TotalNight"].ToString() + " Night</div>");
                            sb.Append("<div class='cartAvtion'>");
                            sb.Append("<ul>");
                            if (Convert.ToInt32(dt0.Rows[i]["SoldOut"].ToString()) == 1)
                            {
                                sb.Append("<li>");
                                sb.Append("<button class='btn' type='button'><span style='color:red;'>Sold Out</span></button>");
                                sb.Append("</li>");
                            }
                            sb.Append("<li>");
                            sb.Append("<button class='btn delete_room' data-delete='delete_" + dt0.Rows[i]["RoomID"].ToString() + "' type='button'><img src='/assets/icons/delete.png' alt='nearby amusement park' /><span>Delete</span></button>");
                            sb.Append("</li>");
                            sb.Append("</ul>");
                            sb.Append("</div>");
                            sb.Append("</div>");
                            #endregion

                            #region Total Rooms
                            sb.Append("<div class='card-body'>");
                            DataTable dt1 = new DataTable();
                            DataView dataView1 = new DataView(dt);
                            dataView1.RowFilter = "RoomID=" + Convert.ToInt32(dt0.Rows[i]["RoomID"].ToString()) + "";
                            dt1 = dataView1.ToTable();
                            if (dt1.Rows.Count > 1)
                            {
                                string TotalRoomAppend = "";
                                int TotalRoomNo = 0;
                                int TotalAdults = 0;
                                int TotalKids = 0;
                                int TotalKidRoomPrice = 0;
                                int TotalRoomPrice = 0;
                                int TotalRoomPriceTax = 0;
                                int TotalExRoomPrice = 0;
                                int TotalExRoomPriceTax = 0;
                                for (int j = 0; j < dt1.Rows.Count; j++)
                                {
                                    int KidsPrice = 0;
                                    TotalRoomNo = TotalRoomNo + 1;
                                    TotalAdults = TotalAdults + Convert.ToInt32(dt1.Rows[j]["TotalAdults"].ToString());
                                    TotalKids = TotalKids + Convert.ToInt32(dt1.Rows[j]["TotalKids"].ToString());
                                    TotalKidRoomPrice = TotalKidRoomPrice + Convert.ToInt32(dt1.Rows[j]["TotalKidsPrice"].ToString());
                                    TotalRoomPrice = TotalRoomPrice + Convert.ToInt32(dt1.Rows[j]["RoomPrice"].ToString());
                                    TotalRoomPriceTax = TotalRoomPriceTax + Convert.ToInt32(dt1.Rows[j]["RoomPriceTax"].ToString());
                                    TotalExRoomPrice = TotalExRoomPrice + Convert.ToInt32(dt1.Rows[j]["RoomExPrice"].ToString());
                                    TotalExRoomPriceTax = TotalExRoomPriceTax + Convert.ToInt32(dt1.Rows[j]["RoomExPriceTax"].ToString());
                                    KidsPrice = (Convert.ToInt32(dt1.Rows[j]["TotalKidsPrice"].ToString()) + (Convert.ToInt32(dt1.Rows[j]["RoomExPrice"].ToString())));
                                    if (KidsPrice > 0 && Convert.ToInt32(dt1.Rows[j]["TotalKids"].ToString()) > 0)
                                        TotalRoomAppend = TotalRoomAppend + "<div class='li'> <p>Room " + (j + 1) + "</p> <span>" + dt1.Rows[j]["TotalAdults"].ToString() + " Adult(s), " + dt1.Rows[j]["TotalKids"].ToString() + " Kid(s)</span> <div class='price'><span>Rs. " + dt1.Rows[j]["RoomPrice"].ToString() + ".00</span><span>Ex. Charges. " + KidsPrice.ToString() + ".00</span></div> </div>";
                                    else if (KidsPrice > 0 && Convert.ToInt32(dt1.Rows[j]["TotalKids"].ToString()) <= 0)
                                        TotalRoomAppend = TotalRoomAppend + "<div class='li'> <p>Room " + (j + 1) + "</p> <span>" + dt1.Rows[j]["TotalAdults"].ToString() + " Adult(s)</span> <div class='price'><span>Rs. " + dt1.Rows[j]["RoomPrice"].ToString() + ".00</span><span>Ex. Charges. " + KidsPrice.ToString() + ".00</span></div> </div>";
                                    else
                                        TotalRoomAppend = TotalRoomAppend + "<div class='li'> <p>Room " + (j + 1) + "</p> <span>" + dt1.Rows[j]["TotalAdults"].ToString() + " Adult(s)</span> <div class='price'><span>Rs. " + dt1.Rows[j]["RoomPrice"].ToString() + ".00</span></div>  </div>";
                                }
                                sb.Append("<div class='totrooms_' onclick='toggleDetails($(this))'>");
                                sb.Append("<div class='rooms jstotlaRoomselected' data-totalRooms='" + TotalRoomNo + "' data-totalprice='" + (TotalNight * TotalRoomPrice) + "' data-totalpriceTax='" + (TotalNight * TotalRoomPriceTax) + "'data-totalExprice='" + (TotalNight * TotalExRoomPrice) + "' data-totalExpriceTax='" + (TotalNight * TotalExRoomPriceTax) + "' data-totalKidsprice='" + (TotalNight * TotalKidRoomPrice) + "'>" + TotalRoomNo + " Rooms</div>");
                                if (TotalKids > 0)
                                    sb.Append("<div class='totpersi jsTotalPersion'>" + TotalAdults + " Adult(s), " + TotalKids + " Children</div>");
                                else
                                    sb.Append("<div class='totpersi jsTotalPersion'>" + TotalAdults + " Adult(s)</div>");
                                sb.Append("</div>");
                                sb.Append("<div class='price jstotlaPris'>Rs. " + TotalRoomPrice + ".00</div>");
                                sb.Append("<div class='rombokde jsrombokdetail' style='display: none;'>" + TotalRoomAppend + "</div>");
                                sb.Append("</div>");
                            }
                            else
                            {
                                int KidsPrice = 0;
                                KidsPrice = (Convert.ToInt32(dt1.Rows[0]["TotalKidsPrice"].ToString()) + (Convert.ToInt32(dt1.Rows[0]["RoomExPrice"].ToString())));
                                sb.Append("<div>");
                                sb.Append("<div class='rooms jstotlaRoomselected' data-totalRooms='1' data-totalprice='" + (TotalNight * Convert.ToInt32(dt1.Rows[0]["RoomPrice"].ToString())) + "' data-totalpriceTax='" + (TotalNight * Convert.ToInt32(dt1.Rows[0]["RoomPriceTax"].ToString())) + "'data-totalExprice='" + (TotalNight * Convert.ToInt32(dt1.Rows[0]["RoomExPrice"].ToString())) + "' data-totalExpriceTax='" + (TotalNight * Convert.ToInt32(dt1.Rows[0]["RoomExPriceTax"].ToString())) + "' data-totalKidsprice='" + (TotalNight * Convert.ToInt32(dt1.Rows[0]["TotalKidsPrice"].ToString())) + "'>1 Room</div>");
                                if (Convert.ToInt32(dt1.Rows[0]["TotalKids"].ToString()) > 0)
                                    sb.Append("<div class='totpersi jsTotalPersion'>" + dt1.Rows[0]["TotalAdults"].ToString() + " Adult(s), " + dt1.Rows[0]["TotalKids"].ToString() + " Kids(s)</div>");
                                else
                                    sb.Append("<div class='totpersi jsTotalPersion'>" + dt1.Rows[0]["TotalAdults"].ToString() + " Adult(s)</div>");
                                sb.Append("</div>");
                                if (KidsPrice > 0)
                                    sb.Append("<div class='price jstotlaPris'><span>Rs. " + dt1.Rows[0]["RoomPrice"].ToString() + ".00</span><span>Ex. Charges. " + KidsPrice.ToString() + ".00</span></div>");
                                else
                                    sb.Append("<div class='price jstotlaPris'>Rs. " + dt1.Rows[0]["RoomPrice"].ToString() + ".00</div>");
                            }
                            sb.Append("</div>");
                            #endregion

                            sb.Append("</div>");
                            sb.Append("</div>");
                        }
                        sb.Append("</div>");
                    }
                    else
                        FinalResult = "0";
                    FinalResult = sb.ToString();
                    sb.Clear();
                }
                else
                    FinalResult = "0";
            }
            else
                FinalResult = "0";

            return FinalResult.ToString();
        }
        #endregion

        #region Delete From To Cart
        [WebMethod]
        public static string DeleteRoomBookingModuleByListID(string RoomListID)
        {
            string FinalResult = "";
            if (HttpContext.Current.Session["dtCartRoom"] != null)
            {
                string RoomName = "";
                int ret = 0;
                StringBuilder sb = new StringBuilder();
                DataTable dt = new DataTable();
                dt = ((DataTable)HttpContext.Current.Session["dtCartRoom"]);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt64(dt.Rows[i]["RoomID"]) == Convert.ToInt32(RoomListID.Replace("delete_", "")))
                        {
                            RoomName = dt.Rows[i]["RoomName"].ToString();
                            dt.Rows[i].Delete();
                            ret = 1;
                        }
                    }
                }
                if (ret > 0)
                {
                    HttpContext.Current.Session["dtCartRoom"] = dt;
                    HttpContext.Current.Session["FrontDeletrMSG"] = "" + RoomName + " successfully removed from your cart.";
                    FinalResult = "" + RoomName + " successfully removed from your cart.";
                }
                else
                    FinalResult = "";
            }
            else
                FinalResult = "0";
            return FinalResult;
        }
        #endregion Add To Cart

        #region Booking Now
        protected void btnBookingNow_Click(object sender, EventArgs e)
        {
            int ret = 0;
            if (Session["CustomerID"] != null && Session["dtCartRoom"] != null)
            {
                DataTable dt = new DataTable();
                dt = ((DataTable)HttpContext.Current.Session["dtCartRoom"]);
                if (dt.Rows.Count > 0)
                {
                    int retData = 1;
                    if ((HttpContext.Current.Session["CustomerName"].ToString() != txtBookingCustomerName.Text) || (HttpContext.Current.Session["CustomerMobileNo"].ToString() != txtBookingCustomerMobileNo.Text) || (HttpContext.Current.Session["CustomerEmailID"].ToString() != txtBookingCustomerEmailID.Text) || (HttpContext.Current.Session["CustomerCompanyName"].ToString() != txtBookingCustomerCompanyName.Text) || (HttpContext.Current.Session["CustomerGSTNo"].ToString() != txtBookingCustomerGSTNo.Text))
                    {
                        CustomerData ObjCustomerData = new CustomerData();
                        ObjCustomerData.CustomerID = Convert.ToInt32(HttpContext.Current.Session["CustomerID"]);
                        ObjCustomerData.CustomerName = txtBookingCustomerName.Text;
                        ObjCustomerData.CustomerEmailID = txtBookingCustomerEmailID.Text;
                        ObjCustomerData.CustomerMobileNo = txtBookingCustomerMobileNo.Text;
                        ObjCustomerData.CustomerCompanyName = txtBookingCustomerCompanyName.Text;
                        ObjCustomerData.CustomerGSTNo = txtBookingCustomerGSTNo.Text;
                        retData = ObjCustomerData.UpdateCustomerPersonalinformationByCustomerIDFromOrder();
                        if (retData == 1)
                        {
                            HttpContext.Current.Session["CustomerName"] = txtBookingCustomerName.Text.ToString();
                            HttpContext.Current.Session["CustomerEmailID"] = txtBookingCustomerEmailID.Text.ToString();
                            HttpContext.Current.Session["CustomerMobileNo"] = txtBookingCustomerMobileNo.Text.ToString();
                            HttpContext.Current.Session["CustomerCompanyName"] = txtBookingCustomerCompanyName.Text.ToString();
                            HttpContext.Current.Session["CustomerGSTNo"] = txtBookingCustomerGSTNo.Text.ToString();
                        }
                    }
                    if (retData == -1)
                    {
                        ltrErrorMsg.Text = "<div class='otp_msg'><p style='color: red;'>Email ID already exists!!</span></p></div>";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.booknow_model'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", true);
                    }
                    else if (retData == -2)
                    {
                        ltrErrorMsg.Text = "<div class='otp_msg'><p style='color: red;'>GST No. already exists!!</span></p></div>";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.booknow_model'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", true);
                    }
                    else if (retData == -3)
                    {
                        ltrErrorMsg.Text = "<div class='otp_msg'><p style='color: red;'>GST No. already exists!!</span></p></div>";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "$('.login_model').removeClass('is-open'); $('.overlay').removeClass('overlay_active');var model = '.booknow_model'; $('.overlay').addClass('overlay_active'); $(model).addClass('is-open');", true);
                    }
                    else if (retData == 1)
                    {
                        int OrderNo = Convert.ToInt32(ObjCustomerOrder.SelectMaxOrderNo());
                        ObjCustomerOrder.OrderNo = OrderNo;
                        ObjCustomerOrder.OrderDate = DateTime.UtcNow;
                        ObjCustomerOrder.CustomerID = Convert.ToInt32(Session["CustomerID"]);
                        ObjCustomerOrder.CouponCode = hdnCouponCode.Value;
                        ObjCustomerOrder.CouponValue = Convert.ToInt32(hdnTotalCoupon.Value);
                        ObjCustomerOrder.OrderTotalAmount = (Convert.ToInt32(hdnPayableAmount.Value));
                        ret = ObjCustomerOrder.SaveNewRoomBookingByCustomerData();
                        if (ret > 0)
                        {
                            int TotalRooms = 0;
                            int TotalGuset = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                TotalRooms = TotalRooms + 1;
                                TotalGuset = TotalGuset + ((Convert.ToInt32(dt.Rows[i]["TotalAdults"].ToString())) + (Convert.ToInt32(dt.Rows[i]["TotalKids"].ToString())));
                                CultureInfo MyCultureInfo = new CultureInfo("en-US");
                                DateTime CheckInDate = DateTime.Parse(dt.Rows[i]["CheckInDate"].ToString(), MyCultureInfo, DateTimeStyles.NoCurrentDateDefault);
                                DateTime CheckOutDate = DateTime.Parse(dt.Rows[i]["CheckOutDate"].ToString(), MyCultureInfo, DateTimeStyles.NoCurrentDateDefault);                                
                                ObjCustomerOrderHistory.CustomerOrderListID = ret;
                                ObjCustomerOrderHistory.OrderNo = Convert.ToInt32(OrderNo);
                                ObjCustomerOrderHistory.RoomID = Convert.ToInt32(dt.Rows[i]["RoomID"]);
                                ObjCustomerOrderHistory.RoomName = dt.Rows[i]["RoomName"].ToString();
                                ObjCustomerOrderHistory.RoomImage = dt.Rows[i]["RoomImage"].ToString();
                                ObjCustomerOrderHistory.RoomType = dt.Rows[i]["RoomType"].ToString();
                                ObjCustomerOrderHistory.CheckInDate = CheckInDate;
                                ObjCustomerOrderHistory.CheckOutDate = CheckOutDate;
                                ObjCustomerOrderHistory.TotalNight = Convert.ToInt32(dt.Rows[i]["TotalNight"].ToString());
                                ObjCustomerOrderHistory.RoomNo = "Room " + (i + 1).ToString();
                                ObjCustomerOrderHistory.TotalAdults = Convert.ToInt32(dt.Rows[i]["TotalAdults"].ToString());
                                ObjCustomerOrderHistory.Totalkids = Convert.ToInt32(dt.Rows[i]["TotalKids"].ToString());
                                ObjCustomerOrderHistory.KidsOneAge = Convert.ToInt32(dt.Rows[i]["TotalKidsAge1"].ToString());
                                ObjCustomerOrderHistory.KidsTwoAge = Convert.ToInt32(dt.Rows[i]["TotalKidsAge2"].ToString());
                                ObjCustomerOrderHistory.RoomPrice = Convert.ToInt32(dt.Rows[i]["RoomPrice"].ToString());
                                ObjCustomerOrderHistory.RoomTaxes = Convert.ToInt32(dt.Rows[i]["RoomPriceTax"].ToString());
                                ObjCustomerOrderHistory.ExtraCharges = (Convert.ToInt32(dt.Rows[i]["RoomExPrice"].ToString()) + Convert.ToInt32(dt.Rows[i]["TotalKidsPrice"].ToString()));
                                ObjCustomerOrderHistory.ExtraChargesTax = Convert.ToInt32(dt.Rows[i]["RoomExPriceTax"].ToString());
                                ObjCustomerOrderHistory.TotalPrice = (Convert.ToInt32(dt.Rows[i]["RoomPrice"].ToString()) + Convert.ToInt32(dt.Rows[i]["RoomPriceTax"].ToString()) + Convert.ToInt32(dt.Rows[i]["RoomExPrice"].ToString()) + Convert.ToInt32(dt.Rows[i]["RoomExPriceTax"].ToString()) + Convert.ToInt32(dt.Rows[i]["TotalKidsPrice"].ToString()));
                                ObjCustomerOrderHistory.PostedDate = DateTime.UtcNow;
                                ObjCustomerOrderHistory.SaveNewRoomOrderHistoryRoomWise();
                            }
                            if (ret > 0)
                            {
                                DataTable dt0 = dt.DefaultView.ToTable(true, "RoomID", "RoomName", "RoomType", "CheckInDate", "CheckOutDate", "TotalNight", "TotalRooms");
                                if (dt0.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {

                                        DateTime CheckInDate1 = DateTime.ParseExact(dt.Rows[i]["CheckInDate"].ToString().Replace("-", "/").Replace("-", "/"), "MM/dd/yyyy", null);
                                        DateTime CheckOutDate1 = DateTime.ParseExact(dt.Rows[i]["CheckOutDate"].ToString().Replace("-", "/").Replace("-", "/"), "MM/dd/yyyy", null);
                                        TimeSpan objTimeSpan = CheckOutDate1 - CheckInDate1;
                                        //TotalDays  
                                        double Days = Convert.ToDouble(objTimeSpan.TotalDays);

                                        int TotalNoOfDays = Convert.ToInt32(Days);
                                        if (TotalNoOfDays < 0)
                                            TotalNoOfDays = 1;
                                        if (TotalNoOfDays > 0)
                                        {
                                            for (int j = 0; j < TotalNoOfDays; j++)
                                            {
                                                ObjRoomBookData.RoomID = Convert.ToInt32(dt.Rows[i]["RoomID"]);
                                                ObjRoomBookData.BookingDate = Convert.ToDateTime(dt.Rows[i]["CheckInDate"]).AddDays(j);
                                                ObjRoomBookData.TotalBookRooms = Convert.ToInt32(dt.Rows[i]["TotalRooms"]);
                                                ObjRoomBookData.UpdatedBy = "Update By Online Booking";
                                                ret = ObjRoomBookData.SaveAndUpdateRoomBookingForDateFromFrontEnd();
                                            }
                                        }
                                    }
                                }


                                //int ret1 = 0;
                                //string txnidtxnid = string.Empty;
                                //if (Convert.ToInt32(OrderNo) < 10)
                                //    txnidtxnid = "APG00000R" + OrderNo.ToString();
                                //else if (Convert.ToInt32(OrderNo) < 100 && Convert.ToInt32(OrderNo) > 10)
                                //    txnidtxnid = "APG0000R" + OrderNo.ToString();
                                //else if (Convert.ToInt32(OrderNo) < 1000 && Convert.ToInt32(OrderNo) > 100)
                                //    txnidtxnid = "APG000R" + OrderNo.ToString();
                                //else if (Convert.ToInt32(OrderNo) < 10000 && Convert.ToInt32(OrderNo) > 1000)
                                //    txnidtxnid = "APG00R" + OrderNo.ToString();
                                //else if (Convert.ToInt32(OrderNo) < 100000 && Convert.ToInt32(OrderNo) > 10000)
                                //    txnidtxnid = "APG0R" + OrderNo.ToString();
                                //else if (Convert.ToInt32(OrderNo) < 1000000)
                                //    txnidtxnid = "APGR" + OrderNo.ToString();
                                //ObjCustomerOrder.OrderNo = OrderNo;
                                //ObjCustomerOrder.PaymentID = txnidtxnid;
                                //ObjCustomerOrder.TransactionID = txnidtxnid;
                                //ObjCustomerOrder.TransactionStatus = "Success";
                                //ObjCustomerOrder.UpdatedBy = "Online Payments";
                                //ret1 = ObjCustomerOrder.UpdateRoomBookingOnlinePaymentStatus();
                                //if (ret1 > 0)
                                //{

                                //}

                                //if (Session["CustomerEmailID"] != null && Session["CustomerEmailID"].ToString() != "")
                                //    SendMailToCustomerToConfirmPayment(OrderNo, TotalRooms, TotalGuset, Convert.ToInt32(hdnPayableAmount.Value));
                                //if (Session["CustomerMobileNo"] != null && Session["CustomerMobileNo"].ToString() != "")
                                //{
                                //    ManageException ObjEx = new ManageException();
                                //    try
                                //    {
                                //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                                //        WebClient client = new WebClient();
                                //        string baseurl = "http://125.16.147.178/VoicenSMS/webresources/CreateSMSCampaignGet?ukey=I1aBFeA7tKwwAfw2DJ3rQHFAH&msisdn=" + Session["CustomerMobileNo"].ToString() + "&language=0&credittype=7&senderid=APOGHR&templateid=0&message=Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuset + " guests for " + TotalRooms + " rooms on our AapnoGhar against the booking number " + OrderNo + ". If you have any questions, please let us know, We’ll be happy to help!&filetype=2";
                                //        Stream data = client.OpenRead(baseurl);
                                //        StreamReader reader = new StreamReader(data);
                                //        string ResponseID = reader.ReadToEnd();
                                //        data.Close();
                                //        reader.Close();
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        ObjEx.PublishError("Error in procedure SaveNewCustomerData()", ex);
                                //    }
                                //}
                                //if (TotalRooms > 1)
                                //    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuset + " guests for " + TotalRooms + " rooms worth of ₹ " + hdnPayableAmount.Value + " on our AapnoGhar against the booking number " + OrderNo.ToString() + ".<br><br><br> If you have any questions, please let us know, We’ll be happy to help!";
                                //else
                                //    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuset + " guests for " + TotalRooms + " rooms worth of ₹ " + hdnPayableAmount.Value + " on our AapnoGhar against the booking number " + OrderNo.ToString() + ".<br><br> If you have any questions, please let us know, We’ll be happy to help!";

                                //HttpContext.Current.Session["dtCartRoom"] = null;
                                //HttpContext.Current.Session.Remove("dtCartRoom");
                                //Response.Redirect("/thank-you", true);


                                Recordholder(OrderNo.ToString(), Convert.ToInt32(hdnPayableAmount.Value));
                                Response.Redirect("/pay-now", false);
                            }
                        }
                        else if (ret == -1)
                            ltrErrorMsg.Text = "An error occured, Please try after sometime";
                        else if (ret == -2)
                            ltrErrorMsg.Text = "Phone no is not in correct format";
                        else if (ret == -3)
                            ltrErrorMsg.Text = "Please fill all the details properly";
                    }
                }
                else
                    Response.Redirect("/room-booking-cart");
            }
            else
                Response.Redirect("/");

        }

        public static void Recordholder(string OrderNo, int Subtotal)
        {
            string Name = "";
            string Email = "";
            string Phone = "";
            string BillingAddress = "";
            string StateName = "";
            string LocationName = "";
            string CityName = "";
            if (HttpContext.Current.Session["CustomerName"] != null && HttpContext.Current.Session["CustomerName"].ToString() != "")
                Name = HttpContext.Current.Session["CustomerName"].ToString();
            else
                Name = "AapnoGhart";
            if (HttpContext.Current.Session["CustomerEmailID"] != null && HttpContext.Current.Session["CustomerEmailID"].ToString() != "")
                Email = HttpContext.Current.Session["CustomerEmailID"].ToString();
            else
                Email = "info@aapnoghar.com";
            if (HttpContext.Current.Session["CustomerMobileNo"] != null && HttpContext.Current.Session["CustomerMobileNo"].ToString() != "")
                Phone = HttpContext.Current.Session["CustomerMobileNo"].ToString();
            else
                Phone = "7666779997";

            if (HttpContext.Current.Session["BillingAddress"] != null && HttpContext.Current.Session["BillingAddress"].ToString() != "")
                BillingAddress = HttpContext.Current.Session["BillingAddress"].ToString();
            else
                BillingAddress = "Aapno Ghar / Airport Motel Amusement & Water Park, 43rd Mile Stone , NH-8 Delhi – Jaipur Expressway, Sec-77";

            if (HttpContext.Current.Session["StateName"] != null && HttpContext.Current.Session["StateName"].ToString() != "")
                StateName = HttpContext.Current.Session["StateName"].ToString();
            else
                StateName = "Haryana";

            if (HttpContext.Current.Session["LocationName"] != null && HttpContext.Current.Session["LocationName"].ToString() != "")
                LocationName = HttpContext.Current.Session["LocationName"].ToString();
            else
                LocationName = "122001";

            if (HttpContext.Current.Session["CityName"] != null && HttpContext.Current.Session["CityName"].ToString() != "")
                CityName = HttpContext.Current.Session["CityName"].ToString();
            else
                CityName = "Gurugram";

            string txnidtxnid = string.Empty;
            if (Convert.ToInt32(OrderNo) < 10)
                txnidtxnid = "APG00000R" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 100 && Convert.ToInt32(OrderNo) > 10)
                txnidtxnid = "APG0000R" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 1000 && Convert.ToInt32(OrderNo) > 100)
                txnidtxnid = "APG000R" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 10000 && Convert.ToInt32(OrderNo) > 1000)
                txnidtxnid = "APG00R" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 100000 && Convert.ToInt32(OrderNo) > 10000)
                txnidtxnid = "APG0R" + OrderNo.ToString();
            else if (Convert.ToInt32(OrderNo) < 1000000)
                txnidtxnid = "APGR" + OrderNo.ToString();

            Hashtable ObjHashRecord = new Hashtable();
            ObjHashRecord.Add("merchant_id", "2415379");
            ObjHashRecord.Add("paymentid", txnidtxnid);
            ObjHashRecord.Add("order_id", OrderNo);
            ObjHashRecord.Add("amount", Subtotal);
            //ObjHashRecord.Add("amount", 1);
            ObjHashRecord.Add("currency", "INR");
            ObjHashRecord.Add("redirect_url", "https://www.aapnoghar.com/transaction-succesfull?Type=Rooms&AapnoGhar=" + HttpContext.Current.Session["CustomerID"]);
            ObjHashRecord.Add("cancel_url", "https://www.aapnoghar.com/transaction-failed?AapnoGhar=" + HttpContext.Current.Session["CustomerID"]);
            ObjHashRecord.Add("firstname", Name);
            ObjHashRecord.Add("lastname", Name);
            ObjHashRecord.Add("emailid", Email);
            ObjHashRecord.Add("phone", Phone);
            ObjHashRecord.Add("amountdate", DateTime.Now.ToString());
            ObjHashRecord.Add("billing_name", Name);
            ObjHashRecord.Add("billing_address", BillingAddress);
            ObjHashRecord.Add("billing_city", CityName);
            ObjHashRecord.Add("billing_state", StateName);
            ObjHashRecord.Add("billing_zip", LocationName);
            ObjHashRecord.Add("billing_country", "India");
            ObjHashRecord.Add("billing_tel", Phone);
            ObjHashRecord.Add("billing_email", Email);
            ObjHashRecord.Add("delivery_name", Name);
            ObjHashRecord.Add("delivery_address", BillingAddress);
            ObjHashRecord.Add("delivery_city", CityName);
            ObjHashRecord.Add("delivery_state", StateName);
            ObjHashRecord.Add("delivery_zip", LocationName);
            ObjHashRecord.Add("delivery_country", "India");
            ObjHashRecord.Add("delivery_tel", Phone);
            ObjHashRecord.Add("delivery_email", Email);
            HttpContext.Current.Session["rechold"] = ObjHashRecord;
        }

        #region Room Mail
        private void SendMailToCustomerToConfirmPayment(int OrderNo, int TotalRooms, int TotalGuset, int OrderTotalAmount)
        {
            #region Customer Mail Body
            StringBuilder str = new StringBuilder();
            str.Append("<!DOCTYPE html>");
            str.Append("<html>");
            str.Append("<head>");
            str.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>");
            str.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
            str.Append("<title>Thank you mail</title>");
            str.Append("</head>");
            str.Append("<body style='background: #fff;;'>");
            str.Append("<div style='border:1px solid #04775c;width:700px;'>");
            str.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%' style='padding:10px 20px;'>");

            str.Append("<tr>");
            str.Append("<td style='float:left;text-align:left;'><a href='https://www.aapnoghar.com/' title='logo'><img class='logo' src='https://www.aapnoghar.com/assets/icons/email-logo.png' width='81' alt='logo' /></a></td>");
            str.Append("<td style='float:right;text-align:right;color:#000;padding:15px 5px;'> <a href='mailto:info@aapnoghar.com' style='color:#000;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Email ID : info@aapnoghar.com</a> <br /> <a href='tel:+917666779997' style='color:#000;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Phone : +91 7666 779 997</a></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan='2' style='color:#000;padding:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>");
            str.Append("<table border='0' cellspacing='0' cellspacing='2' width='100%'>");
            str.Append("<tr>");
            str.Append("<td valign='top' align='left'>");
            str.Append("<p style='color:#000; padding-botton:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Hi " + Session["CustomerName"].ToString() + ",<br /><br /></p>");
            if (TotalGuset == 1)
            {
                str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuset + " guest for " + TotalRooms + " rooms worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + OrderNo.ToString() + ".</p>");
                //str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
                str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>If you have any questions, just reply to this email. We’ll be happy to help!</p>");

            }
            else
            {
                str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuset + " guest for " + TotalRooms + " rooms worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + OrderNo.ToString() + ".</p>");
                //str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
                str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>If you have any questions, just reply to this email. We’ll be happy to help!</p>");
            }
            str.Append("<p style='color:#363636;padding-top:20px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><b>Warm Regards</b>,<br><b>AapnoGhar</b></p>");
            str.Append("</td>");
            str.Append("</tr>");
            str.Append("</table>");

            str.Append("</td>");
            str.Append("</tr>");

            str.Append("</table>");

            str.Append("<div style='background:#172061;border-left:solid #666 5px;border-right:solid #666 5px;color:#fff;text-align:center;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'><h2 style='color:#fff;letter-spacing:4px;font:normal 22px/1 Verdana, Helvetica;padding:8px 0px;text-align:center;'><a href='https://www.aapnoghar.com' style='color:#fff;text-decoration:none;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>www.aapnoghar.com</a></h2></div>");
            str.Append("</div>");
            str.Append("</body>");
            str.Append("</html>");
            #endregion

            #region Send Email to customer
            try
            {
                Mail ObjMail = new Mail();
                ObjMail.Subject = "Thankyou for your room Booking at AapnoGhar";
                ObjMail.MailTo = Session["CustomerEmailID"].ToString();
                ObjMail.MailCc = "info@aapnoghar.com";
                ObjMail.Body = str.ToString().Replace(", , ", " ");
                ObjMail.Title = "AapnoGhar";
                ObjMail.SendMail();
            }
            catch (Exception ex)
            {
                Response.Redirect("/something-went-wrong?error=while sending email", false);
            }
            #endregion
        }

        public string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    //if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }
        #endregion

        #endregion

        private void AddMetaTags()
        {
            Page.Title = "Guest Detail - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Guest Detail - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Guest Detail - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Guest Detail - AapnoGhar";
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