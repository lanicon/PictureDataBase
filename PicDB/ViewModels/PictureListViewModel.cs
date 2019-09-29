using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicDB.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class PictureListViewModel : ViewModel
    {
        BusinessLayer bl = new BusinessLayer();
        List<PictureModel> pictureList;

        public PictureListViewModel()
        {
            pictureList = bl.getPictureList();
        }

        public List<PictureViewModel> PictureVMlist {
            get
            {
                List<PictureViewModel> pvmList = new List<PictureViewModel>();

                foreach(PictureModel pm in pictureList)
                {
                    PictureViewModel temp = new PictureViewModel(pm.ID);
                    pvmList.Add(temp);
                }

                return pvmList;
            }
        }
    }
}
