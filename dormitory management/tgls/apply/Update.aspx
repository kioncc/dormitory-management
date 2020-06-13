<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="dormitory_management.tgls.apply.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../framework/jquery-1.11.3.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../../layui/css/layui.css" />
    <script type="text/javascript" src="../../layui/layui.js"></script>
</head>
<body>
    <form id="addForm" class="layui-form" runat="server">
        <div class="layui-form-item">
            <label class="layui-form-label">*课程编号</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_id" class="layui-disabled" disabled runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*课程名称</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_name" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*开始时间</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_start" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
                <div class="layui-form-item">
            <label class="layui-form-label">*结束时间</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_over" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*课程备注</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="course_bz" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">*教师编号</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="teacher_id" class="layui-disabled" disabled runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input-block">
                <asp:Button ID="update" class="layui-btn layui-btn-primary" runat="server" Text="确认修改" OnClick="update_Click" />
            </div>
        </div>
    </form>
     <script>

        layui.use('laydate', function () {
            var laydate = layui.laydate;
            //执行一个laydate实例
            laydate.render({
                elem: '#course_start', //指定元素 
            });

            laydate.render({
                elem: '#course_over', //指定元素 
            });
        });

     </script>
</body>
</html>
