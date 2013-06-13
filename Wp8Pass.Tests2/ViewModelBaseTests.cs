using System;
using Caliburn.Micro;
using Moq;
using Ploeh.AutoFixture.Xunit;
using Wp8Pass.Store.Bootstrap;
using Xunit;
using Xunit.Extensions;

namespace Wp8Pass.Tests2
{
    public class ViewModelBaseTests
    {
        private readonly Mock<INavigationService> _navigation;
        private readonly ViewModelBase _view;

        public ViewModelBaseTests()
        {
            _navigation = new Mock<INavigationService>();
            _view = new ViewModelBase(_navigation.Object);
        }

        [Fact]
        public void Should_GoBack()
        {
            _view.GoBack();
            _navigation.Verify(x => x.GoBack());
        }

        [Theory, AutoData]
        public void Should_Return_GoBack(bool canGoBack)
        {
            _navigation
                .Setup(x => x.CanGoBack)
                .Returns(canGoBack)
                .Verifiable();

            Assert.Equal(canGoBack, _view.CanGoBack);
            _navigation.Verify();
        }
    }
}