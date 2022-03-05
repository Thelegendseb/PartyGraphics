Public Class SpiralPopper

    Inherits PartyObjBase

    Private P_YS, P_XS As Integer 'specific to spiral popper

    Public Sub New(ClickPos As Point)
        ObeysGravity = False
        Popper = GetPopper(ClickPos)
        InitiatePopper()
    End Sub
    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick
        TotalTimerTicks += 1

        CoreMoveObjList.Add(New Particle(Popper, AssignParticleSpeedX, AssignParticleSpeedY))

        For i = CoreMoveObjList.Count - 1 To 0 Step -1
            CoreMoveObjList(i).UpdatePos(ObeysGravity)
            i = PreventLag(i)
            If CoreMoveObjList(i).Bounds.IntersectsWith(Form1.Bounds) = False Then
                Form1.Controls.Remove(CoreMoveObjList(i))
                CoreMoveObjList.Remove(CoreMoveObjList(i))
            End If
        Next
    End Sub

    '========UNIQUE MATH FOR THE SPIRAL GOES HERE AND IS ASSIGNED TO PARTICLE SPEEDS==============
    '===========values will indavertidly effect xpos and ypos, which is important=================

    ' 10,10 is bottom right, maths involved to simulate same speed but feel same

    'WRITE DIRECTLY TO PARTICLES X AND Y SPEED
    Private Function AssignParticleSpeedX()
        'will be returned in instance create and returned to each particles speed
        Return 10
    End Function
    Private Function AssignParticleSpeedY()
        'will be returned in instance create and returned to each particles speed
        Return 10
    End Function

    '==============================================================================================
    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As PictureBox = PopperBase()
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function

End Class

