﻿using CentralSharedModel.Interfaces;
using IoCManager.SharedModel;
using System.Net.Http;
using System.Reflection;
using System.Linq;

namespace CentralValidations
{
    public class CepValidator
    {
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
        
        public IAddress ValidateCep(string cep)
        {
            string _endpoint = string.Format("https://viacep.com.br/ws/{0}/json/", cep);
            IAddress address = null;
            using (var client = new HttpClient())
            {
               
                var response = client.GetAsync(_endpoint).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if(!result.ToUpper().Contains("ERRO"))
                    {
                        address = new SharedModelIoCManager().GetIAddressCurrentImplementation();
                        GetDeserializedAdress(result, address);
                    }
                       
                } 
            }
            return address;
        }
    }
}