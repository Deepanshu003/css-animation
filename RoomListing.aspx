<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="RoomListing.aspx.cs" Inherits="AapnoGharWeb.RoomListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="banner room-listingBanner">
    <div class="bg">
        <div class="video_banner"><video src="https://www.aapnoghar.com/assets/video/stay-hotel.mp4" loop autoplay muted></video></div>
        <div class="banner-content"><h1>Stay at Aapno Ghar</h1></div>
    </div>
    <div class="banner-booking-form" id="PnlRoomForSearchListing" runat="server" visible="false" style="display:none;">
        <div class="booking-form-wrapper">
            <div class="form-container">
                <div class="flex">
                    <div class="col col1">
                        <div class="dropdown-select js-dropdown">
                            <div class="dropdown-wrapper">
                                <div class="slected_dropdown">
                                    <input id="hdnSerachRoomID" runat="server" type="hidden" value="" class="input-rom-hidd" />
                                    <div class="placeholder-label">Select Room</div>
                                    <div class="placeholder-val">Select Room</div>
                                </div>
                                <div class="list-dropdown">
                                    <ul>
                                        <asp:Repeater ID="RptrRoomForSearchListing" runat="server">
                                            <ItemTemplate>
                                                <li data-val="<%#Eval("RoomName")%>" data-attrurl="<%#Eval("RoomNameAlias")%>">
                                                    <div class="checkBoxGroups">
                                                        <label for="">
                                                            <div class="fakeBox"><img src="/assets/icons/tik.png" alt="best water park" /></div>
                                                            <span><%#Eval("RoomName")%></span>
                                                        </label>
                                                    </div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col col2">
                        <div class="form-group"><input type="text" class="checkin_hotel" id="txtchecin" /> <label for="ContentPlaceHolder1_txtchecin">Check In</label></div>
                    </div>
                    <div class="col col3">
                        <div class="form-group"><input type="text" class="checkout_hotel" id="txtchecout" /> <label for="ContentPlaceHolder1_txtchecout">Check Out</label></div>
                    </div>
                    <div class="col col4" style="display:none;">
                        <div class="conter-box">
                            <div class="box-wrapper">
                                <label for="">Adults</label>
                                <div class="counter jounterJsHandler">
                                    <button class="btnDecrement" data-actype="ADULT" type="button">-</button> <input type="text" readonly value="0" class="inputDet input-adult" /> <button class="btnIncrement" data-actype="ADULT" type="button">+</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col col5" style="display:none;">
                        <div class="conter-box">
                            <div class="box-wrapper">
                                <label for="">Kids</label>
                                <div class="counter jounterJsHandler">
                                    <button class="btnDecrement" data-actype="KIDS" type="button">-</button> <input type="text" readonly value="0" class="inputDet input-kids" /> <button class="btnIncrement" data-actype="KIDS" type="button">+</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col col6">
                        <div class="btn-form">
                            <asp:Panel ID="PnlCheckAvailability" runat="server" DefaultButton="btnCheckAvailability">
                                <asp:UpdatePanel ID="UpdPnlCheckAvailability" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnCheckAvailability" runat="server" Text="Check Availability" class="btn" onclick="btnCheckAvailability_Click"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="room-listing-SecA">
    <div class="container">
        <div class="content">
            <div class="logo"><img src="assets/images/room/logo.png" alt="nearest water park" /></div>
            <p>Discover AapnoGhar Resort in Manesa, Gurgaon (Gurugram), a luxury resort tucked away from the city bustle, to entertain guests with a unique holiday resort in Manesar, Gurgaon,  few minutes’ drive from Delhi. The resort offers 67 spacious, comfortable and graciously appointed rooms. The residential area of the resort welcomes guests with a common sit-out natural paradise enhanced with comfortable outdoor furniture, relaxing swings, and a garden gym. Guest facilities also include Football Ground, Cricket Ground and Badminton Court, Basket ball, Volley ball . AapnoGhar Resort is best suited for corporate, families and business travelers.</p>
        </div>
    </div>
