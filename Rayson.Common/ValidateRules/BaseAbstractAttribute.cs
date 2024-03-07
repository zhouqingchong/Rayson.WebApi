using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayson.Common.ValidateRules
{
    public abstract class BaseAbstractAttribute:Attribute
    {
        protected string? Message { get; set; }
        public abstract (bool, string?) DoValidate(object? obj);

        public BaseAbstractAttribute(string message)
        {
            this.Message = message;
        }
    }
}
