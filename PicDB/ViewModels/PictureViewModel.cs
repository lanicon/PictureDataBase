using System;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class PictureViewModel : ViewModel
    {
        private BusinessLayer bl = new BusinessLayer();
        private PictureModel pm;
        private EXIFViewModel evm;
        private IPTCViewModel ivm;
        private PhotographerViewModel phvm;

        public PictureViewModel(int ID)
        {
            pm = bl.getPicture(ID);

            this.ID = pm.ID;
        }

        public string FileName { get { return pm.FileName; } }
        public int ID { get; private set; }

        public PhotographerViewModel PhotographerViewModel
        {
            get
            {
                if (phvm == null)
                {
                    phvm = new PhotographerViewModel();
                    phvm.isVMofPhotographerOfPicture(pm.ID);
                }
                return phvm;
            }
        }

        public EXIFViewModel ExifViewModel {
            get
            {
                if (evm == null)
                {
                    evm = new EXIFViewModel(pm.ID);
                }
                return evm;
            }
        }

        public IPTCViewModel IptcViewModel {
            get
            {
                if (ivm == null)
                {
                    ivm = new IPTCViewModel(pm.ID);
                }
                return ivm;
            }
        }
    }
}
