using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Web.Http;

namespace TSCodegen
{
    public class TypeScriptType
    {
        public string BaseTypeName { get; private set; } = "unknown";
        public bool IsPrimitive { get; private set; } = false;
        public bool IsClass { get; private set; } = false;
        public bool IsEnum { get; private set; } = false;
        public bool IsArray { get; private set; } = false;
        public bool IsDictionary { get; private set; } = false;
        public bool IsNullable { get; private set; } = false;

        public TypeScriptType Parent { get; private set; } = null;
        public TypeScriptType DictionaryKey { get; private set; } = null;
        public List<TypeScriptType> GenericArguments { get; private set; } = new List<TypeScriptType>();
        public List<TypeScriptType> OpenGenericArguments { get; private set; } = new List<TypeScriptType>();
        public Dictionary<string, string> Values { get; private set; } = new Dictionary<string, string>();
        public Dictionary<string, TypeScriptType> Properties { get; private set; } = new Dictionary<string, TypeScriptType>();

        public Type CSharpType { get; } = default;

        public bool HasParent => Parent != null;
        public bool IsGeneric => GenericArguments.Count > 0;
        public bool HasDeclaration => IsEnum || IsClass;
        public override string ToString() => GetFullTypeName();

        public TypeScriptType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException();

            while (ExtractBaseType(ref type))
                continue;

            CSharpType = type;

            if (type.IsGenericType)
            {
                foreach (var genericArgument in type.GetGenericArguments())
                    GenericArguments.Add(new TypeScriptType(genericArgument));

                foreach (var genericArgument in type.GetGenericTypeDefinition().GetGenericArguments())
                    OpenGenericArguments.Add(new TypeScriptType(genericArgument));
            }

            if (Initialize(type))
                return;

            if (InitializeAsPrimitive(type))
            {
                IsPrimitive = true;
                return;
            }

            if (type.IsClass && InitializeAsClass(type))
            {
                IsClass = true;
                return;
            }

            if (type.IsEnum && InitializeAsEnum(type))
            {
                IsEnum = true;
                return;
            }
        }

        private bool ExtractBaseType(ref Type type)
        {
            if (type.IsArray)
            {
                IsArray = true;
                type = type.GetElementType();
                return true;
            }

            if (type.GetInterfaces().Contains(typeof(IEnumerable<>)))
            {
                IsArray = true;
                type = type.GenericTypeArguments[0];
                return true;
            }

            if (type.Name == typeof(Dictionary<,>).Name)
            {
                IsDictionary = true;
                DictionaryKey = new TypeScriptType(type.GenericTypeArguments[0]);
                type = type.GenericTypeArguments[1];
                return true;
            }

            if (type.Name == typeof(Nullable<>).Name)
            {
                IsNullable = true;
                type = type.GenericTypeArguments[0];
                return true;
            }

            if (type.Name == typeof(Task<>).Name)
            {
                IsNullable = true;
                type = type.GenericTypeArguments[0];
                return true;
            }

            if (type.Name == typeof(Task).Name)
            {
                IsNullable = true;
                type = typeof(void);
                return true;
            }

            return false;
        }

        private bool Initialize(Type type)
        {
            if (type == typeof(DateTime))
            {
                BaseTypeName = "Date | DateTimeString";
                return true;
            }

            if (type == typeof(TimeSpan))
            {
                BaseTypeName = "TimeString";
                return true;
            }

            if (type == typeof(IFormFile))
            {
                BaseTypeName = "File";
                return true;
            }

            if (type == typeof(IActionResult))
            {
                BaseTypeName = "any";
                return true;
            }

            if (type == typeof(IHttpActionResult))
            {
                BaseTypeName = "any";
                return true;
            }

            if (type == typeof(object))
            {
                BaseTypeName = "any";
                return true;
            }

            return false;
        }

