using WebApplication1.Models.DTO;

namespace WebApplication1.Repositories;

public class TripRepository : ITripRepository
{
    public async Task<IEnumerable<TripGetDTO>> GetTripsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AssignTripToClientAsync(int idTrip, AssignClientToTripDTO dto)
    {
        throw new NotImplementedException();
    }
}