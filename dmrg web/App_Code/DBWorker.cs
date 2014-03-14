using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
/// <summary>
/// SqlDbWork 的摘要描述
/// </summary>
public class DBWorker
{

    static string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();

    public static int Insert(string Sql)
    {
        
        int a;
        MySqlConnection Conn = new MySqlConnection(connString);
        Conn.Open();
        MySqlCommand Com = new MySqlCommand(Sql, Conn);
        a = Com.ExecuteNonQuery();
        Conn.Close();
        return a;
    }

    public static int UpDate(string Sql)
    {
       
        int a;
        MySqlConnection Conn = new MySqlConnection(connString);
        Conn.Open();
        MySqlCommand Com = new MySqlCommand(Sql, Conn);
        a = Com.ExecuteNonQuery();
        Conn.Close();
        return a;
    }

    public static int Delete(string Sql)
    {
        
        int a;
        MySqlConnection Conn = new MySqlConnection(connString);
        Conn.Open();
        MySqlCommand Com = new MySqlCommand(Sql, Conn);
        a = Com.ExecuteNonQuery();
        Conn.Close();
        return a;
    }

    public static void Read(string Sql, ref DataTable dt)
    {
            MySqlDataAdapter adpt = new MySqlDataAdapter();
            MySqlConnection conn = new MySqlConnection(connString);
            DataSet ds = new DataSet();
            conn.Open();
            adpt = new MySqlDataAdapter(Sql, conn);
            adpt.Fill(ds, "資料");
            dt = ds.Tables["資料"];
            conn.Close();
    
    }

}