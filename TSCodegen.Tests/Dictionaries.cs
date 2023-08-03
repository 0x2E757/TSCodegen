using Microsoft.AspNetCore.Http;

namespace TSCodegen.Tests
{
    internal class Dictionaries
    {
        [Test]
        public void PrimitiveKeys()
        {
            var tsTypeBooleanKey = new TypeScriptType(typeof(Dictionary<bool, int>));
            var tsTypeNumberKey = new TypeScriptType(typeof(Dictionary<int, int>));
            var tsTypeStringKey = new TypeScriptType(typeof(Dictionary<string, int>));

            Assert.That(tsTypeBooleanKey.GetFullTypeName(), Is.EqualTo("Record<boolean, number>"));
            Assert.That(tsTypeNumberKey.GetFullTypeName(), Is.EqualTo("Record<number, number>"));
            Assert.That(tsTypeStringKey.GetFullTypeName(), Is.EqualTo("Record<string, number>"));
        }

        [Test]
        public void PrimitiveElements()
        {
            var tsTypeBoolean = new TypeScriptType(typeof(Dictionary<int, bool>));
            var tsTypeNumber = new TypeScriptType(typeof(Dictionary<int, int>));
            var tsTypeString = new TypeScriptType(typeof(Dictionary<int, string>));

            Assert.That(tsTypeBoolean.GetFullTypeName(), Is.EqualTo("Record<number, boolean>"));
            Assert.That(tsTypeNumber.GetFullTypeName(), Is.EqualTo("Record<number, number>"));
            Assert.That(tsTypeString.GetFullTypeName(), Is.EqualTo("Record<number, string>"));

            var tsTypeBooleanArray = new TypeScriptType(typeof(Dictionary<int, bool[]>));
            var tsTypeNumberArray = new TypeScriptType(typeof(Dictionary<int, int[]>));
            var tsTypeStringArray = new TypeScriptType(typeof(Dictionary<int, string[]>));

            Assert.That(tsTypeBooleanArray.GetFullTypeName(), Is.EqualTo("Record<number, boolean[]>"));
            Assert.That(tsTypeNumberArray.GetFullTypeName(), Is.EqualTo("Record<number, number[]>"));
            Assert.That(tsTypeStringArray.GetFullTypeName(), Is.EqualTo("Record<number, string[]>"));

            var tsTypeBooleanNullable = new TypeScriptType(typeof(Dictionary<int, bool?>));
            var tsTypeNumberNullable = new TypeScriptType(typeof(Dictionary<int, int?>));

            Assert.That(tsTypeBooleanNullable.GetFullTypeName(), Is.EqualTo("Record<number, boolean | null>"));
            Assert.That(tsTypeNumberNullable.GetFullTypeName(), Is.EqualTo("Record<number, number | null>"));
        }

        [Test]
        public void NonPrimitiveElements()
        {
            var tsTypeDateTime = new TypeScriptType(typeof(Dictionary<int, DateTime>));
            var tsTypeTimeSpan = new TypeScriptType(typeof(Dictionary<int, TimeSpan>));
            var tsTypeIFormFile = new TypeScriptType(typeof(Dictionary<int, IFormFile>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(Dictionary<int, IEnumerable<int>>));
            var tsTypeIDictionary = new TypeScriptType(typeof(Dictionary<int, IDictionary<int, int>>));
            var tsTypeClass = new TypeScriptType(typeof(Dictionary<int, Classes.Class>));
            var tsTypeGenericClass = new TypeScriptType(typeof(Dictionary<int, Classes.GenericClass<int>>));
            var tsTypeEnum = new TypeScriptType(typeof(Dictionary<int, Classes.Enum>));

            Assert.That(tsTypeDateTime.GetFullTypeName(), Is.EqualTo("Record<number, Date | DateTimeString>"));
            Assert.That(tsTypeTimeSpan.GetFullTypeName(), Is.EqualTo("Record<number, TimeString>"));
            Assert.That(tsTypeIFormFile.GetFullTypeName(), Is.EqualTo("Record<number, File>"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("Record<number, number[]>"));
            Assert.That(tsTypeIDictionary.GetFullTypeName(), Is.EqualTo("Record<number, Record<number, number>>"));
            Assert.That(tsTypeClass.GetFullTypeName(), Is.EqualTo("Record<number, IClass>"));
            Assert.That(tsTypeGenericClass.GetFullTypeName(), Is.EqualTo("Record<number, IGenericClass<number>>"));
            Assert.That(tsTypeEnum.GetFullTypeName(), Is.EqualTo("Record<number, Enum>"));
        }
    }
}
