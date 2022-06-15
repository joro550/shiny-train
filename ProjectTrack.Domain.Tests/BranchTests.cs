namespace ProjectTrack.Domain.Tests;

public class BranchTests
{
    [Fact]
    public void CanSetName()
    {
        var project = new Branch { Name = "Project 1" };
        Assert.Equal("Project 1", project.Name);
    }

    [Fact]
    public void CanSetId()
    {
        var project = new Branch { Id = 1 };
        Assert.Equal(1, project.Id);
    }

    [Fact]
    public void CanSetProjectId()
    {
        var project = new Branch { ProjectId = 1 };
        Assert.Equal(1, project.ProjectId);
    }
}