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
    
    public partial class Audio
    {
        public int Id { get; set; }
        public string audio1 { get; set; }
        public string subject { get; set; }
        public Nullable<int> kategory { get; set; }
    
        public virtual Subjects Subjects { get; set; }
    }
}