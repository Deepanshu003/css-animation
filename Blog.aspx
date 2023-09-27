<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="AapnoGharWeb.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Blog_SecA">
    <div class="blog-content">
        <div class="flex">
            <asp:Repeater ID="RptrBlogData" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <figure><img src="/AapnoGharlmages/BlogImage/<%#Eval("SmallImg")%>" alt="<%#Eval("BlogTitleURL")%>" title="<%#Eval("BlogTitle")%>" /></figure>
                        <div class="blog_inf">
                            <span><%#Eval("PostedDate")%></span>
                            <p><%#Eval("BlogTitle")%></p>
                        </div>
                        <a class="blog_link" href="/blog/<%#Eval("BlogTitleURL")%>"></a>
                    </div>                    
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="ltrBlog" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="load_btn text-center" style="display:none;"><a href="javascript:void(0)">Load More</a></div>
</div>
</asp:Content>