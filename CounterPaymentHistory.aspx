<%@ Page Title="" Language="C#" MasterPageFile="~/BillCounter.master" AutoEventWireup="true" CodeFile="CounterPaymentHistory.aspx.cs" Inherits="CounterPaymentHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:UpdateProgress ID="UpdateProgress" 
                DynamicLayout="true"
                AssociatedUpdatePanelID="UpdatePanel1"
                runat="server">
                <ProgressTemplate>
                
          <div style="margin:auto;
              font-family:Trebuchet MS;
              filter: alpha(opacity=100);
              opacity: 1;
              font-size:small;
              vertical-align: middle;
              top: 45%;
              position: fixed;
              right: 45%;
              color: #275721;
              text-align: center;
              background-color: White;
              height: 37px; width: 250px;">
                <table style=" background-color: White; font-family: Sans-Serif; text-align: center; border: solid 1px #275721; color: #275721; width: inherit; height: inherit; padding: 15px;">
                <tr>
                    <td style=" text-align: inherit;"><img src="images/progress.gif" alt="Loading"  /></td>
                </tr>
                <tr>
                    <td style=" text-align: inherit;"><span style="font-family: Sans-Serif; font-size: medium; font-weight: bold">Loading...</span></td>
                </tr>
                </table>
        </div>
                </ProgressTemplate>
                </asp:UpdateProgress>
                
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
             <div class="container">
             <div class="floatLeft">
             <div style="background-color:#546879;padding: 5px; margin: 10px 20px 10px 20px; border: 2px solid #C0C0C0;border-radius: 10px; -moz-border-radius: 10px;-webkit-border-radius: 10px;width:420px;">
                <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                        <td>
                                <asp:TextBox ID="txtconsumerno" 
                                    runat="server"
                                    CssClass="upper-case"
                                    placeholder="A0000000000"
                                    AutoPostBack="True" 
                                    Backcolor="beige"
                                    ForeColor="Gray"
                                    BorderColor="cornflowerblue"
                                    BorderWidth="1"
                                    Width="210px" 
                                    MaxLength="11" Font-Bold="True"></asp:TextBox>
                                  </td>
                    </tr>
          
      
                    
                    
                      <tr>
                        <td>
                        <asp:Button ID="btnsearch" OnClick = "btnsearch_Click" Style="width: 60px;" CssClass="button" runat="server" Text="Search"  />
                        <asp:Button ID="btncancel" Style="width: 60px;" CssClass="button" runat="server" Text="Reset"  />
                        </td>
                    </tr>
                
                </table>
</div>
</div>
</div>

<asp:GridView ID="gvSearch" 
        runat="server"
        Width="80%"
        BorderColor="gray" 
        BorderStyle="Outset"
        BorderWidth="1px" 
        Font-Size="8.5pt"
        Font-Names="Sans-Serif"
        BackColor="Beige" 
        GridLines="Both"
        CellPadding="3"
        CellSpacing="6"
        AutoGenerateColumns="false"
        >
<HeaderStyle BackColor="#5B74A8" />
<HeaderStyle ForeColor="White" />
<Columns>
        <asp:BoundField 
            DataField="Consumer_No"
            HeaderText="CONSUMER NO" ItemStyle-Wrap="False" HeaderStyle-Wrap="False">
            <HeaderStyle HorizontalAlign="left"></HeaderStyle> 
            <ItemStyle HorizontalAlign="left" Font-Bold="True"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField 
            DataField="Billed_Amount"
            HeaderText="BILLING AMOUNT" ItemStyle-Wrap="False" HeaderStyle-Wrap="False">
            <HeaderStyle HorizontalAlign="left"></HeaderStyle> 
            <ItemStyle HorizontalAlign="left" Font-Bold="True"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField 
            DataField="Payment_Amount"
            HeaderText="PAYMENT AMOUNT" ItemStyle-Wrap="False" HeaderStyle-Wrap="False">
            <HeaderStyle HorizontalAlign="left"></HeaderStyle> 
            <ItemStyle HorizontalAlign="left" Font-Bold="True"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField 
            DataField="Payment_Date"
            HeaderText="PAYMENT DATE" ItemStyle-Wrap="False" HeaderStyle-Wrap="False">
            <HeaderStyle HorizontalAlign="left"></HeaderStyle> 
            <ItemStyle HorizontalAlign="left" Font-Bold="True"></ItemStyle>
        </asp:BoundField> 
     <asp:BoundField 
            DataField="Billing_Month"
            HeaderText="BILLING MONTH" ItemStyle-Wrap="False" HeaderStyle-Wrap="False">
            <HeaderStyle HorizontalAlign="left"></HeaderStyle> 
            <ItemStyle HorizontalAlign="left" Font-Bold="True"></ItemStyle>
        </asp:BoundField> 
   </Columns>
      </asp:GridView>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnsearch" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>

