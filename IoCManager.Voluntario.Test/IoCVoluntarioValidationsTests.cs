using Voluntario.IoCManager.Business;
using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;
using CentralSharedModel.BaseTest;

namespace CrossCutting.IoCManager.Test
{
    public class IoCVoluntarioValidationsTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVoluntarioValidationsInjection()
        {
            IVoluntarioValidations voluntarioValidations = null;
            VoluntarioValidationsIocManager iocManager = new VoluntarioValidationsIocManager(base.Config);
            voluntarioValidations = iocManager.GetCurrentIVoluntarioValidationsImplementation();
            Assert.IsNotNull(voluntarioValidations);
            Assert.IsTrue(voluntarioValidations.GetType().IsClass);

        }
    }
}