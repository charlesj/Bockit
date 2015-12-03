using System;
using Xunit;

namespace Pancakes.TestUtilities
{
	public class NSubstituteMockRegistryTests
	{
        private readonly NSubstituteMockRegistry SystemUnderTest;

        public NSubstituteMockRegistryTests()
		{
			this.SystemUnderTest = new NSubstituteMockRegistry();	
		}
		
		[Fact]
		public void CanGetAType()
		{
			this.SystemUnderTest.Get(typeof(ITestInterface));
		}
		
		[Fact]
		public void AttemptingToGetUnregisteredType_ReturnsMock()
		{
			
		}
		
		public interface ITestInterface
		{
			
		}
	}
}