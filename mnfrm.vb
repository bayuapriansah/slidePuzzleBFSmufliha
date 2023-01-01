Imports System.Data.OleDb
Namespace slidePuzzle
    Structure Block
        Public Row, Col As Integer
        Public Sub New(ByVal row As Integer, ByVal col As Integer)
            Me.Row = row
            Me.Col = col
        End Sub
    End Structure
    Public Class mnfrm
        Inherits System.Windows.Forms.Form
        Dim myconnection As New koneksidata
#Region "Kode Private"
        Const tSquare As Integer = 64
        Const tImageW As Integer = 62
        'Ukuran default
        Dim nRows As Integer = 3
        Dim nCols As Integer = 3
        Dim rand As Random
        Dim blankTile As Block
        Dim PictureLoaded As Boolean = True
        Dim jam, menit, detik, milidetik As Integer

        Dim timerCountdown As Integer
        Friend WithEvents tmplasttile As ctlTile
        Private tile(,) As ctlTile
        Friend WithEvents DariDataBase As MenuItem
        Friend WithEvents DariKomputer As MenuItem
        Friend WithEvents menuLoad As MenuItem
        Friend WithEvents menuShuffle As MenuItem
        Friend WithEvents menu3X3 As MenuItem
        Friend WithEvents menu4X4 As MenuItem
        Friend WithEvents menu6X6 As MenuItem
        Friend WithEvents menuSize As MenuItem
        Friend WithEvents MenuItem1 As MenuItem
        Friend WithEvents menuWhite As MenuItem
        Friend WithEvents menuBlue As MenuItem
        Friend WithEvents menuRed As MenuItem
        Friend WithEvents menuSilver As MenuItem
        Friend WithEvents mainMenu1 As MainMenu
        Friend WithEvents Konfigurasi As MenuItem
        Friend WithEvents MenuItem3 As MenuItem
        Friend WithEvents Timer1 As Timer
        Friend WithEvents RichTextBox1 As RichTextBox
        Friend WithEvents PictureBox1 As PictureBox
        Friend WithEvents Label1 As Label
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents Label2 As Label
        Friend WithEvents GroupBox2 As GroupBox
        Friend WithEvents GroupBox3 As GroupBox
        Friend WithEvents Button1 As Button
        Friend WithEvents Button2 As Button
        Friend WithEvents Button3 As Button
        Friend WithEvents Button4 As Button
        Friend WithEvents openFile As System.Windows.Forms.OpenFileDialog
#End Region

