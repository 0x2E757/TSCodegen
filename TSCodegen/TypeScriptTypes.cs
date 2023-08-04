using System;
using System.Collections.Generic;

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

        public void Add(TypeScriptType typeScriptType)
        {
            if (typeScriptType.HasDeclaration)
                foreach (var item in Items)
                    if (typeScriptType.BaseTypeName == item.BaseTypeName)
                    {
                        if (typeScriptType.CSharpType.Namespace != item.CSharpType.Namespace)
                            throw new Exception("Different types with same name are not allowed.");

                        return;
                    }

            foreach (var property in typeScriptType.Properties)
                if (!property.Value.CSharpType.IsGenericParameter)
                    Add(property.Value);

            foreach (var genericArgument in typeScriptType.GenericArguments)
                if (!genericArgument.CSharpType.IsGenericParameter)
                    Add(genericArgument);

            if (typeScriptType.HasParent)
                Add(typeScriptType.Parent);

            if (typeScriptType.HasElement)
                Add(typeScriptType.Element);

            if (typeScriptType.HasDeclaration)
            {
                if (ForbiddenNamespaces.Contains(typeScriptType.CSharpType.Namespace))
                    throw new Exception($"Namespace {typeScriptType.CSharpType.Namespace} entities are forbidden ({typeScriptType.CSharpType.Name})!");

                Items.Add(typeScriptType);
            }
        }

        public void Add(IEnumerable<TypeScriptType> typeScriptTypes)
        {
            foreach (var typeScriptType in typeScriptTypes)
                Add(typeScriptType);
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
