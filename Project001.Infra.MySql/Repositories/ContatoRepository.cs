using Project001.Domain.Entities;
using Project001.Domain.Interfaces;
using Project001.Infra.MySql.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Project001.Infra.MySql.Repositories
{
    public class ContatoRepository
        : BaseRepository<Contato, Guid>, IContatoRepository
    {
        private readonly MySqlContext _context;

        public ContatoRepository(MySqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Contato?> GetByEmailAsync(string? email)
        {
            return await _context.Contatos
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Contato?> GetByPhoneAsync(string? phone)
        {
            return await _context.Contatos
                .FirstOrDefaultAsync(c => c.Phone == phone);
        }
    }
}
