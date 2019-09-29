namespace PicDB
{
    using PicDB.ViewModels;
    using System.Windows;
    using System;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.675);
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.DataContext = new MainWindowViewModel();
        }
    }
}
