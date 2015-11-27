namespace Pancakes.Commands
{
	public interface ICommandProcessor
	{
		ICommandResult Execute(ICommandRequest request);	
	}
	
	public interface ICommandRequest
	{
		
	}
	
	public interface ICommandResult
	{
		
	}
}