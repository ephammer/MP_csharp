using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employee
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

        DateTime Birthday { get; set; }
        int PhoneNumber { get; set; }
        string Adress { get; set; }
        enum Degree { Certificate,Bachelor,Master,Phd,Student};
        Boolean MilitaryService { get; set; }
        BankAccount bankAccount { get; set; }
        public override string ToString()
        {
            return FirstName + ' ' + LastName;
        }
    }
}
