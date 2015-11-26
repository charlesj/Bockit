using System;

namespace Pancakes
{
    public interface ITypeConverter
    {
        object Convert(object value, Type targetType);
        
        TTargetType Convert<TTargetType>(object value);
    }
}
