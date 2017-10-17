<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditCalendar.aspx.cs" Inherits="HVKTQS.Web.Calendar.AddEditCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-pin font-red"></i>
                        <asp:Label runat="server" ID="lblTitle" CssClass="caption-subject font-red sbold uppercase"></asp:Label>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-body">
                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblSubject" CssClass="control-label col-md-3 npr" Text="">
                                </asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlDepartment_G" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:DropDownList ID="ddlSubject_G" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <div class="mt-checkbox-inline">
                                        <label class="mt-checkbox mt-checkbox-outline">
                                            <asp:CheckBox runat="server" ID="chkIsImportant_G" />
                                            Sự kiện quan trọng
                                            <span></span>
                                        </label>
                                        <label class="mt-checkbox mt-checkbox-outline">
                                            <asp:CheckBox runat="server" ID="chkIsDone_G" />
                                            Hủy bỏ
                                            <span></span>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <b>Tiều đề</b><span class="required" aria-required="true">* </span>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtTitle_G" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    Ngày thực hiện<span class="required" aria-required="true">* </span>
                                </label>
                                <div class="col-md-9">
                                    <div class='input-group input-group-ct date date-picker startDate_G'>
                                        <div class='input-group  date bootstrap-datetimepicker'>
                                            <asp:TextBox ID="txtStartDate_G" CssClass="form-control bootstrap-dateentry" spellcheck="false" autocomplete="off" runat="server"></asp:TextBox>
                                            <span class="input-group-addon default">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Thời gian</label>
                                <div class="col-md-9">
                                    <div class="mt-checkbox-inline">
                                        <label class="mt-checkbox mt-checkbox-outline">
                                            <asp:CheckBox runat="server" ID="chkAllDay_G" Checked="true" />
                                            Chưa xác định
                                            <span></span>
                                        </label>
                                        <label class="mt-checkbox mt-checkbox-outline">
                                            <asp:CheckBox runat="server" ID="chkNotEndDate_G" />
                                            Chưa biết thời điểm kết thúc
                                            <span></span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label"></label>
                                <div class="col-md-9">
                                    <div class="input-inline input-medium">
                                        <div class="input-group">
                                            <span class="input-group-addon">Bắt đầu
                                            </span>
                                            <asp:TextBox runat="server" ID="txtTimeStart_G" CssClass="form-control clock-picker"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="input-inline input-medium">
                                        <div class="input-group">
                                            <span class="input-group-addon">Kết thúc
                                            </span>
                                            <div class="input-group clockpicker" data-placement="left" data-align="top" data-autoclose="true">
                                                <asp:TextBox runat="server" ID="txtTimeEnd_G" CssClass="form-control clock-picker"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Nội dung</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtDescription_G" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Địa điểm</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtLocation_G" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Chủ trì</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtOrganizer_G" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Thành phần tham gia</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtParticipant_G" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Chuẩn bị</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtPreparation_G" CssClass="form-control "></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">File đính kèm</label>
                                <div class="col-md-9">
                                    <asp:FileUpload ID="fileAttachments" class="file-loading" runat="server" ToolTip="Chọn tệp tin" AllowMultiple="true" />
                                </div>
                            </div>
                            <div id="divRecurrence" runat="server">
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        <b>Sự kiện lặp</b>
                                    </label>
                                    <div class="col-md-9">
                                        <a id="toggleRecurrence_G" href=".collapseRecurrence_G" data-toggle="collapse" class="form-control-static">[Hiển thị chi tiết sự kiện lặp]
                                        </a>
                                    </div>
                                </div>
                                <div class="form-group collapse collapseRecurrence_G">
                                    <label class="col-md-3 control-label">Sự kiện không lặp</label>
                                    <div class="col-md-9">
                                        <div class="mt-radio-inline">
                                            <label class="mt-radio mt-radio-outline">
                                                <asp:RadioButton runat="server" ID="rdoRecurrenceNone_G" Checked="true" GroupName="Recurrence_G" />
                                                Xảy ra vào thời điểm được chỉ ra ở trên
                                                        <span></span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group collapse collapseRecurrence_G">
                                    <label class="col-md-3 control-label">Xảy ra thường kỳ</label>
                                    <div class="col-md-9 ">
                                        <label class="mt-radio mt-radio-outline">
                                            <asp:RadioButton runat="server" ID="rdoRecurrencePeriodic_G" GroupName="Recurrence_G" />
                                            Sự kiện này diễn ra (lặp)
                                                            <span></span>
                                        </label>
                                        <asp:TextBox runat="server" ID="txtPeriodicAmount_G" Width="30"></asp:TextBox>
                                        <asp:DropDownList runat="server" ID="ddlPeriodicCode_G" CssClass="input-small">
                                            <asp:ListItem Value="d">ngày 1 lần</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="w">tuần 1 lần</asp:ListItem>
                                            <asp:ListItem Value="m">tháng 1 lần</asp:ListItem>
                                            <asp:ListItem Value="y">năm 1 lần</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group collapse collapseRecurrence_G">
                                    <label class="col-md-3 control-label">Sự kiện hàng tháng</label>
                                    <div class="col-md-9">
                                        <label class="mt-radio mt-radio-outline">
                                            <asp:RadioButton runat="server" ID="rdoRecurrenceMonthlyActual_G" GroupName="Recurrence_G" />
                                            Sự kiện này diễn ra vào ngày
                                                            <span></span>
                                        </label>
                                        <asp:DropDownList runat="server" ID="ddlActualMonthlyDay_G">
                                        </asp:DropDownList>
                                        <label>hàng tháng</label>
                                    </div>
                                </div>
                                <div class="form-group collapse collapseRecurrence_G">
                                    <label class="col-md-3 control-label">Ngày bắt đầu lặp</label>
                                    <div class="col-md-3">
                                        <div class='input-group input-group-ct date date-picker RecurrenceStartDate_G'>
                                            <div class='input-group  date bootstrap-datetimepicker'>
                                                <asp:TextBox ID="txtRecurrenceStartDate_G" CssClass="form-control bootstrap-dateentry" spellcheck="false" autocomplete="off" runat="server"></asp:TextBox>
                                                <span class="input-group-addon default">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <label class="col-md-3 control-label">Ngày kết thúc lặp lặp</label>
                                    <div class="col-md-3">
                                        <div class='input-group input-group-ct date date-picker RecurrenceEndDate_G'>
                                            <div class='input-group  date bootstrap-datetimepicker'>
                                                <asp:TextBox ID="txtRecurrenceEndDate_G" CssClass="form-control bootstrap-dateentry" spellcheck="false" autocomplete="off" runat="server"></asp:TextBox>
                                                <span class="input-group-addon default">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-1 ">
                                    <asp:Literal runat="server" ID="litModify">
                                    </asp:Literal>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions right">
                            <asp:Button runat="server" ID="btnCancel_G" Text="Hủy bỏ" CausesValidation="true" formnovalidate CssClass="btn default" OnClick="btnCancel_G_Click" />
                            <asp:Button runat="server" ID="btnSave_G" Text="Lưu thông tin" CssClass="btn green" OnClick="btnSave_G_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <link href="../assets/plugins/fileinput/fileinput.min.css" rel="stylesheet" />
    <script src="../assets/plugins/fileinput/fileinput.min.js"></script>
    <script src="../assets/plugins/fileinput/fileinput_locale_vi.js"></script>
    <script type="text/javascript">

        function checkAllDay_G() {
            if ($("#<%=chkAllDay_G.ClientID%>").is(':checked') == false) {
                jQuery('#<%=txtTimeStart_G.ClientID%>').removeAttr("readonly");
                $('#<%=txtTimeStart_G.ClientID%>').clockpicker({
                    placement: 'bottom',
                    align: 'left',
                    autoclose: true,
                    'default': 'now'
                });
                checkNotEndDate_G();
            }
            else {
                $('#<%=txtTimeStart_G.ClientID%>').clockpicker('remove');
                jQuery('#<%=txtTimeStart_G.ClientID%>').attr("readonly", "readonly");
                jQuery('#<%=txtTimeStart_G.ClientID%>').val("");
                jQuery('#<%=txtTimeEnd_G.ClientID%>').clockpicker('remove');
                jQuery('#<%=txtTimeEnd_G.ClientID%>').attr("readonly", "readonly");
                jQuery('#<%=txtTimeEnd_G.ClientID%>').val("");

            }
        }
        function checkNotEndDate_G() {
            if ($("#<%=chkNotEndDate_G.ClientID%>").is(':checked') == false
                && $("#<%=chkAllDay_G.ClientID%>").is(':checked') == false) {
                jQuery('#<%=txtTimeEnd_G.ClientID%>').removeAttr("readonly");
                $('#<%=txtTimeEnd_G.ClientID%>').clockpicker({
                    placement: 'bottom',
                    align: 'left',
                    autoclose: true,
                    'default': 'now'
                });
            }
            else {
                jQuery('#<%=txtTimeEnd_G.ClientID%>').clockpicker('remove');
                jQuery('#<%=txtTimeEnd_G.ClientID%>').attr("readonly", "readonly");
                jQuery('#<%=txtTimeEnd_G.ClientID%>').val("");
            }
        }
        jQuery(document).ready(function () {
            $('#<%=txtTimeStart_G.ClientID%>,#<%=txtTimeEnd_G.ClientID%>').clockpicker({
                placement: 'bottom',
                align: 'left',
                autoclose: true,
                'default': 'now'
            });
            checkAllDay_G();
            $("body").on("click", "#<%=chkAllDay_G.ClientID%>", function (evt) {
                checkAllDay_G();
            });

            $("body").on("click", "#<%=chkNotEndDate_G.ClientID%>", function (evt) {
                checkNotEndDate_G();
            });

            $('a#toggleRecurrence_G').click(function () {
                if ($('.collapseRecurrence_G').hasClass('in')) {
                    $(this).text('[Hiển thị chi tiết sự kiện lặp]');
                } else {
                    $(this).text('[Ẩn chi tiết sự kiện lặp]');
                }
            });

            $('.date-picker').datetimepicker({
                locale: 'vi',
                format: 'DD/MM/YYYY',
                ignoreReadonly: true,
                showTodayButton: true,
                showClear: true,
                useCurrent: false,
                showClose: true
            });

            $('.startDate_G').on('dp.change', function(e){
                $('#MainForm').formValidation('revalidateField', '<%=txtStartDate_G.UniqueID%>');
            })
            $('.RecurrenceStartDate_G').on('dp.change', function(e){
                $('#MainForm').formValidation('revalidateField', '<%=txtRecurrenceStartDate_G.UniqueID%>');
            })
            $('.RecurrenceEndDate_G').on('dp.change', function(e){
                $('#MainForm').formValidation('revalidateField', '<%=txtRecurrenceEndDate_G.UniqueID%>');
            })
            $('#MainForm').formValidation({
                excluded: [':disabled'],
                framework: 'bootstrap',
                fields: {
                    <%=ddlDepartment_G.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Bạn vui lòng chọn khoa!'
                            },
                            callback: {
                                message:'Bạn vui lòng chọn khoa!',
                                callback: function(value, validator, $field) {
                                    if (value !== '-1') {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                        }
                    },
                    <%=ddlSubject_G.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message:  'Bạn vui lòng chọn bộ môn!'
                            },
                            callback: {
                                message:  'Bạn vui lòng chọn bộ môn!',
                                callback: function(value, validator, $field) {
                                    if (value !== '-1') {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                        }
                    },
                    <%= txtTitle_G.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Tiêu đề bắt buộc nhập liệu!'
                            }
                        }
                    },
                    <%=txtStartDate_G.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Ngày sinh bắt buộc phải nhập liệu!'
                            },
                            date: {
                                format: 'DD/MM/YYYY',
                                message: 'Ngày thực hiện không đúng định dạng!'
                            }
                        }
                    },
                    <%=txtPeriodicAmount_G.UniqueID%>: {
                        validators: {
                            between: {
                                min: 1,
                                max: 50,
                                message: 'Số lặp nằm trong khoảng 1 -50!'
                            }
                              ,callback: {
                                  message:  'Số lần bắt buộc nhập liệu!',
                                  callback: function(value, validator, $field) {
                                      if ( $("#<%=rdoRecurrencePeriodic_G.ClientID%>").is(':checked')==true && $("#<%=txtPeriodicAmount_G.ClientID%>").val()=="" ) {
                                          return false;
                                      }
                                      return true;
                                  }
                              }
                        }
                    },
                    <%=txtRecurrenceStartDate_G.UniqueID%>: {
                        validators: {
                            date: {
                                format: 'DD/MM/YYYY',
                                message: 'Ngày bắt đầu lặp không đúng đinh dang!'
                            }
                             ,callback: {
                                 message:  'Ngày bắt đầu lặp bắt buộc nhập liệu!',
                                 callback: function(value, validator, $field) {
                                     if (($("#<%=rdoRecurrenceMonthlyActual_G.ClientID%>").is(':checked')==true || $("#<%=rdoRecurrencePeriodic_G.ClientID%>").is(':checked')==true ) && $("#<%=txtRecurrenceStartDate_G.ClientID%>").val()=="") {
                                         console.log($("#<%=rdoRecurrenceMonthlyActual_G.ClientID%>").is(':checked'));
                                         return false;
                                     }
                                     return true;
                                 }
                             }
                        }
                    },
                    <%=txtRecurrenceEndDate_G.UniqueID%>: {
                        validators: {
                            date: {
                                format: 'DD/MM/YYYY',
                                message: 'Ngày kết thúc lặp không đúng đinh dạng!'
                            }
                            ,callback: {
                                message:  'Ngày kết thúc lặp bắt buộc nhập liệu!',
                                callback: function(value, validator, $field) {
                                    if (($("#<%=rdoRecurrenceMonthlyActual_G.ClientID%>").is(':checked')==true || $("#<%=rdoRecurrencePeriodic_G.ClientID%>").is(':checked')==true) && $("#<%=txtRecurrenceEndDate_G.ClientID%>").val()=="" ) {
                                        return false;
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            })
              .on('click', '#<%=rdoRecurrenceMonthlyActual_G.ClientID%>,#<%=rdoRecurrenceNone_G.ClientID%>,#<%=rdoRecurrencePeriodic_G.ClientID%>', function() {
                  $('#MainForm').formValidation('revalidateField', '<%=txtPeriodicAmount_G.UniqueID%>');
                  $('#MainForm').formValidation('revalidateField', '<%=txtRecurrenceStartDate_G.UniqueID%>');
                  $('#MainForm').formValidation('revalidateField', '<%=txtRecurrenceEndDate_G.UniqueID%>');
              });
            $("#<%= fileAttachments.ClientID %>").fileinput({'showUpload':false, 'previewFileType':'any',initialPreviewAsData: false });

        });
    </script>
</asp:Content>