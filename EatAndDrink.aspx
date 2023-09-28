<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="EatAndDrink.aspx.cs" Inherits="AapnoGharWeb.EatAndDrink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="assets/css/fancy-box.css">
<div class="ceremony-banner banner">
    <div class="video_banner"><video src="https://www.aapnoghar.com/assets/video/eat-and-drink-offer-video.mp4" loop="" autoplay="" muted=""></video></div>
    <div class="content">
        <div class="heading text-center">
            <h1><asp:Literal ID="ltrEatAndDrinkName" runat="server"></asp:Literal></h1>
            <asp:Literal ID="ltrEatAndDrinkSamallDescription" runat="server"></asp:Literal>
            <%--<p>Baza restaurant offers a soothing ambience with enticing music as you select from the multi-cuisine menu appealing to the Indian palate (North Indian, South Indian, Continental and Chinese delicacies).</p>--%>
        </div>
    </div>
</div>
<section>
    <div class="ceremony_secA">
        <div class="container">
            <div class="flex">
                <div class="colA">
                    <asp:Literal ID="ltrEatAndDrinkDescription" runat="server"></asp:Literal>
                    <%--<div class="content">
                        <p>
                            Baza restaurant offers a soothing ambience with enticing music as you select from the multi-cuisine menu appealing to the Indian palate (North Indian, South Indian, Continental and Chinese delicacies). An elegant
                            yet simple decor carries over to the well planned, streamlined menu which offers food rich in flavor – each dish having a distinct character. A delightful, clean and tastefully decorated restaurant.
                        </p>
                    </div>
                    <div class="flex">
                        <div class="colav">
                            <div class="content">
                                <h4>Breakfast</h4>
                                <ul>
                                    <li>Tea, Coffee, Juices</li>
                                    <li>Milk & Cornflakes</li>
                                    <li>Sandwich</li>
                                    <li>Butter toast</li>
                                    <li>Idli sambhar</li>
                                    <li>Stuffed parantha with Curd</li>
                                    <li>Cut fruits</li>
                                </ul>
                            </div>
                        </div>
                        <div class="colav">
                            <div class="content">
                                <h4>Lunch / Dinner</h4>
                                <h6>Starters:</h6>
                                <ul>
                                    <li>Soup</li>
                                    <li>Garden Fresh Green Salad</li>
                                </ul>
                                <h6>Main course:</h6>
                                <ul>
                                    <li>Paneer preparation</li>
                                    <li>Seasonal Vegetable</li>
                                    <li>Lentil</li>
                                    <li>Rice preparation</li>
                                    <li>Assorted breads</li>
                                    <li>Desserts</li>
                                    <li>Pickle, Papad, Chutney</li>
                                </ul>
                            </div>
                        </div>
                    </div>--%>
                    <div class="gallery_wrap" id="PnlGalleryData" runat="server" visible="false">
                        <div class="head_ttl">
                            <div class="heading"><h3>Gallery</h3></div>
                            <div class="slide_btn">
                                <div class="nmber">
                                    <span>0<em>1</em></span> /
                                    <p>0<em>5</em></p>
                                </div>
                                <div class="btn_owl">
                                    <div class="prev"><img src="assets/images/Mehndi-haldi/prev.png" alt="" /></div>
                                    <div class="next"><img src="assets/images/Mehndi-haldi/next.png" alt="" /></div>
                                </div>
                            </div>
                        </div>
                        <div class="gallery_demo">
                            <div class="gallery-slider owl-carousel">
                                <asp:Repeater ID="RptrGalleryData" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <figure><img src="/AapnoGharlmages/GalleryImage/<%# Eval("SmallImg") %>" alt="" /></figure>
                                            <a class="view-img" href="javascript:void(0);" data-fancybox-trigger="gallery1"><p>+</p></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="colB">
                    <div class="inquiry_wrp">
                        <div class="Navigation-list">
                            <div class="get_help">
                                <h4>Quick Inquiry</h4>
                                <p>Impressed & ready to get started with us? Then book us for your party Day and we promise you wonderful memories to cherish for lifetime.</p>
                            </div>
                            <asp:Panel ID="PanelEatAndDrink" runat="server" DefaultButton="lnkBtnSubmit">
                                <asp:UpdatePanel ID="UpdatePanelEatAndDrink" runat="server">
                                    <ContentTemplate>
                                        <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                        <div class="nav-model">
                                            <div class="enqury_form_model">
                                                <div class="form">
                                                    <div class="flex">
                                                        <div class="col">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtEatAndDrinkName" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <label for="ContentPlaceHolder1_txtEatAndDrinkName">Name<span></span></label>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtMainEmail1" runat="server" class="Open_Data" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <asp:TextBox ID="txtEatAndDrinkEmail" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <label for="ContentPlaceHolder1_txtEatAndDrinkEmail">Email<span></span></label>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtEatAndDrinkPhone" runat="server" class="form-control" onkeypress="return numeralsOnly(event)" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <label for="ContentPlaceHolder1_txtEatAndDrinkPhone">Phone<span></span></label>
                                                            </div>
                                                            <div class="form-group calender">
                                                                <input class="datepickerDefault" id="txtEventDate" type="text" runat="server" readonly/>
                                                                <label for="ContentPlaceHolder1_txtEventDate">Event Date<span></span></label>
                                                            </div>
                                                            <div class="form-group message_box">
                                                                <textarea class="form-control" id="textarea1" runat="server"></textarea>
                                                                <label for="ContentPlaceHolder1_textarea1">Message</label>
                                                            </div>
                                                        </div>
                                                        <div class="submit_btn">
                                                            <asp:Button ID="lnkBtnSubmit" runat="server" Text="Request a call back" onclick="lnkBtnSubmit_Click"/>
                                                        </div>
                                                        <asp:HiddenField ID="hdnValueEnquiryType" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section>
    <div class="amusement_secF">
        <div class="container">
            <div class="heading text-center"><h3>More Services</h3></div>
            <div class="more_service_demo">
                <div class="more-service-slider owl-carousel">
                    <asp:Repeater ID="RptrEntertainmentForHome" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <a href="/<%#Eval("EntertainmentNameAlias")%>">
                                    <figure><img src='/AapnoGharlmages/EntertainmentImages/<%#Eval("EntertainmentDefaultImage")%>' alt='<%#Eval("EntertainmentNameAlias")%>' title='<%#Eval("EntertainmentName")%>'/></figure>
                                    <div class="srvc-nm"><h5><%#Eval("EntertainmentName")%></h5></div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="item">
                        <a href="/meet-and-celebrate">
                            <figure><img src="assets/images/home/img3.jpg" alt="" /></figure>
                            <div class="srvc-nm"><h5>Meeting & Celebrations</h5></div>
                        </a>
                    </div>
                    <div class="item">
                        <a href="/stay">
                            <figure><img src="/assets/images/home/img4.jpg" alt="" /></figure>
                            <div class="srvc-nm"><h5>Stay at Aapno Ghar</h5></div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<div class="" style="display: none;">
    <asp:Repeater ID="RptrGalleryData1" runat="server">
        <ItemTemplate>
            <a class="fancylink" href="/AapnoGharlmages/GalleryImage/<%# Eval("SmallImg") %>" data-fancybox="gallery1"></a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<script type="text/javascript" src="assets/js/jquery.fancybox.js"></script>
