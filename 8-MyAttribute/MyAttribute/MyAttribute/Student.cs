using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{

   [Serializable]
   //[Table]
   [Table("NewTable")]
    public class Student
    {
        [Key]//说明这个属性是主键
        public  int Id { get; set; }

        [StringLength(50,6)]//字符串长度
        public string Name { get; set; }

        [EmailAddress]//识别邮箱格式
        public string Email { get; set; }

        [Required]//属性不能为空
        public int Age { get; set; }

        [Display("电话号码")]//显示字段的别名
        public string PhoneNumber { get; set; }
    }

  
}
