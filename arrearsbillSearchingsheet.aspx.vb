Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data


Partial Class arrearsbill
    Inherits System.Web.UI.Page
    Dim rpt As ReportDocument = New ReportDocument
	Dim con As SqlConnection = connection.GetConnect
    Dim exError As String
    Dim crit As String
	Dim se as String 
	
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		se = Convert.ToString((Session("user")))
		
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
        Try
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
            rpt.Load(Server.MapPath("~/reports/arrears_onlySearchingSheet.rpt"))
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
            GPreportdatewise.ReportSource = rpt
            rpt.RecordSelectionFormula = "{invoice.consumer_no} = '" & txtconsumerno.Text.ToString & "' and {invoice.status} = 6"
            GPreportdatewise.RefreshReport()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtconsumerno.Text <> "" Then
            BindReport()
        End If
    End Sub
	
	 Protected Sub btnins_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cmd1 As SqlCommand
        Dim ra As Integer

        Try
            con.Open()
            cmd1 = New SqlCommand("insert into duplicatebill_history  (Consumer_No,Category,zone, bill_type,createdby, createdon) SELECT  consumer_no, category,zone,'Arrears Only Bill (Searching Sheet)', '" & se & "', GETDATE()FROM invoice WHERE  consumer_no = '" & txtconsumerno.Text & "'", con)
            ra = cmd1.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

End Class
