Imports System.Data.SqlClient
Imports System.Data

Partial Class signin
    Inherits System.Web.UI.Page
    Dim exError As String

    Protected Sub btnsign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsign.Click

        If txtusername.Text = "" Then
            labelerror.Visible = True
            labelerror.ForeColor = Drawing.Color.Red
            labelerror.Text = "please fill username field"
            Exit Sub
        End If

        If txtoldpassword.Text = "" Then
            labelerror.Visible = True
            labelerror.ForeColor = Drawing.Color.Red
            labelerror.Text = "please fill old password field"
            Exit Sub
        End If

        If txtnewpassword.Text = "" Then
            labelerror.Visible = True
            labelerror.ForeColor = Drawing.Color.Red
            labelerror.Text = "please fill new password field"
            Exit Sub
        End If



        Dim con As SqlConnection = connection.GetConnect
        Dim comm As New SqlCommand
        Dim DR As SqlDataReader
        Try
            comm.CommandText = "select * from Users where IsActive = 'True' and username ='" & txtusername.Text & "' and password = '" & txtoldpassword.Text & "'"
            comm.CommandType = CommandType.Text
            comm.Connection = con
            con.Open()

            DR = comm.ExecuteReader()

            If DR.HasRows Then
                changepassword(txtusername.Text, txtnewpassword.Text)
                txtusername.Text = String.Empty
                txtoldpassword.Text = String.Empty
                txtnewpassword.Text = String.Empty
                Session.Clear()
                Session.Abandon()
                Response.Redirect("signin.aspx")
            Else
                labelerror.Visible = True
                labelerror.ForeColor = Drawing.Color.Red
                labelerror.Text = "Incorrect username/password"
            End If

            DR.Close()
        Catch ex As Exception
            exError = ex.Message
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub changepassword(ByVal username As String, ByVal password As String)
        Dim con As SqlConnection = connection.GetConnect
        Dim sqlStatement As String = "update users set password = @password where username = @username"
        Try
            con.Open()
            Dim cmd As New SqlCommand(sqlStatement, con)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
        Catch ex As System.Data.SqlClient.SqlException
            Dim msg As String = "Insert/Update Error:"
            msg += ex.Message
            Throw New Exception(msg)
        Finally
            con.Close()
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtusername.Text = String.Empty
            txtoldpassword.Text = String.Empty
            txtnewpassword.Text = String.Empty
            txtusername.Focus()
        End If
    End Sub
End Class
