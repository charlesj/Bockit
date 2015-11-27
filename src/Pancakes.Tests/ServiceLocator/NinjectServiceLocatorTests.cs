using System;
using Ninject.Modules;
using Xunit;
using Pancakes.ServiceLocator;

namespace Pancakes.Tests.ServiceLocator
{
	public class ServiceLocatorTests
	{
		[Fact]
		public void LoadsModules()
		{
			var configuration = new BootConfiguration();
			configuration.AddNinjectModule(new TestNinjectModule());
			var locator = new NinjectServiceLocator(configuration);
			var test = locator.Get<ITest>();
			Assert.NotNull(test);
		}
		
		public interface ITest
		{
			string Name();
		}

        public class Test : ITest
        {
            public string Name()
            {
                return "Hello";
            }
        }

        public class TestNinjectModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<ITest>().To<Test>();
            }
        }
    }
}