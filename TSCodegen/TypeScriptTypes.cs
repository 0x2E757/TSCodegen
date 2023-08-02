using System;
using System.Collections.Generic;

namespace TSCodegen
{
    public class TypeScriptTypes
    {
        public List<TypeScriptType> Items { get; } = new List<TypeScriptType>();

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
                Items.Add(typeScriptType);
        }

        public void Add(IEnumerable<TypeScriptType> typeScriptTypes)
        {
            foreach (var typeScriptType in typeScriptTypes)
                Add(typeScriptType);
        }

        public List<string> GetDeclarations(int indentitationSize, bool export = false)
        {
            var result = new List<string>();

            for (int n = 0; n < Items.Count; n++)
            {
                var item = Items[n];
                result.AddRange(item.GetDeclaration(indentitationSize, export));

                if (n < Items.Count - 1)
                    result.Add("");
            }

            return result;
        }
    }
}
