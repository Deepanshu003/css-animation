<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="BlogDetail.aspx.cs" Inherits="AapnoGharWeb.BlogDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .blog-slider .owl-item{height: fit-content;}
</style>
<div class="banner blog-detail-banner">
    <div class="bg"><asp:Literal ID="ltrImage" runat="server"></asp:Literal></div>
    <div class="content">
        <div class="heading">
            <p><asp:Literal ID="ltrDate" runat="server"></asp:Literal></p>
            <h1><asp:Literal ID="ltrName" runat="server"></asp:Literal></h1>
        </div>
        <div class="social_links">
            <ul>
                <li> <a href="javscript:void(0);" onclick="da_share.fb();"> <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512"> <path d="M279.14 288l14.22-92.66h-88.91v-60.13c0-25.35 12.42-50.06 52.24-50.06h40.42V6.26S260.43 0 225.36 0c-73.22 0-121.08 44.38-121.08 124.72v70.62H22.89V288h81.39v224h100.17V288z"></path> </svg> </a> </li>
                <li> <a href="javascript:void(0)" onclick="da_share.tw();"> <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"> <path d="M459.37 151.716c.325 4.548.325 9.097.325 13.645 0 138.72-105.583 298.558-298.558 298.558-59.452 0-114.68-17.219-161.137-47.106 8.447.974 16.568 1.299 25.34 1.299 49.055 0 94.213-16.568 130.274-44.832-46.132-.975-84.792-31.188-98.112-72.772 6.498.974 12.995 1.624 19.818 1.624 9.421 0 18.843-1.3 27.614-3.573-48.081-9.747-84.143-51.98-84.143-102.985v-1.299c13.969 7.797 30.214 12.67 47.431 13.319-28.264-18.843-46.781-51.005-46.781-87.391 0-19.492 5.197-37.36 14.294-52.954 51.655 63.675 129.3 105.258 216.365 109.807-1.624-7.797-2.599-15.918-2.599-24.04 0-57.828 46.782-104.934 104.934-104.934 30.213 0 57.502 12.67 76.67 33.137 23.715-4.548 46.456-13.32 66.599-25.34-7.798 24.366-24.366 44.833-46.132 57.827 21.117-2.273 41.584-8.122 60.426-16.243-14.292 20.791-32.161 39.308-52.628 54.253z" ></path> </svg> </a> </li>
                <li> <a href="javascript:void(0)" onclick="da_share.wp();"> <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 308 308"> <path d="M227.904,176.981c-0.6-0.288-23.054-11.345-27.044-12.781c-1.629-0.585-3.374-1.156-5.23-1.156 c-3.032,0-5.579,1.511-7.563,4.479c-2.243,3.334-9.033,11.271-11.131,13.642c-0.274,0.313-0.648,0.687-0.872,0.687 c-0.201,0-3.676-1.431-4.728-1.888c-24.087-10.463-42.37-35.624-44.877-39.867c-0.358-0.61-0.373-0.887-0.376-0.887 c0.088-0.323,0.898-1.135,1.316-1.554c1.223-1.21,2.548-2.805,3.83-4.348c0.607-0.731,1.215-1.463,1.812-2.153 c1.86-2.164,2.688-3.844,3.648-5.79l0.503-1.011c2.344-4.657,0.342-8.587-0.305-9.856c-0.531-1.062-10.012-23.944-11.02-26.348 c-2.424-5.801-5.627-8.502-10.078-8.502c-0.413,0,0,0-1.732,0.073c-2.109,0.089-13.594,1.601-18.672,4.802 c-5.385,3.395-14.495,14.217-14.495,33.249c0,17.129,10.87,33.302,15.537,39.453c0.116,0.155,0.329,0.47,0.638,0.922 c17.873,26.102,40.154,45.446,62.741,54.469c21.745,8.686,32.042,9.69,37.896,9.69c0.001,0,0.001,0,0.001,0 c2.46,0,4.429-0.193,6.166-0.364l1.102-0.105c7.512-0.666,24.02-9.22,27.775-19.655c2.958-8.219,3.738-17.199,1.77-20.458 C233.168,179.508,230.845,178.393,227.904,176.981z" /> <path d="M156.734,0C73.318,0,5.454,67.354,5.454,150.143c0,26.777,7.166,52.988,20.741,75.928L0.212,302.716 c-0.484,1.429-0.124,3.009,0.933,4.085C1.908,307.58,2.943,308,4,308c0.405,0,0.813-0.061,1.211-0.188l79.92-25.396 c21.87,11.685,46.588,17.853,71.604,17.853C240.143,300.27,308,232.923,308,150.143C308,67.354,240.143,0,156.734,0z M156.734,268.994c-23.539,0-46.338-6.797-65.936-19.657c-0.659-0.433-1.424-0.655-2.194-0.655c-0.407,0-0.815,0.062-1.212,0.188 l-40.035,12.726l12.924-38.129c0.418-1.234,0.209-2.595-0.561-3.647c-14.924-20.392-22.813-44.485-22.813-69.677 c0-65.543,53.754-118.867,119.826-118.867c66.064,0,119.812,53.324,119.812,118.867 C276.546,215.678,222.799,268.994,156.734,268.994z" /> </svg> </a> </li>
                <li> <a href="javascript:void(0)" onclick="da_share.ln();"> <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"> <path d="M100.28 448H7.4V148.9h92.88zM53.79 108.1C24.09 108.1 0 83.5 0 53.8a53.79 53.79 0 0 1 107.58 0c0 29.7-24.1 54.3-53.79 54.3zM447.9 448h-92.68V302.4c0-34.7-.7-79.2-48.29-79.2-48.29 0-55.69 37.7-55.69 76.7V448h-92.78V148.9h89.08v40.8h1.3c12.4-23.5 42.69-48.3 87.88-48.3 94 0 111.28 61.9 111.28 142.3V448z" ></path> </svg> </a> </li>
            </ul>
        </div>
    </div>
