using MediatR;
using ProjectTrack.Domain;
using ProjectTrack.Application.Projects;
using ProjectTrack.Application.Tests.Common;

namespace ProjectTrack.Application.Tests.Projects;

public class CreateProjectTests
{
    private readonly CreateProjectHandler _handler;
    private readonly InMemoryRepository<Project> _repo;


    public CreateProjectTests()
    {
        _repo = new InMemoryRepository<Project>();
        _handler = new CreateProjectHandler(_repo);
    }

    [Fact]
    public void TestClass() 
        => Assert.IsAssignableFrom<INotificationHandler<CreateProject>>(_handler);

    [Fact]
    public async Task ProjectIsSaved()
    {
        var notification = new CreateProject("Project 1");
        await _handler.Handle(notification, default);

        var projects = await _repo.GetListAsync();
        Assert.NotEmpty(projects);
    }
}