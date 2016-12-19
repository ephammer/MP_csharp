using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Specialization
    {
        int NbProfessionals { get; set; }
        enum NameField {DataStructure,Networks, Security, MobileDevelopment };

        string Name { get; set; }

        int MinHours { get; set; }
        int MaxHours { get; set; }

        public override string ToString()
        {
            return Name;
        }


    }
}
