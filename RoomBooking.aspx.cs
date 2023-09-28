using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Utility;

namespace AapnoGharWeb
{
    public partial class RoomBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllActiveRoomsForBooking();
                if (Session["FrontDeletrMSG"] != null)
                {
                    ltrSucMsg.Text = "<p style='color: #00aeef;'>"+Session["FrontDeletrMSG"].ToString()+"</p>";
                    Session["FrontDeletrMSG"] = null;
                    Session.Remove("FrontDeletrMSG");
                }
            }
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
                    DataTable dt0 = dt.DefaultView.ToTable(true, "RoomID", "RoomName", "RoomImage", "RoomSmallDescription", "RoomType", "RoomPrice", "RoomKidsAge", "TotalRooms");
                    RptrCartRoom.DataSource = dt0;
                    RptrCartRoom.DataBind();
                    RptrCartRoom.Visible = true;
                    hdnCartOpen.Value = "1";
                    foreach (RepeaterItem item in RptrCartRoom.Items)
                    {
                        HiddenField hdnRoomID = (HiddenField)item.FindControl("hdnRoomID");
                        Repeater RptrCartRooms = (Repeater)item.FindControl("RptrCartRooms");
                        DataTable dt1 = new DataTable();
                        DataView dataView1 = new DataView(dt);
                        dataView1.RowFilter = "RoomID=" + hdnRoomID.Value + "";
                        dt1 = dataView1.ToTable();
                        if (dt1.Rows.Count > 0)
                        {
                            RptrCartRooms.DataSource = dt1;
                            RptrCartRooms.DataBind();
                            RptrCartRooms.Visible = true;
                        }
                        else
                            RptrCartRooms.Visible = false;
                        dataView1.Dispose();
                        dt1.Dispose();
                        dt1.Clear();
                    }
                    ltrNoRoom.Text = "";
                }
                else
                {
                    hdnCartOpen.Value = "0";
                    RptrCartRoom.Visible = false;
                    //ltrNoRoom.Text = "<div class='wdth-pc'><div class='err_div'><div class='img_er'><img src='/assets/images/Not-found.gif' alt='water park ticket'/></div><div class='msg_fst'><p class='hJKWmk'><b>No Availability</b><br/>We were unable find a room(s) to match your search criteria. Please change your search,or call us for assistance or, if your dates are flexible, try the Room Availability Calendar. Please email us at <a href='mailto:info@aapnoghar.com'>info@aapnoghar.com</a> incase of non-availability of rooms. Call us at <a href='tel:+917666779997'>+91 7666779997</a>.</p><span class='ShopNow'></span></div></div></div>";
                    ltrNoRoom.Text = "<div class='wdth-pc'><div class='err_div'><div class='img_er'><img src='/assets/images/Not-found.gif' alt='water park ticket'/></div><div class='msg_fst'><p class='hJKWmk'><b>Your booking cart is empty!</b><br/>Add items to it now.</p><span class='ShopNow'><a href='/stay'>Book Now</a></span></div></div></div>";
                }
            }
            else
            {
                hdnCartOpen.Value = "0";
                RptrCartRoom.Visible = false;
                ltrNoRoom.Text = "<div class='wdth-pc'><div class='err_div'><div class='img_er'><img src='/assets/images/Not-found.gif' alt='water park ticket'/></div><div class='msg_fst'><p class='hJKWmk'><b>Your booking cart is empty!</b><br/>Add items to it now.</p><span class='ShopNow'><a href='/stay'>Book Now</a></span></div></div></div>";
            }
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
                    DataTable dt0 = dt.DefaultView.ToTable(true, "RoomID", "RoomName", "RoomURL", "RoomType", "CheckInDate", "CheckOutDate", "TotalNight");
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
                            sb.Append("<li>");
                            sb.Append("<a href='/" + dt0.Rows[i]["RoomURL"].ToString() + "' class='btn'><img src='/assets/icons/pen.png' alt='water park ticket' /><span>Edit</span></a>");
                            sb.Append("</li>");
                            sb.Append("<li>");
                            sb.Append("<button  class='btn delete_room' data-delete='delete_" + dt0.Rows[i]["RoomID"].ToString() + "' type='button'><img src='/assets/icons/delete.png' alt='water park ticket' /><span>Delete</span></button>");
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

        #region Proceed To Delivery Address
        protected void lnkProceedNow_Click(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null)
                Response.Redirect("/room-booking-guest");
            else
                MsgJavascript();
        }

        private void MsgJavascript()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("$('.overlay').addClass('overlay_active'); $('.login_model').addClass('is-open');");
            sb.Append("</script>");
            Literal Literal1 = (Literal)Master.FindControl("Literal1");
            Literal1.Text = sb.ToString();
        }
        #endregion
    }
}