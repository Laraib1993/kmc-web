Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data


Partial Class rebate
    Inherits System.Web.UI.Page
    Dim rpt As ReportDocument = New ReportDocument
   Dim con As SqlConnection = connection.GetConnect
    Dim exError As String
    Dim crit As String
    Dim se As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        se = Convert.ToString((Session("user")))

        If Session("usertypes") = Nothing Then
            Response.Redirect("signin.aspx")
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
            rpt.Load(Server.MapPath("~/reports/cateory_wise.rpt"))
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
             
           
            GPreportdatewise.RefreshReport()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
	
	Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            BindReport()
       
    End Sub
   

End Class
