<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="General.aspx.cs" Inherits="SEM.CMS.Result.Web.Schedule.General" %>

<%@ Register TagPrefix="uc" TagName="MedalStandings" Src="~/UserControls/uscMedalStandings.ascx" %>
<%@ Register TagPrefix="uc" TagName="LiveSchedule" Src="~/UserControls/uscLiveSchedule.ascx" %>
<%@ Register TagPrefix="uc" TagName="LatestMedalist" Src="~/UserControls/uscLatestMedalist.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">

    <div class="col-md-12">
        <div class="row">
            <h1>General Schedule</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <div class="schedule">
                <asp:GridView ID="dgGeneralSchedule" runat="server" EnableViewState="true" CssClass="table table-striped table-bordered pink-large-header2" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                    AutoGenerateColumns="false"
                    AllowPaging="false"
                    DataKeyNames="SportID"
                    Width="100%"
                    OnDataBound="dgGeneralSchedule_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="30%" ItemStyle-CssClass="sport-name">
                            <ItemTemplate>
                                <asp:HyperLink ID="linkSport" CssClass="taphover" runat="server" Visible='<%# Convert.ToInt32(Eval("SportID")) != -1%>' NavigateUrl='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}", Eval("SportID")) %>' Text='<%#Eval("SportName") %>' Font-Bold="true"></asp:HyperLink>
                                <asp:Label ID="labelSport" runat="server" Visible='<%# Convert.ToInt32(Eval("SportID")) == -1%>' Text='<%#Eval("SportName") %>' Font-Bold="true" ForeColor="#5a5a5a"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-03">
                                    <span class="day">3</span><span class="month">Dec</span>
                                </a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="taphover_icon">
                                    <a id="linkSchedule3Dec" runat="server" href='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}&date={1}", Eval("SportID"), "2015-12-03")%>' visible='<%# Convert.ToInt32(Eval("SportID")) == -1 ? false : true%>'>
                                        <asp:Image ID="img3Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("3DecImage"))%>' class="img-circle" Visible='<%# Convert.ToBoolean(Eval("3Dec")) ? true : false%>' />
                                    </a>
                                </div>
                                <asp:Image ID="linkScheduleOC3Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("3DecImage"))%>' class="img-circle" Visible='<%# Convert.ToInt32(Eval("SportID")) == -1 ? true : false%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-04">
                                    <span class="day">4</span><span class="month">Dec</span>
                                </a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="taphover_icon">
                                    <a id="linkSchedule4Dec" runat="server" href='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}&date={1}", Eval("SportID"), "2015-12-04")%>'>
                                        <asp:Image ID="img4Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("4DecImage"))%>' class="img-circle" Visible='<%# Convert.ToBoolean(Eval("4Dec"))%>' />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-05">
                                    <span class="day">5</span><span class="month">Dec</span>
                                </a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="taphover_icon">
                                    <a id="linkSchedule5Dec" runat="server" href='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}&date={1}", Eval("SportID"), "2015-12-05")%>'>
                                        <asp:Image ID="img5Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("5DecImage"))%>' class="img-circle" Visible='<%# Convert.ToBoolean(Eval("5Dec"))%>' />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-06">
                                    <span class="day">6</span><span class="month">Dec</span>
                                </a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="taphover_icon">
                                    <a id="linkSchedule6Dec" runat="server" href='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}&date={1}", Eval("SportID"), "2015-12-06")%>'>
                                        <asp:Image ID="img6Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("6DecImage"))%>' class="img-circle" Visible='<%# Convert.ToBoolean(Eval("6Dec"))%>' />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-07">
                                    <span class="day">7</span><span class="month">Dec</span>
                                </a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="taphover_icon">
                                    <a id="linkSchedule7Dec" runat="server" href='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}&date={1}", Eval("SportID"), "2015-12-07")%>'>
                                        <asp:Image ID="img7Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("7DecImage"))%>' class="img-circle" Visible='<%# Convert.ToBoolean(Eval("7Dec"))%>' />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-08">
                                    <span class="day">8</span><span class="month">Dec</span>
                                </a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="taphover_icon">
                                    <a id="linkSchedule8Dec" runat="server" href='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}&date={1}", Eval("SportID"), "2015-12-08")%>'>
                                        <asp:Image ID="img8Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("8DecImage"))%>' class="img-circle" Visible='<%# Convert.ToBoolean(Eval("8Dec"))%>' />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-09">
                                    <span class="day">9</span><span class="month">Dec</span>
                                </a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="taphover_icon">
                                    <a id="linkSchedule9Dec" runat="server" href='<%# String.Format("~/Schedule/Schedule.aspx?sportid={0}&date={1}", Eval("SportID"), "2015-12-09")%>' visible='<%# Convert.ToInt32(Eval("SportID")) == -1 ? false : true%>'>
                                        <asp:Image ID="img9Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("9DecImage"))%>' class="img-circle" Visible='<%# Convert.ToBoolean(Eval("9Dec"))%>' />
                                    </a>
                                </div>
                                <asp:Image ID="linkScheduleCC9Dec" runat="server" ImageUrl='<%#  String.Format("~/img/schedule/{0}", Eval("9DecImage"))%>' class="img-circle" Visible='<%# Convert.ToInt32(Eval("SportID")) == -1 ? true : false%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="dgFixedGeneralSchedule" runat="server" EnableViewState="true"
                    AutoGenerateColumns="false"
                    AllowPaging="false"
                    DataKeyNames="SportID"
                    Width="100%"
                    CssClass="rWebGrid rWebFixedHeaderGrid">
                    <Columns>
                        <asp:HyperLinkField DataTextField="SportName" DataNavigateUrlFields="SportID" DataNavigateUrlFormatString="~/Schedule/Schedule.aspx?sportid={0}" HeaderStyle-Width="30%" />
                        <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-CssClass="middleAlign">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-03">
                                    <span class="bigFont">3</span><br />
                                    Dec
                                </a>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-CssClass="middleAlign">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-04">
                                    <span class="bigFont">4</span><br />
                                    Dec
                                </a>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-CssClass="middleAlign">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-05">
                                    <span class="bigFont">5</span><br />
                                    Dec
                                </a>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-CssClass="middleAlign">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-06">
                                    <span class="bigFont">6</span><br />
                                    Dec
                                </a>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-CssClass="middleAlign">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-07">
                                    <span class="bigFont">7</span><br />
                                    Dec
                                </a>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-CssClass="middleAlign">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-08">
                                    <span class="bigFont">8</span><br />
                                    Dec
                                </a>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-CssClass="middleAlign">
                            <HeaderTemplate>
                                <a class="taphover link" href="Schedule.aspx?date=2015-12-09">
                                    <span class="bigFont">9</span><br />
                                    Dec
                                </a>
                            </HeaderTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="legend-schedule">
                <div style="font-size:12px;font-size: 1.2rem;">
                    * Schedule is subjected to changes
                </div>
            </div>
            <div class="legend-schedule">
                <div class="col-md-3 col-sm-3 col-xs-3">
                    <img id="imgOpeningCeremony" runat="server" src="~/img/schedule/oc.png" /><div>Opening Ceremony</div>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-3">
                    <img id="imgClosingCeremony" runat="server" src="~/img/schedule/cc.png" /><div>Closing Ceremony</div>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-3">
                    <img id="imgCompetitionDay" runat="server" src="~/img/schedule/empty.png" /><div>Competition Day</div>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-3">
                    <img id="imgDayWithMedals" runat="server" src="~/img/schedule/champion.png" /><div>Day With Medals</div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <uc:MedalStandings ID="uscMedalStandings" runat="server" />
            <uc:LiveSchedule ID="uscLiveSchedule" runat="server" />
            <uc:LatestMedalist ID="uscLatestMedalist" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />

    <script type="text/javascript">
        var dgGeneralScheduleTableID;
        var dgFixedGeneralScheduleTableID;
        var tableOffset;
        var tableOffsetBtm;
        var $header;
        var $fixedHeader;

        <%--function pageLoad()
        {
            dgGeneralScheduleTableID = "<%=dgGeneralSchedule.ClientID%>";
            dgFixedGeneralScheduleTableID = "<%=dgFixedGeneralSchedule.ClientID%>";
            $('#' + dgFixedGeneralScheduleTableID).width($('#' + dgGeneralScheduleTableID)[0].getBoundingClientRect().width);
            tableOffset = $("#" + dgGeneralScheduleTableID).offset().top;
            tableOffsetBtm = tableOffset + $("#" + dgGeneralScheduleTableID).outerHeight();
            $fixedHeader = $("#" + dgFixedGeneralScheduleTableID);

            $(window).bind("scroll", function () {
                var offset = $(this).scrollTop();

                if (offset >= tableOffset && offset <= tableOffsetBtm && $fixedHeader.is(":hidden")) {
                    $fixedHeader.show();
                }
                else if (offset < tableOffset || offset > tableOffsetBtm) {
                    $fixedHeader.hide();
                }
            });
        }--%>

      
    </script>
</asp:Content>
