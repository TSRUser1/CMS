<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="ParticipantMaintenance.aspx.cs" Inherits="SEM.CMS.Web.Competition.ParticipantMaintenance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="ContentHead" runat="server" ContentPlaceHolderID="head">
    <style>
        table tbody tr td select {
            width:250px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="CPH_CMS">

    <fieldset>
        <legend>Search</legend>
        <table>
            <tr>
                <td>Name
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" Width="236" />
                </td>
            </tr>
            <tr>
                <td>Sport
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSport" AutoPostBack="true" OnSelectedIndexChanged="ddlSport_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Event
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlEvent"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Passport/NRIC&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassport" Width="236" />
                </td>
            </tr>
        </table>
    </fieldset>

    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
    <asp:Button ID="btnNew" Text="New" runat="server" OnClick="btnNew_Click" />
    <br />

    <asp:GridView ID="dgParticipant" runat="server" EnableViewState="true"
        AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
        AllowPaging="true"
        OnRowDeleting="DGParticipant_RowDeleting"
        OnPageIndexChanging="DGParticipant_PageIndexChanging"
        DataKeyNames="ParticipantID">
        <Columns>
            <asp:TemplateField HeaderText="" ItemStyle-Width="30px">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Delete" CommandName="delete" OnClientClick="return confirm ( 'Are you sure you want to delete this record?' )"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>


