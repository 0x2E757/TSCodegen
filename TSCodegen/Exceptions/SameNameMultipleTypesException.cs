using System;

namespace TSCodegen.Exceptions
{
    public class SameNameMultipleTypesException : Exception
    {
        public TypeScriptType TypeScriptType { get; }

        public SameNameMultipleTypesException(string message)
            : base(message)
        {
            TypeScriptType = null;
        }

        public SameNameMultipleTypesException(string message, Exception inner)
            : base(message, inner)
        {
            TypeScriptType = null;
        }

        public SameNameMultipleTypesException()
            : base("Different types with same name are not allowed.")
        {
            TypeScriptType = null;
        }

        public SameNameMultipleTypesException(Exception inner)
            : base("Different types with same name are not allowed.", inner)
        {
            TypeScriptType = null;
        }

        public SameNameMultipleTypesException(TypeScriptType typeScriptType)
            : base($"Different types with same name ({typeScriptType.CSharpType.Name}) are not allowed.")
        {
            TypeScriptType = typeScriptType;
        }

        public SameNameMultipleTypesException(TypeScriptType typeScriptType, Exception inner)
            : base($"Different types with same name ({typeScriptType.CSharpType.Name}) are not allowed.", inner)
        {
            TypeScriptType = typeScriptType;
        }
    }
}
