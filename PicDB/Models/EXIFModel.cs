using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicDB.Models
{
    public class EXIFModel
    {
        public String ExifCameraModel { get; set; }
        public double FNumber { get; set; }
        public int ExposureTime { get; set; }
        public DateTime DateTime { get; set; }
    }
}
