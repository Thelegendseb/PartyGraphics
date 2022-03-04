Public Class Form1

    Dim PartyCollection As New List(Of Object)
    Dim PartyType As Byte = InputBox("Enter the type of party you want to have!")

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Init()
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If PartyCollection.Count <> 3 Then

            Select Case PartyType
                Case 1
                    PartyCollection.Add(New PartyPopper(New Point(e.X, e.Y)))
                Case 2
                    PartyCollection.Add(New FireworkPopper(New Point(e.X, e.Y)))
            End Select

        Else
            For Each PartyObj In PartyCollection
                PartyObj.DisposeObj()
            Next
            PartyCollection.Clear()
            Me.Controls.Clear()
        End If
    End Sub

    Sub Init()
        Me.BackColor = Color.Black
        Me.Size = MaximumSize
        Me.WindowState = FormWindowState.Maximized
        Me.CenterToScreen()
    End Sub

End Class