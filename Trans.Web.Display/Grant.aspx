<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grant.aspx.cs" Inherits="Trans.Web.Display.Grant" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/JSTree/dist/themes/default/style.min.css" rel="stylesheet" type="text/css" />
    <script src="/JSTree/dist/jquery.1.9.1.min.js" type="text/javascript"></script>
    <script src="/JSTree/dist/jstree.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
<% if(CanAcce){ %>
    <form id="form1" runat="server">
            <!--加载树-->
        <div id="JsonTree" class="demo" style=" margin-bottom:20px; margin-left:10px; margin-right:50px; float:left; width:30% ">
        </div>
    <div> 
        <table id="UserTbl"  border="1px" cellpadding="0" cellspacing="0"  width="40%">
            <thead>
                <tr>
                    <td style=" min-width:30px">
                        <input type="checkbox" value="-1"   id='AllCheck'/>全选
                    </td>
                    <td style=" min-width:50px">
                        用户名
                    </td>
                    <td style=" min-width:60px">
                        邮箱
                    </td>
                </tr>
            </thead>
            <tbody id="tbody">
                <%=UserList %>
                <tr>
                    <td colspan="3"><input  type="button" value="添加网站同步权限" id="addAuthor"/ style=" margin-right:10px" />
                        <%--<input  type="button" value="添加回滚权限" id="addRoll"/ style=" margin-right:10px" />--%>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
    <%} %>
    <script type="text/javascript">
      //默认选中节点
        function CheckedNode(){            
        // $("#JsonTree").jstree("check_node", "<%=SelectedItem %>");
            var arry='<%=SelectedItem %>';
            var checkNode=arry.split(',');
            $('#JsonTree').find('li').each(function(){
               // alert($(this).attr('id'));
               var idAttr=$(this).attr('id').split(";;");
                for (var i = 0; i <checkNode.length; i++) {      
                    if(checkNode[i].indexOf( idAttr[0])!=-1 && checkNode[i].indexOf( ";;"+idAttr[1])!=-1){
                        $('#JsonTree').jstree('open_node',$(this));
                    }
                    if ($(this).attr('id') == checkNode[i]){
                        $('#JsonTree').jstree('check_node',$(this));
                    }
                }
            });
        }
        $('#JsonTree').jstree({
           'core' : {
               'data': [
               <%=SiteAuthor %>
            ]
		},
            plugins: ["themes", "json_data", "checkbox", "ui"]   //加载插件
        })
        .bind("loaded.jstree", function(e,data){  $('#JsonTree').jstree('open_node',$('li[id="-1"]'))})
        .bind("after_open.jstree", function(e,data){CheckedNode();});

        //全选
        $('#AllCheck').click(function(){
            var checked=$(this).prop('checked');
            $('#tbody [type="checkbox"]').prop("checked",checked);
        });
        //获得被选中项的站点文件，以‘,’分开
        function get_authchecked()
        {
            var authchecked = "";
            var nodes=$("#JsonTree").jstree("get_checked"); //使用get_checked方法 
            $.each(nodes, function(i, n) { 
            authchecked += n+",";
            }); 
//            $("li[aria-selected='true']").each(function(i, element){
//                    authchecked = authchecked + $(element).attr("id") + ",";  //jQuery代码获得以空格隔开的checkbox被选中的项的ID串
//            });
            //获得该站点下的
            return authchecked;
        }
        //获得选中的用户ID
        function get_userChecked(){
             var userChecked="";
            $('#tbody input:checked').each(function(i,element){
                  userChecked = userChecked + $(element).val() + ",";  //jQuery代码获得以空格隔开的checkbox被选中的项的ID串
           });
           return userChecked;
        }
        //给选中的用户添加站点文件权限
        $('#addAuthor').click(function(){
            var userChecked=get_userChecked();
            var authchecked=get_authchecked();
            $.ajax({
                url:"Auth.ashx",
                data:{uid: userChecked, aid: authchecked},
                type: "post",
                success:function(_data){
                    alert(_data);
                    window.parent.location.href="./";
                }
            });
        });
    </script>
</body>
</html>