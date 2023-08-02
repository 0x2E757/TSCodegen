namespace TSCodegen.Tests
{
    internal class FullTypeName
    {
        [Test]
        public void Class()
        {
            var tsType = new TypeScriptType(typeof(Classes.Class));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IClass"));
        }

        [Test]
        public void ClassWithFields()
        {
            var tsType = new TypeScriptType(typeof(Classes.ClassWithFields));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IClassWithFields"));
        }

        [Test]
        public void ClassWithProperties()
        {
            var tsType = new TypeScriptType(typeof(Classes.ClassWithProperties));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IClassWithProperties"));
        }

        [Test]
        public void OpenGenericClass()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClass<>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClass<T>"));
        }

        [Test]
        public void GenericClass()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClass<int>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClass<number>"));
        }

        [Test]
        public void OpenGenericClassA()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassA<>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClassA<T>"));
        }

        [Test]
        public void GenericClassA()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassA<int>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClassA<number>"));
        }

        [Test]
        public void OpenGenericClassB()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassB<,>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClassB<T, U>"));
        }

        [Test]
        public void GenericClassB()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassB<int, bool>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClassB<number, boolean>"));
        }

        [Test]
        public void OpenGenericClassC()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassC<,,>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClassC<T, U, V>"));
        }

        [Test]
        public void GenericClassC()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassC<int, bool, string>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IGenericClassC<number, boolean, string>"));
        }

        [Test]
        public void ChildClass()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildClass));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildClass"));
        }

        [Test]
        public void OpenChildGenericClassA1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassA1<>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassA1<T>"));
        }

        [Test]
        public void ChildGenericClassA1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassA1<int>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassA1<number>"));
        }

        [Test]
        public void OpenChildGenericClassA2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassA2<>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassA2<T>"));
        }

        [Test]
        public void ChildGenericClassA2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassA2<int>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassA2<number>"));
        }

        [Test]
        public void OpenChildGenericClassB1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassB1<,>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassB1<T, U>"));
        }

        [Test]
        public void ChildGenericClassB1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassB1<int, bool>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassB1<number, boolean>"));
        }

        [Test]
        public void OpenChildGenericClassB2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassB2<,>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassB2<T, U>"));
        }

        [Test]
        public void ChildGenericClassB2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassB2<int, bool>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassB2<number, boolean>"));
        }

        [Test]
        public void OpenChildGenericClassC1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassC1<,,>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassC1<T, U, V>"));
        }

        [Test]
        public void ChildGenericClassC1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassC1<int, bool, string>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassC1<number, boolean, string>"));
        }

        [Test]
        public void OpenChildGenericClassC2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassC2<,,>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassC2<T, U, V>"));
        }

        [Test]
        public void ChildGenericClassC2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassC2<int, bool, string>));

            Assert.That(tsType.GetFullTypeName(), Is.EqualTo("IChildGenericClassC2<number, boolean, string>"));
        }
    }
}
