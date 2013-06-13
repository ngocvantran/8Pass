using System;
using Caliburn.Micro;
using Wp8Pass.Store.Bootstrap;

namespace Wp8Pass.Store.ViewModels
{
    public class StartupViewModel : ConductorViewModelBase<Screen>
    {
        public StartupViewModel(Screen[] items,
            INavigationService navigation)
            : base(navigation)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            Items.AddRange(items);
        }
    }
}