using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSharedModel.Model
{
    public class Address : IAddress
    {
        private string _cep;
        private string _logradouro;
        private string _complemento;
        private string _bairro;
        private string _localidade;
        private string _uf;
        private string _unidade;
        private string _ibge;
        private string _gia;

        public string Cep { get => _cep; set => _cep = value; }
        public string Logradouro { get => _logradouro; set => _logradouro = value; }
        public string Complemento { get => _complemento; set => _complemento = value; }
        public string Bairro { get => _bairro; set => _bairro = value; }
        public string Localidade { get => _localidade; set => _localidade = value; }
        public string Uf { get => _uf; set => _uf = value; }
        public string Unidade { get => _unidade; set => _unidade = value; }
        public string Ibge { get => _ibge; set => _ibge = value; }
        public string Gia { get => _gia; set => _gia = value; }
    }
}
