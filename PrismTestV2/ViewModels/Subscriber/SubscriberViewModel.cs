using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Prism.Events;
using PrismTestV2.Events;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;

namespace PrismTestV2.ViewModels.Subscriber
{
    public class SubscriberViewModel : ViewModel
    {
        #region Fields
        IEventAggregator _eventAggregator;
        INavigationService _navigationService;
        private string _test;
        #endregion

        #region Properties
        [RestorableState]
        public string Test
        {
            get { return _test; }
            set { SetProperty(ref _test, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand TestCommand { get; set; }
        public DelegateCommand GoToMainWindowCommand { get; set; }
        #endregion

        public SubscriberViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            Test = "Subscriber view";
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            TestCommand = new DelegateCommand(ExecuteCommand, CanExecute);
            GoToMainWindowCommand = new DelegateCommand(GoToMainWindowExecute, CanExecute);
        }

        private void EventHandlerMethod(string eventArg)
        {
            string test = eventArg;
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }

        public override void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatedFrom(viewModelState, suspending);
        }

        private bool CanExecute()
        {
            return true;
        }

        private void ExecuteCommand()
        {
            _eventAggregator.GetEvent<EventNameTest>().Publish("Event args!!! from subscriber view");
        }

        private void GoToMainWindowExecute()
        {
            _navigationService.Navigate("MainPage", null);
        }
    }
}
