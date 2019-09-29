using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.ViewModels
{
    public class PhotographerViewModel : ViewModel
    {
        private BusinessLayer bl = new BusinessLayer();
        private PhotographerModel phm;
        private ICommand saveCommand;
        private ICommand saveNewCommand;


        private bool firstNameValid = true;
        private bool lastNameValid = true;
        private bool birthdayValid = true;

        public SolidColorBrush firstNameColor { get; private set; }
        public SolidColorBrush lastNameColor { get; private set; }
        public SolidColorBrush birthdayColor { get; private set; }

        public PhotographerViewModel()
        {
            phm = new PhotographerModel();
            phm.Birthday = new DateTime(1970, 1, 1);

            firstNameColor = new SolidColorBrush(Colors.LightGray);
            lastNameColor = new SolidColorBrush(Colors.LightGray);
            birthdayColor = new SolidColorBrush(Colors.LightGray);
        }


        public void isVMofPhotographerOfPicture(int pictureId)
        {
            phm = bl.getPhotographerOfPicture(pictureId);
        }

        public void isVMofPhotographerWithId(int Id)
        {
            phm = bl.getPhotographer(Id);
        }


        public int ID
        {
            get
            {
                return phm.ID;
            }
        }


        public string FirstName
        {
            get
            {
                return phm.FirstName;
            }
            set
            {
                phm.FirstName = value;

                if (value.Length <= 100 && !String.IsNullOrWhiteSpace(value))
                {
                    firstNameValid = true;
                    firstNameColor.Color = Colors.Green;
                }
                else
                {
                    firstNameValid = false;
                    firstNameColor.Color = Colors.Red;
                }
            }
        }


        public string LastName
        {
            get
            {
                return phm.LastName;
            }
            set
            {
                phm.LastName = value;

                if (value.Length <= 50 && !String.IsNullOrWhiteSpace(value))
                {
                    lastNameValid = true;
                    lastNameColor.Color = Colors.Green;
                }
                else
                {
                    lastNameValid = false;
                    lastNameColor.Color = Colors.Red;
                }
            }
        }


        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int BirthdayDay
        {
            get
            {
                return phm.Birthday.Value.Date.Day;
            }
            set
            {
                phm.Birthday = new DateTime(phm.Birthday.Value.Date.Year, phm.Birthday.Value.Date.Month, value);

                if (phm.Birthday < DateTime.Today)
                {
                    birthdayValid = true;
                    birthdayColor.Color = Colors.Green;
                }
                else
                {
                    birthdayValid = false;
                    birthdayColor.Color = Colors.Red;
                }
            }
        }

        public int BirthdayMonth
        {
            get
            {
                return phm.Birthday.Value.Date.Month;
            }
            set
            {
                phm.Birthday = new DateTime(phm.Birthday.Value.Date.Year, value, phm.Birthday.Value.Date.Day);

                if (phm.Birthday < DateTime.Today)
                {
                    birthdayValid = true;
                    birthdayColor.Color = Colors.Green;
                }
                else
                {
                    birthdayValid = false;
                    birthdayColor.Color = Colors.Red;
                }
            }
        }

        public int BirthdayYear
        {
            get
            {
                return phm.Birthday.Value.Date.Year;
            }
            set
            {
                phm.Birthday = new DateTime(value, phm.Birthday.Value.Date.Month, phm.Birthday.Value.Date.Day);

                if (phm.Birthday < DateTime.Today)
                {
                    birthdayValid = true;
                    birthdayColor.Color = Colors.Green;
                }
                else
                {
                    birthdayValid = false;
                    birthdayColor.Color = Colors.Red;
                }
            }
        }


        public DateTime? Birthday
        {
            get
            {
                return phm.Birthday.Value.Date;
            }
            set
            {
                phm.Birthday = value;
            }
        }


        public String Notes
        {
            get
            {
                return phm.Notes;
            }
            set
            {
                phm.Notes = value;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(() => Save()));
            }
        }

        private void Save()
        {
            bl.SavePhotographer(phm.ID, phm);
        }

        public ICommand SaveNewCommand
        {
            get
            {
                return saveNewCommand ?? (saveNewCommand = new RelayCommand(() => SaveNewPhotographer()));
            }
        }

        public void SaveNewPhotographer()
        {
            bl.SaveNewPhotographer(phm);
        }
    }
}
