<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Biography.aspx.cs" Inherits="SEM.CMS.Result.Web.Athletes.Biography" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server"><asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: rgba(0,0,0,0.5);">
            <div style="padding: 10px; position:fixed; top:50%; left:50%; background-color:#fff; width:84px; margin-top:-42px; margin-left:-42px; border-radius:10px;">
                <img id="imgLoading" runat="server" src="~/img/loading/loading.gif" alt="Loading ..." title="Loading..."  />
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
    <asp:UpdatePanel ID="updatePanelContent" runat="server">
        <ContentTemplate>
            <div class="row">
            <div class="col-md-12"><h1>Search Athletes</h1></div>
            </div>
            <asp:Panel ID="panelSearch" runat="server" CssClass="row panel-search">
            
                <div class="col-md-4 form-group">
                    <span class="label-search">Name</span>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control txtName"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <span class="label-search">Country</span>
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control ddlCountry"></asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <span class="label-search">Discipline</span>
                    <asp:DropDownList ID="ddlDiscipline" runat="server" CssClass="form-control ddlDiscipline"></asp:DropDownList>
                </div>
                <div class="col-md-12 form-group">
                    <asp:Button ID="btnSearch" runat="server" OnClientClick="return ValidateSearch();" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-default" />
                </div>
                <div class="col-md-12 form-group">
                    <span style="font-size:12px;font-size: 1.2rem;">* Athletes are pending confirmation</span>
                </div>
            </asp:Panel>
            <asp:Panel ID="panelSearchResult" runat="server" CssClass="row panel-search">
                <div class="col-md-12 panel-top-border-outer">
                    <div class="panel-top-border-inner"></div>
                </div>
                <div class="trigger search-result-header">
                    <div class="col-md-6 col-sm-8 col-xs-8">
                        <h1><span>Search Results <asp:Label ID="lblSearchCount" runat="server"></asp:Label></span></h1>
                    </div>
                    <div class="col-md-6 col-sm-4 col-xs-4 text-right link-hide-search"><asp:HyperLink ID="linkCollapseSearch" runat="server" CssClass="controller show" href="#" ><span data-hide-string="Hide" data-show-string="Show All Results">Hide</span> <img src="../img/trigger/arrow_collapse_up.png" date-hide-image="../img/trigger/arrow_collapse_up.png" data-show-image="../img/trigger/arrow_collapse_down.png" /></asp:HyperLink></div>
                </div>
                <div class="col-md-12">
                    <asp:Panel ID="panelSearchResultList" runat="server">
                        <asp:ListView ID="listParticipant" runat="server" OnItemCommand="listParticipant_ItemCommand" GroupPlaceholderID="groupPlaceHolder" ItemPlaceholderID="itemPlaceholder" GroupItemCount="4" >
                            <LayoutTemplate>
                                <div runat="server" id="groupPlaceHolder"></div>
                            </LayoutTemplate>
                            <GroupTemplate>
                                <div class="container list-participant">
                                    <div class="row">
                                        <div runat="server" id="itemPlaceholder"></div>
                                    </div>
                                </div>
                            </GroupTemplate>
                            <ItemTemplate>
                               <div class="col-md-3 col-sm-6 col-xs-6 " style="min-width:120px;height:100px;" >
                                    <asp:HiddenField ID="hidParticipantID" runat="server" Value='<%# Eval("ParticipantID") %>' />
                                    <div class="sport-name width400" ><%# Eval("SportName") %></div>
                                    <div style="float:left;width:46px">
                                        <img id="imgSport" runat="server" src='<%# Eval("ParticipantImageFilePathTB") %>' class="player" /></div>
                                    <div class="player-info width_400" style="float:left;">
                                        <a id="linkCountry" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>'><img id="imgCountry" src='<%# Eval("SmallIconFilePath") %>' runat="server" alt='<%# Eval("CountryName") %>' title='<%# Eval("CountryName") %>' /></a>
                                        <asp:LinkButton ID="btnFullName" runat="server" CommandArgument="select" Text='<%# Eval("FullName") %>' Font-Underline="true" OnClientClick="SetCollapeSearchFlag(true)" CssClass="link-participant" ToolTip='<%# Eval("FullName") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                No records found.
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </asp:Panel>
                </div>
                </br>
            </asp:Panel>
            <asp:Panel ID="panelParticipantDetail" runat="server" CssClass="row" Visible="false">
                <asp:Panel ID="panelAthletesProfileBorder" runat="server" CssClass="col-md-12 panel-top-border-outer panel-athletes-profile-border">
                    <div class="panel-top-border-inner"></div>
                </asp:Panel>
                <div id="divSelectedParticipantID">
                    <asp:HiddenField ID="hidSelectedParticipantID" runat="server" />
                </div>
                <div id="divSelectedParticipantName">
                    <asp:HiddenField ID="hidSelectedParticipantName" runat="server" />
                </div>
                <div>
                    <section class="col-md-12 athletes-profile">
                        <div class="row">
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <h1><asp:Label ID="lblName" runat="server"></asp:Label></h1>
                                <h2>
                                    <asp:HyperLink ID="linkCountryImage" runat="server">
                                        <asp:Image ID="imgCountry" runat="server" />
                                    </asp:HyperLink>
                                    &nbsp;
                                    <asp:HyperLink ID="linkCountryLabel" runat="server">
                                        <asp:Label ID="lblNPC" runat="server"></asp:Label>
                                    </asp:HyperLink>
                                </h2>
                                <div class="profile table-responsive">
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <th>Birth Date</th>
                                                <th></th>
                                                <th>Gender</th>
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="lblDateOfBirth" runat="server"></asp:Label></td>
                                                <td></td>
                                                <td><asp:Label ID="lblGender" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th>Height (cm)</th>
                                                <th>Weight (Kg)</th>
                                                <th>Age</th>
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="lblHeight" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblWeight" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblAge" runat="server"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="social-media">
                                    <ul>
                                        <li class="ic-facebook"><a href="#" onclick="facebookShareParticipantClick(600,500)"></a></li>
                                        <li class="ic-twitter"><a href="#" onclick="twitterShareParticipantClick(600,500)"></a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:Image ID="imgParticipant" runat="server" class="athletes-image" />
                            </div>
                            <div>
                                <div class="col-md-12 table-responsive" style="overflow-x:visible!important">
                                    <asp:GridView ID="dgParticipantEvent" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                        AutoGenerateColumns="false"
                                        AllowPaging="false"
                                        Width="100%"
                                        OnPreRender="dgParticipantEvent_PreRender"
                                        >
                                        <Columns>
                                            <asp:BoundField DataField="SportName" HeaderText="Sport"  HeaderStyle-Width="30%" HeaderStyle-CssClass="sport" ItemStyle-CssClass="sport" />
                                            <asp:BoundField DataField="EventName" HeaderText="Event"  HeaderStyle-Width="40%" HeaderStyle-CssClass="event" ItemStyle-CssClass="event" />
                                            <%--<asp:TemplateField HeaderText="Event" HeaderStyle-Width="70%" HeaderStyle-CssClass="event" ItemStyle-CssClass="event">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="linkResult" runat="server" NavigateUrl='<%# String.Format("/Event/Results.aspx?EventID={0}&ScheduleID={1}", Eval("EventID"), Eval("ScheduleID"))%>' Text='<%# Eval("EventName") %>'></asp:HyperLink>&nbsp;
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="SportClassCode" HeaderText="Sport Class"  HeaderStyle-Width="10%" HeaderStyle-CssClass="sport-class" ItemStyle-CssClass="sport-class" />
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="10%" HeaderStyle-CssClass="medal" ItemStyle-CssClass="medal">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgParticipantMedal" runat="server" ImageUrl='<%# Eval("MedalImageFilePath") %>' AlternateText='<%# Eval("Medal") %>' ToolTip='<%# Eval("Medal") %>' Visible='<%# Eval("Medal") != DBNull.Value ? true : false%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Repeater ID="rptEvent" runat="server" OnItemDataBound="rptEvent_ItemDataBound" >
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hidScheduleDate" runat="server" Value='<%# Eval("ScheduleDate") %>' />
                                        <div class="row trigger">
                                            <div class="col-md-6 col-sm-8 col-xs-8"><h5><asp:Label ID="lblDate" runat="server" Text='<%# ((DateTime)Eval("ScheduleDateTime")).DayOfWeek + ", " + ((DateTime)Eval("ScheduleDateTime")).ToString("MMM dd") %>'></asp:Label></h5></div>
                                            <div class="col-md-6 col-sm-4 col-xs-4 text-right"><asp:HyperLink ID="linkCollapse" runat="server" CssClass="controller show" href="#" ><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="../img/trigger/arrow_collapse_up.png" date-hide-image="../img/trigger/arrow_collapse_up.png" data-show-image="../img/trigger/arrow_collapse_down.png" /></asp:HyperLink></div>
                                        </div>
                                        <asp:Panel ID="panelEvent" runat="server" CssClass="table-responsive player-results">
                                            <asp:GridView ID="dgParticipantSchedule" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                                AutoGenerateColumns="false"
                                                AllowPaging="false"
                                                OnDataBound="dgParticipantSchedule_DataBound"
                                                >
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Start Time / Location" HeaderStyle-Width="20%" HeaderStyle-CssClass="start-time" ItemStyle-CssClass="start-time" >
                                                        <ItemTemplate>
                                                            <strong style="display:block;"><%# Convert.ToDateTime(Eval("ScheduleDateTime")).ToString("HH:mm") %></strong>
                                                            <strong style="display:block;"><%# Eval("Venue") %></strong>
                                                            <span style="display:block;font-weight:normal;"><%# Eval("Location") %></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Event" HeaderStyle-Width="22%" HeaderStyle-CssClass="event" ItemStyle-CssClass="event" >
                                                        <ItemTemplate>
                                                            <span class="event-title"><%# Eval("EventName") %></span>
                                                            <span class="event-description"><%# Eval("ScheduleName") %></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center" >
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgIsMedalGame" runat="server" ImageUrl="~/img/schedule/champion.png" Visible='<%# Convert.ToBoolean(Eval("IsMedalGame")) %>' Width="25px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="43%" HeaderStyle-CssClass="country" ItemStyle-CssClass="country">
                                                        <ItemTemplate>
                                                            <table style="vertical-align:middle;text-align:left;">
                                                                <colgroup>
                                                                    <col style="width:50px;">
                                                                    <col style="width:80%;vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                    <col style="width:10%;vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                    <col style="width:10%;vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                </colgroup>
                                                                <tr id="trPlayer1" runat="server">
                                                                    <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                        <a id="linkCountry1" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID1")) %>'>
                                                                            <img id="pnlImgCountry1" runat="server" src='<%# Eval("FlagImageFilePath1") %>' Visible='<%# Eval("FlagImageFilePath1") != DBNull.Value ? true : false%>' title='<%# Eval("CountryName1") %>' alt='<%# Eval("CountryName1") %>' />
                                                                        </a>
                                                                    </td>
                                                                    <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                        <asp:Panel ID="pnlTeam1" runat="server" Visible='<%# !(Eval("TeamName1") == DBNull.Value) && !Convert.ToBoolean(Eval("IsIndividualGame")) %>' style="display:inline-block;">
                                                                            <a id="linkTeam1" runat="server" href='<%# String.Format("~/Athletes/TeamBiography.aspx?TeamID={0}", Eval("TeamID1")) %>'>
                                                                                <%# Eval("TeamName1") %>
                                                                            </a>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlPlayer1" runat="server" Visible='<%# !(Eval("FullName1") == DBNull.Value) || Convert.ToBoolean(Eval("IsIndividualGame")) %>' style="display:inline-block;">
                                                                            <a id="linkPlayer1" runat="server" href='<%# String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantID1")) %>'>
                                                                                <%# Eval("FullName1") %>
                                                                            </a>
                                                                        </asp:Panel>
                                                                    </td>
                                                                    <td style="vertical-align:middle;text-align:right;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                        <asp:Panel ID="pnlScoreFinal1" runat="server" Visible='<%# !(Eval("ScoreFinal1") == DBNull.Value)%>' style="display:inline-block;"><span><%# Eval("ScoreFinal1") %></span></asp:Panel>
                                                                    </td>
                                                                    <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                        <asp:Panel ID="pnlBreakRecord" runat="server" Visible='<%# !(Eval("BreakRecord") == DBNull.Value)%>' style="display:inline-block;"><span><%# Eval("BreakRecord") %></span></asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trPlayer2" runat="server" Visible='<%# Convert.ToBoolean(Eval("HeadToHead"))%>'>
                                                                    <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                        <a id="linkCountry2" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID2")) %>'>
                                                                            <img id="pnlImgCountry2" runat="server" src='<%# Eval("FlagImageFilePath2") %>' Visible='<%# Eval("FlagImageFilePath2") != DBNull.Value ? true : false%>' title='<%# Eval("CountryName2") %>' alt='<%# Eval("CountryName2") %>' />
                                                                        </a>
                                                                    </td>
                                                                    <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                        <asp:Panel ID="pnlTeam2" runat="server" Visible='<%# !(Eval("TeamName2") == DBNull.Value) && !Convert.ToBoolean(Eval("IsIndividualGame")) %>' style="display:inline-block;">
                                                                            <a id="linkTeam2" runat="server" href='<%# String.Format("~/Athletes/TeamBiography.aspx?TeamID={0}", Eval("TeamID2")) %>'>
                                                                                <%# Eval("TeamName2") %>
                                                                            </a>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlPlayer2" runat="server" Visible='<%# !(Eval("FullName2") == DBNull.Value) || Convert.ToBoolean(Eval("IsIndividualGame")) %>' style="display:inline-block;">
                                                                            <a id="linkPlayer2" runat="server" href='<%# String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantID2")) %>'>
                                                                                <%# Eval("FullName2") %>
                                                                            </a>
                                                                        </asp:Panel>
                                                                    </td>
                                                                    <td style="vertical-align:middle;text-align:right;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                        <asp:Panel ID="pnlScoreFinal2" runat="server" Visible='<%# !(Eval("ScoreFinal2") == DBNull.Value)%>' style="display:inline-block;"><span><%# Eval("ScoreFinal2") %></span></asp:Panel>
                                                                    </td>
                                                                    <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="12%" HeaderStyle-CssClass="action" ItemStyle-CssClass="action">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="linkStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? false : (Eval("ScheduleStatus").ToString().Equals("Planned") ? false : true) %>' CssClass="blue-button" Text='<%# Eval("ScheduleStatus") %>' NavigateUrl='<%# String.Format("~/Event/Results.aspx?EventID={0}&ScheduleID={1}", Eval("EventID"), Eval("ScheduleID"))%>' ></asp:HyperLink>
                                                            <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? true : (Eval("ScheduleStatus").ToString().Equals("Planned") ? true : false) %>' CssClass="link-disabled blue-button" Text='<%# Eval("ScheduleStatus") %>' ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="dgParticipantEvent" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                                AutoGenerateColumns="false" Visible="false"
                                                AllowPaging="false"
                                                Width="100%"
                                                >
                                                <Columns>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="legend table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr><th colspan="2" style="text-decoration:underline">Legend</th></tr>
                                        </thead>
                                        <tbody>
                                            <tr><td><strong>WR:</strong> World Record</td><td><strong>DNS:</strong> Did Not Start</td></tr>
                                            <tr><td><strong>AR:</strong> Asian Record</td><td><strong>DNF:</strong> Did Not Finish</td></tr>
                                            <tr><td><strong>GR:</strong> Games Record</td><td><strong>DSQ:</strong> Disqualified</td></tr>
                                            <tr><td><strong>PB:</strong> Personal Best</td><td></td></tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </asp:Panel>
            <script type="text/javascript">
                Sys.Application.add_load(BindEvents);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var isCollapseFlag;

        function facebookShareParticipantClick(width, height) {
            var participantID = $("#divSelectedParticipantID > input").val();
            var leftPosition, topPosition;
            leftPosition = (window.screen.width / 2) - ((width / 2) + 10);
            topPosition = (window.screen.height / 2) - ((height / 2) + 50);
            var windowFeatures = "status=no,height=" + height + ",width=" + width + ",resizable=yes,left=" + leftPosition + ",top=" + topPosition + ",screenX=" + leftPosition + ",screenY=" + topPosition + ",toolbar=no,menubar=no,scrollbars=no,location=no,directories=no";
            u = location.href.split('?')[0].replace("#", "") + "?AthleteID=" + participantID;
            t = document.title;
            window.open('http://www.facebook.com/sharer.php?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t), 'sharer', windowFeatures);
            return false;
        }

        function twitterShareParticipantClick(width, height) {
            var participantID = $("#divSelectedParticipantID > input").val();
            var participantName = $("#divSelectedParticipantName > input").val();
            var leftPosition, topPosition;
            leftPosition = (window.screen.width / 2) - ((width / 2) + 10);
            topPosition = (window.screen.height / 2) - ((height / 2) + 50);
            var windowFeatures = "status=no,height=" + height + ",width=" + width + ",resizable=yes,left=" + leftPosition + ",top=" + topPosition + ",screenX=" + leftPosition + ",screenY=" + topPosition + ",toolbar=no,menubar=no,scrollbars=no,location=no,directories=no";
            u = location.href.split('?')[0].replace("#", "") + "?AthleteID=" + participantID;
            t = document.title;
            var sText = "Support " + participantName + " at %23APG2015";
            window.open('http://twitter.com/share?text=' + sText + '&url=' + u, 'sharer', windowFeatures);
            return false;
        }

        function BindEvents() {
            var hideString = "Hide";
            var showString = "Show";
            $(".controller").unbind().bind("click touchstart", function (e) {
                e.preventDefault();
                var panelId = $(this).attr("data-panel-id");
                var hideString = $("span", this).attr("data-hide-string");
                var showString = $("span", this).attr("data-show-string");
                var hideImage = $("img", this).attr("data-hide-image");
                var showImage = $("img", this).attr("data-show-image");
                if ($(this).hasClass("show")) {
                    $("span", this).html(showString);
                    $("img", this).attr("src", showImage);
                    $(this).removeClass("show");
                    $("#" + panelId).animate({ height: ["toggle", "swing"] }, 500);
                } else {
                    $("span", this).html(hideString);
                    $("img", this).attr("src", hideImage);
                    $(this).addClass("show");
                    $("#" + panelId).animate({ height: ["toggle", "swing"] }, 500);
                }
            });

            if (isCollapseFlag)
            {
                $('.link-hide-search .controller').click();
                isCollapseFlag = false;
            }
        }

        function SetCollapeSearchFlag(flag) {
            isCollapseFlag = flag;
        }

        function ValidateSearch() {
            var txtName = document.getElementsByClassName('txtName');
            var ddlCountry = document.getElementsByClassName('ddlCountry');
            var ddlDiscipline = document.getElementsByClassName('ddlDiscipline');

            if (txtName[0].value.trim().length < 3 && ddlCountry[0].value === "-1" && ddlDiscipline[0].value === "-1") {
                alert('Your search must include at least 3 characters for athlete name, or select a country, or select a discipline.');
                return false;
            }

            return true;
        }
    </script>
    <style>
        @media (max-width: 440px) {
            .width400 {height:40px;
            }
            .player-info{max-width:50%!important;min-height:60px;}
            .sport-name {height:40px;
            }
        }
        @media (max-width: 367px) {
             .sport-name {height:40px;
            }
             .player-info{max-width:50%!important;min-height:60px;}
        }
        @media (max-width: 480px) {
            .panel-search {
                max-width: 100%;
            }
        }
        .panel-top-border-outer {
            display:block;
            height:1px;
            padding-left:15px;
            padding-right:15px;
        }
        .panel-top-border-inner {
            background-color:#e4e4e4;
            display:block;
            height:1px;
        }
        .search-result-header {
            display:inline-block;
            width:100%;
        }
        .link-hide-search {
            margin-top:22px;
        }
        .result-block {
            padding-bottom:5px;
        }
        .player-info {
            display:inline-block;
            max-width:70%;
            min-height:60px;
        }
        .list-participant .player {
            vertical-align:top;
        }
        .player-info .country {
            overflow: hidden;
            white-space:nowrap;
            text-overflow:ellipsis;
            max-width:100%;
            display:inline-block;
        }
        .panel-athletes-profile-border {
            margin-bottom:15px;
        }
        .athletes-image {
            margin-top:20px;
            margin-bottom:15px;
        }
        th.action {
            text-align:center;
        }
        .link-disabled {
            cursor: default;
        }
        .link-participant {
            display:inline-block;
            white-space:nowrap;
            width:100%;
            text-overflow:ellipsis;
            overflow-x:hidden;
        }
    </style>
</asp:Content>

