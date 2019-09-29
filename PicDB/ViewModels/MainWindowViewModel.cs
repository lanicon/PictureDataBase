using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PicDB.DALs;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PicDB.ViewModels
{

    internal class MainWindowViewModel : ViewModel
    {
        public PictureViewModel CurrentPicture { get; set; }
        public PictureListViewModel PictureVMList { get; set; }
        public List<PictureViewModel> pictures { get; }
        public PhotographerListViewModel PhotographerListViewModel { get; }
        public ObservableCollection<PhotographerViewModel> photographerViewModels { get; private set; }
        public PhotographerViewModel AddPhotographer { get; set; }

        private ICommand saveNewCommand;


        public MainWindowViewModel()
        {
            CurrentPicture = new PictureViewModel(1);
            PictureVMList = new PictureListViewModel();
            AddPhotographer = new PhotographerViewModel();

            pictures = PictureVMList.PictureVMlist;

            PhotographerListViewModel = new PhotographerListViewModel();

            photographerViewModels = PhotographerListViewModel.PhotographerList;

            MsSQLDAL ms = new MsSQLDAL();
            ms.getPhotographer(1);
            //ms.makePictureReport(4);

            //ms.makeTagReport();
        }

        public ICommand SaveNewCommand
        {
            get
            {
                return saveNewCommand ?? (saveNewCommand = new RelayCommand(() => {
                    AddPhotographer.SaveNewPhotographer();
                    photographerViewModels = PhotographerListViewModel.PhotographerList;

                    OnPropertyChanged("photographerViewModels");

                }));
            }
        }
    }
}
