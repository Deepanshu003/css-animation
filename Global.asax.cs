using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AapnoGharWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));
            routes.Add(new Route("{*favicon}", null, new RouteValueDictionary { { "favicon", @"(.*/)?favicon.ico(/.*)?" } }, new StopRoutingHandler()));
            routes.Ignore("{*alljs}", new { alljs = ".*\\.js(/.*)?" });
            routes.Ignore("{*allpng}", new { allpng = ".*\\.png(/.*)?" });
            routes.Ignore("{*allcss}", new { allcss = ".*\\.css(/.*)?" });
            routes.Ignore("{*alljpg}", new { alljpg = ".*\\.jpg(/.*)?" });
            routes.Ignore("{*alljpeg}", new { alljpeg = ".*\\.jpeg(/.*)?" });
            routes.Ignore("{*alljpeg}", new { alljpeg = ".*\\.gif(/.*)?" });

            //Admin Panel
            routes.MapPageRoute("", "aapnoghar-admin/login", "~/AapnoGharAdmin/index.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/home", "~/AapnoGharAdmin/Home.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/change-password", "~/AapnoGharAdmin/ChangePassword.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/logout", "~/AapnoGharAdmin/Logout.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-amenities", "~/AapnoGharAdmin/AddUpdAmenities.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/amenities", "~/AapnoGharAdmin/ManageAmenities.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/addupd-Room", "~/AapnoGharAdmin/AddUpdRoomData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-Room", "~/AapnoGharAdmin/ManageRoomData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/room-gallery-data", "~/AapnoGharAdmin/ManageRoomGalleryData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/room-availability", "~/AapnoGharAdmin/ManageRoomAvailability.aspx");


            routes.MapPageRoute("", "aapnoghar-admin/addupd-package", "~/AapnoGharAdmin/AddUpdPackage.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/package", "~/AapnoGharAdmin/ManagePackage.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-entertainment", "~/AapnoGharAdmin/AddUpdEntertainmentData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-entertainment", "~/AapnoGharAdmin/ManageEntertainmentData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/entertainment-gallery-data", "~/AapnoGharAdmin/ManageEntertainmentGalleryData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-entertainment-meal", "~/AapnoGharAdmin/AddUpdEntertainmentMealData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-entertainment-meal", "~/AapnoGharAdmin/ManageEntertainmentMealData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-entertainment-activity", "~/AapnoGharAdmin/AddUpdEntertainmentActivityData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-entertainment-activity", "~/AapnoGharAdmin/ManageEntertainmentActivityData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-festival-charges", "~/AapnoGharAdmin/AddUpdFestivalChargesData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-festival-charges", "~/AapnoGharAdmin/ManageFestivalChargesData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-coupons", "~/AapnoGharAdmin/AddUpdCouponsData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-coupons", "~/AapnoGharAdmin/ManageCouponsData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addUpd-customer", "~/AapnoGharAdmin/AddUpdCustomer.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-customer", "~/AapnoGharAdmin/ManageCustomer.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/room-booking-history", "~/AapnoGharAdmin/ViewOrderHistory.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-room-booking", "~/AapnoGharAdmin/ManageOrder.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-entertainment-book-order", "~/AapnoGharAdmin/ManageEntertainmentBookOrder.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/entertainment-book-history", "~/AapnoGharAdmin/ViewEntertainmentHistory.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-weddeing-event", "~/AapnoGharAdmin/AddUpdWeddeingEventData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-weddeing-event", "~/AapnoGharAdmin/ManageWeddeingEventData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/weddeing-event-gallery-data", "~/AapnoGharAdmin/ManageWeddeingEventGalleryData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/wedding-and-celebration-enquiry", "~/AapnoGharAdmin/ManageWeddeingEventDataEnquiry.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-eat-and-drink", "~/AapnoGharAdmin/AddUpdEatAndDrinkData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-eat-and-drink", "~/AapnoGharAdmin/ManageEatAndDrinkData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/eat-and-drink-gallery-data", "~/AapnoGharAdmin/ManageEatAndDrinkGalleryData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/eat-and-drink-enquiry", "~/AapnoGharAdmin/ManageEatAndDrinkEnquiryData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-cms-page", "~/AapnoGharAdmin/AddUpdCMSData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/manage-cms-page", "~/AapnoGharAdmin/ManageCMSData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/cms-page-gallery-data", "~/AapnoGharAdmin/ManageCMSGalleryData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/cms-page-enquiry", "~/AapnoGharAdmin/ManageCMSEnquiryData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-photo-category", "~/AapnoGharAdmin/AddUpdPhotoCategory.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/Photo-category", "~/AapnoGharAdmin/ManagePhotoCategory.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/addupd-photo-data", "~/AapnoGharAdmin/AddUpdPhotoData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/photo-data", "~/AapnoGharAdmin/ManagePhotoData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/addupd-video-data", "~/AapnoGharAdmin/AddUpdVideoData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/video-data", "~/AapnoGharAdmin/ManageVideoData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-blog-category", "~/AapnoGharAdmin/AddUpdBlogCategory.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/blog-category", "~/AapnoGharAdmin/ManageBlogCategory.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/addupd-blog-data", "~/AapnoGharAdmin/AddUpdBlogData.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/blog-data", "~/AapnoGharAdmin/ManageBlogData.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/addupd-job-category", "~/AapnoGharAdmin/AddUpdJobCategory.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/job-category", "~/AapnoGharAdmin/ManageJobCategory.aspx");
            routes.MapPageRoute("", "aapnoghar-admin/career", "~/AapnoGharAdmin/ManageCareer.aspx");

            routes.MapPageRoute("", "aapnoghar-admin/contact-us", "~/AapnoGharAdmin/ManageContact.aspx");

            //Front End Panel
            routes.MapPageRoute("", "", "~/index.aspx");
            routes.MapPageRoute("", "about-us", "~/AboutUs.aspx");
            routes.MapPageRoute("", "career", "~/CareerFront.aspx");
            routes.MapPageRoute("", "contact-us", "~/ContactUs.aspx");
            routes.MapPageRoute("", "eat-and-drink-offer", "~/EatAndDrink.aspx");
            routes.MapPageRoute("", "gallery", "~/Gallery.aspx");
            routes.MapPageRoute("", "packages", "~/Packages.aspx");
            routes.MapPageRoute("", "picnic-packages", "~/Packages.aspx");
            routes.MapPageRoute("", "family-stay-packages", "~/Packages.aspx");
            routes.MapPageRoute("", "privacy-policy", "~/PrivacyPolicy.aspx");
            routes.MapPageRoute("", "terms-and-conditions", "~/TermsAndConditions.aspx");
            routes.MapPageRoute("", "something-went-wrong", "~/SomethingWentWrong.aspx");
            routes.MapPageRoute("", "thank-you", "~/ThankYou.aspx");
            routes.MapPageRoute("", "pay-now", "~/CCAVRequestHandler.aspx");
            routes.MapPageRoute("", "transaction-succesfull", "~/CCAVResponseHandler.aspx");
            routes.MapPageRoute("", "transaction-failed", "~/CCAVTransactionFailed.aspx");

            routes.MapPageRoute("", "userdashboard", "~/UserDashboard.aspx");
            routes.MapPageRoute("", "userdashboard-profile", "~/UserDashboardProfile.aspx");            
            routes.MapPageRoute("", "userdashboard-stay-room", "~/UserDashboardRoomAndSuits.aspx");
            routes.MapPageRoute("", "userdashboard-activities", "~/UserDashboardActivities.aspx");
            routes.MapPageRoute("", "log-out", "~/UserDashboardLogOut.aspx");

            routes.MapPageRoute("", "blog", "~/Blog.aspx");
            routes.MapPageRoute("", "blog/{BlogTitleURL}", "~/BlogDetail.aspx");

            routes.MapPageRoute("", "meet-and-celebrate", "~/MeetAndCelebrateListing.aspx");
            routes.MapPageRoute("", "{WeddeingEventAlias}", "~/MeetAndCelebrateDetail.aspx", false, null, new RouteValueDictionary { { "isOtherMeetAndCelebrate", new isOtherisOtherMeetAndCelebrate() } });

            routes.MapPageRoute("", "{CMSAlias}", "~/CMSPageDetail.aspx", false, null, new RouteValueDictionary { { "isOtherCMSPage", new isOtherCMSPage() } });

            routes.MapPageRoute("", "stay", "~/RoomListing.aspx");
            //routes.MapPageRoute("", "{RoomNameAlias}", "~/RoomDetails.aspx");
            routes.MapPageRoute("", "{RoomNameAlias}", "~/RoomDetails.aspx", false, null, new RouteValueDictionary { { "isOtherRoom", new isOtherRoom() } });
            routes.MapPageRoute("", "room-booking-cart", "~/RoomBooking.aspx");
            routes.MapPageRoute("", "room-packages", "~/RoomPackages.aspx");            
            routes.MapPageRoute("", "room-booking-guest", "~/RoomBookingGuestDetail.aspx");

            //routes.MapPageRoute("", "{EntertainmentNameAlias}", "~/EntertainmentDetails.aspx");
            routes.MapPageRoute("", "{EntertainmentNameAlias}", "~/EntertainmentDetails.aspx", false, null, new RouteValueDictionary { { "isOtherEntertainment", new isOtherEntertainment() } });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Do Not Allow URL to end in trailing slash
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            if (string.IsNullOrEmpty(url)) return;

            string lastChar = url[url.Length - 1].ToString();
            if (lastChar == "/" || lastChar == "\\")
            {
                url = url.Substring(0, url.Length - 1);
                if (url != "")
                {
                    Response.Clear();
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", url);
                    Response.End();
                }
            }

            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/bestweddingresort"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/bestweddingresort", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/book-now"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/book-now", "https://www.aapnoghar.com/room-booking-cart"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/wateramusementparkdelhincr"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/wateramusementparkdelhincr", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/breakfast-menu"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/breakfast-menu", "https://www.aapnoghar.com/eat-and-drink-offer"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/lunch-menu"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/lunch-menu", "https://www.aapnoghar.com/eat-and-drink-offer"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/snacks"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/snacks", "https://www.aapnoghar.com/eat-and-drink-offer"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/food-menu"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/food-menu", "https://www.aapnoghar.com/eat-and-drink-offer"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/resort-view"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/resort-view", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/resort-view"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/resort-view", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/rooms"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/rooms", "https://www.aapnoghar.com/stay"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/banquet-hall"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/banquet-hall", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/wedding-lawns"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/wedding-lawns", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/water-park-pics"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/water-park-pics", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/amusement-park-pics"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/amusement-park-pics", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/restaurant"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/restaurant", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/amusement-park-2"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/amusement-park-2", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/amusement-park-package"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/amusement-park-package", "https://www.aapnoghar.com/packages"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/all-gallery"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/all-gallery", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/booknow"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/booknow", "https://www.aapnoghar.com/room-booking-cart"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/bookings"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/bookings", "https://www.aapnoghar.com/room-booking-cart"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/contact-form"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/contact-form", "https://www.aapnoghar.com/contact-us"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/video-gallery"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/video-gallery", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/image-gallery"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/image-gallery", "https://www.aapnoghar.com/gallery"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/amusement-park"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/amusement-park", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/uncategorized/page/2"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/uncategorized/page/2", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/new-year-2021"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/new-year-2021", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/amusement-parks"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/amusement-parks", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/valentine-venues"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/valentine-venues", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/lohri-venue"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/lohri-venue", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/holi-party"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/holi-party", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/kids-birthday-party"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/kids-birthday-party", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/wedding-venue"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/wedding-venue", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/wedding-anniversary"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/wedding-anniversary", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/christmas-venue"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/christmas-venue", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/pre-wedding-venue"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/pre-wedding-venue", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/family-function"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/family-function", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/diwali-party-venues"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/diwali-party-venues", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/author/aapnoghar"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/author/aapnoghar", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/water-park"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/water-park", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/author/aapnoghar/page/2"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/author/aapnoghar/page/2", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/author/aapnoghar/page/3"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/author/aapnoghar/page/3", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/author/aapnoghar/page/4"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/author/aapnoghar/page/4", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/page/2"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/page/2", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/page/3"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/page/3", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/page/4"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/page/4", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/best-amusement-park-in-gurgaon"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/best-amusement-park-in-gurgaon", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/best-theme-parks-near-gurugram"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/best-theme-parks-near-gurugram", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/best-water-park-in-gurgaon"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/best-water-park-in-gurgaon", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/water-park-in-gurgaon"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/water-park-in-gurgaon", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/adventurepark"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/adventurepark", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/amusementpark"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/amusementpark", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/water-park-enjoyment"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/water-park-enjoyment", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/best-places-to-celebrate-new-year"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/best-places-to-celebrate-new-year", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/unique-places-to-celebrate-new-year"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/unique-places-to-celebrate-new-year", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/aapnogharresort"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/aapnogharresort", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/newyear"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/newyear", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/newyear2021"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/newyear2021", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/best-resorts-in-gurugram"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/best-resorts-in-gurugram", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/valentine-party-venues-in-gurgaon"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/valentine-party-venues-in-gurgaon", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/lohri-party-venues-in-gurgaon"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/lohri-party-venues-in-gurgaon", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/ideas-for-holi-party"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/ideas-for-holi-party", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/childrens-birthday-party-venues"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/childrens-birthday-party-venues", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/wedding-venue"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/wedding-venue", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/ideas-for-a-surprise-wedding-anniversary"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/ideas-for-a-surprise-wedding-anniversary", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/surprise-party-ideas-for-wedding-anniversary"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/surprise-party-ideas-for-wedding-anniversary", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/how-to-plan-a-corporate-christmas-party"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/how-to-plan-a-corporate-christmas-party", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/tips-to-plan-a-christmas-party"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/tips-to-plan-a-christmas-party", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/saving-money-at-amusement-park"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/saving-money-at-amusement-park", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/tips-to-save-money-at-amusement-park"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/tips-to-save-money-at-amusement-park", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/amusement-parks-in-gurgaon"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/amusement-parks-in-gurgaon", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/family-outing-amusement-park"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/family-outing-amusement-park", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/fun-ways-to-light-up-your-wedding"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/fun-ways-to-light-up-your-wedding", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/how-to-light-up-your-wedding-ideas"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/how-to-light-up-your-wedding-ideas", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/find-the-marriage-venue"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/find-the-marriage-venue", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/how-to-choose-the-perfect-marriage-venue"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/how-to-choose-the-perfect-marriage-venue", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/how-to-start-mehendi-function"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/how-to-start-mehendi-function", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/tag/sangeet-venues-in-gurgaon"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/tag/sangeet-venues-in-gurgaon", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/blog/category/uncategorized"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/blog/category/uncategorized", "https://www.aapnoghar.com/blog"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/accommodation/deluxe"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/accommodation/deluxe", "https://www.aapnoghar.com/deluxe-room"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/accommodation/luxury"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/accommodation/luxury", "https://www.aapnoghar.com/luxury-room"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/accommodation/suite"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/accommodation/suite", "https://www.aapnoghar.com/suite-room"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/accommodation/presidential-suite-1"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/accommodation/presidential-suite-1", "https://www.aapnoghar.com/presidential-suite-room-1"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/accommodation/presidential-suite-2"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/accommodation/presidential-suite-2", "https://www.aapnoghar.com/presidential-suite-room-2"));
            }
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("https://www.aapnoghar.com/hotel-term-condition"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("https://www.aapnoghar.com/hotel-term-condition", "https://www.aapnoghar.com/terms-and-conditions#Hotel"));
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //if (!(Request.Url.AbsoluteUri.ToLower().Contains("www")))
            //{
            //    if (!(Request.Url.AbsoluteUri.ToLower().Contains("https://")))
            //        Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://www."));
            //    else
            //        Response.Redirect(Request.Url.AbsoluteUri.Replace("https://", "https://www."));
            //}
        }
    }
}