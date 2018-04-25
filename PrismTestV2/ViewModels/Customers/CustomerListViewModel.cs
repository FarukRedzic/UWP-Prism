using Microsoft.Practices.Prism.Commands;
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
        IUnityContainer _container;
        #endregion

        #region Properties
        public ObservableCollection<CustomerItemViewModel> Customers { get; set; }
        #endregion
        public CustomerListViewModel(IUnityContainer container)
        {
            _container = container; // container injection in case for manual resolving registered implementations (best practice is to avoid manual resolving)
            AddCustomerCommand = new DelegateCommand(AddCustomerExecute, CanExecute);
            Customers = new ObservableCollection<CustomerItemViewModel>();
            Customers.Add(new CustomerItemViewModel("Indira", "Djeldum", SetFocus));
            Customers.Add(new CustomerItemViewModel("Edin", "Music", SetFocus));
            Customers.Add(new CustomerItemViewModel("Faruk", "Redzic", SetFocus));
        }

        public void SetFocus(int customerId)
        {
            foreach (CustomerItemViewModel customer in Customers)
            {
                if (customer.CustomerId == customerId)
                    customer.IsFocused = true;
                else if(customer.IsFocused)
                    customer.IsFocused = false;
            }
        }

        private bool CanExecute()
        {
            return true;
        }

        private void AddCustomerExecute()
        {
            Customers.Add(new CustomerItemViewModel("newCustomerName", "newCustomerSurname", SetFocus));
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
