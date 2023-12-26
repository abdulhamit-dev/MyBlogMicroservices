using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace TextSearchAPI.Models
{
    public class Content
    {
        // [PropertyName("_id")]
        // public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}