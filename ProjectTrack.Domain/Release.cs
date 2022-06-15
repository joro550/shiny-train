using ProjectTrack.Domain.Common;

namespace ProjectTrack.Domain;

public class Release : BaseEntity
{
    public int ProjectId { get; set; }   
    public string Name { get; set; } = string.Empty;
}