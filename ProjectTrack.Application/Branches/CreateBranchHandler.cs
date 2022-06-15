using MediatR;
using ProjectTrack.Domain;
using ProjectTrack.Application.Common.Interfaces;
using ProjectTrack.Application.Projects;

namespace ProjectTrack.Application.Branches;

public record CreateBranch(string Name, int ProjectId)
    : IRequest<CreateBranchResponse>;

public record CreateBranchResponse(bool Created);

public class CreateBranchHandler
    : IRequestHandler<CreateBranch, CreateBranchResponse>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Branch> _repo;

    public CreateBranchHandler(IRepository<Branch> repo, 
        IMediator mediator)
    {
        _repo = repo;
        _mediator = mediator;
    }

    public async Task<CreateBranchResponse> Handle(CreateBranch notification, CancellationToken cancellationToken)
    {
        var project = await _mediator.Send(new ProjectExistQuery(notification.ProjectId), cancellationToken);
        if (!project.Result)
            return new CreateBranchResponse(false);

        await _repo.SaveAsync(new Branch { Name = notification.Name });
        return new CreateBranchResponse(true);
    }
}