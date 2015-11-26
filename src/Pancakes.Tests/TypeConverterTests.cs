using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Pancakes;
using Pancakes.Exceptions;
using Pancakes.ErrorCodes;

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
            try 
            {
                this.typeConverter.Convert(source, target);
            } 
            catch(PancakesInvalidOperationException exception)
            {
                Assert.Equal(PancakesErrorCodes.InvalidTypeConversion, exception.ErrorCode);
            }
        }
        
        [Fact]
        public void ThrowsNullArgumentExceptionWhenPassNullValue()
        {
            try
            {
                this.typeConverter.Convert(null, typeof(string));
            }
            catch (PancakesArgumentNullException exception)
            {
                Assert.Equal(PancakesErrorCodes.NullTypeConversion, exception.ErrorCode);
                Assert.Equal("value", exception.ParamName);                
            }
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
