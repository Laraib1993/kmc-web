Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Partial Class webinventory
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not Page.IsPostBack Then
            If Session("usertypes") = "" Then
                Response.Redirect("signin.aspx")
            Else
                lblLoggedinAs.ForeColor = Drawing.Color.LightGoldenrodYellow
                lblLoggedinAs.Font.Bold = True
                lblLoggedinAs.Font.Size = "12"
                Dim stype As String = "Data Entry Operator"
                lblLoggedinAs.Text = "MUCT KMC BILLING SYSTEM " & Convert.ToString((Session("user"))).ToUpper & " AS " & stype.ToUpper & ""
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
