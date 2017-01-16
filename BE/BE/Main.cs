using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Main
    {
    }

    public struct BankAccount
    {
        public int BankNumber { get; set; }
        public string NameBank { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAdress { get; set; }
        public string BranchCity { get; set; }
        public int AccountNumber { get; set; }

        public override string ToString()
        {
            return "Bank number: " + Convert.ToString(BankNumber) + '\n'
                + "Name of bank: " + NameBank + '\n'
                + "Branch number: " + Convert.ToString(BranchNumber) + '\n'
                + "Branch Adress: " + BranchAdress + '\n'
                + "Branch City: " + BranchCity + '\n'
                + "Account number" + Convert.ToString(AccountNumber);

        }
        public BankAccount(
            int BankNumber,
            string NameBank,
            int BranchNumber, 
            string BranchAdress,
            string BranchCity,
            int AccountNumber)
        {
            this.BankNumber = BankNumber;
            this.NameBank = NameBank;
            this.BranchNumber = BranchNumber;
            this.BranchAdress = BranchAdress;
            this.BranchCity = BranchCity;
            this.AccountNumber = AccountNumber;

        }
    }
}
