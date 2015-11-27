using System;
using Ninject;

namespace Pancakes.ServiceLocator
{
	public class NinjectServiceLocator : IServiceLocator
	{
		private readonly IKernel kernel;
		
		public NinjectServiceLocator(BootConfiguration configuration)
		{
			this.kernel = new StandardKernel();
			kernel.Load(configuration.ModulesToLoad);
		}
		
		public IKernel Kernel
		{
			get
			{
				return this.kernel;
			}
		}

        public object Get(Type type)
        {
            return this.kernel.Get(type);
        }

        public TServiceType Get<TServiceType>()
        {
            return this.kernel.Get<TServiceType>();
        }
    }
}