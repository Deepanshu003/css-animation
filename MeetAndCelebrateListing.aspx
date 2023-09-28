<%@ Page Title="" Language="C#" MasterPageFile="~/AapnoGharWebMaster.Master" AutoEventWireup="true" CodeBehind="MeetAndCelebrateListing.aspx.cs" Inherits="AapnoGharWeb.MeetAndCelebrateListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section id="pnlWeddeingEventType" runat="server" visible="false">
    <div class="home_secE meetANDCelebra">
        <div class="secE-wrapper">
            <div class="container">
                <div class="heading text-center">
                    <h3><span>Meeting & Celebrations</span> Start Planning</h3>
                    <p>Experience personalized services and hospitality to celebrate your next event. AapnoGhar is an ideal venue for wedding functions, corporate outings, picnics and other events/get-togethers. Our experienced and professional team will handle each detail and do all work necessary to entertain your group. There are various well manicured lawns and a banquet hall for organizing parties like kitties, birthdays, family picnics and more. We offer excellent peripheral arrangements like catering, flower decoration, DJ with dance floor and lighting. We also have special packages for large groups.</p>
                </div>
                <div class="upper_nav">
                    <ul>
                        <asp:Repeater ID="RptrWeddeingEventType" runat="server">
                            <ItemTemplate>
                                <li <%# Container.ItemIndex == 0 ? "class='active'":"" %> data-tab='car-<%#Eval("WeddeingEventType").ToString().ToLower().Replace(" ", "-").Replace("&", "and") %>'>
                                    <%# Convert.ToString(Eval("WeddeingEventType")) == "Wedding Ceremony" ? "<img src='assets/icons/hrt_ico.png'/>":"" %>
                                    <%# Convert.ToString(Eval("WeddeingEventType")) == "Corporate Events" ? "<img src='assets/icons/mic_ico.png'/>":"" %>
                                    <%# Convert.ToString(Eval("WeddeingEventType")) == "Venues" ? "<img src='assets/icons/venues_ico.png'/>":"" %>                                    
                                    <a href="Javascript:void(0)"><%#Eval("WeddeingEventType") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="event_wrapper">
                <div class="container">
                    <asp:Repeater ID="RptrWeddeingEventType1" runat="server">
                        <ItemTemplate>
                            <div class="event_demo" data-tab="car-<%#Eval("WeddeingEventType").ToString().ToLower().Replace(" ", "-").Replace("&", "and") %>" <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display:none;'" %>>
                                <asp:HiddenField ID="hndWeddeingEventType" Value='<%#Eval("WeddeingEventType")%>' Visible="false" runat="server" />
                                <div class="ListofEvents">
                                    <div class="flex">
                                        <asp:Repeater ID="RptrWeddeingEventData" runat="server">
                                            <ItemTemplate>
                                                <div class="col">
                                                    <div class="item">
                                                        <figure><img src="/AapnoGharlmages/WeddeingEventImages/<%#Eval("WeddeingEventDefaultImage")%>" alt="<%#Eval("WeddeingEventAlias")%>" title="<%#Eval("WeddeingEventName")%>" /></figure>
                                                        <div class="info_slide <%# Container.ItemIndex == 0 ? "active":"" %>">
                                                            
                                                            <h4><%#Eval("WeddeingEventName")%></h4>
                                                            <%# Convert.ToString(Eval("WeddeingEventSamllDescription")) != "" ? "<p>"+Eval("WeddeingEventSamllDescription")+"</p>":"" %>     
                                                        </div>
                                                        <a href="/<%#Eval("WeddeingEventAlias")%>"></a>
                                                        <%# Convert.ToString(Eval("WeddeingEventVideoLink")) != "" ? "<div class='video_icon model-video model-open' data-model='.Model_Video' data-video='"+Eval("WeddeingEventVideoLink")+"?autoplay=1;rel=0'><img src='assets/icons/play.png' alt='' /></div>":"" %>                                        
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- <div class="link_btn red_btn"><a class="btn model-open" data-model=".enqury_model" href="javascript:void(0)">Book Now</a></div> -->
        </div>
    </div>
</section>
<script type="text/javascript">   
    $(function () {
        $('.active_celebrate').addClass('active_header');
    });
</script>
</asp:Content>
