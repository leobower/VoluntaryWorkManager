using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.IoCManager.Business;

namespace Voluntario.IoCManager.Tests
{
    public class IoCVoluntarioPersistenceTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVoluntarioModelInjection()
        {
            IVoluntarioPersistence voluntarioPersistence = null;
            VoluntarioPersistenceIocManager iocManager = new VoluntarioPersistenceIocManager(base.Config);
            voluntarioPersistence = iocManager.GetCurrentIVoluntarioPersitenceImplementation();
            Assert.IsNotNull(voluntarioPersistence);

            Assert.IsTrue(voluntarioPersistence.GetType().IsClass);
            
        }

    }
}