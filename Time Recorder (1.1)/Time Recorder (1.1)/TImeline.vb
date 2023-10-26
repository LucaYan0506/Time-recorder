Public Class TImeline
    Public Shared AddData, AddTime, AddNameOfActivity, AddType, AddDetail, Add, Combobox_selectedText As String
    Dim data(10000) As Date
    Dim time(10000) As String
    Dim NameOfActivity(10000) As String
    Dim type(10000) As String
    Dim detail(10000) As String
    Dim a, TotalDays_default As Integer
    Dim DT As New DataTable
    Dim check As Boolean = False
    Dim saved As Boolean
    Public Shared Record As New DataType
    Public Shared index,Total_days As Integer
    Public Shared ItemName As String
    Dim Form As New Chart
    Public Shared firstDate, lastDate As Date
    Public Shared button2_text As String = "From"
    Public Shared button3_text As String = "To"

    Public Class DataType
        Public data(10000) As Date
        Public time(10000) As Double
        Public name(10000) As String
        Function initialize()
            For i = 0 To index
                data(i) = Nothing
                time(i) = Nothing
                name(i) = Nothing
            Next
            Return 0
        End Function
    End Class

    Private Sub Filter()
        If IO.File.Exists("Timeline") Then
            Dim c As Integer = 0
            Dim data2(10000) As String
            Dim time2(10000) As String
            Dim NameOfActivity2(10000) As String
            Dim type2(10000) As String
            Dim detail2(10000) As String
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
                    Dim NewDate(10000) As Date
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
        End If
        If DataGridView1.RowCount < 12 Then
            Button1.Visible = True
        Else
            Button1.Visible = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Combobox_selectedText = ComboBox1.Text
        Filter()
    End Sub

    Private Sub DeleteCmd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteCmd.Click
        Try
            saved = False
            Dim data2, time2, name2, type2, detail2 As String
            data2 = DataGridView1.CurrentRow.Cells(0).Value
            time2 = DataGridView1.CurrentRow.Cells(1).Value
            name2 = DataGridView1.CurrentRow.Cells(2).Value
            type2 = DataGridView1.CurrentRow.Cells(3).Value
            detail2 = DataGridView1.CurrentRow.Cells(4).Value

            DT.Rows.Clear()
            For i = 0 To a - 1
                DT.Rows.Add(data(i + 1), time(i + 1), NameOfActivity(i + 1), type(i + 1), detail(i + 1))
            Next
            For x = 0 To a - 1
                Dim datamid As String
                datamid = Mid(DT.Rows(x).ItemArray(0), 1, 10)
                If datamid = data2 And DT.Rows(x).ItemArray(1) = time2 And DT.Rows(x).ItemArray(2) = name2 And DT.Rows(x).ItemArray(3) = type2 And DT.Rows(x).ItemArray(4) = detail2 Then
                    DT.Rows.RemoveAt(x)
                    a -= 1
                    For i = x + 1 To 9998
                        data(i) = data(i + 1)
                        time(i) = time(i + 1)
                        NameOfActivity(i) = NameOfActivity(i + 1)
                        type(i) = type(i + 1)
                        detail(i) = detail(i + 1)
                    Next
                    Exit For
                End If
            Next
            DataGridView1.DataSource = DT
            Filter()
        Catch
            a = 0
            MsgBox("There isn't any data")
        End Try
    End Sub

    Private Sub TImeline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As Integer = FreeFile()
        Try
            If IO.File.Exists("Timeline") Then

                FileOpen(c, "Timeline", OpenMode.Input)
                a = 0
                If check = False Then
                    DT.Columns.Add("Data", GetType(Date))
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
                FileClose(c)


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
            If DataGridView1.RowCount <> 0 Then
                'find the total of days 
                TotalDays_default = 1
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                'save first row of data 
                firstDate = DataGridView1.Rows(0).Cells(0).Value

                'save the rest of data
                For i = 1 To DataGridView1.RowCount - 1
                    If DataGridView1.Rows(i - 1).Cells(0).Value = DataGridView1.Rows(i).Cells(0).Value Then

                    Else
                        TotalDays_default += 1
                        lastDate = DataGridView1.Rows(i).Cells(0).Value

                    End If
                Next
            End If

            'create a block to cover when it is need
            Button1.Enabled = False
            Button1.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(c)
            Dim result As MsgBoxResult
            result = MsgBox("You are achieved the limit of data that you can storage.Do you want to delete all of them?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Critical, "Error")
            If result = vbYes Then
                Dim result2 As MsgBoxResult
                result2 = MsgBox("Once you delete it you can't restore them, are you sure to delete?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Message")
                If result2 = vbYes Then
                    IO.File.Delete("D:\School\IT\Visual Basic\Time Recorder\Time Recorder (1.1)\Time Recorder (1.1)\bin\Debug\Timeline")
                End If
            End If
            saved = True
            Me.Close()
        End Try
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
            button2_text = "From"
        End If
        Filter()
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        saved = False
        Dim index As Integer = 0
            For i = 0 To a
                Select Case DataGridView1.CurrentCell.ColumnIndex
                    Case 0
                        If time(i) = DataGridView1.CurrentRow.Cells(1).Value And NameOfActivity(i) = DataGridView1.CurrentRow.Cells(2).Value And type(i) = DataGridView1.CurrentRow.Cells(3).Value And detail(i) = DataGridView1.CurrentRow.Cells(4).Value Then
                            index = i
                        End If
                    Case 1
                        If data(i) = DataGridView1.CurrentRow.Cells(0).Value And NameOfActivity(i) = DataGridView1.CurrentRow.Cells(2).Value And type(i) = DataGridView1.CurrentRow.Cells(3).Value And detail(i) = DataGridView1.CurrentRow.Cells(4).Value Then
                            index = i
                        End If
                    Case 2
                        If data(i) = DataGridView1.CurrentRow.Cells(0).Value And time(i) = DataGridView1.CurrentRow.Cells(1).Value And type(i) = DataGridView1.CurrentRow.Cells(3).Value And detail(i) = DataGridView1.CurrentRow.Cells(4).Value Then
                            index = i
                        End If
                    Case 3
                        If data(i) = DataGridView1.CurrentRow.Cells(0).Value And time(i) = DataGridView1.CurrentRow.Cells(1).Value And NameOfActivity(i) = DataGridView1.CurrentRow.Cells(2).Value And detail(i) = DataGridView1.CurrentRow.Cells(4).Value Then
                            index = i
                        End If
                    Case 4
                        If data(i) = DataGridView1.CurrentRow.Cells(0).Value And time(i) = DataGridView1.CurrentRow.Cells(1).Value And NameOfActivity(i) = DataGridView1.CurrentRow.Cells(2).Value And type(i) = DataGridView1.CurrentRow.Cells(3).Value Then
                            index = i
                        End If
                End Select



            Next




            Select Case DataGridView1.CurrentCell.ColumnIndex
            Case 0
                Try
                    data(index) = DataGridView1.CurrentCell.Value
                Catch ex As Exception
                    MessageBox.Show("pls insert the date in this format (dd/mm/yyyy)")
                    data(index) = DataGridView1.CurrentCell.Value
                End Try
            Case 1
                Try
                    Dim curr_time = DataGridView1.CurrentCell.Value

                    Dim a As Integer = Integer.Parse(curr_time(0))
                    a = Integer.Parse(curr_time(1))
                    a = Integer.Parse(curr_time(3))
                    a = Integer.Parse(curr_time(4))
                    a = Integer.Parse(curr_time(6))
                    a = Integer.Parse(curr_time(7))
                    If curr_time(2) <> ":" And curr_time(5) <> ":" Then
                        a = Integer.Parse("f")
                    End If

                    time(index) = DataGridView1.CurrentCell.Value
                Catch ex As Exception
                    MessageBox.Show("pls insert as the this format (hh:mm:ss)")
                    DataGridView1.CurrentCell.Value = time(index)
                End Try
            Case 2
                Try
                    NameOfActivity(index) = DataGridView1.CurrentCell.Value
                Catch
                    NameOfActivity(index) = "In General"
                    DataGridView1.CurrentCell.Value = "In General"
                End Try
            Case 3
                Dim curr_type = DataGridView1.CurrentCell.Value

                If curr_type = "Learning" Or curr_type = "Entertainment" Or curr_type = "Training" Or curr_type = "Other" Then
                    type(index) = curr_type
                Else
                    Dim msg As String
                    msg = "pls type one of the following types :" & vbCrLf & "1) Learning" & vbCrLf & "2) Entertainment" & vbCrLf & "3) Training" & vbCrLf & "4) Other"
                    MsgBox(msg)
                    DataGridView1.CurrentCell.Value = type(index)
                End If
            Case 4
                Try
                    detail(index) = DataGridView1.CurrentCell.Value
                Catch
                    detail(index) = "In General"
                    DataGridView1.CurrentCell.Value = "In General"
                End Try

        End Select
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        If e.ColumnIndex = 0 Then
            MessageBox.Show("pls enter a valid date")
            e.Cancel = True
        End If
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
            button3_text = "To"
        End If
        Filter()
    End Sub


    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        firstDate = sender.SelectionRange.Start
        Button2.Text = MonthCalendar1.SelectionRange.Start.ToShortDateString()
        button2_text = MonthCalendar1.SelectionRange.Start.ToShortDateString()
        MonthCalendar1.Visible = False
        Filter()
    End Sub
    Private Sub MonthCalendar2_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar2.DateSelected
        lastDate = sender.SelectionRange.Start
        Button3.Text = MonthCalendar2.SelectionRange.Start.ToShortDateString()
        button3_text = MonthCalendar2.SelectionRange.Start.ToShortDateString()
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
                For y = 0 To 3
                    Write(c, DT.Rows(x).ItemArray(y))
                Next
                WriteLine(c, DT.Rows(x).ItemArray(4))
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
        Dim h(10000) As Integer
        Dim m(10000) As Integer
        Dim s(10000) As Integer
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

    Private Sub ChartCMD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChartCMD.Click
        Record.initialize()
        index = 0

        If DataGridView1.RowCount <> 0 Then
            Dim h, m, s, total As Double
            DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            'save time
            h = Mid(DataGridView1.Rows(0).Cells(1).Value.ToString, 1, 2)
            m = Mid(DataGridView1.Rows(0).Cells(1).Value.ToString, 4, 2)
            s = Mid(DataGridView1.Rows(0).Cells(1).Value.ToString, 7, 2)
            total = h + m / 60 + s / 3600

            'save all data
            For i = 0 To DataGridView1.RowCount - 1
                h = Mid(DataGridView1.Rows(i).Cells(1).Value.ToString, 1, 2)
                m = Mid(DataGridView1.Rows(i).Cells(1).Value.ToString, 4, 2)
                s = Mid(DataGridView1.Rows(i).Cells(1).Value.ToString, 7, 2)
                total = h + m / 60 + s / 3600
                Record.data(i) = DataGridView1.Rows(i).Cells(0).Value
                Record.time(i) = total
                Record.name(i) = DataGridView1.Rows(i).Cells(2).Value
                index += 1
            Next
        Else
            Record.data(0) = MonthCalendar1.SelectionStart
            Record.data(1) = MonthCalendar2.SelectionStart
        End If

        'set first and last date
        If Button2.Text = "From" Or Button3.Text = "To" Or Button2.Text = "Hide" Or Button3.Text = "Hide" Then
            If DataGridView1.Rows.Count >= 2 Then
                firstDate = DataGridView1.Rows(0).Cells(0).Value
                lastDate = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0).Value
            End If
        End If

        'set name
        ItemName = ComboBox1.Text & "(" & TextBox2.Text & ")"

        'set the  total_days by the selected date
        If Button2.Text <> "From" And Button3.Text <> "To" Then
            Dim diff As Integer = DateDiff(DateInterval.Day, MonthCalendar2.SelectionRange.Start.Date, MonthCalendar1.SelectionRange.Start.Date)
            Total_days = -diff + 1
        Else
            Total_days = TotalDays_default
        End If
        'show chart
        Form = New Chart

        Form.Show()

    End Sub

    
End Class