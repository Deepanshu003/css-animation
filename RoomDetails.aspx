<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="RoomDetails.aspx.cs" Inherits="AapnoGharWeb.RoomDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="banner room-listingBanner roomDetailsBanner">
    <div class="bg">
        <asp:Literal ID="ltrBanner" runat="server"></asp:Literal>
        <div class="banner-content">
            <h1><asp:Literal ID="ltrRoomName" runat="server"></asp:Literal></h1>
            <asp:Literal ID="ltrRoomSmallDescription" runat="server"></asp:Literal>
            <asp:Literal ID="ltrRoom360View" runat="server"></asp:Literal>
        </div>
    </div>
</div>
<div class="roomDetails-SecA">
    <div class="container-fluid">
        <div class="flex">
            <div class="col" id="PnlImageOrGallery" runat="server" visible="false">
                <div class="owl-carousel slideRommD-A cutom-dots">
                    <asp:Repeater ID="RptrGalleryData1" runat="server">
                        <ItemTemplate>
                            <figure class="shadeBTT"><img src="/AapnoGharlmages/GalleryImage/<%# Eval("SmallImg") %>" alt="water park ticket price" /></figure>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="col">
                <div class="roomDetailsIntel">
                    <div class="desc" id="pnlRoomDescription" runat="server" visible="false">
                        <asp:Literal ID="ltrRoomDescription" runat="server"></asp:Literal>
                    </div>
                    <div class="roomDetailsIntel1" id="PnlPrice" runat="server" visible="false">
                        <div class="roomDIntel1Wrap">
                            <div class="price_wrap">
                                <div class="price redpricejs">Rs. <asp:Literal ID="ltrPrice" runat="server"></asp:Literal></div>
                                <div class="pn redgstpricejs">Per Night + GST</div>
                            </div>
                            <div class="rdUiDropdown stay_package_Hide">
                                <div class="rdUiDropdownWrap">
                                    <input type="hidden" class="input_wBrakAttprice" /> <input type="hidden" class="input_wBrakAttname" />
                                    <div class="rdUiDropdownSelc jsrdUiDropdownSelc">
                                        <div class="text jsrdUiDropdowntext"><asp:Literal ID="ltrTypeName" runat="server"></asp:Literal></div>
                                        <div class="icon"><img src="assets/icons/donw.png" alt="nearby water park" /></div>
                                    </div>
                                    <div class="rdUiDropdrodown jsrdUiDropdrodown">
                                        <ul>
                                            <asp:Repeater ID="RptrRoomPriceData" runat="server">
                                                <ItemTemplate>
                                                    <li data-rs="<%# Eval("RoomDefaultPrice") %>" data-name="<%# Eval("TypeName") %>" data-roomprice="<%# Eval("RoomDefaultPrice") %>" data-roompricetax="<%# Eval("RoomDefaultPriceTaxs") %>" data-exroomprice="<%# Eval("ExtraPersonPrice") %>" data-exroompricetax="<%# Eval("ExtraPersonPriceTaxs") %>" data-gst="<%# Eval("RoomTaxes") %>" class="Chk_Price <%# Convert.ToString(Eval("TypeName")) == "Room with Breakfast, Lunch, Dinner & Water & Amusement Park Ticket" ? "stay_package":"" %> <%# Container.ItemIndex == 0 ? "ChcekChnagesClass":"" %>">Reserve <%# Eval("TypeName") %></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="rdUioccup"><p>Occupancy: 2<asp:Literal ID="ltrTotalGuest" Visible="false" runat="server"></asp:Literal> Adults</p></div>
                        </div>
                    </div>
                    <div class="roomDetailsIntel2" id="PnlPrice1" runat="server" visible="false">
                        <div class="form-checAvali">
                            <div class="flex">
                                <div class="colChecA">
                                    <div class="form-group">
                                        <input type="text" class="calinput checkin_hotel" id="txtchecin" runat="server"  readonly/>
                                        <div class="icon"><img src="assets/icons/calendar.png" alt="amusement water park" /></div>
                                        <div class="calLabel">Check In</div>
                                        <div class="dateSChecin inputCheckInLabel">Select Date</div>
                                    </div>
                                </div>
                                <div class="colChecA line">
                                    <div class="form-group">
                                        <input type="text" class="calinput checkout_hotel" id="txtchecout" runat="server"  readonly/>
                                        <div class="icon"><img src="assets/icons/calendar.png" alt="best amusement park near me" /></div>
                                        <div class="calLabel">Check Out</div>
                                        <div class="dateSChecin inputCheckOutLabel">Select Date</div>
                                    </div>
                                </div>
                                <div class="colChecB fieldSelectRoom" style="display: none;">
                                    <div class="field-selectRoom-box">
                                        <select name="" class="select-roomDropdown bind_drop_dwon_by_checkindate"></select>
                                    </div>
                                </div>
                                <div class="colChecB btnBoxAvialble">
                                    <div class="btn_avali">
                                        <a href="javascript:void(0)" class="btn Check_Availability">Check Availability</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Literal ID="ltrRoomBookingBySalesTeam" runat="server"></asp:Literal>
                    <div class="no_room_found" style="display:none;"><p><b>No Availability</b><br/>We were unable find a room(s) to match your search criteria. Please change your search,or call us for assistance or, if your dates are flexible, try the Room Availability Calendar. Please email us at <a href='mailto:info@aapnoghar.com'>info@aapnoghar.com</a> incase of non-availability of rooms. Call us at <a href='tel:+917666779997'>+91 7666779997</a>.</p></div>
                    <div class="list_roomAddon" style="display:none;">
                        <div class="important_data" style="display:none;">
                            <div class="list">
                                <div class="flex form">
                                    <div class="col-A">
                                        <div class="SNRomm roomsAdded No_Rooms_SHow1" data-totalnoofadult='0' data-totalnoofchild='0' data-kidsoneage='0' data-kidstwoage='0'>Room 1</div>
                                    </div>
                                    <div class="col-B col">
                                        <div class="form-group">
                                            <input type="hidden" data-input=".noroom" class="numRoom inputAdult_1" value="1" />
                                            <select name="" class="form-control dropdown_adult bind_drop_drwon_Adult" data-input=".inputAdult_1" id=""></select>
                                        </div>
                                    </div>
                                    <div class="col-B col kid_hide" style="display:none;">
                                        <div class="form-group">
                                            <input type="hidden" data-input=".noroom" class="numRoom inputChild_1" value="0" />
                                            <select name="" class="form-control dropdown_adult bind_drop_drwon_Child" data-input=".inputAdult_1" id=""></select>
                                        </div>
                                    </div>
                                    <div class="col-B kid_Age_hide" style="display:none;">
                                        <div class="form-group">
                                            <select name="" class="form-control Bind_Kids" id="" data-attkids="Kids 1">
                                                <option value="0">< 1 Year</option>
                                                <option value="1">1 Year</option>
                                                <option value="2">2 Years</option>
                                                <option value="3">3 Years</option>
                                                <option value="4">4 Years</option>
                                                <option value="5">5 Years</option>
                                                <option value="6">6 Years</option>
                                                <option value="7">7 Years</option>
                                                <option value="8">8 Years</option>
                                                <option value="9">9 Years</option>
                                                <option value="10">10 Years</option>
                                                <option value="11">11 Years</option>
                                                <option value="12">12 Years</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-B kid_Age_hide" style="display:none;">
                                        <div class="form-group">
                                            <select name="" class="form-control Bind_Kids" id="">
                                                <option value="0">< 1 Year</option>
                                                <option value="1">1 Year</option>
                                                <option value="2">2 Years</option>
                                                <option value="3">3 Years</option>
                                                <option value="4">4 Years</option>
                                                <option value="5">5 Years</option>
                                                <option value="6">6 Years</option>
                                                <option value="7">7 Years</option>
                                                <option value="8">8 Years</option>
                                                <option value="9">9 Years</option>
                                                <option value="10">10 Years</option>
                                                <option value="11">11 Years</option>
                                                <option value="12">12 Years</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="listRooms No_listRooms_Show"></div>
                    </div>
                    <div class="roomDetailsIntel2 book_now_room" style="display:none;">
                        <div class="colChecB">
                            <div class="btn_avali">
                                <a href="javascript:void(0)" class="btn add_to_cart">Book Now</a>
                            </div>
                        </div>
                    </div>
                    <asp:Literal ID="ltrRoomOtherDescription1" runat="server"></asp:Literal>
                    <div class="roomDetailsIntel3" id="PnlAllDetaisl" runat="server">
                        <div class="roomDetAmini">
                            <div class="aminTab jsAminTab">
                                <ul>
                                    <asp:Literal ID="ltrAmenitiesData" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltrRoomCancellationPolicy1" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltrRoomResortPolicy1" runat="server"></asp:Literal>
                                </ul>
                            </div>
                            <div class="roomAminLuist">
                                <div class="lisTab">
                                    <div class="tab" data-tab="tab_Amenities" id="PnlAmenitiesData" runat="server" visible="false">
                                        <div class="owl-carousel nav-center aminSLideB animatslidCs">
                                            <asp:Repeater ID="RptrAmenitiesData" runat="server">
                                                <ItemTemplate>
                                                    <div class="item">
                                                        <div class="icon"><img src="/AapnoGharlmages/AmenitiesImage/<%#Eval("SmallImg")%>" alt="<%#Eval("AmenitiesTitleURL")%>" title="<%#Eval("AmenitiesTitle")%>"/></div>
                                                        <p><%#Eval("AmenitiesTitle")%></p>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="tab" data-tab="tab_Cancellation" id="PnlRoomCancellationPolicy" runat="server" visible="false">
                                        <div class="content-wrap">
                                            <div class="content">
                                                <p>Booking is Non-Refundable.</p>
                                                <asp:Literal ID="ltrRoomCancellationPolicy" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab" data-tab="tab_Resort_policy" id="PnlRoomResortPolicy" runat="server" visible="false">
                                        <div class="content-wrap">
                                            <div class="content">
                                                <asp:Literal ID="ltrRoomResortPolicy" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="roomDetails-SecB" id="PnlRelatedRomData" runat="server" visible="false">
    <div class="container-fluid">
        <div class="heading text-center">
            <h2>Rooms & Suits</h2>
            <p>The guests can choose from a variety of room categories like Presidential Suite, Suite, Luxury, Deluxe.</p>
        </div>
        <div class="owl-carousel SlideReletedRom nav-center">
            <asp:Repeater ID="RptrRelatedRomData" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <figure><img src="/AapnoGharlmages/RoomImages/<%#Eval("RoomDefaultImage")%>" alt="<%#Eval("RoomNameAlias")%>" title="<%#Eval("RoomName")%>"/></figure>
                        <div class="item-content">
                            <div class="content">
                                <div class="room-name"><%#Eval("RoomName")%></div>
                                <%# Convert.ToString(Eval("RoomSmallDescription")) != "" ? "<div class='sortDes'>"+Eval("RoomSmallDescription")+"</div>":"" %>
                                <div class="amminit">
                                    <ul>
                                        <%# Convert.ToString(Eval("RoomViewSide")) != "" ? "<li> <div class='icon'><img src='assets/images/room/beach.png' alt='amusement park' /></div> <div class='text'>"+Eval("RoomViewSide")+"</div> </li>":"" %>
                                        <%# Convert.ToString(Eval("RoomBedType")) != "" ? "<li> <div class='icon'><img src='assets/images/room/bed.png' alt='amusement park near me' /></div> <div class='text'>"+Eval("RoomBedType")+"</div> </li>":"" %>
                                        <li>
                                            <div class="icon"><img src="assets/images/room/maximumOccoumpany.png" alt="near me water park" /></div>
                                            <div class="text"><%# Convert.ToInt16(Eval("NoofChildren")) > 0 ? ""+Eval("NoofAdults")+" Adults and "+Eval("NoofChildren")+" Children Or "+(Convert.ToInt16(Eval("NoofChildren")) + Convert.ToInt16(Eval("NoofAdults")))+" Adults":""+Eval("NoofAdults")+" Adults" %></div>
                                        </li>
                                        <%# Convert.ToString(Eval("RoomSize")) != "" ? "<li> <div class='icon'><img src='assets/images/room/scale-up.png' alt='water theme park' /></div> <div class='text'>Size : "+Eval("RoomSize")+"</div> </li>":"" %>
                                        <%# Convert.ToString(Eval("ComplimentaryWiFiDevices")) != "" ? "<li> <div class='icon'><img src='assets/images/room/wifi.png' alt='best water park' /></div> <div class='text'>"+Eval("ComplimentaryWiFiDevices")+"</div> </li>":"" %>
                                    </ul>
                                </div>
                                <div class="priceWrap">
                                    <div class="price" <%# (Convert.ToInt16(Eval("DiscountedPrice")) > 0) ? "":" style='display:none;'" %>>Rs. <%#Eval("DiscountedPrice")%></div>
                                    <div class="pn" <%# (Convert.ToInt16(Eval("DiscountedPrice")) > 0) ? "":" style='display:none;'" %>>per night</div>
                                </div>
                                <div class="link"><a href="/<%#Eval("RoomNameAlias")%>">View Details</a></div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
