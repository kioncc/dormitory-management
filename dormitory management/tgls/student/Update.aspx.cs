using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace dormitory_management.tgls.student
{
    public partial class Update : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //修改根据ID获取数据自动绑定文本框
                int id = Convert.ToInt32(Request.QueryString["id"]);
                var info = db.student.Find(id);

                this.stu_id.Text = info.stu_id;
                this.stu_name.Text = info.stu_name;

                if (info.stu_sex == "男")
                {
                    this.RadioButton1.Checked = true;
                }
                else
                {
                    this.RadioButton2.Checked = true; ;
                }
                this.banji.Text = info.banji;
                this.stu_tel.Text = info.stu_tel;
                this.course_name.Text = info.course_name;
            }           
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Regex rx1 = new Regex(@"^1[3,5,8]\d{9}$");
            if (!rx1.IsMatch(this.stu_tel.Text)) //不匹配
            {
                Response.Write("<script>alert('手机号格式不对，请重新输入！！')</script>");
                return;
            }

            Regex rx2 = new Regex(@"^\d{13}$");
            if (!rx2.IsMatch(this.stu_id.Text)) //不匹配
            {
                Response.Write("<script>alert('学号只能为13位数字，请重新输入！！')</script>");
                return;
            }
            //修改实体
            var sex = "女";
            if (RadioButton1.Checked)
            {
                sex = "男";
            }

            int id = Convert.ToInt32(Request.QueryString["id"]);
            var repeat = db.student.Find(id);
            var user = Session["user"] as user;
            repeat.stu_name = this.stu_name.Text;
            repeat.stu_sex = sex;
            repeat.banji = this.banji.Text;
            repeat.stu_tel = this.stu_tel.Text;
            repeat.course_name = this.course_name.Text;
            var count = db.SaveChanges();
            if (count > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
                Response.Redirect("student_list.aspx");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }
        }
    }
}