<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SEM.CMS.Web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_CMS" runat="server">
    <h1 class="title-content">Error Page</h1>
    <div style="line-height:1.6;font-weight:300;text-align:justify;padding-bottom:50px">
        <p style="margin-bottom:30px"><img src="img/error/nila.png" /></p>
        <p>
            <span style="font-size: 18px">Well, this is a little awkward. We can't find the page you're looking for! It may have been moved, or deleted.</span>
        </p>
        <p>
            <span style="font-size: 18px">Click <a href="Index.aspx">here</a> to go back to homepage.
            </span>
        </p>
    </div>
</asp:Content>
