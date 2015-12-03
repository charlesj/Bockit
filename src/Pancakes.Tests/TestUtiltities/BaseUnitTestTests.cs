using System;
using Pancakes.TestUtilities;
using Xunit;

namespace Pancakes.Tests.TestUtilities
{
	public class BaseUnitTest
	{
		public class Build
		{
			[Fact]
			public void TypeWithMultipleConstructors_ThrowsException()
			{
				var sut = new BaseUnitTest<TypeWithMultipleConstructors>();
				Assert.Throws<InvalidOperationException>(() => sut.Build());
			}
			
			[Fact]
			public void CanBuildType_WithNoDependencies()
			{
				var sut = new BaseUnitTest<TestableTypeNoDependencies>();
				var built = sut.Build();
			}
			
			[Fact]
			public void CanBuildType_WithInterfaceDependencies()
			{
				var sut = new BaseUnitTest<TypeWithInterfaceDependencies>();
				var built = sut.Build();
			}
			
			[Fact]
			public void CanBuildType_WithAbstractDependencies()
			{
				var sut = new BaseUnitTest<TypeWithAbstractDependcies>();
				var buildt = sut.Build();
			}
			
			[Fact]
			public void ThrowsException_WhenBuildingClassWithInappropriateDependencies()
			{
				var sut = new BaseUnitTest<TypeWithInappropriateDependencies>();
				Assert.Throws<InvalidOperationException>(() => sut.Build());
			}
		}
		
		public class TypeWithInappropriateDependencies
		{
			public TypeWithInappropriateDependencies(string inappropriate)
			{}
		}
		
		public class TypeWithInterfaceDependencies
		{
			public TypeWithInterfaceDependencies(IFooService fooService, IBarService barService)
			{
			}
		}
		
		public class TypeWithAbstractDependcies
		{
			public TypeWithAbstractDependcies(TestAbstractClass tac)
			{}
		}
		
		public abstract class TestAbstractClass
		{}
		
		public class TypeWithMultipleConstructors
		{
			public TypeWithMultipleConstructors()
			{
				
			}
			
			public TypeWithMultipleConstructors(IFooService fooService)
			{
				
			}
		}
		
		public class TestableTypeNoDependencies
		{	
		}
		
		public interface IFooService
		{
		}
		
		public interface IBarService
		{
		}
	}	
}