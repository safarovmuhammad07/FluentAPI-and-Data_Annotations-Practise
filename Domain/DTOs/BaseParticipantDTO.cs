using Domain.Enums;

namespace Domain.DTOs;

public record BaseParticipantDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ParticipantRole Role { get; set; }
    public List<string> Skills { get; set; } = [];
    public ExperienceLevel  ExperienceLevel  { get; set; }
}

public record CreateParticipantDTO : BaseParticipantDTO
{
    public int TeamId { get; set; }  
}

public record UpdateParticipantDTO : BaseParticipantDTO
{
    public int Id{ get; set; }  
    
}

public record ReadParticipantDTO : BaseParticipantDTO
{
    public int Id { get; set; }
    public int TeamId { get; set; }
}