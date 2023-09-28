<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="EntertainmentDetails.aspx.cs" Inherits="AapnoGharWeb.EntertainmentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="assets/css/fancy-box.css" />
<div class="amusement-banner">
    <div class="img_wrap">
        <div class="item has_bookbtn">
            <figure><asp:Literal ID="ltrEntertainmentImage1" runat="server"></asp:Literal></figure>
            <div class="inf_itm">
                <div class="flex">
                    <div class="heading">
                        <h1><asp:Literal ID="ltrEntertainmentName" runat="server"></asp:Literal></h1>
                        <p><asp:Literal ID="ltrEntertainmentTiming" runat="server"></asp:Literal></p>
                    </div>
                    <div class="btn_vdo">
                        <asp:Literal ID="ltrBookNowActiveOrNot" runat="server"></asp:Literal>
                         <asp:Literal ID="ltrEntertainmentVideoLink" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
        <asp:Literal ID="ltrEntertainmentImage2" runat="server"></asp:Literal>
        <div class="item" id="pnlImageOrGallery" runat="server">
            <asp:Literal ID="ltrEntertainmentImage3" runat="server"></asp:Literal>
            <asp:Literal ID="ltrGalleryData" runat="server"></asp:Literal>
        </div>
    </div>
</div>
<section id="pnlEntertainmentFullDescription" runat="server" visible="false">
    <div class="amusement_secA">
        <div class="container">
            <div class="flex">
                <div class="colA">
                    <figure><img src="assets/icons/Loader-BIG.gif" alt="water park ticket price" /></figure>
                </div>
                <div class="colB">
                    <div class="heading"><h3>Best <asp:Literal ID="ltrEntertainmentName1" runat="server"></asp:Literal> In Gurgaon</h3></div>
                    <div class="content">
                        <asp:Literal ID="ltrEntertainmentFullDescription" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section id="PnlActivities" runat="server" visible="false">
    <div class="amusement_secB">
        <div class="container">
            <div class="heading text-center">
                <h3><asp:Literal ID="ltrActivities" runat="server"></asp:Literal>+ <asp:Literal ID="ltrActivitiesherading" runat="server"></asp:Literal></h3>
                <img src="assets/icons/heading_line_white.png" alt="nearby water park" />
            </div>
            <div class="activity_demo">
                <div class="activity-slider owl-carousel">
                    <asp:Repeater ID="RptrActivities" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <figure><img src="/AapnoGharlmages/ActivityImage/<%# Eval("ActivityDefaultImage") %>" alt="<%# Eval("ActivityAlias") %>" title="<%# Eval("ActivityTitle") %>"/></figure>
                                <div class="acti_inf"><p><%# Eval("ActivityTitle") %></p></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <asp:Literal ID="ltrBookNowActiveOrNot1" runat="server"></asp:Literal>            
        </div>
    </div>
</section>
<section id="PnlDeliciousFood" runat="server" visible="false">
    <div class="amusement_secC">
        <div class="container">
            <div class="heading text-center">
                <h3>Delicious Food</h3>
                <img src="assets/icons/heading_line_white.png" alt="amusement water park" />
            </div>
            <div class="flex">
                <div class="colA">
                    <ul class="food_nav">
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
                                            <%# Convert.ToInt16(Eval("ActiveStatus")) == 1 ? "<div class='link_btn red_btn'><a href='javascript:void(0);' class='model-open' data-model='.Popup_Book_ParkModel'>Book Now</a></div>":"" %>                                            
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
</section>
<section id="PnlTestimonial" runat="server" visible="false">
    <div class="amusement_secD">
        <div class="container">
            <div class="heading text-center">
                <h3>
                    Meet some of the<br />
                    people behind <span>our stories</span>
                </h3>
                <p>AapnoGhar Resort Water Park and Amusement Park , the city of joy is the ideal expression of a beautiful and unequalled dream world.</p>
            </div>
            <div class="testinomial_demo">
                <div class="testinomial-slider owl-carousel">
                    <asp:Repeater ID="RptrTestimonial" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <figure><img src="/AapnoGharlmages/VideoGallery/<%#Eval("SmallImg")%>" alt="<%#Eval("GalleryTitle")%>" title="<%#Eval("GalleryTitle")%>"/></figure>
                                <div class="testi_inf">
                                    <p><%#Eval("GalleryTitle")%></p>
                                    <div class="video_icon model-video model-open" data-model=".Model_Video" data-video="<%#Eval("VideoURL")%>?autoplay=1"><img src="assets/icons/play.png" alt="best amusement park near me" /></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</section>
