using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using DS;

namespace BL
{
    public class BLL:IBL
    {
        private Dal_imp dataSource;

        public BLL()
        {
            dataSource = new Dal_imp();
        }

        public List<Contract> ListContract
        {
            get
            {
                return dataSource.ListContract;
            }

            set
            {
                dataSource.ListContract = value;
            }
        }

        public List<Employee> ListEmployees
        {
            get
            {
                return dataSource.ListEmployees;
            }

            set
            {
                dataSource.ListEmployees = value;
            }
        }

        public List<Employer> ListEmployer
        {
            get
            {
                return dataSource.ListEmployer;
            }

            set
            {
                dataSource.ListEmployer = value;
            }
        }

        public List<Specialization> ListSpecialzation
        {
            get
            {
                return dataSource.ListSpecialzation;
            }

            set
            {
                dataSource.ListSpecialzation = value;
            }
        }

        public void AddContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(Employee employee)
        {
            if(calculateAge(employee.Birthday)>=18)
            {
                dataSource.AddEmployee(employee);
            }
            else
            {
                throw new Exception();
            }
        }

        public void AddEmployer(Employer employer)
        {
            throw new NotImplementedException();
        }

        public void AddSpecialization(Specialization specialisation)
        {
            throw new NotImplementedException();
        }

        public List<BankAccount> ListBankBranches()
        {
            throw new NotImplementedException();
        }

        public void RemoveContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployer(Employer employer)
        {
            throw new NotImplementedException();
        }

        public void RemoverEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void RemoveSpecialization(Specialization specialisation)
        {
            throw new NotImplementedException();
        }

        private int calculateAge(DateTime birthday)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int intBirthday = int.Parse(birthday.ToString("yyyyMMdd"));

            return (now - intBirthday) / 10000;
        }
    }

   
}
