Public Class inactivity_alert
    Public dialogResult As Boolean = False
    Private Sub inactivity_alert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dialogResult = True
        Me.Hide()
    End Sub

    Private Sub inactivity_alert_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        dialogResult = True
    End Sub
End Class