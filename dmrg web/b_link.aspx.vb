
Partial Class b_link
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
        DBWork.Read("SELECT * FROM 相關連結 ORDER BY 識別碼 DESC", dt)


        Session("相關連結") = dt



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

        Dim dt As DataTable = Session("相關連結")

        Dim dt2 As New DataTable
        dt2.Columns.Add("類型")
        dt2.Columns.Add("名稱")
        dt2.Columns.Add("連結")
        dt2.Columns.Add("識別碼")

        If dt.Rows.Count > 0 Then


            Dim start_index As Integer = (page - 1) * page_count
            Dim end_index As Integer = start_index + page_count

            If end_index > dt.Rows.Count - 1 Then end_index = dt.Rows.Count - 1


            For i As Integer = start_index To end_index
                Dim Row As DataRow = dt2.NewRow

                Row("類型") = dt.Rows(i).Item("類型")
                Row("名稱") = dt.Rows(i).Item("名稱")
                Row("連結") = dt.Rows(i).Item("連結")
                Row("識別碼") = dt.Rows(i).Item("識別碼")

                dt2.Rows.Add(Row)

            Next
        End If


        Rep.DataSource = dt2
        Rep.DataBind()

        Session("後台相關連結2") = dt2

    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Show_News(DropDownList1.SelectedIndex + 1)

    End Sub
    Protected Sub Rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Rep.ItemCommand


        If Session("flag") = 1 Then

            Session("flag") = 2


            Dim dt As DataTable = Session("後台相關連結2")

            If e.CommandName = "刪除" Then

                DBWork.Update("DELETE FROM 相關連結 WHERE 識別碼=" + dt.Rows(e.Item.ItemIndex).Item("識別碼"))


                Share.MsgBox(Me, "刪除成功!")

                Load1()
            ElseIf e.CommandName = "修改" Then
                Panel1.Visible = True
                Label1.Text = "修改"

                TextBox1.Text = dt.Rows(e.Item.ItemIndex).Item("類型")
                TextBox2.Text = dt.Rows(e.Item.ItemIndex).Item("名稱")
                TextBox3.Text = dt.Rows(e.Item.ItemIndex).Item("連結")

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
            Share.MsgBox(Me, "類型未輸入!")
            Exit Sub
        End If

        If TextBox2.Text.Trim = "" Then
            Share.MsgBox(Me, "名稱未輸入!")
            Exit Sub
        End If

        If TextBox3.Text.Trim = "" Then
            Share.MsgBox(Me, "連結未輸入!")
            Exit Sub
        End If

        If Label1.Text = "新增" Then

            DBWork.Insert("INSERT INTO 相關連結(類型,會議,連結) Values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')")
            Load1()
            Share.MsgBox(Me, "新增成功!")
            Panel1.Visible = False
            Rep.Visible = True

        ElseIf Label1.Text = "修改" Then


            DBWork.Insert("UPDATE 相關連結 SET 類型='" + Share.GetSqlStr(TextBox1.Text) + "',名稱='" + Share.GetSqlStr(TextBox2.Text) + "',連結='" + Share.GetSqlStr(TextBox3.Text) + "' WHERE 識別碼=" + Session("修改識別碼"))
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