#Region "Kode WinFormnya"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private components As System.ComponentModel.IContainer
        Friend WithEvents tRandom As System.Windows.Forms.Timer
        Private WithEvents tilesPanel As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.tilesPanel = New System.Windows.Forms.Panel()
            Me.openFile = New System.Windows.Forms.OpenFileDialog()
            Me.tRandom = New System.Windows.Forms.Timer(Me.components)
            Me.DariDataBase = New System.Windows.Forms.MenuItem()
            Me.DariKomputer = New System.Windows.Forms.MenuItem()
            Me.menuLoad = New System.Windows.Forms.MenuItem()
            Me.Konfigurasi = New System.Windows.Forms.MenuItem()
            Me.menuShuffle = New System.Windows.Forms.MenuItem()
            Me.menu3X3 = New System.Windows.Forms.MenuItem()
            Me.menu4X4 = New System.Windows.Forms.MenuItem()
            Me.menu6X6 = New System.Windows.Forms.MenuItem()
            Me.menuSize = New System.Windows.Forms.MenuItem()
            Me.MenuItem1 = New System.Windows.Forms.MenuItem()
            Me.MenuItem3 = New System.Windows.Forms.MenuItem()
            Me.menuWhite = New System.Windows.Forms.MenuItem()
            Me.menuBlue = New System.Windows.Forms.MenuItem()
            Me.menuRed = New System.Windows.Forms.MenuItem()
            Me.menuSilver = New System.Windows.Forms.MenuItem()
            Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button4 = New System.Windows.Forms.Button()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'tilesPanel
            '
            'Me.tilesPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.None
            Me.tilesPanel.BackColor = System.Drawing.Color.White
            Me.tilesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tilesPanel.Location = New System.Drawing.Point(12, 12)
            Me.tilesPanel.Name = "tilesPanel"
            Me.tilesPanel.Size = New System.Drawing.Size(272, 224)
            Me.tilesPanel.TabIndex = 0
            '
            'tRandom
            '
            '
            'DariDataBase
            '
            Me.DariDataBase.Index = -1
            Me.DariDataBase.Text = ""
            '
            'DariKomputer
            '
            Me.DariKomputer.Index = -1
            Me.DariKomputer.Text = ""
            '
            'menuLoad
            '
            Me.menuLoad.Index = 0
            Me.menuLoad.Text = ""
            '
            'Konfigurasi
            '
            Me.Konfigurasi.Index = -1
            Me.Konfigurasi.Text = ""
            '
            'menuShuffle
            '
            Me.menuShuffle.Index = 1
            Me.menuShuffle.Text = ""
            '
            'menu3X3
            '
            Me.menu3X3.Index = -1
            Me.menu3X3.Text = ""
            '
            'menu4X4
            '
            Me.menu4X4.Index = -1
            Me.menu4X4.Text = ""
            '
            'menu6X6
            '
            Me.menu6X6.Index = -1
            Me.menu6X6.Text = ""
            '
            'menuSize
            '
            Me.menuSize.Index = 2
            Me.menuSize.Text = ""
            '
            'MenuItem1
            '
            Me.MenuItem1.Index = 3
            Me.MenuItem1.Text = ""
            '
            'MenuItem3
            '
            Me.MenuItem3.Index = -1
            Me.MenuItem3.Text = ""
            '
            'menuWhite
            '
            Me.menuWhite.Checked = True
            Me.menuWhite.DefaultItem = True
            Me.menuWhite.Index = -1
            Me.menuWhite.Text = "White"
            '
            'menuBlue
            '
            Me.menuBlue.Index = -1
            Me.menuBlue.Text = ""
            '
            'menuRed
            '
            Me.menuRed.Index = -1
            Me.menuRed.Text = ""
            '
            'menuSilver
            '
            Me.menuSilver.Index = -1
            Me.menuSilver.Text = ""
            '
            'mainMenu1
            '
            Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuLoad, Me.menuShuffle, Me.menuSize, Me.MenuItem1})
            '
            'Timer1
            '
            Me.Timer1.Interval = 10
            '
            'RichTextBox1
            '
            Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Menu
            Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
            Me.RichTextBox1.Location = New System.Drawing.Point(7, 20)
            Me.RichTextBox1.Name = "RichTextBox1"
            Me.RichTextBox1.Size = New System.Drawing.Size(264, 177)
            Me.RichTextBox1.TabIndex = 0
            Me.RichTextBox1.Text = "Di samping merupakan gambar dari planet dengan bentuk sempurna yang harus kalian " &
    "susun kembali ketika sudah selesai di acak"
            '
            'PictureBox1
            '
            Me.PictureBox1.Location = New System.Drawing.Point(277, 19)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(250, 194)
            Me.PictureBox1.TabIndex = 2
            Me.PictureBox1.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 200)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(129, 13)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Created by Mufliha Afiksih"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.PictureBox1)
            Me.GroupBox1.Controls.Add(Me.RichTextBox1)
            Me.GroupBox1.Location = New System.Drawing.Point(557, 13)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(533, 219)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Tab Informasi"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(125, 12)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(279, 55)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "00:00:00:00"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.Label2)
            Me.GroupBox2.Location = New System.Drawing.Point(557, 239)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(533, 75)
            Me.GroupBox2.TabIndex = 2
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Timer Waktu"
            '
            'GroupBox3
            '
            Me.GroupBox3.Location = New System.Drawing.Point(557, 321)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(533, 54)
            Me.GroupBox3.TabIndex = 3
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Hint"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(557, 382)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(533, 23)
            Me.Button1.TabIndex = 4
            Me.Button1.Text = "Hint"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(557, 411)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(533, 23)
            Me.Button2.TabIndex = 5
            Me.Button2.Text = "Mulai (Acak)"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(557, 440)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(533, 23)
            Me.Button3.TabIndex = 6
            Me.Button3.Text = "Kembali Ke Awal"
            Me.Button3.UseVisualStyleBackColor = True
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(557, 469)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(533, 23)
            Me.Button4.TabIndex = 7
            Me.Button4.Text = "Keluar"
            Me.Button4.UseVisualStyleBackColor = True
            '
            'mnfrm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1102, 501)
            Me.Controls.Add(Me.Button4)
            Me.Controls.Add(Me.Button3)
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.tilesPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Menu = Me.mainMenu1
            Me.Name = "mnfrm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Puzzle Game - Mufliha"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            'Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region "Muat Form"
        Private Sub mnfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Using sql As New OleDbCommand("select gambar from tbsoni where level='" & Replace(My.Settings.SLEVEL, "'", "''") & "'", myconnection.open)
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
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            myconnection.close()
            MakeTiles(nRows, nCols)
            menuSize.Enabled = False
            Timer1.Enabled = False
            muat_dari_db()
        End Sub
