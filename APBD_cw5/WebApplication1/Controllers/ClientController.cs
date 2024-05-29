using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;
[Route("api/clients")]
[ApiController]
public class ClientController: ControllerBase
{
    private readonly IClientRepository _repository;

    public ClientController(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> DeleteClient([FromRoute] int idClient)
    {
        try
        {
            await _repository.DeleteClientAsync(idClient);
            return Ok("Client with ID " + idClient + "deleted");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }
}