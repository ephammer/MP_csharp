using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int ContractID { get; set; }
        // TODO: Limit NumberContract to number with 8 digits

        public int EmployerID { get; set; }
        public int EmployeeID { get; set; }

        public bool Interview { get; set; }
        public bool ContractSignature { get; set; }
        public int HourlyWageBrute { get; set; }
        public int HourlyWageNet { get; set; }
        public DateTime StartContract { get; set; }
        public DateTime EndContract { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public Contract(int contarctID, int emplyerID, int employeeID, bool interview, bool signature,
            int hourlyWageBrute, int hourlyWageNet, DateTime startContract, DateTime endContract)
        {
            ContractID = contarctID;
            EmployerID = emplyerID;
            EmployeeID = employeeID;
            Interview = interview;
            ContractSignature = signature;
            HourlyWageBrute = hourlyWageBrute;
            HourlyWageNet = hourlyWageNet;
            StartContract = startContract;
            EndContract = endContract;
        }
    }
}
