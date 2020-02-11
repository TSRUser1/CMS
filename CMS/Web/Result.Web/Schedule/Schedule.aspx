<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="SEM.CMS.Result.Web.Schedule.Schedule" %>
<%@ Register TagPrefix="uc" TagName="MedalStandings" Src="~/UserControls/uscMedalStandings.ascx" %>
<%@ Register TagPrefix="uc" TagName="LiveSchedule" Src="~/UserControls/uscLiveSchedule.ascx" %>
<%@ Register TagPrefix="uc" TagName="LatestMedalist" Src="~/UserControls/uscLatestMedalist.ascx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEventMenu" Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
     
    <div class="row">
        <div class="col-md-12">
            <h1><asp:Label ID="lblHeader" runat="server" ></asp:Label></h1>

        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="panelSport" runat="server" Visible="false" CssClass="panel-sport">
                <asp:Image ID="imgSport" runat="server" CssClass="img-sport" />
                <div style="display:inline-block;">
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control ddlGender" onchange="FilterSchedule(this)" style="padding:1px 5px; height:26px;">
                    </asp:DropDownList>
                </div>
            </asp:Panel>
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-8">
            <section id="section" runat="server">
                <div class="row">
                    <div style="margin:8px">
                        <div>
                            <%--<asp:UpdatePanel ID="updatePanelContent" runat="server" EnableViewState="true" ViewStateMode="Enabled">
                                <ContentTemplate>--%>
                                    <ul id="navTabs" runat="server" class="nav nav-tabs" role="tablist" >
                                    </ul>
                                    <div id="panel-no-records" style="display:none;text-align:center;width:100%;padding-top:20px;padding-bottom:20px;">There are no records.</div>
                                    <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane active">
                                            <div class="table-responsive panel-single">
                                                <h5 style="padding-top:5px; margin:0;"><span><asp:Label ID="lblScheduleHeader" Font-Size="17px" Font-Bold="true" runat="server"></asp:Label></span></h5>
                                                <asp:GridView ID="dgSchedule" runat="server" EnableViewState="true" CssClass="table table-striped table-schedule" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                                    AutoGenerateColumns="false"
                                                    AllowPaging="false"
                                                    Width="100%"
                                                    OnDataBound="dgSchedule_DataBound"
                                                    OnRowCreated="dgSchedule_RowCreated"
                                                    >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Start Time / Location" HeaderStyle-Width="18%" HeaderStyle-CssClass="start-time" ItemStyle-CssClass="start-time" >
                                                            <ItemTemplate>
                                                                <strong style="display:block;"><%# Convert.ToDateTime(Eval("ScheduleDateTime")).ToString("HH:mm") %></strong>
                                                                <strong style="display:block;"><%# Eval("Venue") %></strong>
                                                                <span style="display:block;font-weight:normal;"><%# Eval("Location") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Event" HeaderStyle-Width="20%" HeaderStyle-CssClass="event" ItemStyle-CssClass="event" >
                                                            <ItemTemplate>
                                                                <span class="event-title" style="display:block;"><%# Eval("EventName") %></span>
                                                                <span class="event-description" style="display:block;"><%# Eval("ScheduleName") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:Image ID="imgIsMedalGame" runat="server" ImageUrl="~/img/schedule/champion.png" Visible='<%# Convert.ToBoolean(Eval("IsMedalGame")) %>' Width="25px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="36%" HeaderStyle-CssClass="country" ItemStyle-CssClass="country">
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
                                                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="19%" HeaderStyle-CssClass="action" ItemStyle-CssClass="action">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="linkStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? false : (Eval("ScheduleStatus").ToString().Equals("Planned") ? false : true) %>' CssClass="blue-button" Text='<%# Eval("ScheduleStatus") %>' NavigateUrl='<%# String.Format("~/Event/Results.aspx?EventID={0}&ScheduleID={1}", Eval("EventID"), Eval("ScheduleID"))%>' ></asp:HyperLink>
                                                                <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? true : (Eval("ScheduleStatus").ToString().Equals("Planned") ? true : false) %>' CssClass="link-disabled blue-button" Text='<%# Eval("ScheduleStatus") %>' ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <asp:Repeater ID="repeaterPanel" runat="server" OnItemDataBound="repeaterPanel_ItemDataBound" Visible="false">
                                                <ItemTemplate>
                                                    <div class="row trigger">
                                                        <div class="col-md-6 col-sm-8 col-xs-8"><h5><asp:Label ID="lblSubHeader" runat="server"></asp:Label></h5></div>
                                                        <asp:HiddenField ID="hidSportID" runat="server" Value='<%# Eval("SportID") %>' ></asp:HiddenField>
                                                        <asp:HiddenField ID="hidScheduleDate" runat="server" Value='<%# Eval("ScheduleDate") %>'></asp:HiddenField>
                                                        <div class="col-md-6 col-sm-4 col-xs-4 text-right"><asp:HyperLink ID="linkCollapse" runat="server" CssClass="controller show" href="#" ><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="../img/trigger/arrow_collapse_up.png" date-hide-image="../img/trigger/arrow_collapse_up.png" data-show-image="../img/trigger/arrow_collapse_down.png" /></asp:HyperLink></div>
                                                    </div>
                                                    <asp:Panel ID="pnlCollapsible" runat="server" CssClass="table-responsive panel-all">
                                                        <asp:GridView ID="dgScheduleAll" runat="server" EnableViewState="true" CssClass="table table-striped table-schedule" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                                            AutoGenerateColumns="false"
                                                            AllowPaging="false"
                                                            OnDataBound="dgScheduleAll_DataBound"
                                                            OnRowCreated="dgSchedule_RowCreated"
                                                            >
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Start Time / Location" HeaderStyle-Width="18%" HeaderStyle-CssClass="start-time" ItemStyle-CssClass="start-time" >
                                                                    <ItemTemplate>
                                                                        <strong style="display:block;"><%# Convert.ToDateTime(Eval("ScheduleDateTime")).ToString("HH:mm") %></strong>
                                                                        <strong style="display:block;"><%# Eval("Venue") %></strong>
                                                                        <span style="display:block;font-weight:normal;"><%# Eval("Location") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Event" HeaderStyle-Width="20%" HeaderStyle-CssClass="event" ItemStyle-CssClass="event" >
                                                                    <ItemTemplate>
                                                                        <span class="event-title" style="display:block;"><%# Eval("EventName") %></span>
                                                                        <span class="event-description" style="display:block;"><%# Eval("ScheduleName") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center" >
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="imgIsMedalGame" runat="server" ImageUrl="~/img/schedule/champion.png" Visible='<%# Convert.ToBoolean(Eval("IsMedalGame")) %>' Width="25px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" HeaderStyle-Width="36%" HeaderStyle-CssClass="country" ItemStyle-CssClass="country">
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
                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="19%" HeaderStyle-CssClass="action" ItemStyle-CssClass="action">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="linkStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? false : (Eval("ScheduleStatus").ToString().Equals("Planned") ? false : true) %>' CssClass="blue-button" Text='<%# Eval("ScheduleStatus") %>' NavigateUrl='<%# String.Format("~/Event/Results.aspx?EventID={0}&ScheduleID={1}", Eval("EventID"), Eval("ScheduleID"))%>' ></asp:HyperLink>
                                                                        <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? true : (Eval("ScheduleStatus").ToString().Equals("Planned") ? true : false) %>' CssClass="link-disabled blue-button" Text='<%# Eval("ScheduleStatus") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <script type="text/javascript">
                                        Sys.Application.add_load(BindScheduleEvents);
                                    </script>
                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <div class="col-md-4">
            <uc:MedalStandings id="uscMedalStandings" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function BindScheduleEvents()
        {
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

            if ($('.panel-sport .ddlGender').length > 0)
            {
                FilterSchedule($('.panel-sport .ddlGender'));
            }
        }

        function FilterSchedule(sender) {
            var type = $(sender).val();

            if (type == 'men') {
                $('.table-schedule tr.men').removeClass('hide');
                $('.table-schedule tr.women').addClass('hide');
                $('.table-schedule tr.mixed').addClass('hide');
            }
            else if (type == 'women') {
                $('.table-schedule tr.men').addClass('hide');
                $('.table-schedule tr.women').removeClass('hide');
                $('.table-schedule tr.mixed').addClass('hide');
            }
            else if (type == 'mixed') {
                $('.table-schedule tr.men').addClass('hide');
                $('.table-schedule tr.women').addClass('hide');
                $('.table-schedule tr.mixed').removeClass('hide');
            }
            else if (type == 'all') {
                $('.table-schedule tr.men').removeClass('hide');
                $('.table-schedule tr.women').removeClass('hide');
                $('.table-schedule tr.mixed').removeClass('hide');
            }

            var noOfTableShown = 0;

            $('.panel-all').each(function () {
                var count = $(this).find('.table-schedule > tbody > tr:not(.hide)').length;

                if (count == 0) {
                    $(this).prev().hide();
                    $(this).hide();
                }
                else {
                    $(this).prev().show();
                    $(this).show();
                    noOfTableShown++;
                }
            });

            if (noOfTableShown == 0) {
                $('#panel-no-records').show();
            }
            else {
                $('#panel-no-records').hide();
            }

            $('.panel-single').each(function () {

                if ($(this).find('.table-schedule').length == 0) {
                    return;
                }

                var count = $(this).find('.table-schedule > tbody > tr:not(.hide)').length;

                if (count == 0) {
                    $(this).hide();
                    $('#panel-no-records').show();
                }
                else {
                    $(this).show();
                    $('#panel-no-records').hide();
                }
            });
        }
    </script>
    <style>
        .link-disabled {
            cursor: default;
        }
        .nav.nav-tabs .menu-sport {
            max-height:49px;
            max-width:50px;
        }
        .nav.nav-tabs .link-sport {
            padding-top:0px;
            padding-bottom:0px;
            padding-left:4px;
            padding-right:4px;
        }
        .nav.nav-tabs .link-sport-all {
            padding-left:12px;
            padding-right:12px;
        }
        .sport-overview .trigger,
        .sport-overview-tab2 .trigger {
            padding-top:5px;
        }
        .sport-overview .trigger,
        .sport-overview-tab2 .trigger {
            font-size: 17px;
            font-weight: bold;
            vertical-align: middle;
        }
        .sport-overview .trigger h5,
        .sport-overview-tab2 .trigger h5 {
            padding-top:3px;
            font-size: 17px;
            font-weight:bold;
            margin:0;
        }
        .sport-overview .tab-content .table > tbody > tr > td, 
        .sport-overview .tab-content .table > tbody > tr > th, 
        .sport-overview .tab-content .table > tfoot > tr > td, 
        .sport-overview .tab-content .table > tfoot > tr > th, 
        .sport-overview .tab-content .table > thead > tr > td, 
        .sport-overview .tab-content .table > thead > tr > th,
        .sport-overview-tab2 .tab-content .table > tbody > tr > td, 
        .sport-overview-tab2 .tab-content .table > tbody > tr > th, 
        .sport-overview-tab2 .tab-content .table > tfoot > tr > td, 
        .sport-overview-tab2 .tab-content .table > tfoot > tr > th, 
        .sport-overview-tab2 .tab-content .table > thead > tr > td, 
        .sport-overview-tab2 .tab-content .table > thead > tr > th {
            padding:5px 5px;
            font-size:11px;
        }
        .blue-button {
            background-size:85%;
            padding-left:16px;
            margin-left:3px;
            padding-top:1px;
            width:110px;
        }
        th.action {
            text-align:center;
        }
        h1 {
            vertical-align:bottom;
        }
        h1.schedule-header {
            display:inline-block;
        }
        .panel-sport {
            display:inline-block;
            margin-bottom:10px;
        }
        .panel-sport .btn {
            vertical-align:bottom;
        }
        .panel-sport .img-sport {
            width:40px;
            margin-left:10px;
            margin-right:10px;
            vertical-align:bottom;
        }
        tr.hide {
            display:none;
        }
    </style>
</asp:Content>
