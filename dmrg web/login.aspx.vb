
Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        If TextBox1.Text.Trim = "admin" And TextBox2.Text.Trim = "dmrg99123" Then
            Session("後台登入id") = "admin"
            Response.Redirect("b_news.aspx")
        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
