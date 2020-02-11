<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Event.Summary" %>

<%@ Register TagPrefix="uc" TagName="SubMenu" Src="~/UserControls/ucSubMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="SelectedGame" Src="~/UserControls/ucSelectedGame.ascx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
    <uc:SubMenu ID="SubMenu" runat="server" />
    <uc:SelectedGame ID="SelectedGame" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="pnlKnockout" runat="server" Visible="false">
                <section class="game-standing">
                    <div class="standing-table">
                        <div class="table-responsive standing-table-container">
                            <asp:PlaceHolder  runat="server" ID="phKnockout"></asp:PlaceHolder>
                            <asp:Panel runat="server" ID="pnlTable"></asp:Panel>
                        </div>
                    </div>
                </section>
            </asp:Panel>
            <asp:Panel ID="pnlLeague" runat="server" Visible="false">
                <section class="summary2-a">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Panel ID="pnlLeagueRanking" runat="server" CssClass="table-responsive"></asp:Panel>
                        </div>
                    </div>
                </section>
                <section class="summary2-b">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Panel ID="pnlLeagueSummary" runat="server" CssClass="table-responsive"></asp:Panel>
                            <div class="table-responsive">
                            </div>
                        </div>
                    </div>
                </section>
            </asp:Panel>
            <asp:Panel ID="pnlTimeDistance" runat="server" Visible="false">
                <section class="summary2-a">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Panel ID="pnlTimeDistanceItem" runat="server" CssClass="table-responsive"></asp:Panel>
                        </div>
                    </div>
                </section>
            </asp:Panel>            
        </div>
        <asp:Literal ID="litEventFooterNote" runat="server"></asp:Literal>
    </div>
    <script type="text/javascript">
        $('.country-name').bind('mouseenter', function () {
            var $this = $(this);

            if (this.offsetHeight < this.scrollHeight && !$this.attr('title')) {
                $this.attr('title', $this.text());
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
