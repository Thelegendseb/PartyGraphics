Public Class SpiralPopper

    Inherits PartyObjBase

    Private SpeedPresets(11) As Speed

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
        SpeedLooper += 1

        CoreMoveObjList.Add(New Particle(Popper, AssignParticleSpeedX, AssignParticleSpeedY))

        For i = CoreMoveObjList.Count - 1 To 0 Step -1

            CoreMoveObjList(i).UpdatePos(ObeysGravity)
            i = PreventLag(i)
            RemoveOutOfBoundsParticles(CoreMoveObjList(i))
        Next

        If SpeedLooper = 11 Then
            SpeedLooper = 0
        End If

    End Sub

    Private Function Variance() As Integer
        Dim Limit As Integer = 4
        Randomize()
        Return Int(Rnd() * (Limit * 2)) - Limit
    End Function

    Private Function AssignParticleSpeedX()
        Return SpeedPresets(SpeedLooper).x + Variance()
    End Function
    Private Function AssignParticleSpeedY()
        Return SpeedPresets(SpeedLooper).y + Variance()
    End Function

    Private Sub InitiateSpeedPresets()
        SpeedPresets(0) = New Speed(0, -20)
        SpeedPresets(1) = New Speed(6, -12)
        SpeedPresets(2) = New Speed(12, -6)
        SpeedPresets(3) = New Speed(20, 0)
        SpeedPresets(4) = New Speed(12, 6)
        SpeedPresets(5) = New Speed(6, 12)
        SpeedPresets(6) = New Speed(0, 20)
        SpeedPresets(7) = New Speed(-12, 6)
        SpeedPresets(8) = New Speed(-6, 12)
        SpeedPresets(9) = New Speed(-20, 0)
        SpeedPresets(10) = New Speed(-12, -6)
        SpeedPresets(11) = New Speed(-6, -12)
    End Sub

    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As PictureBox = PopperBase()
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function

End Class
