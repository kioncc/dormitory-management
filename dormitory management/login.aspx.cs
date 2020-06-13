using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dormitory_management
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            //获取文本框中的值
            string userid = this.user.Text;
            string password = this.pwd.Text;
            string type;
            Session["loginname"] = this.user.Text;//j获取当前用户账号信息
            if (_teacher.Checked)
            {
                type = _teacher.Text;
            }
            else
                type = _user.Text;
            if (userid.Equals("") || password.Equals(""))//用户名或密码为空
            {
                Response.Write("<script>alert('用户名和密码不能为空！')</script>");
            }
            else//用户名或密码不为空
            {
                string Connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\message.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection SqlCon = new SqlConnection(Connstring); //数据库连接
                SqlCon.Open(); //打开数据库
                string sql = "select * from [user] where userid='" + userid + "' and userpwd='" + password + "' and  _type=N'" + type + "'";//查找用户sql语句
                SqlCommand cmd = new SqlCommand(sql, SqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                if (sdr.Read())         //从结果中找到
                {
                    if (type == "教师")
                    {
                        Response.Redirect("frame.aspx");
                    }
                    else
                        Response.Redirect("frame_student.aspx");
                }
                else
                {
                    Response.Write("<script>alert('用户名或密码错误！')</script>");
                    return;
                }
                SqlCon.Close();
            }
        }


    }
}