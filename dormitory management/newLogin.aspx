<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newLogin.aspx.cs" Inherits="dormitory_management.newLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录界面</title>
    <!-- 公共样式 开始 -->
		<link rel="shortcut icon" href="images/favicon.ico"/>
		<link rel="bookmark" href="images/favicon.ico"/>
		<link rel="stylesheet" type="text/css" href="css/base.css"/>
		<link rel="stylesheet" type="text/css" href="css/iconfont.css"/>
		<script type="text/javascript" src="framework/jquery-1.11.3.min.js"></script>
		<link rel="stylesheet" type="text/css" href="layui/css/layui.css"/>
		<script type="text/javascript" src="layui/layui.js"></script>
		<!-- 公共样式 结束 -->
		
		<link rel="stylesheet" type="text/css" href="css/login1.css"/>
		<script type="text/javascript" src="js/login1.js"></script>
    <style>
			body {
    margin: 0;
    padding: 0;
    font-family: sans-serif;
    background: url(https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1561611916356&di=a80b01f66d57237932a268463496778f&imgtype=0&src=http%3A%2F%2Fpic1.win4000.com%2Fwallpaper%2F2018-01-16%2F5a5dc3f3588b6.jpg) no-repeat;
    background-size: cover;
    background-color: black;
}
 
/*登录盒子样式*/
.login-box {
    width: 280px;
    position: absolute;
    top: 35%;
    left: 50%;
    transform: translate(-50%,-50%);
    color: white;
}
 
/*字体样式*/
.login-box h1 {
    float: left;
    font-size: 30px;
    border-bottom: 6px solid #4caf50;
    margin-bottom: 50px;
    padding: 13px 0;
}
 
.textbox {
    width: 100%;
    overflow: hidden;
    font-size: 20px;
    padding: 8px 0;
    margin: 8px 0;
    border-bottom: 1px solid #4caf50;
}
 
/*图标样式*/
.textbox i {
    width: 26px;
    float: left;
    text-align: center;
}
 
/*表单文本框样式*/
.textbox input {
    border: none;
    outline: none;
    background: none;
    color: white;
    font-size: 18px;
    width: 80%;
    float: left;
    margin: 0 10px;
}
 
/*表单登录按钮样式*/
.btn {
    width: 100%;
    background: none;
    border: 2px solid #4caf50;
    color: white;
    padding: 5px;
    font-size: 18px;
    cursor: pointer;
    margin: 12px 0;
}
		</style>
</head>
<body>
    <form id="form1" runat="server" class ="login-box">
                <h1>课堂随机点名系统</h1>
        <div class="textbox">
            <%--添加图标--%>
            <i class="fa fa-user" aria-hidden="true"></i>
            <asp:TextBox ID="username" runat="server" placeholder="请输入您的用户名"></asp:TextBox>
        </div> 
        <div class="textbox">
            <i class="fa fa-lock" aria-hidden="true"></i>
            <asp:TextBox ID="userpsw" runat="server" placeholder="请输入您的密码" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="login_btn" runat="server" Text="登录" CssClass="btn"/>
    </form>
</body>
</html>
