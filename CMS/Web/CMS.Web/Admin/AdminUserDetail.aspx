<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="AdminUserDetail.aspx.cs" Inherits="SEM.CMS.Web.AdminUserDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_CMS" runat="server">  
    <table style="width: 100%">
        <colgroup>
            <col style="width: 30px" />
            <col style="width: 100px" />
            <col style="width: 10px" />
            <col style="width: 200px" />
        </colgroup>
        <tr>
            <td></td>
            <td colspan="3">
                <asp:Button ID="btnBack" Text="Back" class="btn btn-success" runat="server" OnClick="btnBack_Click" />
                &nbsp;
                <asp:Button ID="btnClear" Text="Clear" class="btn btn-info" runat="server" OnClick="btnClear_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3" style="font-weight: bold"><asp:Label runat="server" ID="lblPageMode" Text="Add"></asp:Label> &nbsp;admin user</td>
        </tr>
        <tr>
            <td></td>
            <td>Login ID</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtLoginID" runat="server" Width="200px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ValidationGroup="SaveAdminDetails" runat="server" ID="rfvLoginID" ControlToValidate="txtLoginID" ErrorMessage="Required Field!" ForeColor="Red" />
             </td>
        </tr>
        <tr>
            <td></td>
            <td>Full name</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtFullname" runat="server" Width="200px"></asp:TextBox></td>
              <td>
                <asp:RequiredFieldValidator ValidationGroup="SaveAdminDetails" runat="server" ID="rfvFullname" ControlToValidate="txtFullname" ErrorMessage="Required Field!" ForeColor="Red" />
             </td>
        </tr>
        <tr style="display:none">
            <td style="display:none"></td>
            <td style="display:none"></td>
            <td style="display:none"></td>
            <td style="display:none">
                <asp:TextBox style="display:none" ID="txtFakePwd" TextMode="Password" AutoCompleteType="None" runat="server" Width="200px"></asp:TextBox></td>
             <td style="display:none"></td>
        </tr>
        <tr>
            <td></td>
            <td>Password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtPassword" TextMode="Password" AutoCompleteType="None" runat="server" Width="200px"></asp:TextBox></td>
             <td>
                <asp:RequiredFieldValidator ValidationGroup="SaveAdminDetails" runat="server" ID="rfvPassword" ControlToValidate="txtPassword" ErrorMessage="Required Field!" ForeColor="Red" />
             </td>
        </tr>
        <tr>
            <td></td>
            <td>Designation</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtDesignation" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
       <%-- <tr>
            <td></td>
            <td>Date</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtDate" TextMode="DateTime" runat="server" Width="150px" ValidationGroup="validationGrp"></asp:TextBox>
                <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" PopupButtonID="imgBtnCalender" TargetControlID="txtDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                <asp:ImageButton ID="imgBtnCalender" ImageAlign="Middle" runat="server" ImageUrl="~/images_general/calendar.jpg" /></td>
        </tr>--%>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Button ID="btnSave" Text="Insert User" class="btn btn-primary" ValidationGroup="SaveAdminDetails" runat="server" OnClick="btnSave_Click" /></td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="dgRoleDetail" runat="server"
        AutoGenerateColumns="False"
        class="table table-striped table-bordered"
        DataKeyNames="RoleID">
        <Columns>
            <asp:TemplateField HeaderText="No." ItemStyle-Width="20px">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>

                <ItemStyle Width="20px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkHasRole" runat="server" Checked='<%# Eval("IsActive") %>'/>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
</asp:Content>