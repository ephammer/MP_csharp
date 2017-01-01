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
        int BankNumber { get; set; }
        string NameBank { get; set; }
        int BranchNumber { get; set; }
        string BranchAdress { get; set; }
        string BranchCity { get; set; }
        int AccountNumber { get; set; }

        BankAccount(
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
