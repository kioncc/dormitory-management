using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace dormitory_management
{
    public static class Helper
    {
        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="entitys">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            try
            {
                //检查实体集合不能为空
                if (entitys == null || entitys.Count < 1)
                {
                    throw new Exception("需转换的集合为空");
                }
                //取出第一个实体的所有Propertie
                Type entityType = entitys[0].GetType();

                PropertyInfo[] entityProperties = entityType.GetProperties();

                //生成DataTable的structure
                //生产代码中，应将生成的DataTable结构Cache起来，此处略
                DataTable dt = new DataTable();
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    dt.Columns.Add(entityProperties[i].Name);
                }

                foreach (object entity in entitys)
                {
                    if (entity == null)
                    {
                        continue;
                    }
                    //检查所有的的实体都为同一类型
                    if (entity.GetType() != entityType)
                    {
                        throw new Exception("要转换的集合元素类型不一致");
                    }
                    object[] entityValues = new object[entityProperties.Length];
                    for (int i = 0; i < entityProperties.Length; i++)
                    {
                        entityValues[i] = entityProperties[i].GetValue(entity, null);
                    }
                    dt.Rows.Add(entityValues);
                }
                return dt;
            }
            catch (Exception ex)
            {
                //throw ex;
                //Response.Write("<script>alert('查询结果为空！')</script>");
                System.Web.HttpContext.Current.Response.Write("<script>alert('查询结果为空！')</script>");
                DataTable dt = new DataTable();
                return dt;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">datatable数据</param> 
        /// <param name="path">文件夹路径</param>
        /// <param name="fileName">文件路径</param>
        public static void ToCsv(DataTable table, string fileName)
        {
            Console.WriteLine($"table读取数据条数:{table.Rows.Count}");
            //以半角逗号（即,）作分隔符，列为空也要表达其存在。
            //列内容如存在半角逗号（即,）则用半角引号（即""）将该字段值包含起来。
            //列内容如存在半角引号（即"）则应替换成半角双引号（""）转义，并用半角引号（即""）将该字段值包含起来。
            StringBuilder sb = new StringBuilder();

            sb.Append("学号,学生姓名,出勤状态,考勤时间,课程名称,教师编号");
            sb.AppendLine();
            DataColumn colum;
            int count = 0;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    colum = table.Columns[i];

                    if (colum.ColumnName == "id")
                    {
                        continue;
                    }
                    if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                    {
                        sb.Append(" " + "\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                    }
                    else
                    {
                        var txt = row[colum].ToString();
                        sb.Append($"\t{txt}");
                    }

                    sb.Append(",");
                }
                sb.AppendLine();
                count++;
            }

            File.WriteAllText(fileName, sb.ToString());

        }


        public static DataTable GetExcel(string filePath, string Sheet = "Sheet1")
        {
            string strExtension = System.IO.Path.GetExtension(filePath);
            OleDbConnection connection = null;

            #region 判断 .xls与.xlsx文件

            //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串) 
            //"HDR=yes;"是说Excel文件的第一行是列名而不是数，"HDR=No;"正好与前面的相反。"IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。 
            switch (strExtension)
            {
                case ".xls":
                    connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";" + "Extended Properties=\"Excel 8.0;HDR=No;IMEX=1;\"");
                    break;
                case ".xlsx":
                    connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";" + "Extended Properties=\"Excel 12.0;HDR=No;IMEX=1;\"");
                    break;
                default:
                    connection = null;
                    break;
            }
            if (connection == null)
            {
                return null;
            }

            #endregion

            connection.Open();
            string sql = @"Select * from [" + Sheet + "$]";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var data = ds.Tables[0];

            return data;
        }
    }
}