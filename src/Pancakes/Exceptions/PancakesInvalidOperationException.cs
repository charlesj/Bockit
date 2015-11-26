using System;
using Pancakes.ErrorCodes;

namespace Pancakes.Exceptions
{
    public class PancakesInvalidOperationException : InvalidOperationException, IPancakesException
    {
		private PancakesInvalidOperationException(){}
		
		public PancakesInvalidOperationException(ErrorCode errorCode)
		{
			this.ErrorCode = errorCode;
		}
		
        public ErrorCode ErrorCode {get; private set;}        
    }
}