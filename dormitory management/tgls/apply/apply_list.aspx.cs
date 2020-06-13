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

namespace dormitory_management.tgls.apply
{
    public partial class apply_list : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {   //第一次加载页面时
            if (!Page.IsPostBack)
            {
                var user = Session["user"] as user;
                var list = db.course.Where(x => x.teacher_id == user.user_id).ToList();
                GridView1.AutoGenerateColumns = false;
                GridView1.DataSource = list;
                GridView1.DataBind();


                GridView1.Columns[0].Visible = false;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var info = db.course.Find(id);
                if (info != null)
                {
                    db.course.Remove(info);
                }
                var user = Session["user"] as user;
                var stuList = db.student.Where(x => x.course_name == info.course_name && x.teacher_id == user.user_id).ToList();

                foreach (var item in stuList)
                {
                    var stu = db.student.Find(item.id);
                    if (stu != null)
                    {
                        db.student.Remove(stu);
                    }
                }

                if (db.SaveChanges() > 0)
                {
                    Response.Write("<script>alert('删除成功')</script>");
                    var list = db.course.ToList();
                    GridView1.AutoGenerateColumns = false;
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                };
            }
        }

        protected void select_Click(object sender, EventArgs e)
        {
            var user = Session["user"] as user;
            var course_id = this.course_id.Text;
            var course_name = this.course_name.Text;
            var list = db.course.Where(x => x.course_id.Contains(course_id) && x.course_name.Contains(course_name) && x.teacher_id == user.user_id).ToList();

            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}