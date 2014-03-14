<%@ Page Language="VB" AutoEventWireup="false" CodeFile="b_team.aspx.vb" Inherits="b_team" %>


<%@ Register src="b_top.ascx" tagname="b_top" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>研究團隊設定</title>
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
                                      <div align="center">年度</div></TD>
                                    <TD width="6%"> 
                                      <div align="center">班別</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">個人照片</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">姓名</div></TD>  
                                         <TD width="3%"> 
                                      <div align="center">刪除</div></TD>                                                                                                                                                                                                                                                                                         
                                  </TR>                                  
</HeaderTemplate>

<ItemTemplate>
    
                                  <TR>                                                                                                        
                                      <TD ><div align="center"><asp:LinkButton ID="LinkButton1" runat="server"  CommandName="查看"><%#Container.DataItem("year")%></asp:LinkButton></div></TD>                           
                                       <TD ><div align="center"><asp:LinkButton ID="LinkButton2" runat="server"  CommandName="查看"><%#Container.DataItem("style")%></asp:LinkButton></div></TD>                           
                                          <TD ><div align="center">
                                              <img alt="" src="team/photo/<%#Container.DataItem("photo")%>" />
                                        <TD ><div align="center"><asp:LinkButton ID="LinkButton3" runat="server"  CommandName="查看"><%#Container.DataItem("name")%></asp:LinkButton></div></TD>                                                                      
                                 
                                   <TD ><div align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/del.jpg" Height="20px" Width="20px" CommandName="刪除" OnClientClick="return confirm('確定要刪除嗎?')"/></div></TD>   
                                  </TR>
</ItemTemplate>
<FooterTemplate>
                                </TBODY>
                              </TABLE>
</FooterTemplate>
</asp:Repeater>
</div>
<div>
        <asp:Button ID="Button2" runat="server" Text="新增人員" />        
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton17" runat="server">上一頁</asp:LinkButton>
        <asp:LinkButton ID="LinkButton18" runat="server">下一頁</asp:LinkButton>
        <br />
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
                         年度</td>
                     <td>
                         <asp:TextBox ID="TextBox8" runat="server" Width="62px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         班別</td>
                     <td>
                         <asp:DropDownList ID="DropDownList2" runat="server">
                             <asp:ListItem>一般生</asp:ListItem>
                             <asp:ListItem>專班生</asp:ListItem>
                         </asp:DropDownList>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         姓名</td>
                     <td>
                         <asp:TextBox ID="TextBox2" runat="server" Width="151px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         照片</td>
                     <td>
                         <asp:Image ID="Image1" runat="server" />
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                         <asp:Button ID="Button4" runat="server" Text="上傳" />
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         發表論文</td>
                     <td>
                         <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="350px">
                         </FCKeditorV2:FCKeditor>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         關於我</td>
                     <td>
                         <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Height="350px">
                         </FCKeditorV2:FCKeditor>
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
