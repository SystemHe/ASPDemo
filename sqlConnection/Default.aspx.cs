using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection myconn = GetConnection();
            myconn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("select news_id,news_content from dbo.News", myconn);
            sda.Fill(ds, "News");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //DataList1.DataSource = ds;
            //DataList1.DataBind();
            Bind();
            //*************更新数据表的数据**********************
            //SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            //for (int i = 0; i < ds.Tables["News"].Rows.Count; i++)
            //{
            //ds.Tables["News"].Rows[i]["news_content"] = ds.Tables["News"].Rows[i]["news_content"].ToString() + DateTime.Today.ToShortDateString();
            //}
            //sda.Update(ds, "News");
            //GridView1.DataSource = ds;
            //GridView1.DataKeyNames = new string[] { "news_id" };
            //GridView1.DataBind();
            //sda.Dispose();
            //ds.Dispose();
            //myconn.Close();
            //**************************************************
        }
    }
    public SqlConnection GetConnection()
    {
        string mystr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        SqlConnection myconn = new SqlConnection(mystr);
        return myconn;
    }
    protected void Bind() {
        int currentPage = Convert.ToInt32(Label7.Text);
        PagedDataSource pds = new PagedDataSource();
        SqlConnection myconn = GetConnection();
        myconn.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter("select news_id,news_content from dbo.News", myconn);
        sda.Fill(ds, "News");
        pds.DataSource = ds.Tables["News"].DefaultView;
        pds.AllowPaging = true;
        pds.PageSize = 4;
        pds.CurrentPageIndex = currentPage - 1;
        LinkButton1.Enabled = true;
        LinkButton2.Enabled = true;
        LinkButton3.Enabled = true;
        LinkButton4.Enabled = true;
        if (currentPage == 1)
        {
            LinkButton1.Enabled = false;
            LinkButton2.Enabled = false;
        }
        if (currentPage == pds.PageCount)
        {
            LinkButton3.Enabled = false;
            LinkButton4.Enabled = false;
        }
        this.Label8.Text = Convert.ToString(pds.PageCount);
        DataList1.DataSource = pds;
        DataList1.DataKeyField = "news_id";
        DataList1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            SqlConnection mycon = GetConnection();
            mycon.Open();
            string str = "insert into dbo.News(news_id,news_content) values('"+TextBox1.Text+"','" + TextBox2.Text + "')";
            SqlCommand scmd = new SqlCommand(str, mycon);
            if (scmd.ExecuteNonQuery() > 0)
            {
                Response.Write("添加成功！");
            }
            else
            {
                Response.Write("添加失败！");
            }
            scmd.Dispose();
            mycon.Close();
        }
        else
        {
            Response.Write("请输入内容！");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text != "" && TextBox4.Text != "")
        {
            SqlConnection mycon = GetConnection();
            mycon.Open();
            string str2 = "update dbo.News set news_content='" + TextBox4.Text + "' where news_id='" + TextBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(str2, mycon);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("修改成功！");
            }
            else
            {
                Response.Write("修改失败！");
            }
            cmd.Dispose();
            mycon.Close();
        }
        else
        {
            Response.Write("请输入修改内容！");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text != "")
        {
            SqlConnection mycon = GetConnection();
            mycon.Open();
            string str2 = "delete from dbo.News where news_id='" + TextBox5.Text + "'";
            SqlCommand cmd = new SqlCommand(str2, mycon);
            if (cmd.ExecuteNonQuery() > 0)
            {
                cmd.Dispose();
                mycon.Close();
                Response.Write("删除成功！");
            }
            else
            {
                Response.Write("删除失败！");
            }
            
        }
        else
        {
            Response.Write("请输入要删除的编号！");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.Label7.Text = "1";
        this.Bind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        this.Label7.Text = Convert.ToString(Convert.ToInt32(this.Label7.Text) - 1);
        this.Bind();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        this.Label7.Text = Convert.ToString(Convert.ToInt32(this.Label7.Text) + 1);
        this.Bind();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        this.Label7.Text = this.Label8.Text;
        this.Bind();
    }
   
}