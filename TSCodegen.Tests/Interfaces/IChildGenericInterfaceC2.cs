using TSCodegen.Tests.Enums;

namespace TSCodegen.Tests.Interfaces
{
    internal interface IChildGenericInterfaceC2<T, U, V> : IGenericInterfaceC<IInterface, IGenericInterface<U>, SimpleEnum>
    {
    }
}
