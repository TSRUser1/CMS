<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Athletes.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Event.Athletes" %>
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
            <section class="number-of-athletes">
                <div class="row">
                    <div class="col-md-12">
                        <div class="title-wrapper">
                            Number of Entries: <asp:Label ID="lblNumberOfEntries" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <asp:ListView ID="listAthletes" runat="server" ItemPlaceholderID="itemPlaceholder" GroupPlaceholderID="groupPlaceHolder" GroupItemCount="2" >
                    <LayoutTemplate>
                        <div runat="server" id="groupPlaceHolder"></div>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <div class="row athletes-list">
                            <div runat="server" id="itemPlaceholder"></div>
                        </div>
                    </GroupTemplate>
                    <ItemTemplate>
                        <div class="col-md-6">
                            <div class="item-box">
                                <div class="photo">
                                    <asp:Image ID="imgAthlete" runat="server" AlternateText="140x140" class="img-rounded" data-src="holder.js/140x140" style="width: 125px; height: 125px;" ImageUrl='<%# Eval("ParticipantImageFilePath") %>' data-holder-rendered="true" />
                                </div>
                                <div class="description">
                                    <div class="country">
                                        <a id="linkCountryImage" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>'>
                                            <asp:Image ID="imgCountry" runat="server" ImageUrl='<%# Eval("FlagImageFilePath") %>' Visible='<%# Eval("FlagImageFilePath") != DBNull.Value ? true : false%>' AlternateText='<%# Eval("CountryName") %>' ToolTip='<%# Eval("CountryName") %>' />
                                        </a>
                                        &nbsp;
                                        <a id="linkCountryName" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>'>
                                            <%# Eval("CountryName") %>
                                        </a>
                                    </div>
                                    <div class="name">
                                        <asp:HyperLink ID="linkFullName" runat="server" NavigateUrl='<%# String.Format("~/Athletes/Biography.aspx?AthleteID={0}", Eval("ParticipantID"))%>' Text='<%# Eval("FullName") %>' Font-Underline="true"></asp:HyperLink>
                                    </div>
                                    <%--<div class="bid"><strong>Bib: </strong> <%# String.IsNullOrEmpty(Eval("BibNumber").ToString()) ? '-' : Eval("BibNumber") %></div>--%>
                                    <div class="dob"><%# String.Format("{0:dd MMM yyyy}", Eval("DateOfBirth")) %></div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <EmptyItemTemplate>
                        <div class="col-md-6">
                        </div>
                    </EmptyItemTemplate>
                    <EmptyDataTemplate>
                        <div class="empty-item">
                            No athletes found.
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .empty-item {
            text-align:center;
            padding:10px 25px;
            width:100%;
            display:inline-block;
            background-color:rgb(242, 242, 242);
            border:1px solid rgb(230, 230, 230);
        }
    </style>
</asp:Content>
