
Partial Class contact
    Inherits System.Web.UI.Page

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Then
            Share.MsgBox(Me, "資料填寫不完全")
            Exit Sub
        End If

        Dim mail As String() = {"tenhon6688@hotmail.com"}

        If MyMail.SendEMail(TextBox2.Text, TextBox1.Text, mail) = "success" Then
            Share.MsgBox(Me, "寄出成功")
        End If



    End Sub
End Class
