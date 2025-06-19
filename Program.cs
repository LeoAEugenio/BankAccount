using System;
using System.Linq.Expressions;

namespace BankAccount
{
    class Program
    {
        static async Task Main(string[] args)
        {          
            BankRunner BankRunner = new BankRunner();
            BankRunner.Welcome();
            bool exit = false;
            
            while (!exit)
            {
                exit = await BankRunner.Executer();
            }
            
        }
    }
}