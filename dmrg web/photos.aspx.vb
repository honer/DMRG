
Partial Class photos
    Inherits System.Web.UI.Page

    Dim count As Integer = 16


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

    Sub Load1()

        Dim dt As New DataTable

        DBWorker.Read("SELECT * FROM photos ORDER BY id ASC", dt)


        Dim ss As String = ""

        ss += "<table>"
        ss += "<tr>"

        Dim page As Integer = 0

        If Request("page") = "" Then
            page = 1
        Else
            page = Request("page")
        End If

        Dim start_index = (page - 1) * count
        Dim end_index = start_index + (count - 1)

        If end_index > dt.Rows.Count - 1 Then
            end_index = dt.Rows.Count - 1
        End If

        For i As Integer = start_index To end_index


            If i Mod 4 = 0 Then
                ss += "</tr><tr>"
            End If

            ss += "<td>"
            ss += "<div id=""photo""><a href=""javascript:show('" + dt.Rows(i).Item("photo") + "')"">" + "<img src=""team/photos/" + dt.Rows(i).Item("photo") + """ border=""0"" width=""200px""/></a></div>"
            ss += "<div id=""desp"">" + dt.Rows(i).Item("desp") + "</div>"
            ss += "</td>"



        Next
        ss += "</tr>"
        ss += "</table>"

        'DBWork.Read("SELECT * FROM 期刊論文 ORDER BY 識別碼 ASC", dt)


        'For i As Integer = 0 To dt.Rows.Count


        'Next

        Label1.Text = ss


        Dim all_count As Integer = dt.Rows.Count \ count
        If dt.Rows.Count Mod count > 0 Then
            all_count += 1
        End If

        Label2.Text = "共" + all_count.ToString + "頁"

        For i As Integer = 1 To all_count
            DropDownList1.Items.Add(i.ToString)
        Next

        DropDownList1.SelectedIndex = page - 1


    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged


        Response.Redirect("photos.aspx?page=" + DropDownList1.SelectedValue)

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        If DropDownList1.SelectedIndex > 0 Then
            Response.Redirect("photos.aspx?page=" + DropDownList1.SelectedIndex.ToString)
            DropDownList1.SelectedIndex = DropDownList1.SelectedIndex - 1

        End If


    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

        If DropDownList1.SelectedIndex + 1 <= (DropDownList1.Items.Count - 1) Then
            Response.Redirect("photos.aspx?page=" + (DropDownList1.SelectedIndex + 2).ToString)
            DropDownList1.SelectedIndex = DropDownList1.SelectedIndex + 1
        End If

    End Sub
End Class
