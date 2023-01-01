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
        Const tSquare As Integer = 200
        Const tImageW As Integer = 200
        'Ukuran default
        Dim nRows As Integer = 2
        Dim nCols As Integer = 2
        Dim rand As Random
        Dim blankTile As Block
        Dim PictureLoaded As Boolean = False

        Dim timerCountdown As Integer
        Friend WithEvents tmplasttile As ctlTile
        Private tile(,) As ctlTile
        Friend WithEvents DariDataBase As MenuItem
        Friend WithEvents DariKomputer As MenuItem
        Friend WithEvents menuLoad As MenuItem
        Friend WithEvents menuShuffle As MenuItem
        Friend WithEvents menu2X2 As MenuItem
        Friend WithEvents menu3X3 As MenuItem
        Friend WithEvents menu4X4 As MenuItem
        Friend WithEvents menu5X5 As MenuItem
        Friend WithEvents menu6X6 As MenuItem
        Friend WithEvents menu7X7 As MenuItem
        Friend WithEvents menu8X8 As MenuItem
        Friend WithEvents menu9X9 As MenuItem
        Friend WithEvents menu10X10 As MenuItem
        Friend WithEvents menuSize As MenuItem
        Friend WithEvents MenuItem1 As MenuItem
        Friend WithEvents menuWhite As MenuItem
        Friend WithEvents menuGreen As MenuItem
        Friend WithEvents menuBlue As MenuItem
        Friend WithEvents menuRed As MenuItem
        Friend WithEvents menuSilver As MenuItem
        Friend WithEvents menuGridColor As MenuItem
        Friend WithEvents MenuItem2 As MenuItem
        Friend WithEvents mainMenu1 As MainMenu
        Friend WithEvents Konfigurasi As MenuItem
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents Label5 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label1 As Label
        Friend WithEvents GroupBox2 As GroupBox
        Friend WithEvents Label7 As Label
        Friend WithEvents Label8 As Label
        Friend WithEvents Label9 As Label
        Friend WithEvents Label10 As Label
        Friend WithEvents GroupBox3 As GroupBox
        Friend WithEvents Label11 As Label
        Friend WithEvents Label6 As Label
        Friend WithEvents MenuItem3 As MenuItem
        Friend WithEvents txtTingkatKesulitan As Label
        Friend WithEvents txtLevel As Label
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
            Me.menu2X2 = New System.Windows.Forms.MenuItem()
            Me.menu3X3 = New System.Windows.Forms.MenuItem()
            Me.menu4X4 = New System.Windows.Forms.MenuItem()
            Me.menu5X5 = New System.Windows.Forms.MenuItem()
            Me.menu6X6 = New System.Windows.Forms.MenuItem()
            Me.menu7X7 = New System.Windows.Forms.MenuItem()
            Me.menu8X8 = New System.Windows.Forms.MenuItem()
            Me.menu9X9 = New System.Windows.Forms.MenuItem()
            Me.menu10X10 = New System.Windows.Forms.MenuItem()
            Me.menuSize = New System.Windows.Forms.MenuItem()
            Me.MenuItem1 = New System.Windows.Forms.MenuItem()
            Me.menuWhite = New System.Windows.Forms.MenuItem()
            Me.menuGreen = New System.Windows.Forms.MenuItem()
            Me.menuBlue = New System.Windows.Forms.MenuItem()
            Me.menuRed = New System.Windows.Forms.MenuItem()
            Me.menuSilver = New System.Windows.Forms.MenuItem()
            Me.menuGridColor = New System.Windows.Forms.MenuItem()
            Me.MenuItem2 = New System.Windows.Forms.MenuItem()
            Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.MenuItem3 = New System.Windows.Forms.MenuItem()
            Me.txtLevel = New System.Windows.Forms.Label()
            Me.txtTingkatKesulitan = New System.Windows.Forms.Label()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.SuspendLayout()
            '
            'tilesPanel
            '
            Me.tilesPanel.BackColor = System.Drawing.Color.PaleGreen
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
            Me.DariDataBase.Index = 0
            Me.DariDataBase.Text = "Dari Database (Otomatis)"
            '
            'DariKomputer
            '
            Me.DariKomputer.Index = 1
            Me.DariKomputer.Text = "Dari Komputer (Manual)"
            '
            'menuLoad
            '
            Me.menuLoad.Index = 0
            Me.menuLoad.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.DariDataBase, Me.DariKomputer, Me.Konfigurasi})
            Me.menuLoad.Text = "Menu Utama"
            '
            'Konfigurasi
            '
            Me.Konfigurasi.Index = 2
            Me.Konfigurasi.Text = "Konfigurasi"
            '
            'menuShuffle
            '
            Me.menuShuffle.Enabled = False
            Me.menuShuffle.Index = 1
            Me.menuShuffle.Text = "Acak"
            '
            'menu2X2
            '
            Me.menu2X2.DefaultItem = True
            Me.menu2X2.Index = 0
            Me.menu2X2.Text = "2 x 2"
            '
            'menu3X3
            '
            Me.menu3X3.Index = 1
            Me.menu3X3.RadioCheck = True
            Me.menu3X3.Text = "3 x 3"
            '
            'menu4X4
            '
            Me.menu4X4.Index = 2
            Me.menu4X4.RadioCheck = True
            Me.menu4X4.Text = "4 x 4"
            '
            'menu5X5
            '
            Me.menu5X5.Index = 3
            Me.menu5X5.RadioCheck = True
            Me.menu5X5.Text = "5 x 5"
            '
            'menu6X6
            '
            Me.menu6X6.Index = 4
            Me.menu6X6.Text = "6 x 6"
            '
            'menu7X7
            '
            Me.menu7X7.Index = 5
            Me.menu7X7.Text = "7 x 7"
            '
            'menu8X8
            '
            Me.menu8X8.Index = 6
            Me.menu8X8.Text = "8 x 8"
            '
            'menu9X9
            '
            Me.menu9X9.Index = 7
            Me.menu9X9.Text = "9 x 9"
            '
            'menu10X10
            '
            Me.menu10X10.Index = 8
            Me.menu10X10.Text = "10 x 10"
            '
            'menuSize
            '
            Me.menuSize.Index = 2
            Me.menuSize.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menu2X2, Me.menu3X3, Me.menu4X4, Me.menu5X5, Me.menu6X6, Me.menu7X7, Me.menu8X8, Me.menu9X9, Me.menu10X10})
            Me.menuSize.RadioCheck = True
            Me.menuSize.Text = "Ukuran"
            '
            'MenuItem1
            '
            Me.MenuItem1.Index = 4
            Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3})
            Me.MenuItem1.Text = "Bantuan"
            '
            'menuWhite
            '
            Me.menuWhite.Index = 0
            Me.menuWhite.Text = "White"
            '
            'menuGreen
            '
            Me.menuGreen.Checked = True
            Me.menuGreen.DefaultItem = True
            Me.menuGreen.Index = 1
            Me.menuGreen.Text = "Green"
            '
            'menuBlue
            '
            Me.menuBlue.Index = 2
            Me.menuBlue.Text = "Blue"
            '
            'menuRed
            '
            Me.menuRed.Index = 3
            Me.menuRed.Text = "Red"
            '
            'menuSilver
            '
            Me.menuSilver.Index = 4
            Me.menuSilver.Text = "Silver"
            '
            'menuGridColor
            '
            Me.menuGridColor.Index = 3
            Me.menuGridColor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuWhite, Me.menuGreen, Me.menuBlue, Me.menuRed, Me.menuSilver})
            Me.menuGridColor.Text = "Warna"
            '
            'MenuItem2
            '
            Me.MenuItem2.Index = 5
            Me.MenuItem2.Text = ""
            '
            'mainMenu1
            '
            Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuLoad, Me.menuShuffle, Me.menuSize, Me.menuGridColor, Me.MenuItem1, Me.MenuItem2})
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.Label5)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Location = New System.Drawing.Point(25, 394)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(361, 142)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Cara Bermain"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(7, 20)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(200, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "1. Silahkan pilih gambar dari menu utama"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(7, 42)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(223, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "2. Acak gambar untuk membuat gambar acak"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(7, 66)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(308, 13)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "3. Selesaikan puzzle gambar sesuai dengan gambar yang benar"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(7, 91)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(275, 13)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "4. Setelah selesai, maka akan masuk ke level berikutnya"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(7, 116)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(285, 13)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "5. Pada level berikutnya, kotak puzzle akan semakin besar"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.Label9)
            Me.GroupBox2.Controls.Add(Me.Label10)
            Me.GroupBox2.Location = New System.Drawing.Point(440, 394)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(361, 142)
            Me.GroupBox2.TabIndex = 2
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Cara mengatur level"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(7, 91)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(124, 13)
            Me.Label7.TabIndex = 3
            Me.Label7.Text = "4. Kemudian klik, simpan"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(7, 66)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(230, 13)
            Me.Label8.TabIndex = 2
            Me.Label8.Text = "3. Klik gambar, untuk mengupload gambar baru"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(7, 42)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(208, 13)
            Me.Label9.TabIndex = 1
            Me.Label9.Text = "2. Pilih level yang akan di ganti gambarnya"
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(7, 20)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(208, 13)
            Me.Label10.TabIndex = 0
            Me.Label10.Text = "1. Silahkan pilih menu utama -> konfigurasi"
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.txtTingkatKesulitan)
            Me.GroupBox3.Controls.Add(Me.txtLevel)
            Me.GroupBox3.Controls.Add(Me.Label11)
            Me.GroupBox3.Controls.Add(Me.Label6)
            Me.GroupBox3.Location = New System.Drawing.Point(450, 12)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(340, 131)
            Me.GroupBox3.TabIndex = 3
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Informasi mainan"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(17, 33)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(33, 13)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "Level"
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(17, 75)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(88, 13)
            Me.Label11.TabIndex = 1
            Me.Label11.Text = "Tingkat kesulitan"
            '
            'MenuItem3
            '
            Me.MenuItem3.Index = 0
            Me.MenuItem3.Text = "Penjelasan metode BFS"
            '
            'txtLevel
            '
            Me.txtLevel.AutoSize = True
            Me.txtLevel.Location = New System.Drawing.Point(117, 33)
            Me.txtLevel.Name = "txtLevel"
            Me.txtLevel.Size = New System.Drawing.Size(16, 13)
            Me.txtLevel.TabIndex = 2
            Me.txtLevel.Text = ": -"
            '
            'txtTingkatKesulitan
            '
            Me.txtTingkatKesulitan.AutoSize = True
            Me.txtTingkatKesulitan.Location = New System.Drawing.Point(117, 75)
            Me.txtTingkatKesulitan.Name = "txtTingkatKesulitan"
            Me.txtTingkatKesulitan.Size = New System.Drawing.Size(16, 13)
            Me.txtTingkatKesulitan.TabIndex = 3
            Me.txtTingkatKesulitan.Text = ": -"
            '
            'mnfrm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1102, 577)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.tilesPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Menu = Me.mainMenu1
            Me.Name = "mnfrm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Puzzle Game - Mufliha"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region "Muat Form"
        Private Sub mnfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            MakeTiles(nRows, nCols)
            menuSize.Enabled = False
            menuGridColor.Enabled = False
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
        Private Sub menuShuffle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuShuffle.Click
            menuShuffle.Enabled = False
            menuGridColor.Enabled = True
            tmplasttile = tile(nRows - 1, nCols - 1)
            tmplasttile.Visible = False
            tile(nRows - 1, nCols - 1).Visible = False
            Randomize()
        End Sub
