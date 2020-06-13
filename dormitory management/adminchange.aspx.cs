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

namespace dormitory_management
{
    public partial class adminchange : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {   //第一次加载页面时 加载列表数据
            if (!Page.IsPostBack)
            {
                var user = Session["user"] as user;
                var type = "教师";
                var list = db.user.Where(x => x.user_type == type).ToList();
                GridView1.AutoGenerateColumns = false;
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //获取操作类型 是删除就执行
            if (e.CommandName == "Del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var info = db.user.Find(id); //获取删除的信息
                if (info != null)
                {
                    db.user.Remove(info); //删除
                }
                if (db.SaveChanges() > 0)
                {
                    //删除之后查询刷新表单
                    var type = "教师";
                    Response.Write("<script>alert('删除成功')</script>");
                    var list = db.user.Where(x => x.user_type == type).ToList();
                    GridView1.AutoGenerateColumns = false;
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                };
            }
        }

        protected void select_Click(object sender, EventArgs e)
        {
            //根据输入的条件查询
            var acc_name = this.acc_name.Text;
            var type = "教师";
            var list = db.user.Where(x => x.user_id.Contains(acc_name)&&x.user_type == type).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();

        }
    }
}