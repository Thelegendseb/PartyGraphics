Public Class ConstControls

    Public Shared Function GetButton_ChangeType() As Button
        Dim B As New Button
        With B 'eventually custom image asset
            .Location = New Point(20, 20)
            .Size = New Size(100, 60)
            .BackColor = Color.LightGray
            .Text = "Change Party Type"
        End With
        Return B
    End Function

End Class
