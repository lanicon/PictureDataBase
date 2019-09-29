using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.ViewModels
{
    public class EXIFViewModel : ViewModel
    {
        private BusinessLayer bl = new BusinessLayer();
        private EXIFModel exif;

        public EXIFViewModel(int ID)
        {
            exif = bl.getExif(ID);
        }

        public String ExifCameraModel { get { return exif.ExifCameraModel; } }
        public Double FNumber { get { return exif.FNumber; } }
        public int ExposureTime { get { return exif.ExposureTime; } }
        public DateTime DateTime { get { return exif.DateTime; } }
    }
}
