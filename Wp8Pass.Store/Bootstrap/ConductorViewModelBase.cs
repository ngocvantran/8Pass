using System;
using Caliburn.Micro;

namespace Wp8Pass.Store.Bootstrap
{
    public class ConductorViewModelBase<T>
        : Conductor<T>.Collection.AllActive
        where T : class
    {
        private readonly INavigationService _navigation;

        /// <summary>
        /// Indicates whether the navigator can navigate back.
        /// </summary>
        public bool CanGoBack
        {
            get { return _navigation.CanGoBack; }
        }

        public ConductorViewModelBase(INavigationService navigation)
        {
            if (navigation == null)
                throw new ArgumentNullException("navigation");

            _navigation = navigation;
        }

        /// <summary>
        /// Navigates back.
        /// </summary>
        public void GoBack()
        {
            _navigation.GoBack();
        }
    }
}