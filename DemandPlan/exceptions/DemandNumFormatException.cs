using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemandPlan.exceptions
{
    public class DemandNumFormatException : Exception
    {
        public override string Message
        {
            get
            {
                return "Номер заявки должен быть в формате XXXXXX!";
            }
        }
    }
}
