using FluentValidation.Results;
using Project001.Domain.Validators;
using Project01.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Domain.Entities
{
    public class Contato : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? Update { get; set; }


        #region Atributos


        private string? _nome;
        private string? _email;
        private string? _phone;

        #endregion

        #region Propriedade

        public string? Nome
        { get => _nome; set => _nome = value; }
        public string? Email
        { get => _email; set => _email = value; }
        public string? Phone
        { get => _phone; set => _phone = value; }

        
        public ValidationResult Validate
            => new ContatoValidator().Validate(this);

        public ValidationResult Validation => throw new NotImplementedException();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        #endregion

    }
}
