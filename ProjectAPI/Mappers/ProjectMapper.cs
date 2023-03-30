using ProjectAPI.Contracts.Requests;
using ProjectAPI.Contracts.Responses;
using ProjectAPI.Entities;
using Riok.Mapperly.Abstractions;

namespace ProjectAPI.Mappers
{
    [Mapper]
    public partial class ProjectMapper
    {
        public partial GetProjectResponse MapProjectToResponse(Project entity);
        public partial Project MapRequestToProject(CreateProjectRequest request);

        [MapperIgnoreTarget(nameof(Project.Id))]
        public partial void MapRequestToProject(UpdateProjectRequest request, Project entity);
    }
}
