<%@ Page Language="VB" AutoEventWireup="false" CodeFile="about.aspx.vb" Inherits="about" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="down.ascx" tagname="down" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DMRG-關於我們</title>
<link href="style/style1.css" rel="stylesheet" type="text/css" />
<link href="style/border1.css" rel="stylesheet" type="text/css" />    
        <style type="text/css">
 
 #content td { border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc; color:#333333; height:25px;}
 
    </style> 
</head>
<body>
      <form id="form2" runat="server">
<div id="main">
 <uc1:top ID="top2" runat="server" />
    <div id="content">
            <div id="content_data">
                 <div class="content_data_top">
                <div class="top_left"></div>
                 <div class="top_right"></div>
            </div>
            
            <div class="content_data_center">
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">關於我們</div>
 <div style="padding:5px 5px 5px 5px;">

	<div class="about"><p>資料探勘研究團隊(DMRG)，於西元1999年成立於南台資管所。</p><p>指導教授是黃仁鵬老師，研究領域方面在2009年以年只要是以資料探勘的演算法為研究重心，主要在改善一些基本的資料探勘演算法，使其效能更加優良。</p><p>目前我們則是從事以資料探勘技術在實際應用為主要的研究方向，像說商品與商品之間的關係，推薦系統，網路資料探勘等實際應用為研究方向。</p><p>我們的研究室在L304-1，名為商業智慧實驗室。</p></div>

</div>
 
        </div>
      		<div class="content_data_bottom">
               <div class="bottom_left"></div>
               <div class="bottom_right"></div>
            </div>
	  </div>
    
   
    
    </div>
    
     
     <div></div>
    
   <uc2:down ID="down2" runat="server" />
</div>
    </form>
</body>
</html>
