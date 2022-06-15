using MediatR;
using NSubstitute;
using ProjectTrack.Application.Branches;
using ProjectTrack.Application.Projects;
using ProjectTrack.Application.Tests.Common;
using ProjectTrack.Domain;

namespace ProjectTrack.Application.Tests.Branches;

public class CreateBranchHandlerTests
{
    private IMediator _mediator;
    private readonly CreateBranchHandler _handler;
    private readonly InMemoryRepository<Branch> _repo;

    public CreateBranchHandlerTests()
    {
        _mediator = Substitute.For<IMediator>();;
        _repo = new InMemoryRepository<Branch>();
        _handler = new CreateBranchHandler(_repo, _mediator);
    }

    [Fact]
    public void IsInstanceOfCorrectHandler() 
        => Assert.IsAssignableFrom<IRequestHandler<CreateBranch, CreateBranchResponse>>(_handler);

    [Fact]
    public async Task WhenProjectDoesNotExist_ThenBranchIsNotCreated()
    {
        var  result = await _handler.Handle(new CreateBranch("Branch 1", 1), default);
        Assert.False(result.Created);
    }
    
    [Fact]
    public async Task WhenProjectDoestExist_ThenBranchIsCreated()
    {
        _mediator.Send(new ProjectExistQuery(1))
            .Returns(new ProjectExistResponse(true));
        
        var  result = await _handler.Handle(new CreateBranch("Branch 1", 1), default);

        var branches = await _repo.GetListAsync();
        var branch = branches.FirstOrDefault(); 
        
        Assert.True(result.Created);
        Assert.NotNull(branch);
        Assert.Equal("Branch 1", branch.Name);
    }
}