using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using Model;
using MaxSaas.Helper;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text.RegularExpressions;

namespace dormitory_management
{
    public partial class person : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

                var user = Session["user"] as user;
                this.teacher_id.Text = user.user_id;

        }

        protected void _TJ_Click(object sender, EventArgs e)
        {
            var count = 0;
            var user = Session["user"] as user;
            

            if (teacher_id.Text == "" || teacher_name.Text == "" || teacher_tel.Text == "" || teacher_qq.Text == "")
            {
                Response.Write("<script>alert('至少填写姓名、手机号和邮箱！！')</script>");
                return;
            }

            Regex rx1 = new Regex(@"^1[3,5,8]\d{9}$");
            if (!rx1.IsMatch(this.teacher_tel.Text)) //不匹配
            {
                Response.Write("<script>alert('手机号格式不对，请重新输入！！')</script>");
                return;
            }

            Regex rx2 = new Regex(@"^[A-Za-z0-9_-]+@qq\.com$");
            if (!rx2.IsMatch(this.teacher_qq.Text)) //不匹配
            {
                Response.Write("<script>alert('QQ邮箱格式不正确，请重新输入！！')</script>");
                return;
            }

            var sex = "";
            if (RadioButton1.Checked)
            {
                sex = "男";
            }
            else if (RadioButton2.Checked)
            {
                sex = "女";
            }

            var teacher = new Model.teacher();
            teacher.teacher_name = this.teacher_name.Text;
            teacher.teacher_sex = sex;
            teacher.teacher_id = user.user_id;
            teacher.teacher_tel = this.teacher_tel.Text; 


            var repeat = db.teacher.Where(x => x.teacher_id == this.teacher_id.Text).ToList();
            if (repeat.Count() > 0)
            {
                Response.Write("<script>alert('教师编号已经存在！')</script>");
                return;
            }
            else
            {
                db.teacher.Add(teacher);
                count = db.SaveChanges();
            }
            if (count > 0)
            {
                Response.Write("<script>alert('新增成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('数据库无改动！')</script>");
            }
        }

        protected void _CZ_Click(object sender, EventArgs e)
        {
            var user = Session["user"] as user;

            if (teacher_id.Text == "" || teacher_name.Text == "" || teacher_tel.Text == "" || teacher_qq.Text == "")
            {
                Response.Write("<script>alert('至少填写姓名、手机号和邮箱！！')</script>");
                return;
            }

            Regex rx1 = new Regex(@"^1[3,5,8]\d{9}$");
            if (!rx1.IsMatch(this.teacher_tel.Text)) //不匹配
            {
                Response.Write("<script>alert('手机号格式不对，请重新输入！！')</script>");
                return;
            }

            Regex rx2 = new Regex(@"^[A-Za-z0-9_-]+@qq\.com$");
            if (!rx2.IsMatch(this.teacher_qq.Text)) //不匹配
            {
                Response.Write("<script>alert('QQ邮箱格式不正确，请重新输入！！')</script>");
                return;
            }
            var sex = "";
            if (RadioButton1.Checked)
            {
                sex = "男";
            }
            else if (RadioButton2.Checked)
            {
                sex = "女";
            }

            var teacher = db.teacher.Where(x => x.teacher_id == user.user_id).ToList().FirstOrDefault();
            teacher.teacher_name = this.teacher_name.Text;
            teacher.teacher_sex = sex;
            teacher.teacher_tel = this.teacher_tel.Text;
            teacher.teacher_qq = this.teacher_qq.Text;
            var count = db.SaveChanges();
            if (count > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }

        }
    }
}