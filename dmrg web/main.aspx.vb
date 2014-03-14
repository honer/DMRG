
Partial Class main
    Inherits System.Web.UI.Page

    Const page_count As Integer = 6

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
      

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

  

    Sub Load1()

        Dim dt As New DataTable
        DBWorker.Read("SELECT id,title,content,time FROM news order by id desc", dt)

        Dim ss As String = ""

        ss += "<table>"
        ss += "<tr>"

        Dim page As Integer = 0

        If Request("page") = "" Then
            page = 1
        Else
            page = Request("page")
        End If

        Dim start_index = (page - 1) * page_count
        Dim end_index = start_index + (page_count - 1)

        If end_index > dt.Rows.Count - 1 Then
            end_index = dt.Rows.Count - 1
        End If


        Dim dt2 As New DataTable
        dt2.Columns.Add("id")
        dt2.Columns.Add("title")
        dt2.Columns.Add("content")
        dt2.Columns.Add("time")



        For i As Integer = start_index To end_index
            Dim Row As DataRow = dt2.NewRow

            Row("id") = dt.Rows(i).Item("id")
            Row("title") = dt.Rows(i).Item("title")
            Row("content") = dt.Rows(i).Item("content")
            Row("time") = dt.Rows(i).Item("time")


            dt2.Rows.Add(Row)

        Next



        Rep.DataSource = dt2
        Rep.DataBind()



        Dim all_count As Integer = dt.Rows.Count \ page_count
        If dt.Rows.Count Mod page_count > 0 Then
            all_count += 1
        End If

        For i As Integer = 1 To all_count
            DropDownList1.Items.Add(i.ToString)
        Next

        DropDownList1.SelectedIndex = page - 1


    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged


        Response.Redirect("main.aspx?page=" + DropDownList1.SelectedValue)

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        If DropDownList1.SelectedIndex > 0 Then
            Response.Redirect("main.aspx?page=" + DropDownList1.SelectedIndex.ToString)
            DropDownList1.SelectedIndex = DropDownList1.SelectedIndex - 1

        End If


    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

        If DropDownList1.SelectedIndex + 1 <= (DropDownList1.Items.Count - 1) Then
            Response.Redirect("main.aspx?page=" + (DropDownList1.SelectedIndex + 2).ToString)
            DropDownList1.SelectedIndex = DropDownList1.SelectedIndex + 1
        End If

    End Sub
End Class
