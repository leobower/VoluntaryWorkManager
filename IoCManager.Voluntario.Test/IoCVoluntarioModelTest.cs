using IocManager.Voluntario;
using NUnit.Framework;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class IoCVoluntarioModelTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestVoluntarioModelInjection()
        {
            IVoluntario voluntario = null;
            VoluntarioModelIocManager iocManager = new VoluntarioModelIocManager();
            voluntario = iocManager.GetCurrentImplementation();
            Assert.IsNotNull(voluntario);

            Assert.IsTrue(voluntario.GetType().IsClass);

        }

    }
}