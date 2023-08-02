namespace TSCodegen.Tests
{
    internal class Nullables
    {
        [Test]
        public void Boolean()
        {
            var tsType = new TypeScriptType(typeof(bool?));
            
            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("boolean | null"));
        }

        [Test]
        public void Number()
        {
            var tsType = new TypeScriptType(typeof(int?));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("number | null"));
        }

        [Test]
        public void Enum()
        {
            var tsType = new TypeScriptType(typeof(Classes.Enum?));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("Enum | null"));
        }
    }
}
