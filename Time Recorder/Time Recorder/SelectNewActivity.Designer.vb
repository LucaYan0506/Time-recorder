<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectNewActivity
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CancelCmd = New System.Windows.Forms.Button()
        Me.OkCmd = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(9, 10)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(194, 28)
        Me.ComboBox1.TabIndex = 0
        '
        'CancelCmd
        '
        Me.CancelCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelCmd.Location = New System.Drawing.Point(9, 53)
        Me.CancelCmd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CancelCmd.Name = "CancelCmd"
        Me.CancelCmd.Size = New System.Drawing.Size(73, 33)
        Me.CancelCmd.TabIndex = 19
        Me.CancelCmd.Text = "Cancel"
        Me.CancelCmd.UseVisualStyleBackColor = True
        '
        'OkCmd
        '
        Me.OkCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkCmd.Location = New System.Drawing.Point(152, 53)
        Me.OkCmd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.OkCmd.Name = "OkCmd"
        Me.OkCmd.Size = New System.Drawing.Size(56, 33)
        Me.OkCmd.TabIndex = 19
        Me.OkCmd.Text = "Ok"
        Me.OkCmd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(86, 53)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 33)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Set"
        Me.ToolTip1.SetToolTip(Me.Button1, "Add a new Activity or edit an Activity")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SelectNewActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(216, 95)
        Me.Controls.Add(Me.OkCmd)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CancelCmd)
        Me.Controls.Add(Me.ComboBox1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.Name = "SelectNewActivity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SelectNewActivity"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents CancelCmd As System.Windows.Forms.Button
    Friend WithEvents OkCmd As System.Windows.Forms.Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
