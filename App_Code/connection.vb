Imports System.Data
Imports System.Data.SqlClient

Public Class connection
    Public Shared Function GetConnect() As SqlConnection
        Dim connectionstring As String
        connectionstring = ConfigurationManager.ConnectionStrings("WASA").ConnectionString
        Dim sqlcon As New SqlConnection(connectionstring)
        Return sqlcon
    End Function
   
End Class
