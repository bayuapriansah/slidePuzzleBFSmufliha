Imports System.Data.OleDb
Module koneksiPuzzle
    Public CONN As OleDbConnection
    Public DA As OleDbDataAdapter
    Public DS As DataSet
    Public CMD As OleDbCommand
    Public DR As OleDbDataReader
    Public LokasiDB As String
    Public idNama As Double
    Public idAcak As Integer

    Sub koneksi()
        LokasiDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dataPuzzle.accdb"
        CONN = New OleDbConnection(LokasiDB)
        If CONN.State = ConnectionState.Closed Then CONN.Open()
    End Sub

    Sub acak()
        Randomize()
        idAcak = 9999
        idNama = Math.Ceiling(Rnd() * idAcak)
    End Sub
End Module
