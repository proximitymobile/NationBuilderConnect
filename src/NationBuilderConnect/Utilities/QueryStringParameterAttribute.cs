using System;

namespace NationBuilderConnect.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class QueryStringParameterAttribute : Attribute
    {
        public QueryStringParameterAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}