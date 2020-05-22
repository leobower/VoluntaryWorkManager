using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.IoCManager.Business;

namespace Voluntario.IoCManager.Tests
{
    public class IoCVoluntarioQueryTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVoluntarioModelInjection()
        {
            IVoluntarioQuery voluntario = null;
            VoluntarioQueryIocManager iocManager = new VoluntarioQueryIocManager(base.Config);
            voluntario = iocManager.GetCurrentIVoluntarioQueryImplementation();
            Assert.IsNotNull(voluntario);

            Assert.IsTrue(voluntario.GetType().IsClass);

        }

    }
}