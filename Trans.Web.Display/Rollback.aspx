<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rollback.aspx.cs" Inherits="Trans.Web.Display.Rolls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>同步系统察看回滚</title>
</head>
<body>
<form id="MyForm" method="post" action="Rollback.aspx">
<table width="100%" border="1" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <%=RBOP %>
        </td>
    </tr>
    <tr>
        <td>
            <%=RBLOG %>
        </td>
    </tr>
</table>
<input type="hidden" id="RB" name="RB" value="" />
</form>
<script type="text/javascript" language="javascript">
    function RollBak(f) {
        document.getElementById("RB").value = f;
        document.MyForm.submit();
    }
</script>
</body>
</html>