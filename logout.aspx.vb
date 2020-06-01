
Partial Class logout
    Inherits System.Web.UI.Page
    Dim exError As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session.Clear()
            Session.Abandon()
            Response.Redirect("signin.aspx")
        Catch ex As Exception
            exError = ex.Message
        End Try
    End Sub
End Class
