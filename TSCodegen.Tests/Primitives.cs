namespace TSCodegen.Tests
{
    public class Primitives
    {
        [Test]
        public void Void()
        {
            var tsTypeVoid = new TypeScriptType(typeof(void));

            Assert.That(tsTypeVoid.GetFullTypeName(), Is.EqualTo("void"));
        }

        [Test]
        public void Boolean()
        {
            var tsTypeBool = new TypeScriptType(typeof(bool));

            Assert.That(tsTypeBool.GetFullTypeName(), Is.EqualTo("boolean"));
        }

        [Test]
        public void Number()
        {
            var tsTypeByte = new TypeScriptType(typeof(byte));
            var tsTypeSByte = new TypeScriptType(typeof(sbyte));
            var tsTypeShort = new TypeScriptType(typeof(short));
            var tsTypeUShort = new TypeScriptType(typeof(ushort));
            var tsTypeInt = new TypeScriptType(typeof(int));
            var tsTypeUInt = new TypeScriptType(typeof(uint));
            var tsTypeLong = new TypeScriptType(typeof(long));
            var tsTypeULong = new TypeScriptType(typeof(ulong));
            var tsTypeFloat = new TypeScriptType(typeof(float));
            var tsTypeDouble = new TypeScriptType(typeof(double));
            var tsTypeDecimal = new TypeScriptType(typeof(decimal));

            Assert.That(tsTypeByte.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeSByte.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeShort.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeUShort.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeInt.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeUInt.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeLong.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeULong.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeFloat.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeDouble.GetFullTypeName(), Is.EqualTo("number"));
            Assert.That(tsTypeDecimal.GetFullTypeName(), Is.EqualTo("number"));
        }

        [Test]
        public void String()
        {
            var tsTypeChar = new TypeScriptType(typeof(char));
            var tsTypeString = new TypeScriptType(typeof(string));

            Assert.That(tsTypeChar.GetFullTypeName(), Is.EqualTo("string"));
            Assert.That(tsTypeString.GetFullTypeName(), Is.EqualTo("string"));
        }
    }
}