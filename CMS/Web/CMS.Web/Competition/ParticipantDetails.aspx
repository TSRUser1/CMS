<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="ParticipantDetails.aspx.cs" Inherits="SEM.CMS.Web.Competition.ParticipantDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_CMS">
<div id="page" class="dashboard"><div class="row-fluid"><div class="span12"><div class="widget">

        <div class="widget-title">
        <h4><i class="icon-reorder"></i><asp:Label runat="server" ID="lblPageMode" Text="Add"></asp:Label> &nbsp;Participant</h4>
        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
    </div> 

    <div class="widget-body"><div class="form"><div class="form-horizontal">

        <div class="form-actions">
            <asp:Button ID="btnBack" Text="Back" class="btn btn-success" runat="server" OnClick="btnBack_Click" />
            <asp:Button ID="btnClear" Text="Clear" class="btn btn-info" runat="server" OnClick="btnClear_Click" />
        </div>

        <div class="control-group">
                <label class="control-label" for="txtFullName">Full Name</label>
            <div class="controls">
                    <asp:TextBox ID="txtFullName" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtFullName" runat="server" ControlToValidate="txtFullName" ForeColor="Red" ValidationGroup="validationGrp_ParticipantDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtFamilyName">Family Name</label>
            <div class="controls">
                <asp:TextBox ID="txtFamilyName" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="txtGivenName">Given Name</label>
            <div class="controls">
                <asp:TextBox ID="txtGivenName" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtIPCNo">IPC No</label>
            <div class="controls">
                <asp:TextBox ID="txtIPCNo" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtWeight">Weight</label>
            <div class="controls">
                <asp:TextBox ID="txtWeight" runat="server" class="span6"></asp:TextBox>
               <ajaxToolkit:MaskedEditExtender ID="meeWeight" runat="server" TargetControlID="txtWeight" Mask="999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" ErrorTooltipEnabled="True" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtHeight">Height</label>
            <div class="controls">
                <asp:TextBox ID="txtHeight" runat="server" class="span6"></asp:TextBox>
               <ajaxToolkit:MaskedEditExtender ID="meeHeight" runat="server" TargetControlID="txtHeight" Mask="999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" ErrorTooltipEnabled="True" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtAccreditationNo">Accreditation No</label>
            <div class="controls">
                <asp:TextBox ID="txtAccreditationNo" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtDOB">Date of Birth</label>
            <div class="controls">
                <div class="input-append date date-picker">
                    <asp:TextBox ID="txtDOB" class="input-small date-picker" size="16" runat="server" ></asp:TextBox><span class="add-on"><i runat="server" id="imgCalender" class="icon-calendar"></i></span>
                    <asp:CalendarExtender ID="txtDOB_CalendarExtender" CssClass="calendarOverride" runat="server" PopupButtonID="txtDOB" TargetControlID="txtDOB" Format="dd/MM/yyyy" Enabled="True"></asp:CalendarExtender>
                </div>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="ddlGender">Gender</label>
            <div class="controls">
                <asp:DropDownList ID="ddlGender" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlGender" runat="server" ControlToValidate="ddlGender" ForeColor="Red" ValidationGroup="validationGrp_ParticipantDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="ddlCountry">Country</label>
            <div class="controls">
                    <asp:DropDownList ID="ddlCountry" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlCountry" runat="server" ControlToValidate="ddlCountry" ForeColor="Red" ValidationGroup="validationGrp_ParticipantDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtPassportNo">Passport No</label>
            <div class="controls">
                <asp:TextBox ID="txtPassportNo" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtPassportNo" runat="server" ControlToValidate="txtPassportNo" ForeColor="Red" ValidationGroup="validationGrp_ParticipantDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="ddlMainCategory">Main Category</label>
            <div class="controls">
                <asp:DropDownList ID="ddlMainCategory" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlMainCategory" runat="server" ControlToValidate="ddlMainCategory" ForeColor="Red" ValidationGroup="validationGrp_ParticipantDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtSport">Sport</label>
            <div class="controls">
               <asp:DropDownList ID="ddlSport" runat="server" class="span6" AutoPostBack="true" OnSelectedIndexChanged="ddlSport_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlSport" runat="server" ControlToValidate="ddlSport" ForeColor="Red" ValidationGroup="validationGrp_ParticipantEvent" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="txtEvent">Event</label>
            <div class="controls">
                <asp:DropDownList ID="ddlEvent" runat="server" class="span6" AutoPostBack="true" OnSelectedIndexChanged="ddlEvent_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlEvent" runat="server" ControlToValidate="ddlEvent" ForeColor="Red" ValidationGroup="validationGrp_ParticipantEvent" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <%--<div class="control-group">
            <label class="control-label" for="txtTeamID">Team ID (For Team Game)</label>
            <div class="controls">
                <asp:DropDownList ID="ddlTeam" runat="server" class="span6" ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlTeam" runat="server" ControlToValidate="ddlTeam" ForeColor="Red" ValidationGroup="validationGrp_ParticipantEvent" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>--%>
        <div class="control-group">
            <label class="control-label" for="txtEvent">Sport Class</label>
            <div class="controls">
                <asp:DropDownList ID="ddlSportClass" runat="server" class="span6"></asp:DropDownList>&nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" class="btn btn-warning" ValidationGroup="validationGrp_ParticipantEvent" />
                <asp:RequiredFieldValidator ID="reqDdlSportClass" runat="server" ControlToValidate="ddlSportClass" ForeColor="Red" ValidationGroup="validationGrp_ParticipantEvent" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="control-group">
              <div class="controls">
              <asp:GridView ID="dgParticipantInEvent"  runat="server" EnableViewState="true"
                AutoGenerateColumns="false"
                AutoGenerateEditButton ="true"
                AutoGenerateDeleteButton="true"  class="table table-striped table-bordered"
                AllowPaging="true"
                OnRowCancelingEdit="dgParticipantInEvent_RowCancelingEdit"
                OnRowEditing="dgParticipantInEvent_RowEditing"
                OnRowDeleting="DGParticipantInEvent_RowDeleting"
                OnRowUpdating="dgParticipantInEvent_RowUpdating"
                OnPageIndexChanging="DGParticipantInEvent_PageIndexChanging" 
                OnRowDataBound="dgParticipantInEvent_RowDataBound"
                DataKeyNames="ParticipantInEventID,EventName,CreatedDateTime">
                <Columns>
                    <asp:TemplateField HeaderText="No." ItemStyle-Width="20px">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sport Class" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <%# Eval("SportClassCode") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="gridDDLSportClassCode" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
             </asp:GridView>
          </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtCardPhotoPath">Card Photo Path</label>
            <div class="controls">
                <asp:TextBox ID="txtCardPhotoPath" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtCardPhotoPathThumbnail">Card Photo Path Thumbnail</label>
            <div class="controls">
                <asp:TextBox ID="txtCardPhotoPathThumbnail" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtCardPhotoPathExternal">Card Photo Path External</label>
            <div class="controls">
                <asp:TextBox ID="txtCardPhotoPathExternal" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnSave" Text="Save" class="btn btn-primary" runat="server" OnClick="btnSave_Click" ValidationGroup="validationGrp_ParticipantDetails" />
        </div>
    </div></div></div>
</div></div></div></div>

</asp:Content>

