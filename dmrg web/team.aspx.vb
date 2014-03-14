
Partial Class team
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Load1()
        End If


    End Sub

    Sub Load1()

        Dim dt As New DataTable

        DBWorker.Read("SELECT * FROM student ORDER BY year DESC", dt)


        Dim ss As String = ""

        Dim ii As Integer = 0

        Dim cc As Integer = 0

	if request("ac") = "" or request("ac") = "present" then

		dim pre_year as integer = (Now().year() - 1911)

		For i As Integer = dt.Rows.Count - 1 To 0 step -1

			if dt.Rows(i).Item("year") >= pre_year - 2 then

				dim s1 as string = ""
				dim s2 as string = ""

				If IsDBNull(dt.Rows(0).Item("paper")) = False Then s1 = dt.Rows(i).Item("paper")
                		If IsDBNull(dt.Rows(0).Item("desp")) = False Then s2 = dt.Rows(i).Item("desp")

				ss += "<table>"

				ss += "<tr>"
				ss += "<td rowspan=""3"" width=""20%"">" + dt.Rows(i).Item("year").ToString + "級" + "</td>"
				ss += "<td rowspan=""3"" width=""20%""><img src=""team/photo/" + dt.Rows(i).Item("photo") + """ alt="""" height=""200px"" width=""155px""></td>"	
				ss += "<td width=""60%"">" + dt.Rows(i).Item("name") + "</td>"		
				ss += "</tr>"	

				ss += "<tr>"
				ss += "<td>" + s1 + "</td>"
				ss += "</tr>"		

				ss += "<tr>"
				ss += "<td>" + s2 + "</td>"
				ss += "</tr>"

				ss += "</table>"

			end if		
		next 

		ss += "<div style=""text-align:right""><a href=""team.aspx?ac=all"">歷屆學長姐</a></div>"
	
	else if request("ac") = "all" then
    		
		For i As Integer = 0 To dt.Rows.Count - 1

            		If ii <> dt.Rows(i).Item("year") Then
				
                			ii = dt.Rows(i).Item("year")
                			ss += "<div style=""height:1px; border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc;margin-top:5px;margin-down:5px""></div>"
                			ss += "<div style=""height:1px; border-bottom-color:#cccccc;margin-top:5px;margin-down:5px""></div>"
                			ss += "<span style=""color:#ab38ff;margin-top:20px;height:25px;"">‧" + dt.Rows(i).Item("year").ToString + "級" + "</span> | "
                			cc = 0
				
            		End If

            		cc += 1

            		ss += "<span style=""margin-left:15px; line-height:22px;""><a href=""team_info.aspx?id=" + dt.Rows(i).Item("id").ToString + """>" + dt.Rows(i).Item("name") + "(" + dt.Rows(i).Item("style") + ")" + "</a></span>"

       		Next
		
		ss += "<div style=""height:1px; border-bottom-style:dotted; border-bottom-width:1px; border-bottom-color:#cccccc;margin-top:5px;margin-down:5px""></div>"
		ss += "<div style=""text-align:right""><a href=""team.aspx?ac=present"">當屆</a></div>"

	end if

	

        Label1.Text = ss






    End Sub

End Class
