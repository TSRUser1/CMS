<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKnockoutForSixTeen.ascx.cs" Inherits="SEM.CMS.Result.Mobile.UserControls.ucKnockoutForSixTeen" %>
<style>
    .sharpen {
        background-color: #dbdada !important;
    }
</style>

<table class="table">
    <tbody>
        <tr>
            <th colspan="4">
                <asp:Label ID="lblRoundName1" runat="server" Text="Round of 16"></asp:Label></th>
            <th colspan="4">
                <asp:Label ID="lblRoundName2" runat="server" Text="Quater Final"></asp:Label></th>
            <th colspan="4">
                <asp:Label ID="lblRoundName3" runat="server" Text="Semi Final"></asp:Label></th>
            <th colspan="4">
                <asp:Label ID="lblRoundName4" runat="server" Text="Final"></asp:Label></th>
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
                </div>
                <div class="medal-icon">
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_1_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-upper">&nbsp;</td>
            <td class="back-upper">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_1_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_1_1" runat="server"></asp:Label>
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_2_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_2_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_2_1" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-lower">&nbsp;</td>
            <td class="back-lower">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_1_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-upper">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_2_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_2_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_2_2" runat="server"></asp:Label>
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
            <td class="back-upper">&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry3_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName3_1_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal3_1_1" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore3_1_1" runat="server"></asp:Label>
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
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_3_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_3_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_3_1" runat="server"></asp:Label>
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
            <td class="back-lower">&nbsp;
            </td>
            <td>
                <div class="country sharpen">
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
                <div class="score">
                    <asp:Label ID="lblScore3_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-upper">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_3_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_3_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_3_2" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-upper">&nbsp;
            </td>
            <td class="back-upper">&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_2_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_2_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_2_1" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-lower">&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td class="link">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_4_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_4_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_4_1" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-lower">&nbsp;
            </td>
            <td class="back-lower">&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_2_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_2_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_2_2" runat="server"></asp:Label>
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
            <td class="link">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_4_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_4_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_4_2" runat="server"></asp:Label>
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
            <td class="back-upper">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry4_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName4_1_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal4_1_1" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore4_1_1" runat="server"></asp:Label>
                </div>
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
                        <asp:Image ID="imgCountry1_5_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_5_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_5_1" runat="server"></asp:Label>
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
            <td class="back-lower">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry4_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName4_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal4_1_2" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore4_1_2" runat="server"></asp:Label>
                </div>
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
                        <asp:Image ID="imgCountry1_5_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_5_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_5_2" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-upper">&nbsp;
            </td>
            <td class="back-upper">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_3_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_3_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_3_1" runat="server"></asp:Label>
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
            <td class="link">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_6_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_6_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_6_1" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-lower">&nbsp;
            </td>
            <td class="back-lower">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_3_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_3_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_3_2" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-upper">&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td class="link">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_6_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_6_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_6_2" runat="server"></asp:Label>
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
            <td class="back-upper">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry3_2_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName3_2_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal3_2_1" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore3_2_1" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-lower">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_7_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_7_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_7_1" runat="server"></asp:Label>
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
            <td class="back-lower">&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry3_2_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName3_2_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal3_2_2" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore3_2_2" runat="server"></asp:Label>
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
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_7_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_7_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_7_2" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-upper">&nbsp;
            </td>
            <td class="back-upper">&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_4_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_4_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_4_1" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-lower">&nbsp;
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
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_8_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_8_1" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_8_1" runat="server"></asp:Label>
                </div>
            </td>
            <td class="front-lower">&nbsp;
            </td>
            <td class="back-lower">&nbsp;
            </td>
            <td>
                <div class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry2_4_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName2_4_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore2_4_2" runat="server"></asp:Label>
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
            <td colspan="2">
                <div style='<%= GetStyle() %>' class="header">
                    <asp:Label ID="lblRoundName5" runat="server" Text="3rd/4th Placing"></asp:Label>
                </div>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>
                <div class="country">
                    <div class="country-image">
                        <asp:Image ID="imgCountry1_8_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName1_8_2" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="medal-icon">
                </div>
            </td>
            <td>
                <div class="score">
                    <asp:Label ID="lblScore1_8_2" runat="server"></asp:Label>
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
            <td>&nbsp;
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry5_1_1" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName5_1_1" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal5_1_1" runat="server" CssClass="medal-icon" />
                    </div>
                </div>
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="score">
                    <asp:Label ID="lblScore5_1_1" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
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
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="country sharpen">
                    <div class="country-image">
                        <asp:Image ID="imgCountry5_1_2" runat="server" />
                    </div>
                    <div class="country-name">
                        <asp:Label ID="lblName5_1_2" runat="server"></asp:Label>
                    </div>
                    <div class="medal-icon">
                        <asp:Image ID="imgMedal5_1_2" runat="server" />
                    </div>
                </div>
            </td>
            <td>
                <div style='<%= GetStyle() %>' class="score">
                    <asp:Label ID="lblScore5_1_2" runat="server"></asp:Label>
                </div>
            </td>
            <td>&nbsp;
            </td>
        </tr>
    </tbody>
</table>
