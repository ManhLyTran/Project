<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAccount.aspx.cs" Inherits="HVKTQS.Web.Account.ListAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box">
                <div class="portlet light bordered">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-pin font-red"></i>
                            <span class="caption-subject font-red sbold uppercase">Danh sách tài khoản</span>
                        </div>
                    </div>
                    <div class="portlet-title">
                        <div class="form-inline" role="form">
                            <div class="form-group">
                                <label class="control-label" for="keyword">Từ khóa</label>
                                <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn btn-default">
                            <i class="fa fa-search"></i>Tìm kiếm
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <asp:Literal runat="server" ID="litError"></asp:Literal>
                        <div class="table-scrollable">
                            <asp:Repeater runat="server" ID="rptUser" OnItemCommand="rptUser_ItemCommand" OnItemDataBound="rptUser_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th class="text-center" style="width: 40px;">STT </th>
                                                <th class="text-center">Tài khoản</th>
                                                <th class="text-center">Họ và tên</th>
                                                <th class="text-center">Vai trò</th>
                                                <th class="text-center">Đăng nhập cuối</th>
                                                <th class="text-center">Địa chỉ IP</th>
                                                <th class="text-center">Hành động</th>
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
                                            <%# DataBinder.Eval(Container.DataItem,"UserName") %>
                                        </td>
                                        <td>
                                            <%# DataBinder.Eval(Container.DataItem,"FullName") %>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblRole" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <%# String.Format("{0:dd/MM/yyyy HH:mm:sss}", DataBinder.Eval(Container.DataItem,"LoginDate"))%>
                                        </td>
                                        <td>
                                            <%# DataBinder.Eval(Container.DataItem,"LastIPAddress") %>
                                        </td>
                                        <td class="text-center">
                                            <asp:LinkButton ID="lnkResetPassword" title="Reset mật khẩu" runat="server" CommandName="ResetPassword" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserID") %>' OnClientClick="return confirm('Bạn có reset mật khẩu tài khoản này không?');">
                                                <i class="fa fa-key fa-lg" aria-hidden="true"></i>
                                            </asp:LinkButton>
                                            &nbsp;&nbsp;

                                            <asp:LinkButton ID="lnkLockUsser" title="Khóa tài khoản" runat="server" CommandName="LockUsser" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserID") %>' OnClientClick="return confirm('Bạn có muốn khóa tài khoản này không?');">
                                                     <i class="fa fa-lock fa-lg" aria-hidden="true"></i>
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="lnkUnLockUsser" title="Mở tài khoản" runat="server" CommandName="UnLockUsser" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserID") %>' OnClientClick="return confirm('Bạn có muốn mở khóa tài khoản này không?');">
                                                    <i class="fa fa-unlock-alt fa-lg" aria-hidden="true"></i>
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
    </div>
</asp:Content>