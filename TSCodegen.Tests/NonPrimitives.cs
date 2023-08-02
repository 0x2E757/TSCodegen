using Microsoft.AspNetCore.Http;

namespace TSCodegen.Tests
{
    internal class NonPrimitives
    {
        [Test]
        public void Task()
        {
            var tsType = new TypeScriptType(typeof(Task));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("void"));
        }

        [Test]
        public void GenericTask()
        {
            var tsType = new TypeScriptType(typeof(Task<int>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("number"));
        }

        [Test]
        public void DateTime()
        {
            var tsType = new TypeScriptType(typeof(DateTime));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("Date | DateTimeString"));
        }

        [Test]
        public void TimeSpan()
        {
            var tsType = new TypeScriptType(typeof(TimeSpan));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("TimeString"));
        }

        [Test]
        public void IFormFile()
        {
            var tsType = new TypeScriptType(typeof(IFormFile));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("File"));
        }

        [Test]
        public void IEnumerable()
        {
            var tsTypeList = new TypeScriptType(typeof(List<int>));
            var tsTypeIList = new TypeScriptType(typeof(IList<int>));
            var tsTypeIEnumerable = new TypeScriptType(typeof(IEnumerable<int>));

            Assert.That(tsTypeList.GetFullTypeName(), Is.EqualTo("number[]"));
            Assert.That(tsTypeIList.GetFullTypeName(), Is.EqualTo("number[]"));
            Assert.That(tsTypeIEnumerable.GetFullTypeName(), Is.EqualTo("number[]"));
        }

        [Test]
        public void IDictionary()
        {
            var tsTypeDictionary = new TypeScriptType(typeof(Dictionary<int, int>));
            var tsTypeIDictionary = new TypeScriptType(typeof(IDictionary<int, int>));

            Assert.That(tsTypeDictionary.GetFullTypeName(), Is.EqualTo("{ [key: number]: number }"));
            Assert.That(tsTypeIDictionary.GetFullTypeName(), Is.EqualTo("{ [key: number]: number }"));
        }
    }
}

