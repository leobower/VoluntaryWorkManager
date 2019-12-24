using System;
using System.Collections.Generic;
using System.Text;

namespace CentralValidations
{
    public class DateTimeValidator
    {
        public bool ValidateDateTime(string datetime, out string dateTimeFormatted)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation())
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
