using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employer
    {
        public int Id { get; set; }
        public bool Compagny { get; set; }
        public string FirstName { get; set; }
        public string CompagnieName { get; set; }
        public int PhoneNumber { get; set; }
        public string Adress { get; set; }
        public enum NameField { DataStructure, Networks, Security, MobileDevelopment };
        public NameField Field { get; set; }
        public DateTime DateCreation { get; set; }
        public override string ToString()
        {
            string employer = null;
            employer += "ID: " + Id + '\n';
            employer += "First name: " + FirstName + '\n';
            if (Compagny)
                employer += "Compagnie: " + CompagnieName + '\n';
            employer += "Phone number: " + PhoneNumber + '\n'
                + "Adress: " + Adress + '\n'
                + "Field: " + Convert.ToString(Field) + '\n'
                + "Date of creation: " + Convert.ToString(DateCreation) + '\n';
            return employer;
        }

        public Employer()
        {

        }

        public Employer(int id, bool compagnie, string firstName, string compagnieName,
            int phoneNumber, string adress, NameField field, DateTime dateCreation)
        {
            Id = id;
            Compagny = compagnie;
            FirstName = firstName;
            CompagnieName = compagnieName;
            PhoneNumber = phoneNumber;
            Adress = adress;
            Field = field;
            DateCreation = dateCreation;
        }
    }
}
