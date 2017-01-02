using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        void AddSpecialization(Specialization specialisation);
        void RemoveSpecialization(Specialization specialisation);
        // TODO: Function to update the Specialization

        void AddEmployer(Employer employer);
        void RemoveEmployer(Employer employer);
        // TODO: Function to update the Employer

        void AddEmployee(Employee employee);
        void RemoverEmployee(Employee employee);
        // TODO: Function to update the Employee

        void AddContract(Contract contract);
        void RemoveContract(Contract contract);
        // TODO: Function to update the Contract

        List<Specialization> ListSpecialzation { get; set; }
        List<Employee> ListEmployees { get; set; }
        List<Employer> ListEmployer { get; set; }
        List<Contract> ListContract { get; set; }

        List<BankAccount> ListBankBranches();
    }
}
