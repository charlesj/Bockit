using System;
using Pancakes.ErrorCodes;

namespace Pancakes.Exceptions
{
	public class PancakesArgumentNullException : ArgumentNullException, IPancakesException
	{
		private PancakesArgumentNullException(){}
		
		public PancakesArgumentNullException(ErrorCode errorCode, string argumentName) : base(argumentName)
		{
			this.ErrorCode = errorCode;
		}

        public ErrorCode ErrorCode {get; private set;}
    }
}