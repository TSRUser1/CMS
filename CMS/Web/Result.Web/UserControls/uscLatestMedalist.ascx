<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uscLatestMedalist.ascx.cs" Inherits="SEM.CMS.Result.Web.UserControls.uscLatestMedalist" %>
<div class="table-responsive" style="overflow: hidden">

    <script type="text/javascript">

            $('#myCarousel').carousel({
                interval: 5000
            })
            $('#myCarousel').bind('slide', function () {

            });
        });

    </script>

    <style>

    .title{margin: 0;font-size: 18px; font-weight: bold; vertical-align: middle; padding: 10px 15px;color:#fff;}

    .title> a{color:#fff;}

    .dvFooter{line-height:35px;text-align:left;background-color:#ececec;padding-left:5px;}

    .dvFirst{width: 25%; height: 100%; padding-left: 5px!important; padding-right: 5px!important;}

    .dvSecond{width: 51%; height: 100%; padding-left: 5px!important; padding-right: 5px!important;}

    .dvThird{width: 24%; height: 100%; padding-left: 5px!important; padding-right: 5px!important;}

    </style>

    <div class="body-content-wrapper">
        <div class="orange-62-header">
            <h3 class="title">
                <a href='<%= String.Format("../Medal/Medallist.aspx?PageMode=Daily&date={0}", DateTime.Now.ToString("yyyy-MM-dd")) %>'>
                    Latest Medallist<b class="arrow-right"></b>
                </a>
            </h3>
        </div>

        <!--Repeater No records -->
        <asp:Panel ID="dvFooter" runat="server" class="dvFooter"> 
            <span> No record.</span>
        </asp:Panel>

        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner" role="listbox" style="height: auto; margin-top: 6px">
                <asp:Repeater ID="dgLatestMedallist" runat="server">
                    <ItemTemplate>
                        <div class="item <%# (Container.ItemIndex == 0 ? "active" : "") %>" style="height: 95px;">
                            <div class="col-sm-4 col-xs-4 latest-medalist dvFirst">
                                <img id="playerImg" runat="server" src='<%# Eval("ParticipantImageFilePath")%>' class="player" visible='<%# Convert.ToBoolean(Eval("IsIndividualGame")) %>' />
                                <a id="linkCountryTeam" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>' visible='<%# !Convert.ToBoolean(Eval("IsIndividualGame")) %>'>
                                    <img id="countryImgTeam" runat="server" src='<%# Eval("ParticipantCountryImageFilePath")%>' alt='<%# Eval("CountryName")%>' title='<%# Eval("CountryName")%>' />
                                </a>
                            </div>
                            <div class="col-sm-4 col-xs-4 latest-medalist dvSecond">
                                <a id="linkCountry" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>' visible='<%# Convert.ToBoolean(Eval("IsIndividualGame")) %>'>
                                    <img id="countryImg" runat="server" src='<%# Eval("ParticipantCountryImageFilePath")%>' alt='<%# Eval("CountryName")%>' title='<%# Eval("CountryName")%>' />
                                </a>
                                <br />
                                <a id="linkParticipant" runat="server" href='<%# String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantOrTeamID")) %>' visible='<%# Convert.ToBoolean(Eval("IsIndividualGame")) %>'>
                                    <span class="player-name"><%# Eval("ParticipantOrTeamName")%></span>
                                </a>
                                <a id="linkTeam" class="player-name" runat="server" href='<%# String.Format("~/Athletes/TeamBiography.aspx?TeamID={0}", Eval("ParticipantOrTeamID")) %>' visible='<%# !Convert.ToBoolean(Eval("IsIndividualGame")) %>'>
                                    <span class="player-name"><%# Eval("ParticipantOrTeamName")%></span>
                                </a>
                            </div>
                            <div class="col-sm-4 col-xs-4 latest-medalist dvThird" >
                                <img id="sportImg" class="player" runat="server" src='<%#Eval("SportImageFilePath") == DBNull.Value ? "" : Eval("SportImageFilePath").ToString().Replace(".png", "_small.png") %>' alt='<%# Eval("SportName")%>' title='<%# Eval("SportName")%>'  />
                            </div>
                        </div>
                    </ItemTemplate>
                   
                </asp:Repeater>
            </div>
        </div>

    </div>

</div>
