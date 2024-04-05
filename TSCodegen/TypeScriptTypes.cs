using System.Collections.Generic;
using TSCodegen.Exceptions;

namespace TSCodegen
{
    public class TypeScriptTypes
    {
        public List<TypeScriptType> Items { get; } = new List<TypeScriptType>();
        public List<string> ForbiddenNamespaces { get; } = new List<string>();

        public TypeScriptTypes(List<string> forbiddenNamespaces = null)
        {
            if (forbiddenNamespaces != null)
                ForbiddenNamespaces.AddRange(forbiddenNamespaces);
        }

        public void Add(TypeScriptType typeScriptType, bool suppressErrors = false)
        {
            var typeIsPresent = false;

            if (typeScriptType.HasDeclaration)
                foreach (var item in Items)
                    if (typeScriptType.BaseTypeName == item.BaseTypeName)
                    {
                        if (typeScriptType.CSharpType.Namespace != item.CSharpType.Namespace)
                            throw new SameNameMultipleTypesException(typeScriptType.CSharpType.Name);

                        typeIsPresent = true;
                        break;
                    }

            foreach (var property in typeScriptType.Properties)
                if (!property.Value.CSharpType.IsGenericParameter)
                    Add(property.Value, suppressErrors);

            foreach (var genericArgument in typeScriptType.GenericArguments)
                if (!genericArgument.CSharpType.IsGenericParameter)
                    Add(genericArgument, suppressErrors);

            if (typeScriptType.HasParent)
                Add(typeScriptType.Parent, suppressErrors);

            if (typeScriptType.HasElement)
                if (!typeScriptType.Element.CSharpType.IsGenericParameter)
                    Add(typeScriptType.Element, suppressErrors);

            if (typeScriptType.HasDeclaration)
            {
                if (!suppressErrors && ForbiddenNamespaces.Contains(typeScriptType.CSharpType.Namespace))
                    throw new ForbiddenNamespaceException(typeScriptType);

                if (!typeIsPresent)
                    Items.Add(typeScriptType);
            }
        }

        public void Add(IEnumerable<TypeScriptType> typeScriptTypes, bool suppressErrors = false)
        {
            foreach (var typeScriptType in typeScriptTypes)
                Add(typeScriptType, suppressErrors);
        }

        public List<string> GetDeclarations(int indentationSize, bool export = false)
        {
            var result = new List<string>();

            for (int n = 0; n < Items.Count; n++)
            {
                var item = Items[n];
                result.AddRange(item.GetDeclaration(indentationSize, export));

                if (n < Items.Count - 1)
                    result.Add("");
            }

            return result;
        }
    }
}
