using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using BE;

namespace DAL
{
    class Dal_xml_imp:Idal
    {
        /*
        XElement configsRoot;
        string configsPath;
        */

        XElement employeesRoot;
        string employeesPath;

        XElement employersRoot;
        string employersPath;

        XElement specializationsRoot;
        string specializationsPath;

        XElement contractsRoot;
        string contractsPath;

        public Dal_xml_imp()
        {
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);

            for (int i = 0; i < 3; i++)
                localPath = Directory.GetParent(localPath).FullName;

            employeesPath = localPath + @"\\XML\\EmployeesXML.xml";
            employersPath = localPath + @"\\XML\\EmployersXML.xml";
            specializationsPath = localPath + @"\\XML\\SpecializationsXML.xml";
            contractsPath = localPath + @"\\XML\\ContractsXML.xml";
            //configsPath = localPath + @"\\XML\\ConfigsXML.xml";

            // ---------------------------------------------------
            // Generating XML Files
            // ---------------------------------------------------

            /*
            // Configuration File
            if (!File.Exists(configsPath))
            {
                // We config the auto-increment indexes
                configsRoot = new XElement("autoincrements");
                XElement numberRenting = new XElement("numberRenting", 0);
                XElement numberClient = new XElement("numberClient", 0);
                XElement numberCar = new XElement("numberCar", 0);
                XElement numberFault = new XElement("numberFault", 0);
                XElement numberCarFault = new XElement("numberCarFault", 0);

                configsRoot.Add(new XElement("autoincrement", numberRenting, numberClient, numberCar, numberFault, numberCarFault));
                configsRoot.Save(configsPath);
            }
            try { configsRoot = XElement.Load(configsPath); }
            catch { throw new Exception("Failed to load " + configsPath); }

            // updating class static auto-increments
            Renting.autoIncrement = getNumberOf("Renting");
            Client.autoIncrement = getNumberOf("Client");
            Car.autoIncrement = getNumberOf("Car");
            Fault.autoIncrement = getNumberOf("Fault");
            Car_Fault.autoIncrement = getNumberOf("CarFault");
            */

            // Employer File
            if (!File.Exists(employersPath))
                MakeFile("employers", employersPath, employersRoot);
            try { employersRoot = XElement.Load(employersPath); }
            catch { throw new Exception("Failed to load " + employersPath); }


            // Employee File
            if (!File.Exists(employeesPath))
                MakeFile("employees", employeesPath, employeesRoot);
            try { employeesRoot = XElement.Load(employeesPath); }
            catch { throw new Exception("Failed to load " + employeesPath); }


            // Specialization File
            if (!File.Exists(specializationsPath))
                MakeFile("specializations", specializationsPath, specializationsRoot);
            try { specializationsRoot = XElement.Load(specializationsPath); }
            catch { throw new Exception("Failed to load " + specializationsPath); }


            // Contracts File
            if (!File.Exists(contractsPath))
                MakeFile("faults", contractsPath, contractsRoot);
            try { contractsRoot = XElement.Load(contractsPath); }
            catch { throw new Exception("Failed to load " + contractsPath); }


        }

        private void MakeFile(string name, string path, XElement root)
        {
            root = new XElement(name);
            root.Save(path);
        }

