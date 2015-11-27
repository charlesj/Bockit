namespace Pancakes.Queries
{
	public interface IQueryProcessor
	{
		IQueryResult Query(IQuery query);
	}
	
	public interface IQuery
	{
		
	}
	
	public interface IQueryResult
	{
		
	}
}