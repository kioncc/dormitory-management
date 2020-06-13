<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apply_list.aspx.cs" Inherits="dormitory_management.tgls.apply.apply_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
    <form id="form1" runat="server">


        <div style="display: inline-block; margin-top: 50px" class="layui-form-item">
            <label class="layui-form-label">*课程编号</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_id" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>

        <div style="display: inline-block" class="layui-form-item">
            <label class="layui-form-label">*课程名称</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_name" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div> 


        <asp:Button ID="select" Style="display: inline-block; margin-bottom: 60px" class="layui-btn" runat="server" Text="查询" OnClick="select_Click" />

        <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" class="layui-table" runat="server">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" />
                <asp:BoundField DataField="course_id" HeaderText="课程编号" />
                <asp:BoundField DataField="course_name" HeaderText="课程名称" />
                <asp:BoundField DataField="course_start" HeaderText="开始时间" />
                <asp:BoundField DataField="course_over" HeaderText="结束时间" />
                <asp:BoundField DataField="course_bz" HeaderText="课程备注" />
                <asp:BoundField DataField="teacher_id" HeaderText="教师编号" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        操作
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="Update.aspx?id=<%# Eval("id") %>">修改</a>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Del" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
