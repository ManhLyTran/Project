<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="HVKTQS.Web.Shared.Header" %>
<div class="page-header navbar navbar-fixed-top">
    <div class="page-header-inner ">
        <div class="page-logo">
            <a runat="server" href="~/">
                <img src="../assets/img/logo.png" alt="logo" class="logo-default" />
            </a>
            <div class="menu-toggler sidebar-toggler">
                <!-- DOC: Remove the above "hide" to enable the sidebar toggler button on header -->
            </div>
        </div>
        <a href="javascript:;" class="menu-toggler responsive-toggler" data-toggle="collapse" data-target=".navbar-collapse"></a>
        <div class="page-actions hidden-xs">
            <h3 style="vertical-align: middle; color: #aeb2c4;">Khoa công nghệ thông tin</h3>
        </div>
        <div class="page-top">
            <!-- BEGIN TOP NAVIGATION MENU -->
            <div class="top-menu">
                <ul class="nav navbar-nav pull-right">
                    <li class="separator hide"></li>
                    <li class="dropdown dropdown-extended dropdown-inbox dropdown-dark" id="header_inbox_bar">
                        <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true">
                            <i class="icon-bell"></i>
                            <span class="badge badge-danger">4 </span>
                        </a>
                        <ul class="dropdown-menu">
                            <li class="external">
                                <h3>You have
                                            <span class="bold">7 New</span> Messages</h3>
                                <a href="app_inbox.html">view all</a>
                            </li>
                            <li>
                                <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 275px;">
                                    <ul class="dropdown-menu-list scroller" style="height: 275px; overflow: hidden; width: auto;" data-handle-color="#637283" data-initialized="1">
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="../assets/img/avatar2.jpg" class="img-circle" alt="" />
                                                </span>
                                                <span class="subject">
                                                    <span class="from">Lisa Wong </span>
                                                    <span class="time">Just Now </span>
                                                </span>
                                                <span class="message">Vivamus sed auctor nibh congue nibh. auctor nibh auctor nibh... </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="../assets/img/avatar2.jpg" class="img-circle" alt="" />
                                                </span>
                                                <span class="subject">
                                                    <span class="from">Richard Doe </span>
                                                    <span class="time">16 mins </span>
                                                </span>
                                                <span class="message">Vivamus sed congue nibh auctor nibh congue nibh. auctor nibh auctor nibh... </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="../assets/img/avatar2.jpg" class="img-circle" alt="" />
                                                </span>
                                                <span class="subject">
                                                    <span class="from">Bob Nilson </span>
                                                    <span class="time">2 hrs </span>
                                                </span>
                                                <span class="message">Vivamus sed nibh auctor nibh congue nibh. auctor nibh auctor nibh... </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="../assets/img/avatar2.jpg" class="img-circle" alt="" />
                                                </span>
                                                <span class="subject">
                                                    <span class="from">Lisa Wong </span>
                                                    <span class="time">40 mins </span>
                                                </span>
                                                <span class="message">Vivamus sed auctor 40% nibh congue nibh... </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="../assets/img/avatar2.jpg" class="img-circle" alt="" />
                                                </span>
                                                <span class="subject">
                                                    <span class="from">Richard Doe </span>
                                                    <span class="time">46 mins </span>
                                                </span>
                                                <span class="message">Vivamus sed congue nibh auctor nibh congue nibh. auctor nibh auctor nibh... </span>
                                            </a>
                                        </li>
                                    </ul>
                                    <div class="slimScrollBar" style="background: rgb(99, 114, 131); width: 7px; position: absolute; top: 0px; opacity: 0.4; display: none; border-radius: 7px; z-index: 99; right: 1px; height: 160.904px;"></div>
                                    <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; background: rgb(234, 234, 234); opacity: 0.2; z-index: 90; right: 1px;"></div>
                                </div>
                            </li>
                        </ul>
                    </li>
                    <li class="separator hide"></li>

                    <!-- BEGIN USER LOGIN DROPDOWN -->
                    <li class="dropdown dropdown-user dropdown-dark">
                        <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                            <asp:Label runat="server" ID="lblFullName" CssClass="username username-hide-on-mobile"></asp:Label>
                            <asp:Image runat="server" ID="imgAvatar" CssClass="img-circle" Height="39px" Width="39px" />
                        </a>
                        <ul class="dropdown-menu dropdown-menu-default">
                            <li>
                                <asp:HyperLink runat="server" ID="lnkMyCalendar" NavigateUrl="~/Calendar/MyCalendar">
                                  <i class="icon-calendar"></i>Lịch của tôi
                                </asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkMyProfile" NavigateUrl="~/Account/MyProfile">
                                    <i class="icon-user"></i>Thông tin cá nhân
                                </asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkChangePassword" NavigateUrl="~/Account/ChangePassword">
                                   <i class="icon-rocket"></i>Thay đổi mật khẩu
                                </asp:HyperLink>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkUserLock" NavigateUrl="~/Account/UserLock">
                                   <i class="icon-lock"></i>Khóa màn hình
                                </asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkLogOut" NavigateUrl="~/Account/Login">
                                    <i class="icon-key"></i>Đăng xuất
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </li>
                    <!-- END USER LOGIN DROPDOWN -->
                </ul>
            </div>
        </div>
    </div>
</div>