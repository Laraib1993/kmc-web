Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class qtr_collection
    Inherits System.Web.UI.Page
    Dim rpt As ReportDocument = New ReportDocument
    Dim exError As String
    Dim crit As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("usertypes") = Nothing Then
            Response.Redirect("signin.aspx")
        End If

        'If Not IsPostBack Then
        BindReport()
        'report()
        'End If

    End Sub

    Sub BindReport()
        'Try
        quarter.DisplayToolbar = True
        quarter.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        quarter.Zoom(100)
        quarter.HasExportButton = True
        quarter.HasPrintButton = True
        quarter.HasToggleGroupTreeButton = False
        quarter.HasToggleParameterPanelButton = False
        quarter.HasZoomFactorList = False
        quarter.HasCrystalLogo = False
        quarter.Font.Size = 8
        quarter.GroupTreeStyle.Font.Size = 8
        quarter.GroupTreeStyle.ShowLines = False
        quarter.ToolbarStyle.Width = Unit.Parse("2046px")
        quarter.SeparatePages = False
        rpt.Load(Server.MapPath("~/reports/quarter_wise.rpt"))
        Dim conInfo As New ConnectionInfo
        With conInfo
            .ServerName = "WIN-H4F4JGGN50A"
            .DatabaseName = "kmc"
            .UserID = "sa"
            .Password = "Sprint@5555"
        End With

        crit = "{payment_history_Main.Payment_Date}>=#" & Format(CDate(Request.QueryString("fromdate")), "MM/dd/yyyy") & "#"
        crit = crit & " and {payment_history_Main.Payment_Date} <=#" & Format(CDate(Request.QueryString("todate")), "MM/dd/yyyy") & "#"

        rpt.RecordSelectionFormula = crit
        rpt.DataDefinition.FormulaFields("msgfromdate").Text = ("'" + (Request.QueryString("fromdate") + "'"))
        rpt.DataDefinition.FormulaFields("msgtodate").Text = ("'" + (Request.QueryString("todate") + "'"))

        For Each MyTable As Table In rpt.Database.Tables
            Dim MyTableLogonInfo As TableLogOnInfo = MyTable.LogOnInfo
            MyTableLogonInfo.ConnectionInfo = conInfo
            MyTable.ApplyLogOnInfo(MyTableLogonInfo)
        Next


        rpt.ReadRecords()
        quarter.ReportSource = rpt
        quarter.RefreshReport()


        'Catch ex As Exception
        'exError = ex.Message
        'End Try
    End Sub


End Class
