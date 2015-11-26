using System;
using System.ComponentModel;

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
                throw new ArgumentNullException(nameof(value));
            var converter = TypeDescriptor.GetConverter(targetType);
			if (!converter.IsValid(value) || !converter.CanConvertFrom(value.GetType()))
			{
				throw new InvalidOperationException("Attempted to convert to a type that was not valid.");
			}

			if (value is string)
			{
				return converter.ConvertFromString(value as string);
			}

			return converter.ConvertTo(value, targetType);
        }

        public TTargetType Convert<TTargetType>(object value)
        {
            return (TTargetType)this.Convert(value, typeof(TTargetType));
        }
    }
}
