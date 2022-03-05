Public Class Form1

    Dim PartyCollection As New List(Of PartyObjBase)

    Dim PartyType As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Init()
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If PartyType <> 0 Then
            'INHERIT POPPER FUNDAMENTALS IN ORDER TO CREATE A SUB TO HAVE UNIVERAL SUBS
            If PartyCollection.Count < 3 Then

                Select Case PartyType
                    Case 1
                        PartyCollection.Add(New ConfettiPopper(New Point(e.X, e.Y)))
                    Case 2
                        PartyCollection.Add(New FireworkPopper(New Point(e.X, e.Y)))
                    Case 3
                        PartyCollection.Add(New SpiralPopper(New Point(e.X, e.Y)))
                End Select

            Else
                PartyReset()
            End If
        Else
            MsgBox("Please choose a party to start!")
        End If
    End Sub

    '========BUTTON/S=========
    Private Sub ChangePartyType(ByVal sender As Object, ByVal e As EventArgs)
        Dim Reaction As Object = InputBox("Enter the type of party you want to have!")
        If Reaction = "" Then
            MsgBox("You must enter a party number in order to begin. please do so!")
        Else
            PartyType = Reaction
            PartyReset()
        End If
    End Sub
    '- - - - - - - - - - - - - 
    Sub AddControlsToForm()
        Dim SwitchPartyType As Button = ConstControls.GetButton_ChangeType()
        AddHandler SwitchPartyType.Click, AddressOf ChangePartyType

        Me.Controls.Add(SwitchPartyType)
    End Sub
    '=========================
    Sub Init()
        Me.BackColor = Color.Black
        Me.Size = MaximumSize
        Me.WindowState = FormWindowState.Maximized
        Me.CenterToScreen()

        AddControlsToForm()
    End Sub

    Sub PartyReset()
        For Each PartyObj In PartyCollection
            PartyObj.DisposeObj()
        Next
        PartyCollection.Clear()
    End Sub

End Class