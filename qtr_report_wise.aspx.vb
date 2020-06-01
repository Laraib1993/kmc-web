Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class qtr_report_wise
    Inherits System.Web.UI.Page
    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click

        Dim txtTodayFromdate As Date = Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy")
        Dim txtTodayTodate As Date = Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy")

        Dim Fromtodaydate As Date = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy")
        Dim Totodaydate As Date = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy")

        If txtTodayFromdate > Fromtodaydate Then
            lblmsg.Visible = True
            lblmsg.ForeColor = Drawing.Color.Red
            lblmsg.Text = "From Date is not greater than current date"
            Exit Sub
        End If

        If txtTodayTodate > Totodaydate Then
            lblmsg.Visible = True
            lblmsg.ForeColor = Drawing.Color.Red
            lblmsg.Text = "To Date is not greater than current date"
            Exit Sub
        End If

        If txtfromdate.Text <> "" And txttodate.Text <> "" Then
            lblmsg.Text = ""
            lblmsg.Visible = False
            Response.Redirect(("qtr_collection.aspx?fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text))
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("usertypes") = Nothing Then
            Response.Redirect("signin.aspx")
        End If


        If Not IsPostBack Then
            txtfromdate.Text = Date.Today
            txttodate.Text = Date.Today
        End If

    End Sub
End Class
