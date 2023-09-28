<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="AapnoGharWeb.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="banner contact-banner">
    <div class="bg"><img src="assets/images/Contact/banner.jpg" alt="water theme park" /></div>
    <div class="content">
        <div class="heading text-center"><h1>Contact us</h1></div>
    </div>
</div>
<section>
    <div class="contact_secA">
        <div class="container">
            <div class="flex">
                <div class="colA">
                    <figure><img src="assets/icons/Loader-BIG.gif" alt="best water park" /></figure>
                </div>
                <div class="colB">
                    <div class="content">
                        <div class="head_info">
                            <figure><img src="assets/icons/Apnoghar_logo_text.png" alt="nearest water park" /></figure>
                        </div>
                        <div class="address_info">
                            <div class="col">
                                <figure><img src="assets/icons/loc.png" alt="water park" /></figure>
                                <div class="inf">
                                    <p>Aapno Ghar / Airport Motel Amusement & Water Park,<br> 43rd Mile Stone , NH-8 Delhi – Jaipur Expressway, Sec-77 Gurugram, Haryana</p>
                                </div>
                            </div>
                            <div class="col">
                                <figure><img src="assets/icons/cont_call.png" alt="water adventure parks" /></figure>
                                <div class="inf"><a href="tel:+917666779997">+91 - 7666779997</a> | <a href="tel:+911242371281">0124-2371281</a>/<a href="tel:+911242371282">82</a></div>
                            </div>
                            <div class="col">
                                <figure><img src="assets/icons/cont_msg.png" alt="water park resort near me" /></figure>
                                <div class="inf">
                                    <p><a href="mailto:info@aapnoghar.com">info@aapnoghar.com</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="contact_btn">
                            <ul>
                                <li>
                                    <a href="https://goo.gl/maps/dEMAEHK7KNHr23C5A" target="_blank"><img src="assets/icons/loc.png" alt="water park near by me" /> Get Direction</a>
                                </li>
                                <li>
                                    <a href="https://api.whatsapp.com/send/?phone=7666779997&text&type=phone_number&app_absent=0" target="_blank">
                                        <img src="assets/icons/cont_wtsp.png" alt="water park near me with price" /> Talk to Aapnoghar
                                    </a>
                                    <%--<a href="https://web.whatsapp.com/send?phone=+917666779997&amp;text=Hello Team Aapno Ghar, I'm interested in one of your services. Could you please connect with me?" target="_blank">
                                        <img src="assets/icons/cont_wtsp.png" alt="" /> Talk to Aapnoghar
                                    </a>--%>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section>
    <div class="contact_secB">
        <div class="container">
            <div class="inquiry-wrapper">
                <div class="heading text-center"><h2>Contact us</h2></div>
                <asp:Panel ID="PnlNormalInquiry" runat="server" DefaultButton="btnNormalSubmit">
                    <asp:UpdatePanel ID="UpdPnlNormalInquiry" runat="server">
                        <ContentTemplate>
                            <div class="form">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNormalInquiryName" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                        <label for="ContentPlaceHolder1_txtNormalInquiryName">Name<span>*</span></label>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtMainEmail1" runat="server" class="Open_Data" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                        <asp:TextBox ID="txtNormalInquiryEmail" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                        <label for="ContentPlaceHolder1_txtNormalInquiryEmail">Email<span>*</span></label>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNormalInquiryPhone" runat="server" class="form-control" onkeypress="return numeralsOnly(event)" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                        <label for="ContentPlaceHolder1_txtNormalInquiryPhone">Phone<span>*</span></label>
                                    </div>
                                    <div class="form-group calender">
                                        <input class="datepickerDefault" type="text" id="txtNormalInquiryDate" runat="server" readonly/>
                                        <label for="ContentPlaceHolder1_txtNormalInquiryDate">Date of Visit<span>*</span></label>
                                    </div>
                                    <div class="form-group message_box">
                                        <textarea type="text" class="form-control" id="textarea1" runat="server"></textarea>
                                        <label for="ContentPlaceHolder1_textarea1">Message</label>
                                    </div>
                                    <div class="CheckboxGroup">
                                        <p>Enquiry For: <span>*</span></p>
                                        <div class="flex">
                                            <div class="col2">
                                                <div class="checkBoxGroup">
                                                    <label for="ContentPlaceHolder1_chkWaterPark">
                                                        <input type="checkbox" name="" value="Water Park" id="chkWaterPark" runat="server" />
                                                        <div class="fakeBox"><img src="assets/icons/check_iocnswn.png" alt="water theme park near me" /></div>
                                                        <span class="item-label">Water Park</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="col2">
                                                <div class="checkBoxGroup">
                                                    <label for="ContentPlaceHolder1_chkAmusementPark">
                                                        <input type="checkbox" name="" value="Amusement Park" id="chkAmusementPark" runat="server" />
                                                        <div class="fakeBox"><img src="assets/icons/check_iocnswn.png" alt="water resort near me" /></div>
                                                        <span class="item-label">Amusement Park</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="col2">
                                                <div class="checkBoxGroup">
                                                    <label for="ContentPlaceHolder1_chkFamilyHomeStay">
                                                        <input type="checkbox" name="" value="Family Home Stay" id="chkFamilyHomeStay" runat="server" />
                                                        <div class="fakeBox"><img src="assets/icons/check_iocnswn.png" alt="water park resorts" /></div>
                                                        <span class="item-label">Family Home Stay</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="col2">
                                                <div class="checkBoxGroup">
                                                    <label for="ContentPlaceHolder1_chkOthers">
                                                        <input type="checkbox" name="" value="Others" id="chkOthers" runat="server" />
                                                        <div class="fakeBox"><img src="assets/icons/check_iocnswn.png" alt="Others" /></div>
                                                        <span class="item-label">Others</span>
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="submit_btn"><asp:Button ID="btnNormalSubmit" runat="server" Text="Submit" onclick="btnNormalSubmit_Click"/></div>
                                <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                            </div>
                            <asp:HiddenField ID="hdnInterested" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </div>
        </div>
    </div>
</section>
<script type="text/javascript">
    $('.inquiry-wrapper .checkBoxGroup input[type="checkbox"]').on('change', function () {
        var arr1 = new Array();
        var $this = $(this);
        $('.inquiry-wrapper .checkBoxGroup input:checked').each(function () {
            arr1.push($(this).val())
        })
        $('#ContentPlaceHolder1_hdnInterested').val(arr1.toString());
    });
</script>
</asp:Content>