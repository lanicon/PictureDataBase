using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicDB.Models
{
    public class IPTCModel
    {
        public String City { get; set; }
        public String Caption { get; set; }
        public String Headline { get; set; }
        public List<String> Tags { get; set; }
    }
}
