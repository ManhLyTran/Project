<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLock.aspx.cs" Inherits="HVKTQS.Web.Account.UserLock" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Khóa màn hình</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/components.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="../assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/lock.css" rel="stylesheet" type="text/css" />
</head>
<body class="">
    <form id="main" runat="server">
        <div class="page-lock">
            <div class="page-logo">
            </div>
            <div class="page-body">
                <div class="lock-head">Khóa màn hình </div>
                <asp:Literal runat="server" ID="litError"></asp:Literal>
                <div class="lock-body">
                    <div class="pull-left lock-avatar-block">
                        <asp:Image runat="server" ID="imgAvatar" CssClass="lock-avatar" Height="110px" Width="110px" />
                    </div>
                    <div class="lock-form pull-left">
                        <h4>
                            <asp:Label runat="server" ID="lblFullName"></asp:Label>
                        </h4>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control placeholder-no-fix" TextMode="Password" autocomplete="off" placeholder="Mật khẩu" />
                        </div>
                        <div class="form-actions">
                            <asp:Button runat="server" ID="btnLogin" CssClass="btn red uppercase" Text="Đăng nhập" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
                <div class="lock-bottom">
                    <a href="~/Account/Login" runat="server">Không phải
                     <asp:Label runat="server" ID="lblFullName1"></asp:Label>
                    </a>
                </div>
            </div>
            <div class="page-footer-custom">2017 © Design by Manh Ly Tran</div>
        </div>
    </form>
    <script src="../assets/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/scripts/lock.min.js" type="text/javascript"></script>
</body>
</html>