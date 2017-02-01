using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DS
{
    public class Dal_imp : Idal
    {
        public Dal_imp()
        {
            new DataSource();
        }
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

        public List<BankAccount> ListBankBranches
        {
            get
            {
                List<BankAccount> listBankBranches = new List<BankAccount>(5);

                return listBankBranches;
            }
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

        public void UpdateContract(Contract UpdatedContract)
        {
            for (int i = 0; i > ListContract.Count; i++)
            {
                if(ListContract[i].ContractID == UpdatedContract.ContractID)
                {
                    ListContract[i] = UpdatedContract;
                    break;
                }
            }

        }

        public void UpdatedEmployer(Employer UpdatedEmployer)
        {
            for (int i = 0; i > ListEmployer.Count; i++)
            {
                if (ListEmployer[i].Id== UpdatedEmployer.Id)
                {
                    ListEmployer[i] = UpdatedEmployer;
                    break;
                }
            }
        }

        public void UpdateEnployee(Employee UpdatedEmployee)
        {
            for (int i = 0; i > ListEmployees.Count; i++)
            {
                if (ListEmployees[i].Id == UpdatedEmployee.Id)
                {
                    ListEmployees[i] = UpdatedEmployee;
                    break;
                }
            }
        }

        public void UpdateSpecialization(Specialization UpdatedSpecialisation)
        {
            for (int i = 0; i > ListSpecialzation.Count; i++)
            {
                if (ListSpecialzation[i].SpecializationID == UpdatedSpecialisation.SpecializationID)
                {
                    ListSpecialzation[i] = UpdatedSpecialisation;
                    break;
                }
            }
        }



    }
}
