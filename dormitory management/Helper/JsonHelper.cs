using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxSaas.Helper
{
    public static class JsonHelper
    {

        /// <summary>
        /// json转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            try
            {

                return JsonConvert.DeserializeObject<T>(json);

            }
            catch (Exception ex)
            {

                throw new Exception("json转对象失败" + ex.Message);
            }
        }

        /// <summary>
        /// 对象转json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }
    }
}
