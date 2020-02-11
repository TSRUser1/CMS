<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCaptcha.aspx.cs" Inherits="SEM.CMS.Web.TemplateWF.TestCaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: 100%;
            vertical-align: baseline;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin: 0;
            padding: 0;
        }
        .auto-style2 {
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <table style="width:100%;">
            <tr>
                <td>
                    <div class="auto-style1">
                        <div class="auto-style1">
                            <asp:UpdatePanel ID="UpdatePanelCaptcha" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ImageButton ID="img_captcha" runat="server" OnClick="img_captcha_Click" ToolTip="Click to refresh the Code" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCode" runat="server" class="input-xsmall" MaxLength="4" placeholder="Code"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>
