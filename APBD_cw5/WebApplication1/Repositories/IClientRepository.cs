namespace WebApplication1.Repositories;

public interface IClientRepository
{
    Task DeleteClientAsync(int idClient);
}