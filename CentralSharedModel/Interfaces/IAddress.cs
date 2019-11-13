using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSharedModel.Interfaces
{
    public interface IAddress
    {
        string Cep { get; set; }
        string Logradouro { get; set; }
        string Complemento { get; set; }
        string Bairro { get; set; }
        string Localidade { get; set; }
        string Uf { get; set; }
        string Unidade { get; set; }
        string Ibge { get; set; }
        string Gia { get; set; }


    }
}
