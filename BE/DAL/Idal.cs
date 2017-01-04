using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        void AddSpecialization(Specialization specialisation);
		void RemoveSpecialization(Specialization specialisation);
        void UpdateSpecialization(Specialization UpdatedSpecialisation);

        /*
        void UpdateSpecializationName(string name);
        void UpdateSpecializatioMinHours(int minHours);
        void UpdateSpecializationMaxHours(int maxHours);
        void UpdateSpecialization(Specialization.NameField Field);
        */
		void AddEmployer(Employer employer);
		void RemoveEmployer(Employer employer);
        void UpdatedEmployer(Employer UpdatedEmployer);

        /*
        void UpdateEmployerCompagnie(bool Compagnie);
        void UpdateEmplouerFirstName(string FirstName);
        void UpdateEmployerCompagnieName(string CompagnieName);
        void UpdateEmployerPhoneNumber(int PhoneNumber);
        void UpdateEmployerAdress(string Adress);
        void UpdateEmployerField(Employer.NameField Field);
        void UpdateEmployerCreation(DateTime Creation);
        */

        void AddEmployee(Employee employee);
		void RemoverEmployee(Employee employee);
        void UpdateEnployee(Employee UpdatedEmployee);

        /*
        void UpdateEmployeeFirstName(string FirstName);
        void UpdateEmployeeLastName(string LastName);
        void UpdateEmployeeSpecialization(int SpecializationID);
        void UpdateEmployeeBirthday(DateTime Birthday);
        void UpdateEmployeePhoneName(int PhoneNumber);
        void UpdateEmployeeAdress(string Adress);
        void UpdateEmployeeDegree(Employee.Degree degree);
        void UpdateEmployeeBankAccount(BankAccount bankAccount);
        */

        void AddContract(Contract contract);
		void RemoveContract(Contract contract);
        void UpdateContract(Contract UpdatedContract);
        /*
        void UpdateContractEmployer(int EmployerID);
        void UpdateContractEmployee(int EMployeeID);
        void UpdateContractInterviw(bool Interview);
        void UpdateContractSignature(bool ContractSignature);
        void UpdateContractHourlyWageBrute(int HourlyWageBrute);
        void UpdateContractHourlyWageNet(int HourlyWageNet);
        void UpdateContractTimeStart(DateTime StartTime);
        void UpdateContractTimeStop(DateTime StopTime);
        */

        List<Specialization> ListSpecialzation { get; set;}
		List<Employee> ListEmployees { get; set;}
		List<Employer> ListEmployer { get; set;}
		List<Contract> ListContract { get; set;}

		List<BankAccount> ListBankBranches();
    }
}
