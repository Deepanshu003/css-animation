<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AapnoGharWeb.indexmain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="home_banner">
    <div class="home_demo">
        <div class="banner-slider owl-carousel">
            <asp:Repeater ID="RptrEntertainmentForHome" runat="server">
                <ItemTemplate>
                    <div class='item <%# Container.ItemIndex == 0 ? "active":"" %>'>
                        <a href="/<%#Eval("EntertainmentNameAlias")%>">
                            <%--<%# Container.ItemIndex == 0 ? "<div class='video'><video id='myVid' muted loop autoplay src='/AapnoGharlmages/EntertainmentImages/"+Eval("EntertainmentVideo")+"'></video></div>":"<div class='video'><video id='myVid' muted loop autoplay src='/AapnoGharlmages/EntertainmentImages/"+Eval("EntertainmentVideo")+"'></video><img class='poster' src='/AapnoGharlmages/EntertainmentImages/"+Eval("EntertainmentDefaultImage")+"' alt='"+Eval("EntertainmentNameAlias")+"' title='"+Eval("EntertainmentName")+"'/></div>" %>--%>
                            <%# Convert.ToString(Eval("EntertainmentVideo")) != "" ? "<div class='video'><video id='myVid' muted loop autoplay src='/AapnoGharlmages/EntertainmentImages/"+Eval("EntertainmentVideo")+"'></video><img class='poster' src='/AapnoGharlmages/EntertainmentImages/"+Eval("EntertainmentDefaultImage")+"' alt='"+Eval("EntertainmentNameAlias")+"' title='"+Eval("EntertainmentName")+"'/></div>":"<figure><img src='/AapnoGharlmages/EntertainmentImages/"+Eval("EntertainmentDefaultImage")+"' alt='"+Eval("EntertainmentNameAlias")+"' title='"+Eval("EntertainmentName")+"'/></figure>" %>
                            <div class="info"><p><%#Eval("EntertainmentName")%></p></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="item">
                <a href="/meet-and-celebrate">
                    <div class="video"><video id="myVid1" muted="" loop="" autoplay="" src="/assets/video/meet-and-celebrations.mp4"></video><img class="poster" src="assets/images/home/img3.jpg" alt="Meetings & Celebrations" title="Meetings & Celebrations"></div>
                    <div class="info"><p>Meetings & Celebrations</p></div>
                </a>
            </div>
            <div class="item">
                <a href="/stay">
                    <div class="video"><video id="myVid2" muted="" loop="" autoplay="" src="/assets/video/Stay.mp4"></video><img class="poster" src="assets/images/home/img4.jpg" alt="Stay" title="Stay"></div>
                    <div class="info"><p>Stay at Aapno Ghar</p></div>
                </a>
            </div>
        </div>
    </div>
