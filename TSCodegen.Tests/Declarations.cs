namespace TSCodegen.Tests
{
    internal class Declarations
    {
        [Test]
        public void Enum()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Enums.SimpleEnum)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "enum SimpleEnum {",
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
        public void Interface()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IInterface)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IInterface {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ExportInterface()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IInterface)));
            var declarations = tsTypes.GetDeclarations(4, true);
            var target = new List<string>
            {
                "export interface IInterface {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void InterfaceWithProperties()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IInterfaceWithProperties)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IInterfaceWithProperties {",
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
        public void ChildInterface()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IChildInterface)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IInterface {}",
                "",
                "interface IChildInterface extends IInterface {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericInterfaceWithProperties()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IGenericInterfaceWithProperties<>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericInterfaceWithProperties<T> {",
                "    arrayProperty: T[];",
                "}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceA1()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceA1<>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericInterfaceA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IChildGenericInterfaceA1<T> extends IGenericInterfaceA<T> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceA2()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceA2<Enums.SimpleEnum>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "enum SimpleEnum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
                "",
                "interface IGenericInterfaceA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IChildGenericInterfaceA2<T> extends IGenericInterfaceA<number> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceB1()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceB1<,>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericInterfaceB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
                "}",
                "",
                "interface IChildGenericInterfaceB1<T, U> extends IGenericInterfaceB<T, U> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceB2()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceB2<Interfaces.IInterface, Interfaces.IChildGenericInterfaceA2<Enums.SimpleEnum>>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IInterface {}",
                "",
                "enum SimpleEnum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
                "",
                "interface IGenericInterfaceA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IChildGenericInterfaceA2<T> extends IGenericInterfaceA<number> {}",
                "",
                "interface IGenericInterfaceB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
                "}",
                "",
                "interface IChildGenericInterfaceB2<T, U> extends IGenericInterfaceB<boolean, number> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceC1()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceC1<,,>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IGenericInterfaceC<T, U, V> {",
                "    propertyC1: T;",
                "    propertyC2: U;",
                "    propertyC3: V;",
                "}",
                "",
                "interface IChildGenericInterfaceC1<T, U, V> extends IGenericInterfaceC<V, U, T> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceC2()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceC2<bool, int, string>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IInterface {}",
                "",
                "interface IGenericInterface<T> {}",
                "",
                "enum SimpleEnum {",
                "    Foo = 1,",
                "    Bar = 2,",
                "    Baz = 4,",
                "}",
                "",
                "interface IGenericInterfaceC<T, U, V> {",
                "    propertyC1: T;",
                "    propertyC2: U;",
                "    propertyC3: V;",
                "}",
                "",
                "interface IChildGenericInterfaceC2<T, U, V> extends IGenericInterfaceC<IInterface, IGenericInterface<U>, SimpleEnum> {}",
            };

            Assert.That(declarations, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declarations.Count; n += 1)
                Assert.That(declarations[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericInterfaceWithDifferentArguments()
        {
            var tsTypes = new TypeScriptTypes();
            tsTypes.Add(new TypeScriptType(typeof(Interfaces.IGenericInterfaceB<Interfaces.IGenericInterfaceA<Interfaces.IInterfaceA>, Interfaces.IGenericInterfaceA<Interfaces.IInterfaceB>>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IInterfaceA {}",
                "",
                "interface IGenericInterfaceA<T> {",
                "    propertyA: T;",
                "}",
                "",
                "interface IInterfaceB {}",
                "",
                "interface IGenericInterfaceB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
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
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassA2<Enums.SimpleEnum>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "enum SimpleEnum {",
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
            tsTypes.Add(new TypeScriptType(typeof(Classes.ChildGenericClassB2<Classes.Class, Classes.ChildGenericClassA2<Enums.SimpleEnum>>)));
            var declarations = tsTypes.GetDeclarations(4);
            var target = new List<string>
            {
                "interface IClass {}",
                "",
                "enum SimpleEnum {",
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
                "enum SimpleEnum {",
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
                "interface IChildGenericClassC2<T, U, V> extends IGenericClassC<IClass, IGenericClass<U>, SimpleEnum> {}",
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
