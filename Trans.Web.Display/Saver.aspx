<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Saver.aspx.cs" Inherits="Trans.Web.Display.Saver" %>
<script>
this.parent.document.getElementById('content').innerHTML='<%=mainContent.Replace("\'","\\\'") %>';
this.parent.document.getElementById('Status').innerHTML='<%=Status %>';
</script>
<%=thiscontent %>