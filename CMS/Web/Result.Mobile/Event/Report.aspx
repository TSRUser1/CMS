<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Event.Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="SubMenu" Src="~/UserControls/ucSubMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="SelectedGame" Src="~/UserControls/ucSelectedGame.ascx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
    <uc:SubMenu ID="SubMenu" runat="server" />
    <uc:SelectedGame ID="SelectedGame" runat="server" />
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderRWeb">
    
            <section class="athletes-profile"><div class="row"><div class="col-md-12">
                
                <div class="row trigger grey-bg">
                    <div class="col-md-6"><h5><asp:Label ID="txtEntry" runat="server" Text="Entry List\Team Roster"></asp:Label></h5></div>
                    <div class="col-md-6 text-right"><a class="controller show" href="#" data-panel-id="result-1"><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a></div>
                </div><br/>
                <div class="table-responsive player-results" id="result-0">
                    <asp:DataList ID="dlEntry" runat="server" OnItemCommand="ButtonDownloadContent"
                        RepeatDirection="Vertical" RepeatColumns="1" BorderStyle="None" Style="padding: 0px!important">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <div>
                                <img src='../Images/pdf.png' id="ImgIcon" />
                                <asp:LinkButton ID="ButtonDownload" runat="server" Style="padding-left: 5px; text-decoration: none"
                                    ToolTip="Click here to download" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FilePath") %>'
                                    Text=' <%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br/>

                <div class="row trigger grey-bg">
                    <div class="col-md-6"><h5><asp:Label ID="txtSchedule" runat="server" Text="Schedule"></asp:Label></h5></div>
                    <div class="col-md-6 text-right"><a class="controller show" href="#" data-panel-id="result-1"><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a></div>
                </div><br/>
                <div class="table-responsive player-results" id="result-1">
                    <asp:DataList ID="dlSchedule" runat="server" OnItemCommand="ButtonDownloadContent"
                        RepeatDirection="Vertical" RepeatColumns="1" BorderStyle="None" Style="padding: 0px!important">
                       <ItemStyle VerticalAlign="Top" />
                         <ItemTemplate>
                            <div>
                                <img src='../Images/pdf.png' id="ImgIcon" />
                                <asp:LinkButton ID="ButtonDownload" runat="server" Style="padding-left: 5px; text-decoration: none"
                                    ToolTip="Click here to download" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FilePath") %>'
                                    Text=' <%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br/>

                <div class="row trigger grey-bg">
                    <div class="col-md-6"><h5><asp:Label ID="txtStartList" runat="server" Text="Start List"></asp:Label></h5></div>
                    <div class="col-md-6 text-right"><a class="controller show" href="#" data-panel-id="result-2"><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a></div>
                </div><br/>
                <div class="table-responsive player-results" id="result-2">
                    <asp:DataList ID="dlStartList" runat="server" OnItemCommand="ButtonDownloadContent"
                        RepeatDirection="Vertical" RepeatColumns="1" BorderStyle="None" Style="padding: 0px!important">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <div>
                                <img src='../Images/pdf.png' id="ImgIcon" />
                                <asp:LinkButton ID="ButtonDownload" runat="server" Style="padding-left: 5px; text-decoration: none"
                                    ToolTip="Click here to download" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FilePath") %>'
                                    Text=' <%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br/>

                <div class="row trigger grey-bg">
                    <div class="col-md-6"><h5><asp:Label ID="txtResult" runat="server" Text="Result"></asp:Label></h5></div>
                    <div class="col-md-6 text-right"><a class="controller show" href="#" data-panel-id="result-3"><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a></div>
                </div><br/>
                <div class="table-responsive player-results" id="result-3">
                    <asp:DataList ID="dlResult" runat="server" OnItemCommand="ButtonDownloadContent"
                        RepeatDirection="Vertical" RepeatColumns="1" BorderStyle="None" Style="padding: 0px!important">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <div>
                                <img src='../Images/pdf.png' id="ImgIcon" />
                                <asp:LinkButton ID="ButtonDownload" runat="server" Style="padding-left: 5px; text-decoration: none"
                                    ToolTip="Click here to download" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FilePath") %>'
                                    Text=' <%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br/>

                <div class="row trigger grey-bg">
                    <div class="col-md-6"><h5><asp:Label ID="Label1" runat="server" Text="Medals"></asp:Label></h5></div>
                    <div class="col-md-6 text-right"><a class="controller show" href="#" data-panel-id="result-3"><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a></div>
                </div><br/>
                <div class="table-responsive player-results" id="result-4">
                    <asp:DataList ID="dlMedal" runat="server" OnItemCommand="ButtonDownloadContent"
                        RepeatDirection="Vertical" RepeatColumns="1" BorderStyle="None" Style="padding: 0px!important">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <div>
                                <img src='../Images/pdf.png' id="ImgIcon" />
                                <asp:LinkButton ID="ButtonDownload" runat="server" Style="padding-left: 5px; text-decoration: none"
                                    ToolTip="Click here to download" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FilePath") %>'
                                    Text=' <%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br/>

                <div class="row trigger grey-bg">
                    <div class="col-md-6"><h5><asp:Label ID="Label2" runat="server" Text="Summary"></asp:Label></h5></div>
                    <div class="col-md-6 text-right"><a class="controller show" href="#" data-panel-id="result-3"><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a></div>
                </div><br/>
                <div class="table-responsive player-results" id="result-5">
                    <asp:DataList ID="dlSummary" runat="server" OnItemCommand="ButtonDownloadContent"
                        RepeatDirection="Vertical" RepeatColumns="1" BorderStyle="None" Style="padding: 0px!important">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <div>
                                <img src='../Images/pdf.png' id="ImgIcon" />
                                <asp:LinkButton ID="ButtonDownload" runat="server" Style="padding-left: 5px; text-decoration: none"
                                    ToolTip="Click here to download" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FilePath") %>'
                                    Text=' <%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br/>

                <div class="row trigger grey-bg">
                    <div class="col-md-6"><h5><asp:Label ID="Label3" runat="server" Text="Official Communications"></asp:Label></h5></div>
                    <div class="col-md-6 text-right"><a class="controller show" href="#" data-panel-id="result-3"><span data-hide-string="Hide" data-show-string="Show">Hide</span> <img src="/img/trigger/arrow_collapse_up.png" date-hide-image="/img/trigger/arrow_collapse_up.png" data-show-image="/img/trigger/arrow_collapse_down.png" /></a></div>
                </div><br/>
                <div class="table-responsive player-results" id="result-6">
                    <asp:DataList ID="dlOffComm" runat="server" OnItemCommand="ButtonDownloadContent"
                        RepeatDirection="Vertical" RepeatColumns="1" BorderStyle="None" Style="padding: 0px!important">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <div>
                                <img src='../Images/pdf.png' id="ImgIcon" />
                                <asp:LinkButton ID="ButtonDownload" runat="server" Style="padding-left: 5px; text-decoration: none"
                                    ToolTip="Click here to download" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FilePath") %>'
                                    Text=' <%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div></div></section>

</asp:Content>

