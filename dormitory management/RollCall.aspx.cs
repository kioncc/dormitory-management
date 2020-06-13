using MaxSaas.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dormitory_management
{
    public partial class RollCall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Session["user"] as user;
                usera = user;
                //
                var data = db.course.Where(x => x.teacher_id == user.user_id).ToList();
                foreach (var item in data)
                {
                    DropDownList1.Items.Add(item.course_name);
                }
                DropDownList1.DataBind();
            }
        }
        static user usera = new user();
        static DormitoryEntities db = new DormitoryEntities();
        //protected void dingming_Click(object sender, EventArgs e)
        //{
        //    var course_id = this.course_id.Text;
        //    var banji = this.banji.Text;
        //    var sex = this.sex.Text;

        //    var stuList = db.student.Where(x => x.banji.Contains(banji) && x.stu_sex.Contains(sex) && x.course_name.Contains(course_id)).ToList();

        //    if (stuList == null || stuList.Count() == 0)
        //    {
        //        Response.Write("<script>alert('符合条件的学生不存在')</script>");
        //        return;
        //    }
        //    Random rd = new Random();
        //    int i = rd.Next(0, stuList.Count());

        //    var stu = stuList[i];
        //    WinThePrize.Text = stu.stu_name;
        //}



        [WebMethod]
        public static string GetSj(string banji, string sex, string course_id)
        {
            //查询满足满足搜索条件的学生 并且过滤为当前登录老师的学生
            studentList = db.student.Where(x => x.banji.Contains(banji) && x.stu_sex.Contains(sex) && x.course_name == course_id && x.teacher_id == usera.user_id).ToList();
            Random rd = new Random();
            //系统生成随机数 0-学生的数量
            int i = rd.Next(0, studentList.Count());

            if (studentList.Count() == 0)
            {
                return "学生不存在";
            }

            //获取系统生成的随机数然后获取到下标的学生
            return studentList[i].stu_name; ;
        }

        public static List<student> studentList = new List<student>();

        protected void absence_Click(object sender, EventArgs e)
        {

            var course_id = this.DropDownList1.Text;
            var banji = this.banji.Text;
            var sex = this.sex.Text;

            var studentList = db.student.Where(x => x.banji.Contains(banji) && x.stu_sex.Contains(sex) && x.course_name == course_id && x.teacher_id == usera.user_id).ToList();

            if (studentList == null || studentList.Count() == 0)
            {
                Response.Write("<script>alert('符合条件的学生不存在')</script>");
                return;
            }
        }

        [WebMethod]
        public static string GetData(string banji, string sex, string course_id)
        {
            studentList = db.student.Where(x => x.banji.Contains(banji) && x.stu_sex.Contains(sex) && x.course_name.Contains(course_id) && x.teacher_id == usera.user_id).ToList();

            var json = JsonHelper.ObjectToJson(studentList);
            return json;
        }

        public static SpeechSynthesizer voice = new SpeechSynthesizer();

        [WebMethod]
        public static string For(string json, string type, string course_id)
        {

            var stu = JsonHelper.JsonToObject<student>(json);
            var attendance = new attendance();
            attendance.student_id = stu.stu_id;
            attendance.student_name = stu.stu_name;
            attendance.atd_state = type == "True" ? "正常出勤" : "缺勤";
            attendance.atd_time = DateTime.Now;
            attendance.course_id = course_id;
            attendance.teacher_id = usera.user_id;
            db.attendance.Add(attendance);
            db.SaveChanges();


            return "";
        }

    }
}