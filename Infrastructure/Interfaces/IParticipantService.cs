
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.ApiRespponce;

namespace Infrastructure.Interfaces;


public interface IParticipantService
{
    Task<Response<List<ReadParticipantDTO>>> GetAllParticipantsAsync();
    Task<Response<Participant>> GetParticipantByIdAsync(int id);
    Task<Response<string>> AddParticipantAsync(CreateParticipantDTO request);
    Task<Response<string>> UpdateParticipantAsync(UpdateParticipantDTO request);
    Task<Response<string>> DeleteParticipantAsync(int id);
}