#End Region

#Region "Ukuran Menu"
        Private Sub menu2X2_Click(sender As Object, e As EventArgs) Handles menu2X2.Click
            If (menu2X2.Checked) Then Return
            clearItems()
            menu2X2.Checked = True
            nRows = 2
            nCols = 2
            MakeTiles(nRows, nCols)
        End Sub
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
        Private Sub menu5X5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu5X5.Click
            If (menu5X5.Checked) Then Return
            clearItems()
            menu5X5.Checked = True
            nRows = 5
            nCols = 5
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

        Private Sub menu7X7_Click(sender As Object, e As EventArgs) Handles menu7X7.Click
            If (menu7X7.Checked) Then Return
            clearItems()
            menu7X7.Checked = True
            nRows = 7
            nCols = 7
            MakeTiles(nRows, nCols)
        End Sub

        Private Sub menu8X8_Click(sender As Object, e As EventArgs) Handles menu8X8.Click
            If (menu8X8.Checked) Then Return
            clearItems()
            menu8X8.Checked = True
            nRows = 8
            nCols = 8
            MakeTiles(nRows, nCols)
        End Sub

        Private Sub menu9X9_Click(sender As Object, e As EventArgs) Handles menu9X9.Click
            If (menu9X9.Checked) Then Return
            clearItems()
            menu9X9.Checked = True
            nRows = 9
            nCols = 9
            MakeTiles(nRows, nCols)
        End Sub

        Private Sub menu10X10_Click(sender As Object, e As EventArgs) Handles menu10X10.Click
            If (menu10X10.Checked) Then Return
            clearItems()
            menu10X10.Checked = True
            nRows = 10
            nCols = 10
            MakeTiles(nRows, nCols)
        End Sub
        Private Sub clearItems()
            menu2X2.Checked = False
            menu3X3.Checked = False
            menu4X4.Checked = False
            menu5X5.Checked = False
            menu6X6.Checked = False
            menu7X7.Checked = False
            menu8X8.Checked = False
            menu9X9.Checked = False
            menu10X10.Checked = False
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
            menuGridColor.Enabled = True
            PictureLoaded = False
        End Sub

