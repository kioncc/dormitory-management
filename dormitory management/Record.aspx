<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="dormitory_management.Record" %>

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
    <script src="../../framework/cframe.js"></script>·
    <!-- 仅供所有子页面使用 -->
    <!-- 公共样式 结束 -->

    <style>
        .layui-form {
            margin-right: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" style="width: 95%" class="layui-form" runat="server">


        <div>


            <div style="display: inline-block; margin-top: 50px" class="layui-form-item">
                <label class="layui-form-label">考勤状态</label>
                <div class="layui-input-inline shortInput">
                    <asp:TextBox ID="type" runat="server" CssClass="layui-input"></asp:TextBox>
                </div>
            </div>

            <div style="display: inline-block" class="layui-form-item">
                <label class="layui-form-label">开始时间</label>
                <div class="layui-input-inline shortInput">
                    <asp:TextBox ID="start" type="text" runat="server" CssClass="layui-input"></asp:TextBox>
                </div>
            </div>


            <div style="display: inline-block" class="layui-form-item">
                <label class="layui-form-label">结束时间</label>
                <div class="layui-input-inline shortInput">
                    <asp:TextBox ID="end" runat="server" CssClass="layui-input"></asp:TextBox>
                </div>
            </div>

            <div style="display: inline-block" class="layui-form-item">
                <label class="layui-form-label">课程名称</label>
                <div class="layui-input-inline shortInput" style="height: 17px">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </div>
            </div>


            <asp:Button ID="select" Style="margin-bottom: 60px; margin-left: 80%" class="layui-btn" runat="server" Text="查询" OnClick="select_Click" />

            <asp:Button ID="output" Style="margin-bottom: 60px" class="layui-btn" runat="server" Text="导出" OnClick="output_Click1" />
            <asp:GridView ID="GridView1" class="layui-table" runat="server">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="学号" />
                    <asp:BoundField DataField="student_name" HeaderText="学生名称" />
                    <asp:BoundField DataField="atd_state" HeaderText="出勤状态" />
                    <asp:BoundField DataField="atd_time" HeaderText="考勤时间" />
                    <asp:BoundField DataField="course_id" HeaderText="课程名称" />
                    <asp:BoundField DataField="teacher_id" HeaderText="教师编号" />
                </Columns>
            </asp:GridView>
        </div>
    </form>

    <script>

        layui.use('laydate', function () {
            var laydate = layui.laydate;
            //执行一个laydate实例
            laydate.render({
                elem: '#start', //指定元素 
            });

            laydate.render({
                elem: '#end', //指定元素 
            });
        });




    </script>
</body>
</html>
