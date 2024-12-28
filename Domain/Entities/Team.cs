using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Team
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public int HackathonId { get; set; }
    public DateTime CreatedDate { get; set; }
    [MaxLength(50)]
    public string LeaderName{ get; set; }
    public int TotalMembers { get; set; }
    public int Score { get; set; }
    public TeamStatus Status { get; set; }
    public Hackathon Hackathon { get; set; }
    public List<Participant> Participants { get; set; }
}
