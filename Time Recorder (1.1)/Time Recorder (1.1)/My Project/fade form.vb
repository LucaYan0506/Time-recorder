Imports System.Runtime.CompilerServices

Public Class fade_form
    Dim op = 0
    Dim s = 10

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles fade_out.Tick
        If op < 0 Then
            Me.Close()
        End If

        op -= 0.05
        Me.Opacity = op
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles fade_in.Tick
        op += 0.05
        Me.Opacity = op

        If op > 1 Then
            fade_in.Stop()
            Timer1.Start()
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        fade_in.Start()
    End Sub

    Private Sub Form1_MouseEnter(sender As Object, e As System.EventArgs) Handles MyBase.MouseEnter
        Timer1.Stop()
        fade_out.Start()
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        s -= 1
        If s = 0 Then
            Timer1.Stop()
            fade_out.Start()
        End If
    End Sub
End Class