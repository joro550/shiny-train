namespace ProjectTrack.Domain.Tests;

public class CardTests
{
    [Fact]
    public void CanSetName()
    {
        var project = new Card { Name = "Project 1" };
        Assert.Equal("Project 1", project.Name);
    }

    [Fact]
    public void CanSetId()
    {
        var project = new Card { Id = 1 };
        Assert.Equal(1, project.Id);
    }

    [Fact]
    public void CanSetProjectId()
    {
        var project = new Card { ProjectId = 1 };
        Assert.Equal(1, project.ProjectId);
    }

    [Fact]
    public void CanSetReleaseId()
    {
        var project = new Card { BranchId = 1 };
        Assert.Equal(1, project.BranchId);
    }
}