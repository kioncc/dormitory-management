<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RollCall.aspx.cs" Inherits="dormitory_management.RollCall" %>

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
        <div style="display: inline-block" class="layui-form-item">
            <label class="layui-form-label">*课程名称</label>
            <div class="layui-input-inline shortInput">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div style="display: inline-block" class="layui-form-item">
            <label class="layui-form-label">班级</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="banji" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>

        <div style="display: inline-block" class="layui-form-item">
            <label class="layui-form-label">性别</label>
            <div class="layui-input-inline shortInput">
                <asp:TextBox ID="sex" runat="server" CssClass="layui-input"></asp:TextBox>
            </div>
        </div>

        <div>

            <div style="margin-left: 30%" class="layui-form-item">
                <label class="layui-form-label">点名公示</label>
                <div style="font-size: 30px" class="layui-input-inline shortInput">
                    <asp:TextBox ID="WinThePrize" Width="200" Height="200" runat="server" CssClass="layui-input"></asp:TextBox>
                </div>
            </div>




            <div style="display: inline-block; margin-left: 34%" class="layui-input-block">
                <button type="button" class="layui-btn" onclick="GetSj()">随机点名</button>
            </div>


            <div style="display: inline-block" class="layui-input-block">
                <button type="button" class="layui-btn" onclick="getData()">全部点名</button>
            </div>

        </div>
    </form>
    <script>

        //
        var ci = 0;

        //循环出来 符合条件的
        function getData() {

            var ddl = document.getElementById("DropDownList1");
            var data = ddl.options[ddl.selectedIndex].text;

            var course_id = data;
            if (course_id == "") {
                alert("请至少输入【课程名称】");
                return;
            }

            var param = {
                "banji": document.getElementById("banji").value,
                "sex": document.getElementById("sex").value,
                "course_id": data,
            }
            $.ajax({
                type: "post",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(param),
                url: "/RollCall.aspx/GetData",
                success: function (data) {
                    var obj = JSON.parse(data.d);
                    if (obj.length == 0) {
                        alert("符合条件的学生不存在");
                    }

                    for (var i = 0; i < obj.length; i++) {
                        if (obj.length > ci) {
                            cha(obj[i]);
                            sleep(500);
                        }
                    }

                },
                error: function (xhr) {
                    alert("发送失败");
                }
            });
        }
        //新增方法
        function cha(json) {

            var ddl = document.getElementById("DropDownList1");
            var data = ddl.options[ddl.selectedIndex].text;

            var type = confirm(json.stu_name + "是否到教室");
            var param = {
                "json": JSON.stringify(json),
                "type": type,
                "course_id": data,
            }
            $.ajax({
                type: "post",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(param),
                url: "/RollCall.aspx/For",
                success: function (data) {
                    ci++;
                },
                error: function (xhr) {
                    alert("发送失败");
                }
            });

        }
        //等待方法

        function sleep(numberMillis) {
            var now = new Date();
            var exitTime = now.getTime() + numberMillis;
            while (true) {
                now = new Date();
                if (now.getTime() > exitTime) return;
            }
        }

        //获取中奖的学生
        function GetSj() {

            var ddl = document.getElementById("DropDownList1");
            var data = ddl.options[ddl.selectedIndex].text;

            if (data == null || data == "") {
                alert("请至少输入【课程名称】");
                return;
            }

            var param = {
                "banji": document.getElementById("banji").value,
                "sex": document.getElementById("sex").value,
                "course_id": data,
            }
            $.ajax({
                type: "post",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(param),
                url: "/RollCall.aspx/GetSj",
                success: function (data) {
                    document.getElementById("WinThePrize").value = data.d;
                    speckText(data.d)
                },
                error: function (xhr) {
                    alert("发送失败");
                }
            });

        }
        //语音播报方法
        function speckText(str) {
            var url = "http://tts.baidu.com/text2audio?lan=zh&ie=UTF-8&text=" + encodeURI(str);
            var n = new Audio(url);
            n.src = url;
            n.play();
        }
    </script>
</body>
</html>
