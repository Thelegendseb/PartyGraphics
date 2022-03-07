Public Class SnakePopper

    Inherits PartyObjBase

    Private MouseTracks As New List(Of Point)

    Public Sub New(ClickPos As Point)
        ObeysGravity = False
        Popper = GetPopper(ClickPos)
        InitiatePopper()
    End Sub

    Private Function AssignParticleSpeedX()
        Return 0
    End Function

    Private Function AssignParticleSpeedY()
        Return 0
    End Function

    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick

        TotalTimerTicks += 1


        CoreMoveObjList.Add(New Particle(Popper, AssignParticleSpeedX, AssignParticleSpeedY))



        For i = CoreMoveObjList.Count - 1 To 0 Step -1
            CoreMoveObjList(i).UpdatePos(ObeysGravity)
            i = PreventLag(i)
            RemoveOutOfBoundsParticles(CoreMoveObjList(i))
        Next

    End Sub

    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As PictureBox = PopperBase()
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function

End Class
