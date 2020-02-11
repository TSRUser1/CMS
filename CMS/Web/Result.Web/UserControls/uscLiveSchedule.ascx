<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uscLiveSchedule.ascx.cs" Inherits="SEM.CMS.Result.Web.UserControls.uscLiveSchedule" %>
<div class="table-responsive">
    <table class="table table-striped table-radius blue-62-header live-schedule" style="table-layout:fixed;">
        <colgroup>
            <col style="width:60px">
            <col style="width:100%">
        </colgroup>
        <thead>
            <tr>
                <th><h3><a id="linkLiveSchedule" runat="server" href="~/Schedule/Live.aspx" style="color:#fff;">Live Schedule<b class="arrow-right"></b></a></h3></th>
                <th></th>
            </tr>
        </thead>
        <tbody class="grey-bg">
            <tr class="horizontal-header">
                <th style="white-space:normal;">Start Time</th>
                <th>Event</th>
            </tr>
            <tr>
                <td colspan="2" style="max-height:250px;padding:0px;">
                    <div class="wrapper" style="max-height:250px; height:auto;overflow-y:auto;">
                        <asp:ListView ID="listLiveSchedule" runat="server" ItemPlaceholderID="itemPlaceHolder"
                            OnItemDataBound="listLiveSchedule_ItemDataBound"
                            >
                            <LayoutTemplate>
                                <table style="width:100%;table-layout:fixed;" class="live-schedule-inner">
                                    <col style="width:60px">
                                    <col style="width:100%">
                                    <tr id="itemPlaceHolder" runat="server"></tr>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr ID="rowLiveSchedule" runat="server">
                                    <td style="padding:5px;">
                                        <asp:HiddenField ID="hidURL" runat="server" Value='<%# String.Format("/Event/Results.aspx?EventID={0}&ScheduleID={1}", Eval("EventID"), Eval("ScheduleID"))%>' />
                                        <%# Convert.ToDateTime(Eval("ScheduleDateTime")).ToString("HH:mm") %>
                                        <br />
                                        <img id="imgSport" runat="server" src='<%#Eval("SportImageFilePath") == DBNull.Value ? "" : Eval("SportImageFilePath").ToString().Replace(".png", "_small.png") %>' class="image-small" />
                                    </td>
                                    <td style="padding:5px;" class="live-schedule-cell">
                                        <strong><%# Eval("EventName") %></strong>
                                        <br />
                                        <span><%# Eval("ScheduleName") %></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <div style="display:block; width:100%; text-align:left; padding-top:10px; padding-bottom:10px; padding-left:5px;">No schedules today.</div>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</div>
<script type="text/javascript">
    Sys.Application.add_load(BindLiveScheduleEvents);
</script>