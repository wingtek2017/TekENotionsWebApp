//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TekENotionsWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pattern
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<bool> free { get; set; }
        public Nullable<int> first_photo_id { get; set; }
        public Nullable<int> pattern_author_id { get; set; }
        public Nullable<int> designer_id { get; set; }
        public string permalink { get; set; }
    }
}
