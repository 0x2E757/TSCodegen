namespace TSCodegen.Tests
{
    internal class Declaration
    {
        [Test]
        public void Enum()
        {
            var tsType = new TypeScriptType(typeof(Classes.Enum));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "enum Enum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void Class()
        {
            var tsType = new TypeScriptType(typeof(Classes.Class));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IClass {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ExportClass()
        {
            var tsType = new TypeScriptType(typeof(Classes.Class));
            var declaration = tsType.GetDeclaration(4, true);
            var target = new List<string>
            {
                "export interface IClass {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ClassWithFields()
        {
            var tsType = new TypeScriptType(typeof(Classes.ClassWithFields));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IClassWithFields {",
                "    boolField: boolean;",
                "    intField: number;",
                "    stringField: string;",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ClassWithProperties()
        {
            var tsType = new TypeScriptType(typeof(Classes.ClassWithProperties));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IClassWithProperties {",
                "    boolProperty: boolean;",
                "    intProperty: number;",
                "    stringProperty: string;",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericClass()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClass<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericClass<T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ExportGenericClass()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClass<>));
            var declaration = tsType.GetDeclaration(4, true);
            var target = new List<string>
            {
                "export interface IGenericClass<T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericClassA()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassA<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericClassA<T> {",
                "    propertyA: T;",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericClassB()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassB<,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericClassB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericClassC()
        {
            var tsType = new TypeScriptType(typeof(Classes.GenericClassC<,,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericClassC<T, U, V> {",
                "    propertyC1: T;",
                "    propertyC2: U;",
                "    propertyC3: V;",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildClass()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildClass));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildClass extends IClass {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassA1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassA1<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericClassA1<T> extends IGenericClassA<T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassA2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassA2<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericClassA2<T> extends IGenericClassA<number> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassB1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassB1<,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericClassB1<T, U> extends IGenericClassB<T, U> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassB2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassB2<,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericClassB2<T, U> extends IGenericClassB<boolean, number> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassC1()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassC1<,,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericClassC1<T, U, V> extends IGenericClassC<V, U, T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassC2()
        {
            var tsType = new TypeScriptType(typeof(Classes.ChildGenericClassC2<,,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericClassC2<T, U, V> extends IGenericClassC<IClass, IGenericClass<U>, Enum> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }
    }
}
