using Voluntario.IoCManager.Business;
using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;

namespace CrossCutting.IoCManager.Test
{
    public class IoCVoluntarioValidationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVoluntarioValidationsInjection()
        {
            IVoluntarioValidations voluntarioValidations = null;
            VoluntarioValidationsIocManager iocManager = new VoluntarioValidationsIocManager();
            voluntarioValidations = iocManager.GetCurrentIVoluntarioValidationsImplementation();
            Assert.IsNotNull(voluntarioValidations);
            Assert.IsTrue(voluntarioValidations.GetType().IsClass);

        }
    }
}