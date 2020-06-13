<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassWord.aspx.cs" Inherits="dormitory_management.UpdatePassWord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,Chrome=1" />
    <!-- Google Chrome Frame也可以让IE用上Chrome的引擎: -->
    <meta name="renderer" content="webkit" />
    <!--国产浏览器高速模式-->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="网站简介" />
    <!-- 网站简介 -->
    <meta name="keywords" content="搜索关键字，以半角英文逗号隔开" />
    <title>课堂随机点名系统</title>
    <!-- 公共样式 开始 -->
    <link rel="stylesheet" type="text/css" href="../../css/base.css" />
    <link rel="stylesheet" type="text/css" href="../../css/iconfont.css" />
    <script type="text/javascript" src="../../framework/jquery-1.11.3.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../../layui/css/layui.css" />
    <script type="text/javascript" src="../../layui/layui.js"></script>
    <!-- 滚动条插件 -->
    <link rel="stylesheet" type="text/css" href="../../css/jquery.mCustomScrollbar.css" />
    <script src="../../framework/jquery-ui-1.10.4.min.js"></script>
    <script src="../../framework/jquery.mousewheel.min.js"></script>
    <script src="../../framework/jquery.mCustomScrollbar.min.js"></script>
    <script src="../../framework/cframe.js"></script>
    <!-- 仅供所有子页面使用 -->
    <!-- 公共样式 结束 -->

    <style>
        .layui-form {
            margin-right: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <div>
            <div class="layui-form-item">
                <label class="layui-form-label">*旧密码</label>
                <div class="layui-input-inline shortInput">
                    <asp:TextBox ID="oidpwd" runat="server" CssClass="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">*新密码</label>
                <div class="layui-input-inline shortInput">
                    <asp:TextBox ID="newpwd" runat="server" CssClass="layui-input"></asp:TextBox>
                </div>
            </div>

            <div class="layui-form-item">
                <label class="layui-form-label">*确认新密码</label>
                <div class="layui-input-inline shortInput">
                    <asp:TextBox ID="newpwdqr" runat="server" CssClass="layui-input"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="Update" Style="margin-left: 20%" class="layui-btn layui-btn-primary" runat="server" Text="修改密码" OnClick="Update_Click" />
        </div>
    </form>
</body>
</html>

