<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Trans.Web.Display.Users" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>用户列表</title>
<style type="text/css">
*{font-size:12px; font-family:arial;}
table{background-color:#333;}
table tr th{background-color:#eee;}
table tr td{background-color:#fff;}
table tr.out td{background-color:#fff;}
table tr.over td{background-color:#eee;}
.s1{color:#FF9900;}
.s2{color:green;}
.s3{color:black;}
.s-1{color:red;}
.s-2{color:red;}
.s-3{color:red;}
</style>
</head>
<body>
    <%=ListStr %>
</body>
</html>