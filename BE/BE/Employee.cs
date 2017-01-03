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

        public DateTime Birthday { get; set; }
        public int PhoneNumber { get; set; }
        public string Adress { get; set; }
        public enum Degree { Certificate,Bachelor,Master,Phd,Student};
        public Degree degree { get; set; }
        public bool MilitaryService { get; set; }
        public BankAccount bankAccount { get; set; }
        public override string ToString()
        {
            return FirstName + ' ' + LastName;
        }

        public Employee(int id, string firstName, string lastName, DateTime birthday, 
            int phoneNumber, string adress, Degree degree, bool militaryService, BankAccount bankAccount)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
            this.degree = degree;
            MilitaryService = militaryService;
            this.bankAccount = bankAccount;
        }
    }
}