</div>
<section>
    <div class="home_secA">
        <div class="container">
            <div class="flex">
                <div class="colA">
                    <figure><img src="assets/icons/Loader-BIG.gif" alt="water park near me with price" /></figure>
                </div>
                <div class="colB">
                    <div class="content">
                        <%--<div class="head_info"><h3>AapnoGhar Resort Water Park and Amusement Park , the city of joy is the ideal expression of a beautiful and unequalled dream world. It exists in harmony with the magic of nature.</h3></div>--%>
                        <div class="head_info"><h3>AapnoGhar Resort, Water and Amusement Park, the city of joy is the ideal expression of a beautiful and unequalled dream world. It exists in harmony with the magic of nature.</h3></div>
                        <div class="counter_sec">
                            <div class="count-info">
                                <h3><span class="count" data-count="29">0</span></h3>
                                <p>Years of experience</p>
                            </div>
                            <div class="count-info">
                                <h3><span class="count" data-count="20">0</span>+</h3>
                                <p>Thrilling rides</p>
                            </div>
                            <div class="count-info">
                                <h3><span class="count" data-count="20">0</span>+</h3>
                                <p>Adventure activities</p>
                            </div>
                            <div class="count-info">
                                <h3><span class="count" data-count="67">0</span></h3>
                                <p>Well-appointed rooms</p>
                            </div>
                            <div class="count-info">
                                <h3><span class="count" data-count="4">0</span></h3>
                                <p>Party lawns & banquet hall</p>
                            </div>
                            <div class="count-info only_mobile">
                                <h3><span class="count" data-count="29">0</span></h3>
                                <p>Amenities</p>
                            </div>
                        </div>
                        <div class="link_btn red_btn text-center"><a href="/about-us">Read More</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section id="PnlPackageData" runat="server" visible="false">
    <div class="home_secB">
        <div class="heading text-center">
            <h3>JHUL JHUL KAR KHAO</h3>
        </div>
        <div class="container">            
            <div class="content_cola">
                <div class="cola_wrapper">
                    <div class="col_bx">
                        <asp:Repeater ID="RptrPackageData" runat="server">
                            <ItemTemplate>
                                <div class="card <%# Container.ItemIndex == 0 ?  "active" : ""  %>" data-attr="tab<%#Eval("PackageID") %>">
                                    <div class="top_con">
                                        <div class="heading">
                                            <h3>Weekdays (Mon to Fri)</h3>
                                            <h2><%#Eval("PackageTitle") %></h2>
                                            <div class="line"><img src="assets/icons/heading_line.png" alt="water theme park near me" /></div>
                                        </div>
                                        <div class="right_aside">
                                            <h4>Rs.<%#Eval("KidsPrice") %></h4>
                                            <span class="at_top">From</span>
                                            <p class='paxextaxc'>inclusive of taxes</p>
                                        </div>
                                    </div>
                                    <div class="mid_con">
                                        <h6>Timing- <%#Eval("PackageTimming") %></h6>
                                        <%# Convert.ToString(Eval("PackagePunchline")) != "" ? "<p class='small'>"+Eval("PackagePunchline")+"</p>":"" %>
                                        <div class="pakage_pr">
                                            <div class="col" id="PnlAdults" runat="server" visible='<%# Convert.ToInt16(Eval("AdultPrice")) > 0 ? true:false %>'>
                                                <figure><img src="assets/icons/adult.gif" alt="water resort near me" /></figure>
                                                <div class="info_pakg">
                                                    <h4>Adults <span>Rs. <%#Eval("AdultPrice") %>/head</span></h4>
                                                    <%# Convert.ToString(Eval("PackageAdultsPunchline1")) != "" ? "<p class='small'>"+Eval("PackageAdultsPunchline1")+"</p>":"" %>
                                                </div>
                                            </div>
                                            <div class="col" id="PnlKids" runat="server" visible='<%# Convert.ToInt16(Eval("KidsPrice")) > 0 ? true:false %>'>
                                                <figure><img src="assets/icons/kids.gif" alt="water park resorts" /></figure>
                                                <div class="info_pakg">
                                                    <h4>Kids <span>Rs. <%#Eval("KidsPrice") %>/head</span></h4>
                                                    <%# Convert.ToString(Eval("PackageKidsPunchline1")) != "" ? "<p class='small'>"+Eval("PackageKidsPunchline1")+"</p>":"" %>
                                                    <%# Convert.ToInt16(Eval("PackageKidsPunchline2")) > 0 ? "<p class='small' style='color:red;'>Kids(below "+Eval("PackageKidsPunchline2")+" inches of height) are complimentary</p>":"" %>
                                                </div>
                                            </div>
                                            <div class="link_btn skyblue_btn"><a href="javascript:void(0);" class="model-open modelTyepCheck bind_package" data-type="Weekdays" data-model=".Popup_Book_ParkModel" data-Package='<%#Eval("PackageID") %>' data-name='<%#Eval("PackageTitle") %>' data-Timing='<%#Eval("PackageTimming") %>' data-Punchline='<%#Eval("PackagePunchline") %>' data-Kids='<%#Eval("KidsPrice") %>' data-Adult='<%#Eval("AdultPrice") %>' data-KidsTAX='<%#Eval("KidsPriceTaxs") %>' data-AdultTAX='<%#Eval("AdultPriceTaxs") %>' data-KidsPunchline1='<%#Eval("PackageKidsPunchline1") %>' data-KidsPunchline2='<%#Eval("PackageKidsPunchline2") %>' data-AdultsPunchline='<%#Eval("PackageAdultsPunchline1") %>'>Book Now</a></div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="RptrPackageData2" runat="server">
                            <ItemTemplate>
                                <div class="card" data-attr="tab_<%#Eval("PackageID") %>" style='display: none;'>
                                    <div class="top_con">
                                        <div class="heading">
                                            <h3>Weekends/Holidays</h3>
                                            <h2><%#Eval("PackageTitle") %></h2>
                                            <div class="line"><img src="assets/icons/heading_line.png" alt="best water park near me" /></div>
                                        </div>
                                        <div class="right_aside">
                                            <h4>Rs.<%#Eval("KidsPrice") %></h4>
                                            <span class="at_top">From</span>
                                            <p class='paxextaxc'>inclusive of taxes</p>
                                        </div>
                                    </div>
                                    <div class="mid_con">
                                        <h6>Timing- <%#Eval("PackageTimming") %></h6>
                                        <%# Convert.ToString(Eval("PackagePunchline")) != "" ? "<p class='small'>"+Eval("PackagePunchline")+"</p>":"" %>
                                        <div class="pakage_pr">                                            
                                            <div class="col" id="PnlAdults" runat="server" visible='<%# Convert.ToInt16(Eval("AdultPrice")) > 0 ? true:false %>'>
                                                <figure><img src="assets/icons/adult.gif" alt="nearest adventure park" /></figure>
                                                <div class="info_pakg">
                                                    <h4>Adults <span>Rs. <%#Eval("AdultPrice") %>/head</span></h4>
                                                    <%# Convert.ToString(Eval("PackageAdultsPunchline1")) != "" ? "<p class='small'>"+Eval("PackageAdultsPunchline1")+"</p>":"" %>
                                                </div>
                                            </div>
                                            <div class="col" id="PnlKids" runat="server" visible='<%# Convert.ToInt16(Eval("KidsPrice")) > 0 ? true:false %>'>
                                                <figure><img src="assets/icons/kids.gif" alt="resort and water park near me" /></figure>
                                                <div class="info_pakg">
                                                    <h4>Kids <span>Rs. <%#Eval("KidsPrice") %>/head</span></h4>
                                                    <%# Convert.ToString(Eval("PackageKidsPunchline1")) != "" ? "<p class='small'>"+Eval("PackageKidsPunchline1")+"</p>":"" %>
                                                    <%# Convert.ToInt16(Eval("PackageKidsPunchline2")) > 0 ? "<p class='small' style='color:red;'>Kids(below "+Eval("PackageKidsPunchline2")+" inches of height) are complimentary</p>":"" %>
                                                </div>
                                            </div>
                                            <div class="link_btn skyblue_btn"><a href="javascript:void(0);" class="model-open modelTyepCheck bind_package" data-type="Weekdays" data-model=".Popup_Book_ParkModel" data-Package='<%#Eval("PackageID") %>' data-name='<%#Eval("PackageTitle") %>' data-Timing='<%#Eval("PackageTimming") %>' data-Punchline='<%#Eval("PackagePunchline") %>' data-Kids='<%#Eval("KidsPrice") %>' data-Adult='<%#Eval("AdultPrice") %>' data-KidsTAX='<%#Eval("KidsPriceTaxs") %>' data-AdultTAX='<%#Eval("AdultPriceTaxs") %>' data-KidsPunchline1='<%#Eval("PackageKidsPunchline1") %>' data-KidsPunchline2='<%#Eval("PackageKidsPunchline2") %>' data-AdultsPunchline='<%#Eval("PackageAdultsPunchline1") %>'>Book Now</a></div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div style="display:none" class="nav_dots">
                        <ul>
                            <li class="active" data-attr="tab1"></li>
                            <li data-attr="tab2"></li>
                            <li data-attr="tab_1"></li>
                            <li data-attr="tab_2"></li>
                        </ul>
                    </div>
                </div>
                <div class="tabNav">
                    <div class="btnGoPrev btn-tbnav"><img src="/assets/icons/left_black.png" /></div>
                    <div class="btnGoNext btn-tbnav"><img src="/assets/icons/right_black.png" /></div>
                </div>
            </div>
            <div class="content_colb">
                <asp:Repeater ID="RptrPackageData1" runat="server">
                    <ItemTemplate>
                        <div class="cont <%# Container.ItemIndex == 0 ? "active":"" %>" data-attr="tab<%#Eval("PackageID") %>">
                            <div class="flex">
                                <div class="colA">
                                    <div class="col">
                                        <figure><img src='/AapnoGharlmages/PackageImages/<%#Eval("PackageImage1") %>' title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                    <div class="col">
                                        <figure><img src="/AapnoGharlmages/PackageImages/<%#Eval("PackageImage2") %>" title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                </div>
                                <div class="colB">
                                    <div class="col">
                                        <figure><img src="/AapnoGharlmages/PackageImages/<%#Eval("PackageImage3") %>" title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                    <div class="col">
                                        <figure><img src="/AapnoGharlmages/PackageImages/<%#Eval("PackageImage4") %>" title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="RptrPackageData21" runat="server">
                    <ItemTemplate>
                        <div class="cont" data-attr="tab_<%#Eval("PackageID") %>">
                            <div class="flex">
                                <div class="colA">
                                    <div class="col">
                                        <figure><img src='/AapnoGharlmages/PackageImages/<%#Eval("PackageImage1") %>' title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                    <div class="col">
                                        <figure><img src="/AapnoGharlmages/PackageImages/<%#Eval("PackageImage2") %>" title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                </div>
                                <div class="colB">
                                    <div class="col">
                                        <figure><img src="/AapnoGharlmages/PackageImages/<%#Eval("PackageImage3") %>" title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                    <div class="col">
                                        <figure><img src="/AapnoGharlmages/PackageImages/<%#Eval("PackageImage4") %>" title="<%#Eval("PackageTitle") %>" alt="<%#Eval("PackageTitleURL") %>" /></figure>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="link_btn white_btn text-center"><a href="/packages">View all Packages</a></div>
        </div>
    </div>
