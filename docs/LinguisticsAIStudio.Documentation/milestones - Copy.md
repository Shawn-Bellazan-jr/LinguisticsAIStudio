﻿## Building a Prompt Source Generator for AI Studio

Here's how we can approach building a source generator that caters to different prompt structures for AI Studio: 

**1. Defining Prompt Structures:**

We'll start by defining enums or classes to represent the different prompt structures you mentioned:

```csharp
public enum PromptStructure
{
    Freeform,
    Structured,
    Chat
}
```

**2. Prompt Attribute:**

Next, we'll create an attribute that developers can use to mark their classes as prompts and specify the structure:

```csharp
[AttributeUsage(AttributeTargets.Class)]
public class AIPromptAttribute : Attribute
{
    public PromptStructure Structure { get; set; }

    // Add more properties as needed for customization
    // e.g., public string Description { get; set; } 
}
```

**3. Source Generator Implementation:**

1.  **Project Setup:** Create a new C# Class Library project for the source generator. Install the necessary NuGet packages: `Microsoft.CodeAnalysis.CSharp` and `Microsoft.CodeAnalysis.Analyzers`.

2.  **Implement ISourceGenerator:**

    *   **Initialize Method:** (Optional) You can use this method for any initialization tasks, but it's not strictly required for this scenario.

    *   **Execute Method:**

        1.  **Get Target Classes:** Use the `context` to get all classes annotated with the `AIPromptAttribute`.

        2.  **Generate Code for Each Class:**

            *   **Extract Information:** Get the prompt structure from the attribute. You can also extract additional information if you've added more properties to the attribute.

            *   **Generate Code Based on Structure:**

                *   **Freeform:** Generate a simple class with properties representing the freeform text input.

                *   **Structured:** Generate a class with properties matching the expected structure of the prompt (e.g., separate properties for different sections of the prompt).

                *   **Chat:** Generate classes representing the different roles in a chat conversation (e.g., User, Assistant) with properties for their respective messages.

            *   **Add Source File:** Use `context.AddSource(...)` to add the generated class to the compilation.

**4. Example Usage:**

```csharp
[AIPrompt(Structure = PromptStructure.Freeform)]
public class FreeformPrompt
{
    public string Text { get; set; }
}

[AIPrompt(Structure = PromptStructure.Structured)]
public class StructuredPrompt
{
    public string Title { get; set; }
    public string Context { get; set; }
    public string Question { get; set; }
}
```

**5. Further Considerations:**

*   **Validation:** Add validation logic to the source generator to ensure that the prompt classes are defined correctly. 

*   **Customization:** 
    *   Allow developers to specify additional options within the attribute (e.g., temperature for text generation, model to use).
    *   Consider generating methods for interacting with AI Studio APIs directly from the generated classes.

*   **Error Handling:** Implement robust error handling during code generation.

**6. Integrating with AI Studio:**

*   The generated classes can be used in your Blazor application to collect prompt information from users.
*   Develop services that take these prompt objects, prepare the appropriate format for AI Studio API (based on the structure), and send the requests to AI Studio.
*   Process the results from AI Studio and display them in your Blazor application.

**Benefits:**

*   **Type Safety:** Ensures that prompts conform to the expected structure.
*   **Reduced Boilerplate:** Eliminates the need to manually create classes for different prompt types. 
*   **Improved Developer Experience:** Makes it easier and faster to develop applications using AI Studio. 

**Remember:** This is a high-level overview. The specific implementation details will depend on the exact requirements of your AI Studio integration and the desired level of customization.
﻿