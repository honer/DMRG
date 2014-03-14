
Partial Class b_top
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("後台登入id") = "" Then
            Response.Redirect("login.aspx")
        End If


    End Sub
End Class