</section>
<section>
    <div class="home_secC" id="pnlCouponsData" runat="server" visible="true">
        <div class="bg">
            <figure><img src="assets/images/home/secC_banner.jpg" alt="nearby amusement park" /></figure>
        </div>
        <div class="secC_wrapper" style="display:none;">
            <div class="container">
                <asp:Repeater ID="RptrCouponsData" runat="server">
                    <ItemTemplate>
                        <div class="content">
                            <figure><img src="assets/images/home/secC_ico.png" alt="water park ticket" /></figure>
                            <div class="info_abt">
                                <h2><%# (Eval("CouponType").ToString() == "Value") ? "₹ " + Eval("CouponValue") + "" : "" + Eval("CouponValue") + " %" %> OFF</h2>
                                <h4>ALL GROUP Picnic!</h4>
                                <h2>Promo Code: <%#Eval("CouponCode")%></h2>
                                <p class="small">Use the promo code at checkout.<br />Offer ends on <%# Convert.ToDateTime(Eval("CouponExpiry")).ToString("ddd, dd MMM yyyy") %>.</p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</section>
<section id="pnlRoomData" runat="server" visible="false">
    <div class="home_secD">
        <div class="container">
            <div class="heading text-center">
                <h3><span>Accommodation</span> stay and play your way</h3>
                <p>The heart of the action or a secluded tropical sanctuary? Your choice of resort accommodation awaits.</p>
                <div class="tsd_btn"><a href="https://www.aapnoghar.com/aapno360/presidential-suite.html" target="_blank">360&#176;</a></div>
            </div>
            <div class="Accom_demo">
                <div class="accom-slider owl-carousel">
                    <asp:Repeater ID="RptrRoomData" runat="server">
                        <ItemTemplate>
                            <div class="item left_image">
                                <div class="card">
                                    <figure><img src="/AapnoGharlmages/RoomImages/<%#Eval("RoomImage1")%>" alt="<%#Eval("RoomNameAlias")%>" title="<%#Eval("RoomName")%>"/></figure>
                                    <div class="info_card active"><p><%#Eval("RoomName")%></p></div>
                                    <a href="/<%#Eval("RoomNameAlias")%>"></a>
                                </div>
                            </div>
                            <div class="item">
                                <div class="card">
                                    <figure><img src="/AapnoGharlmages/RoomImages/<%#Eval("RoomDefaultImage")%>" alt="<%#Eval("RoomNameAlias")%>" title="<%#Eval("RoomName")%>"/></figure>
                                    <div class="info_card active"><p><%#Eval("RoomName")%></p></div>
                                    <a href="/<%#Eval("RoomNameAlias")%>"></a>
                                </div>
                            </div>
                            <div class="item right_image">
                                <div class="card">
                                    <figure><img src="/AapnoGharlmages/RoomImages/<%#Eval("RoomImage2")%>" alt="<%#Eval("RoomNameAlias")%>" title="<%#Eval("RoomName")%>"/></figure>
                                    <div class="info_card active"><p><%#Eval("RoomName")%></p></div>
                                    <a href="/<%#Eval("RoomNameAlias")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="link_btn gold_btn text-center"><a href="/stay">View All</a></div>
        </div>
    </div>
