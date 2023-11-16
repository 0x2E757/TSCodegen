using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool HasOverrides { get; private set; } = false;

        public TypeScriptType Parent { get; private set; } = null;
        public TypeScriptType Element { get; private set; } = null;
        public TypeScriptType DictionaryKey { get; private set; } = null;
        public List<TypeScriptType> GenericArguments { get; private set; } = new List<TypeScriptType>();
        public List<TypeScriptType> OpenGenericArguments { get; private set; } = new List<TypeScriptType>();
        public Dictionary<string, string> Values { get; private set; } = new Dictionary<string, string>();
        public Dictionary<string, TypeScriptType> Properties { get; private set; } = new Dictionary<string, TypeScriptType>();

        public Type CSharpType { get; private set; } = default;

        public bool HasParent => Parent != null;
        public bool HasElement => Element != null;
        public bool IsGeneric => GenericArguments.Count > 0;
        public bool HasDeclaration => IsEnum || IsClass;
        public override string ToString() => GetFullTypeName();

        public TypeScriptType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException();

            CSharpType = type;

            while (TryExtractBaseType())
                if (IsArray || IsDictionary)
                    return;

            if (CSharpType.IsGenericType)
            {
                foreach (var genericArgument in CSharpType.GetGenericArguments())
                    GenericArguments.Add(new TypeScriptType(genericArgument));

                foreach (var genericArgument in CSharpType.GetGenericTypeDefinition().GetGenericArguments())
                    OpenGenericArguments.Add(new TypeScriptType(genericArgument));
            }

            if (Initialize())
                return;

            if (InitializeAsPrimitive())
            {
                IsPrimitive = true;
                return;
            }

            if (CSharpType.IsClass && InitializeAsClass())
            {
                IsClass = true;
                return;
            }

            if (CSharpType.IsEnum && InitializeAsEnum())
            {
                IsEnum = true;
                return;
            }
        }

        private bool TryExtractBaseType()
        {
            if (CSharpType.IsArray)
            {
                IsArray = true;
                Element = new TypeScriptType(CSharpType.GetElementType());
                return true;
            }

            if (CSharpType.Implements(typeof(Task)))
            {
                CSharpType = typeof(void);
                return true;
            }

            if (CSharpType.Implements(typeof(Task<>)))
            {
                CSharpType = CSharpType.GenericTypeArguments[0];
                return true;
            }

            if (CSharpType.Implements(typeof(IDictionary<,>)))
            {
                IsDictionary = true;
                DictionaryKey = new TypeScriptType(CSharpType.GenericTypeArguments[0]);
                Element = new TypeScriptType(CSharpType.GenericTypeArguments[1]);
                return true;
            }

            if (CSharpType.Implements(typeof(IEnumerable<>)))
            {
                IsArray = true;
                Element = new TypeScriptType(CSharpType.GenericTypeArguments[0]);
                return true;
            }

            if (CSharpType.Implements(typeof(Nullable<>)))
            {
                IsNullable = true;
                CSharpType = CSharpType.GenericTypeArguments[0];
                return true;
            }

            return false;
        }

        private bool Initialize()
        {
            if (CSharpType == typeof(DateTime))
            {
                BaseTypeName = "Date | DateTimeString";
                return true;
            }

            if (CSharpType == typeof(TimeSpan))
            {
                BaseTypeName = "TimeString";
                return true;
            }

            if (CSharpType == typeof(IFormFile))
            {
                BaseTypeName = "File";
                return true;
            }

            if (CSharpType == typeof(IActionResult))
            {
                BaseTypeName = "any";
                return true;
            }

            if (CSharpType == typeof(IHttpActionResult))
            {
                BaseTypeName = "any";
                return true;
            }

            if (CSharpType == typeof(object))
            {
                BaseTypeName = "any";
                return true;
            }

            return false;
        }

        private bool InitializeAsPrimitive()
        {
            switch (CSharpType)
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
                    BaseTypeName = "number";
                    return true;

                case Type @char when @char == typeof(char):
                case Type @string when @string == typeof(string):
                    BaseTypeName = "string";
                    return true;
            }

            return false;
        }

        private bool InitializeAsClass()
        {
            BaseTypeName = (CSharpType.IsGenericParameter ? "" : "I") + CSharpType.GetNameWithoutGenericArity();

            if (CSharpType.IsGenericType)
                CSharpType = CSharpType.GetGenericTypeDefinition();

            foreach (var field in CSharpType.GetFields())
            {
                if (Properties.ContainsKey(field.Name))
                {
                    var fieldLastOverride = CSharpType.GetFieldLastOverride(field.Name);
                    Properties[field.Name] = new TypeScriptType(fieldLastOverride.FieldType);
                    HasOverrides = true;
                }
                else
                    Properties.Add(field.Name, new TypeScriptType(field.FieldType));
            }

            foreach (var property in CSharpType.GetProperties())
            {
                if (Properties.ContainsKey(property.Name))
                {
                    var propertyLastOverride = CSharpType.GetPropertyLastOverride(property.Name);
                    Properties[property.Name] = new TypeScriptType(propertyLastOverride.PropertyType);
                    HasOverrides = true;
                }
                else
                    Properties.Add(property.Name, new TypeScriptType(property.PropertyType));
            }

            if (CSharpType.BaseType != typeof(object))
                Parent = new TypeScriptType(CSharpType.BaseType);

            return true;
        }

        private bool InitializeAsEnum()
        {
            BaseTypeName = CSharpType.Name;

            foreach (var value in CSharpType.GetEnumValues())
            {
                var enumType = Enum.GetUnderlyingType(CSharpType);
                var itemName = Enum.GetName(CSharpType, value);
                var itemValue = Convert.ChangeType(value, enumType).ToString();

                if (itemName == null || itemValue == null)
                    return false;

                Values.Add(itemName, itemValue);
            }

            return true;
        }

        public string GetOpenGenericTypeName()
        {
            var result = BaseTypeName;

            if (IsClass && IsGeneric)
            {
                var generics = OpenGenericArguments.Select(oga => oga.GetOpenGenericTypeName());
                result += $"<{string.Join(", ", generics)}>";
            }

            return result;
        }

        public string GetFullTypeName()
        {
            var result = Element?.GetFullTypeName() ?? BaseTypeName;

            if (IsClass && IsGeneric)
            {
                var generics = GenericArguments.Select(ga => ga.GetFullTypeName());
                result += $"<{string.Join(", ", generics)}>";
            }

            if (IsNullable)
                result = $"{result} | null";

            if (IsArray)
                result = result.Contains('|') ? $"({result})[]" : $"{result}[]";

            if (IsDictionary)
                result = $"Record<{DictionaryKey.BaseTypeName}, {result}>";

            return result;
        }

        public List<string> GetDeclaration(int indentationSize, bool export = false)
        {
            var result = new List<string>();
            var indentation = new string(' ', indentationSize);

            if (IsClass)
            {
                if (HasOverrides)
                    result.Add($"// Inheritance replaced with expanded items as some of them were overridden");

                var typeName = GetOpenGenericTypeName();
                var declarationHeader = $"{typeName}";

                if (HasParent && !HasOverrides)
                    declarationHeader += $" extends {Parent.GetFullTypeName()}";

                result.Add((export ? "export " : "") + $"interface {declarationHeader} {{");

                foreach (var property in Properties)
                    if (HasOverrides || !HasParent || !Parent.Properties.ContainsKey(property.Key))
                        result.Add(indentation + $"{property.Key.ToCamelCase()}: {property.Value.GetFullTypeName()};");

                if (result.Count == 1)
                    result[0] += $"}}";
                else
                    result.Add($"}}");
            }

            if (IsEnum)
            {
                result.Add((export ? "export " : "") + $"enum {BaseTypeName} {{");

                foreach (var value in Values)
                    result.Add(indentation + $"{value.Key} = {value.Value},");

                result.Add($"}}");
            }

            return result;
        }
    }
}
