Public Class TImeline
    Public Shared AddData, AddTime, AddNameOfActivity, AddType, AddDetail, Add As String
    Dim data(100) As Date
    Dim time(100) As String
    Dim NameOfActivity(100) As String
    Dim type(100) As String
    Dim detail(100) As String
    Dim a As Integer
    Dim DT As New DataTable
    Dim check As Boolean = False
    Dim saved As Boolean
    Private Sub Filter()
        Dim c As Integer = 0
        Dim data2(100) As String
        Dim time2(100) As String
        Dim NameOfActivity2(100) As String
        Dim type2(100) As String
        Dim detail2(100) As String
        DT.Rows.Clear()
        For i = 1 To a
            If ComboBox1.SelectedItem = type(i) Then
                DT.Rows.Add(data(i), time(i), NameOfActivity(i), type(i), detail(i))
                c += 1
                data2(c) = data(i)
                time2(c) = time(i)
                NameOfActivity2(c) = NameOfActivity(i)
                type2(c) = type(i)
                detail2(c) = detail(i)
            ElseIf ComboBox1.SelectedItem = "All" Then
                DT.Rows.Add(data(i), time(i), NameOfActivity(i), type(i), detail(i))
                c += 1
                data2(c) = data(i)
                time2(c) = time(i)
                NameOfActivity2(c) = NameOfActivity(i)
                type2(c) = type(i)
                detail2(c) = detail(i)
            End If
        Next
        DT.Rows.Clear()
        For i = 1 To c
            If Button2.Text = "From" Or Button3.Text = "To" Then
                DT.Rows.Add(data2(i), time2(i), NameOfActivity2(i), type2(i), detail2(i))
            ElseIf Button2.Text = "Hide" Or Button3.Text = "Hide" Then
                DT.Rows.Add(data2(i), time2(i), NameOfActivity2(i), type2(i), detail2(i))
            Else
                Dim b As Integer
                Dim NewDate(1000) As Date
                b = DateDiff(DateInterval.Day, CDate(Button2.Text), CDate(Button3.Text))
                For y = 0 To b
                    NewDate(y) = DateAdd(DateInterval.Day, y, CDate(Button2.Text))
                    If NewDate(y) = data2(i) Then
                        DT.Rows.Add(data2(i), time2(i), NameOfActivity2(i), type2(i), detail2(i))
                    End If
                Next
            End If
        Next
        Dim DV As New DataView(DT)
        DV.RowFilter = String.Format("Name like '%{0}%'", Trim(TextBox2.Text.Replace("'", "''")))
        DataGridView1.DataSource = DV
        Dim column As New DataGridViewColumn
        column = DataGridView1.Columns(0)
        column.Width = 74
        column = DataGridView1.Columns(1)
        column.Width = 62
        column = DataGridView1.Columns(2)
        column.Width = 113
        column = DataGridView1.Columns(3)
        column.Width = 110
        column = DataGridView1.Columns(4)
        column.Width = 145
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Filter()
    End Sub

    Private Sub DeleteCmd_Click(sender As Object, e As EventArgs) Handles DeleteCmd.Click
        Try
            saved = False
            Dim data2, time2, name2, type2, detail2 As String
            data2 = DataGridView1.CurrentRow.Cells(0).Value.ToString
            time2 = DataGridView1.CurrentRow.Cells(1).Value.ToString
            name2 = DataGridView1.CurrentRow.Cells(2).Value.ToString
            type2 = DataGridView1.CurrentRow.Cells(3).Value.ToString
            detail2 = DataGridView1.CurrentRow.Cells(4).Value.ToString

            DT.Rows.Clear()
            For i = 0 To a - 1
                DT.Rows.Add(data(i + 1), time(i + 1), NameOfActivity(i + 1), type(i + 1), detail(i + 1))
            Next
            For x = 0 To a - 1
                Dim datamid As String
                datamid = Mid(DT.Rows(x).ItemArray(0), 1, 10)
                If datamid = data2 And DT.Rows(x).ItemArray(1) = time2 And DT.Rows(x).ItemArray(2) = name2 And DT.Rows(x).ItemArray(3) = type2 And DT.Rows(x).ItemArray(4) = detail2 Then
                    DT.Rows.RemoveAt(x)
                    For i = x + 1 To 98
                        data(i) = data(i + 1)
                        time(i) = time(i + 1)
                        NameOfActivity(i) = NameOfActivity(i + 1)
                        type(i) = type(i + 1)
                        detail(i) = detail(i + 1)
                    Next
                    Exit For
                End If
            Next
            a -= 1
            DataGridView1.DataSource = DT
            Filter()
        Catch
            a = 0
            MsgBox("There isn't any data")
        End Try
    End Sub

    Private Sub TImeline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("Timeline") Then
            Dim c As Integer = FreeFile()
            FileOpen(c, "Timeline", OpenMode.Input)
            a = 0
            If check = False Then
                DT.Columns.Add("Data", GetType(String))
                DT.Columns.Add("Time", GetType(String))
                DT.Columns.Add("Name", GetType(String))
                DT.Columns.Add("Type", GetType(String))
                DT.Columns.Add("Detail", GetType(String))
                check = True
            End If
            Do Until EOF(c)
                a += 1
                Input(c, data(a))
                Input(c, time(a))
                Input(c, NameOfActivity(a))
                Input(c, type(a))
                Input(c, detail(a))
            Loop
            FileClose()
        End If
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("Learning")
        ComboBox1.Items.Add("Entertainment")
        ComboBox1.Items.Add("Training")
        ComboBox1.Items.Add("Other")
        ComboBox1.SelectedIndex = 0
        MonthCalendar1.Visible = False
        MonthCalendar2.Visible = False
        saved = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "From" Then
            MonthCalendar1.Visible = True
            Button2.Text = "Hide"
        ElseIf Button2.Text = MonthCalendar1.SelectionRange.Start.ToShortDateString Then
            MonthCalendar1.Visible = True
            Button2.Text = "Hide"
        Else
            MonthCalendar1.Visible = False
            Button2.Text = "From"
        End If
        Filter()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "To" Then
            MonthCalendar2.Visible = True
            Button3.Text = "Hide"
        ElseIf Button3.Text = MonthCalendar2.SelectionRange.Start.ToShortDateString Then
            MonthCalendar2.Visible = True
            Button3.Text = "Hide"
        Else
            MonthCalendar2.Visible = False
            Button3.Text = "To"
        End If
        Filter()
    End Sub

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        Button2.Text = MonthCalendar1.SelectionRange.Start.ToShortDateString()
        MonthCalendar1.Visible = False
        Filter()
    End Sub
    Private Sub MonthCalendar2_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar2.DateSelected
        Button3.Text = MonthCalendar2.SelectionRange.Start.ToShortDateString()
        MonthCalendar2.Visible = False
        Filter()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Filter()
    End Sub

    Private Sub SaveCmd_Click(sender As Object, e As EventArgs) Handles SaveCmd.Click
        Dim result As MsgBoxResult
        result = MsgBox("Do you want to save?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Information, "Message")
        If result = vbYes Then
            Button2.Text = "From"
            TextBox2.Text = ""
            ComboBox1.SelectedIndex = 0
            Filter()
            Dim c As Integer = FreeFile()
            Dim n As Integer = DataGridView1.Rows.Count - 1
            FileOpen(c, "Timeline", OpenMode.Output)
            For x = 0 To n
                For y = 0 To 4
                    Write(c, DT.Rows(x).ItemArray(y))
                Next
            Next
            saved = True
            Me.Close()
            FileClose(c)
        ElseIf result = vbNo Then
            saved = True
            Me.Close()
        End If

    End Sub

    Private Sub TotalCmd_Click(sender As Object, e As EventArgs) Handles TotalCmd.Click
        Dim h(100) As Integer
        Dim m(100) As Integer
        Dim s(100) As Integer
        Dim TotalH, TotalM, TotalS As String
        For i = 0 To DataGridView1.Rows.Count - 1
            h(i) = Mid(DataGridView1.Rows(i).Cells(1).Value.ToString, 1, 2)
            m(i) = Mid(DataGridView1.Rows(i).Cells(1).Value.ToString, 4, 2)
            s(i) = Mid(DataGridView1.Rows(i).Cells(1).Value.ToString, 7, 2)
            TotalH += h(i)
            TotalM += m(i)
            TotalS += s(i)
            If TotalS > 60 Then
                TotalS -= 60
                TotalM += 1
            End If
            If TotalM > 60 Then
                TotalM -= 60
                TotalH += 1
            End If
        Next
        If TotalH < 10 Then
            TotalH = "0" & TotalH
            If TotalH = "0" Then
                TotalH = "00"
            End If
        End If
        If TotalM < 10 Then
            TotalM = "0" & TotalM
            If TotalM = "0" Then
                TotalM = "00"
            End If
        End If
        If TotalS < 10 Then
            TotalS = "0" & TotalS
            If TotalS = "0" Then
                TotalS = "00"
            End If
        End If
        TotalTxt.Text = TotalH & "h " & TotalM & "m " & TotalS & "s"
    End Sub

    Private Sub TImeline_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If saved = False Then
            Dim result As MsgBoxResult
            result = MsgBox("Do you want to save?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Information, "Message")
            If result = vbYes Then
                Button2.Text = "From"
                TextBox2.Text = ""
                ComboBox1.SelectedIndex = 0
                Filter()
                Dim c As Integer = FreeFile()
                Dim n As Integer = DataGridView1.Rows.Count - 1
                FileOpen(c, "Timeline", OpenMode.Output)
                For x = 0 To n
                    For y = 0 To 4
                        Write(c, DT.Rows(x).ItemArray(y))
                    Next
                Next
                FileClose(c)
            ElseIf result = vbCancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub AddCmd_Click(sender As Object, e As EventArgs) Handles AddCmd.Click
        Dim Add As New SelectNewActivity
        Dim Add2 As New AddNewActivity
        saved = False
        SelectNewActivity.FormSelected = "Timeline"
        Add.ShowDialog()
        If TImeline.Add = "Yes" Then
            a += 1
            data(a) = AddData
            time(a) = AddTime
            NameOfActivity(a) = AddNameOfActivity
            type(a) = AddType
            detail(a) = AddDetail
            DT.Rows.Add(AddData, AddTime, AddNameOfActivity, AddType, AddDetail)
            Filter()
            TImeline.Add = "No"
        End If
    End Sub

End Class