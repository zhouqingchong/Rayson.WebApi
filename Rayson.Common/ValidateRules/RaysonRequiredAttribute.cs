using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Rayson.Common.ValidateRules
{
    public class RaysonRequiredAttribute: BaseAbstractAttribute
    {
        public RaysonRequiredAttribute(string? message):base(message)
        {
           
        }

        public override (bool, string?) DoValidate(object? obj)
        {
            return obj == null ? (false, Message) : (true, Message);
        }
    }
}
