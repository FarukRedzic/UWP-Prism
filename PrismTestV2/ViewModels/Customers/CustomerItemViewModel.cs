using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PrismTestV2.ViewModels.Customers
{
    public class CustomerItemViewModel : ViewModel
    {
        private static int Id = 1;
        #region Commands
        public DelegateCommand IntroduceCommand { get; set; }
        #endregion

        public delegate void SetFocus(int id);
        SetFocus _focusDel;
        #region Properties

        public int CustomerId { get; set; }

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

        private bool _isFocused;
        public bool IsFocused
        {
            get { return _isFocused; }
            set { SetProperty(ref _isFocused, value); }
        }
        #endregion

        public CustomerItemViewModel(string name, string surname, SetFocus focusDel)
        {
            CustomerId = Id++;
            Name = name;
            Surname = surname;
            _focusDel = focusDel;
            IntroduceCommand = new DelegateCommand(IntroduceMe, CanExecute);
        }

        private bool CanExecute()
        {
            return true;
        }

        private async void IntroduceMe()
        {
            _focusDel(CustomerId);
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
    }
}
