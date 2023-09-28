<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="AapnoGharWeb.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="assets/css/fancy-box.css" />
<div class="banner gallery-banner">
    <div class="bg">
        <div class="gallery-slider owl-carousel">
            <img src="assets/images/Gallery/slideimg1.jpg" alt="nearest water park" />
            <img src="assets/images/Gallery/slideimg2.jpg" alt="water park" />
            <img src="assets/images/Gallery/slideimg3.jpg" alt="water adventure parks" />
            <img src="assets/images/Gallery/slideimg4.jpg" alt="water park resort near me" />
        </div>
    </div>
    <div class="content">
        <div class="heading text-center">
            <h1>Gallery</h1>
            <div class="custom_dots">
                <button role="button" class="owl-dot active"><span></span></button> <button role="button" class="owl-dot"><span></span></button> <button role="button" class="owl-dot"><span></span></button>
                <button role="button" class="owl-dot"><span></span></button>
            </div>
        </div>
    </div>
</div>
<section id="PnlPhotoAndVideoVideo" runat="server">
    <div class="gallery_secA">
        <div class="gallery_tab">
            <ul>
                <asp:Literal ID="ltrPhotoGallery" runat="server"></asp:Literal>
                <asp:Literal ID="ltrVideoGallery" runat="server"></asp:Literal>                
            </ul>
        </div>
        <div class="gallery_content">
            <div data-attr="image" class="tabs"  id="pnlPhotoCategory" runat="server" visible="false" style="display: block;">
                <div class="blog-content">
                    <div class="flex">
                        <asp:Repeater ID="RptrPhotoCategory" runat="server">
                            <ItemTemplate>
                                <div class="col">
                                    <figure><img src="/AapnoGharlmages/PhotoImage/<%#Eval("PhotoCategoryImage")%>" alt="<%#Eval("PhotoCategoryName")%>" title="<%#Eval("PhotoCategoryName")%>"/></figure>
                                    <div class="blog_inf"><p><%#Eval("PhotoCategoryName")%></p></div>
                                    <a class="gallery_link" href="javascript:void(0);" data-fancybox-trigger="gallery<%#Eval("PhotoCategoryID")%>"> <p>+</p></a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div data-attr="video" class="tabs" id="PnlVideoGallery" runat="server" visible="false" style="display: none;">
                <div class="blog-content">
                    <div class="flex">
                        <asp:Repeater ID="RptrVideoGallery" runat="server">
                            <ItemTemplate>
                                <div class="col">
                                    <figure><img src="/AapnoGharlmages/VideoGallery/<%#Eval("SmallImg")%>" alt="<%#Eval("GalleryTitle")%>" title="<%#Eval("GalleryTitle")%>"/></figure>
                                    <div class="blog_inf"><p><%#Eval("GalleryTitle")%></p></div>
                                    <div class="play_btn">
                                        <div class="video_icon model-open model-video" data-model=".Model_Video"  data-video="<%#Eval("VideoURL")%>?autoplay=1"><img src="assets/icons/play.png" alt="<%#Eval("GalleryTitle")%>"/></div>
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
<div class="" style="display: none;">
    <asp:Repeater ID="RptrPhotoData" runat="server">
        <ItemTemplate>
            <a class="fancylink" href="/AapnoGharlmages/PhotoImage/<%#Eval("SmallImg")%>" data-fancybox="gallery<%#Eval("PhotoCategoryID")%>"></a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<script type="text/javascript" src="/assets/js/jquery.fancybox.js"></script>
<script type="text/javascript">
    $(function () {

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
        $(".gallery_link").on('click', function () {
            fancAddNav();
        });
        function fancAddNav() {
            var left = 'assets/icons/left_black.png';
            var right = 'assets/icons/right_black.png';
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

        $('.gallery_tab ul li a').on('click', function (e) {
            var tab = $(this).attr('data-attr');
            $('.gallery_content .tabs[data-attr="' + tab + '"]').fadeIn(400).siblings().hide();
            $(this).parent('li').addClass('active').siblings().removeClass('active');
            e.preventDefault();
        });
        $('.gallery-slider').owlCarousel({
            items: 1,
            margin: 0,
            autoplay: true,
            nav: false,
            navText: ['<img src="assets/icons/left.png" />', '<img src="assets/icons/right.png" />'],
            dots: true,
            dotsContainer: '.custom_dots',
            loop: true,
            autoplayTimeout: 3000,
            responsive: {
                0: {
                    items: 1
                },
                675: {
                    items: 1
                },
                991: {
                    items: 1
                },
            }
        });
    });

    
</script>
</asp:Content>