<div class="roomDetails-SecC">
    <div class="heading text-center"><h2>Location Map</h2></div>
    <div class="map" id="map_2"></div>
</div>
<div class="model ModelPopup Model-FamilyStayPacke" id="PnlRoomOtherDescription" runat="server">
    <div class="model-body">
        <div class="close_model"><img src="assets/icons/close.png" alt="water fun park near me" /></div>
        <div class="model-table">
            <div class="table">
                <div class="tablhead">
                    <h2>Family Stay Packages for 1 Night</h2>
                    <p>Food & Stay Itinerary</p>
                </div>
                <div class="tab_wraper">
                    <asp:Literal ID="ltrRoomOtherDescription" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</div>
<input type="hidden" class="inputlat" value="">
<input type="hidden" class="inputlon" value="">
<asp:HiddenField ID="hdnSerachRoomID" Value="0" runat="server" />
<asp:HiddenField ID="hdnRoomID" runat="server" />
<asp:HiddenField ID="hdnRoomName" runat="server" />
<asp:HiddenField ID="hdnRoomURL" runat="server" />
<asp:HiddenField ID="hdnRoomType" runat="server" />
<asp:HiddenField ID="hdnRoomImage" runat="server" />
<asp:HiddenField ID="hdnRoomSmallDescription" runat="server" />
<asp:HiddenField ID="hdnNumbersOfRooms" runat="server" />
<asp:HiddenField ID="hdnNumbersOfAdulst" runat="server" Value="0"/>
<asp:HiddenField ID="hdnNumbersOfChild" runat="server" Value="0"/>
<asp:HiddenField ID="hdnKidsAgeParameter" runat="server" Value="0"/>
<asp:HiddenField ID="hdnKidsAgeExtraprice" runat="server" Value="0"/>
<asp:HiddenField ID="hdnRoomPrice" runat="server" Value="0"/>
<asp:HiddenField ID="hdnRoomPriceTax" runat="server" Value="0"/> 
<asp:HiddenField ID="hdnTotalRoomPrice" runat="server" Value="0"/> 
<asp:HiddenField ID="hdnExtraBedCharges" runat="server" Value="0"/>
<asp:HiddenField ID="hdnExtraBedTax" runat="server" Value="0"/>
<asp:HiddenField ID="hdnTotalExtraBedCharges" runat="server" Value="0"/>
<asp:HiddenField ID="hdnToDate" runat="server" />
<asp:HiddenField ID="hdnEndDate" runat="server" />
<asp:HiddenField ID="hdnTotalRoomsAvailable" runat="server" Value="0"/>
<asp:HiddenField ID="hdnTotalNight" runat="server" Value="0"/>
<asp:HiddenField ID="hdnCart" runat="server" Value="0"/>
<asp:HiddenField ID="hdnStayPacakge" runat="server" Value=""/>
<script type="text/javascript">
    $(function () {
        var date = new Date();
        var day = date.getDate();
        $('.active_room').addClass('active_header');
        $('.jsAminTab ul li').on('click', function () {
            var tab = $(this).attr('data-tab');
            $(this).addClass('active').siblings().removeClass('active');
            $('.roomAminLuist .tab').each(function () {
                if ($(this).attr('data-tab') == tab) {
                    $(this).slideDown();
                }
                else {
                    $(this).slideUp();
                }
            });
        });

        $('.SlideReletedRom').owlCarousel({
            items: 1,
            margin: 30,
            autoplay: false,
            nav: true,
            dots: false,
            loop: true,
            autoplayTimeout: 3000,
            navText: ['<img src="assets/icons/left_black.png" />', '<img src="assets/icons/right_black.png" />'],
            responsive: {
                0: {
                    items: 1.2,
                    nav: false,
                    margin: 10,
                },
                675: {
                    items: 3,
                }
            }
        });

        $('.aminSLideB').owlCarousel({
            items: 1,
            margin: 0,
            autoplay: false,
            nav: true,
            dots: false,
            loop: true,
            autoplayTimeout: 3000,
            responsive: {
                0: {
                    items: 2,
                    navText: ['<img src="assets/icons/nextBl.png" />', '<img src="assets/icons/nextBr.png" />'],
                },
                420: {
                    items: 3,
                    navText: ['<img src="assets/icons/nextBl.png" />', '<img src="assets/icons/nextBr.png" />'],
                },
                675: {
                    items: 4,
                    navText: ['<img src="assets/icons/nextBl.png" />', '<img src="assets/icons/nextBr.png" />'],
                }
            }
        });

        $('.slideRommD-A').owlCarousel({
            items: 1,
            margin: 0,
            autoplay: true,
            nav: false,
            dots: true,
            loop: true,
            autoplayTimeout: 3000,
            responsive: {
                0: {
                    items: 1
                },
                675: {
                    items: 1
                }
            }
        });

        $(".checkin_hotel").datepicker({
            minDate: 0,
            maxDate: "+3M -" + day + "D",
            firstDay: 0,
            dateFormat: 'mm-dd-yy',
            numberOfMonths: 1,
            onClose: function (selectedDate) {
                $('#ContentPlaceHolder1_hdnToDate').val(selectedDate);
                $('#ContentPlaceHolder1_txtchecin').val(selectedDate);
                if ($(this).val() != "") {
                    $(this).parent('.form-group').addClass('valid');
                    $('.inputCheckInLabel').text(selectedDate);
                }
                else {
                    $(this).parent('.form-group').removeClass('valid');
                    $('.inputCheckInLabel').text("Select Date");
                }
                var minDate = $(this).datepicker('getDate');
                var newMin = new Date(minDate.setDate(minDate.getDate() + 1));
                $(".checkout_hotel").datepicker("option", "minDate", newMin);
            }
        });

        $(".checkout_hotel").datepicker({
            minDate: 0,
            maxDate: "+3M -" + day + "D",
            minDate: '+2d',
            dateFormat: 'mm-dd-yy',
            numberOfMonths: 1,
            onClose: function (selectedDate) {
                if ($(this).val() != "") {
                    $(this).parent('.form-group').addClass('valid');
                    $('.inputCheckOutLabel').text(selectedDate);
                }
                else {
                    $(this).parent('.form-group').removeClass('valid');
                    $('.inputCheckOutLabel').text("Select Date")
                }
                $('#ContentPlaceHolder1_hdnEndDate').val(selectedDate);
                $('#ContentPlaceHolder1_txtchecout').val(selectedDate);
                if ($('#ContentPlaceHolder1_txtchecin').val() != "" && $('#ContentPlaceHolder1_txtchecout').val() != "") {
                    CheckNumbersOfRoomAvailable($('#ContentPlaceHolder1_hdnRoomID').val(), $('#ContentPlaceHolder1_txtchecin').val(), $('#ContentPlaceHolder1_txtchecout').val());
                }
            }
        });

        function checkDateSelected() {
            if ($(".checkout_hotel").val() !== "" && $(".checkin_hotel").val() !== "") {
                $('.fieldSelectRoom').show();
                $('.btnBoxAvialble').hide();
            }
            else {
                $('.fieldSelectRoom').hide();
                $('.btnBoxAvialble').show();
            }
        }

        $('.jsrdUiDropdownSelc').on('click', function () {
            $('.rdUiDropdrodown').slideToggle()
        });

        $('.jsrdUiDropdrodown ul li').on('click', function () {
            $('.rdUiDropdrodown').slideUp();
            var rs = $(this).attr('data-rs');
            var text = $(this).attr('data-name');
            var Price = $(this).attr('data-roomprice');
            var PriceTax = $(this).attr('data-roompricetax');
            var ExPrice = $(this).attr('data-exroomprice');
            var ExPriceTax = $(this).attr('data-exroompricetax');
            var GST = $(this).attr('data-gst');
            $('.input_wBrakAttprice').val(rs);
            $('.input_wBrakAttname').text(text);
            $('.jsrdUiDropdowntext').text(text);
            $('.redpricejs').text("Rs. " + rs);
            $('.redgstpricejs').text("Per Night + " + GST + "% GST");
            $('#ContentPlaceHolder1_hdnRoomType').val(text);
            $('#ContentPlaceHolder1_hdnRoomPrice').val(Price);
            $('#ContentPlaceHolder1_hdnRoomPriceTax').val(PriceTax);
            $('#ContentPlaceHolder1_hdnTotalRoomPrice').val((parseInt(Price) + parseInt(PriceTax)));
            $('#ContentPlaceHolder1_hdnExtraBedCharges').val(ExPrice);
            $('#ContentPlaceHolder1_hdnExtraBedTax').val(ExPriceTax);
            $('#ContentPlaceHolder1_hdnTotalExtraBedCharges').val((parseInt(ExPrice) + parseInt(ExPriceTax)));
        });

        $('body').click(function (e) {
            var catFilterCont = $(".jsrdUiDropdownSelc");
            if (!catFilterCont.is(e.target) && catFilterCont.has(e.target).length === 0) {
                $('.rdUiDropdrodown').slideUp();
            }
        });
    });