</div>
<section>
    <div class="Blog-detail_SecA">
        <div class="container">
            <div class="flex">
                <div class="colA">
                    <div class="blog_content">
                        <asp:Literal ID="ltrData" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="colB">
                    <div class="services_sec">
                        <h3 class="head_ing">Services</h3>
                        <ul>
                            <li><a href="/stay">Rooms</a></li>
                            <asp:Repeater ID="RptrEntertainmentForFooter" runat="server">
                                <ItemTemplate>
                                    <li><a href="/<%#Eval("EntertainmentNameAlias")%>"><%#Eval("EntertainmentName")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <li><a href="/meet-and-celebrate">Meeting & Celebrations</a></li>
                            <li><a href="/eat-and-drink-offer">Eat & Drink</a></li>
                            <li><a href="/packages">Packages</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section id="PnlRelatedBlogData" runat="server" visible="false">
    <div class="Blog-detail_SecB">
        <div class="container">
            <div class="heading text-center"><h4>Related blogs</h4></div>
            <div class="blogs_demo">
                <div class="blog-slider owl-carousel">
                    <asp:Repeater ID="RptrRelatedBlogData" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <figure><img src="/AapnoGharlmages/BlogImage/<%#Eval("SmallImg")%>" alt="<%#Eval("BlogTitleURL")%>" title="<%#Eval("BlogTitle")%>"/></figure>
                                <div class="blog_inf">
                                    <span><%#Eval("PostedDate")%></span>
                                    <p><%#Eval("BlogTitle")%></p>
                                </div>
                                <a class="blog_link" href="/blog/<%#Eval("BlogTitleURL")%>"></a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</section>
<script type="text/javascript">
    $(function () {
        $('.blog-slider').owlCarousel({
            loop: true,
            responsiveClass: true,
            margin: 10,
            nav: true,
            navText: ['<img src="/assets/icons/left_black.png" />', '<img src="/assets/icons/right_black.png" />'],
            rewind: true,
            dots: false,
            smartSpeed: 1500,
            responsive: {
                0: {
                    items: 1,
                },
                600: {
                    items: 3,
                },
                1000: {
                    items: 3,
                }
            }
        });
    });
</script>
<script src="<%=Page.ResolveUrl("~/assets/js/jquery.da-share.js")%>" type="text/javascript"></script>
</asp:Content>
