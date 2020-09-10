
using CentralSharedModel.Interfaces;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using Voluntario.Application.Tests;

namespace Voluntario.API.Rest.Test
{
    public class VoluntarioAPITest : BaseTestClass, IRequest
    {
        string _voluntarioSer = null;
        string endpoint = string.Format("https://localhost:44302/api/v1/Voluntario/");

        [Test]
        public void PostTest()
        {
            
            bool ret = false;
            using (var client = new HttpClient())
            {
                _voluntarioSer = base.GetVoluntarioSerialized();

                HttpResponseMessage response = client.PostAsync(
                     endpoint, new StringContent(
                         _voluntarioSer, Encoding.UTF8, "application/json")).Result;
                ret = (response.StatusCode == HttpStatusCode.Created);

            }

            Assert.IsTrue(ret);
        }

        [Test]
        public void GetByCpf()
        {
            bool ret = false;
            string cpf = "10980011337";
            string endpointCPf = endpoint + $"cpf/{cpf}";
            using (var client = new HttpClient())
            {
                string request = base.GetVoluntarioSerialized();

                HttpResponseMessage response = client.GetAsync(endpointCPf).Result;
                ret = (response.StatusCode == HttpStatusCode.OK);

            }

            Assert.IsTrue(ret);
        }

        [Test]
        public void GetById()
        {
            bool ret = false;
            string id = "79a1399a-242a-455a-b5b4-923537db7a84";
            string endpointId = endpoint + $"id/{id}";
            using (var client = new HttpClient())
            {
                string request = base.GetVoluntarioSerialized();

                HttpResponseMessage response = client.GetAsync(endpointId).Result;
                ret = (response.StatusCode == HttpStatusCode.OK);

            }

            Assert.IsTrue(ret);
        }

        [Test]
        public void GetByEmail()
        {
            bool ret = false;
            string email = "le.ribeiro.vca.1221@gmail.com";
            string endpointEmail = endpoint + $"email/{email}";
            using (var client = new HttpClient())
            {
                string request = base.GetVoluntarioSerialized();

                HttpResponseMessage response = client.GetAsync(endpointEmail).Result;
                ret = (response.StatusCode == HttpStatusCode.OK);

            }

            Assert.IsTrue(ret);
        }

        [Test]
        public void GetByName()
        {
            bool ret = false;
            string name = "teste";
            string endpointNamel = endpoint + $"name/{name}";
            using (var client = new HttpClient())
            {
                string request = base.GetVoluntarioSerialized();

                HttpResponseMessage response = client.GetAsync(endpointNamel).Result;
                ret = (response.StatusCode == HttpStatusCode.OK);

            }

            Assert.IsTrue(ret);
        }


        //public void PutTest()
        //{
        //    bool ret = false;
        //    using (var client = new HttpClient())
        //    {
        //        string request = base.GetVoluntarioSerialized();

        //        HttpResponseMessage response = client.PostAsync(
        //             endpoint, new StringContent(
        //                 request, Encoding.UTF8, "application/json")).Result;
        //        ret = (response.StatusCode == HttpStatusCode.Created);

        //    }

        //    Assert.IsTrue(ret);
        //}
    }

    
}