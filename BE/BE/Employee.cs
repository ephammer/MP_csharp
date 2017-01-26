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
        public int SpecializationID { get; set; }
        public DateTime Birthday { get; set; }
        public int PhoneNumber { get; set; }
        public string Adress { get; set; }
        public enum Degrees { Certificate,Bachelor,Master,Phd,Student};
        public Degrees Degree { get; set; }
        public bool MilitaryService { get; set; }
        public BankAccount Bankaccount { get; set; }
        public override string ToString()
        {
            return "First Name: " + FirstName + '\n' 
                + "Last Name: " + LastName + '\n'
                + "ID: " + Convert.ToString(Id) + '\n'
                + "Birthday: " + Convert.ToString(Birthday) +'\n'
                + "Specialization: " + Convert.ToString(SpecializationID) + '\n'
                + "PhoneNumber: " + Convert.ToString(PhoneNumber) + '\n'
                + "Adress: " + Adress + '\n'
                + "Degree: " + Convert.ToString(Degree) + '\n'
                + "Military service: " + Convert.ToString(MilitaryService) + '\n'
                + "BankAccount" + Convert.ToString(Bankaccount);
        }

        public Employee()
        {

        }
        public Employee(int id, string firstName, string lastName, DateTime birthday, 
            int phoneNumber, string adress, Degrees degree, int specialization,
            bool militaryService, BankAccount bankAccount)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
            Adress = adress;
            this.Degree = degree;
            this.SpecializationID = specialization;
            MilitaryService = militaryService;
            this.Bankaccount = bankAccount;
        }
    }
}
