using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using Voluntario.Domain.Entities.Interfaces;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Voluntario.SerializationManager
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
    

    public class JSon : ICentralSerializationManager<IVoluntario>
    {
        private readonly JsonSerializerSettings _settings;
        private IVoluntario _volunt = null;
        private IConfiguration _conf;
        public JSon(IConfiguration conf)
        {
            _conf = conf;
            _settings = new JsonSerializerSettings();
            _settings.ContractResolver = new LowercaseContractResolver();
            _volunt = new Voluntario.IoCManager.Model.ModelIoCManager(_conf).GetIVoluntarioCurrentImplementation();
        }

        private IVoluntario DeserializeJSonVol(string vol)
        {
            IVoluntario ret = new Voluntario.IoCManager.Model.ModelIoCManager(_conf).GetIVoluntarioCurrentImplementation();
            //var JObject = JsonConvert.DeserializeObject(vol);
            JObject obj = JObject.Parse(vol);
            //var teste = obj.GetValue("areasinteresse");
            foreach (PropertyInfo pi in ret.GetType().GetProperties())
            {
                if (obj.GetValue(pi.Name.ToLower()) != null)
                {
                    //TODO - verificar como o NewtonSoft serializa byte[]
                    if (!pi.Name.ToLower().Equals("foto"))
                    {
                        if (!obj.GetValue(pi.Name.ToLower()).ToString().Contains("["))
                            pi.SetValue(ret, Convert.ChangeType(obj.GetValue(pi.Name.ToLower()).ToString(), pi.PropertyType));
                        else
                        {
                            //TODO
                            string val = obj.GetValue(pi.Name.ToLower()).ToString().Replace("[", string.Empty).Replace("]", string.Empty).Replace("\"", string.Empty).Replace(System.Environment.NewLine, string.Empty);
                            string[] arrVal = val.Split(',');
                            List<string> listStr = new List<string>();
                            for (int i = 0; i < arrVal.Length; i++)
                            {
                                listStr.Add(arrVal[i]);

                            }
                            pi.SetValue(ret, listStr);

                        }
                    }

                }
                
            }

            return ret;
        }

        public IVoluntario Deserialize(string obj)
        {
            return DeserializeJSonVol(obj);
        }

        public string Serialize(IVoluntario obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, _settings);
        }

        public bool TryDeserialize(string obj)
        {
            bool ret = false;
            try
            {
                IVoluntario vol = new Voluntario.IoCManager.Model.ModelIoCManager(_conf).GetIVoluntarioCurrentImplementation();
                //var JObject = JsonConvert.DeserializeObject(vol);
                JObject jObj = JObject.Parse(obj);
                List<bool> listContainsToken = new List<bool>();

                //List<string> listProps = new List<string>();
                foreach (PropertyInfo pi in vol.GetType().GetProperties())
                {
                    listContainsToken.Add(jObj.ContainsKey(pi.Name.ToLower()));
                }

                ret = (jObj.Count.Equals(listContainsToken.Count) && !listContainsToken.Contains(false));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if(!ret)
            {
                string message = @"Invalid Request Body. Follow the model above
                                        {
                                          'id': 'Guid',
                                          'cpf': 'Long',
                                          'cep': 'string',
                                          'datanascimento': 'dd/MM/yyy',
                                          'email': 'valid@email.com',
                                          'fotobase64': 'string',
                                          'nome': 'Full Name',
                                          'senha': 'Senha',
                                          'telefone': 'string',
                                          'areasinteresse': [
                                            'test01',
                                            'test02'
                                          ]
                                        }";
                throw new Exception(message);
            }
            return ret;
            
        }
    }
}
