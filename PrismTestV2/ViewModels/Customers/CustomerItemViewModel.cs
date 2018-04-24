using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PrismTestV2.ViewModels.Customers
{
    public class CustomerItemViewModel : ViewModel
    {

        #region Commands
        public DelegateCommand IntroduceCommand { get; set; }
        #endregion

        public CustomerItemViewModel(string name, string surname)
        {
            Name = name;
            Surname = surname;
            IntroduceCommand = new DelegateCommand(IntroduceMe, CanExecute);
        }

        private bool CanExecute()
        {
            return true;
        }

        private async void IntroduceMe()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "User",
                Content = string.Format("I'm {0} {1}", Name, Surname),
                CloseButtonText = "Close"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }

        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }
}
