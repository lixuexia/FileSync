<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rolls.aspx.cs" Inherits="Trans.Web.Display.Roll" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>同步系统回滚</title>
</head>
<body>
<form id="MyForm" method="post" action="Rolls.aspx">
    <table width="100%" border="1" cellspacing="0" cellpadding="0">
        <caption style="color:Red;">备份回滚</caption>
        <tr>
            <td>
                <%=BakDateLab %>
            </td>
        </tr>
        <tr>
            <td>
                <%=BakMarkLab %>
            </td>
        </tr>
    </table>
    <input type="hidden" id="RollBackMark" value="" name="RollBackMark" />
</form>
<script type="text/javascript" language="javascript">
function SelBakDate()
{
    if(document.getElementById("BakDateList").value!="-1")
    {
        document.getElementById("RollBackMark").value='';
        document.MyForm.submit();
    }
}
function RollBack(rid)
{
    document.getElementById("RollBackMark").value=rid;
    document.MyForm.submit();
}
function ViewRBOp(rid)
{
    window.open("Roleback.aspx?RID="+encodeURIComponent(rid));
}
</script>
</body>
</html>