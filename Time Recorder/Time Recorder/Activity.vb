Public Class Activity
    Dim NameOfActivity, type, type2, type3, detail As String
    Public Shared IFClose As Boolean
    Dim c, Check, index As Integer
    Dim a As Integer = FreeFile()
    Dim combo As New DataGridViewComboBoxCell
    Dim StopAdd As Boolean
    Dim number As Integer
    Dim IfOpen As Boolean

    Private Sub deleteCmd_Click(sender As Object, e As EventArgs) Handles deleteCmd.Click
        StopAdd = True
        Dim n As Integer = DataGridView1.CurrentRow.Index
        DataGridView1.Rows.RemoveAt(n)
        Check -= 1
        c -= 1
        StopAdd = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DataGridView1.Rows(0).Cells(1).Value = type3
        Timer1.Stop()
    End Sub

    Private Sub ResetBackColor()
        For y = 0 To 2
            For x = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(x).Cells(y).Style.BackColor = Color.White
            Next
        Next
    End Sub

    Private Sub TypeValue(ByVal n As String, ByRef n2 As String)
        combo.Items.Add("Learning")
        combo.Items.Add("Entertainment")
        combo.Items.Add("Training")
        combo.Items.Add("Other")
        Select Case n
            Case "Learning"
                n2 = combo.Items(0)
            Case "Entertainment"
                n2 = combo.Items(1)
            Case "Training"
                n2 = combo.Items(2)
            Case "Other"
                n2 = combo.Items(3)
        End Select
    End Sub
    Private Sub Activity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StopAdd = True
        index = 0
        IFClose = False
        DataGridView1.Columns(0).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", DefaultFont.Size, FontStyle.Bold)
        If IO.File.Exists("Activity") Then
            a = FreeFile()
            FileOpen(a, "Activity", OpenMode.Input)
            Input(a, number)
            Do Until DataGridView1.Rows.Count = number + 1
                DataGridView1.Rows.Insert(0, 1)
                Dim cc As New DataGridViewComboBoxCell
                cc.Items.Clear()
                cc.Items.Add("Learning")
                cc.Items.Add("Entertainment")
                cc.Items.Add("Training")
                cc.Items.Add("Other")
                Try
                    DataGridView1.Item(1, 0) = cc
                Catch
                    MsgBox("Insert the name,pls")
                    FileClose(a)
                    Exit Sub
                End Try
            Loop
            Do Until EOF(a)
                Input(a, NameOfActivity)
                Input(a, type)
                TypeValue(type, type2)
                Input(a, detail)
                DataGridView1.Rows(index).Cells(0).Value = NameOfActivity
                DataGridView1.Rows(index).Cells(1).Value = type2
                If index = 0 Then
                    type3 = type2
                End If
                DataGridView1.Rows(index).Cells(2).Value = detail
                index += 1
            Loop
            FileClose(a)
            c = DataGridView1.Rows.Count - 1
        End If
        StopAdd = False
        Timer1.Start()
        ResetBackColor()
    End Sub


    Private Sub SaveCmd_Click(sender As Object, e As EventArgs) Handles SaveCmd.Click
        For i = 1 To DataGridView1.Rows.Count - 1
            Try
                NameOfActivity = DataGridView1.Rows(i - 1).Cells(0).Value.ToString
            Catch
                MsgBox("Pls, insert the Name of Activity")
                DataGridView1.Rows(i - 1).Cells(0).Style.BackColor = Color.Red
                If IfOpen = True Then
                    FileClose(c)
                    IfOpen = False
                End If
                Exit Sub
            End Try
            If DataGridView1.Rows(i - 1).Cells(1).Value = Nothing Then
                DataGridView1.Rows(i - 1).Cells(1).Value = "Other"
            End If
            type = DataGridView1.Rows(i - 1).Cells(1).Value.ToString

            If DataGridView1.Rows(i - 1).Cells(2).Value = Nothing Then
                DataGridView1.Rows(i - 1).Cells(2).Value = "In General"
            End If
            detail = DataGridView1.Rows(i - 1).Cells(2).Value.ToString

            If i = 1 Then
                FileOpen(c, "Activity", OpenMode.Output)
                WriteLine(c, DataGridView1.Rows.Count - 1)
                IfOpen = True
            End If
            Write(c, NameOfActivity)
            Write(c, type)
            WriteLine(c, detail)
        Next
        IFClose = True
        FileClose(c)
        Me.Close()
    End Sub


    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If StopAdd = False Then
            If Check <> DataGridView1.Rows.Count Then
                Dim cc As New DataGridViewComboBoxCell
                cc.Items.Clear()
                cc.Items.Add("Learning")
                cc.Items.Add("Entertainment")
                cc.Items.Add("Training")
                cc.Items.Add("Other")
                Try
                    DataGridView1.Item(1, c) = cc
                Catch
                    MsgBox("Insert the name first,pls")
                    Exit Sub
                End Try
                c += 1
                Check = DataGridView1.Rows.Count
            End If
        End If
    End Sub
End Class