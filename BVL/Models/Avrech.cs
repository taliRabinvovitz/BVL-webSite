//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BVL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Avrech
    {
        public Avrech()
        {
            this.EnglishDetails = new HashSet<EnglishDetails>();
            this.HebroDetails = new HashSet<HebroDetails>();
        }
    
        public int Id { get; set; }
        public System.DateTime date { get; set; }
        public int children { get; set; }
        public string image { get; set; }
    
        public virtual ICollection<EnglishDetails> EnglishDetails { get; set; }
        public virtual ICollection<HebroDetails> HebroDetails { get; set; }
    }
}