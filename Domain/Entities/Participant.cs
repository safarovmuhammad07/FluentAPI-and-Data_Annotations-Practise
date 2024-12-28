using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Participant
{
    [Key]
    public int Id { get; set; }
    [MaxLength(45)]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
    public ParticipantRole Role { get; set; }
    public List<string> Skills { get; set; } = [];
    public ExperienceLevel  ExperienceLevel  { get; set; }
    public DateTime JoinDate { get; set; }
    public int TeamId { get; set; }  
    [ForeignKey("TeamId")]
    public Team Team { get; set; }
    
}