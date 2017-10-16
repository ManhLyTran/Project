<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListEmployee.aspx.cs" Inherits="HVKTQS.Web.Employee.ListEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-head">
        <div class="page-title break-head">
            <h1>Quản lý hồ sơ giảng viên</h1>
        </div>
        <div class="page-toolbar">
            <asp:LinkButton runat="server" ID="lbtAddEmployee" CssClass="btn btn-default" OnClick="lbtAddEmployee_Click">
                     <i class="fa fa-plus"></i>Thêm mới giảng viên
            </asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light portlet-fit bordered">
                <div class="portlet-title">
                    <div class="form-inline" role="form">
                        <div class="form-group">
                            <label class="control-label" for="subject">Bộ môn</label>
                            <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="Position">Chức vụ</label>
                            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label class="control-label" for="keyword">Từ khóa</label>
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn btn-default" OnClick="lnkSearch_Click">
                            <i class="fa fa-search"></i>Tìm kiếm
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-scrollable">
                        <asp:Repeater runat="server" ID="rptEmployee" OnItemCommand="rptEmployee_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th class="text-center" style="width: 40px;">STT </th>
                                            <th class="text-center">Họ và tên</th>
                                            <th class="text-center">Ngày sinh</th>
                                            <th class="text-center">Email</th>
                                            <th class="text-center">Bộ môn </th>
                                            <th class="text-center">Chức vụ</th>
                                            <th class="text-center" style="width: 40px;">Sửa </th>
                                            <th class="text-center" style="width: 40px;">Xóa</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%# Container.ItemIndex + 1%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem,"FullName") %>
                                    </td>
                                    <td>
                                        <%# String.Format("{0:dd/MM/yyyy}",DataBinder.Eval(Container.DataItem,"DateOfBirth")) %>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem,"Email") %>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem,"SubjectName") %>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem,"PositionName") %>
                                    </td>
                                    <td class="text-center">
                                        <asp:LinkButton ID="lnkEdit" title="Sửa" runat="server" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"EmployeeID") %>'>
                                           <i class="fa fa-pencil-square-o fa-lg"></i>
                                        </asp:LinkButton>
                                    </td>
                                    <td class="text-center">
                                        <asp:LinkButton ID="lnkDelete" title="Xóa" runat="server" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"EmployeeID") %>' OnClientClick="return confirm('Bạn có thực sự muốn xóa?');">
                                            <i class="fa fa-trash-o fa-lg"></i>
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                 </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>