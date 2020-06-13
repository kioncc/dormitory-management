using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;

namespace dormitory_management
{
    public partial class xiugai : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //修改根据ID获取数据自动绑定文本框
                int id = Convert.ToInt32(Request.QueryString["id"]);
                var info = db.user.Find(id);

                this.user_id.Text = info.user_id;
                this.user_pwd.Text = info.user_psw;

            }
        }

        protected void update_Click(object sender, EventArgs e)
        {                       
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var repeat = db.user.Find(id);
            var user = Session["user"] as user;
            repeat.user_id = this.user_id.Text;
            repeat.user_psw = this.user_pwd.Text;
            var count = db.SaveChanges();
            if (count > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
                Response.Redirect("adminchange.aspx");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }
        }
    }
}