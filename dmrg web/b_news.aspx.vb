
Partial Class b_news
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
        DBWorker.Read("SELECT * FROM news ORDER BY time DESC", dt)

        'dt.Columns.Add("日期")


        'For i As Integer = 0 To dt.Rows.Count - 1

        '    dt.Rows(i).Item("日期") = dt.Rows(i).Item("發表日期").ToString().Split(" ")(0)


        'Next

        Session("最新消息") = dt



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

        Dim dt As DataTable = Session("最新消息")

        Dim dt2 As New DataTable
        dt2.Columns.Add("time")
        dt2.Columns.Add("title")
        dt2.Columns.Add("content")
        dt2.Columns.Add("id")

        If dt.Rows.Count > 0 Then


            Dim start_index As Integer = (page - 1) * page_count
            Dim end_index As Integer = start_index + page_count

            If end_index > dt.Rows.Count - 1 Then end_index = dt.Rows.Count - 1


            For i As Integer = start_index To end_index
                Dim Row As DataRow = dt2.NewRow

                Row("time") = dt.Rows(i).Item("time")
                Row("title") = dt.Rows(i).Item("title")
                Row("content") = dt.Rows(i).Item("content")
                Row("id") = dt.Rows(i).Item("id")

                dt2.Rows.Add(Row)

            Next
        End If


        Rep.DataSource = dt2
        Rep.DataBind()

        Session("後台最新消息2") = dt2

    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Show_News(DropDownList1.SelectedIndex + 1)

    End Sub
    Protected Sub Rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Rep.ItemCommand


        If Session("flag") = 1 Then

            Session("flag") = 2


            Dim dt As DataTable = Session("後台最新消息2")

            If e.CommandName = "刪除" Then

                DBWorker.UpDate("DELETE FROM news WHERE id=" + dt.Rows(e.Item.ItemIndex).Item("id"))


                Share.MsgBox(Me, "刪除成功!")

                Load1()
            ElseIf e.CommandName = "修改" Then
                Panel1.Visible = True
                Label1.Text = "修改"

                TextBox1.Text = dt.Rows(e.Item.ItemIndex).Item("time")
                TextBox2.Text = dt.Rows(e.Item.ItemIndex).Item("title")
                TextBox3.Text = dt.Rows(e.Item.ItemIndex).Item("content")

                Session("news_edit_id") = dt.Rows(e.Item.ItemIndex).Item("id")
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
            Share.MsgBox(Me, "日期未輸入!")
            Exit Sub
        End If

        If TextBox2.Text.Trim = "" Then
            Share.MsgBox(Me, "主旨未輸入!")
            Exit Sub
        End If

        If TextBox3.Text.Trim = "" Then
            Share.MsgBox(Me, "內容未輸入!")
            Exit Sub
        End If

        If Label1.Text = "新增" Then

            DBWorker.Insert("INSERT INTO news(time,title,content) Values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')")
            Load1()
            Share.MsgBox(Me, "新增成功!")
            Panel1.Visible = False
            Rep.Visible = True

        ElseIf Label1.Text = "修改" Then


            DBWorker.Insert("UPDATE news SET time='" + Share.GetSqlStr(TextBox1.Text) + "',title='" + Share.GetSqlStr(TextBox2.Text) + "',content='" + Share.GetSqlStr(TextBox3.Text) + "' WHERE id=" + Session("news_edit_id"))
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
