﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace PrismTestV2.ViewModels.Customers
{
    public class CustomerListViewModel : ViewModel
    {

        #region Commands
        public DelegateCommand AddCustomerCommand { get; set; }
        #endregion

        #region Properties
        public ObservableCollection<CustomerItemViewModel> Customers { get; set; }
        #endregion
        public CustomerListViewModel(IUnityContainer _container)
        {
            AddCustomerCommand = new DelegateCommand(AddCustomerExecute, CanExecute);
            Customers = new ObservableCollection<CustomerItemViewModel>();
            Customers.Add(new CustomerItemViewModel("Indira", "Djeldum"));
            Customers.Add(new CustomerItemViewModel("Edin", "Music"));
            Customers.Add(new CustomerItemViewModel("Faruk", "Redzic"));
        }

        private bool CanExecute()
        {
            return true;
        }

        private void AddCustomerExecute()
        {
            Customers.Add(new CustomerItemViewModel("newCustomerName", "newCustomerSurname"));
        }

        private string _myProperty;
        [RestorableState] // When application suspends this will restore property value
        public string MyProperty
        {
            get { return _myProperty; }
            set { SetProperty(ref _myProperty, MyProperty); }
        }


        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }

        public override void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatedFrom(viewModelState, suspending);
        }
    }
}
