using System;
using System.ComponentModel;
using Pancakes.Exceptions;
using Pancakes.ErrorCodes;

namespace Pancakes
{
    public interface ITypeConverter
    {
        object Convert(object value, Type targetType);
        
        TTargetType Convert<TTargetType>(object value);
    }

    public class TypeConverter : ITypeConverter
    {
        public object Convert(object value, Type targetType)
        {
            if(value == null)
                throw new PancakesArgumentNullException(PancakesErrorCodes.NullTypeConversion, nameof(value));
            
            try
            {
                var converter = TypeDescriptor.GetConverter(targetType);
    
                if (value is string)
                {
                    return converter.ConvertFromString(value as string);
                }
    
                return converter.ConvertTo(value, targetType);
            }
            catch(Exception exception)
            {
                throw new PancakesInvalidOperationException(PancakesErrorCodes.InvalidTypeConversion, exception);
            }
        }

        public TTargetType Convert<TTargetType>(object value)
        {
            return (TTargetType)this.Convert(value, typeof(TTargetType));
        }
    }
}
