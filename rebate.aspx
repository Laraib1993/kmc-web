<%@ Page Title="" Language="VB" MasterPageFile="~/webinventory.master" AutoEventWireup="false" CodeFile="rebate.aspx.vb" Inherits="rebate" %>

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
                        
                    </tr>
                     <tr>
                         <td>
                               <asp:Button ID="btnsearch" OnClick = "btnsearch_Click" Style="width: 120px;" CssClass="button" runat="server" Text="Preview" />
                                <asp:Button ID="btnPrint" Style="width: 100px;" OnClientClick ="Print()" CssClass="button" runat="server" Text="Print" />
                                
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

