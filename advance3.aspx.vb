Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data


Partial Class advance3
    Inherits System.Web.UI.Page
    Dim rpt As ReportDocument = New ReportDocument
    Dim con As SqlConnection = connection.GetConnect
    Dim exError As String
    Dim crit As String
    Dim se As String

    Public Shared Function listEmplMUCT() As List(Of ListItem)
        Dim conn As SqlConnection = New SqlConnection()
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("WASA").ConnectionString

        Using cmd As SqlCommand = New SqlCommand("sp_empMUCT", conn)
            Dim div As List(Of ListItem) = New List(Of ListItem)()
            cmd.CommandType = CommandType.StoredProcedure
            conn.Open()

            Using sdr As SqlDataReader = cmd.ExecuteReader()

                While sdr.Read()
                    div.Add(New ListItem With {
                    .Value = sdr(2).ToString() + " " + sdr(1).ToString(),
                    .Text = sdr(1).ToString()
                })
                End While
            End Using

            Return div
        End Using
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        se = Convert.ToString((Session("user")))

        If Session("usertypes") = Nothing Then
            Response.Redirect("signin.aspx")
        End If

        If Not IsPostBack Then
            ddlemployee.DataSource = listEmplMUCT()
            ddlemployee.DataTextField = "Text"
            ddlemployee.DataValueField = "Value"
            ddlemployee.DataBind()
            ddlemployee.Items.Insert(0, "")
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
            rpt.Load(Server.MapPath("~/reports/advancebill3.rpt"))
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
            rpt.RecordSelectionFormula = "{invoice.consumer_no} = '" & txtconsumerno.Text.ToString & "' and {invoice.status} = 1"
           
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

        Dim cmd2 As SqlCommand
        Dim ra1 As Integer

        Dim cmd3 As SqlCommand
        Dim ra2 As Integer

        Try
            con.Open()
            cmd1 = New SqlCommand("insert into duplicatebill_history  (Consumer_No,Category,zone, bill_type,createdby, createdon,issuedate,duedate,EmployeeMUCT,Description) SELECT  consumer_no, category,zone,'2 Quater Advance Bill (Employee MUCT)', '" & se & "', GETDATE(),GETDATE(),dateadd(day, 10, (CONVERT(VARCHAR(10), getdate(), 111))),'" + ddlemployee.Value + "','" + txtdescription.Value + "' FROM invoice WHERE  consumer_no = '" & txtconsumerno.Text & "'", con)
            ra = cmd1.ExecuteNonQuery()


            con.Open()
            cmd2 = New SqlCommand("update invoice set status = 7 where consumer_no = '" + txtconsumerno.Text + "'", con)
            ra1 = cmd2.ExecuteNonQuery()
            con.Close()

            con.Open()
            cmd3 = New SqlCommand("insert MUCTBill_Records(ConsumerNo,Zone,Town,Employee,Createdon,createdby) SELECT  consumer_no, zone,town,'" + ddlemployee.Value + "', GETDATE(),'createdby' FROM invoice WHERE  consumer_no = '" & txtconsumerno.Text & "'", con)
            ra2 = cmd3.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception

        End Try
    End Sub

End Class
