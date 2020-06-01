Imports System.Data.SqlClient
Imports System.Data

Partial Class signin
    Inherits System.Web.UI.Page
    Dim exError As String

    Protected Sub btnsign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsign.Click
        If txtusername.Text = "" Then
            labelerror.Visible = True
            labelerror.ForeColor = Drawing.Color.Red
            labelerror.Text = "please fill username"
            txtusername.Focus()
            Exit Sub
        End If

        If txtpassword.Text = "" Then
            labelerror.Visible = True
            labelerror.ForeColor = Drawing.Color.Red
            labelerror.Text = "please fill password"
            txtpassword.Focus()
            Exit Sub
        End If

        userlogin()
      End Sub
    Private Sub userlogin()
        Dim con As SqlConnection = connection.GetConnect
        Dim cmd As New SqlCommand
        Dim DR As SqlDataReader
        Try
            cmd.CommandText = "select * from Users where username = @username and password = @password and IsActive = 1"
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@username", txtusername.Text.Trim())
            cmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim())
            con.Open()
            DR = cmd.ExecuteReader()
            If DR.HasRows Then
                DR.Read()
                Session("usertypes") = DR("usertypes").ToString
                Session("user") = DR("username").ToString
                Session("role") = DR("usertypes").ToString

                If Session("role") = "Billing Counter Operator" Then
                    Response.Redirect("DataEntry.aspx")

                ElseIf Session("role") = "Admin" Then
                    Response.Redirect("AdminDashboard.aspx")

                ElseIf Session("role") = "Data Entry" Then
                    Response.Redirect("Default.aspx")
                End If

            Else
                labelerror.Visible = True
                labelerror.ForeColor = Drawing.Color.Red
                labelerror.Text = "Incorrect username/password"
                txtpassword.Focus()
            End If
            DR.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtusername.Text = String.Empty
            txtpassword.Text = String.Empty
            Response.Cookies(txtusername.Text).Expires = DateTime.Now.AddDays(-1)
            Response.Cookies.Remove(txtpassword.Text)
            txtusername.Focus()
        End If
    End Sub
End Class
