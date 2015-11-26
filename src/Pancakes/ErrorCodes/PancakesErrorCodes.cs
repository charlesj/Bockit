namespace Pancakes.ErrorCodes
{
	public class PancakesErrorCodes : ErrorCode
	{
		public static ErrorCode InvalidTypeConversion = new PancakesErrorCodes(100, "A type conversion was attempted that was impossible");
		
		private PancakesErrorCodes(int identifier, string description) : base($"PANCAKES{identifier}", description)
		{	
		}
	}
}