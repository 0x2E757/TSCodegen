namespace TSCodegen.Tests
{
    internal class Declarations
    {
        [Test]
        public void Enum()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.Enum)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "enum Enum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void Class()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.Class)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClass {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ExportClass()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.Class)));
            var declarations = tsTypes.GetDeclarations(4, true);
            var target = new List<string>
            {
                "export interface IClass {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ClassWithFields()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ClassWithFields)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClassWithFields {",
                "    boolField: boolean;",
                "    intField: number;",
                "    stringField: string;",
                "}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ClassWithProperties()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ClassWithProperties)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClassWithProperties {",
                "    boolProperty: boolean;",
                "    intProperty: number;",
                "    stringProperty: string;",
                "}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildClass()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildClass)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClass {}",
                "",
                "interface IChildClass extends IClass {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericClassWithProperties()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.GenericClassWithProperties<>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericClassWithProperties<T> {",
                "    arrayProperty: T[];",
                "}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassA1()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassA1<>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericClassA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IChildGenericClassA1<T> extends IGenericClassA<T> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassA2()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassA2<Classes.Enum>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "enum Enum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
                "",
                "interface IGenericClassA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IChildGenericClassA2<T> extends IGenericClassA<number> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassB1()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassB1<,>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericClassB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
                "}",
                "",
                "interface IChildGenericClassB1<T, U> extends IGenericClassB<T, U> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassB2()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassB2<Classes.Class, Classes.ChildGenericClassA2<Classes.Enum>>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClass {}",
                "",
                "enum Enum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
                "",
                "interface IGenericClassA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IChildGenericClassA2<T> extends IGenericClassA<number> {}",
                "",
                "interface IGenericClassB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
                "}",
                "",
                "interface IChildGenericClassB2<T, U> extends IGenericClassB<boolean, number> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassC1()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassC1<,,>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericClassC<T, U, V> {",
                "    propertyC1: T;",
                "    propertyC2: U;",
                "    propertyC3: V;",
                "}",
                "",
                "interface IChildGenericClassC1<T, U, V> extends IGenericClassC<V, U, T> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericClassC2()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassC2<bool, int, string>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClass {}",
                "",
                "interface IGenericClass<T> {}",
                "",
                "enum Enum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
                "",
                "interface IGenericClassC<T, U, V> {",
                "    propertyC1: T;",
                "    propertyC2: U;",
                "    propertyC3: V;",
                "}",
                "",
                "interface IChildGenericClassC2<T, U, V> extends IGenericClassC<IClass, IGenericClass<U>, Enum> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericClassWithDifferentArguments()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Classes.GenericClassB<Classes.GenericClassA<Classes.ClassA>, Classes.GenericClassA<Classes.ClassB>>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClassA {}",
                "",
                "interface IGenericClassA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IClassB {}",
                "",
                "interface IGenericClassB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
                "}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }
    }
}
