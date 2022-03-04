Public Class GravObj
    Inherits PictureBox
    Public Shared Dimension As Integer = 10
    Public xs As Integer
    Public ys As Integer

    Sub New(PopperParent As PictureBox, xsp As Integer, ysp As Integer)
        Me.Size = New Size(Dimension, Dimension)
        Me.Left = PopperParent.Left + Dimension / 2
        Me.Top = PopperParent.Top + Dimension / 2
        Me.xs = xsp
        Me.ys = ysp
        Assign()
        Form1.Controls.Add(Me)
    End Sub

    Sub UpdatePos()
        ys += 3
        Me.Left += xs
        Me.Top += ys
    End Sub

    Private Sub Assign()
        Dim PartyCols() As Color = {Color.Red, Color.Yellow, Color.Green, Color.Pink, Color.LightBlue}
        Me.BackColor = PartyCols(Int(Rnd() * (PartyCols.Length)))
    End Sub
End Class