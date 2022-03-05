Public Class PopperFundamentals

    Public CoreMoveObjList As New List(Of Particle)

    Public ObeysGravity As Boolean

    Public Popper As PictureBox

    Public WithEvents T As New Timer

    Public Sub DisposeObj()
        T.Stop()
        Form1.Controls.Remove(Popper)
        For Each Obj In CoreMoveObjList
            Form1.Controls.Remove(Obj)
        Next
        CoreMoveObjList.Clear()
    End Sub

End Class
