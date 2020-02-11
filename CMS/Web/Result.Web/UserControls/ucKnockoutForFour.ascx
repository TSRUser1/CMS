<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKnockoutForFour.ascx.cs" Inherits="SEM.CMS.Result.Web.UserControls.ucKnockoutForFour" %>
<style>
    .sharpen {
        background-color: #dbdada !important;
    }
</style>

<table class="table">
    <tbody>
        <tr>
            <th colspan="4">
                <asp:Label ID="lblRoundName1" runat="server" Text="Semi Final"></asp:Label></th>
            <th colspan="4">
                <asp:Label ID="lblRoundName2" runat="server" Text="Final"></asp:Label></th>
        </tr>
        <tr>
            <td>
                <div>&nbsp;</div>
            </td>
            <td>
                <div>&nbsp;</div>
            </td>
            <td>
                <div class="connector">&nbsp;</div>
            </td>
            <td>
                <div class="connector">&nbsp;</div>
            </td>
            <td>
                <div>&nbsp;</div>
            </td>
            <td>
                <div>&nbsp;</div>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <div class="country sharpen">
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
            <td>&nbsp;</td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
            <td style="border-top: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td style="border-bottom: black 4px solid; border-left: black 4px solid;"></td>
            <td>
                <div class="country">
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
                <div class="score">
                    <asp:Label ID="lblScore2_1_1" runat="server"></asp:Label>
                </div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="border-top: black 4px solid; border-left: black 4px solid;">&nbsp;</td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal2_1_2" runat="server"  />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_2_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_2_1" runat="server" />
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal1_2_1" runat="server"/>
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_2_1" runat="server" />
                </div>
            </td>
            <td style="border-bottom: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_2_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_2_2" runat="server" />
                    </div>
                    <div class="medal-icon">
                    <asp:Image ID="imgMedal1_2_2" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_2_2" runat="server" />
                </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="2">
                <div style='<%= GetStyle() %>' class="header">
                    <asp:Label ID="lblRoundName3" runat="server" Text="3rd/4th Placing"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style='<%= GetStyle() %>' class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry3_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName3_1_1" runat="server" />
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal3_1_1" runat="server"/>
                    </div>
                </div>
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="score">
                    <asp:Label ID="lblScore3_1_1" runat="server" />
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style='<%= GetStyle() %>' class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry3_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName3_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal3_1_2" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="score">
                    <asp:Label ID="lblScore3_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </tbody>
</table>
