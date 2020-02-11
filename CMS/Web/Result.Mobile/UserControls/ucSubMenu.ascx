<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSubMenu.ascx.cs" Inherits="SEM.CMS.Result.Mobile.UserControls.ucSubMenu" %>
<div class="col-md-7 col-sm-6 col-xs-12">
    <nav class="sub-page-menu">
        <ul>
            <li>
                <asp:HyperLink ID="hlResult" ToolTip="Result" runat="server">Result</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="hlMedals" ToolTip="Medals and Final Ranking" runat="server">Medals</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="hlAthletes" ToolTip="Number of Athletes" runat="server">Athletes</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="hlRecords" ToolTip="Event Records" runat="server">Records</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="hlReports" ToolTip="Event Reports" runat="server">Reports</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="hlSummary" ToolTip="Event Summary" runat="server">Summary</asp:HyperLink></li>
        </ul>
    </nav>
    <h3 class="game-title"><asp:Label ID="lblScheduleName" runat="server"></asp:Label></h3>
    <h3 class="game-title"><asp:Label ID="lblScheduleDateTime" runat="server" Visible="false"></asp:Label></h3>
</div>
