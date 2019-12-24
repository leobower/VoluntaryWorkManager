using CentralSharedModel.Interfaces;
using CentralValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CentralValidations.Test
{
    public class EmailValidatorTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestValidEmail()
        {
            List<string> _listEmails = new List<string>() { "david.jones@proseware.com", "d.j@server1.proseware.com",
                                    "jones@ms1.proseware.com", "j_teste@server1.proseware.com" };//Valid emails
            bool valid = false;
            try
            {
                foreach (var item in _listEmails)
                {
                    valid = new EmailValidator(Guid.NewGuid().ToString()).IsValidEmail(item);
                    if (!valid)
                    {
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;//;new Exception(String.Format("Current CPF: {0}", currentCep), ex);
            }

            Assert.IsTrue(valid);
        }

        [Test]
        public void TestInvalidEmail()
        {
            List<string> _listEmails = new List<string>() { "j.@server1.proseware.com", 
                                    "j..s@proseware.com", "js*@proseware.com" };//Valid emails
            bool valid = false;
            try
            {
                foreach (var item in _listEmails)
                {
                    valid = new EmailValidator(Guid.NewGuid().ToString()).IsValidEmail(item);
                    if (valid)
                    {
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;//;new Exception(String.Format("Current CPF: {0}", currentCep), ex);
            }

            Assert.IsFalse(valid);
        }

    }
}
