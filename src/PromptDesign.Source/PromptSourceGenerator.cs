using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromptDesign.Source
{
    [Generator]
    public class PromptSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            // Get all classes with the AIPromptAttribute
            var promptClasses = context.Compilation.SyntaxTrees
                .SelectMany(tree => tree.GetRoot().DescendantNodes())
                .OfType<ClassDeclarationSyntax>()
                .Where(cds => cds.AttributeLists
                    .SelectMany(al => al.Attributes)
                    .Any(a => a.Name.ToString() == "AIPrompt"))
                .ToList();

            foreach (var promptClass in promptClasses)
            {
                // Get the PromptStructure from the attribute
                var structure = promptClass.AttributeLists
                    .SelectMany(al => al.Attributes)
                    .First(a => a.Name.ToString() == "AIPrompt")
                    .ArgumentList.Arguments[0].ToString();

                // Generate code based on the structure (example for TextToText)
                if (structure == "PromptStructure.Freeform")
                {
                    var generatedCode = $@"
public partial class {promptClass.Identifier.Text}
{{
    // Add properties and methods specific to Freeform prompts
    public string Text {{ get; set; }}

}}
";
                    context.AddSource($"{promptClass.Identifier.Text}.g.cs", generatedCode);
                }
            }

        }

        public void Initialize(GeneratorInitializationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
