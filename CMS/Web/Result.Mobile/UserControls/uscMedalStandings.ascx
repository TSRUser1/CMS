<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uscMedalStandings.ascx.cs" Inherits="SEM.CMS.Result.Mobile.UserControls.uscMedalStandings" %>

<div class="table-responsive">
        <style>
        .arrow-right {
            margin-left: 2px;
            vertical-align: middle;
            display: inline-block;
            width: 0;
            height: 0;
            border-top: 4px solid transparent;
            border-bottom: 4px solid transparent;
            border-left: 4px solid #fff;
        }
    </style>

    <asp:GridView ID="dgMedalStanding" runat="server" EnableViewState="true" CssClass="table pink-62-header medal-standings" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
        AutoGenerateColumns="false"
        AllowPaging="false"
        Width="100%"
        OnRowCreated="dgMedalStanding_RowCreated"
        OnPreRender="dgMedalStanding_PreRender"
        >
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="medal-standings-header">
                <HeaderTemplate>
                    <h3><a id="linkMedalStanding" runat="server" href="~/Medal/Standing.aspx" style="color:#fff;vertical-align:middle;">Medal Standings<b class="arrow-right"></b></a><asp:Label ID="lblMedalStandingHeader" runat="server" Visible="false" CssClass="label-medal-standing"></asp:Label></h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# ViewState[SEM.CMS.Result.Mobile.WebBase.VS_MEDALSTANDINGS_TOTAL] == null ? "" : ( Convert.ToInt32(ViewState[SEM.CMS.Result.Mobile.WebBase.VS_MEDALSTANDINGS_TOTAL]) == 0 ? "" : Eval("Rank")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a id="linkCountry" runat="server" href='<%# String.Format("~/Schedule/ScheduleCountry.aspx?CountryID={0}", Eval("CountryID")) %>'><img id="imgCountry" src='<%# Eval("IconFilePath") %>' runat="server" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center">
                <ItemTemplate>
                    <%# Eval("GoldMedal") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center">
                <ItemTemplate>
                    <%# Eval("SilverMedal") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center">
                <ItemTemplate>
                    <%# Eval("BronzeMedal") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center">
                <ItemTemplate>
                    <%# Eval("Total") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="dgMedalStandingCountry" runat="server" EnableViewState="true" CssClass="table pink-62-header medal-standings" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
        AutoGenerateColumns="false"
        AllowPaging="false"
        Width="100%"
        OnRowCreated="dgMedalStandingCountry_RowCreated"
        OnPreRender="dgMedalStandingCountry_PreRender"
        Visible="false"
        >
        <Columns>
            <asp:TemplateField HeaderStyle-Width="34%" ItemStyle-Width="34%" ItemStyle-CssClass="sport-name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="medal-standings-header">
                <HeaderTemplate>
                    <h3><a id="linkMedalStanding" runat="server" href="~/Medal/Standing.aspx" style="color:#fff;vertical-align:middle;">Medal Standings<b class="arrow-right"></b></a><asp:Label ID="lblHeaderCountry" runat="server" Visible="false" CssClass="label-medal-standing"></asp:Label></h3>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Image ID="imgSport" runat="server" ImageUrl='<%# Eval("SportImageFilePath") != DBNull.Value ? Eval("SportImageFilePath").ToString().Replace(".png", "_small.png") : "" %>' AlternateText='<%# Eval("SportName")%>' ToolTip='<%# Eval("SportName")%>' CssClass="img-sport"  />
                   <span class="label-sport-name" style="display:none;"><%# Eval("SportName")%></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-Width="16%" ItemStyle-Width="16%">
                <ItemTemplate>
                    <%# Eval("GoldMedal") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-Width="16%" ItemStyle-Width="16%">
                <ItemTemplate>
                    <%# Eval("SilverMedal") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-Width="16%" ItemStyle-Width="16%">
                <ItemTemplate>
                    <%# Eval("BronzeMedal") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-Width="18%" ItemStyle-Width="18%">
                <ItemTemplate>
                    <%# Eval("Total") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <script type="text/javascript">
        Sys.Application.add_load(BindMedalStandingsEvents);
    </script>
</div>