<script type="text/javascript">
    $(function () {
        $('.active_eat_drink').addClass('active_header');
        $('.fancylink').fancybox({
            buttons: [
                'close',
            ],
            thumbs: {
                autoStart: false
            },
            'onStart': function () {
                alert('start');
            }
        });

        $(".view-img").on('click', function () {
            fancAddNav();
        });
        function fancAddNav() {
            var left = 'assets/icons/left.png';
            var right = 'assets/icons/right.png';
            setTimeout(function () {
                $('.fancybox-navigation .fancybox-button--arrow_left div').html('<img src="' + left + '" />');
                $('.fancybox-navigation .fancybox-button--arrow_right div').html('<img src="' + right + '" />');
            }, 100)
        }
        $(function () {
            if (location.hash != '') {
                fancAddNav();
            }
        });


        //slider

        var owlSlidA = $('.gallery-slider');
        var owlAItem = owlSlidA.find('.item');
            owlSlidA.on('initialized.owl.carousel changed.owl.carousel', function(e) {
                $('.slide_btn span em').html(e.relatedTarget.relative(e.item.index) + 1)
                $('.slide_btn p em').html(e.item.count)
                owlAItem.each(function(i){
                    $(this).attr('data-index',i+1)
                })
            })
        owlSlidA.owlCarousel({
            items: 3,
            margin: 15,
            slideBy: 3,
            autoplay: false,
            nav: false,
            navText: ['<img src="assets/icons/left.png" />', '<img src="assets/icons/right.png" />'],
            dots: false,
            loop: false,
            // onInitialized: counter,
            // onChanged: counter,
            responsive: {
                0: {
                    items: 2,
                    margin: 8,
                    nav: false
                },
                675: {
                    items: 2
                },
                991: {
                    items: 3,
                    touchDrag: false,
                    mouseDrag: false,
                    autoplayTimeout: 3000,
                },
            }
        });

        function counter(event) {
            if (!event.namespace) {
                return;
            }
            var slides = event.relatedTarget;
            $('.slide_btn span em').text(slides.relative(slides.current()) / 3 + 1);
            $('.slide_btn p em').text(slides.items().length / 3);
        }
        $('.btn_owl .prev').click(function () {
            // $('.slide_btn span em').html(function(i, val) { return val*1-1 })
            $('.gallery-slider').trigger('prev.owl.carousel');
        })
        $('.btn_owl .next').click(function () {
            // $('.slide_btn span em').html(function(i, val) { return val*1+1 })
            $('.gallery-slider').trigger('next.owl.carousel')
            ;
        })
        $('.more-service-slider').owlCarousel({
            items: 3,
            margin: 25,
            autoplay: false,
            nav: true,
            navText: ['<img src="assets/icons/left_black.png" />', '<img src="assets/icons/right_black.png" />'],
            dots: false,
            loop: true,
            autoplayTimeout: 3000,
            responsive: {
                0: {
                    items: 1.3,
                    nav: false,
                    margin: 10
                },
                675: {
                    items: 3
                },
                991: {
                    items: 3
                },
            }
        });
    })
</script>
</asp:Content>