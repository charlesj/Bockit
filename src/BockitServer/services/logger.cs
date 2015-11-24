using System;
public class Logger
{
	public void Success(string message, params object[] args)
	{
		Console.WriteLine(message, args);
	}
}