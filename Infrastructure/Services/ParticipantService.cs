using System.Net;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiRespponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService(Context context): IParticipantService
{
   public async Task<Response<List<ReadParticipantDTO>>> GetAllParticipantsAsync()
    {
        var participants =await context.Participants
            .ToListAsync();
        var participantDtos = participants.Select(t => new ReadParticipantDTO()
        {
            Id = t.Id,
            Name = t.Name,
            Email = t.Email,
            Phone = t.Phone,
            Role = t.Role,
            Skills = t.Skills,
            ExperienceLevel = t.ExperienceLevel,
            TeamId = t.TeamId
            
            
            
        }).ToList();
        return new Response<List<ReadParticipantDTO>>(participantDtos);
    }

    public async Task<Response<Participant>> GetParticipantByIdAsync(int id)
    {
        var participant= await context.Participants.FirstOrDefaultAsync(t => t.Id == id);
        return participant == null
            ? new Response<Participant>(HttpStatusCode.NotFound, "Participent not found")
            : new Response<Participant>(participant);
    }

    public async Task<Response<string>> AddParticipantAsync(CreateParticipantDTO request)
    {
        var participant = new Participant()
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Role = request.Role,
            Skills = request.Skills,
            ExperienceLevel = request.ExperienceLevel,
            TeamId = request.TeamId
            
        };
        await context.Participants.AddAsync(participant);
        var result = await context.SaveChangesAsync();
         return result==0
             ? new Response<string>(HttpStatusCode.InternalServerError, "Internal server error")
             : new Response<string>(HttpStatusCode.Created, "Participant created successfully");
    }

    public async Task<Response<string>> UpdateParticipantAsync(UpdateParticipantDTO request)
    {
        var existingParticipant = await context.Participants.FirstOrDefaultAsync(t => t.Id == request.Id);
        if (existingParticipant == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        }
        existingParticipant.Id = request.Id;
        existingParticipant.Name = request.Name;
        existingParticipant.Email = request.Email;
        existingParticipant.Phone = request.Phone;
        existingParticipant.Skills = request.Skills;
        existingParticipant.Role = request.Role;
        existingParticipant.ExperienceLevel = request.ExperienceLevel;
        context.Participants.Update(existingParticipant);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<string>(HttpStatusCode.OK, "Participant updated successfully");
    }

    public async Task<Response<string>> DeleteParticipantAsync(int id)
    {
        var existingParticipant = await context.Participants.FirstOrDefaultAsync(t => t.Id == id);
        if (existingParticipant == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        }
        context.Participants.Remove(existingParticipant);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<string>(HttpStatusCode.OK, "Participant deleted successfully");
    }
}