using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dormitory_management
{
    public partial class Record : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();

        public static List<attendance> list = new List<attendance>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var user = Session["user"] as user;
                list = db.attendance.Where(x => x.teacher_id == user.user_id).ToList();
                GridView1.AutoGenerateColumns = false;
                GridView1.DataSource = list;
                GridView1.DataBind();



                var data = db.course.Where(x => x.teacher_id == user.user_id).ToList();
                foreach (var item in data)
                {
                    DropDownList1.Items.Add(item.course_name);
                }
                DropDownList1.DataBind();
            }
        }

        protected void select_Click(object sender, EventArgs e)
        {
            try
            {
                var user = Session["user"] as user;
                var type = this.type.Text;
                var start = Convert.ToDateTime(this.start.Text); //开始
                var end = Convert.ToDateTime(this.end.Text);    //结束

                var select = DropDownList1.Text;
                if (start > end)
                {
                    Response.Write("<script>alert('结束时间不能早于开始时间！')</script>");
                    return;
                }
                list = db.attendance.Where(x => x.atd_state.Contains(type) && x.course_id == select && x.teacher_id == user.user_id && x.atd_time.Value.Day >= start.Day
                && x.atd_time.Value.Day <= end.Day).ToList();

                GridView1.DataSource = list;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('请输入查询时间！')</script>");
            }

        }


        protected void output_Click1(object sender, EventArgs e)
        {
            var table = Helper.ListToDataTable<attendance>(list);
            var path = @"E:\File\";

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            var filename = DateTime.Now.Ticks;
            var filepath = $"{path}{filename}.csv";
            Helper.ToCsv(table, filepath);
            Response.Write("<script>alert('导出成功')</script>");
        }
    }
}