//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace $safeprojectname$
{
    using System;
    using BIA.Net.Model;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    #pragma warning disable CS1591 // Missing XML Comment
    public partial class MemberRole : ObjectRemap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberRole()
        {
            this.Members = new HashSet<Member>();
        }
    
        
        [Required]
        public int Id { get; set; }
        
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        
        public virtual ICollection<Member> Members { get; set; }
    }
    #pragma warning restore CS1591 // Missing XML Comment
}
