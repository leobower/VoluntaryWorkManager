using IocManager.Voluntario;
using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class IoCVoluntarioPersistenceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVoluntarioModelInjection()
        {
            IVoluntarioPersistence voluntarioPersistence = null;
            VoluntarioPersistenceIocManager iocManager = new VoluntarioPersistenceIocManager();
            voluntarioPersistence = iocManager.GetCurrentImplementation();
            Assert.IsNotNull(voluntarioPersistence);

            Assert.IsTrue(voluntarioPersistence.GetType().IsClass);
            
        }

    }
}