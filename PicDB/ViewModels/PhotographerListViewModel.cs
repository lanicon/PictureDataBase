using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.ViewModels
{
    public class PhotographerListViewModel : ViewModel
    {
        private BusinessLayer bl = new BusinessLayer();
        private ObservableCollection<PhotographerViewModel> list;

        public ObservableCollection<PhotographerViewModel> PhotographerList
        {
            get
            {
                List<PhotographerModel> phmList = bl.getPhotographerList();

                list = new ObservableCollection<PhotographerViewModel>();

                foreach (PhotographerModel phm in phmList)
                {
                    PhotographerViewModel phvm = new PhotographerViewModel();
                    phvm.isVMofPhotographerWithId(phm.ID);

                    list.Add(phvm);
                }

                return list;
            }
        }
    }
}
