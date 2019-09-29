using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.ViewModels
{
    public class IPTCViewModel : ViewModel
    {
        private BusinessLayer bl = new BusinessLayer();
        private IPTCModel iptc;
        private ICommand saveCommand;
        private int id;

        public IPTCViewModel(int ID)
        {
            iptc = bl.getIptc(ID);

            this.id = ID;
        }

        public String City {
            get
            {
                return iptc.City;
            }
            set
            {
                iptc.City = value;
            }
        }


        public String Caption { get { return iptc.Caption; } set { iptc.Caption = value; } }
        public String Headline { get { return iptc.Headline; } set { iptc.Headline = value; } }
        public List<String> Tags { get { return iptc.Tags; } }


        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(() => Save()));
            }
        }

        private void Save()
        {
            bl.SaveIptc(id, iptc);
        }

    }
}
