
Partial Class team_info
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

    Sub Load1()
        If Request("id") <> "" Then

            Dim dt As New DataTable
            DBWorker.Read("SELECT * FROM student WHERE id=" + Request("id"), dt)


            If dt.Rows.Count = 1 Then
                Image1.ImageUrl = "team/photo/" + dt.Rows(0).Item("photo")
                If IsDBNull(dt.Rows(0).Item("name")) = False Then Label1.Text = dt.Rows(0).Item("name")
                If IsDBNull(dt.Rows(0).Item("paper")) = False Then Label2.Text = dt.Rows(0).Item("paper")
                If IsDBNull(dt.Rows(0).Item("desp")) = False Then Label4.Text = dt.Rows(0).Item("desp")

            End If



        End If


    End Sub

End Class
