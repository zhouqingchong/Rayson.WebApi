using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayson.Common.ValidateRules
{
    public class RequireIsNumActtribute : BaseAbstractAttribute
    {
        public RequireIsNumActtribute(string message) : base(message)
        {
        }

        public override (bool, string?) DoValidate(object? obj)
        {
            return obj is int or long ? (true, Message) : (false, Message);
        }
    }
}
