using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Moq;
using Ploeh.AutoFixture.Xunit;
using Wp8Pass.Store.Services;
using Wp8Pass.Store.ViewModels;
using Xunit;
using Xunit.Extensions;

namespace Wp8Pass.Tests2
{
    public class DbSelectViewModelTests
    {
        private readonly Mock<IDatabaseManager> _manager;
        private readonly DbSelectViewModel _viewModel;

        public DbSelectViewModelTests()
        {
            _manager = new Mock<IDatabaseManager>();
            _viewModel = new DbSelectViewModel(_manager.Object);
        }

        [Theory, AutoData]
        public void Should_Display_Databases_When_Activated(
            DatabaseRegistration[] databases)
        {
            _manager
                .Setup(x => x.GetDatabases())
                .Returns(Task.FromResult(databases));

            ScreenExtensions.TryActivate(_viewModel);

            Assert.Equal(
                databases.Select(x => x.Name),
                _viewModel.Databases.Select(x => x.Name));
        }
    }
}