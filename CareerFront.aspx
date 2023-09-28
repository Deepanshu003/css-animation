<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="CareerFront.aspx.cs" Inherits="AapnoGharWeb.CareerFront" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="banner career-banner">
    <div class="bg"><img src="assets/images/career/banner.jpg" alt="nearby amusement park" /></div>
    <div class="content">
        <div class="heading text-center">
            <h1>Career at AapnoGhar</h1>
            <p>Work hard, have fun & make history!</p>
        </div>
    </div>
</div>
<section>
    <div class="home_secA career_secA">
        <div class="container">
            <div class="flex">
                <div class="colA">
                    <figure><img src="assets/icons/joker.png" alt="water park ticket" /></figure>
                </div>
                <div class="colB">
                    <div class="content">
                        <div class="head_info"><h3>Why work with us ?</h3></div>
                        <div class="content">
                            <p>
                                Our success is based on teamwork, working together to have an environment based on dignity and respect across the wide variety of job roles that exist within our company. We actively encourage and promote the
                                development of employees throughout the company, nurturing and growing talented individuals to become the next generation of leaders within our business.
                            </p>
                        </div>
                        <!-- <div class="link_btn red_btn text-center"> <a href="">Read More</a> </div>-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section>
    <div class="career_secB">
        <div class="container">
            <div class="flex">
                <div class="col">
                    <div class="card">
                        <div class="head-con">
                            <img src="assets/images/career/role.png" alt="water park ticket price" />
                            <h6>Role</h6>
                        </div>
                        <div class="content"><p>Opportunity to make a real difference supplemented by great camaraderie, autonomy at work and super-fast speed to action</p></div>
                    </div>
                </div>
                <div class="col">
                    <div class="card">
                        <div class="head-con">
                            <img src="assets/images/career/leadership.png" alt="nearby water park" />
                            <h6>Leadership</h6>
                        </div>
                        <div class="content"><p>Humble, Capable and visionary leadership. Top-notch Advisory Board</p></div>
                    </div>
                </div>
                <div class="col">
                    <div class="card">
                        <div class="head-con">
                            <img src="assets/images/career/culture.png" alt="amusement water park" />
                            <h6>Culture</h6>
                        </div>
                        <div class="content"><p>High on meritocracy: You hustle, you perform, you get rewarded. Deep rooted values (DELITE – Decisive, Empathy, Lean, Innovative, Trustworthy, Excellent Customer Service)</p></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section id="PnlJobOpeningList" runat="server" visible="false">
    <div class="career_secC">
        <div class="container">
            <div class="heading text-center"><h2>Current openings</h2></div>
            <div class="tab_slid">
                <div class="content_tab">
                    <asp:Repeater ID="RptJobOpeningList" runat="server">
                        <ItemTemplate>
                            <div class="tab">
                                <div class="title <%# Container.ItemIndex == 0 ? "active":"" %>">
                                    <h6><%#Eval("JobCategoryName")%></h6>
                                    <span></span>
                                </div>
                                <div class="content" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display:none;'" %>>
                                    <p>Function: <%#Eval("JObLocation")%></p>
                                    <p>Type: <%#Eval("Experience")%></p>
                                    <p>Start Date: ASAP</p>
                                    <%#Eval("JobCategoryDiscription")%>
                                    <div class="app_btn" ><a href="javascript:void(0);" data-JobCategoryID="<%#Eval("JobCategoryID")%>">Apply Now</a></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</section>
<section id="PnlJobOpeningList1" runat="server" visible="false">
    <div class="career_secD">
        <div class="container">
            <div class="heading text-center">
                <h2>Interested in joining us?</h2>
                <p>Submit your CV, we will contact you as soon as we have relevant openings</p>
            </div>
            <div class="nav-model">
                <div class="enqury_form_model">
                    <div class="form">
                        <div class="flex">
                            <div class="col">
                                <div class="form-group">
                                    <asp:TextBox ID="txtNameCareer" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                    <label for="ContentPlaceHolder1_txtNameCareer">Name*<span></span></label>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmailIdCareer" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>       
                                    <label for="ContentPlaceHolder1_txtEmailIdCareer">Email*<span></span></label>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtContactCareer" maxlength="10" onkeypress="return numeralsOnly(event)" runat="server" class="form-control" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                                    <label for="ContentPlaceHolder1_txtContactCareer">Phone*<span></span></label>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddJobCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group message_box">
                                    <textarea type="text" class="form-control" id="textarea1" runat="server"></textarea>
                                    <label for="textarea1">Message*</label>
                                </div>
                                <div class="form-group attach_file">
                                    <input type="file" name="File" class="UpldTxt" id="UploadedCV_Career" runat="server" accept=".pdf"/>
                                    <div class="pdf"><em id="file-upload-filename">Attach Resume*</em> <img src="assets/icons/attach.png" alt="best amusement park near me" /></div>
                                </div>
                            </div>
                            <div class="submit_btn">
                                <asp:Button ID="linkbtnSubmit" runat="server" OnClick="linkbtnSubmit_Click" class="btn-form" Text="Apply Now"/>
                            </div>
                            <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<script type="text/javascript">
    $(function () {
        $('.app_btn a').on('click', function (e) {
            e.preventDefault();
            var sele = $(this).attr('data-jobcategoryid');
            $('select#ContentPlaceHolder1_ddJobCategory option').each(function () {
                if ($(this).val() == sele) {
                    $(this).prop('selected', true);
                }
                else {
                    $(this).prop('selected', false);
                }
            })
            $('body,html').animate({
                scrollTop: ($('.career_secD').offset().top - $('header').height()),
            }, 700
            );
        })
    })

    $('.content_tab .tab .title').click(function () {
        $(this).parent().siblings('.tab').children('.title').removeClass('active');
        $(this).parent().siblings('.tab').children('.content').slideUp();
        $(this).toggleClass('active');        
        $(this).siblings('.content').slideToggle();
    });

    $('.app_btn a').click(function (e) {
        console.log(e);
    });
</script>
</asp:Content>