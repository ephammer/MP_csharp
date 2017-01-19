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
            string contract = "Contract ID: " + Convert.ToString(ContractID) + "\n" ;
            contract += "Employers ID: " + Convert.ToString(EmployerID) + "\n";
            contract += "Employees ID: " + Convert.ToString(EmployeeID) + "\n";

            if (Interview)
                contract += "Interview: " + "Yes" + "\n";
            else
                contract += "Interview: " + "No" + "\n";

            if (ContractSignature)
                contract += "Signature: " + "Yes" + "\n";
            else
                contract += "Signature: " + "No" + "\n";

            contract += "The hourly wage before Taxes: " + Convert.ToString(HourlyWageBrute) + "\n";
            contract += "The hourly wage after Taxes: " + Convert.ToString(HourlyWageNet) + "\n";

            contract += "The contract started the: " + Convert.ToString(StartContract) + "\n";
            contract += "The contract ended the: " + Convert.ToString(EndContract) + "\n";
            contract += "The total duration of the contract is: " + Convert.ToString(EndContract - StartContract); 

            return contract;
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
