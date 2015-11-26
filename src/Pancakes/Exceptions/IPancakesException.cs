using Pancakes.ErrorCodes;
namespace Pancakes.Exceptions
{
	public interface IPancakesException
	{
		ErrorCode ErrorCode { get; }
	}
}