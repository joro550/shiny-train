namespace ProjectTrack.Domain.Tests;

public class ReleaseTests
{
    [Fact]
    public void CanSetName()
    {
        var project = new Release { Name = "Project 1" };
        Assert.Equal("Project 1", project.Name);
    }

    [Fact]
    public void CanSetId()
    {
        var project = new Release { Id = 1 };
        Assert.Equal(1, project.Id);
    }

    [Fact]
    public void CanSetProjectId()
    {
        var project = new Release { ProjectId = 1 };
        Assert.Equal(1, project.ProjectId);
    }
}