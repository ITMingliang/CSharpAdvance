using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
   public class CustomeAttribute
    {
        /// <summary>
        /// 查找特性（获取表名）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string GetTableNameAttribute<T>(T mode) where T:class
        {
            Type type = typeof(T);
            if (type.IsDefined(typeof(TableAttribute),true))
            {
                var attribute = type.GetCustomAttributes(typeof(TableAttribute), true);
               return ((TableAttribute)attribute[0]).TableName;
            }
            else
            {
                return type.Name;
            }
        }


        //public bool  IsKeyAttribute<T>(T mode) where T : class
        //{
        //    Type type = typeof(T);
        //    if (type.IsDefined(typeof(KeyAttribute), true))
        //    {
        //        var attribute = type.GetCustomAttributes(typeof(KeyAttribute), true);
        //        return ((KeyAttribute)attribute[0]).IsValidate("");
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        //通用查找方法
        public static bool Validate<T>(T model)
        {
            //获取所有属性和特性
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();
            //遍历属性和读取特性
            foreach (var property in propertyInfos)
            {
                if (property.IsDefined(typeof(CommonValidateAttribute),true))
                {
                    var attributes = property.GetCustomAttributes(typeof(CommonValidateAttribute), true);
                    foreach (var item in attributes)
                    {
                        CommonValidateAttribute attribute = item as CommonValidateAttribute;
                        if (!attribute.IsValidate(property.GetValue(model)))
                        {
                            return false;
                        }
                      
                    }
                }
            }

            return true;
        }

    }
}
