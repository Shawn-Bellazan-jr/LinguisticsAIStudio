using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAIStudio.WebApp
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AIPromptAttribute : Attribute
    {
        public PromptStructure Structure { get; set; }

        // Add more properties as needed for customization
        // e.g., public string Description { get; set; } 
    }
}
