<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="HVKTQS.Web.Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-head">
        <div class="page-title break-head">
            <h1>Quản lý danh mục khoa</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-comments"></i>
                        <asp:Label ID="lblTitle" runat="server" Text="Danh mục khoa"></asp:Label>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="col-sm-12 nopadding list-head-function">

                        <div class="col-sm-6 nopadding">
                            <div class="form-group">
                                <button id="btnFirst" type="button" class="form-button btn btn-default" title="Đầu">
                                    <i class="fa fa-step-backward fa-lg" aria-hidden="true"></i>&nbsp;
                                </button>
                                <button id="btnPrev" type="button" class="form-button btn btn-default" title="Trước">
                                    <i class="fa fa-caret-left fa-lg" aria-hidden="true"></i>&nbsp;
                                </button>
                                <button id="btnNext" type="button" class="form-button btn btn-default" title="Sau">
                                    <i class="fa fa-caret-right fa-lg" aria-hidden="true"></i>&nbsp;
                                </button>
                                <button id="btnLast" type="button" class="form-button btn btn-default" title="Cuối">
                                    <i class="fa fa-step-forward fa-lg" aria-hidden="true"></i>&nbsp;
                                </button>
                                <button id="btnSaveViewOrder" type="button" class="form-button btn btn-default" title="Lưu thứ tự xem">
                                    <i class="fa fa-floppy-o fa-lg" aria-hidden="true"></i>Lưu thứ tự xem
                                </button>
                            </div>
                        </div>
                        <div class="col-sm-6 text-right nopadding">
                            <div class="form-group">
                                <button id="btnAdd" type="button" class="form-button btn btn-default">
                                    <i class="fa fa-plus" aria-hidden="true"></i>Thêm
                                </button>
                            </div>
                        </div>
                    </div>

                    <div id="divContent" class="table-scrollable">
                        <asp:Literal runat="server" ID="litList" Text=""></asp:Literal>
                    </div>

                    <div style="margin-top: 10px; font-style: italic;">
                        <b>Ghi chú:</b>
                        <span>Giữ trái chuột và kéo vào ô đầu tiên để sắp xếp thứ tự xem</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade draggable-modal" id="dlgAddEdit" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-md">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="dlgAddEdit-title">Thêm khoa</h4>
                </div>
                <div class="modal-body" style="max-height: 500px;">
                    <div class="form-horizontal">
                        <div id="d-alert" class="alert alert-danger" style="display: none;">
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-3 npr">
                                Tên khoa: <span class="required">*</span>
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtDepartmentName" CssClass="form-control input-xs" spellcheck="false" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 npr">
                                Mô tả:
                            </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtDescription" CssClass="form-control input-xs" spellcheck="false" autocomplete="off" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" id="dlgAddEdit-btnSaveAndAdd" class="btn green">Lưu & Thêm</button>
                    <button type="button" id="dlgAddEdit-btnSaveAndClose" class="btn green">Lưu & Đóng</button>
                    <button type="button" id="dlgAddEdit-btnClose" class="btn dark btn-outline" data-dismiss="modal">Đóng</button>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hddDialogResult" Value="" />
    <asp:HiddenField runat="server" ID="hddRowId" Value="0" />
    <script src="../assets/plugins/RowSorter/RowSorter.js"></script>
    <script type="text/javascript">
        function loadList() {
            $.ajax({
                url: "../List/Handler/DepartmentHandler.ashx?fn=GetHTML",
                type: "POST",
                async: true,
                success: function (response, textStatus, jqXHR) {
                    $('#divContent').html(response);
                    updateTitle();
                    $("#tblList").rowSorter({
                        handler: "span.drag-drop",
                        onDrop: function (tbody, row, new_index, old_index) {
                            ////Do work
                        }
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('Lỗi: ' + errorThrown);
                }
            });
        }

        function updateTitle() {
            var trs = $('#tblList tbody tr');
            if (trs != null) {
                $('#<%=lblTitle.ClientID%>').text('Danh mục khoa (' + trs.length + ')');
            }
        }

        function clearValue() {
            $("#<%=txtDepartmentName.ClientID%>").val("");
            $("#<%=txtDescription.ClientID%>").val("");
            $("#d-alert").html("");
            $("#d-alert").hide();
            $("#<%=txtDepartmentName.ClientID%>").focus();
        }

        function isValidated() {
            var strErr = "";

            if ($.trim($("#<%=txtDepartmentName.ClientID%>").val()) == "") {
                if (strErr == "") {
                    strErr = "Bạn chưa nhập tên!";
                }
                else {
                    strErr = strErr + "<br />" + "Bạn chưa nhập tên!";
                }
            }
            if (strErr != "") {
                $("#d-alert").html("<button aria-hidden='true' data-hide='alert' id='d-alert-close' class ='close' type='button'>×</button>" + strErr);
                $('#d-alert').show();
                return false;
            }
            else {
                $("#d-alert").html("");
                $('#d-alert').hide();
                return true;
            }
            return true;
        }

        function save() {
            var DepartmentName = $.trim($("#<%=txtDepartmentName.ClientID%>").val());
            var Description = $.trim($("#<%=txtDescription.ClientID%>").val());
            var DepartmentID = parseInt($.trim($("#<%=hddRowId.ClientID%>").val()));
            var objInfo = {};
            objInfo.DepartmentName = DepartmentName;
            objInfo.Description = Description;
            objInfo.DepartmentID = DepartmentID;
            $.ajax({
                url: "../List/Handler/DepartmentHandler.ashx?fn=AddUpdate",
                type: "POST",
                async: true,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(objInfo),
                dataType: "json",
                success: function (response, textStatus, jqXHR) {
                    if (response.hasExecuted == false) {
                        $("#d-alert").html("<button aria-hidden='true' data-hide='alert' id='d-alert-close' class ='close' type='button'>×</button>" + response.msg);
                        $('#d-alert').show();
                        $("#<%=txtDepartmentName.ClientID%>").focus();
                    }
                    else {
                        $("#d-alert").html("");
                        $('#d-alert').hide();

                        if ($("#<%=hddDialogResult.ClientID%>").val() == "SaveAndClose") {
                            $('#dlgAddEdit').modal('hide');
                        }
                        else if ($("#<%=hddDialogResult.ClientID%>").val() == "SaveAndAdd") {
                            clearValue();
                        }
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('Lỗi: ' + errorThrown);
                }
            });
        }

        $(document).ready(function () {
            updateTitle();
            $('body').on('mouseover', '#tblList tbody tr', function (e) {
                $(this).addClass('row-hover');
            });

            $('body').on('mouseout', '#tblList tbody tr', function (e) {
                $(this).removeClass('row-hover');
            });

            $('body').on('click', '#tblList tbody tr', function (e) {
                $('#tblList tbody tr.row-selected').removeClass('row-selected');
                $(this).addClass('row-selected');
            });

            $("body").on("click", "#d-alert-close", function (evt) {
                $("#d-alert").html("");
                $("#d-alert").hide();
            });

            $('#btnFirst').click(function (evt) {
                var row = $('.row-selected');
                if (row.length < 1) {
                    alert('Bạn chưa chọn khoa!');
                    return false;
                }
                $(row).prependTo("#tblList");
            });

            $('#btnPrev').click(function (evt) {
                var row = $('#tblList .row-selected');
                if (row.length < 1) {
                    alert('Bạn chưa chọn khoa!');
                    return false;
                }
                row.insertBefore(row.prev());
            });
            $('#btnNext').click(function (evt) {
                var row = $('#tblList .row-selected');
                if (row.length < 1) {
                    alert('Bạn chưa chọn khoa!');
                    return false;
                }
                row.insertAfter(row.next());
            });

            $('#btnLast').click(function (evt) {

                var row = $('#tblList .row-selected');
                if (row.length < 1) {
                    alert('Bạn chưa chọn khoa!');
                    return false;
                }
                $(row).appendTo("#tblList");
            });

            $('#btnSaveViewOrder').click(function (evt) {
                var $trs = $('#tblList tbody tr');
                var strDepartmentID = "";
                $trs.each(function (idx, item) {
                    strDepartmentID += $.trim($(item).find('td').eq(0).text()) + ",";
                });
                if (strDepartmentID == "") return false;

                $.ajax({
                    url: "../List/Handler/DepartmentHandler.ashx?fn=UpdateViewOrderInBatches",
                    type: "POST",
                    async: true,
                    data: "strDepartmentID=" + strDepartmentID,
                    success: function (response, textStatus, jqXHR) {
                        if (response.c > 0) {
                            alert(response.msg);
                            loadList();
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert('Lỗi: ' + errorThrown);
                    }
                });

            });

            //drag-drop
            $("#tblList").rowSorter({
                handler: "span.drag-drop",
                onDrop: function (tbody, row, new_index, old_index) {
                    //Do work
                }
            });

            //Add
            $("body").on("click", "#btnAdd", function (evt) {
                $("#dlgAddEdit-title").text("Thêm khoa");
                $("#dlgAddEdit-btnSaveAndAdd").show();
                clearValue();

                $("#dlgAddEdit").modal({
                    keyboard: false,
                    backdrop: "static"
                });
                $("#<%=txtDepartmentName.ClientID%>").focus();
            });

            //Edit
            $("body").on("click", ".lnkEdit", function (evt) {
                $("#dlgAddEdit-title").text("Sửa khoa");
                $("#dlgAddEdit-btnSaveAndAdd").hide();
                var tr = $(this).closest("tr");
                var DepartmentID = $.trim($(tr).find('td').eq(0).text());
                $("#<%=hddRowId.ClientID%>").val(DepartmentID);

                $.ajax({
                    url: "../List/Handler/DepartmentHandler.ashx?fn=GetByIDCache",
                    type: "POST",
                    async: true,
                    data: "DepartmentID=" + DepartmentID,
                    success: function (response, textStatus, jqXHR) {
                        var objInfo = $.parseJSON(response.d);
                        $("#<%=txtDepartmentName.ClientID%>").val(objInfo.DepartmentName);
                        $("#<%=txtDescription.ClientID%>").val(objInfo.Description)

                        $("#dlgAddEdit").modal({
                            keyboard: false,
                            backdrop: "static"
                        });
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert('Lỗi: ' + errorThrown);
                    }
                });

            });

            //Button Save And Add
            $("body").on("click", "#dlgAddEdit-btnSaveAndAdd", function (evt) {
                $("#<%=hddDialogResult.ClientID%>").val("SaveAndAdd");
                if (isValidated() == true) {
                    save();
                }
            });

            //Button Save And Close
            $("body").on("click", "#dlgAddEdit-btnSaveAndClose", function (evt) {
                $("#<%=hddDialogResult.ClientID%>").val("SaveAndClose");
                if (isValidated() == true) {
                    save();
                }
            });

            //Delete
            $("body").on("click", ".lnkDelete", function (evt) {
                if (confirm("Bạn có chắc chắn muốn xóa không?") == true) {
                    var tr = $(this).closest("tr");
                    var DepartmentID = $.trim($(tr).find('td').eq(0).text());

                    $.ajax({
                        url: "../List/Handler/DepartmentHandler.ashx?fn=DeleteByID",
                        type: "POST",
                        async: true,
                        data: "DepartmentID=" + DepartmentID,
                        success: function (response, textStatus, jqXHR) {
                            if (response.hasExecuted == false) {
                                alert("Chức danh này đang được sử dụng, bạn không được phép xóa!");
                            }
                            else {
                                loadList();
                            }
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            alert('Lỗi: ' + errorThrown);
                        }
                    });
                }
            });

            //Close modal
            $('#dlgAddEdit').on('hide.bs.modal', function (evt) {
                $("#<%=hddRowId.ClientID%>").val('0');
                $("#d-alert").html("");
                $("#d-alert").hide();
                loadList();
            })

        });
    </script>
</asp:Content>