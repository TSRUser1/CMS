<%@ Page Title="" Language="C#" MasterPageFile="~/RWeb.Master" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="SEM.CMS.Result.Web.Event.Record" %>
<%@ Register TagPrefix="uc" TagName="SubMenu" Src="~/UserControls/ucSubMenu.ascx" %>
<%@ Register TagPrefix="uc" TagName="SelectedGame" Src="~/UserControls/ucSelectedGame.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderEventMenu" runat="server">
    <uc:SubMenu ID="SubMenu" runat="server" />
    <uc:SelectedGame ID="SelectedGame" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRWeb" runat="server">
    <section class="result">
        <div>
            <ul class="nav nav-tabs" role="tablist">
                <li runat="server" id="liBroken" role="presentation"><a style="font-size:15px;font-weight:bold;" href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab">Broken Records</a></li>
                <li runat="server" id="liInitial" role="presentation"><a style="font-size:15px;font-weight:bold;" href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab">Initial Records</a></li>
            </ul>
            <div class="tab-content">
                <asp:Panel runat="server" ID="tab1" ClientIDMode="Static">
                    <div class="table-responsive">
                        <div class="table-responsive results">
                            <table class="table table-striped" style="background-color: #E00747; margin-bottom: 0px;">
                                <thead>
                                    <tr>
                                        <th style="color: white;">
                                            <b>Record</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Mark</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Player</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Location</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Date</b>
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                            <asp:GridView ID="dgBrokenRecord" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeader="false" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                AutoGenerateColumns="false" DataKeyNames="EventID" OnRowDataBound="dgBrokenRecord_RowDataBound" AllowPaging="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# Eval("EventName") %>
                                            <br />
                                            <asp:GridView ID="dgParticipantBrokenRecord" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeader="false"
                                                ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                                AutoGenerateColumns="false"
                                                AllowPaging="false">
                                                <Columns>
                                                    <asp:BoundField DataField="BreakRecord" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" />
                                                    <asp:BoundField DataField="ScoreFinal" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="6%"/>
                                                    <asp:BoundField DataField="FullName"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                    <asp:TemplateField HeaderText="Location" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLocation" runat="server" Text="Singapore"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Date" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="5%" DataFormatString="{0:d MMM yyyy}" />
                                                </Columns>
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="tab2" ClientIDMode="Static">
                    <div class="table-responsive">
                        <div class="table-responsive results">
                            <table class="table table-striped" style="background-color: #E00747; margin-bottom: 0px;">
                                <thead>
                                    <tr>
                                        <th style="color: white;">
                                            <b>Record</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Mark</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Player</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Location</b>
                                        </th>
                                        <th style="color: white;">
                                            <b>Date</b>
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                            <asp:GridView ID="dgInitialRecord" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeader="false" ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                AutoGenerateColumns="false" DataKeyNames="EventID" OnRowDataBound="dgInitialRecord_RowDataBound" AllowPaging="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# Eval("EventName") %>
                                            <br />
                                            <asp:GridView ID="dgParticipantInitialRecord" runat="server" EnableViewState="true" CssClass="table table-striped" ShowHeader="false"
                                                ShowHeaderWhenEmpty="true" EmptyDataText="No records found." EmptyDataRowStyle-HorizontalAlign="Center"
                                                AutoGenerateColumns="false"
                                                AllowPaging="false">
                                                <Columns>
                                                    <asp:BoundField DataField="Record" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" />
                                                    <asp:BoundField DataField="Result" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="6%"/>
                                                    <asp:BoundField DataField="FullName"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                    <asp:BoundField DataField="location" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" />
                                                    <asp:BoundField DataField="Date" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="5%" DataFormatString="{0:d MMM yyyy}" />
                                                </Columns>
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </section>
</asp:Content>
