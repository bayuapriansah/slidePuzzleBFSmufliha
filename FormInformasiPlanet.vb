Imports System.Data.OleDb
Public Class FormInformasiPlanet
    Dim myconnection As New koneksidata
    Dim mycmd As New OleDbCommand
    Dim objadapter As OleDbDataAdapter
    Dim objreader As OleDbDataReader
    Dim dtable As New DataTable
    Private Sub FormInformasiPlanet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using sql As New OleDbCommand("select gambar,deskripsi,link from tbsoni where level='" & Replace(My.Settings.SLEVEL, "'", "''") & "'", myconnection.open)
                Using dr As OleDbDataReader = sql.ExecuteReader()
                    Using dt As New DataTable
                        dt.Load(dr)
                        If dt.Rows.Count <> 1 Then
                            PictureBox1.Image = Nothing
                        Else
                            Dim rowsoni As DataRow = dt.Rows(0)
                            Using ms As New IO.MemoryStream(CType(rowsoni(0), Byte()))
                                Dim Pic As Image = Image.FromStream(ms)
                                PictureBox1.Image = New Bitmap(Pic)
                                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                            End Using
                            RichTextBox1.Text = rowsoni(1)
                            TextBox1.Text = rowsoni(2)
                            Dim html As String = "<html><head>"
                            html &= "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>"
                            html &= "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='750' height='420' frameborder='0'></iframe>"
                            html &= "</body></html>"
                            Me.WebBrowser1.DocumentText = String.Format(html, TextBox1.Text.Split("=")(1))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconnection.close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Welcome.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        slidePuzzle.mnfrm.Show()
        Me.Close()
    End Sub
End Class