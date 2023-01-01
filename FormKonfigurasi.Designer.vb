<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKonfigurasi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BTSIMPAN = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CLEVEL = New System.Windows.Forms.ComboBox()
        Me.BTRESETLEVEL = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTSIMPAN
        '
        Me.BTSIMPAN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTSIMPAN.Location = New System.Drawing.Point(2, 381)
        Me.BTSIMPAN.Name = "BTSIMPAN"
        Me.BTSIMPAN.Size = New System.Drawing.Size(90, 23)
        Me.BTSIMPAN.TabIndex = 0
        Me.BTSIMPAN.Text = "Simpan"
        Me.BTSIMPAN.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(578, 377)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'CLEVEL
        '
        Me.CLEVEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CLEVEL.FormattingEnabled = True
        Me.CLEVEL.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.CLEVEL.Location = New System.Drawing.Point(583, 3)
        Me.CLEVEL.Name = "CLEVEL"
        Me.CLEVEL.Size = New System.Drawing.Size(130, 21)
        Me.CLEVEL.TabIndex = 2
        Me.CLEVEL.Text = "Level Gambar"
        '
        'BTRESETLEVEL
        '
        Me.BTRESETLEVEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTRESETLEVEL.Location = New System.Drawing.Point(98, 381)
        Me.BTRESETLEVEL.Name = "BTRESETLEVEL"
        Me.BTRESETLEVEL.Size = New System.Drawing.Size(90, 23)
        Me.BTRESETLEVEL.TabIndex = 3
        Me.BTRESETLEVEL.Text = "Reset Level"
        Me.BTRESETLEVEL.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Set Level:"
        '
        'FormKonfigurasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(716, 410)
        Me.Controls.Add(Me.BTRESETLEVEL)
        Me.Controls.Add(Me.CLEVEL)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BTSIMPAN)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormKonfigurasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormKonfigurasi"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTSIMPAN As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CLEVEL As ComboBox
    Friend WithEvents BTRESETLEVEL As Button
    Friend WithEvents Label1 As Label
End Class
