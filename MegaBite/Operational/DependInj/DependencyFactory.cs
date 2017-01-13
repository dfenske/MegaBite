using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BulletTime.Operational.Dependency
{
    public class DependencyFactory
    {
        #region Fields

        private static Lazy<DependencyFactory> instance = new Lazy<DependencyFactory>(() =>
        {
            return new DependencyFactory();
        }, LazyThreadSafetyMode.ExecutionAndPublication);


        private IUnityContainer unityContainer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public IUnityContainer Container
        {
            get
            {
                return this.unityContainer;
            }
            protected set
            {
                this.unityContainer = value;
            }
        }

        #endregion

        #region Constructors

        public DependencyFactory()
        {
            this.unityContainer = new UnityContainer();
            DependencyFactory.RegisterTypes(this.unityContainer);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the container that will be used to resolve the application's dependencies.
        /// </summary>
        /// <returns></returns>
        public static DependencyFactory GetContainer()
        {
            return instance.Value;
        }

        /// <summary>
        /// Resolves the specified dependency name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dependencyName">Name of the dependency.</param>
        /// <returns></returns>
        public T Resolve<T>(string dependencyName)
        {
            return Container.Resolve<T>(dependencyName);
        }

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        private static void RegisterTypes(IUnityContainer container)
        {
            // Load from web.config 
            container.LoadConfiguration();
        }
        #endregion
    }
}
