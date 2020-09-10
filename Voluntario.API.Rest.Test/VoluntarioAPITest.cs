
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

        [Test]
        public void PostTest()
        {
            string endpoint = string.Format("https://localhost:44302/api/v1/Voluntario/");
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
        public void PutTest()
        {
            string endpoint = string.Format("https://localhost:44302/api/v1/Voluntario/");
            bool ret = false;
            using (var client = new HttpClient())
            {
                string request = base.GetVoluntarioSerialized();

                HttpResponseMessage response = client.PostAsync(
                     endpoint, new StringContent(
                         request, Encoding.UTF8, "application/json")).Result;
                ret = (response.StatusCode == HttpStatusCode.Created);

            }

            Assert.IsTrue(ret);
        }
    }

    
}