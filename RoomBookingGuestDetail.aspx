<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="RoomBookingGuestDetail.aspx.cs" Inherits="AapnoGharWeb.RoomBookingGuestDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .disply_hide{display:none;}
    .bookingInforForm { margin-top: 0px; }
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
                                    <li class="current">
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
                            <div class="listCard" id="pnlGustInfo" runat="server">
                                <div class="card">                                                                       
                                    <div class="bookingInforForm">
                                        <div class="form-wrapper">
                                            <div class="title_form">Gust Info</div>
                                            <asp:Panel ID="PnlBookingNow" runat="server" DefaultButton="btnBookingNow">
                                                <asp:UpdatePanel ID="UpdPnlBookingNow" runat="server">
                                                    <ContentTemplate>
                                                        <div class="form">
                                                            <div class="flex">
                                                                <div class="form-col2" style="flex: 0 1 33%; max-width: 33%;">
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtBookingCustomerName" runat="server" class="form-control" placeholder="Full Name*"></asp:TextBox>
                                                                        <label for="ContentPlaceHolder1_txtBookingCustomerName">Full Name<span>*</span></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-col2" style="flex: 0 1 33%; max-width: 33%;">
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtBookingCustomerMobileNo" runat="server" class="form-control" placeholder="Phone No.*"></asp:TextBox>
                                                                        <label for="ContentPlaceHolder1_txtBookingCustomerMobileNo">Phone<span>*</span></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-col2" style="flex: 0 1 33%; max-width: 33%;">
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtBookingCustomerEmailID" runat="server" class="form-control" placeholder="Email ID*"></asp:TextBox>
                                                                        <label for="ContentPlaceHolder1_txtBookingCustomerEmailID">Email ID <span>*</span></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-col2">
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtBookingCustomerCompanyName" runat="server" class="form-control" placeholder="Company Name."></asp:TextBox>
                                                                        <label for="ContentPlaceHolder1_txtBookingCustomerCompanyName">Company Name.</label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-col2">
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtBookingCustomerGSTNo" runat="server" class="form-control" placeholder="GST No."></asp:TextBox>
                                                                        <label for="ContentPlaceHolder1_txtBookingCustomerGSTNo">GST No.</label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="btn-form disply_hide">
                                                                <asp:Button ID="btnBookingNow" runat="server" Text="Continue" class="btn" onclick="btnBookingNow_Click"/>
                                                            </div>
                                                        </div>
                                                        <asp:Literal ID="ltrErrorMsg" runat="server"></asp:Literal>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
                                                        <%# Convert.ToInt16(Eval("SoldOut")) == 1 ? "<div class='sortDes' style='color:red'>Sold Out</div>":"" %>
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
                        </div>
                    </div>
                </div>
            </div>
            <div class="asde_Right">
                <div class="asicdWrapper">
                    <div class="bookingCardAside">
                        <div class="heading">Your Stay</div>
                        <div class="checkinout">
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
                        </div>
                        <div class="listSeelctdRomrb">
                            <div id="msg"></div>
                            <asp:Literal ID="ltrSucMsg" runat="server"></asp:Literal>
                            <div class="wrapper" id="bindRoomsData">
                                <%--<div class="list-container list-selectedRomm-js">
                                    <div class="list" data-id="R0">
                                        <input type="hidden" class="inputHideenPriAddon" value="8250" />
                                        <div class="card">
                                            <div class="card-header">
                                                <div class="romname jsrommname">Deluxe Room</div>
                                                <div class="altr jsaltr">With Breakfast</div>
                                                <div class="forday jsforday">Wed, Mar 29, 2023 - Sat, Apr 1, 2023 | 2 Nights</div>
                                                <div class="cartAvtion">
                                                    <ul>
                                                        <li>
                                                            <button type="button"><img src="assets/icons/pen.png" alt="" /><span>Edit</span></button>
                                                        </li>
                                                        <li>
                                                            <button type="button"><img src="assets/icons/delete.png" alt="" /><span>Delete</span></button>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="card-body">
                                                <div class="totrooms_">
                                                    <div class="rooms jstotlaRoomselected">3 Rooms</div>
                                                    <div class="totpersi jsTotalPersion">7 Adult, 2 Children</div>
                                                </div>
                                                <div class="price jstotlaPris">Rs. 8250.00</div>
                                                <div class="rombokde jsrombokdetail">
                                                    <div class="li">
                                                        <p>Room 1</p>
                                                        <span>2 Adults, 0 Children</span>
                                                        <div class="price">Rs. 2750.00</div>
                                                    </div>
                                                    <div class="li">
                                                        <p>Room 2</p>
                                                        <span>3 Adults, 1 Children</span>
                                                        <div class="price">Rs. 2750.00</div>
                                                    </div>
                                                    <div class="li">
                                                        <p>Room 3</p>
                                                        <span>2 Adults, 1 Children</span>
                                                        <div class="price">Rs. 2750.00</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>                                
                            </div>
                            <div class="RomBookiTotol js-RomBookiTotol disply_hide">
                                <div class="tootal_lalbel">
                                    <input type="hidden" />
                                    <p>Total</p>
                                    <span class="jstotlaPris finalTotlaPrice">Rs. 8250.00 </span>
                                </div>                                
                                <div class="tax_lalbel ex_charges_show_hide">
                                    <p>Extra Adult Charges</p>
                                    <span class="jstaxamoun finalTotlaExPrice">Rs. 00.00 </span>
                                </div>
                                <div class="tax_lalbel">
                                    <p>Total Tax</p>
                                    <span class="jstaxamoun finalTotlaTax">Rs. 100.00 </span>
                                </div>
                                <div class="coupon_lalbel coupon_show_hide">
                                    <p>Coupon Discount</p>
                                    <span class="jsdisprice coupnspriceshow">- Rs. 00.00</span>
                                </div>
                            </div>
                        </div>
                        <div class="paybalAmoutn disply_hide">
                            <div class="paybal">
                                <p>Payable</p>
                                <span class="ttotlaPayAmount">Rs. 8250.00</span>
                            </div>
                            <div class="form-btn_su">
                                <a href="/stay" class="btn">More Room</a>
                                <asp:LinkButton ID="btnBookingNow1" class="btn" runat="server" onclick="btnBookingNow_Click">Continue</asp:LinkButton>
                            </div>
                        </div>
                        <div class="couponCodeBox disply_hide">
                            <div class="couponForm">
                                <div class="form">
                                    <div class="form-group">
                                        <input type="text" class="form-control inputProMocode model-open" data-model=".CouponsPopModule" placeholder="Promo Code" />
                                        <button type="button" class="btn btn_coupons model-open" data-attr="1" data-model=".CouponsPopModule">View all coupons</button>
                                    </div>
                                </div>
                                <div class="termcont">
                                    <div class="checkBoxGroup">
                                        <label for="">
                                            <input type="checkbox" id="che_book_now"/>
                                            <div class="fakeBox"><img src="assets/icons/tik.png" alt="nearby amusement park" /></div>
                                        </label>
                                    </div>
                                    <p>I agree to the <a href="/terms-and-conditions#Hotel" target="_blank">terms and conditions</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdnTotalRooms" runat="server" Value="0" />
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
<asp:HiddenField ID="hdnTotalCoupon" Value="0" runat="server" />
<script type="text/javascript" src="assets/js/roomHandler.js"></script>
<script>
    $(function () {
        var path = location.pathname;
        if (path == "/room-booking-guest") {
            $('.mobFooterStrip').remove();
        }
        $('.paybalAmoutn').append("<div class='btn'>"+$('.bookingInforForm .form .btn-form').html()+"</div>");
    })

    $('.totrooms_').on('click', function () {
        $('.rombokde').slideToggle();
    });


    $(function () {
        $('.active_room').addClass('active_header');
        ShowRoomBookingModule();
    });

    //1. Show cart Value
    function ShowRoomBookingModule() {
        var DomainPath1 = location.protocol + "//" + location.host + "/RoomBookingGuestDetail.aspx/ShowRoomBookingModule";
        $.ajax({
            type: "POST",
            url: DomainPath1,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (Result) {
                if (Result.d != "0") {
                    $('#bindRoomsData').html('' + Result.d);
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
        var DomainPath = location.protocol + "//" + location.host + "/RoomBookingGuestDetail.aspx/DeleteRoomBookingModuleByListID";
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

    function CouponsRooms(CoupType, CoupValue, CoupName) {
        var CouponAmount = "0"
        if (CoupType == "Value") {
            CouponAmount = CoupValue;
        }
        else {
            CouponAmount = (parseInt($('#ContentPlaceHolder1_hdnPayableAmount').val()) * parseInt(CoupValue));
            CouponAmount = parseInt((CouponAmount / 100));
        }
        $('.inputProMocode').val(CoupName);
        $('#ContentPlaceHolder1_hdnCouponCode').val(CoupName); 
        $('#ContentPlaceHolder1_hdnTotalCoupon').val(CouponAmount);
        $('.CouponsPopModule').removeClass('is-open');
        $(".overlay").removeClass('overlay_active');
        $('.coupAppliDeBox,.decouBox').show();
        PriceDataAccordingToRooms();
    }

    function PriceDataAccordingToRooms() {
        //var TotalNights = $('#ContentPlaceHolder1_hdnTodayNights').val();
        var Price = "0";
        var Taxes = "0";
        var ExtraCharges = "0";
        var ExtraChargestax = "0";
        var KidsPrice = "0";
        var CouponAmount = $('#ContentPlaceHolder1_hdnTotalCoupon').val();
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
            $('.coupnspriceshow').text("Rs. " + CouponAmount + ".00");
        }
        else {
            $('.coupon_show_hide').hide();
        }
        $('.ttotlaPayAmount').text("Rs. " + Total + ".00");
    }
</script>
</asp:Content>
