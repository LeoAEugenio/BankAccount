using System;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace BankAccount
{
    class BankRunner
    {
        BankRepository BankRepository = new BankRepository();
        BankService BankService = new BankService();

        public void Welcome()
        {
            string banner = @"
            ██     ██  █████  ████████ ███████ ██████     ██     ██ ██ ███    ██ ███████ 
            ██     ██ ██   ██    ██    ██      ██   ██    ██     ██ ██ ████   ██ ██      
            ██  █  ██ ███████    ██    █████   ██████     ██  █  ██ ██ ██ ██  ██ █████   
            ██ ███ ██ ██   ██    ██    ██      ██   ██    ██ ███ ██ ██ ██  ██ ██ ██      
            ███   ███ ██   ██    ██    ███████ ██   ██     ███ ███  ██ ██   ████ ███████ 

            ██████    █████  ███    ██ ██   ██ 
            ██   ██  ██   ██ ████   ██ ██  ██  
            ██████   ███████ ██ ██  ██ █████   
            ██   ██  ██   ██ ██  ██ ██ ██  ██  
            ██████   ██   ██ ██   ████ ██   ██
            ";

            Console.WriteLine(banner);

            Console.WriteLine("Welcome to WaterWine Bank\n");
        }


        public async Task<bool> Executer()
        {
            String line = new string('-', 50);

            Console.WriteLine(line);
            
            int input;
            do
            {
                Console.WriteLine("\nWhat would you like to do now?\n\n1)Create an account\n2)Update existing account\n3)Withdraw balance\n4)Deposit balance\n5)Delete existing account\n6)Exit");

                if (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
                {
                    Console.WriteLine("Enter a valid option.");
                }
            } while (input <= 0);

            MenuOptions menuOptions = (MenuOptions)input;

            switch (menuOptions)
            {
                case MenuOptions.CreateAccount:
                    await BankRepository.Newaccount();
                    break;
                case MenuOptions.UpdateAccount:
                    await BankRepository.Updateaccount();
                    break;
                case MenuOptions.Withdraw:
                    await BankService.Withdraw();
                    break;
                case MenuOptions.Deposit:
                    await BankService.Deposit();
                    break;
                case MenuOptions.Delete:
                    await BankService.DeleteAccount();
                    break;
                case MenuOptions.Exit:
                    return true;
            }
            return false;

        }
    }
}