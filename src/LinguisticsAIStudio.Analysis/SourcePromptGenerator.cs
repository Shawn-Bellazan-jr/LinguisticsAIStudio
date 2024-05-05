using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAIStudio.Analysis
{
    public class SourcePromptGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // Get all classes with the AIPromptAttribute
            var promptClasses = context.
                .SelectMany(tree => tree.GetRoot().DescendantNodes())
                .OfType<ClassDeclarationSyntax>()
                .Where(cds => cds.AttributeLists
                    .SelectMany(al => al.Attributes)
                    .Any(a => a.Name.ToString() == "AIPrompt"))
                .ToList();
        }
    }
}
