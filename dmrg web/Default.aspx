<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>DMRG</title>
<link href="style/style.css" rel="stylesheet" type="text/css" />
<link href="style/border.css" rel="stylesheet" type="text/css" />
</head>

<body>
<form id="form1" runat="server">
<div id="main">

    
    <div id="content">
            <div id="content_data">
            <div class="content_data_top">
                <div class="top_left"></div>
                <div class="top_right"></div>
            </div>
            
            <div class="content_data_center">
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 20px;">最新消息</div>
        <asp:Repeater id="Rep" Visible="True" EnableViewState="True" Runat="Server" 
                           >
<HeaderTemplate>
<TABLE width="100%" border="0"  align="center" cellPadding=0 cellSpacing=0 borderColorLight=#ffffff borderColorDark=#ffffff id="news" >
                                <TBODY style="color:#333333;">
                                  <TR align=middle>                             
                                    <TD width="10%"> 
                                      <div align="center">日期</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">主旨</div></TD>
                                    <TD width="60%"> 
                                      <div align="center">內容</div></TD>                                                                                                                                                                                                
                                  </TR>                                  
</HeaderTemplate>

<ItemTemplate>
                                  <TR>                                   
                                    <TD><div align="center"><%#Container.DataItem("日期")%></div></TD>
                                    <TD><div align="center"><%#Container.DataItem("主旨")%></div></TD>
                                    <TD><div align="left"><a href="news_info.aspx?id=<%#Container.DataItem("識別碼")%>"><%#Container.DataItem("內容")%></a></div></TD>                                    
</ItemTemplate>
<FooterTemplate>
                                </TBODY>
                              </TABLE>
</FooterTemplate>
</asp:Repeater>
        <table style="width:100%;" id="sel">
            <tr>
                <td class="style1" >
                    &nbsp;</td>
                <td class="style" >
                    <asp:LinkButton ID="LinkButton1" runat="server">&lt;</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server">&gt;</asp:LinkButton>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        </div>
      		<div class="content_data_bottom">
               <div class="bottom_left"></div>
               <div class="bottom_right"></div>
            </div>
	  </div>
    
    
    </div>

</div>


</form>
</body>
</html>
