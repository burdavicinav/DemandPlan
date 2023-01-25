using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemandPlan.exceptions
{
    public class DemandPhoneFormatException : Exception
    {
        public override string Message
        {
            get
            {
                return "Неверный формат номера телефона!";
            }
        }
    }
}
