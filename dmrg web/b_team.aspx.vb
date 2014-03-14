
Partial Class b_team
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
        DBWorker.Read("SELECT * FROM student ORDER BY year DESC", dt)

      

        Session("研究團隊") = dt



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

        Dim dt As DataTable = Session("研究團隊")

        Dim dt2 As New DataTable
        dt2.Columns.Add("photo")
        dt2.Columns.Add("year")
        dt2.Columns.Add("name")
        dt2.Columns.Add("style")
        dt2.Columns.Add("paper")
        dt2.Columns.Add("desp")
        dt2.Columns.Add("id")

        If dt.Rows.Count > 0 Then


            Dim start_index As Integer = (page - 1) * page_count
            Dim end_index As Integer = start_index + page_count

            If end_index > dt.Rows.Count - 1 Then end_index = dt.Rows.Count - 1


            For i As Integer = start_index To end_index
                Dim Row As DataRow = dt2.NewRow

                Row("photo") = dt.Rows(i).Item("photo")
                Row("year") = dt.Rows(i).Item("year")
                Row("name") = dt.Rows(i).Item("name")
                Row("style") = dt.Rows(i).Item("style")

                Row("paper") = dt.Rows(i).Item("paper")
                Row("desp") = dt.Rows(i).Item("desp")

                Row("id") = dt.Rows(i).Item("id")

                dt2.Rows.Add(Row)

            Next
        End If


        Rep.DataSource = dt2
        Rep.DataBind()

        Session("後台研究團隊2") = dt2

    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Show_News(DropDownList1.SelectedIndex + 1)

    End Sub
    Protected Sub Rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Rep.ItemCommand


        If Session("flag") = 1 Then

            Session("flag") = 2


            Dim dt As DataTable = Session("後台研究團隊2")

            If e.CommandName = "查看" Then
                Panel1.Visible = True
                Label1.Text = "修改"
                Rep.Visible = False

                TextBox8.Text = dt.Rows(e.Item.ItemIndex).Item("year")
                DropDownList2.Text = dt.Rows(e.Item.ItemIndex).Item("style")
                TextBox2.Text = dt.Rows(e.Item.ItemIndex).Item("name")

                If IsDBNull(dt.Rows(e.Item.ItemIndex).Item("paper")) = False Then
                    FCKeditor1.Value = dt.Rows(e.Item.ItemIndex).Item("paper")
                End If


                If IsDBNull(dt.Rows(e.Item.ItemIndex).Item("desp")) = False Then
                    FCKeditor2.Value = dt.Rows(e.Item.ItemIndex).Item("desp")
                End If

  

                Image1.ImageUrl = "team\photo\" + dt.Rows(e.Item.ItemIndex).Item("photo")

                Session("修改識別碼") = dt.Rows(e.Item.ItemIndex).Item("id")
            ElseIf e.CommandName = "刪除" Then
                DBWorker.UpDate("DELETE FROM student WHERE id=" + dt.Rows(e.Item.ItemIndex).Item("id"))


                Share.MsgBox(Me, "刪除成功!")

                Load1()
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

        If TextBox8.Text.Trim = "" Then
            Share.MsgBox(Me, "年度未輸入!")
            Exit Sub
        End If

        If TextBox2.Text.Trim = "" Then
            Share.MsgBox(Me, "姓名未輸入!")
            Exit Sub
        End If

        If Label1.Text = "新增" Then

            DBWorker.Insert("INSERT INTO student(year,style,name,paper,desp) Values(" + Share.GetSqlStr(TextBox8.Text) + ",'" + DropDownList2.Text + "','" + Share.GetSqlStr(TextBox2.Text) + "','" + Share.GetSqlStr(FCKeditor1.Value) + "','" + Share.GetSqlStr(FCKeditor2.Value) + "')")
            Load1()
            Share.MsgBox(Me, "新增成功!")
            Panel1.Visible = False

        ElseIf Label1.Text = "修改" Then


            DBWorker.Insert("UPDATE student SET year='" + Share.GetSqlStr(TextBox8.Text) + "',style='" + Share.GetSqlStr(DropDownList2.Text) + "',name='" + Share.GetSqlStr(TextBox2.Text) + "',paper='" + Share.GetSqlStr(FCKeditor1.Value) + "',desp='" + Share.GetSqlStr(FCKeditor2.Value) + "' WHERE id=" + Session("修改識別碼"))
            Share.MsgBox(Me, "修改成功!")
            Panel1.Visible = False
            Load1()
            Rep.Visible = True

        End If

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Panel1.Visible = False
        Rep.Visible = True
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click

        If FileUpload1.HasFile Then
            Share.Del_File(HttpContext.Current.Server.MapPath("team") + "\photo", Session("修改識別碼") + "." + Share.GetFileStytle(FileUpload1.FileName))
            FileUpload1.SaveAs(HttpContext.Current.Server.MapPath("team") + "\photo\" + Session("修改識別碼") + "." + Share.GetFileStytle(FileUpload1.FileName))
            Image1.ImageUrl = "team\photo\" + Session("修改識別碼") + "." + Share.GetFileStytle(FileUpload1.FileName)
            DBWorker.Insert("UPDATE student SET photo='" + Session("修改識別碼") + "." + Share.GetFileStytle(FileUpload1.FileName) + "' WHERE id=" + Session("修改識別碼"))
        End If



    End Sub
End Class
