using Project001.Domain.Entities;
using Project001.Domain.Interfaces;
using Project001.Infra.SqlServer.Contexts;

namespace Project001.Infra.SqlServer.Repositories
{
    public class ContatoRepository
        : BaseRepository<Contato, Guid>, IContatoRepository
    {
        private readonly SqlServerContext _sqlServerContext;


        public ContatoRepository(SqlServerContext sqlServerContext) 
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Contato GetByEmail(string email)
        => _sqlServerContext.Contatos
            .FirstOrDefault(c => c.Email.Equals(email));

        public Contato GetByPhone(Guid id)
        {
            throw new NotImplementedException();
        }

        public Contato GetPhone(string phone)
        => _sqlServerContext.Contatos
            .FirstOrDefault(c => c.Phone.Equals(phone));

        Contato IContatoRepository.GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        Contato IContatoRepository.GetPhone(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
