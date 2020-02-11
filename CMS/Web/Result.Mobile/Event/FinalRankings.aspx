<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="FinalRankings.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Event.FinalRankings" %>
<%@ Register TagPrefix="uc" TagName="SubMenu" Src="~/UserControls/ucSubMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="SelectedGame" Src="~/UserControls/ucSelectedGame.ascx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
    <uc:SubMenu ID="SubMenu" runat="server" />
    <uc:SelectedGame ID="SelectedGame" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <%--<div class="row">
        <div class="col-md-12">
            <h1><asp:Label ID="lblHeader" runat="server"></asp:Label></h1>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-12">
            <section class="medals-and-final-ranking">
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="dgFinalRanking" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                AutoGenerateColumns="false"
                                OnPreRender="dgFinalRanking_PreRender"
                                OnRowCreated="dgFinalRanking_RowCreated"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderStyle-CssClass="country" ItemStyle-CssClass="country" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                        <ItemTemplate><img id="imgCountry" runat="server" src='<%# Eval("IconFilePath") %>' alt='<%# Eval("CountryName") %>' title='<%# Eval("CountryName") %>'  /></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="name" ItemStyle-CssClass="name" HeaderStyle-Width="70%" ItemStyle-Width="70%">
                                        <HeaderTemplate>Name</HeaderTemplate>
                                        <ItemTemplate><asp:Image ID="imgParticipant" runat="server" AlternateText="140x140" class="img-rounded" data-src="holder.js/140x140" style="width: 125px; height: 125px;" ImageUrl='<%# Eval("ParticipantImageFilePath") %>' data-holder-rendered="true" />&nbsp;<a id="linkParticipant" runat="server" href='<%# IsTeamGame ? String.Format("~/Athletes/TeamBiography.aspx?TeamID={0}", Eval("ParticipantID")) : String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantID"))%>'><%# Eval("FullName") %></a></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="medal" ItemStyle-CssClass="medal" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                        <ItemTemplate><img id="imgMedal" runat="server" src='<%# Eval("MedalIconFilePath") %>' /></ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .medals-and-final-ranking .table > thead > tr > th.name {
            text-align:left;
        }
    </style>
</asp:Content>