</script>
<script type="text/javascript">
    //0. Room Add To cart Function
    var RoomSmallDescription = $('#ContentPlaceHolder1_hdnRoomSmallDescription').val();
    var RoomTotalRooms = $('#ContentPlaceHolder1_hdnNumbersOfRooms').val();
    var RoomAdultAllowed = $('#ContentPlaceHolder1_hdnNumbersOfAdulst').val();
    var RoomKidsAllowed = $('#ContentPlaceHolder1_hdnNumbersOfChild').val();
    var RoomKidsAge = $('#ContentPlaceHolder1_hdnKidsAgeParameter').val();
    var RoomKidsAgePrice = $('#ContentPlaceHolder1_hdnKidsAgeExtraprice').val();
    var TotalNoght = $('#ContentPlaceHolder1_hdnTotalNight').val();
    $(document).ready(function () {

        if ($('#ContentPlaceHolder1_hdnStayPacakge').val() != "") {
            if ($('.stay_package').length > 0) {
                $('.Chk_Price').removeClass('ChcekChnagesClass');
                $('.stay_package').addClass('ChcekChnagesClass');
                $('.stay_package_Hide').hide();
            }
        }

        $('.ChcekChnagesClass').each(function () {
            var rs = $(this).attr('data-rs');
            var text = $(this).attr('data-name');
            var Price = $(this).attr('data-roomprice');
            var PriceTax = $(this).attr('data-roompricetax');
            var ExPrice = $(this).attr('data-exroomprice');
            var ExPriceTax = $(this).attr('data-exroompricetax');
            var GST = $(this).attr('data-gst');
            $('.input_wBrakAttprice').val(rs);
            $('.input_wBrakAttname').text(text);
            $('.jsrdUiDropdowntext').text(text);
            $('.redpricejs').text("Rs. " + rs);
            $('.redgstpricejs').text("Per Night + " + GST + "% GST");
            $('#ContentPlaceHolder1_hdnRoomType').val(text);
            $('#ContentPlaceHolder1_hdnRoomPrice').val(Price);
            $('#ContentPlaceHolder1_hdnRoomPriceTax').val(PriceTax);
            $('#ContentPlaceHolder1_hdnTotalRoomPrice').val((parseInt(Price) + parseInt(PriceTax)));
            $('#ContentPlaceHolder1_hdnExtraBedCharges').val(ExPrice);
            $('#ContentPlaceHolder1_hdnExtraBedTax').val(ExPriceTax);
            $('#ContentPlaceHolder1_hdnTotalExtraBedCharges').val((parseInt(ExPrice) + parseInt(ExPriceTax)));
        });

        $('.bind_drop_drwon_Adult').each(function () {
            var NoOfAdults = RoomAdultAllowed;
            var NoOfChilds = RoomKidsAllowed;
            if (parseInt(NoOfChilds) > 0) {
                NoOfChilds = "1";
            }
            var NoOfAdultsAndChilds = (parseInt(NoOfAdults));
            //var NoOfAdultsAndChilds = (parseInt(NoOfAdults) + parseInt(NoOfChilds));
            $(this).attr("data-totalgust", "" + NoOfAdultsAndChilds + "");
            $(this).append(new Option('Select Adult', 'Select Adult'));
            for (var i = 0; i < NoOfAdultsAndChilds; i++) {
                $(this).append(new Option('Adult ' + (i + 1) + '', '' + (i + 1) + ''));
            }
        });

        if (parseInt(RoomKidsAllowed) > 0) {
            $('.kid_hide').show();
            $('.bind_drop_drwon_Child').each(function () {
                var NoOfChilds = RoomKidsAllowed;
                $(this).attr("data-totalchild", "" + NoOfChilds + "");
                $(this).append(new Option('Select Kid', 'Select Kid'));
                for (var i = 0; i < NoOfChilds; i++) {
                    $(this).append(new Option('Kid ' + (i + 1) + '', '' + (i + 1) + ''));
                }
            });
        }
        if(parseInt($("input#ContentPlaceHolder1_hdnTotalNight").val()) > 0){
            CheckNumbersOfRoomAvailable($('#ContentPlaceHolder1_hdnRoomID').val(), $('#ContentPlaceHolder1_hdnToDate').val(), $('#ContentPlaceHolder1_hdnEndDate').val());
        }
    });

    //2. Check Room Availability Start
    $(".Check_Availability").on('click', function (event) {
        if (!req(document.getElementById("ContentPlaceHolder1_hdnToDate"), "Please select check in date."))
            return false;
        if (!req(document.getElementById("ContentPlaceHolder1_hdnEndDate"), "Please select check out date."))
            return false;
        CheckNumbersOfRoomAvailable($('#ContentPlaceHolder1_hdnRoomID').val(), $('#ContentPlaceHolder1_hdnToDate').val(), $('#ContentPlaceHolder1_hdnEndDate').val());
    });

    function CheckNumbersOfRoomAvailable(RoomID, CheckInDate, CheckOutDate) {
        var DomainPath = location.protocol + "//" + location.host + "/RoomDetails.aspx/CheckNumbersOfRoomAvailable";
        $.ajax({
            type: "POST",
            url: DomainPath,
            data: '{"RoomID":"' + RoomID + '","CheckInDate":"' + CheckInDate + '","CheckOutDate":"' + CheckOutDate + '"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (Result) {
                if (Result.d == "-2") {
                    $('.fieldSelectRoom').hide();
                    $('.btnBoxAvialble').show();
                    $('.no_room_found').show();
                    $('.check_availability').hide();
                    $('.No_Rooms_Show').show();
                    $('.book_now_room').show();
                    $('.terms_conditions').show();
                    $('.bind_drop_dwon_by_checkindate').html('');
                    $('.bind_drop_dwon_by_checkindate').each(function () {
                        var NoOfRooms = TotalRoomAvailable;
                        $(this).attr("data-totalRooms", "" + NoOfRooms + "");
                        $(this).append(new Option('Select', 'Select'));
                        for (var i = 0; i < NoOfRooms; i++) {
                            $(this).append(new Option('Room ' + (i + 1) + '', '' + (i + 1) + ''));
                        }
                    });
                }
                else {
                    var TotalRoomAvailable = Result.d.toString();
                    TotalRoomAvailable = (parseInt(RoomTotalRooms) - parseInt(TotalRoomAvailable));
                    $('.bind_drop_dwon_by_checkindate').html('');
                    $('.bind_drop_dwon_by_checkindate').each(function () {
                        $(this).attr("data-totalRooms", "" + TotalRoomAvailable + "");
                        $(this).append(new Option('Select Number of Rooms', 'Select'));
                        for (var i = 0; i < TotalRoomAvailable; i++) {
                            $(this).append(new Option('Room ' + (i + 1) + '', '' + (i + 1) + ''));
                        }
                    });
                    if (parseInt(TotalRoomAvailable) > 0) {
                        $('.fieldSelectRoom').show();
                        $('.btnBoxAvialble').hide();
                        $('.no_room_found').hide();
                    }
                    else {
                        $('.no_room_found').show();
                        $('.fieldSelectRoom').hide();
                        $('.btnBoxAvialble').show();
                    }
                }

            },
            error: ErrorMessage
        });
        function ErrorMessage(result) {
            document.location.href = '/something-went-wrong?error=CheckNumbersOfRoomAvailable' + result.status + ' ' + result.statusText + ' ' + result.responseText;
        }
    }

    $('.bind_drop_dwon_by_checkindate').change(function () {
        $('#ContentPlaceHolder1_hdnTotalRoomsAvailable').val($(this).val());
        $('.list_roomAddon').show();
        var NoRooms = $(this).val();
        var AdulAndChileHTML = $('.important_data').html();
        if (NoRooms == 'Select') {
            $('.listRooms').html('');
        }
        else {
            var li = $('.listRooms .list').length;
            if ($('.listRooms .list').length < NoRooms) {
                for (var i = li; i < NoRooms; i++) {
                    var addons = AdulAndChileHTML;
                    console.log(i)
                    $('.listRooms').append(addons)[i];
                    $('.listRooms .list').eq(i).children().find('.roomsAdded').removeClass('No_Rooms_SHow1').addClass('No_Rooms_SHow2');
                }
            }
            else {
                $('.listRooms .list').eq((NoRooms - 1)).nextAll().remove()
            }
        }

        var countNo = "0";
        $('.No_Rooms_SHow2').each(function () {
            countNo = (parseInt(countNo) + parseInt(1))
            $(this).text("ROOM #" + countNo + "");
        });
        $('.No_listRooms_Show').show();

        // Change Function of Adults
        $('.bind_drop_drwon_Adult').change(function () {
            $(this).parents('.list').children('.kid_hide').find('.bind_drop_drwon_Child option[value="0"]').prop("selected", true).trigger('change');
            var kid = $(this).parents('.col-B').siblings('.kid_hide');
            var kedRoom = $(this).parents('.col-B').siblings('.kid_Age_hide');
            //$(this).parents().siblings('.col').hide();
            $(this).parents().siblings('.col-A').children('.No_Rooms_SHow2').attr("data-totalnoofadult", "" + $(this).val() + "");
            if ($(this).attr('data-totalgust') == $(this).val() && parseInt(RoomKidsAllowed) > 0) {
                $(this).parents('.list').children('.kid_hide').find('.bind_drop_drwon_Child option[value="0"]').prop("selected", true).trigger('change');
                //$(this).parents('.list').children('.kidSAge').find('.Bind_Kids option[value="1"]').prop('selected', true).trigger('change');
                $(this).parents().siblings('.col-A').children('.No_Rooms_SHow2').attr("data-extrabed", "" + RoomKidsAllowed + "");
                //$(kedRoom).hide();
                //$(kid).hide();
            }
            else {
                $(this).parents('.list').children('.kid_hide').find('.bind_drop_drwon_Child option[value="0"]').prop("selected", false).trigger('change');
                //$(this).parents('.list').children('.kidSAge').find('.Bind_Kids option[value="1"]').prop('selected', false).trigger('change');
                $(this).parents().siblings('.col-A').children('.No_Rooms_SHow2').attr("data-extrabed", "0");
                $(this).parents().siblings('.col-A').children('.No_Rooms_SHow2').attr("data-totalnoofadult", "" + $(this).val() + "");
                parseInt(RoomKidsAllowed) > 0 ? $(this).parents().siblings('.col').show() : null
            }
            btnFormBokk();
        });       

        // Change Function of Child
        $('.bind_drop_drwon_Child').change(function () {
            $(this).siblings('.No_Child_SHow').text($(this).val());
            $(this).parents().siblings('.col-A').children('.No_Rooms_SHow2').attr("data-totalnoofchild", "" + $(this).val() + "");
            const col = $(this).val();

            var coll = $(this).parents('.list').children().find('.kid_Age_hide');
            if (col == 0) {
                coll.hide();
                $(this).parents('.list').children().find('.kid_Age_hide').find('.Bind_Kids option[value="1"]').prop('selected', true).trigger('change');
                btnFormBokk();
            }
            else if (col == 1) {
                coll.show();
                $(this).parents('.list').children().find('.kid_Age_hide').addClass('fullcol').eq(1).hide()
            }
            else {
                coll.show();
                $(this).parents('.list').children().find('.kid_Age_hide').removeClass('fullcol').show();
            }
        });

        // Change Function of Kids
        $('.Bind_Kids').change(function () {
            var HowISKIds = $(this).attr('data-attkids');
            if (HowISKIds == "Kids 1") {
                $(this).parents('.col-B').siblings('.col-A').children('.No_Rooms_SHow2').attr("data-kidsoneage", "" + $(this).val() + "");
            }
            else {
                $(this).parents('.col-B').siblings('.col-A').children('.No_Rooms_SHow2').attr("data-kidstwoage", "" + $(this).val() + "");
            }
            btnFormBokk();
        });
        btnFormBokk();
    });
    // Button Show
    function btnFormBokk() {
        var CheckAllRoomAdultsAndChildYes = 0;
        var CheckAllRoomAdultsAndChildNo = 1;
        $('.No_listRooms_Show .list').each(function () {
            if ($(this).children().find('select.form-control.dropdown_adult').val() == 'Select Adult') {
                CheckAllRoomAdultsAndChildNo = 0;
            }
            else {
                CheckAllRoomAdultsAndChildYes = 1;
            }
        });       
        if (CheckAllRoomAdultsAndChildNo == 0) {
            $('.book_now_room').hide();
            $('.terms_conditions').hide();
        }
        else if (CheckAllRoomAdultsAndChildYes == 0) {
            $('.book_now_room').hide();
            $('.terms_conditions').hide();
        }
        else {
            $('.book_now_room').show();
            $('.terms_conditions').show();
        }
    }
    // Check Room Availability Start End

    //2. Add To Cart Start
    $(".add_to_cart").on('click', function (event) {
        if ($('#ContentPlaceHolder1_hdnToDate').val() == "")
            return false;
        if ($('#ContentPlaceHolder1_hdnEndDate').val() == "")
            return false;
        var Room = $("input#ContentPlaceHolder1_hdnRoomID").val().trim();
        if ($('#ContentPlaceHolder1_hdnSerachRoomID').val() == "1") {
            DeleteRoomBookingModuleByListID(Room);
        }
        var RoomName = $("input#ContentPlaceHolder1_hdnRoomName").val().trim();
        var RoomURL = $("input#ContentPlaceHolder1_hdnRoomURL").val().trim();
        var RoomImage = $("input#ContentPlaceHolder1_hdnRoomImage").val().trim();
        var RoomType = $("input#ContentPlaceHolder1_hdnRoomType").val().trim();;
        var RoomPrice = $('#ContentPlaceHolder1_hdnRoomPrice').val().trim();
        var RoomPriceTax = $('#ContentPlaceHolder1_hdnRoomPriceTax').val().trim();
        //var RoomExPrice = $('#ContentPlaceHolder1_hdnExtraBedCharges').val().trim();
        //var RoomExPriceTax = $('#ContentPlaceHolder1_hdnExtraBedTax').val().trim();
        var CheckInDate = $("input#ContentPlaceHolder1_hdnToDate").val().trim();
        var CheckOutDate = $("input#ContentPlaceHolder1_hdnEndDate").val().trim();
        var NoOfRooms = RoomTotalRooms;
        //var TotalNight = $("input#ContentPlaceHolder1_hdnTotalNight").val();
        $('#UpdateProgress2').fadeIn(100);
        $(".No_Rooms_SHow2").each(function () {
            var RoomExPriceForSelect = $('#ContentPlaceHolder1_hdnExtraBedCharges').val().trim();
            var RoomExPriceTaxSelect = $('#ContentPlaceHolder1_hdnExtraBedTax').val().trim();
            var TotalRooms = $('.bind_drop_dwon_by_checkindate').val();
            var TotalNight = $("input#ContentPlaceHolder1_hdnTotalNight").val();
            var TotalKidsPrice = 0;
            var TotalAdults = $(this).attr('data-totalnoofadult').trim();
            var TotalKids = $(this).attr('data-totalnoofchild').trim();
            var TotalKidsAge = $(this).attr('data-kidsoneage').trim();
            var TotalKidsAgeTwo = $(this).attr('data-kidstwoage').trim();
            var TotalExtraPerSon = "";
            var RoomExPrice = 0;
            var RoomExPriceTax = 0;
            if (parseInt(TotalKidsAge) > parseInt(RoomKidsAge)) {
                RoomExPrice = $('#ContentPlaceHolder1_hdnExtraBedCharges').val().trim();
                RoomExPriceTax = $('#ContentPlaceHolder1_hdnExtraBedTax').val().trim();
            }
            if (parseInt(TotalKidsAgeTwo) > parseInt(RoomKidsAge)) {
                TotalKidsPrice = (parseInt(TotalKidsPrice) + parseInt(RoomKidsAgePrice));
                RoomExPrice = (parseInt(RoomExPrice) + parseInt($('#ContentPlaceHolder1_hdnExtraBedCharges').val().trim()));
                RoomExPriceTax = (parseInt(RoomExPriceTax) + parseInt($('#ContentPlaceHolder1_hdnExtraBedTax').val().trim()));
            }
            SaveRoomCartToCart(Room, RoomName, RoomURL, RoomImage, RoomSmallDescription, RoomType, RoomPrice, RoomPriceTax, RoomExPrice, RoomExPriceTax, TotalAdults, TotalKids, RoomKidsAge, TotalKidsAge, TotalKidsAgeTwo, TotalKidsPrice, CheckInDate, CheckOutDate, TotalNight, TotalRooms, NoOfRooms);
        });
        setTimeout(function () {
            if (parseInt($("#ContentPlaceHolder1_hdnTotalNight").val()) > 0) {
                var RedirectUrl = location.protocol + "//" + location.host + "/room-booking-cart";
                window.location.replace(RedirectUrl);
            }
            else {
                $('.no_room_found').show();
                $('.no_room_found p').text("Please try again after some time.");
            }
        },500)
        
    });

    //1. Add To Cart
    function SaveRoomCartToCart(Room, RoomName, RoomURL, RoomImage, RoomSmallDescription, RoomType, RoomPrice, RoomPriceTax, RoomExPrice, RoomExPriceTax, TotalAdults, TotalKids, RoomKidsAge, TotalKidsAge, TotalKidsAgeTwo, TotalKidsPrice, CheckInDate, CheckOutDate, TotalNight, TotalRooms, NoOfRooms) {
        var DomainPath = location.protocol + "//" + location.host + "/RoomDetails.aspx/SaveRoomCartToCart";
        $.ajax({
            type: "POST",
            url: DomainPath,
            data: '{"Room":"' + Room + '","RoomName":"' + RoomName + '","RoomURL":"' + RoomURL + '","RoomImage":"' + RoomImage + '","RoomSmallDescription":"' + RoomSmallDescription + '","RoomType":"' + RoomType + '","RoomPrice":"' + RoomPrice + '","RoomPriceTax":"' + RoomPriceTax + '","RoomExPrice":"' + RoomExPrice + '","RoomExPriceTax":"' + RoomExPriceTax + '","TotalAdults":"' + TotalAdults + '","TotalKids":"' + TotalKids + '","RoomKidsAge":"' + RoomKidsAge + '","TotalKidsAge":"' + TotalKidsAge + '","TotalKidsAgeTwo":"' + TotalKidsAgeTwo + '","TotalKidsPrice":"' + TotalKidsPrice + '","CheckInDate":"' + CheckInDate + '","CheckOutDate":"' + CheckOutDate + '","TotalNight":"' + TotalNight + '","TotalRooms":"' + TotalRooms + '","NoOfRooms":"' + NoOfRooms + '"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                if (parseInt(TotalNight) == 0) {
                    $("input#ContentPlaceHolder1_hdnCart").val(result.d);
                }
                $("input#ContentPlaceHolder1_hdnTotalNight").val(result.d);
            },
            error: ErrorMessage
        });
        function ErrorMessage(result) {
            document.location.href = '/something-went-wrong?error=SaveRoomCartToCart' + result.status + ' ' + result.statusText + ' ' + result.responseText;
        }
    }

    //2. Delete To Cart
    function DeleteRoomBookingModuleByListID(Room) {
        $('#UpdateProgress2').fadeIn(100);
        var DomainPath = location.protocol + "//" + location.host + "/RoomDetails.aspx/DeleteRoomBookingModuleByListID";
        $.ajax({
            type: "POST",
            url: DomainPath,
            data: '{"Room":"' + Room + '"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                
            },
            error: ErrorMessage
        });
        function ErrorMessage(result) {
            document.location.href = '/something-went-wrong?error=SaveRoomCartToCart' + result.status + ' ' + result.statusText + ' ' + result.responseText;
        }
    }
    // Add To Cart Start Ens
</script>
<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAdgtKv7SriM13lFaja6Kg0DM4yZXkpoRA"></script>
<script type="text/javascript" src="assets/js/map.js" >
</script>
</asp:Content>
