using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTO;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;
[Route("api/trips")]
[ApiController]
public class TripController
{
    private readonly ITripRepository _repository;

    public TripController(ITripRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AddTripToClient([FromRoute] int idTrip, [FromBody] AssignClientToTripDTO dto)
    {
        throw new NotImplementedException();
}
        
}