using FluentValidation.Results;
using Project001.Domain.Validators;
using Project01.Domain.Core.Interfaces;

namespace Project001.Domain.Entities
{
  public class Contato : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private string? _nome;
    private string? _email;
    private string? _phone;

    public string? Nome
    {
        get => _nome;
        set => _nome = value;
    }

    public string? Email
    {
        get => _email;
        set => _email = value;
    }

    public string? Phone
    {
        get => _phone;
        set => _phone = value;
    }
}

}
