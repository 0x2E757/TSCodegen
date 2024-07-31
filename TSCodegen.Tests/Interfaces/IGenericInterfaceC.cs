namespace TSCodegen.Tests.Interfaces
{
    internal interface IGenericInterfaceC<T, U, V>
    {
        public T PropertyC1 { get; set; }
        public U PropertyC2 { get; set; }
        public V PropertyC3 { get; set; }
    }
}
