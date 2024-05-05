using LinguisticsAIStudio.WebApp.Models;
using Refit;

namespace LinguisticsAIStudio.WebApp.APIs
{
    public interface IProjectAPI
    {
        [Headers("Content-Type: application/json")]
        [Get("/data/projects.json")]
        Task<List<Project>> GetProjectsAsync();


        [Headers("Content-Type: application/json")]
        [Post("/data/projects.json")]
        Task<ProjectDto> CreateProjectAsync([Body] ProjectDto project);

    }
}
