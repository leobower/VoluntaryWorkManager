using IocManager.Voluntario;
using NUnit.Framework;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;
using System.Linq;
using System.Collections.Generic;

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
            voluntario = iocManager.GetCurrentImplementation();
            Assert.IsNotNull(voluntario);

            Assert.IsTrue(voluntario.GetType().IsClass);

        }

    }
}