Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class uc_wise_collection
    Inherits System.Web.UI.Page
    Dim rpt As ReportDocument = New ReportDocument
    Dim exError As String
    Dim crit As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("usertypes") = Nothing Then
            Response.Redirect("signin.aspx")
        End If

        
        BindReport()
       
      

    End Sub

    Sub BindReport()
        Try
        dailyreport.DisplayToolbar = True
        dailyreport.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        dailyreport.Zoom(100)
        dailyreport.HasExportButton = True
        dailyreport.HasPrintButton = True
        dailyreport.HasToggleGroupTreeButton = False
        dailyreport.HasToggleParameterPanelButton = False
        dailyreport.HasZoomFactorList = False
        dailyreport.HasCrystalLogo = False
        dailyreport.Font.Size = 8
        dailyreport.GroupTreeStyle.Font.Size = 8
        dailyreport.GroupTreeStyle.ShowLines = False
        dailyreport.ToolbarStyle.Width = Unit.Parse("2046px")
        dailyreport.SeparatePages = true
        rpt.Load(Server.MapPath("~/reports/quater_payment_uc_wise.rpt"))
        Dim conInfo As New ConnectionInfo
        With conInfo
                .ServerName = "WIN-H4F4JGGN50A"
                .DatabaseName = "kmc"
                .UserID = "sa"
                .Password = "Sprint@5555"
            End With


        crit = "{posting_voucher_qtr.Payment_Date}>=#" & Format(CDate(Request.QueryString("fromdate")), "MM/dd/yyyy") & "#"
        crit = crit & " and {posting_voucher_qtr.Payment_Date} <=#" & Format(CDate(Request.QueryString("todate")), "MM/dd/yyyy") & "#"

        rpt.RecordSelectionFormula = crit
        rpt.DataDefinition.FormulaFields("msgfromdate").Text = ("'" + (Request.QueryString("fromdate") + "'"))
        rpt.DataDefinition.FormulaFields("msgtodate").Text = ("'" + (Request.QueryString("todate") + "'"))

        For Each MyTable As Table In rpt.Database.Tables
            Dim MyTableLogonInfo As TableLogOnInfo = MyTable.LogOnInfo
            MyTableLogonInfo.ConnectionInfo = conInfo
            MyTable.ApplyLogOnInfo(MyTableLogonInfo)
        Next


        rpt.ReadRecords()
        dailyreport.ReportSource = rpt
        dailyreport.RefreshReport()


        Catch ex As Exception
        exError = ex.Message
        End Try
    End Sub


End Class
