Public Class ConstControls

    Public Shared Function GetButton_ChangeType() As Button
        Return New Button With {.Location = New Point(20, 20),
                                .Size = New Size(100, 60),
                                .BackColor = Color.LightGray,
                                .Text = "Change Party Type"}
    End Function 'WILL EVENTUALLY BE CUSTOM IMAGE

    Public Shared Function GetButton_Pause() As Button
        Return New Button With {.Location = New Point(Form1.ClientSize.Width - 20 - 60, 20),
                                .Size = New Size(60, 40),
                                .BackColor = Color.LightGray,
                                .Text = "Pause"}
    End Function

End Class