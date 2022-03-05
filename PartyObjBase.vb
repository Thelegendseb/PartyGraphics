Public Class PartyObjBase

    Public CoreMoveObjList As New List(Of Particle)

    Public ObeysGravity As Boolean

    Public Popper As PictureBox

    Public WithEvents T As New Timer

    Public TotalTimerTicks As Integer

    Public Sub DisposeObj()
        T.Stop()
        Form1.Controls.Remove(Popper)
        For Each Obj In CoreMoveObjList
            Form1.Controls.Remove(Obj)
        Next
        CoreMoveObjList.Clear()
    End Sub

    Public Sub InitiatePopper()
        Form1.Controls.Add(Popper)
        Popper.BringToFront()
        T.Interval = 60
        T.Start()
    End Sub
    Public Function PreventLag(loopval As Integer) As Integer 'specific use - Example Spiral
        If CoreMoveObjList.Count > 30 Then 'prevent lag - not too many
            Form1.Controls.Remove(CoreMoveObjList(0))
            CoreMoveObjList.RemoveAt(0)
            Return loopval - 1
        End If
        Return loopval
    End Function

    Public Function PopperBase() As PictureBox
        Return New PictureBox With {.BackColor = Color.White, .Size = New Size(32, 32)}
    End Function

End Class
