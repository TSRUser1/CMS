<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Medallist.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Medal.Medallist" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <div class="row">
        <div class="col-md-12 iconDiv">
            <h1><asp:Label ID="lblHeader" runat="server" Text ="Medallists" style="vertical-align:top;" CssClass="hidden"></asp:Label>
                    <asp:ImageButton CssClass="ImageIcon" ImageUrl="/Images/Standing.png" ID="btnOverall" runat="server" OnClientClick="return Navigate(this);" Text="Overall Medal Standings" data-navigate-url="/Medal/Standing.aspx" />
                    <asp:ImageButton CssClass="ImageIcon" ImageUrl="/Images/singlemedal.png" ID="btnMedalBySports" runat="server" OnClientClick="return Navigate(this);" Text="Medal By Sports" data-navigate-url="/Medal/Country.aspx" />
                    <asp:ImageButton CssClass="ImageIcon" ImageUrl="/Images/multimedal.png" ID="btnMultiMedallist" runat="server" OnClientClick="return Navigate(this);" Text="Multi-Medallists" data-navigate-url="/Medal/MultiMedallist.aspx?IsMulti=true" />
            </h1>
            
        </div>
    </div>
    <asp:UpdatePanel ID="updatePanelContent" runat="server">
        <ContentTemplate>
            <asp:Panel ID="panelDate" runat="server" CssClass="row" Visible="false">
                <div class="col-md-12">
                    <div class="form-inline date-panel">
                        <div class="form-group">
                            <span class="panelSearchLabel">Date : </span>
                            <asp:DropDownList ID="ddlDate" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="03 Dec" Value="2015-12-03"></asp:ListItem>
                                <asp:ListItem Text="04 Dec" Value="2015-12-04"></asp:ListItem>
                                <asp:ListItem Text="05 Dec" Value="2015-12-05"></asp:ListItem>
                                <asp:ListItem Text="06 Dec" Value="2015-12-06"></asp:ListItem>
                                <asp:ListItem Text="07 Dec" Value="2015-12-07"></asp:ListItem>
                                <asp:ListItem Text="08 Dec" Value="2015-12-08"></asp:ListItem>
                                <asp:ListItem Text="09 Dec" Value="2015-12-09"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col-md-12" style="padding-left:3px!important;padding-right:3px!important">
                    <section class="daily-medallists">
                        <div class="table-responsive">
                            <asp:GridView ID="dgMedalStanding" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                AutoGenerateColumns="false"
                                AllowPaging="false"
                                OnRowDataBound="dgMedalStanding_RowDataBound"
                                OnDataBound="dgMedalStanding_DataBound"
                                OnRowCreated="dgMedalStanding_RowCreated"
                                Width="100%"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="Event">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hidEventID" runat="server" Value='<%# Eval("EventID") %>' />
                                            <%# Eval("EventName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <span><%# Convert.ToDateTime(Eval("ScheduleDateTime")).ToString("dd-MMM-yyyy") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <img id="imgParticipant" runat="server" src='<%# Eval("ParticipantImageFilePath") %>' visible='<%#  Convert.ToBoolean(Eval("IsIndividualGame")) && !(Eval("ParticipantImageFilePath") == DBNull.Value) %>' alt='<%# Eval("ParticipantOrTeamName") %>' title='<%# Eval("ParticipantOrTeamName") %>' class="player-img" />
                                            <a id="linkCountry" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>' style="text-decoration:none;">
                                                <img id="imgCountry" runat="server" src='<%# Eval("ParticipantCountryImageFilePath") %>' alt='<%# Eval("CountryName") %>' title='<%# Eval("CountryName") %>' class="country-flag" />
                                            </a>
                                            &nbsp;
                                            <a id="linkParticipant" runat="server" href='<%# String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantOrTeamID")) %>' class="player-name" visible='<%# Convert.ToBoolean(Eval("IsIndividualGame")) %>'>
                                                <%# Eval("ParticipantOrTeamName") %>
                                            </a>
                                            <a id="linkTeam" runat="server" href='<%# String.Format("~/Athletes/TeamBiography.aspx?TeamID={0}", Eval("ParticipantOrTeamID")) %>' class="player-name" visible='<%# !Convert.ToBoolean(Eval("IsIndividualGame")) %>'>
                                                <%# Eval("ParticipantOrTeamName") %>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medal">
                                        <ItemTemplate>
                                            <img id="imgMedal" runat="server" src='<%# Eval("MedalIconFilePath") %>' /> <%# Eval("Medal") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .date-panel {
            margin:10px 0px;
        }
        .daily-medallists .table .sport-img {
            height:50px;
        }
        .daily-medallists .table .player-img {
            width:125px;
        }
    </style>
    <style>
        .btn-medal-standings {
            margin-top:2px;
            margin-bottom:2px;
        }
    </style>
    <script type="text/javascript">
        function Navigate(sender) {
            window.location.href = $(sender).data("navigate-url");
            return false;
        }
    </script>
</asp:Content>
