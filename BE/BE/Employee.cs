using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization Specialization { get; set; }
        public DateTime Birthday { get; set; }
        public int PhoneNumber { get; set; }
        public string Adress { get; set; }
        public enum Degree { Certificate,Bachelor,Master,Phd,Student};
        public Degree degree { get; set; }
        public bool MilitaryService { get; set; }
        public BankAccount bankAccount { get; set; }
        public override string ToString()
        {
            return "First Name: " + FirstName + '\n' 
                + "Last Name: " + LastName + '\n'
                + "ID: " + Convert.ToString(Id) + '\n'
                + "Birthday: " + Convert.ToString(Birthday) +'\n'
                + "Specialization: " + Convert.ToString(Specialization) + '\n'
                + "PhoneNumber: " + Convert.ToString(PhoneNumber) + '\n'
                + "Adress: " + Adress + '\n'
                + "Degree: " + Convert.ToString(degree) + '\n'
                + "Military service: " + Convert.ToString(MilitaryService) + '\n'
                + "BankAccount" + Convert.ToString(bankAccount);
        }

        public Employee(int id, string firstName, string lastName, DateTime birthday, 
            int phoneNumber, string adress, Degree degree, Specialization specialization,
            bool militaryService, BankAccount bankAccount)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
            this.degree = degree;
            this.Specialization = specialization;
            MilitaryService = militaryService;
            this.bankAccount = bankAccount;
        }
    }
}
