using System;
using System.Collections.Generic;
using System.Text;

namespace Voluntario.Domain.Entities.Interfaces
{
    public interface IVoluntario
    {
        Guid Id { get; set; }
        Int64  Cpf { get; set; }
        string  Cep { get; set; }
        string DataNascimento { get; set; }
        string Email { get; set; }
        byte[] Foto { get; set; }
        string Nome { get; set; }
        string Senha { get; set; }
        string Telefone { get; set; }   

    }
}
