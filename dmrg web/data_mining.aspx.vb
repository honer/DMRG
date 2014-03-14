
Partial Class data_mining
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

    Sub Load1()

        Dim dt As New DataTable

        DBWork.Read("SELECT * FROM 資料探勘 ORDER BY 順序", dt)


        Dim ss As String = ""

        For i As Integer = 0 To dt.Rows.Count - 1
            ss += "<div id=""data_mining"">"
            ss += "<div class=""title"">" + dt.Rows(i).Item("主題") + "</div>"
            ss += "<div class=""content"">" + dt.Rows(i).Item("內文") + "</div>"
            ss += "</div>"

        Next


        Label1.Text = ss






    End Sub

End Class
