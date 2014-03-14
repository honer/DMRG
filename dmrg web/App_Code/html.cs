using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// html 的摘要描述
/// </summary>
public class html
{
	public html()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public static string html_remove(string data,string remove_header)
    {   

        //if (data.IndexOf(remove_header) >= 0 && data.IndexOf("/" + remove_header) >= 0)
        //{
        //    data = data.Remove(data.IndexOf("<" + remove_header + ">"), data.IndexOf("</" + remove_header + ">") - data.IndexOf("<" + remove_header + ">") + remove_header.Length + 3);
        //}

        //return data;

        if (data.IndexOf(remove_header) >= 0 && data.IndexOf("/" + remove_header) >= 0)
        {
            data = data.Remove(data.IndexOf(remove_header) - 1, data.IndexOf("/" + remove_header) - data.IndexOf(remove_header) + 9);
        }

        return data;
    }

    public static int set_all_control_att(System.Web.UI.Page page, string key, string value)
    {
        int count = 0;

        foreach (Control cc in page.Controls)
        {
            if (cc is TextBox)
            {
                TextBox tt = (TextBox)cc;
                tt.Attributes.Add(key, value);
                count++;
            }
        }

        return count;
    }

    public static string Verify(string data)
    {
        //string data;
        //if (html.IndexOf("script") >= 0 && html.IndexOf("/script") >= 0)
        //{
        //    data = html.Remove(html.IndexOf("script") - 1, html.IndexOf("/script") - html.IndexOf("script") + 9);
        //}
        //else if (html.IndexOf("<iframe>") >= 0 && html.IndexOf("</iframe>") >= 0)
        //{
        //    data = html.Remove(html.IndexOf("<iframe>"), html.IndexOf("</iframe>") - html.IndexOf("<iframe>") + 9);
        //}
        //else
        //{
        //    data = html;
        //}

        data = html_remove(data, "script");
        data = html_remove(data, "iframe");

        return data;
    
    }
}
