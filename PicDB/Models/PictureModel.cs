using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicDB.Models
{
    public class PictureModel
    {
        public PictureModel(int ID, string fileName)
        {
            this.ID = ID;
            this.FileName = fileName;
        }

        public string FileName { get; private set; }
        public int ID { get; private set; }
        public EXIFModel exifModel { get; set; }
        public IPTCModel iptcModel { get; set; }
        public PhotographerModel photographer { get; set; }
    }
}
