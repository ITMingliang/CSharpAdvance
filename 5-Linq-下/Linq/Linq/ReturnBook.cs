//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Linq
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReturnBook
    {
        public int ReturnId { get; set; }
        public Nullable<int> BorrowDetailId { get; set; }
        public int ReturnCount { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public string AdminName_R { get; set; }
    
        public virtual BorrowDetail BorrowDetail { get; set; }
    }
}
