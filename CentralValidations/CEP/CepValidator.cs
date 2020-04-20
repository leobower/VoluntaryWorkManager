using CentralSharedModel.Interfaces;
using CrossCutting.IoCManager.SharedModel;
using System.Net.Http;
using System.Reflection;
using System.Linq;
using CentralTracer.Business.Publisher;

namespace CentralValidations
{
    public class CepValidator : IRequest
    {
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        private void GetDeserializedAdress(string response, IAddress address)
        {
            response = response.Replace("{", "").Replace("}", "");
            string[] listString = response.Split(',');
            for (int i = 0; i < listString.Length; i++)
            {
                string[] values = listString[i].Replace("\n","").Replace("\"", "").Replace(" ","").Split(':');

                
                PropertyInfo prop = address.GetType().GetProperties().Where(p => p.Name.ToUpper().Equals(values[0].ToUpper())).FirstOrDefault();

                if (prop != null)
                {
                    prop.SetValue(address, values[1], null);
                }
            }
        }

        public CepValidator(string requestId)
        {
            RequestId = requestId;
        }

        public bool ValidateCep(string cep)
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                bool ret = false;

                string _endpoint = string.Format("https://viacep.com.br/ws/{0}/json/", cep);
                using (var client = new HttpClient())
                {

                    var response = client.GetAsync(_endpoint).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        if (!result.ToUpper().Contains("ERRO"))
                        {
                            ret = true;
                        }

                    }
                }
                return ret;
            }
        }

    }
}
