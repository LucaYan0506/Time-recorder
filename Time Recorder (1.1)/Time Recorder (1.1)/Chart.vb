
Public Class Chart
    Dim h, m As Double
    Dim s As Integer
    Dim Point_position As Integer
    Dim AllData_forChart As New DataType
    Dim index As Integer
    Dim first As Boolean = True
    Public Class DataType
        Public data(10000) As Date
        Public time(10000) As Double
        Public name(10000) As String
        Function initialize()
            For i = 0 To TImeline.index
                data(i) = Nothing
                time(i) = Nothing
            Next
            Return 0
        End Function

    End Class

    Private Sub Upload_AllData_in_chart(ByVal record As DataType)
        Dim Total_Hours As Double

        'show the value of each data as a label
        Chart1.Series(0).IsValueShownAsLabel = True
        Chart1.Series(0).LabelFormat = "F2"
        Chart1.Series(0).LabelBackColor = Color.White
        Chart1.Series(0).Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)


        'set the name of the serie
        Chart1.Series(0).Name = TImeline.ItemName

        'insert data in the chart and set Total_hours
        For i = 0 To index
            Me.Chart1.Series(0).Points.AddXY(record.data(i), record.time(i))
            Total_Hours += record.time(i)
        Next

        Dim average_hours As Double = Total_Hours / TImeline.Total_days
        'convert average hours in normal time (with hours, minutes and seconds)
        Dim a As String = String.Format("{0:F2}", average_hours)
        'find the position of "."
        Point_position = a.IndexOf(".")
        If Point_position = -1 Then
            h = a
            m = 0
            a = String.Format("{0:F2}", h)
        Else
            'set the hours
            h = Mid(a, 1, Point_position)
            'set minutes (with second)
            m = Mid(a, Point_position + 2) * 0.6
            'set seconds
            a = String.Format("{0:F2}", m)
        End If

        Point_position = a.IndexOf(".")

        If Point_position = -1 Then
            m = a
            s = 0
        Else
            s = Mid(a, Point_position + 2) * 0.6
            'set minuts
            m = Mid(a, 1, Point_position)
        End If

        AverageLbl.Text = h & "h " & m & "m " & s & "s"


        'set the size of the serie
        Chart1.ChartAreas(0).AxisX.ScaleView.Size = 5
        'set the size of the scrollbar
        Chart1.ChartAreas(0).AxisX.ScrollBar.Size = 20
        'set the color of the scrollbar 
        Chart1.ChartAreas(0).AxisX.ScrollBar.BackColor = Color.LightGray
        Chart1.ChartAreas(0).AxisX.ScrollBar.ButtonColor = Color.Gray

        'set dateLbl
        DateLbl.Text = Mid(TImeline.button2_text, 1, 10) & "-" & Mid(TImeline.button3_text, 1, 10)

        If TImeline.button2_text = "From" Or TImeline.button3_text = "To" Then
            DateLbl.Text = TImeline.firstDate & "-" & TImeline.lastDate
        End If
    End Sub

    Private Sub Select_TypeChart(ByVal Type As String)
        Dim a As Boolean
        If Type = "Daily Chart" Then
            Button1.Location = New Point(508, 360)
            Button1.Size = New Size(250, 55)
            a = False
        Else
            a = True
            Button1.Location = New Point(624, 375)
            Button1.Size = New Size(127, 40)
        End If
        'set all label and chart 
        'all data chart
        AverageLbl.Visible = a
        DateLbl.Visible = a
        Label1.Visible = a
        Label2.Visible = a
        Chart1.Visible = a
        Min_valueLbl.Visible = a
        Max_valueLbl.Visible = a
        Label4.Visible = a
        Label5.Visible = a

        'daily chart
        Chart2.Visible = Not a
        MonthCalendar1.Visible = Not a
        Label3.Visible = Not a
        TotalOfHours.Visible = Not a

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sender.text = "Daily Chart" Then
            'change chart
            Select_TypeChart(sender.text)
            sender.text = "All data chart"

        Else
            'change chart
            Select_TypeChart(sender.text)
            sender.text = "Daily Chart"
        End If
    End Sub

    Private Sub CalendarCmd_Click(sender As Object, e As EventArgs)
        If MonthCalendar1.Visible = True Then
            MonthCalendar1.Visible = False
        Else
            MonthCalendar1.Visible = True
        End If
    End Sub

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        Dim Daily_Activity As New DataType
        Dim x As Integer
        Dim found As Boolean = False
        Dim total As Double = 0

        'new series
        Chart2.Series.Clear()
        Chart2.Series.Add(MonthCalendar1.SelectionStart.ToString("d"))

        'show the value of each data as a label
        Chart2.Series(0).IsValueShownAsLabel = True
        Chart2.Series(0).LabelFormat = "F2"
        Chart2.Series(0).LabelBackColor = Color.White
        Chart2.Series(0).Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)

        'search
        For i = 0 To TImeline.index - 1
            If MonthCalendar1.SelectionStart.ToString("d") = TImeline.Record.data(i) Then
                Daily_Activity.time(x) = TImeline.Record.time(i)
                Daily_Activity.name(x) = TImeline.Record.name(i)
                found = True
                x += 1
            End If
        Next

        'add the time when there are the same activities (with same name)
        For i = 0 To x - 1
            For y = i + 1 To x - 1
                If Daily_Activity.name(i) = Daily_Activity.name(y) Then
                    Daily_Activity.time(i) += Daily_Activity.time(y)
                    'named "Null" the activity that has been added
                    Daily_Activity.name(y) = "Null"
                End If
            Next
        Next

        'show all data except "Null" activities on chart
        If found = True Then
            For i = 0 To x - 1
                If Daily_Activity.name(i) <> "Null" Then
                    Chart2.Series(0).Points.AddXY(Daily_Activity.name(i), Daily_Activity.time(i))

                    'calculate total of hours
                    total += Daily_Activity.time(i)
                End If
            Next

            'convert hours to normal time (hh : mm : ss)
            Dim h, m, s As Double
            Dim Point_position As Integer = total.ToString.IndexOf(".")
            If Point_position = -1 Then
                h = total
            Else
                h = Mid(total.ToString, 1, Point_position)
            End If
            If Point_position = -1 Then
                m = 0
            Else
                m = Mid(total.ToString, Point_position + 1) * 60

            End If

            Point_position = m.ToString.IndexOf(".")
            If Point_position = -1 Then
                s = 0
            Else
                s = Mid(m.ToString, Point_position + 1) * 60
                m = Mid(m.ToString, 1, Point_position)
            End If

            TotalOfHours.Text = h & "h " & m & "m " & CInt(s) & "s"
        Else
            MsgBox("Didn't find any activity on " & MonthCalendar1.SelectionStart.ToString("d") & vbCrLf & "Or " & MonthCalendar1.SelectionStart.ToString("d") & " is out of the range", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub monthcalendar_datachange()
        Dim Daily_Activity As New DataType
        Dim x As Integer
        Dim found As Boolean = False
        Dim total As Double = 0

        'new series
        Chart2.Series.Clear()
        Chart2.Series.Add(MonthCalendar1.SelectionStart.ToString("d"))

        'show the value of each data as a label
        Chart2.Series(0).IsValueShownAsLabel = True
        Chart2.Series(0).LabelFormat = "F2"
        Chart2.Series(0).LabelBackColor = Color.White
        Chart2.Series(0).Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)

        'search
        For i = 0 To TImeline.index - 1
            If MonthCalendar1.SelectionStart.ToString("d") = TImeline.Record.data(i) Then
                Daily_Activity.time(x) = TImeline.Record.time(i)
                Daily_Activity.name(x) = TImeline.Record.name(i)
                found = True
                x += 1
            End If
        Next

        'add the time when there are the same activities (with same name)
        For i = 0 To x - 1
            For y = i + 1 To x - 1
                If Daily_Activity.name(i) = Daily_Activity.name(y) Then
                    Daily_Activity.time(i) += Daily_Activity.time(y)
                    'named "Null" the activity that has been added
                    Daily_Activity.name(y) = "Null"
                End If
            Next
        Next

        'show all data except "Null" activities on chart
        If found = True Then
            For i = 0 To x - 1
                If Daily_Activity.name(i) <> "Null" Then
                    Chart2.Series(0).Points.AddXY(Daily_Activity.name(i), Daily_Activity.time(i))

                    'calculate total of hours
                    total += Daily_Activity.time(i)
                End If
            Next

            'convert hours to normal time (hh : mm : ss)
            Dim h, m, s As Double
            Dim Point_position As Integer = total.ToString.IndexOf(".")
            If Point_position = -1 Then
                h = total
                m = 0
            Else
                h = Mid(total.ToString, 1, Point_position)
                m = Mid(total.ToString, Point_position + 1) * 60
            End If

            Point_position = m.ToString.IndexOf(".")
            If Point_position = -1 Then
                s = 0
            Else
                s = Mid(m.ToString, Point_position + 1) * 60
                m = Mid(m.ToString, 1, Point_position)
            End If

            TotalOfHours.Text = h & "h " & m & "m " & CInt(s) & "s"
        Else
            MsgBox("Didn't find any activity on " & MonthCalendar1.SelectionStart.ToString("d") & vbCrLf & "Or " & MonthCalendar1.SelectionStart.ToString("d") & " is out of the range", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Chart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If first = True Then
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'Show all data chart 

            index = 0
            'save the first one
            AllData_forChart.data(0) = TImeline.Record.data(0)
            AllData_forChart.time(0) = TImeline.Record.time(0)


            'save the rest of data
            For i = 1 To TImeline.index - 1
                'check if the activity and the previous one is in the same data, if so add them together, otherwise save in another variable
                If TImeline.Record.data(i - 1) = TImeline.Record.data(i) Then
                    AllData_forChart.time(index) += TImeline.Record.time(i)
                Else
                    index += 1
                    AllData_forChart.data(index) = TImeline.Record.data(i)
                    AllData_forChart.time(index) = TImeline.Record.time(i)
                End If
            Next
            Upload_AllData_in_chart(AllData_forChart)

            'Find max value and min value
            Dim max As Double = AllData_forChart.time(0)
            Dim min As Double = AllData_forChart.time(0)
            Dim resultMax As Date = AllData_forChart.data(0)
            Dim resultMin As Date = AllData_forChart.data(0)

            For i = 1 To index
                'max
                If max < AllData_forChart.time(i) Then
                    max = AllData_forChart.time(i)
                    resultMax = AllData_forChart.data(i)
                End If

                'min
                If min > AllData_forChart.time(i) Then
                    min = AllData_forChart.time(i)
                    resultMin = AllData_forChart.data(i)
                End If
            Next

            'show result
            Min_valueLbl.Text = resultMin.ToString("d") & " (" & min.ToString("F2") & "h)"
            Max_valueLbl.Text = resultMax.ToString("d") & " (" & max.ToString("F2") & "h)"



            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'show daily chart

            'show the value of each data as a label
            Chart2.Series(0).IsValueShownAsLabel = True
            Chart2.Series(0).LabelFormat = "F2"
            Chart2.Series(0).LabelBackColor = Color.White
            Chart2.Series(0).Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)
            Chart2.Series(0).IsValueShownAsLabel = True

            'set the name of the series 
            Chart2.Series(0).Name = TImeline.Record.data(1).ToString("d")

            'add data and clear the previous one  
            MonthCalendar1.SetDate(TImeline.Record.data(0))
            monthcalendar_datachange()
            Chart2.Visible = False
            first = False
        End If
    End Sub




End Class