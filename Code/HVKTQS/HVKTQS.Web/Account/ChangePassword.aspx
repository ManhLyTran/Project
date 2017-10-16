<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HVKTQS.Web.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light form-fit bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-pin font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Thay đổi mật khẩu</span>
                    </div>
                </div>
                <div class="portlet-body ">
                    <div class="form-horizontal">
                        <div class="form-body">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Literal runat="server" ID="litError"></asp:Literal>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Mật khẩu hiện tại
                                     <span class="required" aria-required="true">* </span>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtCurrentPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Mật khẩu mới
                                     <span class="required" aria-required="true">* </span>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                    Nhập lại khẩu mới
                                     <span class="required" aria-required="true">* </span>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtReNewPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">
                                </label>
                                <div class="col-md-6">
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn green" Text="Lưu mật khẩu" OnClick="btnSave_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <link href="../assets/plugins/formvalidation/formValidation.min.css" rel="stylesheet" />
    <script src="../assets/plugins/formvalidation/formValidation.min.js"></script>
    <script src="../assets/plugins/formvalidation/formvalidation.bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MainForm').formValidation({
                excluded: [':disabled'],
                framework: 'bootstrap',
                fields: {
                    <%= txtCurrentPassword.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Nhập mật khẩu hiện tại!'
                            }
                        }
                    },
                    <%= txtNewPassword.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Mật khẩu mới không được trống!'
                            },
                            stringLength: {
                                min: 6,
                                message: 'Mật khẩu quá ngắn!'
                            }
                        }
                    },
                    <%= txtReNewPassword.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Nhập lại mật khẩu mới không được trống!'
                            },
                            identical: {
                                field: '<%= txtNewPassword.UniqueID%>',
                                message: 'Nhập lại mật khẩu không khớp!'
                            }
                        }
                    }
                }
            })
        })
    </script>
</asp:Content>