Public Class Form1

    Dim PartyCollection As New List(Of PartyObjBase)

    Dim PartyType As Integer = 0

    Dim Paused As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Init()
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If Paused = False Then
            If PartyType <> 0 Then
                If PartyCollection.Count < 3 Then

                    Select Case PartyType
                        Case 1
                            PartyCollection.Add(New ConfettiPopper(New Point(e.X, e.Y)))
                        Case 2
                            PartyCollection.Add(New FireworkPopper(New Point(e.X, e.Y)))
                        Case 3
                            PartyCollection.Add(New SpiralPopper(New Point(e.X, e.Y)))
                        Case 4
                            PartyCollection.Add(New RipplePopper(New Point(e.X, e.Y)))
                        Case 5
                            PartyCollection.Add(New SnakePopper(New Point(e.X, e.Y)))
                    End Select


                Else
                    PartyReset()
                End If
            Else
                MsgBox("Please choose a party to start!")
            End If
        End If
    End Sub

    '========BUTTON/S & KEYS=========
    Private Sub ChangePartyType(ByVal sender As Object, ByVal e As EventArgs)
        Dim Reaction As Object = InputBox("Enter the type of party you want to have! 1,2,3,4,5")
        If Reaction = "" Then
            MsgBox("You must enter a party number in order to begin. please do so!")
        Else
            PartyType = Reaction
            PartyReset()
        End If
    End Sub
    Private Sub PauseClicked(ByVal sender As Object, ByVal e As EventArgs)
        Pause()
    End Sub
    Private Sub KeyPressed(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.P Then
            Pause()
        End If
    End Sub
    '- - - - - - - - - - - - -
    Private Sub AddControlsToForm()
        Dim SwitchPartyType As Button = ConstControls.GetButton_ChangeType()
        AddHandler SwitchPartyType.Click, AddressOf ChangePartyType
        Me.Controls.Add(SwitchPartyType)

        Dim Pause As Button = ConstControls.GetButton_Pause()
        AddHandler Pause.Click, AddressOf PauseClicked
        Me.Controls.Add(Pause)
    End Sub
    '=========================

    '========XTRAS=========
    Private Sub Pause()
        If PartyCollection.Count > 0 Then
            If Paused = False Then
                For Each PartyObj In PartyCollection
                    PartyObj.T.Stop()
                Next
                Paused = True

            Else
                For Each PartyObj In PartyCollection
                    PartyObj.T.Start()
                Next
                Paused = False
            End If
        End If
    End Sub
    Private Sub Init()
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.BackColor = Color.Black
        Me.Size = MaximumSize
        Me.WindowState = FormWindowState.Maximized
        Me.CenterToScreen()

        AddControlsToForm()
    End Sub
    Private Sub PartyReset()
        For Each PartyObj In PartyCollection
            PartyObj.DisposeObj()
        Next
        PartyCollection.Clear()
    End Sub
    '=========================
End Class
