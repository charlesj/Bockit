using System;
using Pancakes.ErrorCodes;
using Pancakes.Exceptions;
using Xunit;

namespace Pancakes.Tests
{
	public class KernelTests
	{
		[Fact]
		public void CallingBoot_SetsBootConfiguration()
		{
			var kernel = new Kernel();
			var configuration = new BootConfiguration();
			kernel.Boot(configuration);
			Assert.Equal(configuration, kernel.BootConfiguration);
		}
		
		[Fact]
		public void AccessingServiceLocator_PreBoot_ThrowsException()
		{
			var kernel = new Kernel();
			try
			{
				kernel.ServiceLocator.Get(typeof(object));
				throw new Exception("This should not happen");
			}
			catch(PancakesInvalidOperationException exception)
			{
				Assert.Equal(PancakesErrorCodes.AccessServiceLocatorPreBoot, exception.ErrorCode);
			}
		}
		
		[Fact]
		public void AccessServiceLocator_PostBoot_ReturnsLocator()
		{
			var kernel = new Kernel();
			kernel.Boot(BootConfiguration.DefaultConfiguration);
			var locator = kernel.ServiceLocator;
			Assert.NotNull(locator);			
		}
	}
}