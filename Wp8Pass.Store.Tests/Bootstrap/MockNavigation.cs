using System;
using Caliburn.Micro;
using Windows.UI.Xaml.Navigation;

namespace Wp8Pass.Store.Tests.Bootstrap
{
    public class MockNavigation : INavigationService
    {
        public event NavigatedEventHandler Navigated;
        public event NavigatingCancelEventHandler Navigating;
        public event NavigationFailedEventHandler NavigationFailed;
        public event NavigationStoppedEventHandler NavigationStopped;
        public bool CanGoBack { get; private set; }
        public bool CanGoForward { get; private set; }
        public Type CurrentSourcePageType { get; private set; }
        public Type SourcePageType { get; set; }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void GoForward()
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Type sourcePageType)
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Type sourcePageType, object parameter)
        {
            throw new NotImplementedException();
        }
    }
}