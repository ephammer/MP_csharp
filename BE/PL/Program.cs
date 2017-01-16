using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL bll = new BLL();

            Console.WriteLine("Welcome to the Contract managing tool\n");
            Console.WriteLine("Date: " + DateTime.Now);

            Console.WriteLine("Please choose one of the following option:");
            Console.WriteLine("0 - Exit\n" + "1 - Add new Employer\n" + "2 - Add new Employee\n" );

            int input = Convert.ToInt32(Console.ReadLine());

            do
            {
                switch (input)
                {
                    case 0: return;

                    case 1: AddEmployer();
                        Console.WriteLine("Your added a new Employer\n");
                        Console.WriteLine(bll.printListEmployer());
                        break;

                    case 2:// bll.AddEmployee();
                        Console.WriteLine("Your added a new Employee\n");
                        break;
                    default: return;
                }

                Console.WriteLine("Please choose one of the following option:");
                Console.WriteLine("0 - Exit\n" + "1 - Add new Employer\n " + "2 - Add new Employee\n");
                input = Convert.ToInt32(Console.ReadLine());


            } while (true);

            void AddEmployer()
            {
                Console.WriteLine("ID:");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Does the Employer have a compagnie?");
                var compagnie = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("First name:");
                var name = Console.ReadLine();

                string compagnieName;

                if (compagnie)
                {
                    Console.WriteLine("Name of the compagnie:");
                    compagnieName = Console.ReadLine();
                }
                else
                    compagnieName = null;

                Console.WriteLine("Phone number:");
                var phoneNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Adress:");
                var adress = Console.ReadLine();

                bll.AddEmployer(
                           new BE.Employer(
                               id,
                              compagnie,
                               name,
                               compagnieName,
                               phoneNumber,
                               adress,
                               Employer.NameField.DataStructure,
                               DateTime.Now
                               )
                               );
            }
        }

        
    }
}
