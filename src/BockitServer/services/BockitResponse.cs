namespace BockitServer.Services
{
	public class BockitResponse
	{
		public int HttpCode { get; set; }
		
		public string Body { get; set;}
		
		public static BockitResponse Ok()
		{
			return new BockitResponse { HttpCode = 202 };
		}
	}
}