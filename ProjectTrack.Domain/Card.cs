using ProjectTrack.Domain.Common;

namespace ProjectTrack.Domain;

public class Card : BaseEntity
{
    public int ProjectId { get; set; } 
    public int BranchId { get; set; }
    public string Name { get; set; } = string.Empty;
}