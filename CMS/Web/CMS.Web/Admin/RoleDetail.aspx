<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="RoleDetail.aspx.cs" Inherits="SEM.CMS.Web.Admin.RoleDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_CMS" runat="server">
    <div id="page" class="dashboard"><div class="row-fluid"><div class="span12"><div class="widget">

    <div class="widget-title">
        <h4><i class="icon-reorder"></i><asp:Label runat="server" ID="lblPageMode" Text="Add"></asp:Label> &nbsp;Role</h4>
        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
    </div>

    <div class="widget-body"><div class="form"><div class="form-horizontal">

        <div class="form-actions">
            <asp:Button ID="btnBack" Text="Back" class="btn btn-success" runat="server" OnClick="btnBack_Click" />
            <asp:Button ID="btnClear" Text="Clear" class="btn btn-info" runat="server" OnClick="btnClear_Click" />
        </div>

         <div class="control-group">
            <label class="control-label" for="txtRoleName">Role Name</label>
            <div class="controls">
                <asp:TextBox ID="txtRoleName" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtDescription">Description</label>
            <div class="controls">
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
 
        <div class="control-group">
            <label class="control-label" for="txtFunction">Function</label>
            <div class="controls">
                <asp:DropDownList ID="ddlFunction" OnSelectedIndexChanged="ddlFunction_OnSelectedIndexChanged" AutoPostBack="true" runat="server" class="span6">
                </asp:DropDownList>
            </div>
        </div>
         <div class="control-group">
              <div class="controls">
              <asp:GridView ID="dgModuleFunction"  runat="server" EnableViewState="true"
                AutoGenerateColumns="false"
                class="table table-striped table-bordered"
                DataKeyNames="ModuleID">
                <Columns>
                        <asp:TemplateField HeaderText="No." ItemStyle-Width="20px">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>

                <ItemStyle Width="20px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Read Only">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsReadOnly" runat="server" Checked='<%# Eval("IsReadOnly") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Read Write">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsReadWrite" runat="server" Checked='<%# Eval("IsReadWrite") %>' />
                </ItemTemplate>
            </asp:TemplateField>
                    </Columns>
             </asp:GridView>
          </div>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnSave" Text="Insert Role" class="btn btn-primary" runat="server" OnClick="btnSave_Click"/>
        </div>
    
 </div></div></div>
</div></div></div></div>

</asp:Content>
