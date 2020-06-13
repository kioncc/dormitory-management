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
using System.Web.Services;

namespace dormitory_management
{
    public partial class student_list : System.Web.UI.Page
    {



        public static List<student> list = new List<student>();
        protected void Page_Load(object sender, EventArgs e)
        {   //第一次加载页面时 加载列表数据
            if (!Page.IsPostBack)
            {
                DormitoryEntities db = new DormitoryEntities();
                var user = Session["user"] as user;
                list = db.student.Where(x => x.teacher_id == user.user_id).ToList();
                GridView1.AutoGenerateColumns = false;
                GridView1.DataSource = list;
                GridView1.DataBind();

                GridView1.Columns[0].Visible = false;

                var data = db.course.Where(x => x.teacher_id == user.user_id).ToList();
                foreach (var item in data)
                {
                    DropDownList1.Items.Add(item.course_name);
                }
                DropDownList1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DormitoryEntities db = new DormitoryEntities();
            //获取操作类型 是删除就执行
            if (e.CommandName == "Del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var info = db.student.Find(id); //获取删除的信息
                if (info != null)
                {
                    db.student.Remove(info); //删除
                }
                if (db.SaveChanges() > 0)
                {
                    //删除之后查询刷新表单
                    Response.Write("<script>alert('删除成功')</script>");
                    list = db.student.ToList();
                    GridView1.AutoGenerateColumns = false;
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                };
            }
        }

        protected void select_Click(object sender, EventArgs e)
        {
            //根据输入的条件查询
            DormitoryEntities db = new DormitoryEntities();
            var user = Session["user"] as user;
            var stu_name = this.stu_name.Text;
            var banji = this.banji.Text;
            var select = DropDownList1.Text;
            list = db.student.Where(x => x.stu_name.Contains(stu_name) && x.course_name == select && x.banji.Contains(banji) && x.teacher_id == user.user_id).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();

        }


        [WebMethod]
        public static string Delete()
        {
            DormitoryEntities db = new DormitoryEntities();
            foreach (var item in list)
            {
                var info = db.student.Find(item.id);
                if (info != null)
                {
                    db.student.Remove(info); //删除
                }
            }
            if (db.SaveChanges() > 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }

        }
    }
}