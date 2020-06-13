using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dormitory_management
{
    public partial class newLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                //登陆
                DormitoryEntities db = new DormitoryEntities();
                var uid = username.Text;
                var pwd = userpsw.Text;
                var user = db.user.Where(x => x.user_id == uid && x.user_psw == pwd).FirstOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    if (user.user_type == "教师")  //如果是老师进进入老师页面
                    {
                        Response.Redirect("frame.aspx");
                    }
                    else
                    {
                        Response.Redirect("teacher.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('用户名或密码错误！')</script>");
                }
            }
        }
    }
}