using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 邮箱验证
    /// </summary>
    class EmailAddressAttribute : CommonValidateAttribute
    {
        public override bool IsValidate(object dataValue)
        {
            Regex regex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            return regex.IsMatch(dataValue.ToString());
        }
    }
}
