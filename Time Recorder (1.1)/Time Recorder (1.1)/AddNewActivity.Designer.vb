<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddNewActivity
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DateLab = New System.Windows.Forms.Label()
        Me.SelectDataCmd = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SecCBox = New System.Windows.Forms.ComboBox()
        Me.MinCBox = New System.Windows.Forms.ComboBox()
        Me.HoursCbox = New System.Windows.Forms.ComboBox()
        Me.TimeLab = New System.Windows.Forms.Label()
        Me.TypeLab = New System.Windows.Forms.Label()
        Me.TypeCBox = New System.Windows.Forms.ComboBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.DetailLab = New System.Windows.Forms.Label()
        Me.CancelCmd = New System.Windows.Forms.Button()
        Me.AddCmd = New System.Windows.Forms.Button()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.SuspendLayout()
        '
        'DateLab
        '
        Me.DateLab.AutoSize = True
        Me.DateLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateLab.Location = New System.Drawing.Point(16, 7)
        Me.DateLab.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.DateLab.Name = "DateLab"
        Me.DateLab.Size = New System.Drawing.Size(52, 24)
        Me.DateLab.TabIndex = 0
        Me.DateLab.Text = "Date"
        '
        'SelectDataCmd
        '
        Me.SelectDataCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectDataCmd.Location = New System.Drawing.Point(9, 33)
        Me.SelectDataCmd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SelectDataCmd.Name = "SelectDataCmd"
        Me.SelectDataCmd.Size = New System.Drawing.Size(88, 28)
        Me.SelectDataCmd.TabIndex = 1
        Me.SelectDataCmd.Text = "Select"
        Me.SelectDataCmd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(200, 60)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Sec"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(149, 60)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Min"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(106, 60)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Hour"
        '
        'SecCBox
        '
        Me.SecCBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecCBox.FormattingEnabled = True
        Me.SecCBox.IntegralHeight = False
        Me.SecCBox.Location = New System.Drawing.Point(190, 33)
        Me.SecCBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SecCBox.Name = "SecCBox"
        Me.SecCBox.Size = New System.Drawing.Size(42, 28)
        Me.SecCBox.TabIndex = 24
        Me.SecCBox.Text = "00"
        '
        'MinCBox
        '
        Me.MinCBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinCBox.FormattingEnabled = True
        Me.MinCBox.IntegralHeight = False
        Me.MinCBox.Location = New System.Drawing.Point(145, 33)
        Me.MinCBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MinCBox.Name = "MinCBox"
        Me.MinCBox.Size = New System.Drawing.Size(42, 28)
        Me.MinCBox.TabIndex = 23
        Me.MinCBox.Text = "00"
        '
        'HoursCbox
        '
        Me.HoursCbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoursCbox.FormattingEnabled = True
        Me.HoursCbox.IntegralHeight = False
        Me.HoursCbox.Location = New System.Drawing.Point(100, 33)
        Me.HoursCbox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.HoursCbox.Name = "HoursCbox"
        Me.HoursCbox.Size = New System.Drawing.Size(41, 28)
        Me.HoursCbox.TabIndex = 22
        Me.HoursCbox.Text = "00"
        '
        'TimeLab
        '
        Me.TimeLab.AutoSize = True
        Me.TimeLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLab.Location = New System.Drawing.Point(141, 7)
        Me.TimeLab.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TimeLab.Name = "TimeLab"
        Me.TimeLab.Size = New System.Drawing.Size(57, 24)
        Me.TimeLab.TabIndex = 21
        Me.TimeLab.Text = "Time"
        '
        'TypeLab
        '
        Me.TypeLab.AutoSize = True
        Me.TypeLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeLab.Location = New System.Drawing.Point(265, 7)
        Me.TypeLab.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TypeLab.Name = "TypeLab"
        Me.TypeLab.Size = New System.Drawing.Size(57, 24)
        Me.TypeLab.TabIndex = 21
        Me.TypeLab.Text = "Type"
        '
        'TypeCBox
        '
        Me.TypeCBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeCBox.FormattingEnabled = True
        Me.TypeCBox.Location = New System.Drawing.Point(236, 34)
        Me.TypeCBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TypeCBox.Name = "TypeCBox"
        Me.TypeCBox.Size = New System.Drawing.Size(116, 25)
        Me.TypeCBox.TabIndex = 28
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(9, 100)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(343, 76)
        Me.RichTextBox1.TabIndex = 29
        Me.RichTextBox1.Text = ""
        '
        'DetailLab
        '
        Me.DetailLab.AutoSize = True
        Me.DetailLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailLab.Location = New System.Drawing.Point(16, 74)
        Me.DetailLab.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.DetailLab.Name = "DetailLab"
        Me.DetailLab.Size = New System.Drawing.Size(62, 24)
        Me.DetailLab.TabIndex = 21
        Me.DetailLab.Text = "Detail"
        '
        'CancelCmd
        '
        Me.CancelCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelCmd.Location = New System.Drawing.Point(2, 180)
        Me.CancelCmd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CancelCmd.Name = "CancelCmd"
        Me.CancelCmd.Size = New System.Drawing.Size(75, 30)
        Me.CancelCmd.TabIndex = 30
        Me.CancelCmd.Text = "Cancel"
        Me.CancelCmd.UseVisualStyleBackColor = True
        '
        'AddCmd
        '
        Me.AddCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddCmd.Location = New System.Drawing.Point(299, 180)
        Me.AddCmd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AddCmd.Name = "AddCmd"
        Me.AddCmd.Size = New System.Drawing.Size(52, 30)
        Me.AddCmd.TabIndex = 30
        Me.AddCmd.Text = "Add"
        Me.AddCmd.UseVisualStyleBackColor = True
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(9, 34)
        Me.MonthCalendar1.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 31
        Me.MonthCalendar1.Visible = False
        '
        'AddNewActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 217)
        Me.Controls.Add(Me.SelectDataCmd)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.AddCmd)
        Me.Controls.Add(Me.CancelCmd)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.TypeCBox)
        Me.Controls.Add(Me.SecCBox)
        Me.Controls.Add(Me.MinCBox)
        Me.Controls.Add(Me.HoursCbox)
        Me.Controls.Add(Me.DetailLab)
        Me.Controls.Add(Me.TypeLab)
        Me.Controls.Add(Me.TimeLab)
        Me.Controls.Add(Me.DateLab)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.Name = "AddNewActivity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddNewActivity"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateLab As Label
    Friend WithEvents SelectDataCmd As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SecCBox As ComboBox
    Friend WithEvents MinCBox As ComboBox
    Friend WithEvents HoursCbox As ComboBox
    Friend WithEvents TimeLab As Label
    Friend WithEvents TypeLab As Label
    Friend WithEvents TypeCBox As ComboBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents DetailLab As Label
    Friend WithEvents CancelCmd As Button
    Friend WithEvents AddCmd As Button
    Friend WithEvents MonthCalendar1 As MonthCalendar
End Class
