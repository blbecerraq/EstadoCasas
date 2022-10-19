using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeldasCore.Models
{
    public class Response
    {
        public int Days { get; set; }
        public List<int> Input { get; set; }
        public List<int> Output { get; set; }
    }
}
