<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="dormitory_management.tgls.student.Update" %>

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
    <form id="addForm" class="layui-form" runat="server">
        <div class="layui-form-item">
            <label class="layui-form-label">*学号</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="stu_id" class="layui-disabled" disabled runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*学生姓名</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="stu_name" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*学生性别</label>
            <div class="layui-input-inline shortInput">
                <asp:RadioButton GroupName="xb" ID="RadioButton1" runat="server" /><span style="position: fixed; left: 138px; top: 115px">男</span>
                <asp:RadioButton GroupName="xb" ID="RadioButton2" runat="server" /><span style="position: fixed; left: 188px; top: 115px">女</span>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*班级</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="banji" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*学生电话</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="stu_tel" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*课程名称</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_name" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>

        <div class="layui-form-item">
            <div class="layui-input-block">
                <asp:Button ID="update" class="layui-btn layui-btn-primary" runat="server" Text="确认修改" OnClick="update_Click" />
            </div>
        </div>
    </form>
</body>
</html>
