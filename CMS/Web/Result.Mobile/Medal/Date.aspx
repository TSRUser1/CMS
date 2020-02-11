<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Date.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Medal.Date" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1><asp:Label id="lblHeader" runat="server"></asp:Label>&nbsp;<asp:Image ID="imgCountry" runat="server" Visible="false" /></h1>
        </div>
    </div>
    <section class="daily-medallists">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="dgMedalStanding" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                        AutoGenerateColumns="false"
                        AllowPaging="false"
                        Width="100%"
                        OnPreRender="dgMedalStanding_PreRender"
                        OnRowDataBound="dgMedalStanding_RowDataBound"
                        ShowFooter="true"
                        >
                        <Columns>
                            <asp:TemplateField HeaderText="Sport">
                                <ItemTemplate>
                                    <a id="linkTotal" runat="server" href='<%# String.Format("~/Medal/MultiMedallist.aspx?Date={0}&SportID={1}", ViewState["ViewStateDate"], Eval("SportID"))%>'><%# Eval("SportName") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    Overall Total
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    <img id="imgGold" src="~/img/medal/gold.png" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <a id="linkGold" runat="server" href='<%# String.Format("~/Medal/MultiMedallist.aspx?Date={0}&SportID={1}&Medal={2}", ViewState["ViewStateDate"], Eval("SportID"), "GOLD")%>'><%# Eval("GoldMedal") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSumGold" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    <img id="imgSilver" src="~/img/medal/silver.png" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <a id="linkSilver" runat="server" href='<%# String.Format("~/Medal/MultiMedallist.aspx?Date={0}&SportID={1}&Medal={2}", ViewState["ViewStateDate"], Eval("SportID"), "SILVER")%>'><%# Eval("SilverMedal") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSumSilver" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    <img id="imgBronze" src="~/img/medal/bronze.png" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <a id="linkBronze" runat="server" href='<%# String.Format("~/Medal/MultiMedallist.aspx?Date={0}&SportID={1}&Medal={2}", ViewState["ViewStateDate"], Eval("SportID"), "BRONZE")%>'><%# Eval("BronzeMedal") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSumBronze" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <a id="linkTotal" runat="server" href='<%# String.Format("~/Medal/MultiMedallist.aspx?Date={0}&SportID={1}", ViewState["ViewStateDate"], Eval("SportID"))%>'><%# Eval("Total") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSumTotal" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
