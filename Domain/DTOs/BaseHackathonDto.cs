using Domain.Entities;

namespace Domain.DTOs;

public record BaseHackathonDto
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Theme { get; set; }
    public string Location  { get; set; }
    public int MaxTeams { get; set; }
    public string Description{ get; set; }

}


public record CreateHackathonDto : BaseHackathonDto{}

public record UpdateHackathonDto : BaseHackathonDto
{
    public int Id{ get; set; }
}

public record ReadHackathonDto : BaseHackathonDto
{
    public int Id { get; set; }
    public List<Team> Teams { get; set; }
}