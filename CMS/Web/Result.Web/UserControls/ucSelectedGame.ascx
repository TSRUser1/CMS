<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSelectedGame.ascx.cs" Inherits="SEM.CMS.Result.Web.UserControls.ucSelectedGame" %>
<div class="col-md-5 col-sm-6 col-xs-12 pull-right">
    <div class="title-wrapper">
        <div class="title-content">
            <h1 style="font-weight:100; margin-top:9px; font-size:26px; color:#707070">
                <asp:Label ID="lblGame" runat="server"></asp:Label></h1>
            <div style="float: left; width: 25%" class="sports-icon">
                <asp:Image ID="imgGame" runat="server" Width="70%" Height="70%"/>
            </div>
            <div style="float: left; width: 75%;margin-top:15px">
                <div class="date">
                    <strong>Date:</strong>
                    <asp:Label ID="lblGameDuration" runat="server"></asp:Label>
                </div>
                <div class="description"><strong>Number of Athletes:</strong><asp:Label ID="lblNumberAthletes" runat="server"></asp:Label></div>
            </div>

        </div>

    </div>
</div>
