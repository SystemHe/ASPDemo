using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
            Bind2();
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            DataList1.SelectedIndex = e.Item.ItemIndex;
            Bind();
        }
        if (e.CommandName == "back")
        {
            DataList1.SelectedIndex = -1;
            Bind();
        }
    }
    public void Bind()
    {
        SqlConnection con = GetConnection();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("select * from tb_student", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "tb_student");
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }
    protected void DataList2_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList2.EditItemIndex = e.Item.ItemIndex;
        Bind2();
    }
    public SqlConnection GetConnection()
    {
        string mystr = "server=.;database=ASP_Test;uid=he;pwd=123456";
        SqlConnection myconn = new SqlConnection(mystr);
        return myconn;
    }
    public void Bind2()
    {

        SqlConnection con2 = GetConnection();
        con2.Open();
        SqlDataAdapter sda2 = new SqlDataAdapter("select * from tb_student", con2);
        DataSet ds2 = new DataSet();
        sda2.Fill(ds2, "tb_student");
        DataList2.DataSource = ds2;
        DataList2.DataBind();
    }
    protected void DataList2_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        string stuID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        string stuName = ((TextBox)e.Item.FindControl("TextBox1")).Text;
        string stuAge = ((TextBox)e.Item.FindControl("TextBox2")).Text;
        string stuSex = ((TextBox)e.Item.FindControl("TextBox3")).Text;
        string stuHobby = ((TextBox)e.Item.FindControl("TextBox4")).Text;
        string strSql = "update tb_student set 姓名='" + stuName + "',年龄='" + stuAge + "',性别='" + stuSex + "',爱好='" + stuHobby + "' where ID='"+stuID+"'";
        SqlConnection conn = GetConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand(strSql, conn);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
        DataList2.EditItemIndex = -1;
        Bind2();
    }
    protected void DataList2_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList2.EditItemIndex = -1;
        Bind2();
    }
}