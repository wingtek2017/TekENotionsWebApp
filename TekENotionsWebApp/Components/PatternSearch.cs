using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TekENotionsWebApp.Components
{
    public class PatternSearch
    {
        public string PatternName { get; set; }
        public int NeedleSizeId { get; set; }

        public static implicit operator DbSet<object>(PatternSearch v)
        {
            throw new NotImplementedException();
        }
    }
}