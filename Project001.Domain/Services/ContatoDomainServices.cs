using Project001.Domain.Entities;
using Project001.Domain.Interfaces;

namespace Project001.Domain.Services
{
    public class ContatoDomainServices : IContatoDomainService
    {
        private readonly IUnitOfWork _unitOfWork;



        //Construtor de serviço para a Independencia
        public ContatoDomainServices(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Contato entity)
        {
            #region O email do contato deve ser unico

            if (_unitOfWork.ContatoRepository.GetByEmail
                (entity.Email) != null)
                throw new ArgumentException("O email informado");


            #endregion

            #region O telefone unico

            if (_unitOfWork.ContatoRepository.GetByPhone
                (entity.Phone) != null)
                throw new ArgumentException("O telefone informado já cadastrado");

            #endregion

            await _unitOfWork.ContatoRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Contato entity)
        {
            #region Conato deve existir no banco de dados

            if (await _unitOfWork.ContatoRepository.GetByIdAsync
                (entity.Id) == null)
                throw new ArgumentException("Contato nao encontrado verifique seu id");

            #endregion

            #region

            var contatoByEmail = _unitOfWork
                .ContatoRepository.GetByEmail(entity.Email);
            if (contatoByEmail != null
                && !contatoByEmail.Id.Equals(entity.Id))
                throw new ArgumentException(" O email informado já pertence á outro contato cadastro.");

            #endregion

            #region  O email atualizado nao pode ser igual ao outro

            var contatoByPhone = _unitOfWork.ContatoRepository
                .GetByPhone(entity.Phone);
            if (contatoByEmail != null
                && !contatoByPhone.Id.Equals(entity.Id))
                throw new ArgumentException("O telefone informado já esta cadastrado");
            #endregion

            await _unitOfWork.ContatoRepository.DaleteAsync(entity);
        }

        public async Task<List<Contato>> GetAllAsync(int page, int limit)
        {
            if (limit > 250)
                throw new ArgumentException("Limite 250");

            return await _unitOfWork.ContatoRepository
                         .GetAllAsync(page, limit);
        }

        public async Task<Contato> GetByIdAsync(Guid id)
            => await _unitOfWork.ContatoRepository.GetByIdAsync(id);

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}


