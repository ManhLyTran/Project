<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditCalendar.aspx.cs" Inherits="HVKTQS.Web.Calendar.AddEditCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-head">
        <div class="page-title">
            <h1>
                <asp:Label runat="server" ID="lblTitle" Text="Thêm mới sự kiện khoa"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light bordered">
                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="control-label col-md-3 npr">
                                    Khoa: <span class="required">*</span>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control" Visible="false"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <div class="mt-checkbox-inline">
                                        <label class="mt-checkbox mt-checkbox-outline">
                                            <asp:CheckBox runat="server" ID="CheckBox3" />
                                            Sự kiện quan trọng
                                            <span></span>
                                        </label>
                                        <label class="mt-checkbox mt-checkbox-outline">
                                            <asp:CheckBox runat="server" ID="CheckBox4" />
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
                                    <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    Ngày thực hiện<span class="required" aria-required="true">* </span>
                                </label>
                                <div class="col-md-9">
                                    <div class='input-group input-group-ct date date-picker'>
                                        <div class='input-group  date bootstrap-datetimepicker'>
                                            <asp:TextBox ID="txtStartDate" CssClass="form-control bootstrap-dateentry" spellcheck="false" autocomplete="off" runat="server"></asp:TextBox>
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
                                            <asp:CheckBox runat="server" ID="chkAllDay" Checked="true" />
                                            Chưa xác định
                                                            <span></span>
                                        </label>
                                        <label class="mt-checkbox mt-checkbox-outline">
                                            <asp:CheckBox runat="server" ID="chkNotEndDate" />
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
                                            <asp:TextBox runat="server" ID="txtTimeStart" CssClass="form-control clock-picker timeStart"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="input-inline input-medium">
                                        <div class="input-group">
                                            <span class="input-group-addon">Kết thúc
                                            </span>
                                            <div class="input-group clockpicker" data-placement="left" data-align="top" data-autoclose="true">
                                                <asp:TextBox runat="server" ID="txtTimeEnd" CssClass="form-control clock-picker timeEnd"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Nội dung</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Địa điểm</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Chủ trì</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Thành phần tham gia</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Chuẩn bị</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtPreparation" CssClass="form-control "></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <b>Sự kiện lặp</b>
                                </label>
                                <div class="col-md-9">
                                    <a id="toggleRecurrence" href=".collapseRecurrence" data-toggle="collapse" class="form-control-static">[Hiển thị chi tiết sự kiện lặp]
                                    </a>
                                </div>
                            </div>
                            <div class="form-group collapse collapseRecurrence">
                                <label class="col-md-3 control-label">Sự kiện không lặp</label>
                                <div class="col-md-9">
                                    <div class="mt-radio-inline">
                                        <label class="mt-radio mt-radio-outline">
                                            <asp:RadioButton runat="server" ID="rdoRecurrenceNone" Checked="true" GroupName="Recurrence" />
                                            Xảy ra vào thời điểm được chỉ ra ở trên
                                                        <span></span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group collapse collapseRecurrence">
                                <label class="col-md-3 control-label">Xảy ra thường kỳ</label>
                                <div class="col-md-9 ">
                                    <label class="mt-radio mt-radio-outline">
                                        <asp:RadioButton runat="server" ID="rdoRecurrencePeriodic" GroupName="Recurrence" />
                                        Sự kiện này diễn ra (lặp)
                                                            <span></span>
                                    </label>
                                    <asp:TextBox runat="server" ID="txtPeriodicAmount" Width="30"></asp:TextBox>
                                    <asp:DropDownList runat="server" ID="ddlPeriodicCode" CssClass="input-small">
                                        <asp:ListItem Value="d">ngày 1 lần</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="w">tuần 1 lần</asp:ListItem>
                                        <asp:ListItem Value="m">tháng 1 lần</asp:ListItem>
                                        <asp:ListItem Value="y">năm 1 lần</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group collapse collapseRecurrence">
                                <label class="col-md-3 control-label">Sự kiện hàng tháng</label>
                                <div class="col-md-9">
                                    <label class="mt-radio mt-radio-outline">
                                        <asp:RadioButton runat="server" ID="rdoRecurrenceMonthlyActual" GroupName="Recurrence" />
                                        Sự kiện này diễn ra vào ngày
                                                            <span></span>
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlActualMonthlyDay">
                                    </asp:DropDownList>
                                    <label>hàng tháng</label>
                                </div>
                            </div>
                            <div class="form-group collapse collapseRecurrence">
                                <label class="col-md-3 control-label">Ngày bắt đầu lặp</label>
                                <div class="col-md-3">
                                    <div class='input-group input-group-ct date date-picker'>
                                        <div class='input-group  date bootstrap-datetimepicker'>
                                            <asp:TextBox ID="txtRecurrenceStartDate" CssClass="form-control bootstrap-dateentry" spellcheck="false" autocomplete="off" runat="server"></asp:TextBox>
                                            <span class="input-group-addon default">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <label class="col-md-3 control-label">Ngày kết thúc lặp lặp</label>
                                <div class="col-md-3">
                                    <div class='input-group input-group-ct date date-picker'>
                                        <div class='input-group  date bootstrap-datetimepicker'>
                                            <asp:TextBox ID="txtRecurrenceEndDate" CssClass="form-control bootstrap-dateentry" spellcheck="false" autocomplete="off" runat="server"></asp:TextBox>
                                            <span class="input-group-addon default">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions right">
                            <button type="button" class="btn default">Cancel</button>
                            <button type="submit" class="btn green">Submit</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>