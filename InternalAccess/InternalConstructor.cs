using System.Linq;
using System.Reflection;

namespace InternalAccess
{
    public static class InternalConstructor
    {
        private const int ParameterCount = 1;
        public static object ConstructSingleParameter<T>(object parameter)
        {
            var ctor = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(c => c.GetParameters().Any());

            return (T)ctor?.Invoke(new object[ParameterCount]
                { parameter });
        }
    }
}
