<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="ScheduleDetails.aspx.cs" Inherits="SEM.CMS.Web.Schedule.ScheduleDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/assets/bootstrap-datepicker/css/datepicker.css" />
    <link rel="stylesheet" type="text/css" href="/assets/bootstrap-daterangepicker/daterangepicker.css" />
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="CPH_CMS">
<div id="page" class="dashboard"><div class="row-fluid"><div class="span12"><div class="widget">

    <div class="widget-title">
        <h4><i class="icon-reorder"></i><asp:Label runat="server" ID="lblPageMode" Text="Add"></asp:Label> &nbsp;Schedule</h4>
        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
    </div>

    <div class="widget-body"><div class="form"><div class="form-horizontal">

        <div class="form-actions">
            <asp:Button ID="btnBack" Text="Back" class="btn btn-success" runat="server" OnClick="btnBack_Click" />
            <asp:Button ID="btnClear" Text="Clear" class="btn btn-info" runat="server" OnClick="btnClear_Click" />
        </div>

        <div class="control-group">
            <label class="control-label" for="txtScheduleName">Schedule Name</label>
            <div class="controls">
                <asp:TextBox ID="txtScheduleName" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtScheduleName" runat="server" ControlToValidate="txtScheduleName" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtScheduleDateTime">Schedule Date Time</label>
            <div class="controls">
                <div class="input-append date date-picker">
                    <asp:TextBox ID="txtScheduleDateTime" class="input-small date-picker" size="16" runat="server" ValidationGroup="validationGrp"></asp:TextBox><span class="add-on"><i runat="server" id="imgCalender" class="icon-calendar"></i></span>
                    <asp:CalendarExtender ID="txtDepositDateTime_CalendarExtender" CssClass="calendarOverride" runat="server" PopupButtonID="txtScheduleDateTime" TargetControlID="txtScheduleDateTime" Format="dd/MM/yyyy" Enabled="True"></asp:CalendarExtender>
                </div>
                <asp:RequiredFieldValidator ID="reqTxtScheduleDateTime" runat="server" ControlToValidate="txtScheduleDateTime" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="ScheduleTime">Schedule Time</label>
             <div class="controls">
               <asp:TextBox ID="txtScheduleTime" runat="server" ValidationGroup="MKE" />
               <ajaxToolkit:MaskedEditExtender ID="meeScheduleTime" runat="server" TargetControlID="txtScheduleTime" Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Time" AcceptAMPM="false" ErrorTooltipEnabled="True" />
               <ajaxToolkit:MaskedEditValidator ID="mevSchduleTime" runat="server" ForeColor="Red" ControlExtender="meeScheduleTime" ControlToValidate="txtScheduleTime" IsValidEmpty="True" Display="Dynamic" TooltipMessage="Input a 24 hrs time format" ValidationGroup="MKE"/>
             </div> 
        </div> 
        <div class="control-group">
            <label class="control-label" for="txtVenue">Venue</label>
            <div class="controls">
                <asp:TextBox ID="txtVenue" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtVenue" runat="server" ControlToValidate="txtVenue" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtLocation">Location</label>
            <div class="controls">
                <asp:TextBox ID="txtLocation" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtRoundName">Round Name</label>
            <div class="controls">
                <asp:TextBox ID="txtRoundName" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtRoundName" runat="server" ControlToValidate="txtRoundName" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtMatchNo">Match No</label>
            <div class="controls">
                <asp:TextBox ID="txtMatchNo" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtMatchNo" runat="server" ControlToValidate="txtMatchNo" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
                <asp:FilteredTextBoxExtender ID="filteredTextBoxExtenderMatchNo" runat="server" TargetControlID="txtMatchNo" FilterType="Custom, Numbers" Enabled="True"></asp:FilteredTextBoxExtender>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtCompetitionStage">Competition Stage</label>
            <div class="controls">
                <asp:TextBox ID="txtCompetitionStage" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtCompetitionStage" runat="server" ControlToValidate="txtCompetitionStage" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtTotalParticipants">Total Participants</label>
            <div class="controls">
                <asp:TextBox ID="txtTotalParticipants" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtTotalParticipants" runat="server" ControlToValidate="txtTotalParticipants" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
                <asp:FilteredTextBoxExtender ID="filteredTextBoxExtenderTotalParticipants" runat="server" TargetControlID="txtTotalParticipants" FilterType="Custom, Numbers" Enabled="True"></asp:FilteredTextBoxExtender>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="ddlCompetitionFormat">Competition Format</label>
            <div class="controls">
                <asp:DropDownList ID="ddlCompetitionFormat" runat="server" class="span6" AutoPostBack="true" OnSelectedIndexChanged="ddlCompetitionFormat_SelectedIndexChanged"></asp:DropDownList>
                <span class="add-on"><i class="icon-picture"></i></span>
                <asp:HyperLink ID="hlinkKnockOutFormat" runat="server" onclick="window.open('/img/reference/KnockoutChartFormat.jpg','KnockOutFormatPopup','width=1077,height=690,menubar=no,scrollbars=yes,toolbar=no,status=no,location=no,directories=no,resizable=yes,left=' + (screen.width - 1077) / 2 + ',top=20');return false;" NavigateUrl="#">Knock-Out Format</asp:HyperLink>
                <asp:RequiredFieldValidator ID="reqDdlCompetitionFormat" runat="server" ControlToValidate="ddlCompetitionFormat" ForeColor="Red" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="txtGroup">Group (for League system)</label>
            <div class="controls">
                <asp:TextBox ID="txtGroup" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtGroup" runat="server" ControlToValidate="txtGroup" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        
        <div class="control-group">
            <label class="control-label" for="chkIsGenerateLeagueSummary">Generate League Summary</label>
            <div class="controls">
                <asp:CheckBox ID="chkIsGenerateLeagueSummary" runat="server" />
            </div>
        </div>

        <div class="control-group">
            <label class="control-label" for="ddlStatus">Status</label>
            <div class="controls">
                <asp:DropDownList ID="ddlStatus" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlStatus" runat="server" ControlToValidate="ddlStatus" ForeColor="Red" ValidationGroup="validationGrp_ScheduleDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkHeadToHead">Head To Head</label>
            <div class="controls">
                <asp:CheckBox ID="chkHeadToHead" runat="server" />
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="chkIsMedalGame">Medal Game</label>
            <div class="controls">
                <asp:CheckBox ID="chkIsMedalGame" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkIsPublishSchedule">Publish Schedule</label>
            <div class="controls">
                <asp:CheckBox ID="chkIsPublishSchedule" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkIsPublishStartlist">Publish Startlist</label>
            <div class="controls">
                <asp:CheckBox ID="chkIsPublishStartlist" runat="server" />
            </div>
        </div>
        
        <div class="control-group">
            <label class="control-label" for="chkIsOfficial">Official Result</label>
            <div class="controls">
                <asp:CheckBox ID="chkIsOfficial" runat="server" />
            </div>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnSave" Text="Save" class="btn btn-primary" runat="server" OnClick="btnSave_Click" ValidationGroup="validationGrp_ScheduleDetails" />
        </div>
    </div></div></div>
</div></div></div></div>

</asp:Content>


