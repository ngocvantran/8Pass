using System;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using Wp8Pass.Store.ViewModels;

namespace Wp8Pass.Store.Bootstrap
{
    public static class Registries
    {
        public static T GetInstance<T>(this SimpleContainer container)
        {
            return (T)container.GetInstance(typeof(T), null);
        }

        public static Type GetSingleInterface(this TypeInfo type)
        {
            var interfaces = type.ImplementedInterfaces
                .GetEnumerator();

            if (!interfaces.MoveNext())
                return null;

            var result = interfaces.Current;
            return !interfaces.MoveNext()
                ? result : null;
        }

        public static void RegisterAppServices(this SimpleContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            SpecialCases(container);
            ApplyConventions(container);
        }

        private static void ApplyConventions(this SimpleContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            // All concrete types
            var types = AssemblySource.Instance
                .SelectMany(x => x.GetExportedTypes())
                .Select(x => x.GetTypeInfo())
                .Where(x => x.IsClass && !x.IsAbstract)
                .ToList();

            // View Models
            types
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Select(x => x.AsType())
                .Where(x => !container.HasHandler(x, null))
                .Apply(x => container.RegisterPerRequest(x, null, x));

            // Services
            types
                .Where(x => !x.Name.EndsWith("ViewModel"))
                .Select(x => new
                {
                    Type = x.AsType(),
                    Interface = x.GetSingleInterface(),
                })
                .Where(x => x.Interface != null)
                .Apply(x =>
                {
                    var isSingleton = x.Interface
                        .GetTypeInfo()
                        .IsDefined(typeof(SingletonAttribute));

                    if (isSingleton)
                    {
                        container.RegisterSingleton(
                            x.Interface, null, x.Type);
                    }
                    else
                    {
                        container.RegisterPerRequest(
                            x.Interface, null, x.Type);
                    }
                });
        }

        private static void SpecialCases(SimpleContainer container)
        {
            container.Handler<StartupViewModel>(x =>
            {
                var items = new Screen[]
                {
                    x.GetInstance<DbSelectViewModel>(),
                };

                return new StartupViewModel(items,
                    x.GetInstance<INavigationService>());
            });
        }
    }
}