</section>
<section id="pnlWeddeingEventType" runat="server" visible="false">
    <div class="home_secE">
        <div class="secE-wrapper">
            <div class="container">
                <div class="heading text-center">
                    <h3><span>Wedding & Events</span> Start Planning</h3>
                </div>
                <div class="upper_nav">
                    <ul>
                        <asp:Repeater ID="RptrWeddeingEventType" runat="server">
                            <ItemTemplate>
                                <li <%# Container.ItemIndex == 0 ? "class='active'":"" %> data-tab='car-<%#Eval("WeddeingEventType").ToString().ToLower().Replace(" ", "-").Replace("&", "and") %>'>
                                    <%# Convert.ToString(Eval("WeddeingEventType")) == "Wedding Ceremony" ? "<img src='assets/icons/hrt_ico.png'/>":"" %>
                                    <%# Convert.ToString(Eval("WeddeingEventType")) == "Corporate Events" ? "<img src='assets/icons/mic_ico.png'/>":"" %>
                                    <%# Convert.ToString(Eval("WeddeingEventType")) == "Venues" ? "<img src='assets/icons/venues_ico.png'/>":"" %>                                    
                                    <a href="Javascript:void(0)"><%#Eval("WeddeingEventType") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="event_wrapper">
                <asp:Repeater ID="RptrWeddeingEventType1" runat="server">
                    <ItemTemplate>
                        <div class="event_demo" data-tab="car-<%#Eval("WeddeingEventType").ToString().ToLower().Replace(" ", "-").Replace("&", "and") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display:none;'" %>>
                            <asp:HiddenField ID="hndWeddeingEventType" Value='<%#Eval("WeddeingEventType")%>' Visible="false" runat="server" />
                            <div class="event-slider owl-carousel">
                                <asp:Repeater ID="RptrWeddeingEventData" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <figure><img src="/AapnoGharlmages/WeddeingEventImages/<%#Eval("WeddeingEventDefaultImage")%>" alt="<%#Eval("WeddeingEventAlias")%>" title="<%#Eval("WeddeingEventName")%>" /></figure>
                                            <div class="info_slide <%# Container.ItemIndex == 0 ? "active":"" %>">
                                                <%# Convert.ToString(Eval("WeddeingEventVideoLink")) != "" ? "<div class='video_icon model-video model-open' data-model='.Model_Video' data-video='"+Eval("WeddeingEventVideoLink")+"?autoplay=1;rel=0'><img src='assets/icons/play.png' alt='' /></div>":"" %>                                        
                                                <h4><%#Eval("WeddeingEventName")%></h4>
                                                <%# Convert.ToString(Eval("WeddeingEventSamllDescription")) != "" ? "<p>"+Eval("WeddeingEventSamllDescription")+"</p>":"" %>     
                                            </div>
                                            <a href="/<%#Eval("WeddeingEventAlias")%>"></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="link_btn red_btn"><a href="/meet-and-celebrate">View All</a></div>
        </div>
    </div>
