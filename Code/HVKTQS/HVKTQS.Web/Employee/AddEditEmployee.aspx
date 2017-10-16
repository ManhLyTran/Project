<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditEmployee.aspx.cs" Inherits="HVKTQS.Web.Employee.AddEditEmployee" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-head">
        <div class="page-title">
            <h1>
                <asp:Label runat="server" ID="lblTitle"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="profile">

        <div class="tabbable-line tabbable-full-width">
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#tab_1_3" data-toggle="tab" aria-expanded="true">Hồ sơ giảng viên </a>
                </li>
                <li class="">
                    <a href="#tab_1_6" data-toggle="tab" aria-expanded="false">Tài khoản truy cập </a>
                </li>
            </ul>
            <div class="tab-content">
                <asp:Literal runat="server" ID="litError"></asp:Literal>

                <!--tab_1_2-->
                <div class="tab-pane active" id="tab_1_3">
                    <div class="row profile-account">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <div class="form-group kv-avatar center-block" style="width: 172px">
                                            <asp:FileUpload ID="fuImagePath" accept="image/*" class="file-loading" runat="server" ToolTip="Chọn tệp tin" />
                                        </div>
                                        <div id="kv-avatar-errors" class="center-block" style="width: 172px; display: none"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="tab-content">
                                <div class="tab-pane active">
                                    <div>
                                        <div class="col-md-12 form-group">
                                            <label class="control-label">
                                                Họ và tên
                                                <span class="required" aria-required="true">* </span>
                                            </label>
                                            <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Ngày sinh
                                                    <span class="required" aria-required="true">* </span>
                                                        </label>
                                                        <div class="form-inline">

                                                            <div class='input-group input-group-ct date dateOfBirth'>
                                                                <div class='input-group  date bootstrap-datetimepicker'>
                                                                    <asp:TextBox ID="txtDateOfBirth" CssClass="form-control bootstrap-dateentry" runat="server"></asp:TextBox>

                                                                    <input type="hidden" id="hddDateOfBirth" name="hddDateOfBirth" />
                                                                    <span class="input-group-addon default">
                                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label">Giới tính</label>
                                                        <div class="mt-radio-inline">
                                                            <label class="mt-radio">
                                                                <asp:RadioButton runat="server" ID="rbtMale" GroupName="gender" Checked="true" />Nam
                                                        <span></span>
                                                            </label>
                                                            <label class="mt-radio">
                                                                <asp:RadioButton runat="server" ID="rbtFeMale" GroupName="gender" />Nữ
                                                        <span></span>
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Bộ môn
                                                    <span class="required" aria-required="true">* </span>
                                                        </label>
                                                        <asp:DropDownList runat="server" ID="ddlSubject" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Chức vụ
                                                    <span class="required" aria-required="true">* </span>
                                                        </label>
                                                        <asp:DropDownList runat="server" ID="ddlPosition" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Học hàm</label>
                                                <asp:TextBox ID="txtAcademicRank" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Học vị</label>
                                                <asp:TextBox ID="txtBachelorDegree" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label">Email</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-envelope"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label">Số điện thoại liên hệ</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-phone"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label">Địa chỉ</label>
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
                    </div>
                </div>
                <!--end tab-pane-->
                <div class="tab-pane" id="tab_1_6">
                    <div class="row">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Tài khoản:
                                     <span class="required" aria-required="true">* </span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Vai trò:
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control">
                                        <asp:ListItem Text="Thành viên" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Quản trị viên" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Quản trị hệ thống" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group"></div>
                            <div class="col-md-12 padding-bottom">
                                <b>Ghi chú:</b>
                                <span>Mỗi giảng viên sẽ có một tài khoản truy cập vào hệ thống</span>
                            </div>
                            <div class=" col-md-12 padding-bottom">
                                <b>Vai trò thành viên:</b>
                                <span>là người tham gia sử dụng hệ thống với các chức năng cơ bản về quản lịch cá nhân.</span>
                            </div>
                            <div class=" col-md-12 padding-bottom">
                                <b>Vai trò quản trị viên:</b>
                                <span>là người quản lý thông tin lịch công tác của khoa, của bộ môn, cá nhân.</span>
                            </div>
                            <div class=" col-md-12 padding-bottom">
                                <b>Vai trò quản trị hệ thống:</b>
                                <span>là người quản lý các hồ sơ, thông tin đăng nhập của các cán bộ giáo viên, quản lý thông tin lịch công tác của cán bộ giáo viên khoa công nghệ thông tin – là người nắm vai trò cao nhất trong hệ thống.</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-md-offset-8 margiv-top-10 text-right">
                    <asp:Button runat="server" ID="btnCancel" CssClass="btn default" CausesValidation="true" formnovalidate Text="Hủy bỏ" OnClick="btnCancel_Click" />
                    <asp:Button runat="server" ID="btnSave" CssClass="btn green" Text="Lưu thông tin" OnClick="btnSave_Click" />
                </div>
                <!--end tab-pane-->
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hddImagePath" Value="" runat="server" />
    <asp:HiddenField ID="hddFileImage" Value="" runat="server" />
    <asp:HiddenField ID="hddRemoveImage" Value="0" runat="server" />
    <asp:HiddenField ID="hddFileLoaded" Value="" runat="server" />

    <link href="../assets/css/addEmployee.css" rel="stylesheet" />
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
            $('.dateOfBirth').datetimepicker({
                locale: 'vi',
                format: 'DD/MM/YYYY',
                ignoreReadonly: true,
                showTodayButton: true,
                showClear: true,
                useCurrent: false,
                showClose: true
            });
            $('.dateOfBirth').on('dp.change', function(e){
                $('#MainForm').formValidation('revalidateField', '<%=txtDateOfBirth.UniqueID%>');
            })
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
                    defaultPreviewContent: '<img src="/assets/img/avatar.jpg" alt="Ảnh đại diện" class="" style="width: 160px; height: 160px;" />',
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
                    defaultPreviewContent: '<img src="/assets/img/avatar.jpg" alt="Ảnh đại diện" class="" style="width: 160px; height: 160px;" />',
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
                    <%= txtFullName.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Họ và tên bắt buộc phải nhập liệu!'
                            }
                        }
                    },
                    <%=txtDateOfBirth.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Ngày sinh bắt buộc phải nhập liệu!'
                            },
                            date: {
                                format: 'DD/MM/YYYY',
                                message: 'Ngày sinh không hợp lệ!'
                            }
                        }
                    },
                    <%=ddlSubject.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Bộ môn bắt buộc phải nhập liệu!'
                            },
                            callback: {
                                message: 'Bộ môn bắt buộc phải nhập liệu!',
                                callback: function(value, validator, $field) {
                                    if (value !== '-1') {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                        }
                    },
                    <%=ddlPosition.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Chức vụ bắt buộc phải nhập liệu!'
                            },
                            callback: {
                                message: 'Chức vụ bắt buộc phải nhập liệu!',
                                callback: function(value, validator, $field) {
                                    if (value !== '-1') {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                        }
                    },
                    <%= txtEmail.UniqueID%>: {
                        validators: {
                            emailAddress: {
                                message: 'Email không hợp lệ!'
                            }
                        }
                    },
                    <%= txtUsername.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Tài khoản bắt buộc phải nhập liệu!'
                            }
                        }
                    }
                }
            })
                .on('err.field.fv', function(e, data) {
                    var $invalidFields = data.fv.getInvalidFields().eq(0);
                    var $tabPane     = $invalidFields.parents('.tab-pane'),
                        invalidTabId = $tabPane.attr('id');
                    if (!$tabPane.hasClass('active')) {
                        // Then activate it
                        $tabPane.parents('.tab-content')
                                .find('.tab-pane')
                                .each(function(index, tab) {
                                    var tabId = $(tab).attr('id'),
                                        $li   = $('a[href="#' + tabId + '"][data-toggle="tab"]').parent();
                                    if (tabId === invalidTabId) {
                                        // activate the tab pane
                                        $(tab).addClass('active');
                                        // and the associated <li> element
                                        $li.addClass('active');
                                    } else {
                                        $(tab).removeClass('active');
                                        $li.removeClass('active');
                                    }
                                });

                        // Focus on the field
                        $invalidFields.focus();
                    }
                })
                    // Called when a field is valid
                    .on('success.field.fv', function(e, data) {
                        var $parent = data.element.parents('.form-group');
                        // Remove the has-success class
                        $parent.removeClass('has-success');
                    });

        })
    </script>
</asp:Content>