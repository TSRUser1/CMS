<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Standing.aspx.cs" Inherits="SEM.CMS.Result.Mobile.Medal.Standing" %>
<%@ Register TagPrefix="uc" TagName="SelectedGame" Src="~/UserControls/ucSelectedGame.ascx" %>
<%@ MasterType VirtualPath="~/RWeb.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
    <uc:SelectedGame ID="SelectedGame" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">        
    <div class="row">
        <div class="col-md-12 iconDiv">
            <h1><asp:Label id="lblHeader" runat="server" style="vertical-align:top;" class="hidden"></asp:Label>
                    <asp:ImageButton CssClass="ImageIcon" ImageUrl="/Images/Sports.png" ID="btnMedalBySports" runat="server" OnClientClick="return Navigate(this);" Text="Medal By Sports" data-navigate-url="/Medal/Country.aspx" />
                    <asp:ImageButton CssClass="ImageIcon" ImageUrl="/Images/singlemedal.png" ID="btnDailyMedallist" runat="server" OnClientClick="return Navigate(this);" Text="Daily Medallists" />
                    <asp:ImageButton CssClass="ImageIcon" ImageUrl="/Images/multimedal.png" ID="btnMultiMedallist" runat="server" OnClientClick="return Navigate(this);" Text="Multi-Medallists" data-navigate-url="/Medal/MultiMedallist.aspx?IsMulti=true" />
            </h1>
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
                            <asp:TemplateField HeaderText="Rank">
                                <ItemTemplate>
                                    <%# ViewState[SEM.CMS.Result.Mobile.WebBase.VS_MEDALSTANDINGS_TOTAL] == null ? "" : ( Convert.ToInt32(ViewState[SEM.CMS.Result.Mobile.WebBase.VS_MEDALSTANDINGS_TOTAL]) == 0 ? "" : Eval("Rank")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <a id="linkCountry" runat="server" href='<%# String.Format("~/Medal/Country.aspx?CountryID={0}", Eval("CountryID"))%>'><img id="imgCountry" src='<%# Eval("IconFilePath") %>' runat="server" /></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    Overall Total
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    <img id="imgGold" src="~/img/medal/gold_i.png" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <span id="spanGold" runat="server" visible='<%# Convert.ToInt32(Eval("GoldMedal")) == 0 ? true : false %>' ><%# Eval("GoldMedal") %></span>
                                    <a id="linkGold" runat="server" visible='<%# Convert.ToInt32(Eval("GoldMedal")) == 0 ? false : true %>'  href='<%# String.Format("~/Medal/Medallist.aspx?CountryID={0}&Medal={1}{2}", Eval("CountryID"), "GOLD", ViewState["ViewStateSportID"] != null ? "&SportID=" + ViewState["ViewStateSportID"].ToString() : "" )%>'><%# Eval("GoldMedal") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSumGold" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    <img id="imgSilver" src="~/img/medal/silver_i.png" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <span id="spanSilver" runat="server" visible='<%# Convert.ToInt32(Eval("SilverMedal")) == 0 ? true : false %>' ><%# Eval("SilverMedal") %></span>
                                    <a id="linkSilver" runat="server" visible='<%# Convert.ToInt32(Eval("SilverMedal")) == 0 ? false : true %>' href='<%# String.Format("~/Medal/Medallist.aspx?CountryID={0}&Medal={1}{2}", Eval("CountryID"), "SILVER", ViewState["ViewStateSportID"] != null ? "&SportID=" + ViewState["ViewStateSportID"].ToString() : "")%>'><%# Eval("SilverMedal") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSumSilver" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    <img id="imgBronze" src="~/img/medal/bronze_i.png" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <span id="spanBronze" runat="server" visible='<%# Convert.ToInt32(Eval("BronzeMedal")) == 0 ? true : false %>' ><%# Eval("BronzeMedal") %></span>
                                    <a id="linkBronze" runat="server" visible='<%# Convert.ToInt32(Eval("BronzeMedal")) == 0 ? false : true %>' href='<%# String.Format("~/Medal/Medallist.aspx?CountryID={0}&Medal={1}{2}", Eval("CountryID"), "BRONZE", ViewState["ViewStateSportID"] != null ? "&SportID=" + ViewState["ViewStateSportID"].ToString() : "")%>'><%# Eval("BronzeMedal") %></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSumBronze" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <span id="spanTotal" runat="server" visible='<%# Convert.ToInt32(Eval("Total")) == 0 ? true : false %>' ><%# Eval("Total") %></span>
                                    <a id="linkTotal" runat="server" visible='<%# Convert.ToInt32(Eval("Total")) == 0 ? false : true %>' href='<%# String.Format("~/Medal/Medallist.aspx?CountryID={0}{1}", Eval("CountryID"), ViewState["ViewStateSportID"] != null ? "&SportID=" + ViewState["ViewStateSportID"].ToString() : "")%>'><%# Eval("Total") %></a>
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
    <style>
        .btn-medal-standings {
            margin-top:2px;
            margin-bottom:2px;
        }
    </style>
    <script type="text/javascript">
        function Navigate(sender) {
            window.location.href = $(sender).data("navigate-url");
            return false;
        }
    </script>
</asp:Content>