</section>
<section>
    <div class="home_secF">
        <div class="container">
            <div class="heading text-center">
                <h3>Meet some of the people behind <span>our stories</span></h3>
                <p>AapnoGhar Resort Water Park and Amusement Park , the city of joy is the ideal expression of a beautiful and unequalled dream world.</p>
            </div>
        </div>
        <div class="content_f">
            <div class="testi_demo">
                <div class="testi-slider owl-carousel">
                    <div class="item">
                        <div class="card">
                            <div class="upper_ico"><img src="assets/icons/testi_ico.png" alt="water park ticket price" /></div>
                            <div class="text">Nice and well maintained resort with amusement park my kitti my son enjoy lot in amusement park they arrange lot of activity in amusement park ap...</div>
                            <div class="btm_con">
                                <div class="name">anilkU8596BG</div>
                                <p>TripAdvisor review</p>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="card">
                            <div class="upper_ico"><img src="assets/icons/testi_ico.png" alt="nearby water park" /></div>
                            <div class="text">Enjoyed a lot..fun filled activities..good rides..reminded me of my childhood...icing on d cake was food...delicious makke nd bajra rotis with sa...</div>
                            <div class="btm_con">
                                <div class="name">Purvai G</div>
                                <p>Amusement Park and Restaurant</p>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="card">
                            <div class="upper_ico"><img src="assets/icons/testi_ico.png" alt="amusement water park" /></div>
                            <div class="text">As while exploring a resort on internet to spend my weekend in NCR along with my family a good property / hotel was found i.e. AAPNO Ghar Resort ...</div>
                            <div class="btm_con">
                                <div class="name">Amit B</div>
                                <p>1 Night, Standard Room</p>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="card">
                            <div class="upper_ico"><img src="assets/icons/testi_ico.png" alt="best amusement park near me" /></div>
                            <div class="text">Nice and well maintained resort near Delhi , perfect place for child specially 9 to 15 year old . I think Aapno Ghar launches new package rides a...</div>
                            <div class="btm_con">
                                <div class="name">Abhishek</div>
                                <p>5 Nights, Luxury Suite</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="flex_wrapper" id="PnlTestimonial" runat="server" visible="false">
                <div class="con_flx">
                    <div class="colA" id="PnlTestimonial1" runat="server" visible="false">
                        <div class="flex">
                            <asp:Repeater ID="RptrTestimonial1" runat="server">
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="card">
                                            <figure><img src="/AapnoGharlmages/VideoGallery/<%#Eval("SmallImg")%>" alt="<%#Eval("GalleryTitle")%>" title="<%#Eval("GalleryTitle")%>"/></figure>
                                            <div class="icon_vdo">
                                                <div class="video_icon model-video model-open" data-model=".Model_Video" data-video="<%#Eval("VideoURL")%>?autoplay=1"><img src="assets/icons/play.png" alt="water fun park near me" /></div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="colA" id="PnlTestimonial2" runat="server" visible="false">
                        <div class="flex">
                            <asp:Repeater ID="RptrTestimonial2" runat="server">
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="card">
                                            <figure><img src="/AapnoGharlmages/VideoGallery/<%#Eval("SmallImg")%>" alt="<%#Eval("GalleryTitle")%>" title="<%#Eval("GalleryTitle")%>"/></figure>
                                            <div class="icon_vdo">
                                                <div class="video_icon model-video model-open" data-model=".Model_Video" data-video="<%#Eval("VideoURL")%>?autoplay=1"><img src="assets/icons/play.png" alt="amusement park" /></div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<script type="text/javascript">
    //navText: ['<img src="assets/icons/left_black.png" />', '<img src="assets/icons/right_black.png" />'],
    $(function () {
        var counted = 0;
        $(window).scroll(function () {
            var oTop = $('.counter_sec').offset().top - window.innerHeight / 2;
            if (counted == 0 && $(window).scrollTop() > oTop) {
                $('.count').each(function () {
                    var $this = $(this),
                        countTo = $this.attr('data-count');
                    $({
                        countNum: $this.text()
                    }).animate({
                        countNum: countTo
                    }, {
                        duration: 2000,
                        easing: 'swing',
                        step: function () {
                            $this.text(Math.floor(this.countNum));
                        },
                        complete: function () {
                            $this.text(this.countNum);
                        }
                    });
                });
                counted = 1;
            }
        });
    });

    $('.tabNav .btnGoNext').click(function () {
        var next2 = ($('.content_colb .cont.active').next().length > 0) ? $('.content_colb .cont.active').next() : $('.content_colb .cont:first-child');
        next2.addClass("active").siblings().removeClass("active");
        var next = ($('.col_bx .card.active').next().length > 0) ? $('.col_bx .card.active').next() : $('.col_bx .card:first-child');
        next.addClass("active").siblings().removeClass("active");
    });

    $('.tabNav .btnGoPrev').click(function () {
        var prev2 = ($('.content_colb .cont.active').prev().length > 0) ? $('.content_colb .cont.active').prev() : $('.content_colb .cont:last-child');
        prev2.addClass("active").siblings().removeClass("active");
        var prev = ($('.col_bx .card.active').prev().length > 0) ? $('.col_bx .card.active').prev() : $('.col_bx .card:last-child');
        prev.addClass("active").siblings().removeClass("active");
    });

    $('.banner-slider .item').each(function () {
        $(this).hover(
            function () {
                $(this).addClass('active');
                $(this).parent('.owl-item').siblings().children('.item').removeClass('active');
            },
            function () {
                $(this).removeClass('active');
            });
    });
</script>
</asp:Content>
