using Project001.Domain.Entities;

namespace Project001.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task CreateAsync(Contato entity);
        Task UpdateAsync(Contato entity);
        Task DeleteAsync(Contato entity);

        Task<Contato?> GetByIdAsync(Guid id);
        Task<Contato?> GetByEmailAsync(string? email);
        Task<Contato?> GetByPhoneAsync(string? phone);

        Task<List<Contato>> GetAllAsync(int page, int limit);
    }
}
