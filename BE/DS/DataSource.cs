using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DS
{
    
    public class DataSource
    {
        public static List<Specialization> listSpecialzation { get; set; }
        public static List<Employee> listEmployees { get; set; }
        public static List<Employer> listEmployer { get; set; }
        public static List<Contract> listContract { get; set; }

        public DataSource()
        {
            listSpecialzation = new List<Specialization>();
            listEmployees = new List<Employee>();
            listEmployer = new List<Employer>();
            listContract = new List<Contract>();
        }
    }
}