<section id="pnlEntertainmentPackages" runat="server" visible="false">
    <div class="amusement_secE">
        <div class="container">
            <div class="heading text-center">
                <h3>Choose Packages</h3>
                <img src="assets/icons/heading_line_white.png" alt="water fun park near me" />
            </div>
            <div class="pakage_demo">
                <div class="pakage-slider owl-carousel">
                    <asp:Repeater ID="RptrEntertainmentPackages" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <div class="card">
                                    <div class="top_con">
                                        <div class="heading">
                                            <h2><%#Eval("PackageTitle") %></h2>
                                            <div class="line"><img src="assets/icons/heading_line.png" alt="amusement park" /></div>
                                        </div>
                                        <div class="right_aside">
                                            <h4>Rs.<%#Eval("AdultPrice") %></h4>
                                            <span class="at_top">From</span>
                                        </div>
                                    </div>
                                    <div class="mid_con">
                                        <h6><%#Eval("PackageTimming") %></h6>
                                        <p class="small"><%#Eval("PackagePunchline") %></p>
                                        <div class="pakage_pr">
                                            <div class="col" <%# Convert.ToInt16(Eval("KidsPrice")) > 0 ? "":"style='display:none;'" %>>
                                                <figure><img src="assets/icons/kids.gif" alt="amusement park near me" /></figure>
                                                <div class="info_pakg">
                                                    <h4>Kids <span>Rs. <%#Eval("KidsPrice") %>/head</span></h4>
                                                    <p class="small"><%#Eval("PackageKidsPunchline1") %></p>
                                                    <h5>Kids(below <%#Eval("PackageKidsPunchline2") %> inches of height) are complimentary</h5>
                                                </div>
                                            </div>
                                            <div class="col" <%# Convert.ToInt16(Eval("AdultPrice")) > 0 ? "":"style='display:none;'" %>>
                                                <figure><img src="assets/icons/adult.gif" alt="near me water park" /></figure>
                                                <div class="info_pakg">
                                                    <h4>Adults <span>Rs. <%#Eval("AdultPrice") %>/head</span></h4>
                                                    <p class="small"><%#Eval("PackageAdultsPunchline1") %></p>
                                                </div>
                                            </div>
                                            <div class="link_btn skyblue_btn"><a href="javascript:void(0);" class="model-open modelTyepCheck bind_package" data-type="Weekdays" data-model=".Popup_Book_ParkModel"  data-Package='<%#Eval("PackageID") %>' data-name='<%#Eval("PackageTitle") %>' data-Timing='<%#Eval("PackageTimming") %>' data-Punchline='<%#Eval("PackagePunchline") %>' data-Kids='<%#Eval("KidsPrice") %>' data-KidsTAX='<%#Eval("KidsPriceTaxs") %>' data-AdultTAX='<%#Eval("AdultPriceTaxs") %>' data-Adult='<%#Eval("AdultPrice") %>'data-KidsPunchline1='<%#Eval("PackageKidsPunchline1") %>' data-KidsPunchline2='<%#Eval("PackageKidsPunchline2") %>' data-AdultsPunchline='<%#Eval("PackageAdultsPunchline1") %>'>Book Now</a></div>
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
</section>
<section>
    <div class="amusement_secF">
        <div class="container">
            <div class="heading text-center"><h3>More Services</h3></div>
            <div class="more_service_demo">
                <div class="more-service-slider owl-carousel">
                    <asp:Repeater ID="RptrRelatedEntertainmentData" runat="server">
                        <ItemTemplate>
                             <div class="item">
                                <a href="/<%#Eval("EntertainmentNameAlias")%>">
                                    <figure><img src='/AapnoGharlmages/EntertainmentImages/<%#Eval("EntertainmentDefaultImage")%>' alt='<%#Eval("EntertainmentNameAlias")%>' title='<%#Eval("EntertainmentName")%>'/></figure>
                                    <div class="srvc-nm"><h5><%#Eval("EntertainmentName")%></h5></div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>                    
                    <%--<asp:Repeater ID="RptrEatAndDrink" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <a href="/eat-and-drink-offer">
                                    <figure><img src='/AapnoGharlmages/EatAndDrinkImages/<%#Eval("EatAndDrinkDefaultImage")%>' alt='<%#Eval("EatAndDrinkAlias")%>' title='<%#Eval("EatAndDrinkName")%>'/></figure>
                                    <div class="srvc-nm"><h5><%#Eval("EatAndDrinkName")%></h5></div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>--%>
                    <div class="item">
                        <a href="/meet-and-celebrate">
                            <figure><img src="assets/images/home/img3.jpg" alt="water theme park" /></figure>
                            <div class="srvc-nm"><h5>Meeting & Celebrations</h5></div>
                        </a>
                    </div>
                    <div class="item">
                        <a href="/stay">
                            <figure><img src="assets/images/home/img4.jpg" alt="best water park" /></figure>
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
            <a class="fancylink" href="/AapnoGharlmages/GalleryImage/<%# Eval("SmallImg") %>" data-fancybox="gallery16"></a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<script type="text/javascript" src="assets/js/jquery.fancybox.js"></script>
<script type="text/javascript" src="assets/js/book-amusement-park.js"></script>
<script type="text/javascript">
    $(function () {
        $('.active_entertainment').addClass('active_header');
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
        })
        $(".view-more-img").on('click', function () {
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
        $('.activity-slider').owlCarousel({
            items: 3,
            margin: 25,
            autoplay: false,
            nav: true,
            navText: ['<img src="assets/icons/left.png" />', '<img src="assets/icons/right.png" />'],
            dots: false,
            loop: true,
            autoplayTimeout: 3000,
            responsive: {
                0: {
                    items: 1.2,
                    nav: false
                },
                675: {
                    items: 3,
                    margin: 10
                },
                991: {
                    items: 3
                },
            }
        });
        $('.testinomial-slider').owlCarousel({
            items: 3,
            margin: 25,
            autoplay: false,
            nav: false,
            navText: ['<img src="assets/icons/left.png" />', '<img src="assets/icons/right.png" />'],
            dots: true,
            loop: true,
            autoplayTimeout: 3000,
            responsive: {
                0: {
                    items: 1.2
                },
                675: {
                    items: 3,
                    margin: 10
                },
                991: {
                    items: 3
                },
            }
        });
        $('.pakage-slider').owlCarousel({
            items: 2,
            margin: 0,
            autoplay: false,
            nav: true,
            navText: ['<img src="assets/icons/left.png" />', '<img src="assets/icons/right.png" />'],
            dots: false,
            loop: false,
            autoplayTimeout: 3000,
            responsive: {
                0: {
                    items: 1,
                    nav: false,
                    dots: true
                },
                675: {
                    items: 2
                },
                991: {
                    items: 2
                },
            }
        });

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
        //tab
        $('.food_nav li a').on('click', function (e) {
            $(this).parent().addClass('active').siblings().removeClass('active');
            var datafood = $(this).attr('data-food');
            $('.food_wrapper .food_tab[data-food=' + datafood + ']').fadeIn(400).siblings().hide();
            e.preventDefault();
        });
    });
</script>
</asp:Content>
