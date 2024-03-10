using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSchema.GSoC2024.ExistingLibrary
{
    [Generator]
    public class SourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx =>
            {
                var sourceText = @"using System;

[AttributeUsage(AttributeTargets.Assembly)]
public class GeneratedAttributeAttribute : Attribute
{
    public string SchemaPath { get; }
    public string Namespace { get; }

    public GeneratedAttributeAttribute(string schemaPath, string @namespace)
    {
        SchemaPath = schemaPath;
        Namespace = @namespace;
    }
    
}
";
                ctx.AddSource("GeneratedAttributeAttribute", SourceText.From(sourceText, Encoding.UTF8));
            });
        }
    }

}
