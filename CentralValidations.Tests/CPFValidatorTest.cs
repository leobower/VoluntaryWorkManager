using CentralSharedModel.BaseTest;
using CentralValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CentralValidations.Test
{
    public class CpfValidatorTest : BaseTestClass
    {
        private List<string> _listaCpf;

        [SetUp]
        public void Setup()
        {
           // _listaCpf = new List<string>() { "81926682076", "567.756.290-44", "312.543.654.90", "90876856423" };
        }

        [Test]
        public void TestValidCpf()
        {
            _listaCpf = new List<string>() { "81926682076", "567.756.290-44" };//CPFs Válidos

            bool control = false;
            Int64? cpf = null;
            string currentCpf = "";
            try
            {
                foreach (var item in _listaCpf)
                {
                    currentCpf = item;
                    control = new CpfValidator(Guid.NewGuid().ToString(), base.Config).ValidateCPF(item, out cpf);
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
        public void TestInvalidCpf()
        {
            _listaCpf = new List<string>() { "312.543.654.90", "90876856423" };//CPFs Inválidos

            bool control = false;
            Int64? cpf = null;
            string currentCpf = "";
            try
            {
                foreach (var item in _listaCpf)
                {
                    currentCpf = item;
                    control = new CpfValidator(Guid.NewGuid().ToString(), base.Config).ValidateCPF(item, out cpf);
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