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
using Model;
using System.Text.RegularExpressions;

namespace dormitory_management.tgls.apply
{
    public partial class history : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {   //第一次加载页面时
            if (!Page.IsPostBack)
            {
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {

            try
            {
                var repeat = db.course.Where(x => x.course_id == course_id.Text).ToList();
                if (repeat.Count() > 0)
                {
                    Response.Write("<script>alert('课程编号已经存在！')</script>");
                    return;
                }

                var user = Session["user"] as user;
                var info = new course();
                info.course_id = this.course_id.Text;
                info.course_name = this.course_name.Text;
                info.course_start = this.course_start.Text;
                info.course_over = this.course_over.Text;
                info.course_bz = this.course_bz.Text;
                info.teacher_id = user.user_id;

                Regex rx1 = new Regex(@"^\d{5,7}$");

                var now = DateTime.Now.Ticks;

                if (this.course_id.Text == "")
                {
                    Response.Write("<script>alert('请输入课程编号！')</script>");
                    return;
                }
                else if (!rx1.IsMatch(this.course_id.Text))
                {
                    Response.Write("<script>alert('课程编号为5-7位数字，请重新输入！！')</script>");
                    return;
                }
                else if (this.course_name.Text == "")
                {
                    Response.Write("<script>alert('请输入课程名称！')</script>");
                    return;
                }
                else if (Convert.ToDateTime(this.course_start.Text) > Convert.ToDateTime(this.course_over.Text))
                {
                    Response.Write("<script>alert('课程结束时间不能早于课程开始时间！')</script>");
                    return;
                }
                else if (Convert.ToDateTime(this.course_over.Text).Ticks <= now)
                {
                    Response.Write("<script>alert('课程结束日期不能早于等于今天！')</script>");
                    return;
                }



                db.course.Add(info);
                if (db.SaveChanges() > 0)
                {
                    Response.Write("<script>alert('新增成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('新增失败！')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('请输入开始结束时间！')</script>");
            }

        }
    }
}