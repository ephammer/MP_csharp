using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DS
{
    class Dal_imp : Idal
    {
        public List<Contract> ListContract
        {
            get
            {
                return DataSource.listContract;
            }

            set
            {
                DataSource.listContract = value;
            }
        }

        public List<Employee> ListEmployees
        {
            get
            {
                return DataSource.listEmployees;
            }

            set
            {
                DataSource.listEmployees = value;
            }
        }

        public List<Employer> ListEmployer
        {
            get
            {
                return DataSource.listEmployer;
            }

            set
            {
                DataSource.listEmployer = value;
            }
        }

        public List<Specialization> ListSpecialzation
        {
            get
            {
                return DataSource.listSpecialzation;
            }

            set
            {
                DataSource.listSpecialzation = value;
            }
        }

        public void AddContract(Contract contract)
        {
            DataSource.listContract.Add(contract);
        }

        public void AddEmployee(Employee employee)
        {
            DataSource.listEmployees.Add(employee);
        }

        public void AddEmployer(Employer employer)
        {
            DataSource.listEmployer.Add(employer);
        }

        public void AddSpecialization(Specialization specialisation)
        {
            DataSource.listSpecialzation.Add(specialisation);
        }

        public List<BankAccount> ListBankBranches()
        {
            List<BankAccount> listBankBranches = new List<BankAccount>(5);

            return listBankBranches;
        }

        public void RemoveContract(Contract contract)
        {
            DataSource.listContract.Remove(contract);
        }

        public void RemoveEmployer(Employer employer)
        {
            DataSource.listEmployer.Remove(employer);
        }

        public void RemoverEmployee(Employee employee)
        {
            DataSource.listEmployees.Remove(employee);
        }

        public void RemoveSpecialization(Specialization specialisation)
        {
            DataSource.listSpecialzation.Remove(specialisation);
        }
    }
}
