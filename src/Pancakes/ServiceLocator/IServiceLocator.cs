using System;

namespace Pancakes.ServiceLocator
{
	public interface IServiceLocator
	{
		object Get(Type type);
		
		TServiceType Get<TServiceType>();
	}
}