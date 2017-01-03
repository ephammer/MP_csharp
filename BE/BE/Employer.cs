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
        public bool Compagnie { get; set; }
        public string FirstName { get; set; }
        public string CompagnieName { get; set; }
        public int PhoneNumber { get; set; }
        public string Adress { get; set; }
        public enum NameField { DataStructure, Networks, Security, MobileDevelopment };
        public NameField Field { get; set; }
        public DateTime DateCreation { get; set; }
        public override string ToString()
        {
            return CompagnieName;
        }

        public Employer(int id, bool compagnie, string firstName, string compagnieName,
            int phoneNumber, string adress, NameField field, DateTime dateCreation)
        {
            Id = id;
            Compagnie = compagnie;
            FirstName = firstName;
            CompagnieName = compagnieName;
            PhoneNumber = phoneNumber;
            Adress = adress;
            Field = field;
            DateCreation = dateCreation;
        }
    }
}
