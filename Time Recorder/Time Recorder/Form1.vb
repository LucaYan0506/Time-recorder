Public Class Form1
    Dim s, m, h As Integer
    Dim SelectNewActivity As New SelectNewActivity
    Dim Timeline As New TImeline
    Dim n As Integer
    Dim NameOfActivity, type, detail As String
    Private Sub InsertTime(ByVal n As Integer, ByVal label As Object)
        Dim m As String
        m = n.ToString
        If m < 10 Then
            label.Text = "0" + m
        Else
            label.Text = m
        End If
    End Sub

    Private Sub ResetTime(ByRef n As Integer, ByVal Label As Object)
        n = 0
        Label.text = "00"
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        s += 1
        If s >= 60 Then
            s -= 60
            m += 1
            InsertTime(m, MinLabel)
        End If
        If m >= 60 Then
            m -= 60
            InsertTime(m, MinLabel)
            h += 1
            InsertTime(h, HourLabel)
        End If
        InsertTime(s, SecLabel)
        NotifyIcon1.Text = HourLabel.Text + "h " + MinLabel.Text + "m " + SecLabel.Text + "s"
    End Sub

    Private Sub StartCmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartCmd.Click
        If StartCmd.Text = "Start a new activity" Then
            SelectNewActivity.FormSelected = "Form1"
            SelectNewActivity.ShowDialog()
            If SelectNewActivity.cancel = True Then
                SelectNewActivity.cancel = False
                Exit Sub
            End If
            Timer1.Start()
            StopCmd.Enabled = True
            StopToolStripMenuItem.Enabled = True
            StartCmd.Text = "Finished"
        ElseIf StartCmd.Text = "Finished" Then
            Timer1.Stop()
            If IO.File.Exists("Activity") Then
                Dim c As Integer = FreeFile()
                FileOpen(c, "Activity", OpenMode.Input)
                Input(c, n)
                Do Until EOF(c)
                    Input(c, NameOfActivity)
                    Input(c, type)
                    Input(c, detail)
                    If NameOfActivity = SelectNewActivity.selected Then
                        Dim f As Integer = FreeFile()
                        FileOpen(f, "Timeline", OpenMode.Append)
                        Write(f, Date.Today)
                        Write(f, HourLabel.Text & Label10.Text & MinLabel.Text & Label11.Text & SecLabel.Text)
                        Write(f, NameOfActivity)
                        Write(f, type)
                        WriteLine(f, detail)
                        FileClose(f)
                        Exit Do
                    End If
                Loop
                FileClose(c)
            End If
            ResetTime(s, SecLabel)
            ResetTime(m, MinLabel)
            ResetTime(h, HourLabel)
            StopCmd.Enabled = False
            StopCmd.Text = "Stop"
            StopToolStripMenuItem.Enabled = False
            StopToolStripMenuItem.Text = "Stop"
            StartCmd.Text = "Start a new activity"
            StopToolStripMenuItem.Text = "Stop"
        End If
    End Sub

    Private Sub StopCmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopCmd.Click
        If StopCmd.Text = "Stop" Then
            Timer1.Stop()
            StopCmd.Text = "Continue"
        ElseIf StopCmd.Text = "Continue" Then
            Timer1.Start()
            StopCmd.Text = "Stop"
        End If
        StopToolStripMenuItem.Text = StopCmd.Text
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        NotifyIcon1.ShowBalloonTip(450, "Time Recorder", "The application was closed, but it is still running in background", ToolTipIcon.Info)
    End Sub

    Private Sub TimelineCmd_Click(sender As Object, e As EventArgs) Handles TimelineCmd.Click
        Timeline.ShowDialog()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        NotifyIcon1.ShowBalloonTip(450, "Time Recorder", "The application has been opened", ToolTipIcon.Info)
        Me.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StopCmd.Enabled = False
        StopToolStripMenuItem.Enabled = False
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        If StopToolStripMenuItem.Text = "Stop" Then
            Timer1.Stop()
            StopToolStripMenuItem.Text = "Continue"
        ElseIf StopToolStripMenuItem.Text = "Continue" Then
            Timer1.Start()
            StopToolStripMenuItem.Text = "Stop"
        End If
        StopCmd.Text = StopToolStripMenuItem.Text
    End Sub

    Private Sub OpenToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        NotifyIcon1.ShowBalloonTip(450, "Time Recorder", "The application has been opened", ToolTipIcon.Info)
        Me.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

End Class
