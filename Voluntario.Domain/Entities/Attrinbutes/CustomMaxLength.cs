using System;
using System.Collections.Generic;
using System.Text;

namespace Voluntario.Domain
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    internal class CustomMaxLength : Attribute
    {
        public ushort MinLength { get; set; }
        public ushort MaxLength { get; set; }

        internal CustomMaxLength (ushort min, ushort max)
        {
            MinLength = min; MaxLength = max;
        }
    }
}
