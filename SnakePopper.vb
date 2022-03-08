Public Class SnakePopper

    Inherits PartyObjBase

    Private MouseTracks As New List(Of Point)

    Public Sub New(ClickPos As Point)
        ObeysGravity = False
        Popper = GetPopper(ClickPos)
        InitiatePopper()
    End Sub

    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick

        TotalTimerTicks += 1

        If TotalTimerTicks <= 20 Then
            MouseTracks.Add(GetMousePos)
            CoreMoveObjList.Add(New Particle(Popper, 0, 0))
        Else

            For i = CoreMoveObjList.Count - 1 To 0 Step -1

                CoreMoveObjList(i).Left = MouseTracks(MouseTracks.Count - 1 - i).X 'like a 0-> loop
                CoreMoveObjList(i).Top = MouseTracks(MouseTracks.Count - 1 - i).Y

                CoreMoveObjList(i).UpdatePos_Custom(ObeysGravity, ComputeSpeedX(i), ComputeSpeedY(i))


                RemoveOutOfBoundsParticles(CoreMoveObjList(i))
                MouseTracks.Add(GetMousePos)
                MouseTracks.RemoveAt(0)
            Next
        End If

    End Sub
    '=========================
    'HAVE REFRENCE TO POPPER LOCATION
    'SO PARTICLES DONT STACK - ATTRACTIVE FORCE E.G.
    '=========================
    Private Function ComputeSpeedX(CurrentObjIndex As Integer) As Integer
        Dim val As Integer

        Return val
    End Function

    Private Function ComputeSpeedY(CurrentObjIndex As Integer) As Integer
        Dim val As Integer

        Return val
    End Function
    '=========================

    Private Function GetPopper(ClickPos As Point) As PictureBox
        Dim Pop As PictureBox = PopperBase()
        Pop.Location = New Point(ClickPos.X - 16, ClickPos.Y - 16)
        Return Pop
    End Function

End Class
