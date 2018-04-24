using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Prism.Events;
using PrismTestV2.Events;
using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;

namespace PrismTestV2.ViewModels.Main
{
    public class MainViewModel : ViewModel
    {

        #region Fields
        IEventAggregator _eventAggregator;
        INavigationService _navigationService;
        private string _test;
        #endregion

        #region Commands
        public DelegateCommand TestCommand { get; set; }
        public DelegateCommand GoToCustomersCommand { get; set; }
        #endregion

        #region Properties
        [RestorableState]
        public string Test
        {
            get { return _test; }
            set { SetProperty(ref _test, value); }
        }
        #endregion

        #region ctor
        public MainViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            Test = "Main page view";
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            //_eventAggregator.GetEvent<EventNameTest>().Publish("Event args!!!");
            TestCommand = new DelegateCommand(TestExecute, CanExecute);
            GoToCustomersCommand = new DelegateCommand(GoToCustomersExecute, CanExecute);
        }


        #endregion


        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            _eventAggregator.GetEvent<EventNameTest>().Subscribe(EventHandlerMethod, ThreadOption.UIThread); //ThreadOption.PublisherThread, ThreadOption.UIThread
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }

        public override void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatedFrom(viewModelState, suspending);
            //_eventAggregator.GetEvent<EventNameTest>().Unsubscribe(EventHandlerMethod); always unsubscribe from event on deactivating view!!!
        }

        private bool CanExecute()
        {
            return true;
        }

        private void TestExecute()
        {
            _navigationService.Navigate("SubscriberPage", null);
        }

        private void GoToCustomersExecute()
        {
            _navigationService.Navigate("CustomerListPage", "customers...");
        }

        private void EventHandlerMethod(string eventArg)
        {
            Test = eventArg;
        }
    }
}
