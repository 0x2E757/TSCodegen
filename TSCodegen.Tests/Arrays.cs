using Microsoft.AspNetCore.Http;

namespace TSCodegen.Tests
{
    internal class Arrays
    {
        [Test]
        public void Boolean()
        {
            var tsTypeArray = new TypeScriptType(typeof(bool[]));
            var tsTypeList = new TypeScriptType(typeof(List<bool>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<bool>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("boolean[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("boolean[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("boolean[]"));

            var tsTypeNullableArray = new TypeScriptType(typeof(bool?[]));
            var tsTypeNullableList = new TypeScriptType(typeof(List<bool?>));
            var tsTypeNullableIEnumerable = new TypeScriptType(typeof(IEnumerable<bool?>));

            Assert.That(tsTypeNullableArray.GetFullTypeName(), Is.EqualTo("(boolean | null)[]"));
            Assert.That(tsTypeNullableList.GetFullTypeName(), Is.EqualTo("(boolean | null)[]"));
            Assert.That(tsTypeNullableIEnumerable.GetFullTypeName(), Is.EqualTo("(boolean | null)[]"));
        }

        [Test]
        public void Number()
        {
            var tsTypeArray = new TypeScriptType(typeof(int[]));
            var tsTypeList = new TypeScriptType(typeof(List<int>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<int>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("number[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("number[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("number[]"));

            var tsTypeNullableArray = new TypeScriptType(typeof(int?[]));
            var tsTypeNullableList = new TypeScriptType(typeof(List<int?>));
            var tsTypeNullableIEnumerable = new TypeScriptType(typeof(IEnumerable<int?>));

            Assert.That(tsTypeNullableArray.GetFullTypeName(), Is.EqualTo("(number | null)[]"));
            Assert.That(tsTypeNullableList.GetFullTypeName(), Is.EqualTo("(number | null)[]"));
            Assert.That(tsTypeNullableIEnumerable.GetFullTypeName(), Is.EqualTo("(number | null)[]"));
        }

        [Test]
        public void String()
        {
            var tsTypeArray = new TypeScriptType(typeof(string[]));
            var tsTypeList = new TypeScriptType(typeof(List<string>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<string>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("string[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("string[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("string[]"));
        }

        [Test]
        public void Interface()
        {
            var tsTypeArray = new TypeScriptType(typeof(Classes.Class[]));
            var tsTypeList = new TypeScriptType(typeof(List<Classes.Class>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<Classes.Class>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("IClass[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("IClass[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("IClass[]"));
        }

        [Test]
        public void GenericInterface()
        {
            var tsTypeArray = new TypeScriptType(typeof(Classes.GenericClass<int>[]));
            var tsTypeList = new TypeScriptType(typeof(List<Classes.GenericClass<int>>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<Classes.GenericClass<int>>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("IGenericClass<number>[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("IGenericClass<number>[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("IGenericClass<number>[]"));
        }

        [Test]
        public void Enum()
        {
            var tsTypeArray = new TypeScriptType(typeof(Classes.Enum[]));
            var tsTypeList = new TypeScriptType(typeof(List<Classes.Enum>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<Classes.Enum>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("Enum[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("Enum[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("Enum[]"));

            var tsTypeNullableArray = new TypeScriptType(typeof(Classes.Enum?[]));
            var tsTypeNullableList = new TypeScriptType(typeof(List<Classes.Enum?>));
            var tsTypeNullableIEnumerable = new TypeScriptType(typeof(IEnumerable<Classes.Enum?>));

            Assert.That(tsTypeNullableArray.GetFullTypeName(), Is.EqualTo("(Enum | null)[]"));
            Assert.That(tsTypeNullableList.GetFullTypeName(), Is.EqualTo("(Enum | null)[]"));
            Assert.That(tsTypeNullableIEnumerable.GetFullTypeName(), Is.EqualTo("(Enum | null)[]"));
        }

        [Test]
        public void GenericTask()
        {
            var tsTypeArray = new TypeScriptType(typeof(Task<int>[]));
            var tsTypeList = new TypeScriptType(typeof(List<Task<int>>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<Task<int>>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("number[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("number[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("number[]"));

            var tsTypeNullableArray = new TypeScriptType(typeof(Task<int?>[]));
            var tsTypeNullableList = new TypeScriptType(typeof(List<Task<int?>>));
            var tsTypeNullableIEnumerable = new TypeScriptType(typeof(IEnumerable<Task<int?>>));

            Assert.That(tsTypeNullableArray.GetFullTypeName(), Is.EqualTo("(number | null)[]"));
            Assert.That(tsTypeNullableList.GetFullTypeName(), Is.EqualTo("(number | null)[]"));
            Assert.That(tsTypeNullableIEnumerable.GetFullTypeName(), Is.EqualTo("(number | null)[]"));
        }

        [Test]
        public void DateTime()
        {
            var tsTypeArray = new TypeScriptType(typeof(DateTime[]));
            var tsTypeList = new TypeScriptType(typeof(List<DateTime>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<DateTime>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("(Date | DateTimeString)[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("(Date | DateTimeString)[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("(Date | DateTimeString)[]"));
        }

        [Test]
        public void TimeSpan()
        {
            var tsTypeArray = new TypeScriptType(typeof(TimeSpan[]));
            var tsTypeList = new TypeScriptType(typeof(List<TimeSpan>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<TimeSpan>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("TimeString[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("TimeString[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("TimeString[]"));
        }

        [Test]
        public void IFormFile()
        {
            var tsTypeArray = new TypeScriptType(typeof(IFormFile[]));
            var tsTypeList = new TypeScriptType(typeof(List<IFormFile>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<IFormFile>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("File[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("File[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("File[]"));
        }

        [Test]
        public void IEnumerable()
        {
            var tsTypeArray = new TypeScriptType(typeof(IEnumerable<int>[]));
            var tsTypeList = new TypeScriptType(typeof(List<IEnumerable<int>>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<IEnumerable<int>>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("number[][]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("number[][]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("number[][]"));
        }

        [Test]
        public void IDictionary()
        {
            var tsTypeArray = new TypeScriptType(typeof(IDictionary<int, int>[]));
            var tsTypeList = new TypeScriptType(typeof(List<IDictionary<int, int>>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<IDictionary<int, int>>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("Record<number, number>[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("Record<number, number>[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("Record<number, number>[]"));
        }

        [Test]
        public void Class()
        {
            var tsTypeArray = new TypeScriptType(typeof(Classes.Class[]));
            var tsTypeList = new TypeScriptType(typeof(List<Classes.Class>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<Classes.Class>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("IClass[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("IClass[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("IClass[]"));
        }

        [Test]
        public void GenericClass()
        {
            var tsTypeArray = new TypeScriptType(typeof(Classes.GenericClass<int>[]));
            var tsTypeList = new TypeScriptType(typeof(List<Classes.GenericClass<int>>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<Classes.GenericClass<int>>));

            Assert.That(tsTypeArray.GetFullTypeName(), Is.EqualTo("IGenericClass<number>[]"));
            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("IGenericClass<number>[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("IGenericClass<number>[]"));
        }
    }
}
