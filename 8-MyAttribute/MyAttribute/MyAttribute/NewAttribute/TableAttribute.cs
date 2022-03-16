using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 获取表名特性
    /// </summary>
    //特性配置
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true,Inherited =true)]
    //特性定义
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }
        public TableAttribute()
        {

        }
        public TableAttribute(string talbeName)
        {
            TableName = talbeName;
        }
    }

 
}
