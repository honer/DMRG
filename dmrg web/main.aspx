<%@ Page Language="VB" AutoEventWireup="false" CodeFile="main.aspx.vb" Inherits="main" Debug="true" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>

<%@ Register src="down.ascx" tagname="down" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DMRG �ӷ~���z�����</title>    
<link href="style/style.css" rel="stylesheet" type="text/css" />
<link href="style/border1.css" rel="stylesheet" type="text/css" /> 
<meta name="KeyWords" content="���'��Ʊ���'data mining'�ӷ~���z" />
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
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">�̷s����</div>
<asp:Repeater id="Rep" Visible="True" EnableViewState="True" Runat="Server" 
                           >
<HeaderTemplate>
<TABLE width="100%" border="0"  align="center" cellPadding=0 cellSpacing=0 borderColorLight=#ffffff borderColorDark=#ffffff id="news" >
                                <TBODY style="color:#333333;">
                                  <TR align=middle>                             
                                    <TD width="10%"> 
                                      <div align="center">���</div></TD>
                                    <TD width="20%"> 
                                      <div align="center">���D</div></TD>
                                    <TD width="60%"> 
                                      <div align="center">���e</div></TD>                                                                                                                                                                                                
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
            <div style="background: #0099CC; color: #FFFFFF; font-family:Simhei, Verdana; font-size: 15px;">����ڭ�</div>
 <div class="about"><p>��Ʊ��ɬ�s�ζ�(DMRG)�A��褸1999�~���ߩ�n�x��ީҡC</p><p>���ɱб¬O�����P�Ѯv�A��s���譱�b2009�~�H�~�u�n�O�H��Ʊ��ɪ��t��k����s���ߡA�D�n�b�ﵽ�@�ǰ򥻪���Ʊ��ɺt��k�A�Ϩ�į��[�u�}�C</p><p>�ثe�ڭ̫h�O�q�ƥH��Ʊ��ɧ޳N�b������ά��D�n����s��V�A�����ӫ~�P�ӫ~���������Y�A���˨t�ΡA������Ʊ��ɵ�������ά���s��V�C</p><p>�ڭ̪���s�ǦbL304-1�A�W���ӷ~���z����ǡC</p></div>
 
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







