<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="RoomBooking.aspx.cs" Inherits="AapnoGharWeb.RoomBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .disply_hide{display:none;}
</style>
<div class="strip_top">
    <div class="container-fluid">
        <div class="flex">
            <div class="col">
                <div class="branDress"><p>Aapno Ghar, Gurugram</p></div>
            </div>
            <div class="col">
                <div class="branDress_link">
                    <ul>
                        <li>Direct Reservations :</li>
                        <li><a href="mailto:info@aapnoghar.com">info@aapnoghar.com</a></li>
                        <li class="line"></li>
                        <li><a href="tel:+91-766677999">+91-766677999</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="room-bookInner-SecA room-bookInner-SecEx">
    <div class="container-fluid">
        <div class="flex">
            <div class="asde_Left">
                <div class="room-bookInner">
                    <div class="stepasBookRom">
                        <div class="wrapper">
                            <h3>Select a Room</h3>
                            <div class="steps">
                                <ul>
                                    <li class="current">
                                        <div class="no">1</div>
                                        <p>Rooms</p>
                                    </li>
                                    <li>
                                        <div class="no">2</div>
                                        <p>Guest Details</p>
                                    </li>
                                    <li>
                                        <div class="no">3</div>
                                        <p>Payment</p>
                                    </li>
                                    <li>
                                        <div class="no">4</div>
                                        <p>Confirmation</p>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="roomDetailList">
                        <div class="wrapperList">
                            <asp:Repeater ID="RptrCartRoom" runat="server">
                                <ItemTemplate>
                                    <div class="listCard">
                                        <div class="card">
                                            <div class="flex">
                                                <div class="cardImg">
                                                    <figure><img src="/AapnoGharlmages/RoomImages/<%#Eval("RoomImage")%>" title="<%#Eval("RoomName")%>"/></figure>
                                                </div>
                                                <div class="cardRommDetail">
                                                    <div class="cardHeader">
                                                        <h4 class="roomName"><%#Eval("RoomName")%></h4>
                                                        <div class="text jsrdUiDropdowntext"><%#Eval("RoomType")%></div>
                                                        <%# Convert.ToString(Eval("RoomSmallDescription")) != "" ? "<div class='sortDes'><p>"+Eval("RoomSmallDescription")+"</p></div>":"" %>
                                                        <asp:HiddenField ID="hdnRoomID" runat="server" Value='<%#Eval("RoomID")%>' Visible="false"/>
                                                    </div>
                                                    <div class="list_roomsCard">
                                                        <div class="wrap">
                                                            <asp:Repeater ID="RptrCartRooms" runat="server">
                                                                <ItemTemplate>
                                                                    <div class="repet">
                                                                        <div class="snRomm">Room <%# Container.ItemIndex + 1 %></div>
                                                                        <ul>
                                                                            <li><%# Convert.ToInt16(Eval("TotalAdults")) > 1 ? ""+Eval("TotalAdults")+" Adults":"1 Adult" %></li>
                                                                            <%# (Convert.ToInt16(Eval("TotalKids")) > 0 && Convert.ToInt16(Eval("TotalKidsAge1")) == 0) ? "<li>Children 1 (< 1 year)</li>":"" %>
                                                                            <%# (Convert.ToInt16(Eval("TotalKids")) > 0 && Convert.ToInt16(Eval("TotalKidsAge1")) == 1) ? "<li>Children 1 ("+Eval("TotalKidsAge1")+" year)</li>":"" %>
                                                                            <%# (Convert.ToInt16(Eval("TotalKids")) > 0 && Convert.ToInt16(Eval("TotalKidsAge1")) > 1) ? "<li>Children 1 ("+Eval("TotalKidsAge1")+" years)</li>":"" %>
                                                                            <%# (Convert.ToInt16(Eval("TotalKids")) > 1 && Convert.ToInt16(Eval("TotalKidsAge2")) == 0) ? "<li>Children 2 (< 1 year)</li>":"" %>
                                                                            <%# (Convert.ToInt16(Eval("TotalKids")) > 1 && Convert.ToInt16(Eval("TotalKidsAge2")) == 1) ? "<li>Children 2 ("+Eval("TotalKidsAge2")+" year)</li>":"" %>
                                                                            <%# (Convert.ToInt16(Eval("TotalKids")) > 1 && Convert.ToInt16(Eval("TotalKidsAge2")) > 1) ? "<li>Children 2 ("+Eval("TotalKidsAge2")+" years)</li>":"" %>
                                                                        </ul>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                    <div class="cardRoomBody">
                                                        <div class="roomDetailsIntel1">
                                                            <div class="roomDIntel1Wrap">
                                                                <div class="licol cola">
                                                                    <div class="price_wrap">
                                                                        <div class="price redpricejs">Rs. <%#Eval("RoomPrice")%>.00</div>
                                                                        <div class="pn">Per Night + GST</div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal ID="ltrNoRoom" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
            <div class="asde_Right" style="display:none;">
                <div class="asicdWrapper">
                    <div class="bookingCardAside">
                        <div class="heading">Your Stay</div>
                        <%--<div class="checkinout">
                            <ul>
                                <li>
                                    <div class="text">
                                        <p><span>Check-in</span> <b>12:00 Noon</b></p>
                                    </div>
                                </li>
                                <li>
                                    <div class="text">
                                        <p><span>Check-out</span> <b>10:30 AM </b></p>
                                    </div>
                                </li>
                            </ul>
                        </div>--%>
                        <div class="listSeelctdRomrb">
                            <div id="msg"></div>
                            <asp:Literal ID="ltrSucMsg" runat="server"></asp:Literal>                            
                            <div class="wrapper" id="bindRoomsData"></div>
                        </div>
                        <div class="listSeelctdRomrb disply_hide">
                            <div class="wrapper">
                                <div class="list-container list-selectedRomm-js"></div>
                                <div class="RomBookiTotol js-RomBookiTotol">
                                    <div class="tootal_lalbel">
                                        <input type="hidden" />
                                        <p>Total</p>
                                        <span class="jstotlaPris finalTotlaPrice">Rs. 00.00 </span>
                                    </div>
                                    <div class="coupon_lalbel coupon_show_hide" style="display:none;">
                                        <p>Coupon Discount</p>
                                        <span class="jsdisprice">- Rs. 00.00</span>
                                    </div>
                                    <div class="tax_lalbel ex_charges_show_hide">
                                        <p>Extra Adult Charges</p>
                                        <span class="jstaxamoun finalTotlaExPrice">Rs. 00.00 </span>
                                    </div>
                                    <div class="tax_lalbel">
                                        <p>Total Tax</p>
                                        <span class="jstaxamoun finalTotlaTax">Rs. 00.00 </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="only_mob act_card"></div>
                        <div class="paybalAmoutn disply_hide">
                            <div class="paybal">
                                <p>Payable</p>
                                <span class="ttotlaPayAmount">Rs. 00.00</span>
                            </div>
                            <div class="form-btn_su">
                                <a href="/stay" class="btn">More Room</a>
                                <asp:LinkButton ID="lnkProceedNow" class="btn" runat="server" onclick="lnkProceedNow_Click">Proceed Now</asp:LinkButton>
                            </div>
                        </div>
                        <%--<div class="couponCodeBox disply_hide">
                            <div class="couponForm">
                                <div class="form">
                                    <div class="form-group"><input type="text" class="form-control inputProMocode" placeholder="Promo Code" /> <button class="btn">Apply</button></div>
                                </div>
                                <div class="viewAllcoup"><p class="model-open" data-model=".CouponsPopModule">View all coupons</p></div>
                                <div class="termcont">
                                    <div class="checkBoxGroup">
                                        <label for="">
                                            <input type="checkbox" />
                                            <div class="fakeBox"><img src="assets/icons/tik.png" alt="" /></div>
                                        </label>
                                    </div>
                                    <p>I agree to the <a href="/terms-and-conditions#Hotel" target="_blank">terms and conditions</a></p>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdnUrl" runat="server" />
