using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Specialization
    {
        private int scpecializationID;
        private string name;
        private int minHours;
        private int maxHours;

        public enum NameField { DataStructure, Networks, Security, MobileDevelopment };
        public NameField Field { get; set; }
        public int SpecializationID { get { return scpecializationID; } set { scpecializationID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int MinHours { get { return minHours; } set { minHours = value; } }
        public int MaxHours { get { return maxHours; } set{ maxHours = value; } }

        public override string ToString()
        {
            return "Name: " + Name + "\n" 
                + "ID: " + Convert.ToString(SpecializationID) + "\n"
                + "Field: " + Convert.ToString(Field) + "\n"
                + "Minimum hours: " + Convert.ToString(MinHours) + '\n'
                + "Maximum hours: " + Convert.ToString(MaxHours);
        }

        // Constructor
        public Specialization(string name,NameField field, int iDSpecialization, int minHours, int maxHours)
        {
            Name = name;
            Field = field;
            SpecializationID = iDSpecialization;
            MinHours = minHours;
            MaxHours = maxHours;
        }

    }
}
