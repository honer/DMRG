<%@ Page Language="VB" AutoEventWireup="false" CodeFile="main.aspx.vb" Inherits="main" Debug="true" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>

<%@ Register src="down.ascx" tagname="down" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DMRG 商業智慧實驗室</title>    
<link href="style/style.css" rel="stylesheet" type="text/css" />
<link href="style/border1.css" rel="stylesheet" type="text/css" /> 
<meta name="KeyWords" content="資管'資料探勘'data mining'商業智慧" />
<meta name="google-site-verification" content="D_r9Nhq_Yik6jADSwhXkRn_yhTQv_H6OAmZXvNQM6Hk" />
</head>

<body>
<meta name="google-site-verification" content="D_r9Nhq_Yik6jADSwhXkRn_yhTQv_H6OAmZXvNQM6Hk" />   <form id="form1" runat="server">
<div id="main">
 <uc1:top ID="top1" runat="server" />
    
    
    <div id="content">
            <div id="content_data">
            <div class="content_data_top">
                <div class="top_left"></div>
                <div class="top_right"></div>
            </div>
            
            <div class="content_data_center">
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">最新消息</div>
<asp:Repeater id="Rep" Visible="True" EnableViewState="True" Runat="Server" 
                           >
<HeaderTemplate>
<TABLE width="100%" border="0"  align="center" cellPadding=0 cellSpacing=0 borderColorLight=#ffffff borderColorDark=#ffffff id="news" >
                                <TBODY style="color:#333333;">
                                  <TR align=middle>                             
                                    <TD width="10%"> 
                                      <div align="center">日期</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">標題</div></TD>
                                    <TD width="60%"> 
                                      <div align="center">內容</div></TD>                                                                                                                                                                                                
                                  </TR>                                  
</HeaderTemplate>

<ItemTemplate>
                                  <TR>                                   
                                    <TD><div align="center"><%#Container.DataItem("time")%></div></TD>
                                    <TD><div align="center"><%#Container.DataItem("title")%></div></TD>
                                    <TD><div align="left"><a href="news_info.aspx?id=<%#Container.DataItem("id")%>"><%#Container.DataItem("content")%></a></div></TD>                                    
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
         
         <br />
         
                 <div class="content_data_top">
                <div class="top_left"></div>
                <div class="top_right"></div>
            </div>
            
            <div class="content_data_center">
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">關於我們</div>
 <div class="about"><p>資料探勘研究團隊(DMRG)，於西元1999年成立於南台資管所。</p><p>指導教授是黃仁鵬老師，研究領域方面在2009年以年只要是以資料探勘的演算法為研究重心，主要在改善一些基本的資料探勘演算法，使其效能更加優良。</p><p>目前我們則是從事以資料探勘技術在實際應用為主要的研究方向，像說商品與商品之間的關係，推薦系統，網路資料探勘等實際應用為研究方向。</p><p>我們的研究室在L304-1，名為商業智慧實驗室。</p></div>
 
        </div>
      		<div class="content_data_bottom">
               <div class="bottom_left"></div>
               <div class="bottom_right"></div>
            </div>
	  </div>
    
    
    </div>
    
     
    
     <uc2:down ID="down1" runat="server" />
  
</div>





 





    </form>
</body>







