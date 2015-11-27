using Ninject.Modules;
using Pancakes.ErrorCodes;
using Pancakes.Exceptions;
using Xunit;

namespace Pancakes.Tests
{
    public class BootConfigurationTests
	{
		[Fact]
		public void AddNinjectModule_IsAdded()
		{
			var config = new BootConfiguration();
			var module = new TestNinjectModule();
			config.AddNinjectModule(module);
			Assert.Contains(module, config.ModulesToLoad);
		}
		
		[Fact]
		public void SetsVerbosity()
		{
			var config = new BootConfiguration();
			Assert.False(config.BeVerbose);
			config.Verbose();
			Assert.True(config.BeVerbose);
		}
		
		[Fact]
		public void CannotConfigureAfterMarkingAsBooted()
		{
			var config = new BootConfiguration();
			config.Boot();
			try
			{
				config.Verbose();
			} 
			catch(PancakesInvalidOperationException exception)
			{
				Assert.Equal(PancakesErrorCodes.CannotConfigurePostBoot, exception.ErrorCode);
			}
		}

        public class TestNinjectModule : NinjectModule
        {
            public override void Load()
            {
				// no op
            }
        }
    }
}