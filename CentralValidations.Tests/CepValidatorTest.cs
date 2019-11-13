using CentralSharedModel.Interfaces;
using CentralValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CentralValidations.Test
{
    public class CepValidatorTest
    {
        [SetUp]
        public void Setup()
        {
            // _listaCpf = new List<string>() { "81926682076", "567.756.290-44", "312.543.654.90", "90876856423" };
        }

        [Test]
        public void TestValidCep()
        {
            List<string> _listaCep = new List<string>() { "01001-000", "11703680" };//CPFs Válidos
            IAddress address = null;
            try
            {
                foreach (var item in _listaCep)
                {
                    address = new CepValidator().ValidateCep(item);
                    if (address == null)
                    {
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;//;new Exception(String.Format("Current CPF: {0}", currentCep), ex);
            }

            Assert.IsNotNull(address);
            Assert.IsNotEmpty(address.Cep);
        }

        [Test]
        public void TestInvalidCep()
        {
            List<string> _listaCep = new List<string>() { "73980-111", "21312321" };//CPFs Válidos
            IAddress address = null;
            try
            {
                foreach (var item in _listaCep)
                {
                    address = new CepValidator().ValidateCep(item);
                    if (address == null)
                    {
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;//;new Exception(String.Format("Current CPF: {0}", currentCep), ex);
            }

            Assert.IsNull(address);
        }

    }
}
