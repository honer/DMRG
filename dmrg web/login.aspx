<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DMRG後台管理</title>
    <link href="style/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="main">
    <div id="main2">
           <asp:Panel ID="Panel1" runat="server">
          <div class="title"> 
       
         DMRG 後台管理登入</div>
       <div align="center"> 登入帳號 <asp:TextBox ID="TextBox1" runat="server" Width="111px"></asp:TextBox>
        
        </div>
        
        <div align="center">登入密碼 <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="111px"></asp:TextBox>
        </div>
        
       <div align="center" style="margin-top:6px;">  <asp:Button ID="Button1" runat="server" Text="登入" />  </div>
         
           </asp:Panel>
           <cc1:RoundedCornersExtender ID="Panel1_RoundedCornersExtender" runat="server" 
               Enabled="True" TargetControlID="Panel1" Radius="10" Color="#006699" 
               BorderColor="#006699">
           </cc1:RoundedCornersExtender>
      
    </div>
    </div>
    

   
    </form>
</body>
</html>