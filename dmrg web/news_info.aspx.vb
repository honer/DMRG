
Partial Class news_info
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

    Sub Load1()
        If Request("id") <> "" Then

            Dim dt As New DataTable
            DBWorker.Read("SELECT * FROM news WHERE id=" + Request("id"), dt)

            If dt.Rows.Count = 1 Then              
                If IsDBNull(dt.Rows(0).Item("time")) = False Then Label1.Text = dt.Rows(0).Item("time")
                If IsDBNull(dt.Rows(0).Item("title")) = False Then Label2.Text = dt.Rows(0).Item("title")
                If IsDBNull(dt.Rows(0).Item("content")) = False Then Label3.Text = dt.Rows(0).Item("content")
            End If



        End If


    End Sub
End Class
