using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dormitory_management.tgls.apply
{
    public partial class Update : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    var info = db.course.Find(id);

                    this.course_id.Text = info.course_id;
                    this.course_name.Text = info.course_name;
                    this.course_start.Text = info.course_start;
                    this.course_over.Text = info.course_over;
                    this.course_bz.Text = info.course_bz;
                    this.teacher_id.Text = info.teacher_id;
                }
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.course_start.Text) > Convert.ToDateTime(this.course_over.Text))
            {
                Response.Write("<script>alert('课程结束时间不能早于课程开始时间！')</script>");
                return;
            }

            var now = DateTime.Now.Ticks;
            if (Convert.ToDateTime(this.course_over.Text).Ticks <= now)
            {
                Response.Write("<script>alert('课程结束日期不能早于等于今天！')</script>");
                return;
            }
            var user = Session["user"] as user;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var info = db.course.Find(id);

            var stuList = db.student.Where(x => x.course_name == info.course_name && x.teacher_id == user.user_id).ToList();

            info.course_name = this.course_name.Text;
            info.course_start = this.course_start.Text;
            info.course_over = this.course_over.Text;
            info.course_bz = this.course_bz.Text;
            info.teacher_id = user.user_id;



            foreach (var item in stuList)
            {
                item.course_name = this.course_name.Text;
            }

            var count = db.SaveChanges();
            if (count > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
                Response.Redirect("apply_list.aspx");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }

        }
    }
}