namespace Pancakes.ErrorCodes
{
	public class PancakesErrorCodes : ErrorCode
	{
		public static ErrorCode NullTypeConversion = new PancakesErrorCodes(100, "A conversion was attempted using a null value");
		public static ErrorCode InvalidTypeConversion = new PancakesErrorCodes(101, "Attempted to convert to a type that was not valid.");
		public static ErrorCode CannotConfigurePostBoot = new PancakesErrorCodes(102, "Attempted to adjust the boot configuration after boot().");
		
		public static ErrorCode AccessServiceLocatorPreBoot = new PancakesErrorCodes(103, "Attempted to access the service locator before booting");
		private PancakesErrorCodes(int identifier, string description) : base($"PANCAKES{identifier}", description)
		{	
		}
	}
}