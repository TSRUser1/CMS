<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Event.EventList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="SubMenu" Src="~/UserControls/ucSubMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="SelectedGame" Src="~/UserControls/ucSelectedGame.ascx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
    <uc:SubMenu ID="SubMenu" runat="server" />
    <uc:SelectedGame ID="SelectedGame" runat="server" />
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderRWeb">
    <section class="athletes-profile">
        <div class="row">
            <asp:DataList ID="dlSportList" runat="server" Style="padding: 0px!important" OnItemDataBound="dlSportList_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-12">
                        <div class="row trigger grey-bg">
                            <div class="col-md-6">
                                <h5>
                                    <a href='<%# DataBinder.Eval(Container.DataItem, "SportID", "../Schedule/Schedule.aspx?sportid={0}") %>'>
                                        <asp:Label ID="txtSport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SportName") %>'></asp:Label></a>
                                </h5>
                            </div>
                            <div class="col-md-6 text-right">
                                <a class="controller show" href="#" data-panel-id='<%# String.Format("result-{0}", Container.ItemIndex) %>'><span data-hide-string="Hide" data-show-string="Show">Hide</span>
                                    <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a>
                            </div>
                        </div>
                        <br />
                        <div class="table-responsive player-results" id='<%# String.Format("result-{0}", Container.ItemIndex) %>'>
                            <table border="0" style="padding: 0px 5px;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="dlEventListMen" runat="server" ItemStyle-CssClass="event-list-item">
                                                <ItemTemplate>
                                                    <div>
                                                        <a href='<%# DataBinder.Eval(Container.DataItem, "SportID", "../Schedule/Schedule.aspx?SportID={0}") + DataBinder.Eval(Container.DataItem, "EventID", "&EventID={0}") %>'>
                                                            <asp:Label ID="txtEntry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EventName") %>'></asp:Label>
                                                        </a>
                                                        <asp:DataList ID="dlScheduleList" runat="server" Style="padding: 0px!important">
                                                            <ItemTemplate>
                                                                <div>
                                                                    <asp:Label ID="txtEntry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ScheduleName") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                        <td>
                                            <asp:DataList ID="dlEventListWomen" runat="server" ItemStyle-CssClass="event-list-item">
                                                <ItemTemplate>
                                                    <div>
                                                        <a href='<%# DataBinder.Eval(Container.DataItem, "SportID", "../Schedule/Schedule.aspx?SportID={0}") + DataBinder.Eval(Container.DataItem, "EventID", "&EventID={0}") %>'>
                                                            <asp:Label ID="txtEntry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EventName") %>'></asp:Label>
                                                        </a>
                                                        <asp:DataList ID="dlScheduleList" runat="server" Style="padding: 0px!important">
                                                            <ItemTemplate>
                                                                <div>
                                                                    <asp:Label ID="txtEntry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ScheduleName") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                        <td>
                                            <asp:DataList ID="dlEventListMix" runat="server" ItemStyle-CssClass="event-list-item">
                                                <ItemTemplate>
                                                    <div>
                                                        <a href='<%# DataBinder.Eval(Container.DataItem, "SportID", "../Schedule/Schedule.aspx?SportID={0}") + DataBinder.Eval(Container.DataItem, "EventID", "&EventID={0}") %>'>
                                                            <asp:Label ID="txtEntry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EventName") %>'></asp:Label>
                                                        </a>
                                                        <asp:DataList ID="dlScheduleList" runat="server" Style="padding: 0px!important">
                                                            <ItemTemplate>
                                                                <div>
                                                                    <asp:Label ID="txtEntry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ScheduleName") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <br />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </section>
</asp:Content>

