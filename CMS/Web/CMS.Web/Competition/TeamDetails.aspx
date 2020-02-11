<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="TeamDetails.aspx.cs" Inherits="SEM.CMS.Web.Competition.TeamDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_CMS" runat="server">
    <div id="page" class="dashboard">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget">

                    <div class="widget-title">
                        <h4><i class="icon-reorder"></i>
                            <asp:Label runat="server" ID="lblPageMode" Text="Add"></asp:Label>
                            &nbsp;Event</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                    </div>

                    <div class="widget-body">
                        <div class="form">
                            <div class="form-horizontal">

                                <div class="form-actions">
                                    <asp:Button ID="btnBack" Text="Back" class="btn btn-success" runat="server" OnClick="btnBack_Click" />
                                    <asp:Button ID="btnClear" Text="Clear" class="btn btn-info" runat="server" OnClick="btnClear_Click" />
                                </div>

                                <div class="control-group">
                                    <label class="control-label" for="txtEventName">Team Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtTeamName" runat="server" class="span6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqTxtTeamName" runat="server" ControlToValidate="txtTeamName" ForeColor="Red" ValidationGroup="validationGrp_TeamDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtSport">Sport</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlSport" runat="server" class="span6" AutoPostBack="true" OnSelectedIndexChanged="ddlSport_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqDdlSport" runat="server" ControlToValidate="ddlSport" ForeColor="Red" ValidationGroup="validationGrp_TeamDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtEvent">Event</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlEvent" runat="server" class="span6" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqDdlEvent" runat="server" ControlToValidate="ddlEvent" ForeColor="Red" ValidationGroup="validationGrp_TeamDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:Button ID="btnSave" Text="Save" class="btn btn-primary" runat="server" OnClick="btnSave_Click" ValidationGroup="validationGrp_TeamDetails" />
                                </div>
                                <div class="control-group" id="divCountry" runat="server" visible="false">
                                    <label class="control-label" for="txtEvent">Country</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlCountry" runat="server" class="span6" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>


                </div>

                <div id="divParticipants" runat="server" visible="false">
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Participants</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <asp:GridView ID="dgParticipantInEventForTeam" runat="server" EnableViewState="true"
                                AutoGenerateColumns="false"
                                DataKeyNames="ParticipantInEventID"
                                class="table table-striped table-bordered">
                                <Columns>
                                    <asp:TemplateField HeaderText="Assign To Team" ItemStyle-Width="5px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAssignTeam" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="form-actions" id="divAssign" runat="server" visible="false">
                                <asp:Button ID="btnAddParticipant" Text="Assign" class="btn btn-primary" runat="server" OnClick="btnAddParticipant_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div id="divTeamMember" runat="server" visible="false">
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Team Members</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <asp:GridView ID="dgParticipantInTeam" runat="server" EnableViewState="true"
                                AutoGenerateColumns="false"
                                AutoGenerateDeleteButton="true"
                                OnRowDeleting="dgParticipantInTeam_RowDeleting"
                                DataKeyNames="ParticipantInEventID"
                                class="table table-striped table-bordered">
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
