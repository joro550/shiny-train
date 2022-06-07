using LiteDB.Async;
using ProjectTrack.Domain;

namespace ProjectTrack.Infrastructure.Tests;

public class RepositoryTests : IAsyncLifetime
{
    private Repository<Project> _repo = null!;
    private LiteDatabaseAsync _database = null!;
    private ILiteCollectionAsync<Project> _projectCollection = null!;

    [Fact]
    public async Task CanSaveEntity()
    {
        var result = await _repo.SaveAsync(new Project{ Name = "Project 1"});
        var queryResponse = await _projectCollection.Query()
            .Where(p => p.Id == result.Id)
            .ToListAsync();

        Assert.NotEmpty(queryResponse);
    }

    [Fact]
    public async Task CanGetEntityById()
    {
        var project = new Project { Name = "Project 2" };
        await _projectCollection.InsertAsync(project);

        var entity = await _repo.GetById(project.Id);
        
        Assert.NotNull(entity);
        Assert.Equal(project.Name, entity.Name);
    }

    [Fact]
    public async Task CanGetAllRecords()
    {
        const int amountOfRecords = 10;
        for (var i = 0; i < amountOfRecords; i++)
        {
            await _projectCollection.InsertAsync(
                new Project
                {
                    Name = $"Project {i}"
                });
        }

        var projects = await _repo.GetListAsync();
        Assert.NotEmpty(projects);
        Assert.Equal(amountOfRecords, projects.Count);
    }

    public Task InitializeAsync()
    {
        _database = new LiteDatabaseAsync("RepositoryTests.db");
        _repo = new Repository<Project>(_database);
        _projectCollection = _database.GetCollection<Project>(nameof(Project));
        
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await _database.GetCollection(nameof(Project)).DeleteAllAsync();
        _database.Dispose();
    }
}