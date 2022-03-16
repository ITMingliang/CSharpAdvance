using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 字符串长度验证
    /// </summary>
    class StringLengthAttribute: CommonValidateAttribute
    {
        public int MaximumLength { get; set; }
        public int MinimumLength { get; set; }

        public StringLengthAttribute(int max,int min)
        {
            MaximumLength = max;
            MinimumLength = min;
        }

        public override bool IsValidate(object dataValue)
        {
            return MinimumLength<=dataValue.ToString().Length&& dataValue.ToString().Length <= MaximumLength;
        }
    }
}
