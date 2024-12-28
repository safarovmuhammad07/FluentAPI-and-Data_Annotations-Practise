using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Hackathon
{
    
    [Key]
    public int Id { get; set; }
    [MaxLength(45)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    [MaxLength(75)]
    public string Theme { get; set; }
    public string Location  { get; set; }
    public int MaxTeams { get; set; }
    [MaxLength(145)]
    public string Description{ get; set; }
    public List<Team> Teams { get; set; }
    
}
