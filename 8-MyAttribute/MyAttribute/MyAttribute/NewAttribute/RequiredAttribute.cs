using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    //非空验证
    class RequiredAttribute : CommonValidateAttribute
    {
        public override bool IsValidate(object dataValue)
        {
            return dataValue != null && dataValue.ToString().Length != 0;
        }
    }
}
