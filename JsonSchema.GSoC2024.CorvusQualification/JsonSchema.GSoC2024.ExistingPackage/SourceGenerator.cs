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
public class GeneratedAttribute : Attribute
{
    public string SchemaPath { get; }
    public string Namespace { get; }

    public GeneratedAttribute(string schemaPath, string @namespace)
    {
        SchemaPath = schemaPath;
        Namespace = @namespace;
    }
    
}
";
                ctx.AddSource("GeneratedAttribute.g", SourceText.From(sourceText, Encoding.UTF8));
            });
        }
    }

}