<asp:HiddenField ID="hdnSubTotalPrice" Value="0" runat="server" />
<asp:HiddenField ID="hdnSubTotalPriceTax" Value="0" runat="server" />
<asp:HiddenField ID="hdnSubExTotalPrice" Value="0" runat="server" />
<asp:HiddenField ID="hdnSubExTotalPriceTax" Value="0" runat="server" />
<asp:HiddenField ID="hdnCouponCode" runat="server" />
<asp:HiddenField ID="hdnCouponValue" Value="0" runat="server" />
<asp:HiddenField ID="hdnPayableAmount" Value="0" runat="server" />
<asp:HiddenField ID="hdnTodayNights" Value="0" runat="server" />
<asp:HiddenField ID="hdnCartOpen" runat="server" />
<script type="text/javascript" src="/assets/js/roomHandler.js"></script>
<script type="text/javascript">
    $(function () {
	$('.act_card').append($('.paybalAmoutn').html())
        var path = location.pathname;
        if(path == "/room-booking-cart"){
            $('.mobFooterStrip').remove();
        }        
	$('.active_room').addClass('active_header');
        //Price
        
        $('.totrooms_').on('click', function () {
            $('.rombokde').slideToggle();
        });

        $('.trviealde p').on('click', function () {
            $(this).parent('.trviealde').siblings('.roomDetailsIntel3').slideToggle();
        });

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
                    items: 1
                },
                675: {
                    items: 3,
                    navText: ['<img src="assets/icons/nextBl.png" />', '<img src="assets/icons/nextBr.png" />'],
                }
            }
        });

        $('.selected_filter').on('click', function () {
            $('.filterDropdownList').slideToggle();
        });

        $('.filterDropdownList ul li').on('click', function () {
            $('.filterDropdownList').slideUp();
            $('.sortselect').text($(this).text())
        });

        $('body').click(function (e) {
            var catFilterCont = $(".selected_filter");
            if (!catFilterCont.is(e.target) && catFilterCont.has(e.target).length === 0) {
                $('.filterDropdownList').slideUp();
            }
        });

        $('.jsrdUiDropdownSelc').on('click', function () {
            $(this).siblings('.rdUiDropdrodown').slideToggle()
        });

        $('.jsrdUiDropdrodown ul li').on('click', function () {
            $('.rdUiDropdrodown').slideUp();
            var rs = $(this).attr('data-rs');
            var text = $(this).attr('data-name');
            $(this).parents('.roomDetailsIntel1').children().find('.rommSelecHiInpPrice').val(rs);
            $(this).parents('.roomDetailsIntel1').children().find('.redpricejs').text("Rs. " + rs);
            $(this).parents('.roomDetailsIntel1').children().find('.input_wBrakAttprice').val(rs);
            $(this).parents('.roomDetailsIntel1').children().find('.input_wBrakAttname').text(text);
            $(this).parents('.roomDetailsIntel1').children().find('.jsrdUiDropdowntext').text(text);
            $(this).parents('.listCard').attr('data-roomtype', $(this).attr('data-name'));
            $(this).parents('.listCard').attr('data-roomprice', $(this).attr('data-rs'));
            $(this).parents('.listCard').attr('data-roomtax', $(this).attr('data-rsgst'));
            $(this).parents('.listCard').attr('data-roomrxtraprice', $(this).attr('data-exrs'));
            $(this).parents('.listCard').attr('data-roomrxtrapricetax', $(this).attr('data-exrsgst'));
        });

        $('.reapetroom_list').each(function () {
            $(this).children().find('.jsrdUiDropdrodown ul li').eq(0).trigger('click')
        });

        $('body').click(function (e) {
            var catFilterCont = $(".jsrdUiDropdownSelc");
            if (!catFilterCont.is(e.target) && catFilterCont.has(e.target).length === 0) {
                $('.rdUiDropdrodown').slideUp();
            }
        });

        if (parseInt($("#ContentPlaceHolder1_hdnCartOpen").val()) > 0) {
            ShowRoomBookingModule();
            $('.reapetroom_list').each(function () {

            });
        }
    });

    //1. Show cart Value
    function ShowRoomBookingModule() {
        var DomainPath1 = location.protocol + "//" + location.host + "/RoomBooking.aspx/ShowRoomBookingModule";
        $.ajax({
            type: "POST",
            url: DomainPath1,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (Result) {
                if (Result.d != "0") {
                    $('#bindRoomsData').html('' + Result.d);
                    $('.asde_Right').show();
                    PriceDataAccordingToRooms();
                }
                else if (Result.d == "0") {
                    $('#msg').html("<p style='color: #ed1d24;'>Room Booking Cart Empty</p>");
                }
                $('.delete_room').on('click', function () {
                    DeleteRoomBookingModuleByListID($(this).attr("data-delete"));
                });
            }, complete: function () { setTimeout(function () { $('#UpdateProgress2').fadeOut(800); }, 1000); },
            error: ErrorMessage
        });
        function ErrorMessage(Result) {
            document.location.href = '/something-went-wrong?error=SaveRoomCartToCart' + Result.status + ' ' + Result.statusText + ' ' + Result.responseText;
        }
    }

    //2. Delete To Cart
    function DeleteRoomBookingModuleByListID(RoomListID) {
        $('#UpdateProgress2').fadeIn(100);
        var DomainPath = location.protocol + "//" + location.host + "/RoomBooking.aspx/DeleteRoomBookingModuleByListID";
        $.ajax({
            type: "POST",
            url: DomainPath,
            data: '{"RoomListID":"' + RoomListID + '"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                if (result.d != "" && result.d != "0") {
                    //$('#msg').html("<p style='color: #00aeef;'>" + result.d + "</p>");
                    location.reload();
                    //ShowRoomBookingModule();
                }
                else if (result.d == "0") {
                    $('#msg').html("<p style='color: #ed1d24;'>Please try again aftre some time</p>");
                }
            }, complete: function () { setTimeout(function () { $('#UpdateProgress2').fadeOut(800); }, 1000); },
            error: ErrorMessage
        });
        function ErrorMessage(result) {
            document.location.href = '/something-went-wrong?error=SaveRoomCartToCart' + result.status + ' ' + result.statusText + ' ' + result.responseText;
        }
    }

    function PriceDataAccordingToRooms() {
        //var TotalNights = $('#ContentPlaceHolder1_hdnTodayNights').val();
        var Price = "0";
        var Taxes = "0";
        var ExtraCharges = "0";
        var ExtraChargestax = "0";
        var KidsPrice = "0";
        var CouponAmount = $('#ContentPlaceHolder1_hdnCouponValue').val();
        var Total = "0";
        $('.jstotlaRoomselected').each(function () {
            Price = (parseInt(Price) + parseInt($(this).attr('data-totalprice')));
            Taxes = (parseInt(Taxes) + parseInt($(this).attr('data-totalpriceTax')));
            ExtraCharges = (parseInt(ExtraCharges) + parseInt($(this).attr('data-totalExprice')));
            ExtraChargestax = (parseInt(ExtraChargestax) + parseInt($(this).attr('data-totalExpriceTax')));
            KidsPrice = (parseInt(KidsPrice) + parseInt($(this).attr('data-totalkidsprice')));
        });
        if (parseInt(KidsPrice) > 0 || parseInt(ExtraCharges) > 0) {
            $('ex_charges_show_hide').show();
        }
        else {
            $('ex_charges_show_hide').hide();
        }
        $('.disply_hide').show();
        Total = ((parseInt(Price) + parseInt(Taxes) + parseInt(ExtraCharges) + parseInt(ExtraChargestax) + parseInt(KidsPrice)) - parseInt(CouponAmount));
        $('#ContentPlaceHolder1_hdnSubTotalPrice').val(Price);
        $('#ContentPlaceHolder1_hdnSubTotalPriceTax').val(Taxes);
        $('#ContentPlaceHolder1_hdnSubExTotalPrice').val(ExtraCharges);
        $('#ContentPlaceHolder1_hdnSubExTotalPriceTax').val(ExtraChargestax);
        $('#ContentPlaceHolder1_hdnPayableAmount').val(Total);
        $('.finalTotlaPrice').text("Rs. " + Price + ".00");
        $('.finalTotlaExPrice').text("Rs. " + (parseInt(KidsPrice) + parseInt(ExtraCharges)) + ".00");
        $('.finalTotlaTax').text("Rs. " + (parseInt(Taxes) + parseInt(ExtraChargestax)) + ".00");
        if (parseInt(CouponAmount) > 0) {
            $('.coupon_show_hide').show();
        }
        else {
            $('.coupon_show_hide').hide();
        }        
        $('.ttotlaPayAmount').text("Rs. " + Total + ".00");
    }
</script>
</asp:Content>

