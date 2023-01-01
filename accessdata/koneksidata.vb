Imports System.Data.OleDb
Public Class koneksidata
    Dim conect As New OleDbConnection("provider = Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath.ToString & "\soni.mdb")
    Public Function open() As OleDbConnection
        Try
            conect.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return conect
    End Function
    Public Function close() As OleDbConnection
        Try
            conect.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return conect
    End Function
End Class
