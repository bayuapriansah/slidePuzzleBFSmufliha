Imports System.Data.OleDb
Public Class pilihPlanet
    Dim myconnection As New koneksidata
    Dim mycmd As New OleDbCommand
    Dim objadapter As OleDbDataAdapter
    Dim objreader As OleDbDataReader
    Dim dtable As New DataTable

    Private Sub pilihPlanet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using sql As New OleDbCommand("select gambar from tbsoni", myconnection.open)
                Using dr As OleDbDataReader = sql.ExecuteReader()
                    Using dt As New DataTable
                        dt.Load(dr)
                        Dim rowsoni As DataRow = dt.Rows(0)
                        Dim rowsoni1 As DataRow = dt.Rows(1)
                        Dim rowsoni2 As DataRow = dt.Rows(2)
                        Dim rowsoni3 As DataRow = dt.Rows(3)
                        Dim rowsoni4 As DataRow = dt.Rows(4)
                        Dim rowsoni5 As DataRow = dt.Rows(5)
                        Dim rowsoni6 As DataRow = dt.Rows(6)
                        Dim rowsoni7 As DataRow = dt.Rows(7)
                        Using ms As New IO.MemoryStream(CType(rowsoni(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox1.Image = New Bitmap(Pic)
                            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                        Using ms As New IO.MemoryStream(CType(rowsoni1(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox2.Image = New Bitmap(Pic)
                            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                        Using ms As New IO.MemoryStream(CType(rowsoni2(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox3.Image = New Bitmap(Pic)
                            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                        Using ms As New IO.MemoryStream(CType(rowsoni3(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox4.Image = New Bitmap(Pic)
                            PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                        Using ms As New IO.MemoryStream(CType(rowsoni4(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox5.Image = New Bitmap(Pic)
                            PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                        Using ms As New IO.MemoryStream(CType(rowsoni5(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox6.Image = New Bitmap(Pic)
                            PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                        Using ms As New IO.MemoryStream(CType(rowsoni6(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox7.Image = New Bitmap(Pic)
                            PictureBox7.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                        Using ms As New IO.MemoryStream(CType(rowsoni7(0), Byte()))
                            Dim Pic As Image = Image.FromStream(ms)
                            PictureBox8.Image = New Bitmap(Pic)
                            PictureBox8.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconnection.close()
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Welcome.Show()
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Welcome.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Settings.SLEVEL = 1
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        My.Settings.SLEVEL = 2
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        My.Settings.SLEVEL = 3
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        My.Settings.SLEVEL = 4
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        My.Settings.SLEVEL = 5
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        My.Settings.SLEVEL = 6
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        My.Settings.SLEVEL = 7
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        My.Settings.SLEVEL = 8
        My.Settings.Save()
        FormInformasiPlanet.Show()
        Me.Close()
    End Sub
End Class