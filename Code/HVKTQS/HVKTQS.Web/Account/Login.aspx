<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HVKTQS.Web.Account.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Đăng nhập hệ thống</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="../assets/font/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/components.css" rel="stylesheet" id="style_components" />
    <link href="../assets/css/plugins.css" rel="stylesheet" />
    <link href="../assets/css/login.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body class=" login">
    <div class="logo">
    </div>
    <div class="content">
        <form class="login-form" runat="server" >
            <h3 class="form-title">Đăng nhập hệ thống</h3>
                <asp:Literal runat="server" ID="litError"></asp:Literal>
            
            <div class="form-group">
                <label class="control-label">Tài khoản</label>
                <div class="input-icon">
                    <i class="fa fa-user"></i>
                    <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control placeholder-no-fix" autocomplete="off" placeholder="Tài khoản"  />
                </div>
            </div>
            <div class="form-group">
                <label class="control-label">Mật khẩu</label>
                <div class="input-icon">
                    <i class="fa fa-lock"></i>
                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control placeholder-no-fix" TextMode="Password" autocomplete="off" placeholder="Mật khẩu"  />
                </div>
            </div>
            <div class="form-actions">
                <label class="rememberme mt-checkbox mt-checkbox-outline">
                    <asp:CheckBox runat="server" ID="chkRemember" value="1" />
                    Ghi nhớ mật khẩu
                    <span></span>
                </label>
                <asp:Button runat="server" ID="btnLogin" CssClass="btn green pull-right" Text="Đăng nhập" OnClick="btnLogin_Click" />
            </div>
        </form>
    </div>

    <script src="../assets/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../assets/scripts/login.js" type="text/javascript"></script>
    <script src="../assets/scripts/app.js" type="text/javascript"></script>
    <script src="../assets/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
</body>
</html>
