//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZZCompanyNameZZ.ZZProjectNameZZ.Model
{
    using System;
    using BIA.Net.Model;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    #pragma warning disable CS1591 // Missing XML Comment
    public partial class SiteView : ObjectRemap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SiteView()
        {
            this.IsDefault = false;
        }
    
        
        [Required]
        public int ViewId { get; set; }
        
        [Required]
        public int SiteId { get; set; }
        
        [Required]
        public bool IsDefault { get; set; }
    
        
        /// <summary>
        ///  - NotRequired for update use SiteId
        /// </summary>
        public virtual Site Site { get; set; }
        
        /// <summary>
        ///  - NotRequired for update use ViewId
        /// </summary>
        public virtual View View { get; set; }
    }
    #pragma warning restore CS1591 // Missing XML Comment
}
