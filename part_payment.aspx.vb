Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class part_payment
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
    Private Sub GPreportdatewise_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
        GC.Collect()
    End Sub
    Private Sub BindReport()
        'Try
            GPreportdatewise.DisplayToolbar = False
            GPreportdatewise.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            GPreportdatewise.Zoom(100)
            GPreportdatewise.HasExportButton = False
            GPreportdatewise.HasPrintButton = False
            GPreportdatewise.HasToggleGroupTreeButton = False
            GPreportdatewise.HasToggleParameterPanelButton = False
            GPreportdatewise.HasZoomFactorList = False
            GPreportdatewise.HasCrystalLogo = False
            GPreportdatewise.Font.Size = 8
            GPreportdatewise.GroupTreeStyle.Font.Size = 8
            GPreportdatewise.GroupTreeStyle.ShowLines = False
            GPreportdatewise.ToolbarStyle.Width = Unit.Parse("2046px")
            rpt.Load(Server.MapPath("~/reports/part_payment.rpt"))
            Dim conInfo As New ConnectionInfo
            With conInfo
            .ServerName = "WIN-H4F4JGGN50A"
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
            GPreportdatewise.ReportSource = rpt
            rpt.RecordSelectionFormula = "{invoice.consumer_no} = '" & txtconsumerno.Text.ToString & "' and {invoice.status} = 1"
            GPreportdatewise.RefreshReport()
        'Catch ex As Exception
            'Response.Write(ex.Message)
        'End Try
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtconsumerno.Text <> "" Then
            BindReport()
        End If
    End Sub

End Class
