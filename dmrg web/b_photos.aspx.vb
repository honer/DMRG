
Partial Class b_photos
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
        DBWorker.Read("SELECT * FROM photos", dt)



        Session("活動照片") = dt



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

        Dim dt As DataTable = Session("活動照片")

        Dim dt2 As New DataTable
        dt2.Columns.Add("photo")
        dt2.Columns.Add("desp")
        dt2.Columns.Add("id")

        If dt.Rows.Count > 0 Then


            Dim start_index As Integer = (page - 1) * page_count
            Dim end_index As Integer = start_index + page_count

            If end_index > dt.Rows.Count - 1 Then end_index = dt.Rows.Count - 1


            For i As Integer = start_index To end_index
                Dim Row As DataRow = dt2.NewRow

                Row("photo") = dt.Rows(i).Item("photo")
                Row("desp") = dt.Rows(i).Item("desp")
                Row("id") = dt.Rows(i).Item("id")

                dt2.Rows.Add(Row)

            Next
        End If


        Rep.DataSource = dt2
        Rep.DataBind()

        Session("後台活動照片2") = dt2

    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Show_News(DropDownList1.SelectedIndex + 1)

    End Sub
    Protected Sub Rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Rep.ItemCommand


        If Session("flag") = 1 Then

            Session("flag") = 2


            Dim dt As DataTable = Session("後台活動照片2")

            If e.CommandName = "修改" Then
                Panel1.Visible = True
                Label1.Text = "修改"
                Rep.Visible = False


                If IsDBNull(dt.Rows(e.Item.ItemIndex).Item("desp")) = False Then
                    TextBox2.Text = dt.Rows(e.Item.ItemIndex).Item("desp")
                End If

                Image1.ImageUrl = "team\photos\" + dt.Rows(e.Item.ItemIndex).Item("photo")

                Session("修改識別碼") = dt.Rows(e.Item.ItemIndex).Item("id")
            ElseIf e.CommandName = "刪除" Then

                DBWorker.UpDate("DELETE FROM photos WHERE id=" + dt.Rows(e.Item.ItemIndex).Item("id"))

                If File.Exists(HttpContext.Current.Server.MapPath("team") + "\photos\" + dt.Rows(e.Item.ItemIndex).Item("photo")) Then
                    File.Delete(HttpContext.Current.Server.MapPath("team") + "\photos\" + dt.Rows(e.Item.ItemIndex).Item("photo"))
                End If

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


        If TextBox2.Text.Trim = "" Then
            Share.MsgBox(Me, "請輸入照片描述!")
            Exit Sub
        End If

        If Label1.Text = "新增" Then

            Dim photo_name As String = ""

            If (Session("photos_temp") <> "") Then
                photo_name = Session("photos_temp").ToString.Substring(5)

                If File.Exists(HttpContext.Current.Server.MapPath("team") + "\photos\" + Session("photos_temp")) Then
                    File.Move(HttpContext.Current.Server.MapPath("team") + "\photos\" + Session("photos_temp"), HttpContext.Current.Server.MapPath("team") + "\photos\" + photo_name)
                End If

            End If

            DBWorker.Insert("INSERT INTO photos(desp,photo) Values('" + Share.GetSqlStr(TextBox2.Text) + "','" + photo_name + "')")
            Load1()
            Share.MsgBox(Me, "新增成功!")
            Panel1.Visible = False
            Session("photos_temp") = ""

        ElseIf Label1.Text = "修改" Then


            Dim sql As String = ""
            Dim photo_name As String = ""

            If (Session("photos_temp") <> "") Then
                photo_name = Session("photos_temp").ToString.Substring(5)
                sql = "UPDATE photos SET desp='" + Share.GetSqlStr(TextBox2.Text) + "',photo='" + photo_name + "' WHERE id=" + Session("修改識別碼")

                If File.Exists(HttpContext.Current.Server.MapPath("team") + "\photos\" + Session("photos_temp")) Then
                    File.Move(HttpContext.Current.Server.MapPath("team") + "\photos\" + Session("photos_temp"), HttpContext.Current.Server.MapPath("team") + "\photos\" + photo_name)
                End If
            Else
                sql = "UPDATE photos SET desp='" + Share.GetSqlStr(TextBox2.Text) + "' WHERE id=" + Session("修改識別碼")
            End If


            Session("photos_temp") = ""
            DBWorker.Insert(sql)
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
            'Share.Del_File(HttpContext.Current.Server.MapPath("team") + "\photos", Session("修改識別碼") + "." + Share.GetFileStytle(FileUpload1.FileName))

            Dim temp_name As String
            Dim rr As New Random
            temp_name = "temp_" + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString + CInt(rr.NextDouble() * 9).ToString

            ' Response.Write(temp_name)

            Session("photos_temp") = temp_name + "." + Share.GetFileStytle(FileUpload1.FileName)

            FileUpload1.SaveAs(HttpContext.Current.Server.MapPath("team") + "\photos\" + Session("photos_temp"))
            Image1.ImageUrl = "team\photos\" + Session("photos_temp")

            'DBWorker.Insert("UPDATE photos SET photo='" + Session("修改識別碼") + "." + Share.GetFileStytle(FileUpload1.FileName) + "' WHERE id=" + Session("修改識別碼"))
        End If



    End Sub
End Class
