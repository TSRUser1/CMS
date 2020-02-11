<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateTable.aspx.cs" Inherits="SEM.CMS.Web.TemplateTable" MasterPageFile="~/CMS.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_CMS" runat="server">
    <div id="page" class="dashboard">
        <div class="row-fluid">
						<div class="span12">
							<!-- BEGIN EXAMPLE TABLE PORTLET-->
							<div class="widget">
								<div class="widget-title">
									<h4><i class="icon-reorder"></i>Example Table</h4>
									<span class="tools">
									<a href="javascript:;" class="icon-chevron-down"></a>
									<a href="#widget-config" data-toggle="modal" class="icon-wrench"></a>
									<a href="javascript:;" class="icon-refresh"></a>		
									<a href="javascript:;" class="icon-remove"></a>
									</span>							
								</div>
								<div class="widget-body">
									<table class="table table-striped table-bordered" id="sample_1">
										<thead>
											<tr>
												<th style="width:8px"><input type="checkbox" class="group-checkable" data-set=".checkboxes" /></th>
												<th>Username</th>
												<th class="hidden-phone">Email</th>
												<th class="hidden-phone">Points</th>
												<th class="hidden-phone">Joined</th>
												<th class="hidden-phone">Status</th>
												<th>Actions</th>
											</tr>
										</thead>
										<tbody>
											<tr class="odd gradeX">
												<td><input type="checkbox" class="checkboxes" value="1" /></td>
												<td>shuxer</td>
												<td class="hidden-phone"><a href="mailto:shuxer@gmail.com">shuxer@gmail.com</a></td>
												<td class="hidden-phone">120</td>
												<td class="hidden-phone center">12.02.2011</td>
												<td class="hidden-phone"><span class="label label-success">Approved</span></td>
												<td class="center">
													<a href="#" class="icon huge"><i class="icon-zoom-in"></i></a>&nbsp;	
													<a href="#" class="icon huge"><i class="icon-pencil"></i></a>&nbsp;
													<a href="#" class="icon huge"><i class="icon-remove"></i></a>&nbsp;		
												</td>
											</tr>
											<tr class="odd gradeX">
												<td><input type="checkbox" class="checkboxes" value="1" /></td>
												<td>looper</td>
												<td class="hidden-phone"><a href="mailto:looper90@gmail.com">looper90@gmail.com</a></td>
												<td class="hidden-phone">120</td>
												<td class="hidden-phone center">12.12.2011</td>
												<td class="hidden-phone"><span class="label label-warning">Suspended</span></td>
												<td class="center">
													<a href="#" class="icon huge"><i class="icon-zoom-in"></i></a>&nbsp;	
													<a href="#" class="icon huge"><i class="icon-pencil"></i></a>&nbsp;
													<a href="#" class="icon huge"><i class="icon-remove"></i></a>&nbsp;	
												</td>
											</tr>
											<tr class="odd gradeX">
												<td><input type="checkbox" class="checkboxes" value="1" /></td>
												<td>userwow</td>
												<td class="hidden-phone"><a href="mailto:userwow@yahoo.com">userwow@yahoo.com</a></td>
												<td class="hidden-phone">20</td>
												<td class="hidden-phone center">12.12.2012</td>
												<td class="hidden-phone"><span class="label label-success">Approved</span></td>
												<td class="center">
													<a href="#" class="icon huge"><i class="icon-zoom-in"></i></a>&nbsp;	
													<a href="#" class="icon huge"><i class="icon-pencil"></i></a>&nbsp;
													<a href="#" class="icon huge"><i class="icon-remove"></i></a>&nbsp;	
												</td>
											</tr>
											<tr class="odd gradeX">
												<td><input type="checkbox" class="checkboxes" value="1" /></td>
												<td>user1wow</td>
												<td class="hidden-phone"><a href="mailto:userwow@gmail.com">userwow@gmail.com</a></td>
												<td class="hidden-phone">20</td>
												<td class="hidden-phone center">12.12.2012</td>
												<td class="hidden-phone"><span class="label label-inverse">Blocked</span></td>
												<td class="center">
													<a href="#" class="icon huge"><i class="icon-zoom-in"></i></a>&nbsp;	
													<a href="#" class="icon huge"><i class="icon-pencil"></i></a>&nbsp;
													<a href="#" class="icon huge"><i class="icon-remove"></i></a>&nbsp;	
												</td>
											</tr>
										</tbody>
									</table>
								</div>
							</div>
							<!-- END EXAMPLE TABLE PORTLET-->
						</div>
					</div>



    </div>
</asp:Content>
