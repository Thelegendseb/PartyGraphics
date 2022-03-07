Public Class RipplePopper

    Inherits PartyObjBase

    Private SpeedPresets(15) As Speed

    Private SpeedLooper As Integer

    Private Class Speed
        Public x As Integer
        Public y As Integer
        Sub New(xin As Integer, yin As Integer)
            x = xin
            y = yin
        End Sub
    End Class

    Public Sub New(ClickPos As Point)
        ObeysGravity = False
        Popper = GetPopper(ClickPos)
        InitiatePopper()
        InitiateSpeedPresets()
    End Sub
    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick

        TotalTimerTicks += 1

        If TotalTimerTicks Mod 30 = 0 Then
            For i = 0 To SpeedPresets.Length - 1
                SpeedLooper = i
                CoreMoveObjList.Add(New Particle(Popper, AssignParticleSpeedX, AssignParticleSpeedY))
            Next
        End If

        For i = CoreMoveObjList.Count - 1 To 0 Step -1

            CoreMoveObjList(i).UpdatePos(ObeysGravity)
            i = PreventLag(i)
            RemoveOutOfBoundsParticles(CoreMoveObjList(i))
        Next

    End Sub

    Private Function AssignParticleSpeedX()
        Return SpeedPresets(SpeedLooper).x
    End Function
    Private Function AssignParticleSpeedY()
        Return SpeedPresets(SpeedLooper).y
    End Function

    Private Sub InitiateSpeedPresets()
        SpeedPresets(0) = New Speed(0, -20)
        SpeedPresets(1) = New Speed(6, -12)
        SpeedPresets(2) = New Speed(8, -8)
        SpeedPresets(3) = New Speed(12, -6)
        SpeedPresets(4) = New Speed(20, 0)
        SpeedPresets(5) = New Speed(12, 6)
        SpeedPresets(6) = New Speed(8, 8)
        SpeedPresets(7) = New Speed(6, 12)
        SpeedPresets(8) = New Speed(0, 20)
        SpeedPresets(9) = New Speed(-12, 6)
        SpeedPresets(10) = New Speed(-8, 8)
        SpeedPresets(11) = New Speed(-6, 12)
        SpeedPresets(12) = New Speed(-20, 0)
        SpeedPresets(13) = New Speed(-12, -6)
        SpeedPresets(14) = New Speed(-8, -8)
        SpeedPresets(15) = New Speed(-6, -12)
    End Sub

    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As PictureBox = PopperBase()
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function

End Class

