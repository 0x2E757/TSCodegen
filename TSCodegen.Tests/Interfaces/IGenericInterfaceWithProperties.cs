namespace TSCodegen.Tests.Interfaces
{
    internal interface IGenericInterfaceWithProperties<T>
    {
        public T[] ArrayProperty { get; set; }
    }
}
