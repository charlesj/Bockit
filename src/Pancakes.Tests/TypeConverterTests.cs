using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Pancakes;

namespace Pancakes.Tests
{
    public class TypeConverterTests
    {
        private readonly ITypeConverter typeConverter;
        
        public TypeConverterTests()
        {
            this.typeConverter = new TypeConverter();
        }
        
		[Theory]
		[InlineData("1", typeof(int))]
		[InlineData("B6A7EAF2-08A1-4DD3-BD19-DB95BFA59EDF", typeof(Guid))]
		[InlineData("true", typeof(bool))]
		public void CanConvertWithoutThrowing(object source, Type target)
		{
			this.typeConverter.Convert(source, target);
		}
        
        [Theory]
        [InlineData("1d", typeof(int))]
		[InlineData("08A1-4DD3-BD19-DB95BFA59EDF", typeof(Guid))]
		[InlineData("truthy", typeof(bool))]
        public void ThrowsExceptionWhenInvalidConversion(object source, Type target)
        {
            Assert.Throws<InvalidOperationException>(() => this.typeConverter.Convert(source, target));
        }
        
        [Fact]
        public void ThrowsNullArgumentExceptionWhenPassNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => this.typeConverter.Convert(null, typeof(string)));
        }
        
        [Fact]
        public void CanConvertUsingGenericMethod()
        {
            var input = "1";
            var output = this.typeConverter.Convert<int>(input);
            Assert.Equal(1, output);
        }
    }
}
