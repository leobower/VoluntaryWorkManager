using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralValidations
{
    public class DateTimeValidator : IRequest
    {
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        public DateTimeValidator(string requestId)
        {
            RequestId = requestId;
        }

        public bool ValidateDateTime(string datetime, out string dateTimeFormatted)
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                bool ret = false;
                DateTime dt = DateTime.MinValue;
                string formatted = null;
                if (DateTime.TryParse(datetime, out dt))
                {
                    formatted = dt.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
                    ret = true;
                }

                dateTimeFormatted = formatted;
                return ret;
            }
        }
    }
}
