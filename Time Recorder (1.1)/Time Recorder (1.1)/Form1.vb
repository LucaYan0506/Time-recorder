Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks

Public Class Form1
    Dim s, m, h As Integer
    Dim SelectNewActivity As New SelectNewActivity
    Dim Timeline As New TImeline
    Dim n As Integer
    Dim NameOfActivity, type, detail As String

    Public Declare Auto Function GetCursorPos Lib "User32.dll" (ByRef lpPoint As Point) As Integer
    Dim mousepos As Point ' This stores the cordinates of the mouse cursors location
    Dim alertFormsActive As Boolean = False
    Dim s2 = 0
    Private Sub mousePosDetector_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Async Sub showDialogbox()
        alertFormsActive = True
        Dim owner = New inactivity_alert
        owner.Show()
        Await Task.Delay(TimeSpan.FromSeconds(10))
        If owner.dialogResult = False Then
            StopCmd.PerformClick()
        End If
        alertFormsActive = False
        owner.Close()
    End Sub

    'save the current time into a temporary file, so that in case of unexpected closing of the app, we still have a record of it 
    Private Sub update_temporaryFile()
        Dim f As Integer = FreeFile()

        If IO.File.Exists("Activity") Then
            Dim c As Integer = FreeFile()
            FileOpen(c, "Activity", OpenMode.Input)
            Input(c, n)
            Do Until EOF(c)
                Input(c, NameOfActivity)
                Input(c, type)
                Input(c, detail)
                If NameOfActivity = SelectNewActivity.selected Then
                    Exit Do
                End If
            Loop
            FileClose(c)
        End If

        FileOpen(f, "temporaryFile", OpenMode.Output)
        Write(f, Date.Today)
        Write(f, HourLabel.Text & Label10.Text & MinLabel.Text & Label11.Text & SecLabel.Text)
        Write(f, NameOfActivity)
        Write(f, type)
        WriteLine(f, detail)
        FileClose(f)
    End Sub
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
        'check for inactivity
        s2 += 1

        Dim prev_mousepos As Point = mousepos ' This stores the cordinates of the mouse cursors location
        GetCursorPos(mousepos) ' You'll get your location in mousepos

        If mousepos.X <> prev_mousepos.X Or mousepos.Y <> prev_mousepos.Y Then
            s2 = 0
        End If


        If mousepos.X = prev_mousepos.X And mousepos.Y = prev_mousepos.Y And s2 > 3600 And alertFormsActive = False Then
            showDialogbox()
        End If

        Dim minuteUpdate = False

        'record time
        s += 1
        If s >= 60 Then
            minuteUpdate = True
            s -= 60
            m += 1
            InsertTime(m, MinLabel)
        End If
        If m >= 60 Then
            Dim f = New fade_form
            f.Opacity = 0
            f.Show()
            m -= 60
            InsertTime(m, MinLabel)
            h += 1
            InsertTime(h, HourLabel)
        End If
        InsertTime(s, SecLabel)
        NotifyIcon1.Text = HourLabel.Text + "h " + MinLabel.Text + "m " + SecLabel.Text + "s"

        'update temorary file every minutes
        If minuteUpdate Then
            update_temporaryFile()
        End If
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

            'remove temporaryFile, since it is saved into timeline.txt
            System.IO.File.Delete("temporaryFile")
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
    End Sub

    Private Sub TimelineCmd_Click(sender As Object, e As EventArgs) Handles TimelineCmd.Click
        Timeline.ShowDialog()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StopCmd.Enabled = False
        StopToolStripMenuItem.Enabled = False

        'check if the app closed unexpectedly, if so, ask the user if he wants to recover the previous time?
        If System.IO.File.Exists("temporaryFile") Then
            Dim result As DialogResult = MessageBox.Show("The program was closed unexpectedly, do you want to recover the previous time?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                Dim f As Integer = FreeFile()
                Dim current_date As Date
                Dim current_time As String
                FileOpen(f, "temporaryFile", OpenMode.Input)
                Input(f, current_date)
                Input(f, current_time)
                Input(f, NameOfActivity)
                Input(f, type)
                Input(f, detail)
                FileClose(f)

                FileOpen(f, "Timeline", OpenMode.Append)
                Write(f, current_date)
                Write(f, current_time)
                Write(f, NameOfActivity)
                Write(f, type)
                WriteLine(f, detail)
                FileClose(f)
            End If

            IO.File.Delete("temporaryFile")
        End If

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
        Me.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

End Class
