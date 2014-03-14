
Partial Class b_discuss
    Inherits System.Web.UI.Page

    Const page_count As Integer = 10
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If

        Session("flag") = 1

    End Sub

    Sub Load1()

        Dim dt As New DataTable
        DBWorker.Read("SELECT * FROM seminar ORDER BY id DESC", dt)


        Session("研討會訊息") = dt



        Rep.DataSource = dt
        Rep.DataBind()
        Dim count As Integer = dt.Rows.Count / page_count

        If dt.Rows.Count Mod page_count > 0 Then count += 1

        DropDownList1.Items.Clear()
        For i As Integer = 1 To count
            DropDownList1.Items.Add(i.ToString)
        Next

        Show_News(1)




    End Sub

    Sub Show_News(ByVal page As Integer)

        Dim dt As DataTable = Session("研討會訊息")

        Dim dt2 As New DataTable
        dt2.Columns.Add("title")
        dt2.Columns.Add("content")
        dt2.Columns.Add("id")

        If dt.Rows.Count > 0 Then


            Dim start_index As Integer = (page - 1) * page_count
            Dim end_index As Integer = start_index + page_count

            If end_index > dt.Rows.Count - 1 Then end_index = dt.Rows.Count - 1


            For i As Integer = start_index To end_index
                Dim Row As DataRow = dt2.NewRow

                Row("id") = dt.Rows(i).Item("id")
                Row("title") = dt.Rows(i).Item("title")
                Row("content") = dt.Rows(i).Item("content")

                dt2.Rows.Add(Row)

            Next
        End If


        Rep.DataSource = dt2
        Rep.DataBind()

        Session("後台研討會訊息2") = dt2

    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Show_News(DropDownList1.SelectedIndex + 1)

    End Sub
    Protected Sub Rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Rep.ItemCommand


        If Session("flag") = 1 Then

            Session("flag") = 2


            Dim dt As DataTable = Session("後台研討會訊息2")

            If e.CommandName = "刪除" Then

                DBWorker.UpDate("DELETE FROM seminar WHERE id=" + dt.Rows(e.Item.ItemIndex).Item("id"))


                Share.MsgBox(Me, "刪除成功!")

                Load1()
            ElseIf e.CommandName = "修改" Then
                Panel1.Visible = True
                Label1.Text = "修改"

                If IsDBNull(dt.Rows(e.Item.ItemIndex).Item("title")) = False Then
                    TextBox1.Text = dt.Rows(e.Item.ItemIndex).Item("title")
                End If

                If IsDBNull(dt.Rows(e.Item.ItemIndex).Item("content")) = False Then
                    FCKeditor1.Value = dt.Rows(e.Item.ItemIndex).Item("content")
                End If

                Session("修改識別碼") = dt.Rows(e.Item.ItemIndex).Item("id")
                Rep.Visible = False

            End If
        End If
    End Sub

    Protected Sub LinkButton17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton17.Click
        If DropDownList1.SelectedIndex > 0 Then
            DropDownList1.SelectedIndex = DropDownList1.SelectedIndex - 1
            Show_News(DropDownList1.SelectedIndex + 1)
        End If
    End Sub

    Protected Sub LinkButton18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton18.Click
        If DropDownList1.SelectedIndex + 1 < DropDownList1.Items.Count Then
            DropDownList1.SelectedIndex = DropDownList1.SelectedIndex + 1
            Show_News(DropDownList1.SelectedIndex + 1)
        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label1.Text = "新增"
        Panel1.Visible = True
        Rep.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text.Trim = "" Then
            Share.MsgBox(Me, "研討會名稱未輸入!")
            Exit Sub
        End If


        If Label1.Text = "新增" Then

            DBWorker.Insert("INSERT INTO seminar (title,content) Values('" + TextBox1.Text + "','" + FCKeditor1.Value + "')")
            Load1()
            Share.MsgBox(Me, "新增成功!")
            Panel1.Visible = False
            Rep.Visible = True

        ElseIf Label1.Text = "修改" Then


            DBWorker.Insert("UPDATE seminar SET title='" + Share.GetSqlStr(TextBox1.Text) + "',content='" + Share.GetSqlStr(FCKeditor1.Value) + "' WHERE id=" + Session("修改識別碼"))
            Share.MsgBox(Me, "修改成功!")
            Panel1.Visible = False
            Load1()
            Rep.Visible = True

        End If

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Rep.Visible = True
        Panel1.Visible = False
    End Sub
End Class

