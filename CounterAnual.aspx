﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BillCounter.master" AutoEventWireup="true" CodeFile="CounterAnual.aspx.cs" Inherits="CounterAnual" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
      function Print() {
          var dvReport = document.getElementById("dvReport");
          var frame1 = dvReport.getElementsByTagName("iframe")[0];
          if (navigator.appName.indexOf("Internet Explorer") != -1 || navigator.appVersion.indexOf("Trident") != -1) {
              frame1.name = frame1.id;
              window.frames[frame1.id].focus();
              window.frames[frame1.id].print();
          }
          else {
              var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
              frameDoc.print();
          }
      }
    </script>


      <asp:UpdatePanel ID="consumernoPanel" runat="server" UpdateMode="Conditional">
               <ContentTemplate>

      <div align="center">
             <div style="background-color:#546879;padding: 5px; margin: 10px 20px 10px 20px; border: 2px solid #C0C0C0;border-radius: 10px; -moz-border-radius: 10px;-webkit-border-radius: 10px;width:240px;">
                <table cellpadding="0" cellspacing="0" align="center" width="100%">
                    
                    <tr>
                        <td>
                            <input id="txtCNIC" runat="server" placeholder="11111-1111111-1" maxlength="15" 
                                Backcolor="beige"
                                ForeColor="Gray"
                                BorderColor="cornflowerblue"
                                BorderWidth="1"
                                Width="225px" 
                                Height="15px" 
                                minlength ="15"
                                Font-Bold="True" required />
                        </td>
                    </tr>
                    
                     <tr>
                        <td>
                            <input id="txtphone" placeholder="03XX-XXXXXXX" CssClass="upper-case" 
                                runat="server"
                                Backcolor="beige"
                                ForeColor="Gray"
                                BorderColor="cornflowerblue"
                                BorderWidth="1"
                                Width="225px" 
                                Height="15px" 
                                minlength ="11"
                                Font-Bold="True" MaxLength="11" />
                        </td>
                    </tr>
                    
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
                                Width="225px" 
                                Height="15px" 
                                Font-Bold="True" MaxLength="11" />
                        </td>
                    </tr>
                     <tr>
                         <td>
                                <asp:Button ID="btnsearch" OnClick = "btnsearch_Click" Style="width: 120px;" CssClass="button" runat="server" Text="Preview" />
                                <asp:Button ID="btnPrint" OnClick = "btnins_Click" Style="width: 100px;" OnClientClick ="Print()" CssClass="button" runat="server" Text="Print" />
                                
                         </td>
                    </tr>
                     <tr>
                         <td>
                                
                         </td>
                     </tr>
                </table>
            </div>
            </div>


     <div id="dvReport" align="center">
            <CR:CrystalReportViewer ID="GPreportdatewise" 
                runat="server" 
                AutoDataBind="true" 
                EnableDatabaseLogonPrompt="False" 
                EnableParameterPrompt="False" />
    </div>
     </ContentTemplate>
           <Triggers>
                 <asp:PostBackTrigger ControlID = "btnsearch"/>
                 <asp:PostBackTrigger ControlID = "GPreportdatewise"/>
           </Triggers>
    </asp:UpdatePanel>          
</asp:Content>

