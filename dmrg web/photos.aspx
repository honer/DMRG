<%@ Page Language="VB" AutoEventWireup="false" CodeFile="photos.aspx.vb" Inherits="photos" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="down.ascx" tagname="down" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>DMRG-活動照片</title>
<link href="style/style1.css" rel="stylesheet" type="text/css" />
<link href="style/border1.css" rel="stylesheet" type="text/css" />  
<script src="js/hg.js" type="text/javascript"></script>
<script src="js/jq.js" type="text/javascript"></script>  
        <style type="text/css">
 
 #content td { border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc; color:#333333; height:25px;}
 
    </style> 
    
    <script language="javascript" type="text/javascript">
  
    
    function show(x)
    {

        document.getElementById("photo_show2").src = "team/photos/" + x;
        document.getElementById("photo_show1").style.left= "300px";
        document.getElementById("photo_show1").style.top= "100px";
       // document.getElementById("photo_show1").style.display= "block";
        document.getElementById("photo_show1").style.position="absolute";
        $("#photo_show1").show(1000);  //css("display","block"); 
    }
    
    function hide_show()
    {
    
         $("#photo_show1").hide(1000,null);    
    }
   
    </script>
    
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
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">相關連結</div>
  
   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
  
   
                                <table style="width:100%;" id="sel">
            <tr>
           
                <td>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    目前第<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    </asp:DropDownList>頁
                </td>
                     <td>
                    <asp:LinkButton ID="LinkButton1" runat="server">&lt;</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server">&gt;</asp:LinkButton>
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
    
    <div id="photo_show1" style="display:none; border:solid 1px #cccccc; padding:3px 3px 3px 3px;"><div><img alt="" id="photo_show2" src="" border="0"/ width="660px"></div><div><a href="javascript:hide_show()"><img src="img/del.jpg" border="0" alt="0" width="20px"/></a></div></div>
</body>
</html>

