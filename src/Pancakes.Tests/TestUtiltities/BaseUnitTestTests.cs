using System;
using Pancakes.TestUtilities;
using Xunit;

namespace Pancakes.Tests.TestUtilities
{
	public class BaseUnitTestTests
	{
		public class SystemUnderTest
		{
			[Fact]
			public void SystemUnderTest_AvailableUponInstantiation()
			{
				var sut = new BaseUnitTest<TypeWithInterfaceDependencies>();
				Assert.NotNull(sut.SystemUnderTest);
			}	
		}
		
		public class Build
		{
			[Fact]
			public void TypeWithMultipleConstructors_ThrowsException()
			{
				Assert.Throws<InvalidOperationException>(() => new BaseUnitTest<TypeWithMultipleConstructors>());
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
				Assert.Throws<InvalidOperationException>(() => new BaseUnitTest<TypeWithInappropriateDependencies>());
			}
		}
		
		public class Get
		{
			[Fact]
			public void CanGetInstance()
			{
				var sut = new BaseUnitTest<TypeWithInterfaceDependencies>();
				var bar = sut.GetMock<IBarService>();
			}
			
			[Fact]
			public void Instances_AreSingletons()
			{
				var sut = new BaseUnitTest<TypeWithInterfaceDependencies>();
				var first = sut.GetMock<IBarService>();
				var second = sut.GetMock<IBarService>();
				Assert.Equal(first, second);
			}
			
			[Fact]
			public void Instances_AreSameAsSystemUnderTest()
			{
				var sut = new BaseUnitTest<TypeWithInterfaceDependencies>();
				var first = sut.GetMock<IFooService>();
				var second = sut.Build().FooService;
				Assert.Equal(first, second);
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
				this.FooService = fooService;
			}

            public IFooService FooService { get; private set; }
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