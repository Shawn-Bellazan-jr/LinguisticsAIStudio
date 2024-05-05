using System.Text.Json.Serialization;

namespace LinguisticsAIStudio.WebApp.Models
{
    public record ProjectDto(
        [property:JsonPropertyName("projectId")] string ProjectId, 
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("description")] string Description);
}
