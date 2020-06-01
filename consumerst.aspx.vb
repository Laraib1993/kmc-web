Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class consumerst
    Inherits System.Web.UI.Page
    Dim rpt As ReportDocument = New ReportDocument
    Dim exError As String
    Dim crit As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("usertypes") = Nothing Then
            Response.Redirect("signin.aspx")
        End If

        If Not IsPostBack Then
            txtconsumerno.Focus()
        End If

    End Sub
	 Private Sub consumerstatment_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
        GC.Collect()
    End Sub
	Private Sub BindReport()
        Try
            consumerstatment.DisplayToolbar = true
            consumerstatment.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            consumerstatment.Zoom(100)
            consumerstatment.HasExportButton = true
            consumerstatment.HasPrintButton = False
            consumerstatment.HasToggleGroupTreeButton = False
            consumerstatment.HasToggleParameterPanelButton = False
            consumerstatment.HasZoomFactorList = False
            consumerstatment.HasCrystalLogo = False
            consumerstatment.Font.Size = 8
            consumerstatment.GroupTreeStyle.Font.Size = 8
            consumerstatment.GroupTreeStyle.ShowLines = False
            consumerstatment.ToolbarStyle.Width = Unit.Parse("2046px")
            rpt.Load(Server.MapPath("~/reports/consumer_st.rpt"))
            Dim conInfo As New ConnectionInfo
            With conInfo
                .ServerName = "WIN-CFJNVMD2S5P"
                .DatabaseName = "kmc"
                .UserID = "sa"
                .Password = "Sprint@5555"
            End With

            For Each MyTable As Table In rpt.Database.Tables
                Dim MyTableLogonInfo As TableLogOnInfo = MyTable.LogOnInfo
                MyTableLogonInfo.ConnectionInfo = conInfo
                MyTable.ApplyLogOnInfo(MyTableLogonInfo)
            Next

            rpt.ReadRecords()
            consumerstatment.ReportSource = rpt
            rpt.RecordSelectionFormula = "{invoice.consumer_no} = '" & txtconsumerno.Text.ToString & "'"
           
            consumerstatment.RefreshReport()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
	
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtconsumerno.Text <> "" Then
            BindReport()
        End If

    End Sub

End Class
