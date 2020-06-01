﻿Imports System.Data.SqlClient
Imports System.Data

Partial Class search
    Inherits System.Web.UI.Page
    Dim con As SqlConnection = connection.GetConnect
    Dim da As SqlDataAdapter
    Dim strSQL As String

    Dim exError As String

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Searchby()
    End Sub
    Sub Searchby()
        If txtconsumerno.Text <> "" Then
            strSQL = "select * from invoice where consumer_no = '" & txtconsumerno.Text & "'"
        End If

        If txtname.Text <> "" Then
            strSQL = "select * from invoice where consumer_name like '%" + txtname.Text + " %' AND town = '" & ddtown.SelectedValue & "'"
        End If

        If txtaddress.Text <> "" Then
            strSQL = "select * from invoice where consumer_address like '%" + txtaddress.Text + " %' AND town = '" & ddtown.SelectedValue & "'"
        End If

        da = New SqlDataAdapter(strSQL, con)
        con.Open()
        Dim ds As New DataSet()
        da.Fill(ds)
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            System.Threading.Thread.Sleep(100)
            gvSearch.DataSource = ds.Tables(0)
            gvSearch.DataBind()
            gvSearch.Visible = True
            If Not ds Is Nothing Then ds.Dispose()
            ds = Nothing
            If Not da Is Nothing Then da.Dispose()
            da = Nothing
            con.Close()
            con.Dispose()
            con = Nothing
        End If

    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        ClearControls()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("usertypes") = Nothing Then
            Response.Redirect("signin.aspx")
        End If

        If Not IsPostBack Then
            ClearControls()
        End If

    End Sub
    Private Sub ClearControls()
        gvSearch.DataSource = Nothing
        gvSearch.DataBind()
        gvSearch.Visible = False
        txtaddress.Text = Nothing
        txtconsumerno.Text = Nothing
        txtname.Text = Nothing
        ddtown.SelectedValue = Nothing
    End Sub
   


End Class

