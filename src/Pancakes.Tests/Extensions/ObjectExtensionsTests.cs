using Pancakes.Extensions;
using Xunit;

namespace Pancakes.Tests.Extensions
{
	public class ObjectExtensionsTest
	{
		[Fact]
		public void CanConvertEmptyObjectToJson()
		{
			var empty = new EmptyObject();
			var json = empty.ToJson();
			Assert.Equal("{}", json);
		}
		
		[Fact]
		public void CanConvertSimpleObjectToJson()
		{
			var simple = new SimpleObject { Count = 42 };
			var json = simple.ToJson();
			Assert.Equal("{\"Count\":42}", json);
		}
		
		[Fact]
		public void CanConvertSimpleObjectToFormattedJson()
		{
			var simple = new SimpleObject { Count = 42 };
			var json = simple.ToJson(true);
			Assert.Equal("{\n  \"Count\": 42\n}", json);
		}
		
		public class EmptyObject {}
		
		public class SimpleObject
		{
			public int Count { get; set; }
		}
	}
}