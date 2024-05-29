using WebApplication1.Models.DTO;

namespace WebApplication1.Repositories;

public interface ITripRepository
{
    Task<IEnumerable<TripGetDTO>> GetTripsAsync();
    Task AssignTripToClientAsync(int idTrip, AssignClientToTripDTO dto);
}