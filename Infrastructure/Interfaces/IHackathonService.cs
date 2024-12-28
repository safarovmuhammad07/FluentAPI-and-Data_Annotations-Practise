
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiRespponce;

namespace Infrastructure.Interfaces;

public interface IHackathonService
{
    Task<Response<List<ReadHackathonDto>>> GetAllHackathonsAsync();
    Task<Response<Hackathon>> GetHackathonByIdAsync(int id);
    Task<Response<string>> AddHackathonAsync(CreateHackathonDto request);
    Task<Response<string>> UpdateHackathonAsync(UpdateHackathonDto request);
    Task<Response<string>> DeleteHackathonAsync(int id);
}