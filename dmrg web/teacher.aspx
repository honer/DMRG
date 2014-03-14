<%@ Page Language="VB" AutoEventWireup="false" CodeFile="teacher.aspx.vb" Inherits="teacher" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="down.ascx" tagname="down" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DMRG-指導教授</title>
<link href="style/style1.css" rel="stylesheet" type="text/css" />
<link href="style/border1.css" rel="stylesheet" type="text/css" />    
        <style type="text/css">
 
 
            .style1
            {
                width: 122px; text-align:right;
            }
 
 
    </style> 
</head>
<body>
      <form id="form1" runat="server">
<div id="main">
 <uc1:top ID="top1" runat="server" />
    
    <div id="content">
            <div id="content_data">
                 <div class="content_data_top">
                <div class="top_left"></div>
                <div class="top_right"></div>
            </div>
            
            <div class="content_data_center">
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">指導教授</div>
     
    <table width="200" border="1">
	    <tr>
	      <td><img src="team/photo/teacher.jpg" border="0"/></td>
	      <td colspan="2">  <table id="content" style="margin:5px 5px 5px 5px; width:400px; border:dashed 1px #cccccc; color:#000000;">
                <tr>
                    <td width="100px">
                        教師姓名： </td>
                    <td>
                        黃仁鵬　Jen-Peng Huang</td>
                </tr>
                <tr>
                    <td>
                        研究室位置：</td>
                    <td>
                        L305-1</td>
                </tr>
                <tr>
                    <td>
                        電話或分機號碼：</td>
                    <td>
                        (06)2533131-4322</td>
                </tr>
                <tr>
                    <td>
                        學經歷：</td>
                    <td>
                        美國奧克拉荷馬大學電腦科學博士</td>
                </tr>
                <tr>
                    <td>
                        研究領域或專長： </td>
                    <td>
                        平行處理、資料庫系統、物件導向程式設計、專家系統、演算法、超級電腦分析、資料探勘</td>
                </tr>
                <tr>
                    <td>
                        教授課程：</td>
                    <td>
                        資料庫理論與設計、資料探勘、專家系統 
                    </td>
                </tr>
                <tr>
                    <td>
                        個人興趣：</td>
                    <td>
                        養魚、種花、流行飲料、調酒、桌球</td>
                </tr>
                <tr>
                    <td>
                        電子郵件：</td>
                    <td>
                        jehuang@mail.stut.edu.tw </td>
                </tr>
            </table>
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
    
     
    
    
   <uc2:down ID="down1" runat="server" />
</div>
    </form>
</body>
</html>
