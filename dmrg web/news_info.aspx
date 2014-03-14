<%@ Page Language="VB" AutoEventWireup="false" CodeFile="news_info.aspx.vb" Inherits="news_info" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="down.ascx" tagname="down" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>DMRG-研究團隊</title>
<link href="style/style2.css" rel="stylesheet" type="text/css" />
<link href="style/border2.css" rel="stylesheet" type="text/css" />    
        <style type="text/css">
 
 #content td { border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc; color:#333333; height:25px;}
 
            .style1
            {
                width: 137px;
            }
 
    </style> 
</head>
<body>
      <form id="form2" runat="server">
<div id="main">
 <uc1:top ID="top2" runat="server" />
    
    <div id="Div1">
            <div id="content_data">
                 <div class="content_data_top">
                <div class="top_left"></div>
                <div class="top_right"></div>
            </div>
            
            <div class="content_data_center">
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">研究團隊</div>
               <table style="width:100%;" id="content">
                <tr>
                    <td class="style1">
                        發佈日期</td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        標題</td>
                    <td>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        內容</td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
              <div align="center"><a href="main.aspx">返回</a></div>
 
        </div>
      		<div class="content_data_bottom">
               <div class="bottom_left"></div>
               <div class="bottom_right"></div>
            </div>
	  </div>
    
    
    </div>
    
     
    
    
   <uc2:down ID="down2" runat="server" />
</div>
    </form>
</body>
</html>
