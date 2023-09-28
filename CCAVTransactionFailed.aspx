<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="CCAVTransactionFailed.aspx.cs" Inherits="AapnoGharWeb.CCAVTransactionFailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="other-pages">
    <div class="container">
        <div class="pageWrapper">
            <div class="img"><img src="assets/icons/Loader-BIG.gif" alt="water theme park near me" /></div>
            <div class="content">
                <h1>Page Not Found</h1>                
                <p><asp:Literal ID="ltrMsg" runat="server" Text="Transaction Failed Sorry! Payment Not Successful"></asp:Literal></p>
                <ul>
                    <li><a href="mailto:info@aapnoghar.com" data-title="Email : info@napausa.org">Email : info@aapnoghar.com</a></li>
                    <li><a href="tel:+917666779997" data-title="Call Us : +1(703)599 0008">Call Us : +91-7666779997</a></li>
                </ul>
                <div class="btn"><a href="/"> Back To Home Page</a></div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
