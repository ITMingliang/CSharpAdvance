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
    
    public partial class BorrowInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BorrowInfo()
        {
            this.BorrowDetail = new HashSet<BorrowDetail>();
        }
    
        public string BorrowId { get; set; }
        public Nullable<int> ReaderId { get; set; }
        public Nullable<System.DateTime> BorrowDate { get; set; }
        public string AdminName_B { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BorrowDetail> BorrowDetail { get; set; }
        public virtual Readers Readers { get; set; }
    }
}
