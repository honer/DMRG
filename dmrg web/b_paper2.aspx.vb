
Partial Class b_paper2
    Inherits System.Web.UI.Page

    Const page_count As Integer = 6
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
        DBWork.Read("SELECT * FROM 期刊論文 ORDER BY 識別碼 DESC", dt)


        Session("期刊論文") = dt



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

        Dim dt As DataTable = Session("期刊論文")

        Dim dt2 As New DataTable
        dt2.Columns.Add("主題")
        dt2.Columns.Add("期刊")
        dt2.Columns.Add("作者")
        dt2.Columns.Add("識別碼")

        If dt.Rows.Count > 0 Then


            Dim start_index As Integer = (page - 1) * page_count
            Dim end_index As Integer = start_index + page_count

            If end_index > dt.Rows.Count - 1 Then end_index = dt.Rows.Count - 1


            For i As Integer = start_index To end_index
                Dim Row As DataRow = dt2.NewRow

                Row("主題") = dt.Rows(i).Item("主題")
                Row("期刊") = dt.Rows(i).Item("期刊")
                Row("作者") = dt.Rows(i).Item("作者")
                Row("識別碼") = dt.Rows(i).Item("識別碼")

                dt2.Rows.Add(Row)

            Next
        End If


        Rep.DataSource = dt2
        Rep.DataBind()

        Session("後台期刊論文2") = dt2

    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Show_News(DropDownList1.SelectedIndex + 1)

    End Sub
    Protected Sub Rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Rep.ItemCommand


        If Session("flag") = 1 Then

            Session("flag") = 2


            Dim dt As DataTable = Session("後台期刊論文2")

            If e.CommandName = "刪除" Then

                DBWork.Update("DELETE FROM 期刊論文 WHERE 識別碼=" + dt.Rows(e.Item.ItemIndex).Item("識別碼"))


                Share.MsgBox(Me, "刪除成功!")

                Load1()
            ElseIf e.CommandName = "修改" Then
                Panel1.Visible = True
                Label1.Text = "修改"

                TextBox1.Text = dt.Rows(e.Item.ItemIndex).Item("主題")
                TextBox2.Text = dt.Rows(e.Item.ItemIndex).Item("期刊")
                TextBox3.Text = dt.Rows(e.Item.ItemIndex).Item("作者")

                Session("修改識別碼") = dt.Rows(e.Item.ItemIndex).Item("識別碼")
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
            Share.MsgBox(Me, "主題未輸入!")
            Exit Sub
        End If

        If TextBox2.Text.Trim = "" Then
            Share.MsgBox(Me, "期刊未輸入!")
            Exit Sub
        End If

        If TextBox3.Text.Trim = "" Then
            Share.MsgBox(Me, "作者未輸入!")
            Exit Sub
        End If

        If Label1.Text = "新增" Then

            DBWork.Insert("INSERT INTO 期刊論文(主題,期刊,作者) Values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')")
            Load1()
            Share.MsgBox(Me, "新增成功!")
            Panel1.Visible = False
            Rep.Visible = True

        ElseIf Label1.Text = "修改" Then


            DBWork.Insert("UPDATE 期刊論文 SET 主題='" + Share.GetSqlStr(TextBox1.Text) + "',期刊='" + Share.GetSqlStr(TextBox2.Text) + "',作者='" + Share.GetSqlStr(TextBox3.Text) + "' WHERE 識別碼=" + Session("修改識別碼"))
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
