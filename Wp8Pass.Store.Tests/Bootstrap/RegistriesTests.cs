using System;
using System.Reflection;
using Caliburn.Micro;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Wp8Pass.Store.Bootstrap;
using Wp8Pass.Store.Services;
using Wp8Pass.Store.ViewModels;

namespace Wp8Pass.Store.Tests.Bootstrap
{
    [TestClass]
    public class RegistriesTests
    {
        private WinRTContainer _container;

        [TestInitialize]
        public void Initialize()
        {
            AssemblySource.Instance.Clear();
            AssemblySource.Instance.Add(typeof(Registries)
                .GetTypeInfo().Assembly);

            _container = new WinRTContainer();
            _container.RegisterWinRTServices();
            _container.RegisterAppServices();
        }

        [TestMethod]
        public void Should_Detect_Single_Interface()
        {
            Assert.AreEqual(typeof(IDisposable),
                typeof(SingleInteface)
                    .GetTypeInfo()
                    .GetSingleInterface());

            Assert.IsNull(typeof(DoubleInterface)
                .GetTypeInfo()
                .GetSingleInterface());

            Assert.IsNull(typeof(RegistriesTests)
                .GetTypeInfo()
                .GetSingleInterface());
        }

        [TestMethod]
        public void Should_Register_Singletons()
        {
            Assert.AreSame(
                _container.GetInstance<IDatabaseManager>(),
                _container.GetInstance<IDatabaseManager>());
        }

        [TestMethod]
        public void Should_Resolve_Services()
        {
            Assert.IsNotNull(_container
                .GetInstance<IDatabaseManager>());
        }

        [TestMethod]
        public void Should_Resolve_View_Models()
        {
            Assert.IsNotNull(_container
                .GetInstance<DbSelectViewModel>());
        }

        public class DoubleInterface : IDisposable, IFormattable
        {
            public void Dispose() {}

            public string ToString(string format, IFormatProvider formatProvider)
            {
                return null;
            }
        }

        public class SingleInteface : IDisposable
        {
            public void Dispose() {}
        }
    }
}