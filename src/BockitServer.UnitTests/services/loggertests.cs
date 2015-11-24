using Xunit;

public class LoggerTests
{
	[Fact]
	public void CanWrite()
	{
		var sut = new Logger();
		sut.Success("yes");
	}
	
	[Fact]
	public void FailingTest()
	{
		Assert.True(true);	
	}
}