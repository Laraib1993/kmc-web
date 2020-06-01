<%@ Page Title="" Language="VB" MasterPageFile="~/webinventory.master" AutoEventWireup="false" CodeFile="createusers.aspx.vb" Inherits="createusers"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
    
    <asp:Label ID="lblmsg" runat="server" Text="Label" Visible="False"></asp:Label>
    <div>
        <asp:GridView ID="gvUsers" runat="server" 
            DataSourceID="dsUsers" 
                BorderWidth="2px" 
                CellPadding="0" 
                CellSpacing="0" 
                Font-Size="8.5pt"
                DataKeyNames="id"
                OnRowDataBound = "OnRowDataBound"
                HeaderStyle-BackColor="#5B74A8"
                HeaderStyle-ForeColor="White"  
                HeaderStyle-Font-Bold="true" 
                AutoGenerateColumns="false" 
                Width="60%">
            <Columns>

        <asp:TemplateField HeaderText="USERNAME">
        <HeaderStyle HorizontalAlign="left" />
        <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem, "username")%>
        </ItemTemplate>
         <ItemStyle Width="60px" HorizontalAlign="left" Font-Bold="True" Font-Size="14pt" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="PASSWORD">
        <HeaderStyle HorizontalAlign="left" />
        <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem, "password")%>
        </ItemTemplate>
         <ItemStyle Width="60px" HorizontalAlign="left" Font-Bold="True" Font-Size="14pt" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="USER RIGHTS">
        <HeaderStyle HorizontalAlign="left" />
        <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem, "usertypes")%>
        </ItemTemplate>
         <ItemStyle Width="30px" HorizontalAlign="left" Font-Bold="True" Font-Size="14pt" />
        </asp:TemplateField>
  
       <asp:TemplateField HeaderText="Edit">
            <ItemStyle Width="60px" HorizontalAlign="Center"/>
            <ItemTemplate>
                <asp:ImageButton ID="imgbtnedit" runat="server"
                        ImageUrl="~/images/edit.png"
                        CausesValidation="False" 
                        ToolTip="Edit"
                        OnCommand="CommandBtn_Click" 
                        CommandName="cmdEdit"
                        CommandArgument='<%# Eval("id").ToString() + ";" + Eval("username").ToString()+ ";" + Eval("password").ToString()%>'  
                         />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField 
                ShowDeleteButton="True" 
                ButtonType="Image" 
                HeaderText="Delete" 
                ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle" 
                DeleteImageUrl="~/images/delete.png"
                ItemStyle-Width="30px"
                 />
                
      </Columns>
      </asp:GridView>
        <asp:SqlDataSource ID="dsUsers" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WASA %>"
            DeleteCommand="delete from users where id = @id" 
            SelectCommand="select id,username,password,usertypes,IsActive from users">
         </asp:SqlDataSource>
    </div>
    <br />
    
    
<table border="2" cellpadding="0" cellspacing="0" width="25%">
     <tr>
            <td bgcolor="#4d5b76" colspan="3" align="left">
                <font color="white" size="1pt" ><b>ADD USERS</b></font>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                USERNAME:
            </td>
            <td>
                <asp:TextBox ID="txtusername" runat="server" width="120px" height="12px" MaxLength="25"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        ControlToValidate="txtusername" 
                        runat="server" 
                        ErrorMessage="">
                        <font color="Red" size="1" ><b>Required</b></font>
                     </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                PASSWORD:
            </td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server" width="120px" height="12px" MaxLength="10"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        ControlToValidate="txtpassword" 
                        runat="server" 
                        ErrorMessage="">
                        <font color="Red" size="1" ><b>Required</b></font>
                     </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                USER RIGHTS:
            </td>

             <td>
                <asp:DropDownList ID="ddtypes"
                    runat="server" 
                    AutoPostBack="True" 
                    onfocus="this.style.backgroundColor='LEMONCHIFFON'"  
                    onblur="this.style.backgroundColor='white'" 
                    width="135px" 
                    height="25px"
                    Font-Bold="True" 
                    Font-Size="10pt" >
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="Administrator">Administrator</asp:ListItem>
                    <asp:ListItem Value="Data Entry">Data Entry</asp:ListItem>
                     <asp:ListItem Value="Edit Entry">Edit Entry</asp:ListItem>
                    <asp:ListItem Value="Billing">Billing</asp:ListItem>
                    <asp:ListItem Value="MC">MC DMC</asp:ListItem>
                  </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorprefix" 
                    ControlToValidate="ddtypes" runat="server" 
                    ErrorMessage=""><font color="Red" size="1" ><b>Required</b></font>
                </asp:RequiredFieldValidator>
            </td>
        </tr>


   
        <tr>
            <td>
                
            </td>

            <td>
                <asp:Button ID="Button1" runat="server" OnCommand="btnsave_Click" Style="width: 60px;" CssClass="button" Text="Save" />
                <asp:Button ID="Button3" runat="server" OnCommand="btncancel_Click" Style="width: 60px;" CssClass="button" Text="Cancel" />
            </td>

        </tr>
       
    </table>
 
<asp:Panel ID="pnlpopup" runat="server" BackColor="#FF87CEEB" Height="120px" Width="240px" style="display:none; border-radius:3px; border: 1px solid #ccc"> 
      <table width="240px">
        <tr>
            <td>
                 
            </td>
            <td>
                <asp:Label ID="lbluserid" runat="server" Visible="False"></asp:Label>
            </td>
       </tr>

        <tr>
            <td align="right" valign="top">
                Username: 
            </td>
            <td>
                <asp:TextBox ID="txtupdateusername" runat="server" width="120px" height="10px" borderstyle="Solid" bordercolor="GrayText" font-size="x-small" ></asp:TextBox>
            </td>
       </tr>

       <tr>
            <td align="right" valign="top">
                Password: 
            </td>
            <td>
                <asp:TextBox ID="txtupdatepassword" runat="server" width="120px" height="10px" borderstyle="Solid" bordercolor="GrayText" font-size="x-small" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
           </td>
            <td>
                <asp:Button ID="btnUpdate" CausesValidation="False" CommandName="Update" runat="server" Text="Update" onclick="btnUpdate_Click" Style="width: 60px;" CssClass="button" />
                <asp:Button ID="btnCancel" CausesValidation="False" runat="server" Text="Cancel" Style="width: 60px;" CssClass="button" />
            </td>
       </tr>
</table>
</asp:Panel>


<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" 
    runat="server"
    Enabled="True" 
    TargetControlID="btnShowPopup" 
    PopupControlID="pnlpopup"
    CancelControlID="btnCancel" 
    BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>
<asp:Button ID="btnShowPopup" runat="server" style="display:none" />
 </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

