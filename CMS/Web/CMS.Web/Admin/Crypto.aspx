<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crypto.aspx.cs" Inherits="SEM.CMS.Web.Admin.Crypto" MasterPageFile="../CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_CMS" runat="server">
    
    <div>
        <p>Text to be Encrypted/Decrypted: </p>
        <asp:TextBox ID="txtOriText" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox>
        <br /><br />

        <p>Secret Key: </p><asp:TextBox ID="txtSecret" runat="server" Width="150px"></asp:TextBox><br />
        <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" />
        <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" OnClick="btnDecrypt_Click" />
        <br /><br />

        <p>Text after Encrypted/Decrypted: </p><asp:TextBox ID="txtFinalText" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox>
    </div>

</asp:Content>
