<%@ Page Language="VB" AutoEventWireup="false" CodeFile="b_link.aspx.vb" Inherits="b_link" %>


<%@ Register src="b_top.ascx" tagname="b_top" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>相關連結設定</title>
    <link href="style/back_style.css" rel="stylesheet" type="text/css" />  
    <style type="text/css">
        .style1
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
        <uc1:b_top ID="b_top1" runat="server" />
        <div id="show">
   <asp:Repeater id="Rep" Visible="True" EnableViewState="True" Runat="Server" 
                            onitemcommand="Rep_ItemCommand">
<HeaderTemplate>
<TABLE width="100%" border="1"  align="center" cellPadding=0 cellSpacing=0 borderColorLight=#888888 borderColorDark=#ffffff >
                                <TBODY>
                                  <TR align=middle>                             
                                    <TD width="15%"> 
                                      <div align="center">類型</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">名稱</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">連結</div></TD>
                                    <TD width="2%"> 
                                      <div align="center">修改</div></TD>
                                    <TD width="2%"> 
                                      <div align="center">刪除</div></TD>
                                                                                                                                                                                                                                                                                               
                                  </TR>                                  
</HeaderTemplate>

<ItemTemplate>
                                  <TR>                                   
                                    <TD ><div align="center"><%#Container.DataItem("類型")%></div></TD>
                                    <TD ><div align="center"><%#Container.DataItem("名稱")%></div></TD>
                                    <TD ><div align="center"><%#Container.DataItem("連結")%></div></TD>
                                      <TD ><div align="center"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/edit.jpg" Height="20px" Width="20px" CommandName="修改"/></div></TD>                           
                                    <TD ><div align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/del.jpg" Height="20px" Width="20px" CommandName="刪除" OnClientClick="return confirm('確定要刪除嗎?');" /></div></TD>                           
                                                                                
                                  </TR>
</ItemTemplate>
<FooterTemplate>
                                </TBODY>
                              </TABLE>
</FooterTemplate>
</asp:Repeater>
</div>
<div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton17" runat="server">上一頁</asp:LinkButton>
        <asp:LinkButton ID="LinkButton18" runat="server">下一頁</asp:LinkButton>
        <br />
        <asp:Button ID="Button2" runat="server" Text="新增消息" />
        </div>
     <div>
         <asp:Panel ID="Panel1" runat="server" Visible="false">
             <table style="width: 67%;">
                 <tr>
                     <td class="style1" align="center" colspan="2">
                         <asp:Label ID="Label1" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         類型</td>
                     <td>
                         <asp:TextBox ID="TextBox1" runat="server" Width="387px"></asp:TextBox>
                         <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                             Enabled="True" Format="yyyy/MM/dd" TargetControlID="TextBox1">
                         </cc1:CalendarExtender>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         名稱</td>
                     <td>
                         <asp:TextBox ID="TextBox2" runat="server" Width="388px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         連結</td>
                     <td>
                         <asp:TextBox ID="TextBox3" runat="server" Width="388px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         &nbsp;</td>
                     <td>
                         <asp:Button ID="Button1" runat="server" Text="確定" />
                         <asp:Button ID="Button3" runat="server" Text="取消" />
                     </td>
                 </tr>
             </table>
         </asp:Panel>
         <br />
         &nbsp;<br />
         <br />
         <br />
            </div>
    
    </div>
   
    
    </form>
</body>
</html>