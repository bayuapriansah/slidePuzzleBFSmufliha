Imports System.Data.OleDb
Public Class FormKonfigurasi
    Dim myconnection As New koneksidata
    Dim mycmd As New OleDbCommand
    Dim objadapter As OleDbDataAdapter
    Dim objreader As OleDbDataReader
    Dim dtable As New DataTable
#Region "konfigurasi"
    Dim a As New OpenFileDialog
    Sub bukadialogfoto()
        Dim PictureLocation As String
        a.Filter = "Gambar (*.jpg,*.jpeg,*.png,*.bmp,*.gif,*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff"
        PictureLocation = a.FileName
        Try
            If a.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image = New Bitmap(a.FileName)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Sub simpanfoto()
        Try
            myconnection.close()
            Using sql As New OleDbCommand("insert into tbsoni values('" & CLEVEL.Text & "',@gambar)", myconnection.open)
                If a.FileName = Nothing Then
                    'sql.Parameters.Add(New OleDbParameter("@FOTO", OleDbType.Binary)).Value = IO.File.ReadAllBytes("kosong.jpg")
                    MsgBox("Anda belum memilih gambar !!", MsgBoxStyle.Information, "Pemberitahuan !!")
                Else
                    sql.Parameters.Add(New OleDbParameter("@gambar", OleDbType.Binary)).Value = IO.File.ReadAllBytes(a.FileName)
                    MsgBox("Gambar level:  '" & CLEVEL.Text & "'  berhasil disimpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")
                End If
                sql.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconnection.close()
    End Sub
    Sub ubahfoto()
        Try
            myconnection.close()
            Using sql As New OleDbCommand("update tbsoni set gambar=@gambar where level='" & CLEVEL.Text & "'", myconnection.open)
                If a.FileName = Nothing Then
                    'sql.Parameters.Add(New OleDbParameter("@FOTO", OleDbType.Binary)).Value = IO.File.ReadAllBytes("kosong.jpg")
                    MsgBox("Anda belum memilih gambar !!", MsgBoxStyle.Information, "Pemberitahuan !!")
                Else
                    sql.Parameters.Add(New OleDbParameter("@gambar", OleDbType.Binary)).Value = IO.File.ReadAllBytes(a.FileName)
                    MsgBox("Gambar level:  '" & CLEVEL.Text & "'  berhasil dirubah !!", MsgBoxStyle.Information, "Pemberitahuan !!")
                End If
                sql.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconnection.close()
    End Sub
#End Region
    Private Sub BTSIMPAN_Click(sender As Object, e As EventArgs) Handles BTSIMPAN.Click
        Try
            Using sql As New OleDbCommand("select gambar from tbsoni where level = '" & Replace(CLEVEL.Text, "'", "''") & "'", myconnection.open)
                Using dr As OleDbDataReader = sql.ExecuteReader()
                    Using dt As New DataTable
                        dt.Load(dr)
                        If CLEVEL.Text = "" Then
                            MsgBox("Anda belum memilih level !!", MsgBoxStyle.Exclamation, "Pemberitahuan !!")
                        ElseIf dt.Rows.Count <> 1 Then
                            simpanfoto()
                        Else
                            ubahfoto()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconnection.close()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        bukadialogfoto()
    End Sub
    Private Sub CLEVEL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CLEVEL.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub BTRESETLEVEL_Click(sender As Object, e As EventArgs) Handles BTRESETLEVEL.Click
        My.Settings.SLEVEL = 1
        My.Settings.Save()
    End Sub
    Private Sub CLEVEL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CLEVEL.SelectedIndexChanged
        Try
            Using sql As New OleDbCommand("select gambar from tbsoni where level='" & Replace(CLEVEL.Text, "'", "''") & "'", myconnection.open)
                Using dr As OleDbDataReader = sql.ExecuteReader()
                    Using dt As New DataTable
                        dt.Load(dr)
                        If dt.Rows.Count <> 1 Then
                            PictureBox1.Image = Nothing
                        Else
                            Dim rowsoni As DataRow = dt.Rows(0)
                            Using ms As New IO.MemoryStream(CType(rowsoni(0), Byte()))
                                'Dim Pic As Image = Image.FromFile(openFile.FileName)
                                Dim Pic As Image = Image.FromStream(ms)
                                PictureBox1.Image = New Bitmap(Pic)
                                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                            End Using
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconnection.close()
    End Sub

    Private Sub FormKonfigurasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class