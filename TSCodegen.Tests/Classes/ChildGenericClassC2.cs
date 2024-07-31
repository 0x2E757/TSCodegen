using TSCodegen.Tests.Enums;

namespace TSCodegen.Tests.Classes
{
    internal class ChildGenericClassC2<T, U, V> : GenericClassC<Class, GenericClass<U>, SimpleEnum>
    {
    }
}
