<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.StartCmd = New System.Windows.Forms.Button()
        Me.MinLabel = New System.Windows.Forms.Label()
        Me.HourLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SecLabel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.StopCmd = New System.Windows.Forms.Button()
        Me.TimelineCmd = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartCmd
        '
        Me.StartCmd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.StartCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartCmd.Location = New System.Drawing.Point(4, 58)
        Me.StartCmd.Margin = New System.Windows.Forms.Padding(2)
        Me.StartCmd.Name = "StartCmd"
        Me.StartCmd.Size = New System.Drawing.Size(100, 47)
        Me.StartCmd.TabIndex = 0
        Me.StartCmd.Text = "Start a new activity"
        Me.StartCmd.UseVisualStyleBackColor = False
        '
        'MinLabel
        '
        Me.MinLabel.AutoSize = True
        Me.MinLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.MinLabel.Location = New System.Drawing.Point(104, 7)
        Me.MinLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MinLabel.Name = "MinLabel"
        Me.MinLabel.Size = New System.Drawing.Size(60, 42)
        Me.MinLabel.TabIndex = 14
        Me.MinLabel.Text = "00"
        '
        'HourLabel
        '
        Me.HourLabel.AutoSize = True
        Me.HourLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HourLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.HourLabel.Location = New System.Drawing.Point(12, 7)
        Me.HourLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.HourLabel.Name = "HourLabel"
        Me.HourLabel.Size = New System.Drawing.Size(60, 42)
        Me.HourLabel.TabIndex = 13
        Me.HourLabel.Text = "00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(73, 7)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 42)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = ":"
        '
        'SecLabel
        '
        Me.SecLabel.AutoSize = True
        Me.SecLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.SecLabel.Location = New System.Drawing.Point(197, 7)
        Me.SecLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SecLabel.Name = "SecLabel"
        Me.SecLabel.Size = New System.Drawing.Size(60, 42)
        Me.SecLabel.TabIndex = 15
        Me.SecLabel.Text = "00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(165, 7)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 42)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = ":"
        '
        'StopCmd
        '
        Me.StopCmd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.StopCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StopCmd.Location = New System.Drawing.Point(106, 63)
        Me.StopCmd.Margin = New System.Windows.Forms.Padding(2)
        Me.StopCmd.Name = "StopCmd"
        Me.StopCmd.Size = New System.Drawing.Size(82, 39)
        Me.StopCmd.TabIndex = 18
        Me.StopCmd.Text = "Stop"
        Me.StopCmd.UseVisualStyleBackColor = False
        '
        'TimelineCmd
        '
        Me.TimelineCmd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TimelineCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimelineCmd.Location = New System.Drawing.Point(190, 63)
        Me.TimelineCmd.Margin = New System.Windows.Forms.Padding(2)
        Me.TimelineCmd.Name = "TimelineCmd"
        Me.TimelineCmd.Size = New System.Drawing.Size(77, 39)
        Me.TimelineCmd.TabIndex = 19
        Me.TimelineCmd.Text = "Timeline"
        Me.TimelineCmd.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.StopToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 70)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(272, 110)
        Me.Controls.Add(Me.TimelineCmd)
        Me.Controls.Add(Me.StopCmd)
        Me.Controls.Add(Me.MinLabel)
        Me.Controls.Add(Me.HourLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.SecLabel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.StartCmd)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time recorder"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartCmd As System.Windows.Forms.Button
    Friend WithEvents MinLabel As System.Windows.Forms.Label
    Friend WithEvents HourLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents SecLabel As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents StopCmd As System.Windows.Forms.Button
    Friend WithEvents TimelineCmd As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
End Class
