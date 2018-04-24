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
        #region Properties
        public ObservableCollection<CustomerItemViewModel> Customers { get; set; }
        #endregion
        public CustomerListViewModel(IUnityContainer _container)
        {
            Customers = new ObservableCollection<CustomerItemViewModel>();
            Customers.Add(new CustomerItemViewModel("Indira", "Djeldum"));
            Customers.Add(new CustomerItemViewModel("Edin", "Music"));
            Customers.Add(new CustomerItemViewModel("Faruk", "Redzic"));
        }

        private string myVar;
        [RestorableState]
        public string MyProperty
        {
            get { return "radi"; }
            set { myVar = value; }
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
