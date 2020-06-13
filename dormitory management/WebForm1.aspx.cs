using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dormitory_management
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Session["user"] as user;
                var list = db.teacher.Where(x => x.teacher_id == user.user_id).FirstOrDefault();
                teacher_name.Text = list.teacher_name;
                teacher_sex.Text = list.teacher_sex;
                teacher_tel.Text = list.teacher_tel;
                teacher_qq.Text = list.teacher_qq; 

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}