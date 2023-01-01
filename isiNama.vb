Public Class isiNama
    Private Sub isiNama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Welcome.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        Call acak()
        Dim simpan As String
        simpan = "insert into dataPuzzle values('" & idNama & "','" & TextBox1.Text & "','0','0','0')"
        CMD = New OleDb.OleDbCommand(simpan, CONN)
        CMD.ExecuteNonQuery()
        TingkatLevel.Show()
        Me.Close()
    End Sub
End Class