namespace TSCodegen.Tests.Classes
{
    internal class GenericClassC<T, U, V>
    {
        public T PropertyC1 { get; set; } = default!;
        public U PropertyC2 { get; set; } = default!;
        public V PropertyC3 { get; set; } = default!;
    }
}
