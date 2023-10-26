Public Class SelectNewActivity
    Public Shared cancel As Boolean
    Public Shared selected As String
    Public Shared FormSelected As String
    Dim activity As New Activity
    Dim NameOfActivity(100) As String
    Dim type As String
    Dim detail As String
    Dim index, num As Integer
    Dim OK As Boolean
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Other" Then
            MsgBox("")
        End If
    End Sub

    Private Sub SelectNewActivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FormSelected = "Timeline" Then
            OkCmd.Text = "Next"
        Else
            OK = False
            OkCmd.Text = "Ok"
        End If
        ComboBox1.Items.Clear()
        If IO.File.Exists("Activity") Then
            index = 0
            Dim c As Integer = FreeFile()
            FileOpen(c, "Activity", OpenMode.Input)
            Input(c, num)
            Do Until EOF(c)
                index += 1
                Input(c, NameOfActivity(index))
                Input(c, type)
                Input(c, detail)
                ComboBox1.Items.Add(NameOfActivity(index))
            Loop
            FileClose(c)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        activity.ShowDialog()
    End Sub

    Private Sub SelectNewActivity_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Activity.IFClose = True Then
            ComboBox1.Items.Clear()
            If IO.File.Exists("Activity") Then
                Dim c As Integer = FreeFile()
                FileOpen(c, "Activity", OpenMode.Input)
                Input(c, num)
                Do Until EOF(c)
                    Input(c, NameOfActivity(index + 1))
                    Input(c, type)
                    Input(c, detail)
                    ComboBox1.Items.Add(NameOfActivity(index + 1))
                    index += 1
                Loop
                FileClose(c)
            End If
        End If
    End Sub

    Private Sub CancelCmd_Click(sender As Object, e As EventArgs) Handles CancelCmd.Click
        cancel = True
        Me.Close()
    End Sub

    Private Sub OkCmd_Click(sender As Object, e As EventArgs) Handles OkCmd.Click
        If FormSelected = "Timeline" Then
            If ComboBox1.Text = Nothing Then
                MsgBox("Select an Activity")
            Else
                TImeline.AddNameOfActivity = ComboBox1.Text
                Me.Hide()
                Dim Add2 As New AddNewActivity
                Me.Close()
                Add2.ShowDialog()
            End If
        Else
            If ComboBox1.Text = Nothing Then
                MsgBox("Select an Activity")
            Else
                cancel = False
                OK = True
                selected = ComboBox1.Text
                Me.Close()
            End If
        End If
    End Sub

    Private Sub SelectNewActivity_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        cancel = True
        If OK = True Then
            cancel = False
        End If
    End Sub
End Class