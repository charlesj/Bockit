using System;
using Pancakes.ErrorCodes;
using Pancakes.Exceptions;
using Pancakes.ServiceLocator;

namespace Pancakes
{
    public class Kernel
	{
		private IServiceLocator serviceLocator;
		
		public BootConfiguration BootConfiguration { get; private set; }
        public IServiceLocator ServiceLocator 
		{ 
			get
			{
				if(this.serviceLocator == null)
					throw new PancakesInvalidOperationException(PancakesErrorCodes.AccessServiceLocatorPreBoot);
				
				return this.serviceLocator;
			} 
		}

        public void Boot(BootConfiguration configuration)
		{
			configuration.Boot();
			this.BootConfiguration = configuration;
			this.serviceLocator = new NinjectServiceLocator(configuration);
		}
	}
}