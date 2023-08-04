# TSCodegen

Library for C# to TypeScript type conversion. Available as [NuGet package](https://www.nuget.org/packages/TSCodegen/).

Compatible with .NET Standard 2.0 and higher!

## Usage

Library contains two classes - `TypeScriptType` and `TypeScriptTypes`. The first is for creating primitive types and interface names. The second is for creating declarations from classes and enums.

Conversion table:

- Void → `void`
- Boolean → `boolean`
- Numerics → `number`
- Char & string → `string`
- DateTime → `Date | DateTimeString`\*
- TimeSpan → `TimeString`\*
- IFormFile → `File`
- Dynamic types → `any`
- All other types → `unknown`

Generic types:

- Array\<T\> / IEnumerable\<T\> → `T[]`
- Dictionary\<T, U\> → `Record<T, U>`
- Nullable\<T\> → `T | null`
- Task\<T\> → `T`

<sub>\* `DateTimeString` and `TimeString` should be described in a \*.d.ts file.</sub>

### DateTimeString and TimeString declaration example

```TypeScript
declare type DateString = "YYYY-MM-DD";
declare type TimeString = "HH:mm:ss";
declare type DateTimeString = `${DateString}T${TimeString}`;
```

### TypeScriptType

```C#
// Base properties
public string BaseTypeName { get; private set; }
public bool IsPrimitive { get; private set; }
public bool IsClass { get; private set; }
public bool IsEnum { get; private set; }
public bool IsArray { get; private set; }
public bool IsDictionary { get; private set; }
public bool IsNullable { get; private set; }
// Additional properties
public TypeScriptType Parent { get; private set; }
public TypeScriptType DictionaryKey { get; private set; }
public List<TypeScriptType> GenericArguments { get; private set; }
public List<TypeScriptType> OpenGenericArguments { get; private set; }
public Dictionary<string, string> Values { get; private set; }
public Dictionary<string, TypeScriptType> Properties { get; private set; }
// Constructor argument
public Type CSharpType { get; }
// Helpers
public bool HasParent => Parent != null;
public bool IsGeneric => GenericArguments.Count > 0;
public bool HasDeclaration => IsEnum || IsClass;
public override string ToString() => GetFullTypeName();
// Methods
public TypeScriptType(Type type);
public string GetFullTypeName();
public List<string> GetDeclaration(int indentationSize, bool export = false);
```

### TypeScriptTypes

```C#
// Base properties
public List<TypeScriptType> Items { get; }
// Methods
public void Add(TypeScriptType typeScriptType);
public void Add(IEnumerable<TypeScriptType> typeScriptTypes);
public List<string> GetDeclarations(int indentationSize, bool export = false);
```

<sub>\* The `Add` method will recursively add all related to the argument types.</sub>

## Example Application 1

```C#
using TSCodegen;

var num = 123;
var str = "qwe";
var flag = true;

Console.WriteLine(new TypeScriptType(num.GetType()));
Console.WriteLine(new TypeScriptType(str.GetType()));
Console.WriteLine(new TypeScriptType(flag.GetType()));
```

The output will be:

```TypeScript
number
string
boolean
```

## Example Application 2

```C#
using TSCodegen;

Console.WriteLine(new TypeScriptType(typeof(int)));
Console.WriteLine(new TypeScriptType(typeof(string)));
Console.WriteLine(new TypeScriptType(typeof(bool)));
```

The output will be:

```TypeScript
number
string
boolean
```

## Example Application 3

```C#
using TSCodegen;

var type = typeof(MyClass);
var tsType = new TypeScriptType(type);
var strings = tsType.GetDeclaration(4);
Console.WriteLine(string.Join("\n", strings));

class MyClass
{
    public int FieldA;
    public string FieldB;
    private bool FieldC;
}
```

The output will be:

```TypeScript
interface IMyClass {
    fieldA: number;
    fieldB: string;
}
```

## Example Application 4

```C#
using TSCodegen;

var tsType = new TypeScriptType(typeof(MyEnum));
var strings = tsType.GetDeclaration(4);
Console.WriteLine(string.Join("\n", strings));

enum MyEnum
{
    Foo = 1,
    Bar = 2,
    Baz = 4,
}
```

The output will be:

```TypeScript
enum MyEnum {
    Foo = 1,
    Bar = 2,
    Baz = 4,
}
```

## Example Application 5

```C#
using TSCodegen;

var type = typeof(MyGenericClass<bool, int, string>);
var tsType = new TypeScriptType(type);
Console.WriteLine(tsType);

class MyGenericClass<A, B, C>
{
    public A FieldA;
    public B FieldB;
    public C FieldC;
}
```

The output will be:

```TypeScript
IMyGenericClass<boolean, number, string>
```

## Example Application 6

```C#
using TSCodegen;

var type = typeof(MyGenericClass2<,>);
var tsType = new TypeScriptType(type);
var tsTypes = new TypeScriptTypes();
tsTypes.Add(tsType);
var strings = tsTypes.GetDeclarations(4);
Console.WriteLine(string.Join("\n", strings));

class MyGenericClass1<T>
{
    public T FieldA;
}

class MyGenericClass2<T, U> : MyGenericClass1<U>
{
    public T FieldB;
}
```

The output will be:

```TypeScript
interface IMyGenericClass1<T> {
    fieldA: T;
}

interface IMyGenericClass2<T, U> extends IMyGenericClass1<U> {
    fieldB: T;
}
```
