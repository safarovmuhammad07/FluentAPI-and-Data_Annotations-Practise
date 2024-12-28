using System.Net;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiRespponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeamService(Context context): ITeamService
{
    public async Task<Response<List<ReadTeamDto>>> GetAllTeamsAsync()
    {
        var teams =await context.Teams
            .ToListAsync();
        var TeamDtos = teams.Select(t => new ReadTeamDto()
        {
            Id = t.Id,
            Name = t.Name,
            LeaderName = t.LeaderName,
            TotalMembers = t.TotalMembers,
            HackathonId = t.HackathonId,
            Score = t.Score,
            Status = t.Status,
            Participants = t.Participants,
            
        }).ToList();
        return new Response<List<ReadTeamDto>>(TeamDtos.ToList());
    }

    public async Task<Response<Team>> GetTeamByIdAsync(int id)
    {
        var team= await context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        return team == null
            ? new Response<Team>(HttpStatusCode.NotFound, "Course not found")
            : new Response<Team>(team);
    }

    public async Task<Response<string>> AddTeamAsync(CreateTeamDto request)
    {
        var team = new Team()
        {
            Name = request.Name,
            HackathonId = request.HackathonId,
        };
        await context.Teams.AddAsync(team);
        var result = await context.SaveChangesAsync();
         return result==0
             ? new Response<string>(HttpStatusCode.InternalServerError, "Internal server error")
             : new Response<string>(HttpStatusCode.Created, "Team created successfully");
    }

    public async Task<Response<string>> UpdateTeamAsync(UpdateTeamDto request)
    {
        var existingTeam = await context.Teams.FirstOrDefaultAsync(t => t.Id == request.Id);
        if (existingTeam == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        }
        existingTeam.Id = request.Id;
        existingTeam.Name = request.Name;
        existingTeam.LeaderName = request.LeaderName;
        existingTeam.TotalMembers = request.TotalMembers;
        existingTeam.Score = request.Score;
        existingTeam.Status = request.Status;
        context.Teams.Update(existingTeam);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<string>(HttpStatusCode.OK, "Team updated successfully");
    }

    public async Task<Response<string>> DeleteTeamAsync(int id)
    {
        var existingTeam = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (existingTeam == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        }
        context.Teams.Remove(existingTeam);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<string>(HttpStatusCode.OK, "Team deleted successfully");
    }
}