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
    
    public partial class UserSetting
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> Knitting { get; set; }
        public Nullable<bool> Crochet { get; set; }
        public Nullable<bool> UsePassword { get; set; }
        public Nullable<bool> Metric { get; set; }
        public Nullable<bool> US { get; set; }
        public Nullable<bool> MetricUS { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
        public Nullable<System.DateTime> dateSettingsUpdated { get; set; }
        public Nullable<System.DateTime> dateLastLogin { get; set; }
        public Nullable<System.DateTime> dateInventoryUpdated { get; set; }
    }
}