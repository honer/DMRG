
Partial Class discussion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

    Sub Load1()

        Dim dt As New DataTable

        DBWorker.Read("SELECT * FROM seminar", dt)


        Dim ss As String = ""

        For i As Integer = 0 To dt.Rows.Count - 1
            ss += "<div style=""height:1px; border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc;margin-top:5px;margin-down:2px""></div>"
            ss += "<div id=""title"">" + dt.Rows(i).Item("content") + "</div>"
 
        Next


        'DBWork.Read("SELECT * FROM 期刊論文 ORDER BY 識別碼 ASC", dt)


        'For i As Integer = 0 To dt.Rows.Count


        'Next

        Label1.Text = ss





    End Sub
End Class
