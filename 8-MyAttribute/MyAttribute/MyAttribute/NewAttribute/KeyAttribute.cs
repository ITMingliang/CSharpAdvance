using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 主键特性
    /// </summary>
    class KeyAttribute: CommonValidateAttribute
    {
        public bool IsPrimaryKey { get; set; } = true;
        public override bool IsValidate(object dataValue)
        {
            return IsPrimaryKey;
        }
    }


}
