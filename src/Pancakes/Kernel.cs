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
				
				throw new NotImplementedException();
			} 
		}

        public void Boot(BootConfiguration configuration)
		{
			configuration.Boot();
			this.BootConfiguration = configuration;
		}
	}
}