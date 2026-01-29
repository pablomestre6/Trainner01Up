using Project001.Domain.Entities;
using Project001.Domain.Interfaces;

namespace Project001.Domain.Services
{
    public class ContatoDomainServices : IContatoDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContatoDomainServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork 
                ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task CreateAsync(Contato entity)
        {
            var contatoByEmail =
                await _unitOfWork.ContatoRepository.GetByEmailAsync(entity.Email);

            if (contatoByEmail != null)
                throw new ArgumentException("O email informado já está cadastrado");

           
            var contatoByPhone =
                await _unitOfWork.ContatoRepository.GetByPhoneAsync(entity.Phone);

            if (contatoByPhone != null)
                throw new ArgumentException("O telefone informado já está cadastrado");

            await _unitOfWork.ContatoRepository.CreateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Contato entity)
        {
            var contatoAtual =
                await _unitOfWork.ContatoRepository.GetByIdAsync(entity.Id);

            if (contatoAtual == null)
                throw new ArgumentException("Contato não encontrado");

            var contatoByEmail =
                await _unitOfWork.ContatoRepository.GetByEmailAsync(entity.Email);

            if (contatoByEmail != null && contatoByEmail.Id != entity.Id)
                throw new ArgumentException("O email já pertence a outro contato");

            var contatoByPhone =
                await _unitOfWork.ContatoRepository.GetByPhoneAsync(entity.Phone);

            if (contatoByPhone != null && contatoByPhone.Id != entity.Id)
                throw new ArgumentException("O telefone já pertence a outro contato");

            await _unitOfWork.ContatoRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Contato>> GetAllAsync(int page, int limit)
        {
            if (limit > 250)
                throw new ArgumentException("Limite máximo é 250");

            return await _unitOfWork.ContatoRepository.GetAllAsync(page, limit);
        }

        public async Task<Contato?> GetByIdAsync(Guid id)
            => await _unitOfWork.ContatoRepository.GetByIdAsync(id);

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
