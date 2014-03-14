
Partial Class paper
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

    Sub Load1()

        Dim dt As New DataTable

        DBWorker.Read("SELECT * FROM paper ORDER BY id ASC", dt)

        Dim ss As String = ""



        For i As Integer = dt.Rows.Count - 1 To 0 Step -1
            ' ss += "<div style=""height:1px; border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc;margin-top:5px;margin-down:2px""></div>"
            ss += "<div id=""paper"">"
            ss += "<div class=""title""><img src=""img\paper.jpg"" width=""20"" height=""20"" border=""0"" />  " + dt.Rows(i).Item("title") + "</div>"
            ss += "<div class=""diss"">" + dt.Rows(i).Item("content") + "</div>"
            ss += "<div class=""poster"">" + dt.Rows(i).Item("poster") + "</div>"
            ss += "</div>"
        Next


        ss += "<br/>"


        'DBWork.Read("SELECT * FROM 期刊論文 ORDER BY 識別碼 ASC", dt)


        'For i As Integer = 0 To dt.Rows.Count


        'Next

        Label1.Text = ss



    End Sub
End Class
