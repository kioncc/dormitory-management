using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dormitory_management
{
    public partial class UpdatePassWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            DormitoryEntities db = new DormitoryEntities();
            var user = Session["user"] as user;
            var oidpwd = this.oidpwd.Text;
            var newpwd = this.newpwd.Text;
            var newpwdqr = this.newpwdqr.Text;

            if (newpwd.Trim() != newpwdqr.Trim())
            {
                Response.Write("<script>alert('两次输入的密码不一致！')</script>");
                return;
            }

            var info = db.user.Where(x => x.user_id == user.user_id && x.user_psw == oidpwd).FirstOrDefault();
            if (info != null)
            {
                info.user_psw = newpwd;
            }

            if (db.SaveChanges() > 0)
            {
                Response.Write("<script>alert('密码修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('密码修改失败！')</script>");
            }
        }
    }
}