using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01.Domain.Core.Interfaces
{
    public interface IEntity : IValidator
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? Update { get; set; }
    }
}
