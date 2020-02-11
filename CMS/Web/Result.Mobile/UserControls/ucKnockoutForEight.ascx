<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKnockoutForEight.ascx.cs" Inherits="SEM.CMS.Result.Mobile.UserControls.ucKnockoutForEight" %>
<style>
    .sharpen {
        background-color: #dbdada !important;
    }
</style>
<table class="table">
    <tbody>
        <tr>
            <th colspan="4">
                <asp:Label ID="lblRoundName1" runat="server" Text="Quater Final"></asp:Label></th>
            <th colspan="4">
                <asp:Label ID="lblRoundName2" runat="server" Text="Semi Final"></asp:Label></th>
            <th colspan="4">
                <asp:Label ID="lblRoundName3" runat="server" Text="Final"></asp:Label></th>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>
                <div class="connector">&nbsp;</div>
            </td>
            <td>
                <div class="connector">&nbsp;</div>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>
                <div class="connector">&nbsp;</div>
            </td>
            <td>
                <div class="connector">&nbsp;</div>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_1_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_1_1" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td style="border-top: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td style="border-bottom: black 4px solid;">&nbsp;</td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_1_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal2_1_1" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_1_1" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_2_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_2_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_2_1" runat="server"></asp:Label>
                </div>
            </td>
            <td style="border-bottom: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal2_1_2" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td style="border-top: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_2_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_2_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_2_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="border-bottom: black 4px solid; border-left: black 4px solid;">&nbsp;</td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry3_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName3_1_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal3_1_1" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore3_1_1" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_3_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_3_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_3_1" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="border-top: black 4px solid; border-left: black 4px solid;">&nbsp;</td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry3_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName3_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal3_1_2" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore3_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_3_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_3_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_3_2" runat="server"></asp:Label>
                </div>
            </td>
            <td style="border-top: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td style="border-bottom: black 4px solid;">&nbsp;</td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_2_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_2_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal2_2_1" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_2_1" runat="server"></asp:Label>
                </div>
            </td>
            <td style="border-bottom: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_4_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_4_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_4_1" runat="server"></asp:Label>
                </div>
            </td>
            <td style="border-bottom: black 4px solid; border-right: black 4px solid;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_2_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_2_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal2_2_2" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_2_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="2">
                <div style='<%= GetStyle() %>' class="header">
                    <asp:Label ID="lblRoundName4" runat="server" Text="3rd/4th Placing"></asp:Label></div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_4_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_4_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_4_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style='<%= GetStyle() %>' class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry4_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName4_1_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal4_1_1" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="score">
                    <asp:Label ID="lblScore4_1_1" runat="server"></asp:Label>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <div style='<%= GetStyle() %>' class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry4_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName4_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal4_1_2" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="score">
                    <asp:Label ID="lblScore4_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </tbody>
</table>
