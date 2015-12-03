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
		public void ReturnedObject_CanBeCastToRequestedType()
		{
			var constructed = this.SystemUnderTest.Get(typeof(ITestInterface));
			Assert.IsAssignableFrom(typeof(ITestInterface), constructed);
		}
		
		[Fact]
		public void RequestingSameType_ReturnsSameObject()
		{
			var first = this.SystemUnderTest.Get(typeof(ITestInterface));
			var second = this.SystemUnderTest.Get(typeof(ITestInterface));
			Assert.Equal(first, second);
		}
		
		public interface ITestInterface
		{
			
		}
	}
}