#End Region

#Region "Acak dengan Waktu"
        Protected Sub Randomize()
            rand = New Random()
            timerCountdown = 64 * nRows * nCols
            tRandom.Interval = 1
            tRandom.Enabled = True
        End Sub
        Private Sub TimerOnTick(ByVal obj As Object, ByVal ea As EventArgs) Handles tRandom.Tick
            Dim col As Integer = blankTile.Col
            Dim row As Integer = blankTile.Row

            Select Case (rand.Next(4))
                Case 0 : col += 1
                Case 1 : col -= 1
                Case 2 : row += 1
                Case 3 : row -= 1
            End Select

            If (col >= 0 And col < nCols And row >= 0 And row < nRows) Then
                MoveTile(col, row)
            End If

            timerCountdown = timerCountdown - 1
            If (timerCountdown = 0) Then
                tRandom.Stop()
            End If
        End Sub
#End Region

#Region "Pindahkan Tiles (int Col, Int Row)"
        Private Sub MoveTile(ByVal Col As Integer, ByVal Row As Integer)
            tile(Row, Col).Location = New Point(blankTile.Col * tSquare,
                       blankTile.Row * tSquare)

            tile(blankTile.Row, blankTile.Col) = tile(Row, Col)
            tile(Row, Col) = Nothing
            blankTile = New Block(Row, Col)
        End Sub
#End Region

#Region "Pindahkan Tiles (int Rows, int Cols)"
        Public Sub MakeTiles(ByVal Rows As Integer, ByVal Cols As Integer)
            Dim index As Integer = 0

            ReDim tile(Rows, Cols)
            tilesPanel.Size = New Size(tSquare * Rows + 4, tSquare * Cols + 4)
            tilesPanel.Location = New Point(4, 4)
            Me.ClientSize = New Size(tilesPanel.Size.Width + 6, tilesPanel.Size.Height + 6)

            Dim Row, Col As Integer
            For Row = 0 To Rows - 1
                For Col = 0 To Cols - 1
                    tile(Row, Col) = New ctlTile(tSquare, tSquare, index)
                    tile(Row, Col).Parent = Me.tilesPanel
                    tile(Row, Col).Location = New Point(Col * tSquare, Row * tSquare)
                    index += 1
                Next
            Next
        End Sub
#End Region

#Region "Keyboard dan Mouse"
        Private Sub mnfrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            ' Cek puzzle sudah diacak atau belum
            If ((menuShuffle.Enabled) Or (PictureLoaded = False)) Then Return

            ' Arrow Keys Left
            If (e.KeyCode = Keys.Left And blankTile.Col < nCols - 1) Then
                MoveTile(blankTile.Col + 1, blankTile.Row)

                ' Arrow Keys Right
            ElseIf (e.KeyCode = Keys.Right And blankTile.Col > 0) Then
                MoveTile(blankTile.Col - 1, blankTile.Row)

                ' Arrow Keys Up
            ElseIf (e.KeyCode = Keys.Up And blankTile.Row < nRows - 1) Then
                MoveTile(blankTile.Col, blankTile.Row + 1)

                ' Arrow Keys Down
            ElseIf (e.KeyCode = Keys.Down And blankTile.Row > 0) Then
                MoveTile(blankTile.Col, blankTile.Row - 1)

            End If

            e.Handled = True
            CheckFinish()     'Cek jika puzzle dipecahkan.
        End Sub

        Private Sub tilesPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tilesPanel.MouseDown
            ' Cek puzzle sudah diacak atau belum
            If ((menuShuffle.Enabled) Or (PictureLoaded = False)) Then Return

            Dim Col As Integer = e.X \ tSquare  'pembagi integer
            Dim Row As Integer = e.Y \ tSquare  'pembagi integer

            If (Col = blankTile.Col) Then
                If (Row < blankTile.Row) Then
                    Dim Row2 As Integer
                    For Row2 = blankTile.Row - 1 To Row Step -1
                        MoveTile(Col, Row2)
                    Next

                ElseIf (Row > blankTile.Row) Then
                    Dim Row2 As Integer
                    For Row2 = blankTile.Row + 1 To Row
                        MoveTile(Col, Row2)
                    Next
                End If

            ElseIf (Row = blankTile.Row) Then
                If (Col < blankTile.Col) Then
                    Dim Col2 As Integer
                    For Col2 = blankTile.Col - 1 To Col Step -1
                        MoveTile(Col2, Row)
                    Next

                ElseIf (Col > blankTile.Col) Then
                    Dim Col2 As Integer
                    For Col2 = blankTile.Col + 1 To Col
                        MoveTile(Col2, Row)
                    Next
                End If
            End If

            CheckFinish() 'Cek jika puzzle benar :)
        End Sub