        private bool InitializeAsPrimitive(Type type)
        {
            switch (type)
            {
                case Type @void when @void == typeof(void):
                    BaseTypeName = "void";
                    return true;

                case Type @bool when @bool == typeof(bool):
                    BaseTypeName = "boolean";
                    return true;

                case Type @byte when @byte == typeof(byte):
                case Type @sbyte when @sbyte == typeof(sbyte):
                case Type @short when @short == typeof(short):
                case Type @ushort when @ushort == typeof(ushort):
                case Type @int when @int == typeof(int):
                case Type @uint when @uint == typeof(uint):
                case Type @long when @long == typeof(long):
                case Type @ulong when @ulong == typeof(ulong):
                case Type @float when @float == typeof(float):
                case Type @double when @double == typeof(double):
                case Type @decimal when @decimal == typeof(decimal):
                case Type @bigint when @bigint == typeof(BigInteger):
                    BaseTypeName = "number";
                    return true;

                case Type @char when @char == typeof(char):
                case Type @string when @string == typeof(string):
                    BaseTypeName = "string";
                    return true;
            }

            return false;
        }

        private bool InitializeAsClass(Type type)
        {
            BaseTypeName = (type.IsGenericParameter ? "" : "I") + type.GetNameWithoutGenericArity();

            if (type.IsGenericType)
                type = type.GetGenericTypeDefinition();

            foreach (var field in type.GetFields())
            {
                if (Properties.ContainsKey(field.Name))
                    throw new Exception($"Classes with redeclared inherited fields are not allowed ({type.GetNameWithoutGenericArity()}.{field.Name}).");

                Properties.Add(field.Name, new TypeScriptType(field.FieldType));
            }

            foreach (var property in type.GetProperties())
            {
                if (Properties.ContainsKey(property.Name))
                    throw new Exception($"Classes with redeclared inherited properties are not allowed ({type.GetNameWithoutGenericArity()}.{property.Name}).");

                Properties.Add(property.Name, new TypeScriptType(property.PropertyType));
            }

            if (type.BaseType != typeof(object))
                Parent = new TypeScriptType(type.BaseType);

            return true;
        }

        private bool InitializeAsEnum(Type type)
        {
            BaseTypeName = type.Name;

            foreach (var value in type.GetEnumValues())
            {
                var enumType = Enum.GetUnderlyingType(type);
                var itemName = Enum.GetName(type, value);
                var itemValue = Convert.ChangeType(value, enumType).ToString();

                if (itemName == null || itemValue == null)
                    return false;

                Values.Add(itemName, itemValue);
            }

            return true;
        }

        public string GetFullTypeName()
        {
            var result = BaseTypeName;

            if (IsClass && IsGeneric)
            {
                var generics = GenericArguments.Select(oga => oga.BaseTypeName).ToArray();
                result += $"<{string.Join(", ", generics)}>";
            }

            if (IsNullable)
                result = $"{result} | null";

            if (IsArray)
                result = result.Contains('|') ? $"({result})[]" : $"{result}[]";

            if (IsDictionary)
                result = $"{{ [key: {DictionaryKey.BaseTypeName}]: {result} }}";

            return result;
        }

        public List<string> GetDeclaration(int indentitationSize, bool export = false)
        {
            var result = new List<string>();
            var indentitation = new string(' ', indentitationSize);

            if (IsClass)
            {
                var typeName = BaseTypeName;

                if (IsClass && IsGeneric)
                {
                    var generics = OpenGenericArguments.Select(oga => oga.BaseTypeName).ToArray();
                    typeName += $"<{string.Join(", ", generics)}>";
                }

                var declarationHeader = (export ? "export " : "") + $"{typeName}";

                if (HasParent)
                {
                    declarationHeader += $" extends {Parent.BaseTypeName}";

                    if (Parent.IsGeneric)
                    {
                        var generics = Parent.GenericArguments.Select(ga => ga.BaseTypeName).ToArray();
                        declarationHeader += $"<{string.Join(", ", generics)}>";
                    }
                }

                result.Add($"interface {declarationHeader} {{");

                foreach (var property in Properties)
                    if (!HasParent || !Parent.Properties.ContainsKey(property.Key))
                        result.Add(indentitation + $"{property.Key.ToCamelCase()}: {property.Value.GetFullTypeName()};");

                result.Add($"}}");
            }

            if (IsEnum)
            {
                result.Add($"enum {BaseTypeName} {{");

                foreach (var value in Values)
                    result.Add(indentitation + $"{value.Key.ToCamelCase()} = {value.Value},");

                result.Add($"}}");
            }

            return result;
        }
    }
}
