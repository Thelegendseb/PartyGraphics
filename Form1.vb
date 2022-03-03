Public Class Form1

    Public PartyCollection As New List(Of PartyPopper)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Init()
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If PartyCollection.Count <> 3 Then
            PartyCollection.Add(New PartyPopper(New Point(e.X, e.Y)))
        Else
            PartyCollection.Clear()
            Me.Controls.Clear()
        End If
    End Sub
    Sub Init()
        Me.BackColor = Color.Black
        Me.Size = MaximumSize
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.CenterToScreen()
    End Sub
End Class