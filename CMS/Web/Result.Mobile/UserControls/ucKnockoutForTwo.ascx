<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKnockoutForTwo.ascx.cs" Inherits="SEM.CMS.Result.Mobile.UserControls.ucKnockoutForTwo" %>
<style>
    .sharpen {
        background-color: #dbdada !important;
    }
</style>

<table class="table" border="1">
    <tr>
        <th colspan="4">
            <asp:Label ID="lblRoundName1" runat="server" Text="Final"></asp:Label></th>
    </tr>

    <tr>
        <td></td>
        <td>
            <div class="country">
                <div class="country-image">
                    <asp:Image ID="imgCountry1_1_1" runat="server" />
                </div>
                <div class="country-name">
                    <asp:Label ID="lblName1_1_1" runat="server"></asp:Label>
                </div>
                <div class="medal-icon">
                    <asp:Image ID="imgMedal1_1_1" runat="server" />
                </div>
            </div>
        </td>
        <td>
            <div class="score">
                <asp:Label ID="lblScore1_1_1" runat="server"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <div class="country sharpen">
                <div class="country-image">
                    <asp:Image ID="imgCountry1_1_2" runat="server" />
                </div>
                <div class="country-name">
                    <asp:Label ID="lblName1_1_2" runat="server"></asp:Label>
                </div>
                <div class="medal-icon">
                    <asp:Image ID="imgMedal1_1_2" runat="server" />
                </div>
            </div>
        </td>

        <td>
            <div class="score">
                <asp:Label ID="lblScore1_1_2" runat="server"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="4">
            <div style='<%= GetStyle() %>' class="header">
                <asp:Label ID="lblRoundName2" runat="server" Text="3rd/4th Placing"></asp:Label></div>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <div style='<%= GetStyle() %>' class="country">
                <div class="country-image">
                    <asp:Image ID="imgCountry2_1_1" runat="server" />
                </div>
                <div class="country-name">
                    <asp:Label ID="lblName2_1_1" runat="server"></asp:Label>
                </div>
                <div class="medal-icon">
                    <asp:Image ID="imgMedal2_1_1" runat="server" />
                </div>
            </div>
        </td>
        <td>
            <div style='<%= GetStyle() %>' class="score">
                <asp:Label ID="lblScore2_1_1" runat="server"></asp:Label>
            </div>
        </td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <div style='<%= GetStyle() %>' class="country sharpen">
                <div class="country-image">
                    <asp:Image ID="imgCountry2_1_2" runat="server" />
                </div>
                <div class="country-name">
                    <asp:Label ID="lblName2_1_2" runat="server"></asp:Label>
                </div>
                <div class="medal-icon">
                    <asp:Image ID="imgMedal2_1_2" runat="server" />
                </div>
            </div>
        </td>
        <td>
            <div style='<%= GetStyle() %>' class="score">
                <asp:Label ID="lblScore2_1_2" runat="server"></asp:Label>
            </div>
        </td>
    </tr>
</table>
