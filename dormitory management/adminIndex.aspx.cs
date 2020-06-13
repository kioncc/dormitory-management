using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dormitory_management
{
    public partial class adminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (uid.Text ==""||pwd.Text ==""||confirm_pwd.Text =="")
            {
                Response.Write("<script>alert('输入栏不能为空！')</script>");
            }
            else if (!(pwd.Text ==confirm_pwd.Text))
            {
                Response.Write("<script>alert('两次密码输入不一致！')</script>");
            }
            else
            {
                user user = new user();
                user.user_id = this.uid.Text;
                user.user_psw = this.pwd.Text;
                user.user_type = "教师";
                DormitoryEntities db = new DormitoryEntities();

                db.user.Add(user);

                if (db.SaveChanges() > 0)
                {
                    Response.Write("<script>alert('新增成功！')</script>");
                    uid.Text = "";
                    pwd.Text = "";
                    confirm_pwd.Text = "";
                }
            }          
        }
    }
}