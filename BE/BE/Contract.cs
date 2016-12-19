using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        int NumberContract { get; set; }
        // TODO: Limit NumberContract to number with 8 digits

        // TODO: modify get and set
        int EmployerID { get; set; }
        
        // TODO: modify get and set
        int EmployeeID { get; set; }

        bool Interview { get; set; }
        bool ContractSignature { get; set; }
        int HourlyWageBrute { get; set; }
        int HourlyWageNet { get; set; }
        DateTime StartContract { get; set; }
        DateTime EndContract { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
