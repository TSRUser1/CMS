<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="ResultMaintenance.aspx.cs" Inherits="SEM.CMS.Web.ResultMaintenance" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_CMS" runat="server">
    <asp:Image ID="imgSportImage" runat="server" Height="60px" Width="60px" />
    <asp:Label ID="lblEventDetails" runat="server"></asp:Label><br />
    <asp:Label runat="server" ID="lblScheduleDetails"></asp:Label><br />
    <asp:Label runat="server" ID="lblScheduleVenueTime"></asp:Label><br />
    <br />
    <br />
    <asp:HiddenField ID="hidScoreNameID" runat="server" />
    <table border="1" style="border-collapse: collapse;">
        <tbody>
            <tr style="font-size: 11px;">
                <th scope="col"></th>
                <th scope="col">Sc. 1</th>
                <th scope="col">Sc. 2</th>
                <th scope="col">Sc. 3</th>
                <th scope="col">Sc. 4</th>
                <th scope="col">Sc. 5</th>
                <th scope="col">Sc. 6</th>
                <th scope="col">Sc. 7</th>
                <th scope="col">Sc. 8</th>
                <th scope="col">Sc. 9</th>
                <th scope="col">Sc. 10</th>
                <th scope="col">Sc. 11</th>
                <th scope="col">Sc. 12</th>
                <th scope="col">Sc. 13</th>
                <th scope="col">Sc. 14</th>
                <th scope="col">Sc. 15</th>
                <th scope="col">Sc. 16</th>
                <th scope="col">Sc. 17</th>
                <th scope="col">Sc. 18</th>
                <th scope="col">Sc. 19</th>
                <th scope="col">Sc. 20</th>
                <th scope="col" class="result-maintenance-highlight">Final</th>
            </tr>
            <tr>
                <td class="result-maintenance" style="height: 30px; text-align: center; font-weight: bold; font-size: 11px;">
                    <div style="width: 95px;">Score Name</div>
                </td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName1" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName2" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName3" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName4" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName5" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName6" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName7" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName8" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName9" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName10" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName11" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName12" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName13" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName14" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName15" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName16" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName17" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName18" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName19" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreName20" runat="server"></asp:TextBox></td>
                <td class="result-maintenance">
                    <asp:TextBox ID="txtScoreNameFinal" runat="server"></asp:TextBox></td>
            </tr>
            <%--<tr>
                <td class="result-maintenance" style="height: 30px; text-align: center; font-weight: bold; font-size: 11px;">
                    <div style="width: 95px;">Show Startlist</div>
                </td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName1" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName2" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName3" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName4" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName5" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName6" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName7" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName8" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName9" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName10" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName11" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName12" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName13" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName14" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName15" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName16" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName17" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName18" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName19" runat="server" /></td>
                <td class="result-maintenance">
                    <asp:CheckBox ID="chkScoreName20" runat="server" /></td>
            </tr>--%>
        </tbody>
    </table>
    <br />
    <div style="overflow-x: scroll; margin-right: 50px;">
        <asp:GridView ID="dgScoreDetail" runat="server" EnableViewState="true"
            AutoGenerateColumns="false"
            AutoGenerateDeleteButton="false"
            AllowPaging="false"
            OnRowDataBound="dgScoreDetail_RowDataBound"
            DataKeyNames="ScoreID,ParticipantInScheduleID,AccreditationNumber,TeamID" ShowHeader="true" HeaderStyle-Font-Size="11px" EmptyDataText="No Participant added to Start List.">
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <div style="width: 15px;"><%# Container.DataItemIndex + 1 %></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <div class="result-maintenance" style="width: 80px;"><%# DataBinder.Eval(Container.DataItem,"FullName") %></div>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"CountryImage") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <asp:FileUpload ID="btnFileUpload" runat="server" />
    <asp:Button ID="btnLoadFromCsv" runat="server" OnClick="btnLoadFromCsv_Click" Text="Load From CSV" />
    <br />
    <br />
    <asp:Panel runat="server" ID="pnlStatistic" Visible="false">
        <asp:HiddenField ID="hidStatNameID" runat="server" />
        <table border="1" style="border-collapse: collapse;">
            <tbody>
                <tr style="font-size: 11px;">
                    <th scope="col"></th>
                    <th scope="col">St. 1</th>
                    <th scope="col">St. 2</th>
                    <th scope="col">St. 3</th>
                    <th scope="col">St. 4</th>
                    <th scope="col">St. 5</th>
                    <th scope="col">St. 6</th>
                    <th scope="col">St. 7</th>
                    <th scope="col">St. 8</th>
                    <th scope="col">St. 9</th>
                    <th scope="col">St. 10</th>
                </tr>
                <tr>
                    <td class="result-maintenance" style="height: 30px; text-align: center; font-weight: bold; font-size: 11px;">
                        <div style="width: 95px;">Stat Name</div>
                    </td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat1" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat2" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat3" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat4" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat5" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat6" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat7" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat8" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat9" runat="server"></asp:TextBox></td>
                    <td class="result-maintenance">
                        <asp:TextBox ID="txtStat10" runat="server"></asp:TextBox></td>
                </tr>
            </tbody>
        </table>
        <br />

        <asp:GridView ID="dgParticipantStatistic" runat="server" EnableViewState="true"
            AutoGenerateColumns="false"
            AutoGenerateDeleteButton="false"
            AllowPaging="false"
            OnRowDataBound="dgParticipantStatistic_RowDataBound"
            DataKeyNames="StatisticID,ParticipantInScheduleID,AccreditationNumber,TeamID" ShowHeader="true" HeaderStyle-Font-Size="11px" EmptyDataText="No Participant added.">
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <div style="width: 15px;"><%# Container.DataItemIndex + 1 %></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <div class="result-maintenance" style="width: 80px;"><%# DataBinder.Eval(Container.DataItem,"FullName") %></div>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"CountryImage") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Schedule Footer Note :"></asp:Label>
    <%--Source|-|Save|NewPage|Preview|-|Templates Cut|Copy|Paste|PasteText|PasteFromWord|-|Print|SpellChecker|Scayt Undo|Redo|-|Find|Replace|-|SelectAll|RemoveFormat Form|Checkbox|Radio|TextField|Textarea|Select|Button|ImageButton|HiddenField / Bold|Italic|Underline|Strike|-|Subscript|Superscript NumberedList|BulletedList|-|Outdent|Indent|Blockquote|CreateDiv JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock BidiLtr|BidiRtl Link|Unlink|Anchor Image|Flash|Table|HorizontalRule|Smiley|SpecialChar|PageBreak|Iframe / Styles|Format|Font|FontSize TextColor|BGColor Maximize|ShowBlocks|-|About--%>
    <CKEditor:CKEditorControl ID="ckeScheduleFooter" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Event Footer Note :"></asp:Label>
    <br />
    <CKEditor:CKEditorControl ID="ckeEventFooter" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
    <div class="form-actions">
        Toggle Summary HTML Mode&nbsp;:&nbsp;<asp:CheckBox ID="chkTogleHtmlMode" runat="server" />
    </div>
    <asp:Panel ID="Panel3" runat="server" Height="466px">
        <asp:HiddenField ID="hidRefereeID" runat="server" />
        Referees &amp; Officials :
        <table border="0" style="border-collapse: collapse; padding: 5px;">
            <tbody>
                <tr style="font-size: 11px;">
                    <th scope="col">No</th>
                    <th scope="col">Referee Title</th>
                    <th scope="col">Referee Name</th>
                </tr>
                <tr>
                    <td>1</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle1" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle2" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle3" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName3" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle4" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName4" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle5" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName5" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>6</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle6" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName6" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>7</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle7" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName7" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>8</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle8" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName8" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>9</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle9" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName9" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>10</td>
                    <td>
                        <asp:TextBox ID="txtRefTitle10" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtRefName10" runat="server"></asp:TextBox></td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlLeagueTable" runat="server">
        <asp:GridView ID="dgLeague" runat="server"
            AutoGenerateColumns="false"
            AutoGenerateDeleteButton="false"
            AllowPaging="false"
            OnRowDataBound="dgLeague_RowDataBound"
            DataKeyNames="LeagueID,TeamID,ParticipantInEventID">
            <Columns>
                <asp:TemplateField HeaderText="Rank" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRank" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Rank") %>' CssClass="result-maintenance"></asp:TextBox>
                        <asp:RangeValidator ID="validRank" runat="server" Type="Integer"
                            MinimumValue="1" MaximumValue="400" ControlToValidate="txtRank"
                            ErrorMessage=" > 1" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:Image ID="imgCountryImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"IconFilePath") %>' />
                        <asp:Label ID="lblName" CssClass="result-maintenance" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FullName") %>'></asp:Label>
                        <asp:Label ID="lblTeamName" CssClass="result-maintenance" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TeamName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 1" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League1") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 2" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League2") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 3" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League3") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 4" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League4") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 5" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League5") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 6" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League6") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 7" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League7") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 8" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League8") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 9" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League9") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 10" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League10") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 11" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League11") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 12" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League12") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 13" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague13" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League13") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 14" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague14" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League14") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 15" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague15" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League15") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 16" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague16" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League16") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 17" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague17" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League17") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 18" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague18" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League18") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 19" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague19" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League19") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lg. 20" ItemStyle-CssClass="result-maintenance">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLeague20" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"League20") %>' CssClass="result-maintenance"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <div class="form-actions">
        <asp:Button ID="btnBack" Text="Back" class="btn btn-success" runat="server" OnClick="btnBack_Click" />
        <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" Text="Update Score" />
    </div>
</asp:Content>
