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
using System.Data.OleDb;
using System.IO;
using Model;
using MaxSaas.Helper;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text.RegularExpressions;

namespace dormitory_management.tgls.student
{
    public partial class student_add : System.Web.UI.Page
    {

        DormitoryEntities db = new DormitoryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Session["user"] as user;

                //
                var data = db.course.Where(x => x.teacher_id == user.user_id).ToList();
                foreach (var item in data)
                {
                    DropDownList1.Items.Add(item.course_name);
                }
                DropDownList1.DataBind();
            }
        }
        //添加
        protected void _TJ_Click(object sender, EventArgs e)
        {
            var count = 0;
            var user = Session["user"] as user;
            //判断是否导入文件
            if (FileUpload1.HasFile)
            {
                var name = FileUpload1.FileName;
                var fullPath = FileUpload1.PostedFile.FileName;
                if (!name.Contains(".xls"))
                {
                    Response.Write("<script>alert('请导入xls文件！')</script>");
                    return;
                }

                var path = fullPath;
                var table = Helper.GetExcel(path);


                var Course = db.course.Select(x => x.course_name).ToArray();
                for (int i = 1; i < table.Rows.Count; i++)
                {

                    var obj = table.Rows[i];
                    var stuid = obj[0].ToString();
                    var course = obj[4].ToString();
                    var repeat = db.student.Where(x => x.stu_id == stuid && x.course_name == course && x.teacher_id == user.user_id).ToList();

                    if (!Course.Contains(obj[4].ToString()))
                    {
                        Response.Write($"<script>alert('不存在课程{obj[4].ToString()}！ 确认继续新增其他记录')</script>");
                        continue;
                    }

                    if (repeat.Count > 0)
                    {
                        Response.Write("<script>alert('学号" + obj[0].ToString() + " 已经存在 " + obj[4].ToString() + " ！ 确认继续新增其他记录')</script>");
                        continue;
                    }


                    Regex rx1 = new Regex(@"^1[3,5,8]\d{9}$");
                    if (!rx1.IsMatch(obj[3].ToString()) && !(obj[3].ToString() == "")) //不匹配
                    {
                        Response.Write($"<script>alert('学号{obj[0].ToString()}的手机号格式不对，确认继续新增其他记录！！')</script>");
                        continue;
                    }

                    Regex rx2 = new Regex(@"^\d{13}$");
                    if (!rx2.IsMatch(obj[0].ToString())) //不匹配
                    {
                        if (obj[0].ToString() == "")
                        {
                            Response.Write($"<script>alert('学号不允许为空，确认继续新增其他记录！！')</script>");
                            continue;
                        }
                        Response.Write($"<script>alert('学号{obj[0].ToString()}格式不对，确认继续新增其他记录！！')</script>");
                        continue;
                    }                   

                    var info = new Model.student();
                    var repeat1 = db.student.Where(x => x.stu_id == stuid && x.course_name == course && x.teacher_id == user.user_id).ToList();
                    info.stu_id = obj[0].ToString();
                    info.stu_name = obj[1].ToString();
                    info.stu_sex = obj[2].ToString();
                    info.stu_tel = obj[3].ToString();
                    info.course_name = obj[4].ToString();
                    info.banji = obj[5].ToString();
                    info.teacher_id = user.user_id;
                    db.student.Add(info);
                    count = db.SaveChanges();
                }
            }//导入结束
            else
            {
                if (stu_id.Text == "" || stu_name.Text == "" || banji.Text == "" || stu_tel.Text == "")
                {
                    Response.Write("<script>alert('请填写完整信息！！')</script>");
                    return;
                }
                var sex = "";
                if (RadioButton1.Checked)
                {
                    sex = "男";
                }
                else if (RadioButton2.Checked)
                {
                    sex = "女";
                }

                Regex rx1 = new Regex(@"^1[3,5,8]\d{9}$");
                if (!rx1.IsMatch(this.stu_tel.Text)) //不匹配
                {
                    Response.Write("<script>alert('手机号格式不对，请重新输入！！')</script>");
                    return;
                }
                
                Regex rx2 = new Regex(@"^\d{13}$");
                if (!rx2.IsMatch(this.stu_id.Text)) //不匹配
                {
                    Response.Write("<script>alert('学号只能为13位数字，请重新输入！！')</script>");
                    return;
                }


                var stu = new Model.student();
                stu.stu_id = this.stu_id.Text;
                stu.stu_name = this.stu_name.Text;
                stu.stu_sex = sex;
                stu.banji = this.banji.Text;
                stu.teacher_id = user.user_id;
                stu.stu_tel = this.stu_tel.Text; //
                stu.course_name = this.DropDownList1.Text;


                var repeat = db.student.Where(x => x.stu_id == stu.stu_id && x.course_name == DropDownList1.Text && x.teacher_id == user.user_id).ToList();
                if (repeat.Count() > 0)
                {
                    Response.Write("<script>alert('记录已经存在！')</script>");
                    return;
                }
                db.student.Add(stu);
                count = db.SaveChanges();
            }

            if (count > 0)
            {
                Response.Write("<script>alert('新增成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('数据库无改动！')</script>");
            }
        }

        //修改
        protected void _CZ_Click(object sender, EventArgs e)
        {

            var sex = "";
            var user = Session["user"] as user;
            if (RadioButton1.Checked)
            {
                sex = "男";
            }
            else if (RadioButton2.Checked)
            {
                sex = "女";
            }
            if (stu_id.Text == "" || stu_name.Text == "" || banji.Text == "" || stu_tel.Text == "")
            {
                Response.Write("<script>alert('请填写完整信息！！')</script>");
                return;
            }

            Regex rx1 = new Regex(@"^1[3,5,8]\d{9}$");
            if (!rx1.IsMatch(this.stu_tel.Text)) //不匹配
            {
                Response.Write("<script>alert('手机号格式不对，请重新输入！！')</script>");
                return;
            }

            Regex rx2 = new Regex(@"^\d{13}$");
            if (!rx2.IsMatch(this.stu_id.Text)) //不匹配
            {
                Response.Write("<script>alert('学号只能为13位数字，请重新输入！！')</script>");
                return;
            }

            var repeat = db.student.Where(x => x.stu_id == this.stu_id.Text && x.teacher_id == user.user_id).ToList().FirstOrDefault();
            repeat.stu_name = this.stu_name.Text;
            repeat.stu_sex = sex;
            repeat.teacher_id = user.user_id;
            repeat.banji = this.banji.Text;
            repeat.stu_tel = this.stu_tel.Text;
            repeat.course_name = this.DropDownList1.Text;
            var count = db.SaveChanges();
            if (count > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }

        }

        protected void xz_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user = Session["user"] as user;
            var stu_id = this.stu_id.Text;
            var info = db.student.Where(x => x.stu_id == stu_id && x.teacher_id == user.user_id).FirstOrDefault();

            if (info == null)
            {
                Response.Write("<script>alert('未找到学生！')</script>");
                return;
            }

            this.stu_id.Text = info.stu_id;
            this.stu_name.Text = info.stu_name;

            if (info.stu_sex == "男")
            {
                this.RadioButton1.Checked = true;
            }
            else
            {
                this.RadioButton2.Checked = true; ;
            }
            this.banji.Text = info.banji;
            this.stu_tel.Text = info.stu_tel;

        }
    }
}
