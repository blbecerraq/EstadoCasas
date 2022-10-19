using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CeldasCore.Models
{
    public class Request
    {
        [Required]
        public List<int> Houses { get; set; }
        public int Days { get; set; }
    }
}
