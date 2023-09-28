<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="Packages.aspx.cs" Inherits="AapnoGharWeb.Packages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .pakages_secA .pakage_content_tab .tab_pak .room_pakage-slider .col_bx .card { height: auto; }
</style>
<div class="pakages_secA" id="PnlPackageData" runat="server" visible="false">
    <div class="container">
        <div class="pakage_tab">
            <ul>
                <%--<asp:Repeater ID="RptrPackageData" runat="server">
                    <ItemTemplate>
                        <li  <%# Container.ItemIndex == 0 ? "style='class='active'":"" %>><a data-attr="tab_<%#Eval("PackageID") %>"><%#Eval("PackageTitle") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>--%>
                <asp:Literal ID="ltrPicnicPackages" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFamilyStayPackages" runat="server"></asp:Literal>
            </ul>
        </div>
        <div class="pakage_content_tab room-pakage-content-tab">
            <div class="tab_pak" id="PnlPacakegItemData" runat="server" visible="false" data-attr="tab_1" style='display: block;'>
                <div style="flex-direction: column" class="flex">
                    <div class="pakage_tab-wrap">
                        <ul>
                            <li class="active" data-tab="Weekdays">Weekdays(Mon-Fri)</li>
                            <li data-tab="Weekends">Weekends/Holidays</li>
                        </ul>
                        
                    </div>
                    <div class="room_pakage-sliderA">
                        <div data-tab="Weekdays" class="room_pakage-sliderA-wrap" style="display:block">
                             <asp:Repeater ID="RptrPackageData1" runat="server">
                            <ItemTemplate>
                                <div class="col_bx">
                                    <div class="card">
                                        <div class="top_con">
                                            <div class="heading">
                                                <h3>Weekdays (Mon to Fri)</h3>
                                                <h2><%#Eval("PackageTitle") %></h2>
                                                <div class="line"><img src="assets/icons/heading_line.png" alt="best water park" /></div>
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
                                                    <figure><img src="assets/icons/adult.gif" alt="nearest water park" /></figure>
                                                    <div class="info_pakg">
                                                        <h4>Adults <span>Rs. <%#Eval("AdultPrice") %>/head</span></h4>
                                                        <%# Convert.ToString(Eval("PackageAdultsPunchline1")) != "" ? "<p class='small'>"+Eval("PackageAdultsPunchline1")+"</p>":"" %>
                                                    </div>
                                                </div>
                                                <div class="col" id="PnlKids" runat="server" visible='<%# Convert.ToInt16(Eval("KidsPrice")) > 0 ? true:false %>'>
                                                    <figure><img src="assets/icons/kids.gif" alt="water park" /></figure>
                                                    <div class="info_pakg">
                                                        <h4>Kids <span>Rs. <%#Eval("KidsPrice") %>/head</span></h4>
                                                        <%# Convert.ToString(Eval("PackageKidsPunchline1")) != "" ? "<p class='small'>"+Eval("PackageKidsPunchline1")+"</p>":"" %>
                                                        <%# Convert.ToInt16(Eval("PackageKidsPunchline2")) > 0 ? "<p class='small' style='color:red;'>Kids(below "+Eval("PackageKidsPunchline2")+" inches of height) are complimentary</p>":"" %>
                                                    
                                                    </div>
                                                </div>                                         
                                                <div class="btm_btn">
                                                    <div class="dowtoscr" data-attr="tab_<%#Eval("PackageID") %>">Package Inclusions <img src="assets/icons/select-arr.png" alt="water adventure parks" /></div>
                                                    <div class="link_btn skyblue_btn"><a href="javascript:void(0);" class="model-open modelTyepCheck bind_package" data-type="Weekdays" data-model=".Popup_Book_ParkModel" data-Package='<%#Eval("PackageID") %>' data-name='<%#Eval("PackageTitle") %>' data-Timing='<%#Eval("PackageTimming") %>' data-Punchline='<%#Eval("PackagePunchline") %>' data-Kids='<%#Eval("KidsPrice") %>' data-Adult='<%#Eval("AdultPrice") %>' data-KidsTAX='<%#Eval("KidsPriceTaxs") %>' data-AdultTAX='<%#Eval("AdultPriceTaxs") %>' data-KidsPunchline1='<%#Eval("PackageKidsPunchline1") %>' data-KidsPunchline2='<%#Eval("PackageKidsPunchline2") %>' data-AdultsPunchline='<%#Eval("PackageAdultsPunchline1") %>'>Book Now</a></div>
                                                </div>
                                                <div class="terms_cond">
                                                    <a href="/terms-and-conditions#Package">Terms and conditions <img src="assets/images/pakages/right-red.png" alt="water park resort near me" /></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                        <div data-tab="Weekends" class="room_pakage-sliderA-wrap" style="display:none">
                             <asp:Repeater ID="RptrPackageData11" runat="server">
                            <ItemTemplate>
                                <div class="col_bx">
                                    <div class="card">
                                        <div class="top_con">
                                            <div class="heading">
                                                <h3>Weekends/Holidays</h3>
                                                <h2><%#Eval("PackageTitle") %></h2>
                                                <div class="line"><img src="assets/icons/heading_line.png" alt="water park near by me" /></div>
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
                                                                                        
                                                <div class="btm_btn">
                                                    <div class="dowtoscr" data-attr="tab_<%#Eval("PackageID") %>">Package Inclusions <img src="assets/icons/select-arr.png" alt="water park near me with price" /></div>
                                                    <div class="link_btn skyblue_btn"><a href="javascript:void(0);" class="model-open modelTyepCheck bind_package" data-type="Weekdays" data-model=".Popup_Book_ParkModel" data-Package='<%#Eval("PackageID") %>' data-name='<%#Eval("PackageTitle") %>' data-Timing='<%#Eval("PackageTimming") %>' data-Punchline='<%#Eval("PackagePunchline") %>' data-Kids='<%#Eval("KidsPrice") %>' data-Adult='<%#Eval("AdultPrice") %>' data-KidsTAX='<%#Eval("KidsPriceTaxs") %>' data-AdultTAX='<%#Eval("AdultPriceTaxs") %>' data-KidsPunchline1='<%#Eval("PackageKidsPunchline1") %>' data-KidsPunchline2='<%#Eval("PackageKidsPunchline2") %>' data-AdultsPunchline='<%#Eval("PackageAdultsPunchline1") %>'>Book Now</a></div>
                                                </div>
                                                <div class="terms_cond">
                                                    <a href="/terms-and-conditions#Package">Terms and conditions <img src="assets/images/pakages/right-red.png" alt="water theme park near me" /></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab_pak" id="PnlRoomPacakeg" runat="server" visible="false" data-attr="tab_2" style='display: block;'>
                <div class="room_pakage-slider owl-carousel">
                    <asp:Repeater ID="RptrRoomListingPackage" runat="server">
                        <ItemTemplate>
                            <div class="col_bx">
                                <div class="card">
                                    <div class="top_con">
                                        <div class="heading">
                                            <h2><%#Eval("RoomName")%></h2>
                                            <div class="line">
                                                <img src="assets/icons/heading_line.png" alt="water resort near me">
                                            </div>
                                        </div>
                                        <div class="right_aside">
                                            <h4>Rs.<%#Eval("RoomDefaultPrice")%></h4>
                                            <small>Plus Taxes (<%#Eval("RoomTaxes")%>%)</small>
                                            <span class="at_top">From</span>
                                        </div>
                                    </div>
                                    <div class="mid_con">
                                        <%# Convert.ToInt16(Eval("NoofChildren")) > 0 ? "<h6>"+Eval("NoofAdults")+" Adults ("+Eval("NoofChildren")+" Kid below "+Eval("KidsAgeParameter")+" years are complimentary)</h6>":"<h6>"+Eval("NoofAdults")+" Adults</h6>" %>
                                        <%# Convert.ToInt16(Eval("ExtraPersonPrice")) > 0 ? "<p class='small'>Extra Bed/Person charge - Rs."+Eval("ExtraPersonPrice")+" Plus Taxes ("+Eval("RoomTaxes")+"%)</p>":"" %>                                        
                                        <div class="pakage_pr">
                                            <figure><img src="/AapnoGharlmages/RoomImages/<%#Eval("RoomDefaultImage")%>" alt="<%#Eval("RoomNameAlias")%>" title="<%#Eval("RoomName")%>"/></figure>
                                            <div class="btm_btn">
                                                <div class="dowtoscr" data-attr="tab_<%#Eval("RoomID") %>">Package Inclusions <img src="assets/icons/select-arr.png" alt=""></div>
                                                <%# Convert.ToString(Eval("RoomOtherDescription")).ToString() != "" ? "<div class='link_btn green_btn '><a class='btn_packGTable' href='javascript:void(0);'>View Detail</a></div>":"" %>
                                                <div class="getroom_pacage" style="display:none;">
                                                    <%#Eval("RoomOtherDescription") %>
                                                </div>
                                                <div class="link_btn skyblue_btn">
                                                    <a href="/<%#Eval("RoomNameAlias")%>?StayPacakge=Stay">Book Now</a>
                                                </div>
                                            </div>
                                            <div class="terms_cond">
                                                <a href="/terms-and-conditions#Hotel" target="_blank">Terms and conditions <img src="assets/images/pakages/right-red.png" alt="water park resorts"></a>
                                            </div>
                                        </div>
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
<div class="section_tab">
    <div class="tab_sec active" data-attr="tab_1" style="display:block">
        <section id="PnlPackageInclusions" runat="server" visible="false">
            <div class="pakages_secB">
                <div class="container">
                    <div class="heading text-center"><h2>Package Inclusions</h2></div>
                    <div class="tab_pakage2wrap">
                        <asp:Repeater ID="RptrPackageData2" runat="server">
                            <ItemTemplate>
                                <div data-attr="tab_<%#Eval("PackageID") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display: none;'" %>>
                                    <div class="pakage_tab2">
                                        <ul>
                                            <asp:HiddenField ID="hdnPackageID" Value='<%#Eval("PackageID") %>' runat="server" Visible="false"/>
                                            <asp:Repeater ID="RptrPackageEntertainmentData" runat="server">
                                                <ItemTemplate>
                                                    <li <%# Container.ItemIndex == 0 ? "class='active'":"" %>><a data-attr="tab_<%#Eval("PackageID") %>_<%#Eval("EntertainmentID") %>"><%#Eval("EntertainmentName") %></a></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <li class="hide_somtime"><a data-attr='tab_<%#Eval("PackageID") %>_Delicious_Food'>Delicious Food</a></li>
                                            <%--<asp:Literal ID="ltrDeliciousFood" runat="server"></asp:Literal>--%>
                                        </ul>
                                    </div>
                                    <div class="pakage_content_tab2">
                                        <asp:Repeater ID="RptrPackageEntertainmentData1" runat="server">
                                            <ItemTemplate>
                                                <div class="tab_pak" data-attr="tab_<%#Eval("PackageID") %>_<%#Eval("EntertainmentID") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display: none;'" %>>
                                                    <asp:HiddenField ID="hdnEntertainmentID" Value='<%#Eval("EntertainmentID") %>' runat="server" Visible="false"/>
                                                    <div class="tab_pak-slider owl-carousel">
                                                        <asp:Repeater ID="RptrPackageEntertainmentActivitiesData" runat="server">
                                                            <ItemTemplate>
                                                                <div class="item">
                                                                    <figure><img src="/AapnoGharlmages/ActivityImage/<%# Eval("ActivityDefaultImage") %>" alt="<%# Eval("ActivityAlias") %>" title="<%# Eval("ActivityTitle") %>"/></figure>
                                                                    <div class="tab-inf"><p><%# Eval("ActivityTitle") %></p></div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--<div class="tab_pak" data-attr="tab_<%#Eval("PackageID") %>_Delicious_Food" style='display: none;'>
                                            <div class="tab_pak-slider owl-carousel">
                                                <asp:Repeater ID="RptrDeliciousFood1" runat="server">
                                                    <ItemTemplate>
                                                        <div class="item" <%# ((Convert.ToString(Eval("MealTitle")) == "Breakfast" && Convert.ToInt16(Eval("PackageID")) == 2) || (Convert.ToString(Eval("MealTitle")) == "Lunch" && Convert.ToInt16(Eval("PackageID")) == 2) || (Convert.ToString(Eval("MealTiming")).ToString().Contains("09:30 Am to 11:00 Am")  && Convert.ToInt16(Eval("PackageID")) == 2) == true) ? "style='display: none;'":"" %>>
                                                            <figure><img src="/AapnoGharlmages/MealImage/<%#Eval("MealDefaultImage") %>" alt="<%#Eval("MealAlias") %>" title="<%#Eval("MealTitle") %>" /></figure>
                                                            <div class="tab-inf"><p><%# Eval("MealTitle") %></p></div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </section>
        <section class="package_delicious_food" id="PnlPackageDeliciousFood" runat="server" visible="false" style="display:none">
            <div class="amusement_secC">
                <div class="container">
                    <div class="heading text-center">
                        <h3>Delicious Food</h3>
                        <img src="assets/icons/heading_line_white.png" alt="water park resorts" />
                    </div>
                    <div class="tab_pakage2wrap">
                    <asp:Repeater ID="RptrPackageData3" runat="server">
                        <ItemTemplate>
                            <div data-attr="tab_<%#Eval("PackageID") %>_Delicious_Food" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display: none;'" %>>
                                <div class="flex">
                                    <div class="colA">
                                        <ul class="food_nav">
                                            <asp:HiddenField ID="hdnPackageID" Value='<%#Eval("PackageID") %>' runat="server" Visible="false"/>
                                            <asp:Repeater ID="RptrDeliciousFood" runat="server">
                                                <ItemTemplate>
                                                    <li <%# Container.ItemIndex == 0 ? "class='active'":"" %>>
                                                        <a href="Javascript:void(0)" data-food="food<%#Eval("EntertainmentMealID") %>">
                                                            <p><%#Eval("MealTitle") %></p>
                                                            <span><%#Eval("MealTiming") %></span>
                                                        </a>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                    <div class="colB">
                                        <div class="food_wrapper">
                                            <asp:Repeater ID="RptrDeliciousFood1" runat="server">
                                                <ItemTemplate>
                                                    <div class="food_tab" data-food="food<%#Eval("EntertainmentMealID") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display:none;'" %>>
                                                        <div class="content">
                                                            <figure><img src="/AapnoGharlmages/MealImage/<%#Eval("MealDefaultImage") %>" alt="<%#Eval("MealAlias") %>" title="<%#Eval("MealTitle") %>" /></figure>
                                                            <div class="food_info">
                                                                <div class="title">
                                                                    <h4><%#Eval("MealTitle") %></h4>
                                                                    <p><%#Eval("MealTiming") %></p>
                                                                    <asp:HiddenField ID="hndEntertainmentMealID" Value='<%#Eval("EntertainmentMealID")%>' Visible="false" runat="server" />
                                                                </div>
                                                                <ul>
                                                                    <asp:Repeater ID="RptrDeliciousFoodItems" runat="server">
                                                                        <ItemTemplate>
                                                                            <li><%#Eval("MealItemTitle")%></li>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="tab_sec active" data-attr="tab_2" style="display:block">
        <section id="PnlPackageInclusionsRoom" runat="server" visible="false">
            <div class="pakages_secB">
                <div class="container">
                    <div class="heading text-center"><h2>Package Inclusions</h2></div>
                        <div class="tab_pakage2wrap">
                            <asp:Repeater ID="RptrRoomListingPackage1" runat="server">
                                <ItemTemplate>
                                    <div data-attr="tab_<%#Eval("RoomID") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display: none;'" %>>
                                        <div class="pakage_tab2">
                                        <ul>
                                            <asp:HiddenField ID="hdnPackageID" Value='<%#Eval("RoomID") %>' runat="server" Visible="false"/>
                                            <asp:Repeater ID="RptrPackageEntertainmentData" runat="server">
                                                <ItemTemplate>
                                                    <li <%# Container.ItemIndex == 0 ? "class='active'":"" %>><a data-attr="tab_<%#Eval("RoomID") %>_<%#Eval("EntertainmentID") %>"><%#Eval("EntertainmentName") %></a></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <li class="hide_somtime"><a data-attr='tab_room_<%#Eval("RoomID") %>_Delicious_Food'>Delicious Food</a></li>
                                        </ul>
                                    </div>
                                    <div class="pakage_content_tab2">
                                        <asp:Repeater ID="RptrPackageEntertainmentData1" runat="server">
                                            <ItemTemplate>
                                                <div class="tab_pak" data-attr="tab_<%#Eval("RoomID") %>_<%#Eval("EntertainmentID") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display: none;'" %>>
                                                    <asp:HiddenField ID="hdnEntertainmentID" Value='<%#Eval("EntertainmentID") %>' runat="server" Visible="false"/>
                                                    <div class="tab_pak-slider owl-carousel">
                                                        <asp:Repeater ID="RptrPackageEntertainmentActivitiesData" runat="server">
                                                            <ItemTemplate>
                                                                <div class="item">
                                                                    <figure><img src="/AapnoGharlmages/ActivityImage/<%# Eval("ActivityDefaultImage") %>" alt="<%# Eval("ActivityAlias") %>" title="<%# Eval("ActivityTitle") %>"/></figure>
                                                                    <div class="tab-inf"><p><%# Eval("ActivityTitle") %></p></div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </section>
        <section id="PnlPackageRoomDeliciousFood" class="package_delicious_food" runat="server" visible="false" style="display:none">
            <div class="amusement_secC">
                <div class="container">
                    <div class="heading text-center">
                        <h3>Delicious Food</h3>
                        <img src="assets/icons/heading_line_white.png" alt="best water park near me" />
                    </div>
                    <div class="tab_pakage2wrap">
                    <asp:Repeater ID="RptrRoomListingPackage2" runat="server">
                        <ItemTemplate>
                            <div data-attr="tab_room_<%#Eval("RoomID") %>_Delicious_Food" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display: none;'" %>>
                                <div class="flex">
                                    <div class="colA">
                                        <ul class="food_nav">
                                            <asp:HiddenField ID="hdnRoomID" Value='<%#Eval("RoomID") %>' runat="server" Visible="false"/>
                                            <asp:Repeater ID="RptrDeliciousFood" runat="server">
                                                <ItemTemplate>
                                                    <li <%# Container.ItemIndex == 0 ? "class='active'":"" %>>
                                                        <a href="Javascript:void(0)" data-food="food<%#Eval("EntertainmentMealID") %>">
                                                            <p><%#Eval("MealTitle") %></p>
                                                            <span><%#Eval("MealTiming") %></span>
                                                        </a>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                    <div class="colB">
                                        <div class="food_wrapper">
                                            <asp:Repeater ID="RptrDeliciousFood1" runat="server">
                                                <ItemTemplate>
                                                    <div class="food_tab" data-food="food<%#Eval("EntertainmentMealID") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display:none;'" %>>
                                                        <div class="content">
                                                            <figure><img src="/AapnoGharlmages/MealImage/<%#Eval("MealDefaultImage") %>" alt="<%#Eval("MealAlias") %>" title="<%#Eval("MealTitle") %>" /></figure>
                                                            <div class="food_info">
                                                                <div class="title">
                                                                    <h4><%#Eval("MealTitle") %></h4>
                                                                    <p><%#Eval("MealTiming") %></p>
                                                                    <asp:HiddenField ID="hndEntertainmentMealID" Value='<%#Eval("EntertainmentMealID")%>' Visible="false" runat="server" />
                                                                </div>
                                                                <ul>
                                                                    <asp:Repeater ID="RptrDeliciousFoodItems" runat="server">
                                                                        <ItemTemplate>
                                                                            <li><%#Eval("MealItemTitle")%></li>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    </div>
                </div>
            </div>
        </section>
    </div>
</div>
<div class="model ModelPopup Model-FamilyStayPacke tabModelStayPackeg">
    <div class="model-body">
        <div class="close_model"><img src="assets/icons/close.png" alt="nearest adventure park" /></div>
        <div class="model-table">
            <div class="table">
                <div class="tablhead">
                    <h2>Family Stay Packages for 1 Night</h2>
                    <p>Food & Stay Itinerary</p>
                </div>
                <div id="showroom_pacage"></div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(function () {
        $('li.hide_somtime a').on('click', function (e) {
            e.preventDefault();
            var secTarget = $(this).attr('data-attr');
            // if(secTarget == "tab_2_Delicious_Food"){
            //     $('section#ContentPlaceHolder1_PnlPackageDeliciousFood').show();
            //     $('section#ContentPlaceHolder1_PnlPackageRoomDeliciousFood').hide();
            // }
            // else if(secTarget == "tab_room_2_Delicious_Food"){
            //     $('section#ContentPlaceHolder1_PnlPackageRoomDeliciousFood').show();
            //     $('section#ContentPlaceHolder1_PnlPackageDeliciousFood').hide();
            // };
            $('.package_delicious_food').show();
            setTimeout(function () {
                $('html, body').animate({
                    scrollTop: ($('.tab_sec.active .package_delicious_food').offset().top - $('header').height())
                }, 1000);
            }, 500);
            $('.amusement_secC .tab_pakage2wrap > div').each(function(){
                if($(this).attr('data-attr') == secTarget){
                    $(this).show();
                }
                else{
                    $(this).hide()
                }
            })
        })

        $('.pakage_tab-wrap ul li').click(function () {
            $(this).addClass('active').siblings().removeClass('active');
            var datawrap = $(this).attr('data-tab');
            $(".room_pakage-sliderA .room_pakage-sliderA-wrap[data-tab='"+ datawrap +"']").show().siblings().hide();
            })

        $('.pakage_tab2 ul li:not(.hide_somtime) a').on('click', function (e) {
            e.preventDefault();
            $('.package_delicious_food').hide();
            $('section#ContentPlaceHolder1_PnlPackageDeliciousFood,section#ContentPlaceHolder1_PnlPackageRoomDeliciousFood').hide();
            // alert('sss')
            // $('html, body').animate({
            //     scrollTop: ($('.pakages_secB').offset().top - $('header').height())
            // }, 1000);
        })

        $('.pakage_pr .btm_btn .dowtoscr').on('click', function (e) {
            $('.package_delicious_food').hide();
        })

        $('.active_tickets_packages').addClass('active_header');

        $('a.btn_packGTable').on('click', function (e) {
            e.preventDefault();
            $this = $(this).parent('.link_btn');
            $('.tabModelStayPackeg').addClass('is-open');
            $('.overlay').addClass('overlay_active');
            $('#showroom_pacage').html("");
            $('#showroom_pacage').html($this.siblings('.getroom_pacage').html());
        })

        $('.active_tickets_packages').addClass('active_header');

        $('.pakage_tab ul li a').on('click', function (e) {
            $('.room_pakage-slider').trigger('destroy.owl.carousel');
            roompakageslider();
            $('.tab_pak-slider').trigger('destroy.owl.carousel');
            var tab = $(this).attr('data-attr');
            $('.pakage_content_tab .tab_pak[data-attr="' + tab + '"]').fadeIn(400).siblings().hide();
            $('.section_tab .tab_sec[data-attr="' + tab + '"]').fadeIn(400).siblings().hide();
            $('.section_tab .tab_sec[data-attr="' + tab + '"]').addClass('active').siblings().removeClass('active');
            setTimeout(function () {
                $('.pakage_tab2 ul li:first-child a').trigger('click');
                $('.food_nav li:first-child').trigger('click');
            }, 100)
            $(this).parent('li').addClass('active').siblings().removeClass('active')

            e.preventDefault();
        });


        $('.pakage_tab2 ul li a').on('click', function (e) {
            $('.tab_pak-slider').trigger('destroy.owl.carousel');
            var tab = $(this).attr('data-attr');
            $('.pakage_content_tab2 .tab_pak[data-attr="' + tab + '"]').fadeIn(400).siblings().hide();
            $(this).parent('li').addClass('active').siblings().removeClass('active');
            tabslider()
            e.preventDefault();
        });

        var headerheight = $("header").height();
        $('.dowtoscr').click(function () {
            var dattr = $(this).attr('data-attr');
            $('.section_tab .tab_sec.active .pakages_secB .tab_pakage2wrap div[data-attr="' + dattr + '"]').fadeIn(400).siblings().hide();
            $('.section_tab .tab_sec.active .amusement_secC .tab_pakage2wrap div[data-attr="' + dattr + '"]').fadeIn(400).siblings().hide();
            $('html, body').animate({
                scrollTop: $(".tab_sec.active .pakages_secB").offset().top - headerheight
            }, 1000);
        });

        $(function () {
            tabslider();
        });

        function tabslider() {
            $('.tab_pak-slider').owlCarousel({
                items: 5,
                loop: true,
                responsiveClass: true,
                margin: 10,
                nav: true,
                navText: ['<img src="assets/icons/left_black.png" />', '<img src="assets/icons/right_black.png" />'],
                rewind: true,
                dots: false,
                smartSpeed: 1500,
                responsive: {
                    0: {
                        items: 1.2,
                        nav: false
                    },
                    600: {
                        items: 3,
                    },
                    1000: {
                        items: 5,
                    }
                }
            });
        }
        tabslider();

        function roompakageslider() {

            $('.room_pakage-slider').owlCarousel({
                items: 2,
                loop: true,
                slideBy: 2,
                responsiveClass: true,
                margin: 100,
                nav: true,
                navText: ['<img src="assets/icons/left_black.png" />', '<img src="assets/icons/right_black.png" />'],
                rewind: true,
                dots: false,
                smartSpeed: 1000,
                responsive: {
                    0: {
                        items: 1.2,
                        nav: false,
                        margin: 10
                    },
                    600: {
                        items: 2,
                        margin: 10
                    },
                    1000: {
                        items: 2,
                    }
                }
            });
        }
        roompakageslider();
        //tab
        $('.food_nav li a').on('click', function (e) {
            $(this).parent().addClass('active').siblings().removeClass('active');
            var datafood = $(this).attr('data-food');
            $('.food_wrapper .food_tab[data-food=' + datafood + ']').fadeIn(400).siblings().hide();
            e.preventDefault();
        });

        //$('.room_pakage-sliderA').owlCarousel({
        //    items: 2,
        //    loop: true,
        //    slideBy: 2,
        //    responsiveClass: true,
        //    margin: 100,
        //    nav: true,
        //    navText: ['<img src="assets/icons/left_black.png" />', '<img src="assets/icons/right_black.png" />'],
        //    rewind: true,
        //    dots: false,
        //    smartSpeed: 1000,
        //    responsive: {
        //        0: {
        //            items: 1.2,
        //            nav: false,
        //            margin: 10
        //        },
        //        600: {
        //            items: 2,
        //            margin: 10
        //        },
        //        1000: {
        //            items: 2,
        //        }
        //    }
        //});
    });
</script>
</asp:Content>
