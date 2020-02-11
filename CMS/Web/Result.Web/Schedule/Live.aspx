<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Live.aspx.cs" Inherits="SEM.CMS.Result.Web.Schedule.Live" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1>Live Schedule <asp:Label ID="showDate" runat="server" CssClass="show-date"></asp:Label></h1>
        </div>
    </div>
    <section class="sport-overview">
        <div class="row">
            <div class="col-md-12">
                <div>
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active">
                            <div class="table-responsive">
                                <asp:GridView ID="dgSchedule" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center"
                                    AutoGenerateColumns="false"
                                    AllowPaging="false"
                                    Width="100%"
                                    OnDataBound="dgSchedule_DataBound"
                                    >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Start Time / Location" HeaderStyle-Width="15%" HeaderStyle-CssClass="start-time" ItemStyle-CssClass="start-time" >
                                            <ItemTemplate>
                                                <strong style="display:block;"><%# Convert.ToDateTime(Eval("ScheduleDateTime")).ToString("HH:mm") %></strong>
                                                <strong style="display:block;"><%# Eval("Venue") %></strong>
                                                <span style="display:block;font-weight:normal;"><%# Eval("Location") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SportName" HeaderText="Sport" HeaderStyle-Width="8%" HeaderStyle-CssClass="sport" ItemStyle-CssClass="sport" />
                                        <asp:TemplateField HeaderText="Event" HeaderStyle-Width="20%" HeaderStyle-CssClass="event" ItemStyle-CssClass="event" >
                                            <ItemTemplate>
                                                <span class="event-title" style="display:block;"><%# Eval("EventName") %></span>
                                                <span class="event-description" style="display:block;"><%# Eval("ScheduleName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:Image ID="imgIsMedalGame" runat="server" ImageUrl="~/img/schedule/champion.png" Visible='<%# Convert.ToBoolean(Eval("IsMedalGame")) %>' Width="25px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="34%" HeaderStyle-CssClass="country" ItemStyle-CssClass="country">
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
                                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="17%" HeaderStyle-CssClass="action" ItemStyle-CssClass="action">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="linkStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? false : (Eval("ScheduleStatus").ToString().Equals("Planned") ? false : true) %>' CssClass="blue-button" Text='<%# Eval("ScheduleStatus") %>' NavigateUrl='<%# String.Format("~/Event/Results.aspx?EventID={0}&ScheduleID={1}", Eval("EventID"), Eval("ScheduleID"))%>' ></asp:HyperLink>
                                                <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("ScheduleStatus") == DBNull.Value ? true : (Eval("ScheduleStatus").ToString().Equals("Planned") ? true : false) %>' CssClass="link-disabled blue-button" Text='<%# Eval("ScheduleStatus") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:HyperLink ID="linkLanding" runat="server" NavigateUrl="~/Schedule/General.aspx" Font-Underline="true">There is no on-going game at the moment. Please refer to the main schedule here.</asp:HyperLink>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th.action {
            text-align:center;
        }
        .link-disabled {
            cursor: default;
        }
    </style>
</asp:Content>
