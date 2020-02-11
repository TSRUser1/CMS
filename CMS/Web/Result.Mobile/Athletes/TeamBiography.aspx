<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="TeamBiography.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Athletes.TeamBiography" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <div class="container">
        <div class="row">
            <section class="athletes-profile">
                <div class="col-md-12">
                    <div>
                        <table style="width:100%">
                            <tr>
                                <td>
                                    <h2>
                                        <asp:HyperLink ID="linkCountryImage" runat="server">
                                            <asp:Image ID="imgCountry" runat="server" />
                                        </asp:HyperLink>
                                        &nbsp;
                                        <asp:HyperLink ID="linkCountryLabel" runat="server">
                                            <asp:Label ID="lblNPC" runat="server"></asp:Label>
                                        </asp:HyperLink>
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="dgTeam" CssClass="table table-striped" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center" UseAccessibleHeader="true" runat="server" Style="margin-bottom: 0" OnPreRender="dgTeam_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="country" HeaderStyle-CssClass="country">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgParticipantMedal" runat="server" ImageUrl='<%# Eval("CardPhotoPathThumbnail") %>'/>
                                                    <asp:HyperLink ID="linkFullName" runat="server" NavigateUrl='<%# String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantID")) %>'>
                                                        <asp:Label ID="lblFullName" Text=' <%# DataBinder.Eval(Container.DataItem,"FullName") %>' runat="server"></asp:Label>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-CssClass="dob" HeaderStyle-CssClass="dob" DataField="DateOfBirth" DataFormatString="{0:dd MMM yyyy}" HeaderText="Birth Date" />
                                        </Columns>
                                    </asp:GridView>
                                    <br/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="dgTeamEventMedal" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center" Style="margin-bottom: 0"
                                        AutoGenerateColumns="false"
                                        AllowPaging="false"
                                        Width="100%"
                                        OnPreRender="dgTeamEventMedal_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="SportName" HeaderText="Sport"  HeaderStyle-Width="50%" HeaderStyle-CssClass="sport" ItemStyle-CssClass="sport" />
                                            <asp:BoundField DataField="EventName" HeaderText="Event"  HeaderStyle-Width="50%" HeaderStyle-CssClass="event" ItemStyle-CssClass="event" />
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="10%" HeaderStyle-CssClass="medal" ItemStyle-CssClass="medal">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgParticipantMedal" runat="server" ImageUrl='<%# Eval("MedalImageFilePath") %>' AlternateText='<%# Eval("Medal") %>' ToolTip='<%# Eval("Medal") %>' Visible='<%# Eval("Medal") != DBNull.Value ? true : false%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br/>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </section>
        </div>
        <div class="row">
            <section class="athletes-profile">
                <div class="col-md-12">
                    <div>
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
                                                            <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
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
                                                            <td style="vertical-align:middle;padding-bottom:5px;padding-left:2px;padding-right:2px;">
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
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
