using System;
using System.Collections.Generic;
using System.Text;

namespace Voluntario.Domain.Entities.Interfaces
{
    public interface IVoluntario
    {
        [CustomMaxLength(36,36)]
        string Id { get; set; }
        [CustomMaxLength(11, 11)]
        Int64  Cpf { get; set; }
        [CustomMaxLength(8, 8)]
        string Cep { get; set; }
        [CustomMaxLength(8,8)]
        string DataNascimento { get; set; }
        [CustomMaxLength(0, 25)]
        string Email { get; set; }
        byte[] Foto { get; set; }
        [CustomMaxLength(8, 50)]
        string Nome { get; set; }
        [CustomMaxLength(8, 24)]
        string Senha { get; set; }
        [CustomMaxLength(20, 20)]
        string Telefone { get; set; }   
        IList<string> AreasInteresse { get; set; }

    }
}
