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
            Console.WriteLine("0 - Exit\n" + "1 - Add new Employer\n" + "2 - Add new Employee\n" + "3 - Add new Contract\n");

            int input = Convert.ToInt32(Console.ReadLine());

            do
            {
                switch (input)
                {
                    case 0: return;

                    case 1: AddEmployer();
                        Console.WriteLine("Your added a new Employer\n");
                        Console.WriteLine(bll.PrintListEmployer());
                        break;

                    case 2: AddEmployee();
                        Console.WriteLine("Your added a new Employee\n");
                        Console.WriteLine(bll.PrintListEmployee());
                        break;

                    case 3: AddContract();
                        Console.WriteLine("You added a new Contract");
                        Console.WriteLine(bll.PrintListContracts());
                        break;

                    default: return;
                }

                Console.WriteLine("Please choose one of the following option:");
                Console.WriteLine("0 - Exit\n" + "1 - Add new Employer\n" + "2 - Add new Employee\n" + "3 - Add new Contract\n");
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
                try
                {
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
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            void AddEmployee()
            {
                Console.WriteLine("ID: ");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("First name: ");
                var firstName = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Last Name");
                var lastName = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Date of Birth in the following format dd/mm/yyyy :");
                var birthday = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Phone number: ");
                var phone = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Adress: ");
                var adress = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Enter Specialization id:");
                var sID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Did the employee do his Military Service?");
                var military = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("BankAccount details:");
                Console.WriteLine("BankAccount number:");
                var baNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("BankAccount name:");
                var baName = Convert.ToString(Console.ReadLine());

                Console.WriteLine("BankAccount branch number:");
                var baBranchNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("BankAccount branch adress:");
                var baBranchAdress = Convert.ToString(Console.ReadLine());

                Console.WriteLine("BankAccount branch city:");
                var baBranchCity = Convert.ToString(Console.ReadLine());

                Console.WriteLine("BankAccount Account number:");
                var baAccountNumber = Convert.ToInt32(Console.ReadLine());

                try
                {
                    bll.AddEmployee(
                        new Employee(
                            id,
                            firstName,
                            lastName,
                            birthday,
                            phone,
                            adress,
                            Employee.Degrees.Bachelor,
                            sID,
                            military,
                            new BankAccount(
                                baNumber,
                                baName,
                                baBranchNumber,
                                baBranchAdress,
                                baBranchCity,
                                baAccountNumber))
                            );
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
               
            void AddContract()
            {
                Console.WriteLine("Enter the contract ID:");
                var iD = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the employers ID:");
                var employerID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the employees ID:");
                var employeeID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Was there an interview?");
                var interview = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("Was there a contract signature?");
                var signature = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("Enter the hourly wage brute:");
                var hourlyWageBrut = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the hourly wage net:");
                var hourlyWageNet = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("When does the contract start?");
                var contractStart = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("When does the contract stop?");
                var contractStop = Convert.ToDateTime(Console.ReadLine());

                try
                {
                    bll.AddContract(
                        new Contract(
                            iD,
                            employerID,
                            employeeID,
                            interview,
                            signature,
                            hourlyWageBrut,
                            hourlyWageNet,
                            contractStart,
                            contractStop
                        ));
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        
    }
}
