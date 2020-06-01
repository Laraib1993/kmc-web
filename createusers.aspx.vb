Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient

Partial Class createusers
    Inherits System.Web.UI.Page
    Dim exError As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("usertypes") <> "Administrator" Then
            Response.Redirect("signin.aspx")
        End If

    End Sub
    Sub CommandBtn_Click(ByVal sender As Object, ByVal e As CommandEventArgs)
        If e.CommandName = "cmdEdit" Then
            Dim btn As ImageButton = DirectCast(sender, ImageButton)
            Dim commandArgs As String() = e.CommandArgument.ToString().Split(";")
            lbluserid.Text = commandArgs(0)
            txtupdateusername.Text = commandArgs(1)
            txtupdatepassword.Text = commandArgs(2)
            ModalPopupExtender1.Show()
            System.Web.UI.ScriptManager.GetCurrent(Me.Page).SetFocus(txtupdatepassword)
        End If
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        UpdateRecord(lbluserid.Text, txtupdateusername.Text, txtupdatepassword.Text)
    End Sub

    Sub SaveRecord()
        Dim con As SqlConnection = connection.GetConnect
        Dim cmd As New SqlCommand

        Dim sql As String = "insert into Users(username,password,usertypes,IsActive) values (@username,@password,@usertypes,@IsActive)"
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@username", txtusername.Text)
        cmd.Parameters.AddWithValue("@password", txtpassword.Text)
        cmd.Parameters.AddWithValue("@usertypes", ddtypes.SelectedValue)
        cmd.Parameters.AddWithValue("@IsActive", "True")
        Try
            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()
            gvUsers.DataBind()
            clrcontrols()
        Catch ex As SqlException
            If (ex.Number <> 1205) Then
                lblmsg.Visible = True
                lblmsg.ForeColor = Drawing.Color.Red
                lblmsg.Text = "username already exist"
            End If
        Finally
            cmd.Dispose()
            con.Close()
        End Try
    End Sub
    Private Sub UpdateRecord(ByVal id As Integer, ByVal username As String, ByVal password As String)
        Dim con As SqlConnection = connection.GetConnect
        Dim sqlStatement As String = "update users set username = @username,password = @password where id = @id"
        Try
            con.Open()
            Dim cmd As New SqlCommand(sqlStatement, con)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            gvUsers.DataBind()
            clrcontrols()
            Me.ModalPopupExtender1.Hide()
        Catch ex As System.Data.SqlClient.SqlException
            Dim msg As String = "Insert/Update Error:"
            msg += ex.Message
            Throw New Exception(msg)
        Finally
            con.Close()
        End Try
    End Sub
    Protected Sub ddtypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddtypes.SelectedIndexChanged
        ddtypes.Focus()
    End Sub

    Private Sub clrcontrols()
        ddtypes.SelectedValue = ""
        txtusername.Text = ""
        txtpassword.Text = ""
        lbluserid.Text = ""
        txtupdateusername.Text = ""
        txtupdatepassword.Text = ""
        lblmsg.Text = ""
        lblmsg.Visible = False
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As CommandEventArgs)
        SaveRecord()
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As CommandEventArgs)
        clrcontrols()
    End Sub

    Protected Sub OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.background='#A1DCF2';"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';this.style.background='#FFFFFF';"
        End If
    End Sub

End Class
