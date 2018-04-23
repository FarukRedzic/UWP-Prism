using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Events;
using PrismTestV2.Models;
using PrismTestV2.Util;
using PrismTestV2.ViewModels.Customers;
using PrismTestV2.ViewModels.Main;
using PrismTestV2.ViewModels.Subscriber;
using PrismTestV2.Views.Customers;
using PrismTestV2.Views.Main;
using PrismTestV2.Views.Subscriber;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace PrismTestV2
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : MvvmAppBase
    {
        #region Fields
        IUnityContainer _container = new UnityContainer();
        ViewViewModelTypeResolver _viewViewModelTypeResolver; 
        #endregion

        public App()
        {
            InitializeComponent();
            _viewViewModelTypeResolver = new ViewViewModelTypeResolver(typeof(MainPage));
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("MainPage", null);
            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            RegisterServices();
            RegisterViewModels();
            return Task.FromResult<object>(null);
        }

        protected override Type GetPageType(string pageToken)
        {
            return _viewViewModelTypeResolver.GetViewType(pageToken);
        }

        private void RegisterServices()
        {
            _container.RegisterInstance<INavigationService>(NavigationService);
            _container.RegisterInstance<ISessionStateService>(SessionStateService);
            _container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Registering complex data types for storing in application session
        /// </summary>
        protected override void OnRegisterKnownTypesForSerialization()
        {
            base.OnRegisterKnownTypesForSerialization();
            SessionStateService.RegisterKnownType(typeof(User));
        }

        /// <summary>
        /// Method for binding ViewModels and Views for whole application.
        /// </summary>
        private void RegisterViewModels()
        {
            BindViewModelToView<MainViewModel, MainPage>();
            BindViewModelToView<SubscriberViewModel, SubscriberPage>();
            BindViewModelToView<CustomerListViewModel, CustomerListPage>();
        }

        public void BindViewModelToView<TViewModel, TView>()
        {
            ViewModelLocationProvider.Register(typeof(TView).ToString(), () => _container.Resolve<TViewModel>());
        }
    }
}
