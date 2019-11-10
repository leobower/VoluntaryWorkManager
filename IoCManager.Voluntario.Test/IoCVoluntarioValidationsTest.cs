using IocManager.Voluntario;
using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class IoCVoluntarioValidationsTest
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
            voluntarioValidations = iocManager.GetCurrentImplementation();
            Assert.IsNotNull(voluntarioValidations);
            Assert.IsTrue(voluntarioValidations.GetType().IsClass);

        }
    }
}