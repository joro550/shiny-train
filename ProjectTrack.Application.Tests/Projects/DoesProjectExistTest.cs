using MediatR;
using ProjectTrack.Application.Projects;
using ProjectTrack.Application.Tests.Common;
using ProjectTrack.Domain;

namespace ProjectTrack.Application.Tests.Projects;

public class DoesProjectExistTest
{
    private readonly ProjectExistHandler _handler;
    private readonly InMemoryRepository<Project> _repo;

    public DoesProjectExistTest()
    {
        _repo = new InMemoryRepository<Project>();
        _handler = new ProjectExistHandler(_repo);
    }

    [Fact]
    public void IsInstanceOfCorrectHandler() 
        => Assert.IsAssignableFrom<IRequestHandler<ProjectExistQuery, ProjectExistResponse>>(_handler);

    [Fact]
    public async Task WhenNoProjectExists_ThenFalseIsReturned()
    {
        var result = await _handler.Handle(new ProjectExistQuery(1), default);
        Assert.False(result.Result);
    }
    
    [Fact]
    public async Task WhenProjectExists_ThenTrueIsReturned()
    {
        var project = 
            await _repo.SaveAsync(new Project { Name = "Project 1"});
        
        var result = await _handler.Handle(new ProjectExistQuery(project.Id), default);
        Assert.True(result.Result);
    }
}
