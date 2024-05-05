using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LinguisticsAIStudio.WebApp.Models
{
    [JsonSerializable(typeof(Project))]
    public class Project
    {
        [JsonProperty(PropertyName = "projectId")]
        public string? ProjectId { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string? Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }
        public Project()
        {
            
        }
        public Project(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
