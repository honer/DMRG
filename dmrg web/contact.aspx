<%@ Page Language="VB" AutoEventWireup="false" CodeFile="contact.aspx.vb" Inherits="contact" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="down.ascx" tagname="down" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>DMRG-聯絡我們</title>
<link href="style/style2.css" rel="stylesheet" type="text/css" />
<link href="style/border2.css" rel="stylesheet" type="text/css" />    
        <style type="text/css">
 
 #content td { border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc; color:#333333; height:25px;}
 
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
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">聯絡我們</div>
     <table style="width:72%; margin:3px auto 20px auto;" id="content">
        <tr>
            <td colspan="2">
                留言給我們</td>
        </tr>
        <tr>
            <td>
                主旨</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" 
                    Width="432px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                內容</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" 
                    Height="183px" Width="440px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="確定" />           
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
    
     
    
    
   <uc2:down ID="down2" runat="server" />
</div>
    </form>
</body>
</html>

