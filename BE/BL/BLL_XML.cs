﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using DS;

namespace BL
{
    public class BLL_XML:IBL
    {
        private Dal_xml_imp dataSource;

        public BLL_XML()
        {
            dataSource = new Dal_xml_imp();
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

        public string PrintListEmployer()
        {
            string allEmployer = null;
            for (int i = 0; i < ListEmployer.Count; i++)
                allEmployer += ListEmployer[i].ToString() + "\n";
            return allEmployer;
        }

        public string PrintListEmployee()
        {
            string allEmployee = null;
            for (int i = 0; i < ListEmployees.Count; i++)
                allEmployee += ListEmployees[i].ToString() + "\n";
            return allEmployee;
        }

        public string PrintListContracts()
        {
            string allContracts = null;
            for (int i = 0; i < ListContract.Count; i++)
                allContracts += ListContract[i].ToString() + "\n";
            return allContracts;
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
            int indexEmployer = dataSource.ListEmployer.FindIndex(v => v.Id == contract.EmployerID);
            int indexEmployee = dataSource.ListEmployees.FindIndex(v => v.Id == contract.EmployeeID);

            /*
            bool employerExists = false;
            bool employeeExists = false;

            for (int i = 0; i < dataSource.ListEmployer.Count; i++)
            {
                if (dataSource.ListEmployer[i].Id == contract.EmployerID)
                    employerExists = true;
            }

            for(int i = 0; i<dataSource.ListEmployees.Count;i++)
            {
                if (dataSource.ListEmployees[i].Id == contract.EmployeeID)
                    employeeExists = true;
            }
            */

            if (indexEmployee != -1 && indexEmployer != -1)
                dataSource.AddContract(contract);
            else
                throw new Exception("No such employer or employee");
        }

        public void AddEmployee(Employee employee)
        {
            bool added = false;
            if (CalculateAge(employee.Birthday) >= 18)
            {

                for (int i = 0; i < ListSpecialzation.Count; i++)
                {
                    if (employee.SpecializationID == ListSpecialzation[i].SpecializationID)
                    {
                        dataSource.AddEmployee(employee);
                        added = true;
                        break;
                    }
                }
                if (added == false)
                    throw new Exception("The specializationID is incorrect");
            }
            else
            {
                throw new Exception("The employee must be at least 18");
            }
        }
        public void AddEmployer(Employer employer)
        {
            dataSource.AddEmployer(employer);
        }

        public void AddSpecialization(Specialization specialisation)
        {
            dataSource.AddSpecialization(specialisation);
        }


        public List<BankAccount> ListBankBranches
        {
            get
            {
                return dataSource.ListBankBranches;
            }
        }

        public void RemoveContract(Contract contract)
        {
            dataSource.RemoveContract(contract);
        }

        public void RemoveEmployer(Employer employer)
        {
            dataSource.RemoveEmployer(employer);
        }

        public void RemoverEmployee(Employee employee)
        {
            dataSource.RemoverEmployee(employee);
        }

        public void RemoveSpecialization(Specialization specialisation)
        {
            dataSource.RemoveSpecialization(specialisation);
        }

        private int CalculateAge(DateTime birthday)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int intBirthday = int.Parse(birthday.ToString("yyyyMMdd"));

            return (now - intBirthday) / 10000;
        }

        public delegate bool conditionDelegate(Contract contract);

        public List<Contract> FindAllContracts(conditionDelegate cond)
        {
            var list = from item in ListContract where cond(item) select item;

            return (List<Contract>)list;

        }

        public bool FindAllInterview(Contract contract)
        {
            return contract.Interview;
        }

        public bool FindAllContractSignature(Contract contract)
        {
            return contract.ContractSignature;

        }

        public int CountAllContracts(conditionDelegate cond)
        {
            var count = from item in ListContract where cond(item) select item;

            return count.Count<Contract>();
        }

        public List<Employee> GroupEmployersBySpecialization(bool order = false)
        {

            if (order)
            {
                var list = from employee in ListEmployees
                           group employee by employee.SpecializationID into newList
                           orderby newList.Key
                           select newList;

                return (List<Employee>)list;
            }
            else
            {
                var list = from employee in ListEmployees
                           group employee by employee.SpecializationID into newList
                           select newList;

                return (List<Employee>)list;
            }
        }

        public List<Employee> GroupEmployersByAdress(bool order = false)
        {

            if (order)
            {
                var list = from employee in ListEmployees
                           group employee by employee.Adress into newList
                           orderby newList.Key
                           select newList;

                return (List<Employee>)list;
            }
            else
            {
                var list = from employee in ListEmployees
                           group employee by employee.Adress into newList
                           select newList;

                return (List<Employee>)list;
            }
        }

        // TODO: Not working, needs fix
        public List<Employee> GroupEmployersByProfit(bool order = false)
        {

            if (order)
            {
                var list = from employee in ListEmployees
                           group employee by employee.SpecializationID into newList
                           orderby newList.Key
                           select newList;

                return (List<Employee>)list;
            }
            else
            {
                var list = from employee in ListEmployees
                           group employee by employee.SpecializationID into newList
                           select newList;

                return (List<Employee>)list;
            }

        }

        public void UpdateSpecialization(Specialization UpdatedSpecialisation)
        {
            dataSource.UpdateSpecialization(UpdatedSpecialisation);
        }

        public void UpdatedEmployer(Employer UpdatedEmployer)
        {
            dataSource.UpdatedEmployer(UpdatedEmployer);
        }

        public void UpdateEnployee(Employee UpdatedEmployee)
        {
            dataSource.UpdateEnployee(UpdatedEmployee);
        }

        public void UpdateContract(Contract UpdatedContract)
        {
            dataSource.UpdateContract(UpdatedContract);
        }
    }


}