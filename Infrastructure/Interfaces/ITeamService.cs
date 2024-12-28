using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiRespponce;

namespace Infrastructure.Interfaces;
public interface ITeamService

{
    Task<Response<List<ReadTeamDto>>> GetAllTeamsAsync();
    Task<Response<Team>> GetTeamByIdAsync(int id);
    Task<Response<string>> AddTeamAsync(CreateTeamDto request);
    Task<Response<string>> UpdateTeamAsync(UpdateTeamDto request);
    Task<Response<string>> DeleteTeamAsync(int id);
}