        private void LoadData(XElement root, String path)
        {
            try
            {
                root = XElement.Load(path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }


        public List<Specialization> ListSpecialzation
        {
            get
            {
                LoadData(specializationsRoot, specializationsPath);
                List<Specialization> specializations;
                
                try
                {
                    specializations = (from p in specializationsRoot.Elements()
                                select new Specialization()
                                {
                                    Name = p.Element("name").Value,
                                    Field = (Specialization.NameField)Enum.Parse(typeof(Specialization.NameField),p.Element("field").Value),
                                    SpecializationID = Convert.ToInt32(p.Element("id").Value),
                                    MinHours = Convert.ToInt32(p.Element("minHours").Value),
                                    MaxHours = Convert.ToInt32(p.Element("maxHours").Value),
                                }).ToList();
                }
                catch
                {
                    specializations = null;
                }
                return specializations;
                
            } set
            {
                for(int i = 0; i< value.Count; i++)
                {
                    AddSpecialization(value[i]);
                } 
            }
        }

        public List<Employee> ListEmployees
        {
            get
            {
                LoadData(employeesRoot, employeesPath);
                List<Employee> employees;

                try
                {
                    employees = (from p in employeesRoot.Elements()
                                 select new Employee()
                                 {
                                     Id = Convert.ToInt32(p.Element("id").Value),
                                     FirstName = p.Element("firstname").Value,
                                     LastName = p.Element("lastname").Value,
                                     Birthday = Convert.ToDateTime(p.Element("brithday").Value),
                                     Degree = (Employee.Degrees)Enum.Parse(typeof(Employee.Degrees), p.Element("degree").Value),
                                     MilitaryService = Convert.ToBoolean(p.Element("military").Value),
                                     Adress = p.Element("adress").Value,
                                     PhoneNumber = Convert.ToInt32(p.Element("phoneNumber").Value),
                                     Bankaccount = new BankAccount()
                                     {
                                         AccountNumber = Convert.ToInt32(p.Element("BankAccount").Element("AccountNumber").Value),
                                         BankNumber = Convert.ToInt32(p.Element("BankAccount").Element("BankNumber").Value),
                                         BranchNumber = Convert.ToInt32(p.Element("BankAccount").Element("BranchNumber").Value),
                                         BranchAdress = p.Element("BankAccount").Element("BranchAdress").Value,
                                         BranchCity = p.Element("BankAccount").Element("BranchCity").Value,
                                         NameBank = p.Element("BankAccount").Element("NameBank").Value
                                     }
                                 }).ToList();
                }
                catch
                {
                    employees = null;
                }
                return employees;

            }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    AddEmployee(value[i]);
                }
            }
        }
        public List<Employer> ListEmployer {
            get
            {
                LoadData(employersRoot, employersPath);
                List<Employer> employers;

                try
                {
                    employers = (from p in employersRoot.Elements()
                                 select new Employer()
                                 {
                                     Id = Convert.ToInt32(p.Element("id").Value),
                                     FirstName = p.Element("firstname").Value,
                                     Compagny = Convert.ToBoolean(p.Element("compagny").Value),
                                     Field = (Employer.NameField)Enum.Parse(typeof(Employer.NameField), p.Element("field").Value),
                                     CompagnieName = p.Element("compagnyName").Value,
                                     Adress = p.Element("adress").Value,
                                     PhoneNumber = Convert.ToInt32(p.Element("phoneNumber").Value),
                                     DateCreation = Convert.ToDateTime(p.Element("dateCreation").Value)
                                 }).ToList();
                }
                catch
                {
                    employers = null;
                }
                return employers;

            }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    AddEmployer(value[i]);
                }
            }
        }
        public List<Contract> ListContract
        {
            get
            {
                LoadData(contractsRoot, contractsPath);
                List<Contract> contracts;

                try
                {
                    contracts = (from p in contractsRoot.Elements()
                                       select new Contract()
                                       {
                                           ContractID = Convert.ToInt32(p.Element("id").Value),
                                           EmployerID = Convert.ToInt32(p.Element("employerID").Value),
                                           EmployeeID = Convert.ToInt32(p.Element("employeeID").Value),
                                           Interview = Convert.ToBoolean(p.Element("interview").Value),
                                           ContractSignature = Convert.ToBoolean(p.Element("contractSignature").Value),
                                           HourlyWageBrute = Convert.ToInt32(p.Element("hourlyWageBrute").Value),
                                           HourlyWageNet = Convert.ToInt32(p.Element("hourlyWageNet").Value),
                                           StartContract = Convert.ToDateTime(p.Element("startDate").Value),
                                           EndContract = Convert.ToDateTime(p.Element("endDate").Value),
                                       }).ToList();
                }
                catch
                {
                    contracts = null;
                }
                return contracts;

            }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    AddContract(value[i]);
                }
            }
        }




        public void AddSpecialization(Specialization specialisation)
        {
            XElement id = new XElement("id", specialisation.SpecializationID);
            XElement name = new XElement("firstName", specialisation.Name);
            XElement field = new XElement("field", specialisation.Field);
            XElement minHours = new XElement("minHours", specialisation.MinHours);
            XElement maxHours = new XElement("maxHours", specialisation.MaxHours);

            specializationsRoot.Add(new XElement("specialization", id, name, field, minHours,maxHours));
            specializationsRoot.Save(specializationsPath);
        }

        public void RemoveSpecialization(Specialization specialisation)
        {
            XElement specializationElement;
            try
            {
                specializationElement = (from p in specializationsRoot.Elements()
                                  where Convert.ToInt32(p.Element("id").Value) == specialisation.SpecializationID
                                  select p).FirstOrDefault();
                specializationElement.Remove();
                specializationsRoot.Save(specializationsPath);
            }
            catch
            {
                throw new Exception("Error adding specialization");
            }
        }

        public void UpdateSpecialization(Specialization UpdatedSpecialisation)
        {
            XElement specializationElement = (from p in specializationsRoot.Elements()
                                       where Convert.ToInt32(p.Element("id").Value) == UpdatedSpecialisation.SpecializationID
                                       select p).FirstOrDefault();

            specializationElement.Element("name").Value = UpdatedSpecialisation.Name;
            specializationElement.Element("field").Value = Convert.ToString(UpdatedSpecialisation.Field);
            specializationElement.Element("minHours").Value = Convert.ToString(UpdatedSpecialisation.MinHours);
            specializationElement.Element("maxHours").Value = Convert.ToString(UpdatedSpecialisation.MaxHours);

            specializationsRoot.Save(specializationsPath);
        }

        public void AddEmployer(Employer employer)
        {
            XElement id = new XElement("id", employer.Id);
            XElement firstName = new XElement("firstName", employer.FirstName);
            XElement field = new XElement("field", employer.Field);
            XElement compagny = new XElement("compagny", employer.Compagny);
            XElement compagnyName = new XElement("compagnyName", employer.CompagnieName);
            XElement phoneNumber = new XElement("phoneNumber", employer.PhoneNumber);
            XElement adress = new XElement("adress", employer.PhoneNumber);
            XElement dateCreation = new XElement("dateCreation", employer.DateCreation);

            employersRoot.Add(new XElement("employer", id, firstName, field, compagny, compagnyName, adress, phoneNumber, dateCreation));
            employersRoot.Save(employersPath);
        }

        public void RemoveEmployer(Employer employer)
        {
            XElement employerElement;
            try
            {
                employerElement = (from p in employersRoot.Elements()
                                         where Convert.ToInt32(p.Element("id").Value) == employer.Id
                                         select p).FirstOrDefault();
                employerElement.Remove();
                employersRoot.Save(employersPath);
            }
            catch
            {
                throw new Exception("Error adding specialization");
            }
        }

        public void UpdatedEmployer(Employer UpdatedEmployer)
        {
            XElement employerElement = (from p in employersRoot.Elements()
                                              where Convert.ToInt32(p.Element("id").Value) == UpdatedSpecialisation.SpecializationID
                                              select p).FirstOrDefault();

            employerElement.Element("name").Value = UpdatedEmployer.FirstName;
            employerElement.Element("field").Value = Convert.ToString(UpdatedEmployer.Field);
            employerElement.Element("compagny").Value = Convert.ToString(UpdatedEmployer.CompagnieName);
            if(UpdatedEmployer.Compagny)
                employerElement.Element("compagnyName").Value = UpdatedEmployer.CompagnieName;
            else
                employerElement.Element("compagnyName").Value = null;
            employerElement.Element("adress").Value = UpdatedEmployer.Adress;
            employerElement.Element("dateCreation").Value = Convert.ToString(UpdatedEmployer.DateCreation);
            employerElement.Element("phoneNumber").Value = Convert.ToString(UpdatedEmployer.PhoneNumber);



            employersRoot.Save(employersPath);
        }

        public void AddEmployee(Employee employee)
        {
            XElement id = new XElement("id", employee.Id);
            XElement firstName = new XElement("firstName", employee.FirstName);
            XElement lastName = new XElement("lastName", employee.LastName);
            XElement birthday = new XElement("birthday", employee.Birthday);
            XElement degree = new XElement("degree", employee.Degree);
            XElement adress = new XElement("adress", employee.Adress);
            XElement military = new XElement("military", employee.MilitaryService);
            XElement phoneNumber = new XElement("phoneNumber", employee.PhoneNumber);
            XElement accountNumber = new XElement("AccountNumber", employee.Bankaccount.AccountNumber);
            XElement bankNumber = new XElement("BankNumber", employee.Bankaccount.BankNumber);
            XElement branchNumber = new XElement("BranchtNumber", employee.Bankaccount.BranchNumber);
            XElement branchAdress = new XElement("BranchAdress", employee.Bankaccount.BranchAdress);
            XElement branchCity = new XElement("BranchCity", employee.Bankaccount.BranchCity);
            XElement nameBank = new XElement("NameBank", employee.Bankaccount.NameBank);

            // BankAccount
            XElement bankAccount = new XElement("BankAccount", accountNumber, bankNumber, branchNumber, branchAdress, branchCity, nameBank);


            employeesRoot.Add(new XElement("employee", id, firstName, lastName, birthday, degree, adress, military, phoneNumber, bankAccount));
            employeesRoot.Save(employeesPath);
        }

        public void RemoverEmployee(Employee employee)
        {
            XElement employeeElement;
            try
            {
                employeeElement = (from p in employeesRoot.Elements()
                                         where Convert.ToInt32(p.Element("id").Value) == employee.Id
                                         select p).FirstOrDefault();
                employeeElement.Remove();
                employeesRoot.Save(employeesPath);
            }
            catch
            {
                throw new Exception("Error adding specialization");
            }
        }

        public void UpdateEnployee(Employee UpdatedEmployee)
        {
            XElement employeeElement = (from p in specializationsRoot.Elements()
                                              where Convert.ToInt32(p.Element("id").Value) == UpdatedEmployee.Id
                                              select p).FirstOrDefault();

            employeeElement.Element("firstname").Value = UpdatedEmployee.FirstName;
            employeeElement.Element("lastname").Value = UpdatedEmployee.LastName;
            employeeElement.Element("brithday").Value = Convert.ToString(UpdatedEmployee.Birthday);
            employeeElement.Element("degree").Value = Convert.ToString(UpdatedEmployee.Degree);
            employeeElement.Element("military").Value = Convert.ToString(UpdatedEmployee.MilitaryService);
            employeeElement.Element("adress").Value = UpdatedEmployee.Adress;
            employeeElement.Element("phoneNumber").Value = Convert.ToString(UpdatedEmployee.PhoneNumber);
            employeeElement.Element("BankAccount").Element("AccountNumber").Value = Convert.ToString(UpdatedEmployee.Bankaccount.AccountNumber);
            employeeElement.Element("BankAccount").Element("BankNumber").Value = Convert.ToString(UpdatedEmployee.Bankaccount.BankNumber);
            employeeElement.Element("BankAccount").Element("BranchNumber").Value = Convert.ToString(UpdatedEmployee.Bankaccount.BranchNumber);
            employeeElement.Element("BankAccount").Element("BranchAdress").Value = UpdatedEmployee.Bankaccount.BranchAdress;
            employeeElement.Element("BankAccount").Element("BranchCity").Value = UpdatedEmployee.Bankaccount.BranchCity;
            employeeElement.Element("BankAccount").Element("NameBank").Value = UpdatedEmployee.Bankaccount.NameBank;

            employeesRoot.Save(employeesPath);
        }

        public void AddContract(Contract contract)
        {
            XElement id = new XElement("id", contract.ContractID);
            XElement employerID = new XElement("employerID", contract.EmployerID);
            XElement employeeID = new XElement("employeeID", contract.EmployeeID);
            XElement interview = new XElement("interview", contract.Interview);
            XElement contractSignature = new XElement("contractSignature", contract.ContractSignature);
            XElement hourlyWageBrute = new XElement("hourlyWageBrute", contract.HourlyWageBrute);
            XElement hourlyWageNet = new XElement("hourlyWageNet", contract.HourlyWageNet);
            XElement startDate = new XElement("startDate", contract.StartContract);
            XElement endDate = new XElement("EndDate", contract.EndContract);

            contractsRoot.Add(new XElement("contract", id, employeeID, employerID, interview, contractSignature, hourlyWageBrute, hourlyWageNet, startDate, endDate));
            contractsRoot.Save(contractsPath);
        }

        public void RemoveContract(Contract contract)
        {
            XElement contractElement;
            try
            {
                contractElement = (from p in contractsRoot.Elements()
                                   where Convert.ToInt32(p.Element("id").Value) == contract.ContractID
                                   select p).FirstOrDefault();
                contractElement.Remove();
                contractsRoot.Save(contractsPath);
            }
            catch
            {
                throw new Exception("Error adding specialization");
            }
        }

        public void UpdateContract(Contract UpdatedContract)
        {
            XElement contractElement = (from p in employersRoot.Elements()
                                        where Convert.ToInt32(p.Element("id").Value) == UpdatedSpecialisation.SpecializationID
                                        select p).FirstOrDefault();

            contractElement.Element("employerID").Value = Convert.ToString(UpdatedContract.EmployerID);
            contractElement.Element("employeeID").Value = Convert.ToString(UpdatedContract.EmployeeID);
            contractElement.Element("interview").Value = Convert.ToString(UpdatedContract.Interview);
            contractElement.Element("contractSignature").Value = Convert.ToString(UpdatedContract.ContractSignature);
            contractElement.Element("hourlyWageBrute").Value = Convert.ToString(UpdatedContract.HourlyWageBrute);
            contractElement.Element("hourlyWageNet").Value = Convert.ToString(UpdatedContract.HourlyWageNet);
            contractElement.Element("startDate").Value = Convert.ToString(UpdatedContract.StartContract);
            contractElement.Element("endDate").Value = Convert.ToString(UpdatedContract.EndContract);



            contractsRoot.Save(contractsPath);
        }

        public List<BankAccount> ListBankBranches()
        {
            throw new NotImplementedException();
        }
    }
}
