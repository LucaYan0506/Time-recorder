Public Class AddNewActivity
    Dim NameOfActivity, type, detail As String
    Private Sub AddTime(ByRef Combobox1 As Object, ByVal LastTime As Integer)
        Combobox1.items.clear
        For i = 0 To LastTime
            If i < 10 Then
                Combobox1.items.add("0" & i)
            Else
                Combobox1.items.add(i)
            End If
        Next
    End Sub
    Private Sub AddNewActivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddTime(HoursCbox, 9)
        AddTime(MinCBox, 60)
        AddTime(SecCBox, 60)
        TypeCBox.Items.Clear()
        TypeCBox.Items.Add("Learning")
        TypeCBox.Items.Add("Entertainment")
        TypeCBox.Items.Add("Training")
        TypeCBox.Items.Add("Other")
        Dim c As Integer = FreeFile()
        Dim n As Integer
        FileOpen(c, "Activity", OpenMode.Input)
        Input(c, n)
        Do Until EOF(c)
            Input(c, NameOfActivity)
            Input(c, type)
            Input(c, detail)
            If TImeline.AddNameOfActivity = NameOfActivity Then
                TypeCBox.SelectedItem = type
                RichTextBox1.Text = detail
                Exit Do
            End If
        Loop
        FileClose(c)
    End Sub

    Private Sub CancelCmd_Click(sender As Object, e As EventArgs) Handles CancelCmd.Click
        Dim a As New SelectNewActivity
        SelectNewActivity.FormSelected = "Timeline"
        Me.Hide()
        Me.Close()
        a.ShowDialog()
    End Sub

    Private Sub SelectDataCmd_Click(sender As Object, e As EventArgs) Handles SelectDataCmd.Click
        If SelectDataCmd.Text = "Hide" Then
            MonthCalendar1.Visible = False
            SelectDataCmd.Text = "Select"
        Else
            MonthCalendar1.Visible = True
            SelectDataCmd.Text = "Hide"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(HoursCbox.Text)
    End Sub

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        SelectDataCmd.Text = MonthCalendar1.SelectionRange.Start.ToShortDateString()
        MonthCalendar1.Visible = False
    End Sub

    Private Sub AddCmd_Click(sender As Object, e As EventArgs) Handles AddCmd.Click
        If SelectDataCmd.Text = "Select" Or SelectDataCmd.Text = "Hide" Then
            MsgBox("Pls, insert the data", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        If TypeCBox.Text = "" Then
            TypeCBox.SelectedIndex = 3
        End If
        If RichTextBox1.Text = Nothing Then
            RichTextBox1.Text = "In General"
        End If
        TImeline.AddData = SelectDataCmd.Text
        TImeline.AddTime = HoursCbox.Text & ":" & MinCBox.Text & ":" & SecCBox.Text
        TImeline.AddType = TypeCBox.Text
        TImeline.AddDetail = RichTextBox1.Text
        TImeline.Add = "Yes"
        Me.Close()
    End Sub
End Class