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
    public partial class MeetAndCelebrateListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllActiveWeddeingEventDataForListing();
                AddMetaTags();
            }
        }

        #region Celebrate
        private void BindAllActiveWeddeingEventDataForListing()
        {
            WeddeingEventData ObjWeddeingEventData = new WeddeingEventData();
            DataSet ds = new DataSet();
            ds = ObjWeddeingEventData.SelectAllActiveWeddeingEventDataForListing();
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

        private void AddMetaTags()
        {
            Page.Title = "Meet & Celebrations - AapnoGhar";
            HtmlMeta objkeywords1 = (HtmlMeta)Master.FindControl("keywords1");
            objkeywords1.Content = "";
            HtmlMeta objdescription1 = (HtmlMeta)Master.FindControl("description1");
            objdescription1.Content = "";

            HtmlMeta titleOG = (HtmlMeta)Master.FindControl("titleOG");
            titleOG.Content = "Meet & Celebrations - AapnoGhar";
            HtmlMeta descriptionOG = (HtmlMeta)Master.FindControl("descriptionOG");
            descriptionOG.Content = "";

            HtmlMeta titleTwitter = (HtmlMeta)Master.FindControl("titleTwitter");
            titleTwitter.Content = "Meet & Celebrations - AapnoGhar";
            HtmlMeta descriptiontwitter = (HtmlMeta)Master.FindControl("descriptiontwitter");
            descriptiontwitter.Content = "";

            HtmlMeta titleGoogle = (HtmlMeta)Master.FindControl("titleGoogle");
            titleGoogle.Content = "Meet & Celebrations - AapnoGhar";
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