<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="MultiMedallist.aspx.cs" Inherits="SEM.CMS.Result.Web.Medal.MultiMedallist" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1><asp:Label ID="lblMedallist" runat="server" Text="Medallists" style="vertical-align:top;"></asp:Label>
                    <asp:Button ID="btnOverall" runat="server" OnClientClick="return Navigate(this);" Text="Overall Medal Standings" CssClass="btn btn-default btn-medal-standings" data-navigate-url="/Medal/Standing.aspx" />
                    <asp:Button ID="btnMedalBySports" runat="server" OnClientClick="return Navigate(this);" Text="Medal By Sports" CssClass="btn btn-default btn-medal-standings" data-navigate-url="/Medal/Country.aspx" />
                    <asp:Button ID="btnDailyMedallist" runat="server" OnClientClick="return Navigate(this);" Text="Daily Medallists" CssClass="btn btn-default btn-medal-standings" />
            </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <section class="daily-medallists">
                <div class="table-responsive">
                    <asp:GridView ID="dgMedalStanding" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                        AutoGenerateColumns="false"
                        AllowPaging="false"
                        OnDataBound="dgMedalStanding_DataBound"
                        Width="100%"
                        >
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hidParticipantID" runat="server" Value='<%# Eval("ParticipantID") %>' />
                                    <img id="imgParticipant" runat="server" src='<%# Eval("ParticipantImageFilePath") %>' visible='<%# !(Eval("ParticipantImageFilePath") == DBNull.Value) %>' alt='<%# Eval("FullName") %>' title='<%# Eval("FullName") %>' class="player-img" style="padding-right:4px;" />
                                    <a id="linkParticipant" runat="server" href='<%# String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantID")) %>' class="player-name">
                                        <%# Eval("FullName") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <a id="linkCountry" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>'>
                                        <img id="imgCountry" runat="server" src='<%# Eval("IconFilePath") %>' alt='<%# Eval("CountryName") %>' title='<%# Eval("CountryName") %>' class="country-flag" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Sport" DataField="SportName" />
                            <asp:BoundField HeaderText="Event" DataField="EventName" />
                            <asp:TemplateField HeaderText="Medal" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <img id="imgMedal" runat="server" src='<%# Eval("MedalIconFilePath") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Total" DataField="Total" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                        </Columns>
                    </asp:GridView>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .daily-medallists .table .player-img {
            width:125px;
        }
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
