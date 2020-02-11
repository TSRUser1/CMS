<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="SEM.CMS.Result.Web.Event.Results" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="SubMenu" Src="~/UserControls/ucSubMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="SelectedGame" Src="~/UserControls/ucSelectedGame.ascx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
    <uc:SubMenu ID="SubMenu" runat="server" />
    <uc:SelectedGame ID="SelectedGame" runat="server" />
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderRWeb">
    <section class="schedule-list" runat="server" id="sectionSchList">
        <div class="row">
            <div class="col-md-12">
                <div class="jcarousel-wrapper">
                    <div class="jcarousel">
                        <ul>
                            <asp:Repeater ID="rptScheduleList" runat="server" OnItemDataBound="rptScheduleList_ItemDataBound">
                                <ItemTemplate>
                                    <li <%# GetItemClass(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"ScheduleID"))) %>>
                                        <a href="Results.aspx?EventID=<%# DataBinder.Eval(Container.DataItem,"EventID") %>&ScheduleID=<%# DataBinder.Eval(Container.DataItem,"ScheduleID") %>" style="text-decoration: none !important;">
                                            <div class="item-box">
                                                <div class="details">
                                                    <div class="date">
                                                        <span class="day"><%# DataBinder.Eval(Container.DataItem,"ScheduleDateTime", "{0:dd}") %></span>
                                                        <span class="month"><%# DataBinder.Eval(Container.DataItem,"ScheduleDateTime", "{0:MMM}") %></span>
                                                    </div>
                                                    <div class="others">
                                                        <span class="time"><%# DataBinder.Eval(Container.DataItem,"ScheduleDateTime", "{0:HH}") %>:<%# DataBinder.Eval(Container.DataItem,"ScheduleDateTime", "{0:mm}") %></span><span class="status"><%# DataBinder.Eval(Container.DataItem,"StatusName") %></span></div>
                                                </div>
                                                <div class="event"><%# DataBinder.Eval(Container.DataItem,"ScheduleName") %></div>
                                                <div class="team">
                                                    <asp:Repeater ID="rptCountryList" runat="server">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image1" ImageUrl="<%# Container.DataItem %>" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <asp:Panel CssClass="control" runat="server" ID="controlScheduleList" Visible="false">
                        <a href="#" class="jcarousel-control-prev"></a>
                        <a href="#" class="jcarousel-control-next"></a>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </section>
    <div class="row">
        <div class="col-md-12">
            <section class="result">
                <div class="row">
                    <div class="col-md-12">
                        <div>
                            <ul class="nav nav-tabs" role="tablist" style="border-bottom:none!important">
                                <li runat="server" id="liStartList" role="presentation"><a href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab">Start List</a></li>
                                <li runat="server" id="liResult" role="presentation"><a href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab">Result</a></li>
                            </ul>
                            <div class="tab-content">
                                <asp:Panel runat="server" ID="tab1" ClientIDMode="Static">
                                    <asp:Panel ID="pnlStartList" runat="server" CssClass="table-responsive start-list">
                                        <asp:Panel ID="pnlStartListItem" runat="server"></asp:Panel>
                                        <asp:Panel ID="pnlReferee" runat="server" Visible="false">
                                            <table class="table table-striped" style="margin-bottom: 0px">
                                                <thead>
                                                    <tr>
                                                        <th colspan="8">Umpire/Judges</th>
                                                    </tr>
                                                </thead>
                                            </table>
                                            <asp:GridView ID="dgReferee" CssClass="table table-striped" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center" UseAccessibleHeader="true" runat="server">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-CssClass="country" HeaderStyle-CssClass="country" DataField="RerefeeTitle" HeaderText="Title" />
                                                    <asp:BoundField ItemStyle-CssClass="country" HeaderStyle-CssClass="country" DataField="RefereeName" HeaderText="Name" />
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </asp:Panel>
                                    <asp:Literal ID="litStartListFooter" runat="server"></asp:Literal>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="tab2" ClientIDMode="Static">
                                    <div class="table-responsive">
                                        <div class="table-responsive results">
                                            <asp:GridView ID="dgResultLst" CssClass="table table-striped" AutoGenerateColumns="false"
                                                ShowHeaderWhenEmpty="true" EmptyDataText="No records found."
                                                EmptyDataRowStyle-HorizontalAlign="Center" UseAccessibleHeader="true" runat="server"
                                                OnInit="dgResultLst_Init" OnLoad="dgResultLst_Load" Style="margin-bottom: 0"
                                                OnRowCreated="dgResultLst_RowCreated" OnRowDataBound="dgResultLst_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-CssClass="target" HeaderStyle-CssClass="rank" DataField="ResultPosition" HeaderText="Rank" />
                                                    <asp:ImageField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataImageUrlField="MedalIconFilePath" DataAlternateTextField="MedalType" HeaderText="Medal" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="BibNumber" HeaderText="Bib" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" PostBackUrl='<%# Eval("CountryID", "../Schedule/ScheduleCountry.aspx?CountryID={0}") %>' ImageUrl='<%# Eval("CountryImage") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField ItemStyle-CssClass="country" HeaderStyle-CssClass="country" DataNavigateUrlFields="ParticipantID" DataNavigateUrlFormatString="~/Athletes/Biography.aspx?AthleteID={0}" DataTextField="FullName" HeaderText="Name" />
                                                    <asp:HyperLinkField ItemStyle-CssClass="country" HeaderStyle-CssClass="country" DataNavigateUrlFields="TeamID" DataNavigateUrlFormatString="~/Athletes/TeamBiography.aspx?TeamID={0}" DataTextField="TeamName" HeaderText="Team Name" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score1" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score2" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score3" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score4" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score5" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score6" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score7" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score8" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score9" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score10" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score11" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score12" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score13" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score14" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score15" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score16" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score17" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score18" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score19" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Score20" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round-final" HeaderStyle-CssClass="first-round" DataField="ScoreFinal" Visible="false" />
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="BreakRecord" HeaderText="Records" Visible="true"/>
                                                    <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Remarks" HeaderText=""/>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:Panel runat="server" ID="pnlTeamStatistic" Visible="false">
                                                <asp:GridView ID="dgTeamStatistic" CssClass="table table-striped" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" UseAccessibleHeader="true" runat="server"
                                                    OnInit="dgTeamStatistic_Init" OnDataBound="dgTeamStatistic_DataBound" OnRowCreated="dgTeamStatistic_RowCreated">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" HeaderText="Bib" Visible="false">
                                                            <ItemTemplate>
                                                                <%# Eval("BibNumber") %>
                                                                <asp:HiddenField ID="hidCountryID" runat="server" Value='<%# Eval("CountryName") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:ImageField ItemStyle-CssClass="country" HeaderStyle-CssClass="country" DataImageUrlField="CountryImage" DataAlternateTextField="CountryName" HeaderText="Country" />
                                                        <asp:HyperLinkField ItemStyle-CssClass="country" HeaderStyle-CssClass="country" DataNavigateUrlFields="ParticipantID" DataNavigateUrlFormatString="~/Athletes/Biography.aspx?AthleteID={0}" DataTextField="FullName" HeaderText="Name" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic1" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic2" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic3" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic4" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic5" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic6" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic7" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic8" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic9" Visible="false" />
                                                        <asp:BoundField ItemStyle-CssClass="first-round" HeaderStyle-CssClass="first-round" DataField="Statistic10" Visible="false" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <asp:Literal ID="litScheduleFooterNote" runat="server"></asp:Literal>
                                </asp:Panel>
                            </div>

                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <script type="text/javascript">
        $('.event').bind('mouseenter', function () {
            var $this = $(this);

            if (this.offsetWidth < this.scrollWidth && !$this.attr('title')) {
                $this.attr('title', $this.text());
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <style>
        .innerContainer {
            padding-bottom: 20px;
        }

        .innerContentContainer {
            vertical-align: top;
            width: 65%;
            display: inline-block;
        }

        .contentLabelHeader {
            color: rgb(0, 137, 228);
            font-size: 2rem;
        }

        .bigFont {
            font-size: 2rem;
        }

        .boldFont {
            font-weight: bold;
        }

        .rWebFixedHeaderGrid {
            position: fixed;
            top: 0px;
            background-color: white;
            display: none;
        }

        .rWebGrid {
            border-collapse: collapse;
            border-radius: 2px;
        }

            .rWebGrid th {
                background-color: rgb(233, 0, 71);
                text-align: center;
                padding-top: 2px;
                padding-bottom: 2px;
            }

                .rWebGrid th,
                .rWebGrid th a {
                    color: rgb(255, 255, 255);
                }

            .rWebGrid tr:nth-child(even) {
                background-color: rgb(242, 242, 242);
            }

            .rWebGrid tr:nth-child(odd) {
                background-color: rgb(236, 236, 236);
            }

            .rWebGrid th,
            .rWebGrid td {
                border: 2px solid rgb(255, 255, 255);
            }

            .rWebGrid td {
                padding: 5px;
            }

                .rWebGrid td.middleAlign {
                    text-align: center;
                }

                .rWebGrid td:nth-child(1) {
                    font-weight: bold;
                }

        .floatRight {
            float: right;
        }

        .portlets {
            width: 30%;
            display: inline-block;
        }

        .portletContainer {
            margin-top: 2px;
            min-width: 350px;
            display: inline-block;
        }

        .portletHeader {
            padding: 5px;
            display: inline-block;
            width: 100%;
            min-height: 52px;
        }

        .medalStandingHeader {
            background-color: rgb(233, 0, 71);
        }

        .liveScheduleHeader {
            background-color: rgb(0, 156, 255);
        }

        .latestMedalistHeader {
            background-color: rgb(255, 140, 8);
        }

        .portletHeader span {
            color: rgb(255,255,255);
            font-size: 2rem;
            display: inline-block;
            margin-top: 8px;
        }

        .rWebMedalGrid th {
            background-color: rgb(236, 236, 236);
        }

        .rWebMedalGrid tr {
            background-color: rgb(242, 242, 242);
            border-bottom: 1px solid rgb(230,230,230);
        }

        .rWebMedalGrid th,
        .rWebMedalGrid td {
            padding: 5px;
        }

            .rWebMedalGrid th.middleAlign,
            .rWebMedalGrid td.middleAlign {
                text-align: center;
            }

        .rWebLiveScheduleGrid th {
            background-color: rgb(236, 236, 236);
        }

        .rWebLiveScheduleGrid tr {
            background-color: rgb(242, 242, 242);
            border-bottom: 1px solid rgb(230,230,230);
        }

        .rWebLiveScheduleGrid th,
        .rWebLiveScheduleGrid td {
            padding: 5px;
        }

        .imgFlag {
            width: 55px;
        }

        .imgSport {
            width: 86px;
        }

        .rWebLatestMedalistGrid {
            width: 100%;
        }

            .rWebLatestMedalistGrid th,
            .rWebLatestMedalistGrid td {
                padding: 5px;
            }

            .rWebLatestMedalistGrid th {
                background-color: rgb(236, 236, 236);
            }

            .rWebLatestMedalistGrid tr {
                background-color: rgb(242, 242, 242);
                border-bottom: 1px solid rgb(230,230,230);
            }

            .rWebLatestMedalistGrid td {
                vertical-align: middle;
            }

                .rWebLatestMedalistGrid td:nth-child(1) {
                    width: 70px;
                }

                .rWebLatestMedalistGrid td:nth-child(3) {
                    width: 96px;
                }

        .panelPhoto {
            height: 80px;
            width: 60px;
            background-color: #E8E8E8;
        }

        @media (max-width:1000px) {
            .innerContentContainer {
                width: 100%;
            }

            .portlets {
                margin-top: 15px;
            }
        }
    </style>
</asp:Content>

