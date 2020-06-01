<%@ Page Title="" Language="VB" MasterPageFile="~/webinventory.master" AutoEventWireup="false" CodeFile="qtr_collection.aspx.vb" Inherits="qtr_collection" %>

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
     <input type="button" id="btnPrint" value="Print" onclick="Print()" />

    <div id="dvReport" align="center">
            <CR:CrystalReportViewer ID="quarter" 
                runat="server" 
                AutoDataBind="true" 
                EnableDatabaseLogonPrompt="False" 
                EnableParameterPrompt="False" HasRefreshButton="True" />
    </div>
</asp:Content>

