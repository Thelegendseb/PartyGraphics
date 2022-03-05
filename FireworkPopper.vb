Public Class FireworkPopper

    Public Base As New PopperFundamentals

    Public WithEvents T As New Timer

    Dim CentralParticle As Particle

    Dim HasBurstOccured As Boolean

    Public Sub New(ClickPos As Point)
        Base.ObeysGravity = True

        Base.Popper = GetPopper(ClickPos)
        Form1.Controls.Add(Base.Popper)
        Base.Popper.BringToFront()
        T.Interval = 60
        T.Start()
        CentralParticle = New Particle(Base.Popper, AssignParticleSpeedX, AssignParticleSpeedY)
    End Sub
    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick
        '-----BASIC LOOP UNIVERSAL---------

        If CentralParticle.ys > 12 Then
            Form1.Controls.Remove(CentralParticle)
            'asCentralPopped = True
            If HasBurstOccured = False Then
                For i = 0 To 19
                    Base.CoreMoveObjList.Add(New Particle(CentralParticle, AssignParticleSpeedX, AssignShowerSpeedY))
                Next
                HasBurstOccured = True
            End If
        Else
            CentralParticle.UpdatePos(Base.ObeysGravity)
        End If


        If HasBurstOccured = True Then
            For i = Base.CoreMoveObjList.Count - 1 To 0 Step -1
                Base.CoreMoveObjList(i).UpdatePos(Base.ObeysGravity)
                If Base.CoreMoveObjList(i).Bounds.IntersectsWith(Form1.Bounds) = False Then
                    Form1.Controls.Remove(Base.CoreMoveObjList(i))
                    Base.CoreMoveObjList.Remove(Base.CoreMoveObjList(i))
                End If
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
        Dim Pop As New PictureBox
        Pop.BackColor = Color.White
        Pop.Size = New Size(32, 32)
        Pop.Location = New Point(ClickPos.X - 16, Form1.Height - Form1.Height / 5) 'test
        Return Pop
    End Function
    Public Sub DisposeObj()
        T.Stop()
        Form1.Controls.Remove(Base.Popper)
        For Each Obj In Base.CoreMoveObjList
            Form1.Controls.Remove(Obj)
        Next
        Base.CoreMoveObjList.Clear()
    End Sub

End Class