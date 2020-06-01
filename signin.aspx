<%@ Page Language="VB" AutoEventWireup="false" CodeFile="signin.aspx.vb" Inherits="signin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
    <title>MUCT KMC BILLING</title>
    <!-- Creation Date: June 01, 2017            -->
    <!-- Develop and Design: Mohammad Mubashir     -->
   
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="stylesheets/signin-theme.css" />
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css" />
  
   
  
     <script type="text/javascript">

         window.onload = maxWindow;

         function maxWindow() {
             window.moveTo(0, 0);


             if (document.all) {
                 top.window.resizeTo(screen.availWidth, screen.availHeight);
             }

             else if (document.layers || document.getElementById) {
                 if (top.window.outerHeight < screen.availHeight || top.window.outerWidth < screen.availWidth) {
                     top.window.outerHeight = screen.availHeight;
                     top.window.outerWidth = screen.availWidth;
                 }
             }
         }
            window.history.forward();
        </script>

  </head>
 
  <body> 
  <div id="fixedheader">
      MUCT-KMC BILLING MANAGEMENT SYSTEM
  </div>
  <div class="dialog">
        <div class="block">
            <p class="block-heading">SIGN IN </p>
            <div class="block-body">
                <form id="form1" runat="server">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-user"></i></span>
                                <asp:TextBox ID="txtusername" runat="server" placeholder="Username"></asp:TextBox>
                        </div>
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-key"></i></span>
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                        <asp:ImageButton ID="btnsign" runat="server" ImageUrl="~/images/signbtn.jpg" />
                        <div class="clearfix">
                            <asp:Label ID="labelerror" runat="server" Text="Label" Visible="False"></asp:Label>
                        </div>
                        
                </form>
            </div>
        </div>
    </div>
    <div id="fixedfooter">
        <small>© Copyright 2017, Sprint Express Pakistan Karachi</small>
    </div>
</body>