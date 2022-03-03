Public Class PartyPopper

    Public WithEvents T As New Timer

    Dim BallList As New List(Of Ball)

    Public Popper As PictureBox

    Public Sub New(ClickPos As Point)
        Popper = GetPopper(ClickPos)
        Form1.Controls.Add(Popper)
        Popper.BringToFront()
        T.Interval = 60
        T.Start()
        BallList.Add(New Ball(Popper))
    End Sub

    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick
        BallList.Add(New Ball(Popper))
        For i = BallList.Count - 1 To 0 Step -1
            BallList(i).UpdatePos()
            If BallList(i).Top > Form1.Height Then
                Form1.Controls.Remove(BallList(i))
                BallList.Remove(BallList(i))
            End If
        Next
    End Sub
    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As New PictureBox
        Pop.BackColor = Color.White
        Pop.Size = New Size(32, 32)
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function
    Private Class Ball
        Inherits PictureBox
        Public Shared Dimension As Integer = 10
        Public xs As Integer
        Public ys As Integer
        Sub New(PopperParent As PictureBox)
            Form1.Controls.Add(Me)
            Me.Size = New Size(Dimension, Dimension)
            Me.Left = PopperParent.Left + Dimension / 2
            Me.Top = PopperParent.Top + Dimension / 2
            Assign()
        End Sub
        Sub UpdatePos()
            ys += 3
            Me.Left += xs
            Me.Top += ys
        End Sub
        Private Sub Assign()
            Dim PartyCols() As Color = {Color.Red, Color.Yellow, Color.Green, Color.Pink, Color.LightBlue}
            Randomize()
            ys = -40 + (Int(Rnd() * 10) + 1)
            xs = (Int(Rnd() * 30)) - 15
            Me.BackColor = PartyCols(Int(Rnd() * (PartyCols.Length)))
        End Sub
    End Class
End Class
