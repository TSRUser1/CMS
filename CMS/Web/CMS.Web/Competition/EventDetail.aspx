<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="EventDetail.aspx.cs" Inherits="SEM.CMS.Web.EventDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH_CMS" runat="server">  
<div id="page" class="dashboard"><div class="row-fluid"><div class="span12"><div class="widget">

    <div class="widget-title">
        <h4><i class="icon-reorder"></i><asp:Label runat="server" ID="lblPageMode" Text="Add"></asp:Label> &nbsp;Event</h4>
        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
    </div>

    <div class="widget-body"><div class="form"><div class="form-horizontal">
         
        <div class="form-actions">
            <asp:Button ID="btnBack" Text="Back" class="btn btn-success" runat="server" OnClick="btnBack_Click" />
            <asp:Button ID="btnClear" Text="Clear" class="btn btn-info" runat="server" OnClick="btnClear_Click" />
        </div>

         <div class="control-group">
            <label class="control-label" for="txtEventName">Event Name</label>
            <div class="controls">
                <asp:TextBox ID="txtEventName" runat="server" class="span6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTxtEventName" runat="server" ControlToValidate="txtEventName" ForeColor="Red" ValidationGroup="validationGrp_EventDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="txtEventCode">Event Code</label>
            <div class="controls">
                <asp:TextBox ID="txtEventCode" runat="server" class="span6"></asp:TextBox>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="ddlGender">Gender</label>
            <div class="controls">
                <asp:DropDownList ID="ddlGender" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlGender" runat="server" ControlToValidate="ddlGender" ForeColor="Red" ValidationGroup="validationGrp_EventDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="control-group" style="display:none">
            <label class="control-label" for="ddlPlayFormat">Play Format</label>
            <div class="controls">
                <asp:DropDownList ID="ddlPlayFormat" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlPlayFormat" runat="server" ControlToValidate="ddlPlayFormat" ForeColor="Red" ValidationGroup="validationGrp_EventDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="ddlEventType">Event Type</label>
            <div class="controls">
                <asp:DropDownList ID="ddlEventType" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlEventType" runat="server" ControlToValidate="ddlEventType" ForeColor="Red" ValidationGroup="validationGrp_EventDetails" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="chkShowResult">Show Result</label>
            <div class="controls">
                <asp:CheckBox ID="chkShowResult" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkShowMedal">Show Medal</label>
            <div class="controls">
                <asp:CheckBox ID="chkShowMedal" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkShowAthelete">Show Athelete</label>
            <div class="controls">
                <asp:CheckBox ID="chkShowAthelete" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkShowReport">Show Report</label>
            <div class="controls">
                <asp:CheckBox ID="chkShowReport" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkShowRecord">Show Record</label>
            <div class="controls">
                <asp:CheckBox ID="chkShowRecord" runat="server" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chkShowSummary">Show Summary</label>
            <div class="controls">
                <asp:CheckBox ID="chkShowSummary" runat="server" />
            </div>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnInsert" Text="Save" class="btn btn-primary" runat="server" OnClick="btnInsert_Click" ValidationGroup="validationGrp_EventDetails" />
        </div>
    </div></div></div>
</div></div></div></div>

<div id="page2" class="dashboard"><div class="row-fluid"><div class="span12"><div class="widget">
    <div class="widget-title">
        <h4><i class="icon-reorder"></i><asp:Label runat="server" ID="lblUploadFileTitle" Text="Upload File"></asp:Label></h4>
        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
    </div>

    <div class="widget-body"><div class="form"><div class="form-horizontal">
         <div class="control-group">
            <label class="control-label" for="ddlFileGroupType">File Group</label>
            <div class="controls">
                 <asp:DropDownList ID="ddlFileGroupType" runat="server" class="span6"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqDdlFileGroupType" runat="server" ControlToValidate="ddlFileGroupType" ForeColor="Red" ValidationGroup="validationGrp_UploadFile" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="chkLinkToSport">Link To Sport</label>
            <div class="controls">
                <asp:CheckBox ID="chkLinkToSport" runat="server" />
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="txtScheduleName">File Upload</label>
            <div class="controls">
                <asp:FileUpload ID="fuuploadControl" runat="server" class="span6"/>
                <asp:RequiredFieldValidator ID="reqFuuploadControl" runat="server" ControlToValidate="fuuploadControl" ForeColor="Red" ValidationGroup="validationGrp_UploadFile" Display="Dynamic" Text="* Required field!"></asp:RequiredFieldValidator>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" class="btn btn-primary" OnClick="btnUpload_Click" ValidationGroup="validationGrp_UploadFile"/>
            </div>
        </div>
        <div class="control-group">
            <asp:GridView ID="dgFileUpload"  runat="server" EnableViewState="true"
                class="table table-striped table-bordered"
                AutoGenerateColumns="false"
                AutoGenerateDeleteButton="true" 
                AllowPaging="true"
                OnRowDeleting="DGFileUpload_RowDeleting"
                OnPageIndexChanging="DGFileUpload_PageIndexChanging" 
                DataKeyNames="FileID">
                <Columns>
                    <asp:TemplateField HeaderText="No." ItemStyle-Width="20px">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
   </div></div></div>
</div></div></div></div>
</asp:Content>
