﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Trans.Web.Display.Left" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>导航栏</title>
<style type="text/css">
ul{margin:0;padding:0;list-style:none;float:left;}
ul li{height:40px;display:block;margin-bottom:2px;black;}
ul li a{text-decoration:none;display:block;}
ul li a:hover{text-decoration:underline;color:red;background-color:#ccc;}
</style>
</head>
<body>
    <div>
        <ul>
            <li>
                <a href="Main.aspx" target="right">文件同步</a>
            </li>
            <li>
                <a href="Trace.aspx" target="right">同步日志</a>
            </li>
            <li>
                <a href="Rolls.aspx" target="right">回滚操作</a>
            </li>
            <li>
                <a href="Users.aspx" target="right">用户列表</a>
            </li>
        </ul>
    </div>
</body>
</html>