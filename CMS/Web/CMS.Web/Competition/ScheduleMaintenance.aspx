<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="ScheduleMaintenance.aspx.cs" Inherits="SEM.CMS.Web.Schedule.ScheduleMaintainance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_CMS" runat="server">
    <asp:Image ID="imgSportImage" runat="server" Height="60px" Width="60px" />
    <asp:Label ID="lblEventDetails" runat="server"></asp:Label><br />
    <br />
    <br />
    <asp:Button ID="btnNew" Text="New" runat="server" OnClick="btnNew_Click" />
    <asp:GridView ID="dgScheduleDetail"  runat="server" EnableViewState="true"
        class="table table-striped table-bordered"
        AutoGenerateColumns="false"
        AllowPaging="true"
        OnRowDeleting="DGScheduleDetail_RowDeleting"
        OnPageIndexChanging="DGScheduleDetail_PageIndexChanging" 
        DataKeyNames="ScheduleID">
        <Columns>
            <asp:TemplateField HeaderText="" ItemStyle-Width="30px">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Delete" CommandName="delete" OnClientClick="return confirm ( 'Are you sure you want to delete this record?' )"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No." ItemStyle-Width="20px">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:FileUpload ID="btnFileUpload" runat="server" />
     <asp:Button ID="btnLoadFromCsv" runat="server" OnClick="btnLoadFromCsv_Click" Text="Load From CSV" />
</asp:Content>
