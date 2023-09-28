using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using Component;
using Utility;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;

namespace AapnoGharWeb
{
    public partial class CCAVResponseHandler : System.Web.UI.Page
    {

        int ordeNo = 0;
        string trnID;
        string trnstatusStatus;
        CustomerOrder ObjCustomerOrder = new CustomerOrder();
        EntertainmentBookData ObjEntertainmentBookData = new EntertainmentBookData();
        ManageException ObjEx = new ManageException();
        CustomerData ObjCustomerData = new CustomerData();
        SqlDataReader SqlReader, SqlReaderOTP;
        protected void Page_Load(object sender, EventArgs e)
        {
            string workingKey = "0A4235891C342EF85ABBCA0682268EC3"; //URL:https://www.aapnoghar.com
            //string workingKey = "E8CBBBC8D9D203FEB2B4B15F1C0ACCFF"; //URL:https://www.aapnoghar.com
            //string workingKey = "F1B105730E9047B478110D664437A5E0"; //URL:http://localhost:1997
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }
            for (int i = 0; i < Params.Count; i++)
            {
                if (i == 0)
                {
                    ordeNo = Convert.ToInt32(Params[i]);
                }
                if (i == 1)
                {
                    trnID = Params[i];
                }
                if (i == 3)
                {
                    trnstatusStatus = Params[i];
                }
            }
            if ((ordeNo != 0) && (trnID != "") && (trnstatusStatus == "Success"))
            {
                if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "Rooms" && trnstatusStatus == "Success")
                {
                    int ret1 = 0;
                    string txnidtxnid = string.Empty;
                    if (Convert.ToInt32(ordeNo) < 10)
                        txnidtxnid = "APG00000R" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 100 && Convert.ToInt32(ordeNo) > 10)
                        txnidtxnid = "APG0000R" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 1000 && Convert.ToInt32(ordeNo) > 100)
                        txnidtxnid = "APG000R" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 10000 && Convert.ToInt32(ordeNo) > 1000)
                        txnidtxnid = "APG00R" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 100000 && Convert.ToInt32(ordeNo) > 10000)
                        txnidtxnid = "APG0R" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 1000000)
                        txnidtxnid = "APGR" + ordeNo.ToString();
                    ObjCustomerOrder.OrderNo = Convert.ToInt16(ordeNo);
                    ObjCustomerOrder.PaymentID = txnidtxnid;
                    ObjCustomerOrder.TransactionID = trnID;
                    ObjCustomerOrder.TransactionStatus = "Success";
                    ObjCustomerOrder.UpdatedBy = "Online Payments";
                    ret1 = ObjCustomerOrder.UpdateRoomBookingOnlinePaymentStatus();
                    if (ret1 > 0)
                    {
                        SendMailToCustomerRoom(ordeNo.ToString());
                        Response.Redirect("/thank-you", false);
                    }
                }
                else if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "Package" && trnstatusStatus == "Success")
                {
                    int ret1 = 0;
                    string txnidtxnid = string.Empty;
                    if (Convert.ToInt32(ordeNo) < 10)
                        txnidtxnid = "APG00000P" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 100 && Convert.ToInt32(ordeNo) > 10)
                        txnidtxnid = "APG0000P" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 1000 && Convert.ToInt32(ordeNo) > 100)
                        txnidtxnid = "APG000P" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 10000 && Convert.ToInt32(ordeNo) > 1000)
                        txnidtxnid = "APG00P" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 100000 && Convert.ToInt32(ordeNo) > 10000)
                        txnidtxnid = "APG0P" + ordeNo.ToString();
                    else if (Convert.ToInt32(ordeNo) < 1000000)
                        txnidtxnid = "APGP" + ordeNo.ToString();
                    ObjEntertainmentBookData.BookingOrderNo = ordeNo;
                    ObjEntertainmentBookData.PaymentID = txnidtxnid;
                    ObjEntertainmentBookData.TransactionID = trnID;
                    ObjEntertainmentBookData.TransactionStatus = "Success";
                    ObjEntertainmentBookData.UpdatedBy = "Online Payments";
                    ret1 = ObjEntertainmentBookData.UpdateFunctionBookingOnlinePaymentStatus();
                    if (ret1 > 0)
                    {
                        SendMailToCustomerToConfirmPayment(ordeNo);
                        Response.Redirect("/thank-you", false);
                    }
                }
                else
                    Response.Redirect("/something-went-wrong?MSG=Payment not found.", false);
            }
        }

        #region Room Mail
        private void SendMailToCustomerRoom(string OrderNo)
        {
            DataSet ds = new DataSet();
            CustomerOrder ObjCustomerOrder = new CustomerOrder();
            ObjCustomerOrder.OrderNo = Convert.ToInt32(OrderNo);
            ds = ObjCustomerOrder.SelectRoomOrderDetailsByOrderNoForMail();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0].DefaultView.ToTable(true, "OrderDate", "CustomerID", "CustomerName", "CustomerMobileNo", "CustomerEmailID", "CustomerGSTNo", "CustomerCompanyName", "BillingAddress", "StateName", "CityName", "LocationName", "CouponValue", "OrderTotalAmount", "PaymentOption", "PaymentID", "TransactionID", "TransactionStatus", "BookingStatus");
                string OrderDate = dt.Rows[0]["OrderDate"].ToString();
                int CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                string CustomerName = dt.Rows[0]["CustomerName"].ToString();
                string CustomerMobileNo = dt.Rows[0]["CustomerMobileNo"].ToString();
                string CustomerEmailID = dt.Rows[0]["CustomerEmailID"].ToString();
                string CustomerGSTNo = dt.Rows[0]["CustomerGSTNo"].ToString();
                string CustomerCompanyName = dt.Rows[0]["CustomerCompanyName"].ToString();
                string BillingAddress = dt.Rows[0]["BillingAddress"].ToString();
                string StateName = dt.Rows[0]["StateName"].ToString();
                string CityName = dt.Rows[0]["CityName"].ToString();
                string LocationName = dt.Rows[0]["LocationName"].ToString();
                string CouponValue = dt.Rows[0]["CouponValue"].ToString();
                string OrderTotalAmount = dt.Rows[0]["OrderTotalAmount"].ToString();
                string PaymentOption = dt.Rows[0]["PaymentOption"].ToString();
                string PaymentID = dt.Rows[0]["PaymentID"].ToString();
                string TransactionID = dt.Rows[0]["TransactionID"].ToString();
                string TransactionStatus = dt.Rows[0]["TransactionStatus"].ToString();
                string BookingStatus = dt.Rows[0]["BookingStatus"].ToString();
                ObjCustomerData.CustomerID = CustomerID;
                SqlReaderOTP = ObjCustomerData.SelectCustomerDataByCustomerIDOnlineOrder();
                while (SqlReaderOTP.Read())
                {
                    Session["CustomerID"] = SqlReaderOTP["CustomerID"].ToString();
                    Session["CustomerName"] = SqlReaderOTP["CustomerName"].ToString();
                    Session["CustomerMobileNo"] = SqlReaderOTP["CustomerMobileNo"].ToString();
                    Session["CustomerEmailID"] = SqlReaderOTP["CustomerEmailID"].ToString();
                    Session["CustomerGender"] = SqlReaderOTP["CustomerGender"].ToString();
                    Session["StateName"] = SqlReaderOTP["StateName"].ToString();
                    Session["CityName"] = SqlReaderOTP["CityName"].ToString();
                    Session["LocationName"] = SqlReaderOTP["LocationName"].ToString();
                    Session["BillingAddress"] = SqlReaderOTP["BillingAddress"].ToString();
                    Session["CustomerCompanyName"] = SqlReaderOTP["CustomerCompanyName"].ToString();
                    Session["CustomerGSTNo"] = SqlReaderOTP["CustomerGSTNo"].ToString();
                    Session["LastLoginDate"] = SqlReaderOTP["LastLoginDate"].ToString();
                }
                SqlReaderOTP.Dispose();
                SqlReaderOTP.Dispose();


                #region New Booking Invoice Formate
                StringBuilder str1 = new StringBuilder();
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0' style='padding:10px;margin:10px;'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;height:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td style='width:100%;text-align:left;vertical-align:top;'><a href='https://www.aapnoghar.com/'><img src='https://www.aapnoghar.com/assets/icons/email-logo.png' height='167' width='81' alt='logo' /></a></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;height:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                #region One -: Booking Details
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' align='left' cellpadding='3' style='color:#000;font-size:10px;'><strong><u>Booking Info</u></strong></td>");
                str1.Append("<td colspan='2' align='left' cellpadding='3' style='color:#000;font-size:10px;'><strong><u>Personal Info</u></strong></td>");
                str1.Append("</tr>");
                if (PaymentID != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + OrderNo.ToString() + " <span title='Invoice No'>(" + PaymentID + ")</span></td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Name</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + CustomerName + "</td>");
                    str1.Append("</tr>");
                }
                else
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + OrderNo.ToString() + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Name</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + CustomerName + "</td>");
                    str1.Append("</tr>");
                }
                if (CustomerEmailID != "")
                {
                    str1.Append("<tr>");
                    if (TransactionID != "")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else if (BookingStatus == "Booked")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Pending</td>");
                    }
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Email ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><a href='mailto:" + CustomerEmailID + "'>" + CustomerEmailID + "</ a></td>");
                    str1.Append("</tr>");
                }
                else
                {
                    str1.Append("<tr>");
                    if (TransactionID != "")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else if (BookingStatus == "Booked")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Pending</td>");
                    }
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Email ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                    str1.Append("</tr>");
                }
                if (CustomerMobileNo != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking Date</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(OrderDate).ToString("dd MMM yyyy") + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Contact Number</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><a href='tel:+91" + CustomerMobileNo + "'>+91-" + CustomerMobileNo + "</a></td>");
                    str1.Append("</tr>");
                }
                else
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking Date</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(OrderDate).ToString("ddd, dd MMM yyyy") + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Contact Number</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                if (CustomerCompanyName != "")
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Company Name</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + CustomerCompanyName + "</td>");
                }
                else
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Company Name</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                }
                if (CustomerGSTNo != "")
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>GST No.</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + CustomerGSTNo + "</td>");
                }
                else
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>GST No.</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                }
                str1.Append("</tr>");
                string Address = "";
                if (BillingAddress != "")
                    Address = BillingAddress;

                if (CityName != "")
                {
                    if (Address != "")
                        Address = Address + ", " + CityName;
                    else
                        Address = CityName;
                }


                if (StateName != "")
                {
                    if (Address != "")
                        Address = Address + " - " + StateName;
                    else
                        Address = StateName;
                }
                if (LocationName != "")
                {
                    if (Address != "")
                        Address = Address + "(" + LocationName + ")";
                    else
                        Address = LocationName;
                }
                if (Address != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Address</td>");
                    str1.Append("<td colspan='3' cellpadding='2' style='color:#000;font-size:9px;'>" + Address.ToString() + "</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                str1.Append("<td colspan='4' align='center' style='color:#000;font-size:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");
                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Two -: Event & Venue Details
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='5' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong><u>Address & Venue Details</u></strong></td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Organised By</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>AapnoGhar</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Check-in</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>After 12:00 Noon</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Check-out</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>Before 10:30 AM</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Address</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>AapnoGhar Sector 77, Gurugram, Haryana 122004</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='5' align='center' style='color:#000;font-size:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Three -: Tickets & Package Details
                string RoomType = "";
                int TotalRoomNo = 0;
                int TotalAdults = 0;
                int TotalKids = 0;
                int TotalKidRoomPrice = 0;
                int TotalRoomPrice = 0;
                int TotalRoomTaxes = 0;
                int TotalExRoomPrice = 0;
                int TotalExRoomTaxes = 0;
                DataTable dt0 = ds.Tables[0].DefaultView.ToTable(true, "RoomID", "RoomName", "RoomType", "CheckInDate", "CheckOutDate", "TotalNight");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0.5'>");


                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>S.no.</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Total Guest</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Room Price</span></strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Extra Charges</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Total Price</strong></td>");
                str1.Append("</tr>");
                for (int i = 0; i < dt0.Rows.Count; i++)
                {
                    if (RoomType != "")
                        RoomType = RoomType + ", " + dt0.Rows[i]["RoomType"].ToString();
                    else
                        RoomType = dt0.Rows[i]["RoomType"].ToString();
                    str1.Append("<tr>");
                    str1.Append("<td colspan='5' cellpadding='2' align='left' style='color:#000;font-size:10px;background-color:#e7e7e7;vertical-align:middle;'><strong>" + dt0.Rows[i]["RoomName"].ToString() + "<br/>(" + dt0.Rows[i]["RoomType"].ToString() + ")</strong> | Check-in: " + Convert.ToDateTime(dt0.Rows[i]["CheckInDate"]).ToString("dd MMM yyyy") + " | Check-out: " + Convert.ToDateTime(dt0.Rows[i]["CheckOutDate"]).ToString("dd MMM yyyy") + "</td>");
                    str1.Append("</tr>");
                    DataTable dt1 = new DataTable();
                    DataView dataView1 = new DataView(ds.Tables[0]);
                    dataView1.RowFilter = "RoomID=" + Convert.ToInt16(dt0.Rows[i]["RoomID"].ToString()) + "";
                    dt1 = dataView1.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {
                            int KidsPrice = 0;
                            TotalRoomNo = TotalRoomNo + 1;
                            TotalAdults = TotalAdults + Convert.ToInt16(dt1.Rows[j]["TotalAdults"].ToString());
                            TotalKids = TotalKids + Convert.ToInt16(dt1.Rows[j]["TotalKids"].ToString());
                            TotalRoomPrice = TotalRoomPrice + Convert.ToInt16(dt1.Rows[j]["RoomPrice"].ToString());
                            TotalRoomTaxes = TotalRoomTaxes + Convert.ToInt16(dt1.Rows[j]["RoomTaxes"].ToString());
                            TotalExRoomPrice = TotalExRoomPrice + Convert.ToInt16(dt1.Rows[j]["ExtraCharges"].ToString());
                            TotalExRoomTaxes = TotalExRoomTaxes + Convert.ToInt16(dt1.Rows[j]["ExtraChargesTax"].ToString());
                            KidsPrice = ((Convert.ToInt16(dt1.Rows[j]["ExtraCharges"].ToString())));
                            string Adults = "";
                            if (Convert.ToInt16(dt1.Rows[j]["TotalAdults"].ToString()) > 1)
                                Adults = dt1.Rows[j]["TotalAdults"].ToString() + " Adults";
                            else
                                Adults = dt1.Rows[j]["TotalAdults"].ToString() + " Adult";

                            if (Convert.ToInt16(dt1.Rows[j]["TotalKids"].ToString()) > 0)
                                Adults = Adults + ", " + dt1.Rows[j]["TotalKids"].ToString() + " Kids";

                            str1.Append("<tr>");
                            str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + (j + 1) + ".</td>");
                            str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + Adults.ToString() + "</td>");
                            str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + dt1.Rows[j]["RoomPrice"].ToString() + "</td>");
                            if (KidsPrice > 0)
                                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + KidsPrice + "</td>");
                            else
                                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR 0</td>");
                            str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + (Convert.ToInt32(dt1.Rows[j]["RoomPrice"].ToString()) + Convert.ToInt32(KidsPrice)).ToString() + "</td>");
                            str1.Append("</tr>");

                        }
                    }
                }
                string Adults1 = "";
                if (TotalAdults > 1)
                    Adults1 = TotalAdults + " Adults";
                else
                    Adults1 = TotalAdults + " Adult";

                if (TotalKids > 0)
                    Adults1 = Adults1 + ", " + TotalKids + " Kids";

                if (Convert.ToInt32(TotalRoomPrice) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Total Room Price</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + TotalRoomPrice.ToString() + "</td>");
                    str1.Append("</tr>");
                }
                if (Convert.ToInt32(TotalKidRoomPrice) > 0 || Convert.ToInt32(TotalExRoomPrice) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Total Extra Adult Charges</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + (TotalKidRoomPrice + TotalExRoomPrice).ToString() + "</td>");
                    str1.Append("</tr>");
                }
                if (Convert.ToInt32(TotalRoomTaxes) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Total TAX </td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + (TotalRoomTaxes + TotalExRoomTaxes).ToString() + "</td>");
                    str1.Append("</tr>");
                }
                if (Convert.ToInt32(CouponValue) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Coupon Amount - </td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + CouponValue.ToString() + "</td>");
                    str1.Append("</tr>");
                }

                str1.Append("<tr>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'><strong>Net Payable Amount -</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>INR " + OrderTotalAmount.ToString() + "/-</strong></td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'><strong>Total no of Guests -</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>" + Adults1 + "</strong></td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                if (TransactionID != "")
                    str1.Append("<td colspan='5' align='left' style='color:#000;font-size:10px;'><br><strong> - Amount in words : </strong>" + NumbersToWords(Convert.ToInt32(OrderTotalAmount)) + " only.<br><strong> - Transaction ID : </strong> " + TransactionID + "<br><strong> - Transaction Status : </strong> " + TransactionStatus + "<br><strong> - Booking Status : </strong> " + BookingStatus + "<br><br></td>");
                else
                    str1.Append("<td colspan='5' align='left' style='color:#000;font-size:10px;'><br><strong> - Amount in words : </strong>" + NumbersToWords(Convert.ToInt32(OrderTotalAmount)) + " only.<br><strong> - Booking Status : </strong> " + BookingStatus + "<br><br></td>");
                str1.Append("</tr>");

                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Four -: Terms & Conditions

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong>Terms & Conditions</strong></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
                if (RoomType.ToString().Contains("Room with Breakfast, Lunch, Dinner & Water & Amusement Park Ticket") == true)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>1. </strong>Booking is Non-Refundable..</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>2. </strong>Water and Amusement Park is chargeable.</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>3. </strong>Stag entry (Check- in) are not allowed in the Water Park/ Amusement Park.</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>4. </strong>We serve only VEG Food.</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>5. </strong>Only Staying guest allowed in residence area.</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>6. </strong>Check in time : 12:00 Noon and Check out time: 10:30 Am.</td>");
                    str1.Append("</tr>");
                }
                else
                {

                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>1. </strong>Booking is Non-Refundable..</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>2. </strong>Stag entry (Check- in) are not allowed in the Water Park/ Amusement Park.</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>3. </strong>We serve only VEG Food.</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>4. </strong>Only Staying guest allowed in residence area.</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>5. </strong>Check in time : 12:00 Noon and Check out time: 10:30 Am.</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'>&nbsp;</td>");
                str1.Append("</tr>");
                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:8px;padding:15px;margin:15px;'>If you have any query or concern, please feel free to contact us at <a href='tel:+917666779997'><strong>+91-7666779997</strong></a> or email us at <a href='mailto:info@aapnoghar.com'><strong>info@aapnoghar.com</strong></a>.</td>");
                str1.Append("</tr>");
                #endregion

                str1.Append("</table>");

                string InvoiceName1 = "aapno-ghar-room-booking-" + OrderNo.ToString() + ".pdf";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                string final = str1.ToString();
                str1.Clear();
                string appPath = HttpContext.Current.Request.ApplicationPath;
                string path = Server.MapPath(appPath + "/AapnoGharlmages/RoomInvoice/" + InvoiceName1);

                dynamic output = new FileStream(path, FileMode.Create);
                StringReader sr = new StringReader(final.ToString());
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10, 10, 10, 10);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, output);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();
                #endregion

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
                if ((TotalAdults + TotalKids) == 1)
                {
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + (TotalAdults + TotalKids) + " guest for " + TotalRoomNo + " rooms worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + OrderNo.ToString() + ".</p>");
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>If you have any questions, just reply to this email. We’ll be happy to help!</p>");

                }
                else
                {
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + (TotalAdults + TotalKids) + " guest for " + TotalRoomNo + " rooms worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + OrderNo.ToString() + ".</p>");
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
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

                if (Session["CustomerMobileNo"] != null && Session["CustomerMobileNo"].ToString() != "")
                {
                    ManageException ObjEx = new ManageException();
                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                        WebClient client = new WebClient();
                        string baseurl = "http://125.16.147.178/VoicenSMS/webresources/CreateSMSCampaignGet?ukey=I1aBFeA7tKwwAfw2DJ3rQHFAH&msisdn=" + Session["CustomerMobileNo"].ToString() + "&language=0&credittype=7&senderid=APOGHR&templateid=0&message=Thank you for your booking. You have got a perfect choice! We have received your booking having " + (TotalAdults + TotalKids) + " guests for " + TotalRoomNo + " rooms on our AapnoGhar against the booking number " + OrderNo + ". If you have any questions, please let us know, We’ll be happy to help!&filetype=2";
                        Stream data = client.OpenRead(baseurl);
                        StreamReader reader = new StreamReader(data);
                        string ResponseID = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        ObjEx.PublishError("Error in procedure SaveNewCustomerData()", ex);
                    }
                }
                if (TotalRoomNo > 1)
                    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + (TotalAdults + TotalKids) + " guests for " + TotalRoomNo + " rooms worth of ₹ " + OrderTotalAmount + " on our AapnoGhar against the booking number " + OrderNo.ToString() + ".<br><br><br> If you have any questions, please let us know, We’ll be happy to help!";
                else
                    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + (TotalAdults + TotalKids) + " guests for " + TotalRoomNo + " rooms worth of ₹ " + OrderTotalAmount + " on our AapnoGhar against the booking number " + OrderNo.ToString() + ".<br><br> If you have any questions, please let us know, We’ll be happy to help!";

                #region Send Email to customer
                try
                {
                    if (Session["CustomerEmailID"] != null && Session["CustomerEmailID"].ToString() != "")
                    {
                        Mail ObjMail = new Mail();
                        ObjMail.Subject = "Thankyou for your room Booking at AapnoGhar";
                        ObjMail.MailTo = Session["CustomerEmailID"].ToString();
                        ObjMail.MailCc = "info@aapnoghar.com";
                        ObjMail.Body = str.ToString().Replace(", , ", " ");
                        ObjMail.Title = "AapnoGhar";
                        ObjMail.SendMailInvoice(@Server.MapPath(appPath + "/AapnoGharlmages/RoomInvoice/" + InvoiceName1));//ObjMail.SendMail();
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/something-went-wrong?error=while sending email", false);
                }
                #endregion
            }
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

        #region Package Mail
        private void SendMailToCustomerToConfirmPayment(int BookingOrderNo)
        {
            DataSet ds = new DataSet();
            EntertainmentBookData ObjEntertainmentBookData = new EntertainmentBookData();
            ObjEntertainmentBookData.BookingOrderNo = Convert.ToInt32(BookingOrderNo);
            ds = ObjEntertainmentBookData.SelectEntertainmentOrderDetailsByBookingOrderNoForMail();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0].DefaultView.ToTable(true, "BookingOrderNo", "BookingDate", "DateOfVisit", "PackageTitle", "PackageTitleURL", "PackageTimming", "PackagePunchline", "PackageKidsPunchline1", "PackageKidsPunchline2", "PackageAdultsPunchline1", "KidsPrice", "AdultPrice", "TotalKids", "TotalAdult", "TotalGuest", "TotalKidsPrice", "TotalAdultPrice", "TotalPrice", "CouponCode", "CouponValue", "TotalTax", "OrderTotalAmount", "PaymentOption", "BookingStatus", "PaymentStatus", "TransactionID", "TransactionStatus", "PaymentID", "CustomerID", "CustomerName", "CustomerMobileNo", "CustomerEmailID", "CustomerGSTNo", "CustomerCompanyName", "BillingAddress", "StateName", "CityName", "LocationName");
                int CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                string FirstName = dt.Rows[0]["CustomerName"].ToString();
                string PhoneNo = dt.Rows[0]["CustomerMobileNo"].ToString();
                string EmailID = dt.Rows[0]["CustomerEmailID"].ToString();
                string CustomerGSTNo = dt.Rows[0]["CustomerGSTNo"].ToString();
                string CustomerCompanyName = dt.Rows[0]["CustomerCompanyName"].ToString();
                string BillingAddress = dt.Rows[0]["BillingAddress"].ToString();
                string StateName = dt.Rows[0]["StateName"].ToString();
                string CityName = dt.Rows[0]["CityName"].ToString();
                string LocationName = dt.Rows[0]["LocationName"].ToString();
                string BookingDate = dt.Rows[0]["BookingDate"].ToString();
                string DateOfVisit = dt.Rows[0]["DateOfVisit"].ToString();
                string PackageTitle = dt.Rows[0]["PackageTitle"].ToString();
                string PackageTimming = dt.Rows[0]["PackageTimming"].ToString();
                string PackagePunchline = dt.Rows[0]["PackagePunchline"].ToString();
                string PackageKidsPunchline1 = dt.Rows[0]["PackageKidsPunchline1"].ToString();
                string PackageKidsPunchline2 = dt.Rows[0]["PackageKidsPunchline2"].ToString();
                string PackageAdultsPunchline1 = dt.Rows[0]["PackageAdultsPunchline1"].ToString();
                string TotalKids = dt.Rows[0]["TotalKids"].ToString();
                string KidsPrice = dt.Rows[0]["KidsPrice"].ToString();
                string TotalAdult = dt.Rows[0]["TotalAdult"].ToString();
                string AdultPrice = dt.Rows[0]["AdultPrice"].ToString();
                string TotalGuest = dt.Rows[0]["TotalGuest"].ToString();
                string TotalPrice = dt.Rows[0]["TotalPrice"].ToString();
                string CouponCode = dt.Rows[0]["CouponCode"].ToString();
                string CouponValue = dt.Rows[0]["CouponValue"].ToString();
                string TotalTax = dt.Rows[0]["TotalTax"].ToString();
                string OrderTotalAmount = dt.Rows[0]["OrderTotalAmount"].ToString();
                string BookingStatus = dt.Rows[0]["BookingStatus"].ToString();
                string PaymentStatus = dt.Rows[0]["PaymentStatus"].ToString();
                string TransactionID = dt.Rows[0]["TransactionID"].ToString();
                string TransactionStatus = dt.Rows[0]["TransactionStatus"].ToString();
                string CustomerInvoiceNo = dt.Rows[0]["PaymentID"].ToString();
                ObjCustomerData.CustomerID = CustomerID;
                SqlReaderOTP = ObjCustomerData.SelectCustomerDataByCustomerIDOnlineOrder();
                while (SqlReaderOTP.Read())
                {
                    Session["CustomerID"] = SqlReaderOTP["CustomerID"].ToString();
                    Session["CustomerName"] = SqlReaderOTP["CustomerName"].ToString();
                    Session["CustomerMobileNo"] = SqlReaderOTP["CustomerMobileNo"].ToString();
                    Session["CustomerEmailID"] = SqlReaderOTP["CustomerEmailID"].ToString();
                    Session["CustomerGender"] = SqlReaderOTP["CustomerGender"].ToString();
                    Session["StateName"] = SqlReaderOTP["StateName"].ToString();
                    Session["CityName"] = SqlReaderOTP["CityName"].ToString();
                    Session["LocationName"] = SqlReaderOTP["LocationName"].ToString();
                    Session["BillingAddress"] = SqlReaderOTP["BillingAddress"].ToString();
                    Session["CustomerCompanyName"] = SqlReaderOTP["CustomerCompanyName"].ToString();
                    Session["CustomerGSTNo"] = SqlReaderOTP["CustomerGSTNo"].ToString();
                    Session["LastLoginDate"] = SqlReaderOTP["LastLoginDate"].ToString();
                }
                SqlReaderOTP.Dispose();
                SqlReaderOTP.Dispose();
                #region New Booking Invoice Formate
                StringBuilder str1 = new StringBuilder();
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'  style='padding:10px;margin:10px;'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;height:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td style='width:50%;text-align:left;vertical-align:top;'><a href='https://www.aapnoghar.com/'><img src='https://www.aapnoghar.com/assets/icons/email-logo.png' height='167' width='81' alt='logo' /></a></td>");
                str1.Append("<td style='width:50%;text-align:right;'>" + PackageTitle + " Booking Details&nbsp;</td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;height:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                #region One -: Booking Details
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' align='left' cellpadding='3' style='color:#000;font-size:10px;'><strong><u>Booking Info</u></strong></td>");
                str1.Append("<td colspan='2' align='left' cellpadding='3' style='color:#000;font-size:10px;'><strong><u>Personal Info</u></strong></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking ID</td>");
                if (CustomerInvoiceNo != "")
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + BookingOrderNo.ToString() + " <span title='Invoice No'>(" + CustomerInvoiceNo + ")</span></td>");
                else
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + BookingOrderNo.ToString() + "</td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Name</td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + FirstName + "</td>");
                str1.Append("</tr>");
                if (EmailID != "")
                {
                    str1.Append("<tr>");
                    if (TransactionID != "")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else if (BookingStatus == "Booked")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Pending</td>");
                    }
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Email ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><a href='mailto:" + EmailID + "'>" + EmailID + "</ a></td>");
                    str1.Append("</tr>");
                }
                else
                {
                    str1.Append("<tr>");
                    if (TransactionID != "")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else if (BookingStatus == "Booked")
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Confirmed</td>");
                    }
                    else
                    {
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Payment Status</td>");
                        str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Pending</td>");
                    }
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Email ID</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                    str1.Append("</tr>");
                }

                if (PhoneNo != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking Date</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(BookingDate).ToString("dd MMM yyyy") + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Contact Number</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><a href='tel:+91" + PhoneNo + "'>+91-" + PhoneNo + "</a></td>");
                    str1.Append("</tr>");
                }
                else
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Booking Date</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(BookingDate).ToString("dd MMM yyyy") + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Contact Number</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                if (CustomerCompanyName != "")
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Company Name</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + CustomerCompanyName + "</td>");
                }
                else
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Company Name</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                }
                if (CustomerGSTNo != "")
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>GST No.</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + CustomerGSTNo + "</td>");
                }
                else
                {
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>GST No.</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>NA</td>");
                }
                string Address = "";
                if (BillingAddress != "")
                    Address = BillingAddress;

                if (CityName != "")
                {
                    if (Address != "")
                        Address = Address + ", " + CityName;
                    else
                        Address = CityName;
                }


                if (StateName != "")
                {
                    if (Address != "")
                        Address = Address + " - " + StateName;
                    else
                        Address = StateName;
                }
                if (LocationName != "")
                {
                    if (Address != "")
                        Address = Address + "(" + LocationName + ")";
                    else
                        Address = LocationName;
                }
                if (Address != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Address</td>");
                    str1.Append("<td colspan='3' cellpadding='2' style='color:#000;font-size:9px;'>" + Address.ToString() + "</td>");
                    str1.Append("</tr>");
                }
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='4' align='center' style='color:#000;font-size:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");
                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Two -: Event & Venue Details
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='5' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong><u>Address & Venue Details</u></strong></td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Package Name</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageTitle + "</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Date Of Visit</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + Convert.ToDateTime(DateOfVisit).ToString("dd MMM yyyy") + "</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Organised By</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>AapnoGhar</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Timming</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageTimming + "</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Activity</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackagePunchline + "</td>");
                str1.Append("</tr>");
                if (PackageKidsPunchline1 != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Kids</td>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageKidsPunchline1 + "</td>");
                    str1.Append("</tr>");
                }
                if (PackageAdultsPunchline1 != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Adults</td>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>" + PackageAdultsPunchline1 + "</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Venue</td>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;'>AapnoGhar Sector 77, Gurugram, Haryana 122004</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='5' align='center' style='color:#000;font-size:10px;'>&nbsp;<br>&nbsp;</td>");
                str1.Append("</tr>");

                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Three -: Tickets & Package Details
                int i = 1;
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0.5'>");

                str1.Append("<tr>");
                str1.Append("<td colspan='5' cellpadding='2' align='left' style='color:#000;font-size:10px;background-color:#e7e7e7;vertical-align:middle;'><strong>Tickets & Package Details</strong></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>S.no.</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Type</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Price <span style='color:#000;font-size:8px;'>(per ticket)</span></strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>No of ticket</strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>Total Price</strong></td>");
                str1.Append("</tr>");
                if (Convert.ToInt16(TotalAdult) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + i + ".</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Adult(s)</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + AdultPrice + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + TotalAdult + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + (Convert.ToInt32(AdultPrice) * Convert.ToInt32(TotalAdult)).ToString() + "</td>");
                    str1.Append("</tr>");
                    i = i + 1;
                }
                if (Convert.ToInt16(TotalKids) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + i + ".</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>Kids</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + KidsPrice + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>" + TotalKids + "</td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + (Convert.ToInt32(KidsPrice) * Convert.ToInt32(TotalKids)).ToString() + "</td>");
                    str1.Append("</tr>");
                    i = i + 1;
                }
                if (Convert.ToInt32(TotalTax) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Total TAX </td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + TotalTax.ToString() + "</td>");
                    str1.Append("</tr>");
                }
                if (Convert.ToInt32(CouponValue) > 0)
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'>Coupon Amount - </td>");
                    str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'>INR " + CouponValue.ToString() + "</td>");
                    str1.Append("</tr>");
                }

                str1.Append("<tr>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'><strong>Net Payable Amount - </strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>INR " + OrderTotalAmount.ToString() + "/-</strong></td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='4' cellpadding='2' style='color:#000;font-size:9px;text-align:right;'><strong>Total no of Guests - </strong></td>");
                str1.Append("<td colspan='1' cellpadding='2' style='color:#000;font-size:9px;'><strong>" + TotalGuest + "</strong></td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                if (TransactionID != "")
                    str1.Append("<td colspan='5' align='left' style='color:#000;font-size:10px;'><br><strong> - Amount in words : </strong>" + NumbersToWords(Convert.ToInt32(OrderTotalAmount)) + " only.<br><strong> - Transaction ID : </strong> " + TransactionID + "<br><strong> - Transaction Status : </strong> " + TransactionStatus + "<br><strong> - Booking Status : </strong> " + BookingStatus + "<br><br></td>");
                else
                    str1.Append("<td colspan='5' align='left' style='color:#000;font-size:10px;'><br><strong> - Amount in words : </strong>" + NumbersToWords(Convert.ToInt32(OrderTotalAmount)) + " only.<br><strong> - Booking Status : </strong> " + BookingStatus + "<br><br></td>");
                str1.Append("</tr>");

                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");
                #endregion

                #region Commnet
                //#region Four -: Activity Include
                //DataTable dt1 = new DataTable();
                //DataView dataView = new DataView(ds.Tables[0]);
                //dataView.RowFilter = "BookingOrderNo =" + BookingOrderNo + " and ActivityType='Activity'";
                //dt1 = dataView.ToTable(true, "ActivityType", "ActivityName");
                //if (dt1.Rows.Count > 0)
                //{
                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong>Activity Include</strong></td>");
                //    str1.Append("</tr>");

                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                //    str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
                //    for (int k = 0; k < dt1.Rows.Count; k++)
                //    {
                //        str1.Append("<tr>");
                //        str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>" + (k + 1) + ". </strong>" + dt1.Rows[k]["ActivityName"].ToString() + "</td>");
                //        str1.Append("</tr>");
                //    }
                //    str1.Append("</table>");
                //    str1.Append("</td>");
                //    str1.Append("</tr>");

                //}
                //#endregion

                //#region Five -: Meal Include
                //dataView.RowFilter = "BookingOrderNo =" + BookingOrderNo + " and ActivityType='Meal'";
                //dt1 = dataView.ToTable(true, "ActivityType", "ActivityName");
                //if (dt1.Rows.Count > 0)
                //{
                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong>Meal Include</strong></td>");
                //    str1.Append("</tr>");

                //    str1.Append("<tr>");
                //    str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                //    str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
                //    for (int k = 0; k < dt1.Rows.Count; k++)
                //    {
                //        str1.Append("<tr>");
                //        str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>" + (k + 1) + ". </strong>" + dt1.Rows[k]["ActivityName"].ToString() + "</td>");
                //        str1.Append("</tr>");
                //    }
                //    str1.Append("</table>");
                //    str1.Append("</td>");
                //    str1.Append("</tr>");

                //}
                //#endregion

                //dataView.Dispose();
                //dt1.Dispose();
                //dt1.Clear();
                #endregion

                #region Six -: Terms & Conditions

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='color:#000;font-size:10px;'><strong>Terms & Conditions</strong></td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' align='left' style='padding:10px;margin:10px;'>");
                str1.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>1. </strong>Everything mentioned is included in the " + PackageTitle + " (" + PackagePunchline + ").</td>");
                str1.Append("</tr>");
                if (PackageKidsPunchline2 != "")
                {
                    str1.Append("<tr>");
                    str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>2. </strong>Kids(below " + PackageKidsPunchline2 + "inches of height) are complimentary</td>");
                    str1.Append("</tr>");
                }
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>3. </strong>Few activities may not be operational due to technical challenges.</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'><strong>4. </strong>Swimming costume is mandatory to enjoy water based activities. Costume is available on rental at the AapnoGhar.</td>");
                str1.Append("</tr>");
                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:9px;'>&nbsp;</td>");
                str1.Append("</tr>");
                str1.Append("</table>");
                str1.Append("</td>");
                str1.Append("</tr>");

                str1.Append("<tr>");
                str1.Append("<td colspan='2' cellpadding='2' style='color:#000;font-size:8px;padding:15px;margin:15px;'>If you have any query or concern, please feel free to contact us at <a href='tel:+917666779997'><strong>+91-7666779997</strong></a> or email us at <a href='mailto:info@aapnoghar.com'><strong>info@aapnoghar.com</strong></a>.</td>");
                str1.Append("</tr>");
                #endregion

                str1.Append("</table>");

                string InvoiceName1 = "aapno-ghar-package-" + BookingOrderNo.ToString() + ".pdf";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                string final = str1.ToString();
                str1.Clear();
                string appPath = HttpContext.Current.Request.ApplicationPath;
                string path = Server.MapPath(appPath + "/AapnoGharlmages/PackageInvoice/" + InvoiceName1);

                dynamic output = new FileStream(path, FileMode.Create);
                StringReader sr = new StringReader(final.ToString());
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10, 10, 10, 10);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, output);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();
                #endregion

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
                if (Convert.ToInt16(TotalGuest) == 1)
                {
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guest tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + BookingOrderNo.ToString() + ".</p>");
                    //str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>If you have any questions, just reply to this email. We’ll be happy to help!</p>");
                    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guest tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br> If you have any questions, please let us know, We’ll be happy to help!";
                    //Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guest tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.<br><br> If you have any questions, please let us know, We’ll be happy to help!";
                }
                else
                {
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guests tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking " + BookingOrderNo.ToString() + ".</p>");
                    //str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.</p>");
                    str.Append("<p style='color:#000;font-family:Verdana, Arial, Helvetica, sans-serif;font-size:13px;'>If you have any questions, just reply to this email. We’ll be happy to help!</p>");
                    Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guests tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br> If you have any questions, please let us know, We’ll be happy to help!";
                    //Session["Frontmsg"] = "Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guests tickets worth of ₹ " + OrderTotalAmount.ToString() + " on our AapnoGhar against the booking number " + BookingOrderNo.ToString() + ".<br><br>The amount of ₹ " + OrderTotalAmount.ToString() + " is paid successfully.<br><br> If you have any questions, please let us know, We’ll be happy to help!";
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
                    if (Session["CustomerEmailID"] != null && Session["CustomerEmailID"].ToString() != "")
                    {
                        Mail ObjMail = new Mail();
                        ObjMail.Subject = "Thankyou for your Booking at AapnoGhar";
                        ObjMail.MailTo = EmailID.ToString();
                        ObjMail.MailCc = "info@aapnoghar.com";
                        ObjMail.Body = str.ToString().Replace(", , ", " ");
                        ObjMail.Title = "AapnoGhar";
                        //ObjMail.SendMail();
                        ObjMail.SendMailInvoice(@Server.MapPath(appPath + "/AapnoGharlmages/PackageInvoice/" + InvoiceName1));
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/something-went-wrong?error=while sending email", false);
                }
                #endregion

                if (Session["CustomerMobileNo"] != null && Session["CustomerMobileNo"].ToString() != "")
                {
                    ManageException ObjEx = new ManageException();
                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                        WebClient client = new WebClient();
                        string baseurl = "http://125.16.147.178/VoicenSMS/webresources/CreateSMSCampaignGet?ukey=I1aBFeA7tKwwAfw2DJ3rQHFAH&msisdn=" + Session["CustomerMobileNo"].ToString() + "&language=0&credittype=7&senderid=APOGHR&templateid=0&message=Thank you for your booking. You have got a perfect choice! We have received your booking having " + TotalGuest + " guest tickets on our AapnoGhar against the booking number " + BookingOrderNo + ". If you have any questions, please let us know, We’ll be happy to help!&filetype=2";
                        Stream data = client.OpenRead(baseurl);
                        StreamReader reader = new StreamReader(data);
                        string ResponseID = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        ObjEx.PublishError("Error in procedure SaveNewCustomerData()", ex);
                    }
                }
            }
        }
        #endregion
    }
}