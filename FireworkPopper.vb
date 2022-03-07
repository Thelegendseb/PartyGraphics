Public Class FireworkPopper

    Inherits PartyObjBase

    Private ReadOnly CentralParticle As Particle
    'movement of particle is only defined by particles methods

    Private HasBurstOccured As Boolean

    Public Sub New(ClickPos As Point)
        ObeysGravity = True
        Popper = GetPopper(ClickPos)
        InitiatePopper()
        CentralParticle = New Particle(Popper, AssignParticleSpeedX, AssignParticleSpeedY)
    End Sub
    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick
        '-----BASIC LOOP UNIVERSAL---------
        TotalTimerTicks += 1
        If CentralParticle.ys > 12 Then
            Form1.Controls.Remove(CentralParticle)
            'asCentralPopped = True
            If HasBurstOccured = False Then
                For i = 0 To 19
                    CoreMoveObjList.Add(New Particle(CentralParticle, AssignParticleSpeedX, AssignShowerSpeedY))
                Next
                HasBurstOccured = True
            End If
        Else
            CentralParticle.UpdatePos(ObeysGravity)
        End If


        If HasBurstOccured = True Then
            For i = CoreMoveObjList.Count - 1 To 0 Step -1
                CoreMoveObjList(i).UpdatePos(ObeysGravity)
                RemoveOutOfBoundsParticles(CoreMoveObjList(i))
            Next

        End If
        '---------------------------------|
    End Sub

    Private Function AssignParticleSpeedX() As Integer
        Randomize()
        Return (Int(Rnd() * 30)) - 15
    End Function
    Private Function AssignShowerSpeedY() As Integer
        Randomize()
        Return -70 + (Int(Rnd() * 10) + 25)
    End Function
    Private Function AssignParticleSpeedY() As Integer
        Randomize()
        Return -70 + (Int(Rnd() * 10)) + 10
    End Function

    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As PictureBox = PopperBase()
        Pop.Location = New Point(ClickPos.X - 16, Form1.Height - Form1.Height / 5) 'test
        Return Pop
    End Function

End Class