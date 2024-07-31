namespace TSCodegen.Tests
{
    internal class Declaration
    {
        [Test]
        public void Enum()
        {
            var tsType = new TypeScriptType(typeof(Enums.SimpleEnum));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "enum SimpleEnum {",
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
        public void UnprefixedInterface()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.UnprefixedInterface));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IUnprefixedInterface {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ExportUnprefixedInterface()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.UnprefixedInterface));
            var declaration = tsType.GetDeclaration(4, true);
            var target = new List<string>
            {
                "export interface IUnprefixedInterface {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void Interface()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IInterface));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IInterface {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ExportInterface()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IInterface));
            var declaration = tsType.GetDeclaration(4, true);
            var target = new List<string>
            {
                "export interface IInterface {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void InterfaceWithProperties()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IInterfaceWithProperties));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IInterfaceWithProperties {",
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
        public void GenericInterface()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IGenericInterface<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericInterface<T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ExportGenericInterface()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IGenericInterface<>));
            var declaration = tsType.GetDeclaration(4, true);
            var target = new List<string>
            {
                "export interface IGenericInterface<T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericInterfaceA()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IGenericInterfaceA<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericInterfaceA<T> {",
                "    propertyA: T;",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericInterfaceB()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IGenericInterfaceB<,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericInterfaceB<T, U> {",
                "    propertyB1: T;",
                "    propertyB2: U;",
                "}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void GenericInterfaceC()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IGenericInterfaceC<,,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IGenericInterfaceC<T, U, V> {",
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
        public void ChildInterface()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IChildInterface));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildInterface extends IInterface {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceA1()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceA1<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericInterfaceA1<T> extends IGenericInterfaceA<T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceA2()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceA2<>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericInterfaceA2<T> extends IGenericInterfaceA<number> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceB1()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceB1<,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericInterfaceB1<T, U> extends IGenericInterfaceB<T, U> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceB2()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceB2<,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericInterfaceB2<T, U> extends IGenericInterfaceB<boolean, number> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceC1()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceC1<,,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericInterfaceC1<T, U, V> extends IGenericInterfaceC<V, U, T> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }

        [Test]
        public void ChildGenericInterfaceC2()
        {
            var tsType = new TypeScriptType(typeof(Interfaces.IChildGenericInterfaceC2<,,>));
            var declaration = tsType.GetDeclaration(4);
            var target = new List<string>
            {
                "interface IChildGenericInterfaceC2<T, U, V> extends IGenericInterfaceC<IInterface, IGenericInterface<U>, SimpleEnum> {}",
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
                "interface IChildGenericClassC2<T, U, V> extends IGenericClassC<IClass, IGenericClass<U>, SimpleEnum> {}",
            };

            Assert.That(declaration, Has.Count.EqualTo(target.Count));
            for (var n = 0; n < declaration.Count; n += 1)
                Assert.That(declaration[n], Is.EqualTo(target[n]));
        }
    }
}
