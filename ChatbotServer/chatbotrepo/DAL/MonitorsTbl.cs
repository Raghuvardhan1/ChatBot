//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace chatbotrepo.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonitorsTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonitorsTbl()
        {
            this.InterestsTbls = new HashSet<InterestsTbl>();
            this.OptionsTbls = new HashSet<OptionsTbl>();
            this.OrdersTbls = new HashSet<OrdersTbl>();
        }
    
        public int monitor_id { get; set; }
        public string monitor_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterestsTbl> InterestsTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OptionsTbl> OptionsTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersTbl> OrdersTbls { get; set; }
    }
}
