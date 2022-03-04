Public Class SpiralPopper

    Public Base As New PopperFundamentals

    Public WithEvents T As New Timer

    Dim CentralGravObj As GravObj

    Public Sub New(ClickPos As Point)


        T.Start()
    End Sub

    Private Sub T_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T.Tick


        For i = Base.CoreMoveObjList.Count - 1 To 0 Step -1
            'Base.CoreMoveObjList(i).UpdatePos()


            If Base.CoreMoveObjList(i).Bounds.IntersectsWith(Form1.Bounds) = False Then
                Form1.Controls.Remove(Base.CoreMoveObjList(i))
                Base.CoreMoveObjList.Remove(Base.CoreMoveObjList(i))
            End If
        Next
    End Sub

    Public Sub DisposeObj()
        T.Stop()
        Base.CoreMoveObjList.Clear()
    End Sub

End Class

