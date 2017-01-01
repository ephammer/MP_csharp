using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Employer
    {
        int Id { get; set; }
        bool Compagnie { get; set; }
        string FirstName { get; set; }
        string CompagnieName { get; set; }
        int PhoneNumber { get; set; }
        string Adress { get; set; }
        enum NameField { DataStructure, Networks, Security, MobileDevelopment };
        DateTime DateCreation { get; set; }
        public override string ToString()
        {
            return CompagnieName;
        }
    }
}
