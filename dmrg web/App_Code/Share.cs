using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Collections;

/// <summary>
/// Class1 的摘要描述
/// </summary>
public class Share
{
	public Share()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public static void MsgBox(System.Web.UI.Page parentPage, string Msg)
    {
        parentPage.ClientScript.RegisterClientScriptBlock(parentPage.GetType(), "msg", "<script>alert('" + Msg + "');</script>");
    }

    public static string GetSqlStr(string str)
    {
        return str.Replace("'", "''");
    }

    // 傳來檔案全名,取得檔案的副檔名
    public static string GetFileStytle(string FileName)
    {
        return FileName.Substring(FileName.LastIndexOf(".") + 1, FileName.Length - FileName.LastIndexOf(".") - 1);
    }

    // 刪除路徑下的指定檔案名子的所有副檔名的檔案 

    public static void Del_File(string Path, string fileName)
    {
        string[] files = Directory.GetFiles(Path);

        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].IndexOf(fileName) >= 0)
            {
                File.Delete(files[i]);
            }
        }

    }
}
