<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="MeetAndCelebrateDetail.aspx.cs" Inherits="AapnoGharWeb.MeetAndCelebrateDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="assets/css/fancy-box.css"/>
<div class="ceremony-banner banner">
    <div class="bg">
        <asp:Literal ID="ltrBannerImage" runat="server"></asp:Literal>
    </div>
    <div class="content">
        <div class="heading text-center">
            <h1><asp:Literal ID="ltrTitle" runat="server"></asp:Literal></h1>
            <asp:Literal ID="ltrWeddeingEventSamllDescription" runat="server"></asp:Literal>
        </div>
    </div>
    <asp:Literal ID="ltrWeddeingEventVideoLink" runat="server"></asp:Literal>    
</div>
<section>
    <div class="ceremony_secA">
        <div class="container">
            <div class="flex">
                <div class="colA">
                    <div class="content">
                        <asp:Literal ID="ltrData" runat="server"></asp:Literal>
                    </div>
                    <div class="gallery_wrap" id="PnlGalleryData" runat="server" visible="false">
                        <div class="head_ttl">
                            <div class="heading"><h3>Gallery</h3></div>
                            <div class="slide_btn">
                                <div class="nmber">
                                    <span><em>1</em></span> /
                                    <p><em>5</em></p>
                                </div>
                                <div class="btn_owl">
                                    <div class="prev"><img src="assets/images/Mehndi-haldi/prev.png" alt="amusement park near me" /></div>
                                    <div class="next"><img src="assets/images/Mehndi-haldi/next.png" alt="near me water park" /></div>
                                </div>
                            </div>
                        </div>
                        <div class="gallery_demo">
                            <div class="gallery-slider owl-carousel">
                                <asp:Repeater ID="RptrGalleryData" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <figure><img src="/AapnoGharlmages/GalleryImage/<%# Eval("SmallImg") %>" alt="best water park" /></figure>
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
                                <p>Impressed & ready to get started with us? Then book us for your wedding Day and we promise you wonderful memories to cherish for lifetime.</p>
                            </div>
                            <asp:Panel ID="PanelWeddingEvent" runat="server" DefaultButton="lnkBtnSubmit">
                                <asp:UpdatePanel ID="UpdatePanelWeddingEvent" runat="server">
                                    <ContentTemplate>
                                        <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                        <div class="nav-model">
                                            <div class="enqury_form_model">
                                                <div class="form">
                                                    <div class="flex">
                                                        <div class="col">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtWeddingEventName" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <label for="ContentPlaceHolder1_txtWeddingEventName">Name<span></span></label>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtMainEmail1" runat="server" class="Open_Data" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <asp:TextBox ID="txtWeddingEventEmail" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <label for="ContentPlaceHolder1_txtWeddingEventEmail">Email<span></span></label>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtWeddingEventPhone" runat="server" class="form-control" onkeypress="return numeralsOnly(event)" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <label for="ContentPlaceHolder1_txtWeddingEventPhone">Phone<span></span></label>
                                                            </div>
                                                            <div class="form-group calender">
                                                                <input class="datepickerDefault" id="txtEventDate" type="text" runat="server" readonly/>
                                                                <label for="ContentPlaceHolder1_txtEventDate">Event Date<span></span></label>
                                                            </div>
                                                            <div class="form-group">  
                                                                <asp:TextBox ID="txtWeddingEventNameType" runat="server" class="form-control" Enabled="false" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                                                <label for="ContentPlaceHolder1_txtWeddingEventNameType" class="valid">Intersted in<span></span></label>
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
<section id="PnlRelatedWeddeingEvent" runat="server" visible="false">
    <div class="ceremony_secB">
        <div class="container">
            <div class="heading text-center"><h3>More <asp:Literal ID="ltrWeddeingEventType" runat="server"></asp:Literal></h3></div>
        </div>
        <div class="event_demo">
            <div class="event-slider owl-carousel">
                <asp:Repeater ID="RptrRelatedWeddeingEvent" runat="server">
                    <ItemTemplate>
                        <div class="item">
                            <figure><img src="/AapnoGharlmages/WeddeingEventImages/<%#Eval("WeddeingEventDefaultImage")%>" alt="<%#Eval("WeddeingEventAlias")%>" title="<%#Eval("WeddeingEventName")%>" /></figure>
                            <div class="info_slide active">
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
        $('.active_celebrate').addClass('active_header');
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
        var slide_by = 3;
        var owlSlidA = $('.gallery-slider');
        var owlAItem = owlSlidA.find('.item');
            owlSlidA.on('initialized.owl.carousel changed.owl.carousel', function(e) {
                $('.slide_btn span em').html(e.relatedTarget.relative(e.item.index) + slide_by)
                $('.slide_btn p em').html(e.item.count)
                owlAItem.each(function(i){
                    $(this).attr('data-index',i+1)
                })
            })
        owlSlidA.owlCarousel({
            items: 3,
            margin: 15,
            slideBy: slide_by,
            autoplay: false,
            nav: false,
            navText: ['<img src="assets/icons/left.png" />', '<img src="assets/icons/right.png" />'],
            dots: false,
            loop: false,
            touchDrag: false,
            mouseDrag: false,
            autoplayTimeout: 3000,
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

        // function counter(event) {
        //     if (!event.namespace) {
        //         return;
        //     }
        //     var slides = event.relatedTarget;
        //     $('.slide_btn span em').text(slides.relative(slides.current()) / 3 + 1);
        //     // $('.slide_btn p em').text(slides.items().length / 3);
        //     $('.slide_btn p em').text(event.page.count);
        // }
        $('.btn_owl .prev').click(function () {
            // $('.slide_btn span em').html(function(i, val) { return val*1-1 })
            $('.gallery-slider').trigger('prev.owl.carousel');
        })
        $('.btn_owl .next').click(function () {
            // $('.slide_btn span em').html(function(i, val) { return val*1+1 })
            $('.gallery-slider').trigger('next.owl.carousel')
            ;
        })
    });
</script>
</asp:Content>
