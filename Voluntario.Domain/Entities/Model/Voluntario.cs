﻿using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.Entities.Model
{
    public class Voluntario : IVoluntario
    {
        string _id;
        private Int64 _cpf;
        private string cep;
        private string _dataNascimento;
        private string _email;
        private string _fotoBase64;
        private string _nome;
        private string _senha;
        private string _telefone;
        private IList<string> _areasInteresse;
        public string Id { get => _id; set => _id = value; }
        public long Cpf { get => _cpf; set => _cpf = value; }
        public string Cep { get => cep; set => cep = value; }
        public string DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
        public string Email { get => _email; set => _email = value; }
        public string FotoBase64 { get => _fotoBase64; set => _fotoBase64 = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public IList<string> AreasInteresse { get => _areasInteresse; set => _areasInteresse = value; }

        public Voluntario()
        {

        }
    }
}
