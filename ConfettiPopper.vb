Public Class ConfettiPopper

    Inherits PartyObjBase

    Public Sub New(ClickPos As Point)
        ObeysGravity = True
        Popper = GetPopper(ClickPos)
        InitiatePopper()
    End Sub

    Private Function AssignParticleSpeedX()
        Randomize()
        Return (Int(Rnd() * 30)) - 15
    End Function

    Private Function AssignParticleSpeedY()
        Randomize()
        Return -40 + (Int(Rnd() * 10) + 1)
    End Function

    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick
        '-----BASIC LOOP UNIVERSAL--------|
        TotalTimerTicks += 1
        If TotalTimerTicks Mod 2 <> 0 Then 'half rate of generation
            CoreMoveObjList.Add(New Particle(Popper, AssignParticleSpeedX, AssignParticleSpeedY))
        End If
        For i = CoreMoveObjList.Count - 1 To 0 Step -1
            CoreMoveObjList(i).UpdatePos(ObeysGravity)
            i = PreventLag(i)
            If CoreMoveObjList(i).Bounds.IntersectsWith(Form1.Bounds) = False Then
                Form1.Controls.Remove(CoreMoveObjList(i))
                CoreMoveObjList.Remove(CoreMoveObjList(i))
            End If
        Next
        '---------------------------------|
    End Sub

    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As PictureBox = PopperBase()
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function

End Class