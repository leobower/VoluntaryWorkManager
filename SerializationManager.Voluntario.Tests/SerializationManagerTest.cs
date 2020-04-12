using NUnit.Framework;
using System;
using System.Collections.Generic;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.SerializationManager.Tests
{
    public class SerializationManagerTest
    {
        IVoluntario voluntario = null;
        ICentralSerializationManager<IVoluntario> ser = null;
        [SetUp]
        public void Setup()
        {
            ser = new CrossCutting.IoCManager.Voluntario.SerializationManager.SerializationIoCManager().GetJSonCurrentImplementation();

            voluntario = new Voluntario.IoCManager.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
            voluntario.Cep = "11703680";
            voluntario.Cpf = 31495307840;
            voluntario.DataNascimento = "16/02/1982";
            voluntario.Email = "le.ribeiro.vca@gmail.com";
            voluntario.Id = Guid.NewGuid().ToString();
            voluntario.Nome = "Leandro Figueiredo Silva Ribeiro";
            voluntario.Senha = "Senha";
            voluntario.Telefone = "12323123";
            voluntario.AreasInteresse = new List<string>() { "teste01", "teste02" };
            voluntario.FotoBase64 = Convert.ToBase64String(new byte[] { 0, 1, 33, 56, 87, 19 });
        }

        private string TestSerialization()
        {

            return ser.Serialize(voluntario);
        }

        private object TestDeserializaton(string obj)
        {
            return (object)ser.Deserialize(obj);
        }

        private bool TestTryDeserialization(string obj)
        {
            return ser.TryDeserialize(obj);
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

        [Test]
        public void DeserializeTest()
        {
            try
            {
                string message = TestSerialization();
                object objVolunt = TestDeserializaton(message);
                Assert.IsNotNull(objVolunt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void TryDeserializePositiveTest()
        {
            try
            {
                string message = TestSerialization();
                Assert.IsTrue(TestTryDeserialization(message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void TryDeserializeNegativeTest()
        {
            bool test = false;
            try
            {
                string message = TestSerialization();
                message = message.Replace("id", "id_IUI");
                test = TestTryDeserialization(message);
            }
            catch (Exception ex)
            {
                if(!ex.Message.Contains("Invalid Request Body. Follow the model above"))
                    throw ex;
            }

            Assert.IsFalse(test);
        }

    }
}