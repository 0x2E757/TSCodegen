using System;

namespace TSCodegen.Exceptions
{
    public class ForbiddenNamespaceException : Exception
    {
        public TypeScriptType TypeScriptType { get; }

        public ForbiddenNamespaceException(string message)
            : base(message)
        {
            TypeScriptType = null;
        }

        public ForbiddenNamespaceException(string message, Exception inner)
            : base(message, inner)
        {
            TypeScriptType = null;
        }

        public ForbiddenNamespaceException(TypeScriptType typeScriptType)
            : base($"Namespace {typeScriptType.CSharpType.Namespace} entities are forbidden ({typeScriptType.CSharpType.Name}).")
        {
            TypeScriptType = typeScriptType;
        }

        public ForbiddenNamespaceException(TypeScriptType typeScriptType, Exception inner)
            : base($"Namespace {typeScriptType.CSharpType.Namespace} entities are forbidden ({typeScriptType.CSharpType.Name}).", inner)
        {
            TypeScriptType = typeScriptType;
        }
    }
}
