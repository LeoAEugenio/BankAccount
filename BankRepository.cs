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

    class BankRepository
    {
        Client Client = new Client();

        BankDetails BankDetails = new BankDetails();

        BankUpdater BankUpdater = new BankUpdater();

        BankService BankService = new BankService();

        public async Task Newaccount()
        {
            Console.WriteLine("Inform your bank details below:\n");

            do
            {
                Console.WriteLine("Enter your name: ");
                Client.Name = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(Client.Name))
                {
                    Console.WriteLine("Please, enter a valid name..");
                }
            } while (string.IsNullOrWhiteSpace(Client.Name));

            int age;
            do
            {
                Console.WriteLine("Enter your age: ");
                if (!int.TryParse(Console.ReadLine(), out age) || age < 18)
                {
                    Console.WriteLine("You must be over 18 to create an account...");
                    return;
                }

                Client.Age = age;

            } while (Client.Age < 18);

            do
            {
                Console.WriteLine("Enter your nationality: ");
                Client.Nationality = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(Client.Nationality))
                {
                    Console.WriteLine("Please, enter a valid nationality..");
                }
            } while (string.IsNullOrWhiteSpace(Client.Nationality));

            do
            {
                Console.WriteLine("Enter your account number: ");
                BankDetails.AccountNumber = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(BankDetails.AccountNumber))
                {
                    Console.WriteLine("Please, enter a valid account number..");
                }
            } while (string.IsNullOrWhiteSpace(BankDetails.AccountNumber));

            do
            {
                Console.WriteLine("Enter your agency number: ");
                BankDetails.Agency = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(BankDetails.Agency))
                {
                    Console.WriteLine("Please, enter a valid agency number..");
                }
            } while (string.IsNullOrWhiteSpace(BankDetails.Agency));

            do
            {
                Console.WriteLine("Enter your password: ");
                BankDetails.Password = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(BankDetails.Password))
                {
                    Console.WriteLine("Please, enter a valid password..");
                }
            } while (string.IsNullOrWhiteSpace(BankDetails.Password));

            int Moneyinput;
            do
            {
                Console.WriteLine("Enter the amount of money you would like to deposit: ");

                if (!int.TryParse(Console.ReadLine(), out Moneyinput) || Moneyinput <= 0)
                {
                    Console.WriteLine("Please, enter a valid amount..");
                }

                BankDetails.MoneyAmount = Moneyinput;

            } while (BankDetails.MoneyAmount <= 0);

            var DBPath =
            "Server=DESKTOP-6UQP3HM;Database=BankAccount;" +
            "Trusted_Connection=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

            var sqlInsert = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "CreateAccount.sql")
            );

            using var connection = new  SqlConnection(DBPath);
            using var command = new SqlCommand(sqlInsert, connection);

            command.Parameters.AddWithValue("@name", Client.Name);
            command.Parameters.AddWithValue("@age", Client.Age);
            command.Parameters.AddWithValue("@nationality", Client.Nationality);
            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);
            command.Parameters.AddWithValue("@agency", BankDetails.Agency);
            command.Parameters.AddWithValue("@password", BankDetails.Password);
            command.Parameters.AddWithValue("@moneyamount", BankDetails.MoneyAmount);

            connection.Open();
            int response = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (response == 1)
            {
                Console.WriteLine("\nClient Details entered successfully!\n");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
                return;
            }
        }

        public async Task Updateaccount()
        {
            int input;
            do
            {
                Console.WriteLine("What would you like to update?:\n \n1)Name\n2)Age\n3)Nationality\n4)Account Number\n5)Agency\n6)Password\n7)Return to menu\n");

                if (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
                {
                    Console.WriteLine("Enter a valid option..");
                    return;
                }
            } while (input <= 0);

            UpdateOptions options = (UpdateOptions)input;

            switch (options)
            {
                case UpdateOptions.Name:
                    await BankUpdater.Updatename();
                    break;
                case UpdateOptions.Age:
                    await BankUpdater.UpdateAge();
                    break;
                case UpdateOptions.Nationality:
                    await BankUpdater.UpdateNationality();
                    break;
                case UpdateOptions.AccountNumber:
                    await BankUpdater.UpdateAccountNumber();
                    break;
                case UpdateOptions.Agency:
                    await BankUpdater.UpdateAgency();
                    break;
                case UpdateOptions.Password:
                    await BankUpdater.UpdatePassword();
                    break;
                default:
                    Console.WriteLine("Option not found..");
                    break;
            }
        }
    }
}