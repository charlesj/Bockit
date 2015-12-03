using System;
using System.Collections.Generic;
using System.Linq;

namespace Pancakes.TestUtilities
{
	public class BaseUnitTest<TSystemUnderTest>
	{
		public TSystemUnderTest Build()
		{
			var mockRegistry = new NSubstituteMockRegistry();
			var constructorParams = new List<object>();
			var constructors = (typeof(TSystemUnderTest)).GetConstructors();
			if(constructors.Count() > 1)
				throw new InvalidOperationException("Cannot Test Types with multiple constructors - Code Smell");
			
			var constructor = constructors[0];
			var parameters = constructor.GetParameters();
			foreach (var parameter in parameters)
			{
				var parametType = parameter.ParameterType;
				if(!parametType.IsAbstract && !parametType.IsInterface)
					throw new InvalidOperationException("Use more appropriate types (interface or abstract) for your dependencies");
					
				constructorParams.Add(mockRegistry.Get(parameter.ParameterType));
			}
			
			var instance = constructor.Invoke(constructorParams.ToArray()); 
			return (TSystemUnderTest)instance;
		}
	}
}