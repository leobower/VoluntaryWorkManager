using CentralValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CentralValidations.Test
{
    public class CnpjValidatorTest
    {
        // private List<string> _listaCnpj;

        [SetUp]
        public void Setup()
        {
            // _listaCpf = new List<string>() { "81926682076", "567.756.290-44", "312.543.654.90", "90876856423" };
        }

        [Test]
        public void TestValidCnpj()
        {
            List<string> _listaCnpj = new List<string>() { "41691825000187", "12.204.603/0001-94" };//CPFs Válidos

            bool control = false;
            Int64? cpf = null;
            string currentCpf = "";
            try
            {
                foreach (var item in _listaCnpj)
                {
                    currentCpf = item;
                    control = CnpjValidator.ValidateCnpj(item, out cpf);
                    if (!control && (cpf == null || !cpf.HasValue))
                    {
                        cpf = null;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Current CPF: {0}",currentCpf), ex);
            }
            
            Assert.IsTrue(control && cpf.HasValue);
        }

        [Test]
        public void TestInvalidCnpj()
        {
            List<string> _listaCnpj = new List<string>() { "31232123212456", "31.243.245/7777-88" };//CPFs Inválidos

            bool control = false;
            Int64? cpf = null;
            string currentCpf = "";
            try
            {
                foreach (var item in _listaCnpj)
                {
                    currentCpf = item;
                    control = CnpjValidator.ValidateCnpj(item, out cpf);
                    if (!control && (cpf == null || !cpf.HasValue))
                    {
                        cpf = null;
                        break;
                    }
                    cpf = null;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Current CPF: {0}", currentCpf), ex);
            }

            Assert.IsTrue(!control && !cpf.HasValue);
        }



    }
}