namespace TSCodegen.Tests.Classes
{
    internal class GenericClassWithProperties<T>
    {
        public T[] ArrayProperty { get; set; } = default!;
    }
}
