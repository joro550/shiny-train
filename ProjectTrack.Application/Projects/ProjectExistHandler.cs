using MediatR;
using ProjectTrack.Application.Common.Interfaces;
using ProjectTrack.Domain;

namespace ProjectTrack.Application.Projects;

public record ProjectExistQuery(int Id) 
    : IRequest<ProjectExistResponse>;

public record ProjectExistResponse(bool Result);

public class ProjectExistHandler
    : IRequestHandler<ProjectExistQuery, ProjectExistResponse>
{
    private readonly IRepository<Project> _repo;

    public ProjectExistHandler(IRepository<Project> repo) 
        => _repo = repo;

    public async Task<ProjectExistResponse> Handle(ProjectExistQuery request, CancellationToken cancellationToken)
    {
        var result = await _repo.GetById(request.Id);
        return new ProjectExistResponse(result != null);
    }
}