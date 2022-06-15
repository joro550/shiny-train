namespace ProjectTrack.Domain.Tests;

public class ProjectTests
{
    [Fact]
    public void CanSetName()
    {
        var project = new Project { Name = "Project 1" };
        Assert.Equal("Project 1", project.Name);
    }

    [Fact]
    public void CanSetId()
    {
        var project = new Project { Id = 1 };
        Assert.Equal(1, project.Id);
    }
}