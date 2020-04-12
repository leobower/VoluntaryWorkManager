using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CrossCutting.IoCManager.Voluntario.SerializationManager;
using Voluntario.SerializationManager;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.API.Rest
{
    public class RawJsonBodyInputFormatter : InputFormatter
    {
        public RawJsonBodyInputFormatter()
        {
            this.SupportedMediaTypes.Add("application/json");
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                
                try
                {
                    ICentralSerializationManager<IVoluntario> ser =
                      new CrossCutting.IoCManager.Voluntario.SerializationManager.SerializationIoCManager().GetJSonCurrentImplementation();

                    ser.TryDeserialize(content);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return await InputFormatterResult.SuccessAsync(content);
            }
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }
    }
}