</div>
<div class="room-listing-Sect">
    <div class="container-fluid">
        <div class="flex">
            <asp:Repeater ID="RptrRoomListing" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="roomCard">
                            <div class="room-card-inner">
                                <div class="flex">
                                    <div class="card-colA">
                                        <a href="/<%#Eval("RoomNameAlias")%>">
                                            <figure><img src="/AapnoGharlmages/RoomImages/<%#Eval("RoomDefaultImage")%>" alt="<%#Eval("RoomNameAlias")%>" title="<%#Eval("RoomName")%>"/></figure>
                                        </a>
                                    </div>
                                    <div class="card-colB">
                                        <div class="room-card-detail">
                                            <div class="cardDetails">
                                                <div class="room-name"><%#Eval("RoomName")%></div>
                                                <%# Convert.ToString(Eval("RoomSmallDescription")) != "" ? "<div class='sortDes'>"+Eval("RoomSmallDescription")+"</div>":"" %>
                                                <div class="amminit">
                                                    <ul>
                                                        <%# Convert.ToString(Eval("RoomViewSide")) != "" ? "<li> <div class='icon'><img src='assets/images/room/beach.png' alt='water park' /></div> <div class='text'>"+Eval("RoomViewSide")+"</div> </li>":"" %>
                                                        <%# Convert.ToString(Eval("RoomBedType")) != "" ? "<li> <div class='icon'><img src='assets/images/room/bed.png' alt='water adventure parks' /></div> <div class='text'>"+Eval("RoomBedType")+"</div> </li>":"" %>
                                                        <li>
                                                            <div class="icon"><img src="assets/images/room/maximumOccoumpany.png" alt="water park resort near me" /></div>
                                                            <div class="text"><%# Convert.ToInt16(Eval("NoofChildren")) > 0 ? ""+Eval("NoofAdults")+" Adults and "+Eval("NoofChildren")+" Children Or "+(Convert.ToInt16(Eval("NoofChildren")) + Convert.ToInt16(Eval("NoofAdults")))+" Adults":""+Eval("NoofAdults")+" Adults" %></div>
                                                        </li>
                                                         <%# Convert.ToString(Eval("RoomSize")) != "" ? "<li> <div class='icon'><img src='assets/images/room/scale-up.png' alt='water park near by me' /></div> <div class='text'>Size : "+Eval("RoomSize")+"</div> </li>":"" %>
                                                         <%# Convert.ToString(Eval("ComplimentaryWiFiDevices")) != "" ? "<li> <div class='icon'><img src='assets/images/room/wifi.png' alt='water park near me with price' /></div> <div class='text'>"+Eval("ComplimentaryWiFiDevices")+"</div> </li>":"" %>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="roomPricein">
                                                <div class="price" <%# (Convert.ToInt16(Eval("DiscountedPrice")) > 0) ? "":" style='display:none;'" %>>Rs. <%#Eval("DiscountedPrice")%>.00</div>
                                                <p class="pn" <%# (Convert.ToInt16(Eval("DiscountedPrice")) > 0) ? "":" style='display:none;'" %>>Per Night + GST</p>
                                                <div class="btn_rom"><a href="/<%#Eval("RoomNameAlias")%>">Room Details</a></div>
                                                <%# Convert.ToString(Eval("Room360View")) != "" ? "<div class='txview'> <a href='"+Eval("Room360View")+"' target='_blank'> <p>360<sup>o</sup></p> <span>View</span> </a> </div>":"" %>                                                
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
<%--<asp:HiddenField ID="hdnSerachRoomID" runat="server" />--%>
<asp:HiddenField ID="hdnRoomName" runat="server" />
<asp:HiddenField ID="hdnCheckInDate" runat="server" />
<asp:HiddenField ID="hdnCheckOutDate" runat="server" />
<asp:HiddenField ID="hndTotalNoOfAdult" runat="server" />
<asp:HiddenField ID="hndTotalNoOfKids" runat="server" />
<script type="text/javascript">
    $(function () {
        $('.active_room').addClass('active_header');
        $('.js-dropdown .slected_dropdown').on('click', function () {
            $('.list-dropdown').slideToggle();
        });

        $('.js-dropdown .list-dropdown li').on('click', function () {
            var room_val = $(this).attr('data-val');
            var room_url = $(this).attr('data-attrurl');
            $(this).addClass('active').siblings().removeClass('active');
            $('.placeholder-val').text(room_val);
            $('.input-rom-hidd').val(room_url);
            $('.list-dropdown').slideUp();
            $('.js-dropdown').addClass('active');
        });

        $('body').click(function (e) {
            var catFilterCont = $(".js-dropdown");
            if (!catFilterCont.is(e.target) && catFilterCont.has(e.target).length === 0) {
                $('.list-dropdown').slideUp();
            }
        });

        $(".checkin_hotel").datepicker({
            minDate: 0,
            firstDay: 0,
            dateFormat: 'dd-mm-yy',
            changeMonth: true,
            numberOfMonths: 1,
            onClose: function (selectedDate) {
                var newMin = selectedDate;
                $('#ContentPlaceHolder1_hdnCheckInDate').val(selectedDate);
                if ($(this).val() != "") {
                    $(this).parent('.form-group').addClass('valid')
                }
                else {
                    $(this).parent('.form-group').removeClass('valid')
                }
                $(".checkout_hotel").datepicker("option", "minDate", newMin);
            }
        });

        $(".checkout_hotel").datepicker({
            minDate: '+2d',
            changeMonth: true,
            firstDay: 0,
            dateFormat: 'dd-mm-yy',
            numberOfMonths: 1,
            onClose: function (selectedDate) {
                if ($(this).val() != "") {
                    $(this).parent('.form-group').addClass('valid')
                }
                else {
                    $(this).parent('.form-group').removeClass('valid')
                }
                $('#ContentPlaceHolder1_hdnCheckOutDate').val(selectedDate);
            }
        });
    })

    // Counter Adult data-actype
    const ActionType = {
        INC_COUNTER: "INC_COUNTER",
        DEC_COUNTER: "DEC_COUNTER",
    }
    const ACTION_COUNT = {
        ADULT: 0,
        KIDS: 0,
    }
    var BTN_DEC, BTN_INC;
    BTN_DEC = $('.btnDecrement');
    BTN_INC = $('.btnIncrement');

    BTN_INC.on('click', function () {
        var acF = $(this).attr('data-actype');
        CounterHandler(ActionType.INC_COUNTER, acF)
    })
    BTN_DEC.on('click', function () {
        var acF = $(this).attr('data-actype')
        CounterHandler(ActionType.DEC_COUNTER, acF)
    });

    function CounterHandler(type, ACTFor) {
        if (ActionType.INC_COUNTER == type) {
            ACTION_COUNT[ACTFor] = ACTION_COUNT[ACTFor] + 1;
        }
        else if (ActionType.DEC_COUNTER == type) {
            if (ACTION_COUNT[ACTFor] === 0) {
                return 0;
            }
            else {
                ACTION_COUNT[ACTFor] = ACTION_COUNT[ACTFor] - 1;
            }
        }
        bindDataInput(ACTFor)
    }
    function bindDataInput(i) {
        $('button[data-actype="' + i + '"]').siblings('.inputDet').val(ACTION_COUNT[i]);
    }
</script>
</asp:Content>