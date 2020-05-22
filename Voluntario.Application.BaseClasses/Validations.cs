using CentralSharedModel.Interfaces;
using CentralValidations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voluntario.Application.BaseClasses
{
    public abstract class Validations : IRequest
    {
        private CepValidator _cepValidator;
        private CpfValidator _cpfValidator;
        private DateTimeValidator _dateTimeValidator;
        private EmailValidator _emailValidator;
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        public CepValidator CepValidator { get => _cepValidator; set => _cepValidator = value; }
        public CpfValidator CpfValidator { get => _cpfValidator; set => _cpfValidator = value; }
        public DateTimeValidator DateTimeValidator { get => _dateTimeValidator; set => _dateTimeValidator = value; }
        public EmailValidator EmailValidator { get => _emailValidator; set => _emailValidator = value; }

        public Validations(IConfiguration conf)
        {
            _cepValidator = new CepValidator(RequestId, conf);
            _cpfValidator = new CpfValidator(RequestId, conf);
            _dateTimeValidator = new DateTimeValidator(RequestId, conf);
            _emailValidator = new EmailValidator(RequestId, conf);
        }
    }
}
