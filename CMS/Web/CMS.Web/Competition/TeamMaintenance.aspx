<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="TeamMaintenance.aspx.cs" Inherits="SEM.CMS.Web.Competition.TeamMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH_CMS" runat="server">
    <div id="page" class="dashboard">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget">
                    <div class="widget-title">
                        <h4>Search</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                    </div>
                    <div class="control-group">
                        Sport  
            <asp:DropDownList runat="server" ID="ddlSport" AutoPostBack="true" OnSelectedIndexChanged="ddlSport_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="control-group">
                        Event  
            <asp:DropDownList runat="server" ID="ddlEvent"></asp:DropDownList>
                    </div>

                    <div class="form-actions">
                        <asp:Button runat="server" class="btn btn-success" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnNew" class="btn btn-info" Text="New" runat="server" OnClick="btnNew_Click" />
                    </div>
                    <div class="widget-body">
                        <asp:GridView ID="dgTeam" runat="server" EnableViewState="true"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            OnRowDeleting="DGTeam_RowDeleting"
                            OnPageIndexChanging="DGTeam_PageIndexChanging"
                            DataKeyNames="TeamID"
                            CssClass="table table-striped table-bordered">
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
