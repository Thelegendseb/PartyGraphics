Public Class PartyPopper

    Public Base As New PopperFundamentals

    Public WithEvents T As New Timer

    Public Sub New(ClickPos As Point)
        'have warning if we know its possible to offscreen particles  ?
        Base.Popper = GetPopper(ClickPos)
        Form1.Controls.Add(Base.Popper)
        Base.Popper.BringToFront()
        T.Interval = 60
        T.Start()
        Base.CoreMoveObjList.Add(New GravObj(Base.Popper, AssignParticleSpeedX, AssignParticleSpeedY))
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
        Base.CoreMoveObjList.Add(New GravObj(Base.Popper, AssignParticleSpeedX, AssignParticleSpeedY))
        For i = Base.CoreMoveObjList.Count - 1 To 0 Step -1
            Base.CoreMoveObjList(i).UpdatePos()
            If Base.CoreMoveObjList(i).Bounds.IntersectsWith(Form1.Bounds) = False Then
                Form1.Controls.Remove(Base.CoreMoveObjList(i))
                Base.CoreMoveObjList.Remove(Base.CoreMoveObjList(i))
            End If
        Next
        '---------------------------------|
    End Sub
    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As New PictureBox
        Pop.BackColor = Color.White
        Pop.Size = New Size(32, 32)
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function

    Public Sub DisposeObj()
        T.Stop()
        Base.CoreMoveObjList.Clear()
    End Sub
End Class