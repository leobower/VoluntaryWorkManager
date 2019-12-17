using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;
using IoCManager.Voluntario.Business;

namespace Tests
{
    public class IoCVoluntarioQueryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVoluntarioModelInjection()
        {
            IVoluntarioQuery voluntario = null;
            VoluntarioQueryIocManager iocManager = new VoluntarioQueryIocManager();
            voluntario = iocManager.GetCurrentIVoluntarioQueryImplementation();
            Assert.IsNotNull(voluntario);

            Assert.IsTrue(voluntario.GetType().IsClass);

        }

    }
}