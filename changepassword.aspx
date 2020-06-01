<%@ Page Language="VB" AutoEventWireup="false" CodeFile="changepassword.aspx.vb" Inherits="signin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
    <title>WASA Change Password</title>
 
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="stylesheets/signin-theme.css" />
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css" />
    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>

  
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
    <div class="navbar">
        <div class="navbar-inner">
                
        </div>
    </div>
        <div class="row-fluid">
        <div class="dialog">
        <div class="block">
            <p class="block-heading">Password Change</p>
            <div class="block-body">
                <form id="form1" runat="server">
                    <label>Username</label>
                      <asp:TextBox ID="txtusername" runat="server" width="130px" height="10px" borderstyle="Solid" bordercolor="GrayText" font-size="x-small" ></asp:TextBox>
                    <label>Old Password</label>
                            <asp:TextBox ID="txtoldpassword" runat="server" width="130px" height="10px" borderstyle="Solid" bordercolor="GrayText" font-size="x-small"></asp:TextBox>
                    <label>New Password</label>
                            <asp:TextBox ID="txtnewpassword" runat="server" width="130px" height="10px" borderstyle="Solid" bordercolor="GrayText" font-size="x-small"></asp:TextBox><br />
                            <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtnewpassword"
                            ValidationExpression="^[\s\S]{5,8}$" ErrorMessage="Password must contain: Minimum 5 and Maximum 8 characters required." ForeColor="Red" />
                        <br /> 
                        <asp:ImageButton ID="btnsign" runat="server" ImageUrl="~/images/submit.png" />
                        <div class="clearfix">
                            <asp:Label ID="labelerror" runat="server" Text="Label" Visible="False"></asp:Label>
                        </div>
                </form>
            </div>
        </div>
        <p class="pull-right" style=""><a href="" target="blank"></a></p>
    </div>
</div>
</body>