#End Region

#Region "Kode jika susunan benar dan menang"
        Private Sub CheckFinish()
            Dim Finished As Boolean = True

            Dim index As Integer = 0
            Dim Row, Col As Integer

            For Row = 0 To nRows - 1
                For Col = 0 To nCols - 1
                    If ((index <> nRows * nCols) And Not (tile(Row, Col) Is Nothing)) Then
                        Finished = Finished And (tile(Row, Col).tIndex = index)
                    End If
                    index += 1
                    If Not (Finished) Then Return
                Next
            Next

            If (Finished) Then
                tile(nRows - 1, nCols - 1) = tmplasttile
                tile(nRows - 1, nCols - 1).Visible = True
                Dim result As Integer = MessageBox.Show("Sukses menyusun puzzle !!!, Lanjut level selanjutnya?", "Selamat :)", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    blankTile = New Block(nRows - 1, nCols - 1)
                    clearItems()
                    MakeTiles(nRows, nCols)
                ElseIf result = DialogResult.Yes Then
                    If My.Settings.SLEVEL <= 9 Then
                        My.Settings.SLEVEL += 1
                        My.Settings.Save()
                        MessageBox.Show("Level, '" & My.Settings.SLEVEL & "'", "[Konfirmasi]")
                        blankTile = New Block(nRows - 1, nCols - 1)
                        clearItems()
                        'Dim sonisitez As Integer = My.Settings.SLEVEL + 1
                        Dim sonisitez As Integer = My.Settings.SLEVEL
                        nRows = sonisitez
                        nCols = sonisitez
                        MakeTiles(nRows, nCols)
                        muat_dari_db()
                    Else
                        MsgBox("Anda sudah menyelesaikan seluruh level hehe :-D", MsgBoxStyle.Information, "Selamat :)")
                        blankTile = New Block(nRows - 1, nCols - 1)
                    End If

                End If
            End If
        End Sub
#End Region

#Region "Menunya"
        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            'menuShuffle.Enabled = False
            tmplasttile = tile(nRows - 1, nCols - 1)
            tmplasttile.Visible = False
            tile(nRows - 1, nCols - 1).Visible = False
            Randomize()
            Timer1.Enabled = True
        End Sub
        'Private Sub menuShuffle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuShuffle.Click
        '    menuShuffle.Enabled = False
        '    tmplasttile = tile(nRows - 1, nCols - 1)
        '    tmplasttile.Visible = False
        '    tile(nRows - 1, nCols - 1).Visible = False
        '    Randomize()
        'End Sub
#End Region

#Region "Ukuran Menu"
        Private Sub menu3X3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu3X3.Click
            If (menu3X3.Checked) Then Return
            clearItems()
            menu3X3.Checked = True
            nRows = 3
            nCols = 3
            MakeTiles(nRows, nCols)
        End Sub
        Private Sub menu4X4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu4X4.Click
            If (menu4X4.Checked) Then Return
            clearItems()
            menu4X4.Checked = True
            nRows = 4
            nCols = 4
            MakeTiles(nRows, nCols)
        End Sub

        Private Sub menu6X6_Click(sender As Object, e As EventArgs) Handles menu6X6.Click
            If (menu6X6.Checked) Then Return
            clearItems()
            menu6X6.Checked = True
            nRows = 6
            nCols = 6
            MakeTiles(nRows, nCols)
        End Sub

        Private Sub clearItems()
            menu3X3.Checked = False
            menu4X4.Checked = False
            menu6X6.Checked = False
            Dim Row, Col As Integer
            For Row = 0 To nRows - 1
                For Col = 0 To nCols - 1
                    Try
                        tile(Row, Col).Dispose()
                    Catch
                        '
                    End Try
                Next
            Next
            menuShuffle.Enabled = False
            PictureLoaded = False
        End Sub

#End Region

        Private Sub DariKomputer_Click(sender As Object, e As EventArgs) Handles DariKomputer.Click
            openFile.FileName = ""
            openFile.Filter = "Gambar (*.jpg,*.jpeg,*.png,*.bmp,*.gif,*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff"
            openFile.ShowDialog()
            If (openFile.FileName = "") Then
                menuShuffle.Enabled = False
                Return
            End If

            Dim Row, Col As Integer
            For Row = 0 To nRows - 1
                For Col = 0 To nCols - 1
                    Try
                        tile(Row, Col).Dispose()
                    Catch
                    End Try
                Next
            Next

            MakeTiles(nRows, nCols)

            Dim cxThumbnail As Integer = tImageW * nRows
            Dim cyThumbnail As Integer = tImageW * nRows

            Dim Pic As Image = Image.FromFile(openFile.FileName)
            Pic = Pic.GetThumbnailImage(cxThumbnail, cyThumbnail, Nothing, System.IntPtr.Zero)

            Console.WriteLine(tile(0, 0).Location)
            For Row = 0 To nRows - 1
                For Col = 0 To nCols - 1
                    tile(Row, Col).tilePicture(Pic, New Point(Col * tImageW, Row * tImageW))
                Next
            Next

            blankTile = New Block(nRows - 1, nCols - 1)
            menuShuffle.Enabled = True
            PictureLoaded = True
            If menuSize.Enabled = False Then
                menuSize.Enabled = True
            End If
        End Sub
        Sub muat_dari_db()
            Try
                Using sql As New OleDbCommand("select gambar from tbsoni where level='" & Replace(My.Settings.SLEVEL, "'", "''") & "'", myconnection.open)
                    Using dr As OleDbDataReader = sql.ExecuteReader()
                        Using dt As New DataTable
                            dt.Load(dr)
                            If dt.Rows.Count <> 1 Then
                            Else
                                Dim rowsoni As DataRow = dt.Rows(0)
                                Using ms As New IO.MemoryStream(CType(rowsoni(0), Byte()))
                                    Dim Row, Col As Integer
                                    For Row = 0 To nRows - 1
                                        For Col = 0 To nCols - 1
                                            Try
                                                tile(Row, Col).Dispose()
                                            Catch
                                            End Try
                                        Next
                                    Next
                                    MakeTiles(nRows, nCols)
                                    Dim cxThumbnail As Integer = tImageW * nRows
                                    Dim cyThumbnail As Integer = tImageW * nRows
                                    'Dim Pic As Image = Image.FromFile(openFile.FileName)
                                    Dim Pic As Image = Image.FromStream(ms)
                                    Pic = Pic.GetThumbnailImage(cxThumbnail, cyThumbnail, Nothing, System.IntPtr.Zero)
                                    Console.WriteLine(tile(0, 0).Location)
                                    For Row = 0 To nRows - 1
                                        For Col = 0 To nCols - 1
                                            tile(Row, Col).tilePicture(Pic, New Point(Col * tImageW, Row * tImageW))
                                        Next
                                    Next
                                    blankTile = New Block(nRows - 1, nCols - 1)
                                    menuShuffle.Enabled = True
                                    If menuSize.Enabled = True Then
                                        menuSize.Enabled = False
                                    End If
                                    PictureLoaded = True
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
        Private Sub DariDataBase_Click(sender As Object, e As EventArgs) Handles DariDataBase.Click
            muat_dari_db()
        End Sub
        Private Sub Konfigurasi_Click(sender As Object, e As EventArgs) Handles Konfigurasi.Click
            FormKonfigurasi.Show()
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            Welcome.Close()
            Me.Close()
        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            Me.Close()
            Welcome.Show()
        End Sub

        Private Sub mnfrm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
            My.Settings.LEVELSONI = My.Settings.SLEVEL
            My.Settings.Save()
        End Sub

        Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click

        End Sub

        Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
            If milidetik = 60 Then
                milidetik = 0
                detik = detik + 1
            End If
            If detik = 60 Then
                If milidetik = 60 Then
                    milidetik = 0
                    detik = 0
                    menit = menit + 1
                End If
            End If
            If menit = 60 Then
                If detik = 60 Then
                    If milidetik = 60 Then
                        milidetik = 0
                        detik = 0
                        menit = 0
                        jam = jam + 1
                    End If
                End If
            End If

            milidetik = milidetik + 1
            Label2.Text = Format(jam, "00") & ":" & Format(menit, "00") & ":" & Format(detik, "00") & ":" & Format(milidetik, "00")
        End Sub
    End Class
End Namespace