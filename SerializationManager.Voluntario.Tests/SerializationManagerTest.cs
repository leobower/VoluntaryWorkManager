using NUnit.Framework;
using System;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.SerializationManager.Tests
{
    public class SerializationManagerTest
    {
        IVoluntario voluntario = null;
        [SetUp]
        public void Setup()
        {
            voluntario = new Voluntario.IoCManager.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
            voluntario.Cep = "11703680";
            voluntario.Cpf = 31495307840;
            voluntario.DataNascimento = "16/02/1982";
            voluntario.Email = "le.ribeiro.vca@gmail.com";
            voluntario.Id = Guid.NewGuid().ToString();
            voluntario.Nome = "Leandro Figueiredo Silva Ribeiro";
            voluntario.Senha = "Senha";
            voluntario.Telefone = "12323123";
        }

        private string TestSerialization()
        {
            ICentralSerializationManager<IVoluntario> ser = new Voluntario.IoCManager.SerializationManager.SerializationIoCManager().GetISerializationCurrentImplementation();

            return ser.Serialize(voluntario);
        }


        [Test]
        public void SerializeTest()
        {
            try
            {
                string message = TestSerialization();
                Assert.IsNotNull(message);
                Assert.IsNotEmpty(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}