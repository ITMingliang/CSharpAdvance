using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    abstract class CommonValidateAttribute:Attribute
    {
        public abstract bool IsValidate(object dataValue);
    }
}
