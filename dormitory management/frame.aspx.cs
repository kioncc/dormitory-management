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
    public partial class frame : System.Web.UI.Page
    {
        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                ////var user = Session["user"] as user;
                //int id = Convert.ToInt32(Request.QueryString["id"]);
                ////var list = db.teacher.Where(x => x.teacher_id == user.user_id).ToList();
                //var info = db.teacher.Find(id);
                //this.teacher_name.Text = info.teacher_name;
            }
        }
    }
}