<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="HVKTQS.Web.Account.MyProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light form-fit bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-pin font-red"></i>
                        <span class="caption-subject font-red sbold uppercase">Thay đổi thông tin cá nhân</span>
                    </div>
                </div>
                <div class="portlet-body form ">
                    <div class="form-horizontal">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Literal runat="server" ID="litError"></asp:Literal>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <div class="col-md-12">
                                            <div class="kv-avatar center-block" style="width: 200px">
                                                <asp:FileUpload ID="fuImagePath" accept="image/*" class="file-loading" runat="server" ToolTip="Chọn tệp tin" />
                                            </div>
                                            <div id="kv-avatar-errors" class="center-block" style="width: 200px; display: none"></div>
                                        </div>
                                    </div>
                                    <div class="col-md-9">
                                        <div class="form-group">
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Họ và tên:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <asp:Label runat="server" ID="lblFullName" CssClass="form-control-static" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Ngày sinh:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <asp:Label runat="server" ID="lblDateOfBirth" CssClass="form-control-static" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Giới tính:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <asp:Label runat="server" ID="lblGender" CssClass="form-control-static" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Bộ môn:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <asp:Label runat="server" ID="lblSubject" CssClass="form-control-static" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Chức vụ:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <asp:Label runat="server" ID="lblPosition" CssClass="form-control-static" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Học hàm:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtAcademicRank" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Học vị:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtBachelorDegree" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Email:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-envelope"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Số điện thoại:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-phone"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                <b>Địa chỉ:</b>
                                            </label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-bank"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-4 col-md-8">
                                    <asp:Button runat="server" ID="btnCancel" CssClass="btn default" CausesValidation="true" formnovalidate Text="Hủy bỏ" OnClick="btnCancel_Click" />
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn green" Text="Lưu thông tin" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hddImagePath" Value="" runat="server" />
    <asp:HiddenField ID="hddFileImage" Value="" runat="server" />
    <asp:HiddenField ID="hddRemoveImage" Value="0" runat="server" />
    <asp:HiddenField ID="hddFileLoaded" Value="" runat="server" />
    <%--Upload file--%>
    <link href="../assets/plugins/fileinput/fileinput.min.css" rel="stylesheet" />
    <script src="../assets/plugins/fileinput/fileinput.min.js"></script>
    <script src="../assets/plugins/fileinput/fileinput_locale_vi.js"></script>
    <%--formValidation: Kiểm tra nhập liệu--%>
    <link href="../assets/plugins/formvalidation/formValidation.min.css" rel="stylesheet" />
    <script src="../assets/plugins/formvalidation/formValidation.min.js"></script>
    <script src="../assets/plugins/formvalidation/formvalidation.bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= fuImagePath.ClientID %>').on('fileclear', function (event) {
                $('#<%= btnSave.ClientID%>').prop('disabled', false);
                if ($('#<%= hddFileImage.ClientID%>').val() != '' || $('#<%= hddFileLoaded.ClientID%>').val() != '') {
                    $('#<%= hddRemoveImage.ClientID%>').val('1');
                    $('#<%= hddFileLoaded.ClientID%>').val('');
                }
            });

            $('#<%= fuImagePath.ClientID %>').on('fileimagesloaded', function (event, data, previewId, index) {
                console.log("fileimagesloaded");
                $('#<%= hddFileLoaded.ClientID%>').val($('#<%= fuImagePath.ClientID %>').val());
            });

            $('#<%= fuImagePath.ClientID %>').on('fileerror', function (event, data) {
                console.log("fileerror");
                $('#<%= btnSave.ClientID%>').prop('disabled', true);
            });

            if ($('#<%= hddFileImage.ClientID%>').val() != '') {
                var imagePath =  $('#<%= hddImagePath.ClientID%>').val();
                $("#<%= fuImagePath.ClientID %>").fileinput({
                    initialPreview: [
                        '<img src="' + imagePath + '" alt="Ảnh đại diện" class="" style="width: 160px; height: 160px;">'
                    ],
                    language: 'vi',
                    overwriteInitial: true,
                    maxFileSize: 5000,
                    showClose: false,
                    showCaption: false,
                    previewFileType: "image",
                    browseClass: "btn btn-success btn-sm",
                    browseLabel: "Chọn",
                    browseIcon: "<i class=\"glyphicon glyphicon-picture\"></i> ",
                    removeClass: "btn btn-danger btn-sm",
                    removeLabel: "Xóa",
                    removeIcon: "<i class=\"glyphicon glyphicon-trash\"></i> ",
                    elErrorContainer: '#kv-avatar-errors',
                    msgErrorClass: 'alert alert-block alert-danger',
                    defaultPreviewContent: '<img src="/assets/img/avatar.jpg" alt="Ảnh đại diện" class="" style="width: 188px; height: 160px;" />',
                    layoutTemplates: { main2: '{preview} {browse} {remove}' },
                    allowedFileExtensions: ["jpg", "png", "gif"],
                    msgInvalidFileExtension: "File không hợp lệ!"
                });
            } else {
                $("#<%= fuImagePath.ClientID %>").fileinput({
                    language: 'vi',
                    overwriteInitial: true,
                    maxFileSize: 5000,
                    showClose: false,
                    showCaption: false,
                    previewFileType: "image",
                    browseClass: "btn btn-success btn-sm",
                    browseLabel: "Chọn",
                    browseIcon: "<i class=\"glyphicon glyphicon-picture\"></i> ",
                    removeClass: "btn btn-danger btn-sm",
                    removeLabel: "Xóa",
                    removeIcon: "<i class=\"glyphicon glyphicon-trash\"></i> ",
                    elErrorContainer: '#kv-avatar-errors',
                    msgErrorClass: 'alert alert-block alert-danger',
                    defaultPreviewContent: '<img src="/assets/img/avatar.jpg" alt="Ảnh đại diện" class="" style="width: 188px; height: 160px;" />',
                    layoutTemplates: { main2: '{preview} {browse} {remove}' },
                    allowedFileExtensions: ["jpg", "png", "gif"],
                    msgInvalidFileExtension: "File không hợp lệ!"
                });
            }
            //validate form
            $('#MainForm').formValidation({
                excluded: [':disabled'],
                framework: 'bootstrap',
                fields: {
                    <%= txtEmail.UniqueID%>: {
                        validators: {
                            emailAddress: {
                                message: 'Email không hợp lệ!'
                            }
                        }
                    }
                }
            });

        })
    </script>
</asp:Content>