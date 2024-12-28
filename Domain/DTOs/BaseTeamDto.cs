using Domain.Entities;
using Domain.Enums;

namespace Domain.DTOs;

public record BaseTeamDto
{
    public string Name { get; set; }
    public string LeaderName{ get; set; }
    public int TotalMembers { get; set; }
}

public record CreateTeamDto : BaseTeamDto
{
    public int HackathonId { get; set; }
}

public record UpdateTeamDto : BaseTeamDto
{
    public int Id{ get; set; }
    public int Score { get; set; }
    public TeamStatus Status { get; set; }
}

public record ReadTeamDto : BaseTeamDto
{
    public int Id { get; set; }
    public int HackathonId { get; set; }
    public int Score { get; set; }
    public TeamStatus Status { get; set; }
    public List<Participant> Participants { get; set; }
}
