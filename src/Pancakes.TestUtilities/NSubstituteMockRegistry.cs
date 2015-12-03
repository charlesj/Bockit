using System;
using System.Collections.Generic;
using NSubstitute;

namespace Pancakes.TestUtilities
{
	public class NSubstituteMockRegistry
	{
		private Dictionary<Type, object> registry;
		
		public NSubstituteMockRegistry()
		{
				this.registry = new Dictionary<Type, object>();
		} 
		
        public object Get(Type type)
        {
			if (this.registry.ContainsKey(type))
			{
				var mock = Substitute.For(new[] { type }, null);
				this.registry.Add(type, mock);
			}
			
            return this.registry[type];
        }
    }
}