#End Region

#Region "Warna Grid"
        Private Sub ClearColors()
            menuWhite.Checked = False
            menuGreen.Checked = False
            menuBlue.Checked = False
            menuRed.Checked = False
            menuSilver.Checked = False
        End Sub

        Private Sub menuWhite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuWhite.Click
            ClearColors()
            menuWhite.Checked = True
            Me.tilesPanel.BackColor = Color.LightYellow
        End Sub

        Private Sub menuGreen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuGreen.Click
            ClearColors()
            menuGreen.Checked = True
            Me.tilesPanel.BackColor = Color.PaleGreen
        End Sub

        Private Sub menuBlue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuBlue.Click
            ClearColors()
            menuBlue.Checked = True
            Me.tilesPanel.BackColor = Color.LightBlue
        End Sub

        Private Sub menuRed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuRed.Click
            ClearColors()
            menuRed.Checked = True
            Me.tilesPanel.BackColor = Color.LightCoral
        End Sub

        Private Sub menuSilver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSilver.Click
            ClearColors()
            menuSilver.Checked = True
            Me.tilesPanel.BackColor = Color.Silver
        End Sub
#End Region
        Private Sub DariKomputer_Click(sender As Object, e As EventArgs) Handles DariKomputer.Click
            openFile.FileName = ""
            openFile.Filter = "Gambar (*.jpg,*.jpeg,*.png,*.bmp,*.gif,*.tiff)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff"
            openFile.ShowDialog()
            If (openFile.FileName = "") Then
                menuShuffle.Enabled = False
                menuGridColor.Enabled = True
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
            If menuGridColor.Enabled = False Then
                menuGridColor.Enabled = True
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
                                    ''If My.Settings.LEVELSONI <= 1 Then
                                    ''Else
                                    ''    clearItems()
                                    ''    Dim sonisitez As Integer = My.Settings.LEVELSONI
                                    ''    nRows = sonisitez
                                    ''    nCols = sonisitez
                                    ''    MakeTiles(nRows, nCols)
                                    ''End If
                                    menuShuffle.Enabled = True
                                    If menuGridColor.Enabled = False Then
                                        menuGridColor.Enabled = True
                                    End If
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
        Private Sub mnfrm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
            My.Settings.LEVELSONI = My.Settings.SLEVEL
            My.Settings.Save()
        End Sub

        Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click

        End Sub
    End Class
End Namespace