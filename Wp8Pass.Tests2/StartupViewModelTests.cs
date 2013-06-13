using System;
using Caliburn.Micro;
using Moq;
using Wp8Pass.Store.ViewModels;
using Xunit;

namespace Wp8Pass.Tests2
{
    public class StartupViewModelTests
    {
        private readonly Mock<INavigationService> _navigation;
        private readonly Screen _screen;
        private readonly StartupViewModel _viewModel;

        public StartupViewModelTests()
        {
            _screen = new Screen();
            _navigation = new Mock<INavigationService>();

            _viewModel = new StartupViewModel(
                new[] {_screen}, _navigation.Object);
        }

        [Fact]
        public void Should_Activate_Views_On_Activation()
        {
            ScreenExtensions.TryActivate(_viewModel);
            Assert.True(_screen.IsActive);
        }
    }
}