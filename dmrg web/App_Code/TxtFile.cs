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

/// <summary>
/// TxtFile 的摘要描述
/// </summary>
public static class TxtFile
{
    public static string Read(string file,System.Text.Encoding en)
    {
        String data = "";
        String line = "";
        StreamReader sr = new StreamReader(file,en);
        
       

        while ((line = sr.ReadLine()) != null)
        {
            data += line + "\n";        
        }

        sr.Close();
        sr.Dispose();

        return data;
    }

    // 此程式從一個字串資料裡利用兩個字串值來取得此兩個字串範圍裡的字串

    public static string GetDataInRange(string data,string startStr, string endStr)
    {
        int intStartIndex = data.IndexOf(startStr);

        string strTemp = data.Substring(intStartIndex, data.Length - intStartIndex);

        int intEndIndex = strTemp.IndexOf(endStr);


        return data.Substring(intStartIndex, intEndIndex + 1);
    }

    // 讀取CSS的值
    // file 檔案路徑
    // id css的 id 例如: .topClass
    // style css 的 style 例如: color  

   



}
