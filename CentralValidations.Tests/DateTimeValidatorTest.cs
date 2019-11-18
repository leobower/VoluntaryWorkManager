using CentralSharedModel.Interfaces;
using CentralValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CentralValidations.Test
{
    public class DateTimeValidatorTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestValidDateTime()
        {
            List<string> _listDate = new List<string>() { "2012-12-12 12:00:00", "2012/12/12 12:00:00" };//Valid dates
            string data = null;
            bool valid = false;
            try
            {
                foreach (var item in _listDate)
                {
                    valid = new DateTimeValidator().ValidateDateTime(item, out data);
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

            Assert.IsNotNull(data);
            Assert.IsNotEmpty(data);
            Assert.IsTrue(valid);
        }

        [Test]
        public void TestInvalidDateTime()
        {
            List<string> _listDate = new List<string>() { "2012-23-12 12:00:00", "2012/23/12 12:00:00" };//invalid dates
            string data = null;
            bool valid = true;
            try
            {
                foreach (var item in _listDate)
                {
                    valid = new DateTimeValidator().ValidateDateTime(item, out data);
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

            Assert.IsNull(data);
            //Assert.IsNotEmpty(data);
            Assert.IsFalse(valid);
        }

    }
}
