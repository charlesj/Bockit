using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ninject.Modules;
using Pancakes.ErrorCodes;
using Pancakes.Exceptions;

namespace Pancakes
{
	public class BootConfiguration
	{
		private bool hasBeenBooted;
		private readonly List<INinjectModule> modulesToLoad;
		
		public BootConfiguration()
		{
			this.modulesToLoad = new List<INinjectModule>();
		}

        public ReadOnlyCollection<INinjectModule> ModulesToLoad
        {
            get
            {
                return modulesToLoad.AsReadOnly();
            }
        }

        public bool BeVerbose { get; private set; }
		
		public static BootConfiguration DefaultConfiguration
		{
			get 
			{
				return new BootConfiguration();
			}
		}

        public void Boot()
        {
            this.hasBeenBooted = true;
        }

        public BootConfiguration AddNinjectModule(INinjectModule module)
		{
			this.ProtectAgainstConfiguringAfterBoot();
			this.modulesToLoad.Add(module);
			return this;
		}
		
		public BootConfiguration Verbose()
		{
			this.ProtectAgainstConfiguringAfterBoot();
			this.BeVerbose = true;
			return this;
		}
		
		private void ProtectAgainstConfiguringAfterBoot()
		{
			if(this.hasBeenBooted)
				throw new PancakesInvalidOperationException(PancakesErrorCodes.CannotConfigurePostBoot);
		}
	}
}