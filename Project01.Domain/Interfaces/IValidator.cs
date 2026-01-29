using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01.Domain.Core.Interfaces
{
    public interface IValidator
    {

        ValidationResult Validation { get; }
    }
}
