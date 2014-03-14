<%@ Page Language="VB" AutoEventWireup="false" CodeFile="b_news.aspx.vb" Inherits="b_news" %>

<%@ Register src="b_top.ascx" tagname="b_top" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>最新消息設定</title>
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
<TABLE>
                                <TBODY">
                                  <TR align=middle>                             
                                    <TD width="6%"> 
                                      <div align="center">日期</div></TD>
                                    <TD width="6%"> 
                                      <div align="center">主旨</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">內容</div></TD>
                                    <TD width="2%"> 
                                      <div align="center">修改</div></TD>
                                    <TD width="2%"> 
                                      <div align="center">刪除</div></TD>
                                                                                                                                                                                                                                                                                               
                                  </TR>                                  
</HeaderTemplate>

<ItemTemplate>
                                  <TR>                                   
                                    <TD ><div align="center"><%#Container.DataItem("time")%></div></TD>
                                    <TD ><div align="center"><%#Container.DataItem("title")%></div></TD>
                                    <TD ><div align="center"><%#Container.DataItem("content")%></div></TD>
                                    <TD ><div align="center"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/edit.jpg" Height="20px" Width="20px" CommandName="修改"/></div></TD>                           
                                    <TD ><div align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/del.jpg" Height="20px" Width="20px" CommandName="刪除" OnClientClick="return confirm('確定要刪除嗎?')"/></div></TD>                           
                                                                                
                                  </TR>
</ItemTemplate>
<FooterTemplate>
                                </TBODY>
                              </TABLE>
</FooterTemplate>
</asp:Repeater>
</div>
   <asp:Button ID="Button2" runat="server" Text="新增消息" />
        
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton17" runat="server">上一頁</asp:LinkButton>
        <asp:LinkButton ID="LinkButton18" runat="server">下一頁</asp:LinkButton>
        <br />
        
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
                         日期</td>
                     <td>
                         <asp:TextBox ID="TextBox1" runat="server" Width="93px"></asp:TextBox>
                         <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                             Enabled="True" Format="yyyy/MM/dd" TargetControlID="TextBox1"></cc1:CalendarExtender>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         主旨</td>
                     <td>
                         <asp:TextBox ID="TextBox2" runat="server" Width="237px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         內容</td>
                     <td>
                         <asp:TextBox ID="TextBox3" runat="server" Height="107px" 
                TextMode="MultiLine" Width="394px"></asp:TextBox>
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