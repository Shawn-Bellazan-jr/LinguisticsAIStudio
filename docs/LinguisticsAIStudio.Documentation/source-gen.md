
﻿## Building the AIPromptAttribute and Source Generator

Here's how you can create the `AIPromptAttribute` and a basic source generator to work with it:

**1. AIPromptAttribute:**

```csharp
[AttributeUsage(AttributeTargets.Class)]
public class AIPromptAttribute : Attribute
{
    public PromptStructure Structure { get; set; }

    // Add more properties as needed for customization
    // e.g., public string Description { get; set; } 
}

public enum PromptStructure
{
    TextToText,
    TextToCode,
    // Add more structures as needed
}
```

This attribute will be used to decorate classes that represent different AI prompt structures. 

**2. Source Generator:**

```csharp
[Generator]
public class AIPromptGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context) { }

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
            if (structure == "PromptStructure.TextToText")
            {
                var generatedCode = $@"
public partial class {promptClass.Identifier.Text}
{{
    // Add properties and methods specific to TextToText prompts
}}
";
                context.AddSource($"{promptClass.Identifier.Text}.g.cs", generatedCode);
            } 
            // Add more cases for other PromptStructures
        }
    }
}
```

This source generator will find classes with the `AIPromptAttribute` and generate additional code within those classes based on the specified `PromptStructure`.

**3. Example Usage:**

```csharp
[AIPrompt(Structure = PromptStructure.TextToText)]
public partial class SummarizationPrompt 
{
    public string Text { get; set; } 
    public int Length { get; set; }
}

// After source generation:
public partial class SummarizationPrompt
{
    // ... (Generated properties and methods for TextToText prompts) 
}
```

**4. Further Development:**

*   **Specific Code Generation:** Implement code generation logic for each `PromptStructure`, including properties, methods, and API interaction methods as needed. 
*   **Validation:** Add logic to validate the prompt classes (e.g., ensure required properties exist). 
*   **Customization Options:** Allow developers to provide additional information through the attribute to customize the generated code further. 
*   **Integration with AI Studio Services:**  Develop services that utilize the generated prompt classes to interact with AI Studio APIs effectively.

**5. Additional Considerations:**

*   **Error Handling:** Implement proper error handling during code generation to provide informative messages to developers.
*   **Testing:** Create unit tests to ensure the source generator is working as expected and generating correct code.
*   **Documentation:** Provide clear documentation for developers on how to use the `AIPromptAttribute` and the generated code effectively.

This example provides a basic framework for building a source generator for AI prompts. You can expand upon this foundation to create a robust and flexible solution for your AI development needs.
﻿