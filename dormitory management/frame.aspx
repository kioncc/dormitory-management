<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frame.aspx.cs" Inherits="dormitory_management.frame" %>

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
    <link rel="shortcut icon" href="images/favicon.ico" />
    <link rel="bookmark" href="images/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="css/base.css" />
    <link rel="stylesheet" type="text/css" href="css/iconfont.css" />
    <script type="text/javascript" src="framework/jquery-1.11.3.min.js"></script>
    <link rel="stylesheet" type="text/css" href="layui/css/layui.css" />
    <script type="text/javascript" src="layui/layui.js"></script>
    <!-- 滚动条插件 -->
    <link rel="stylesheet" type="text/css" href="css/jquery.mCustomScrollbar.css" />
    <script src="framework/jquery-ui-1.10.4.min.js"></script>
    <script src="framework/jquery.mousewheel.min.js"></script>
    <script src="framework/jquery.mCustomScrollbar.min.js"></script>
    <script src="framework/cframe.js"></script>
    <!-- 仅供所有子页面使用 -->
    <!-- 公共样式 结束 -->

    <link rel="stylesheet" type="text/css" href="css/frameStyle.css" />
    <script type="text/javascript" src="framework/frame.js"></script>
</head>
<body>
    <!-- 左侧菜单 - 开始 -->
    <div class="frameMenu">
        <div class="logo">
            <div class="logoText">
                <h1>课堂随机点名系统</h1>
                <p>RollCall</p>
            </div>
        </div>
        <div class="menu">
            <ul>
                <li>
                    <a class="menuFA"><i class="iconfont icon-liuliangyunpingtaitubiao03 left"></i>个人信息维护<i class="iconfont icon-dajiantouyou right"></i></a>
                    <dl>
                        <dt><a onclick="menuCAClick('person.aspx',this)">个人信息更改</a></dt>
                        <dt><a onclick="menuCAClick('WebForm1.aspx',this)">信息展示</a></dt>
                    </dl>
                </li>
                <li>
                    <a class="menuFA"><i class="iconfont icon-liuliangyunpingtaitubiao03 left"></i>课程管理<i class="iconfont icon-dajiantouyou right"></i></a>
                    <dl>
                        <dt><a onclick="menuCAClick('tgls/apply/history.aspx',this)">添加课程</a></dt>
                        <dt><a onclick="menuCAClick('tgls/apply/apply_list.aspx',this)">课程列表</a></dt>
                    </dl>
                </li>
                <li>
                    <a class="menuFA"><i class="iconfont icon-liuliangyunpingtaitubiao03 left"></i>学生管理<i class="iconfont icon-dajiantouyou right"></i></a>
                    <dl>
                        <dt><a onclick="menuCAClick('tgls/student/student_add.aspx',this)">学生信息录入</a></dt>
                        <dt><a onclick="menuCAClick('tgls/student/student_list.aspx',this)">学生列表</a></dt>
                    </dl>
                </li>
                <li>
                    <a class="menuFA"><i class="iconfont icon-liuliangyunpingtaitubiao03 left"></i>点名模块<i class="iconfont icon-dajiantouyou right"></i></a>
                    <dl>
                        <dt><a onclick="menuCAClick('RollCall.aspx',this)">点名</a></dt>
                    </dl>
                </li>
                <li>
                    <a class="menuFA"><i class="iconfont icon-liuliangyunpingtaitubiao03 left"></i>考勤模块<i class="iconfont icon-dajiantouyou right"></i></a>
                    <dl>
                        <dt><a onclick="menuCAClick('Record.aspx',this)">考勤记录</a></dt>
                    </dl>
                </li>
            </ul>
        </div>
    </div>
    <!-- 左侧菜单 - 结束 -->

    <div class="main">
        <!-- 头部栏 - 开始 -->
        <div class="frameTop">
            <img class="jt" src="images/top_jt.png" />
            <div class="topMenu">
                <ul>
                    <li><a onclick="menuCAClick('UpdatePassWord.aspx',this)"><i class="iconfont icon-xiugaimima"></i>修改密码</a></li>
						<li><a href="newLogin.aspx"><i class="iconfont icon-084tuichu"></i>注销</a></li>
                </ul>
            </div>
        </div>
        <!-- 头部栏 - 结束 -->

        <!-- 核心区域 - 开始 -->
        <div class="frameMain">
            <div class="title" id="frameMainTitle">
                <span><i class="iconfont icon-xianshiqi"></i>后台首页</span>
            </div>
            <div class="con">
                <iframe id="mainIframe" onscroll="auto"></iframe>
            </div>
        </div>
        <!-- 核心区域 - 结束 -->
    </div>
</body>
</html>
