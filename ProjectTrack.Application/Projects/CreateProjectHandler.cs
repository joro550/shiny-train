using MediatR;
using ProjectTrack.Domain;
using ProjectTrack.Application.Common.Interfaces;

namespace ProjectTrack.Application.Projects;

public record CreateProject(string Name)
    : INotification;

public class CreateProjectHandler : INotificationHandler<CreateProject>
{
    private readonly IRepository<Project> _repo;

    public CreateProjectHandler(IRepository<Project> repo) 
        => _repo = repo;

    public async Task Handle(CreateProject notification, CancellationToken cancellationToken) 
        => await _repo.SaveAsync(new Project { Name = notification.Name });
}

