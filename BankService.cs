using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace BankAccount
{
    class BankService
    {

        Client Client = new Client();

        BankDetails BankDetails = new BankDetails();
        public async Task Withdraw()
        {
            int withdrawAmount;
            do
            {
                Console.WriteLine("How munch would you like to withdraw?\n");
                if (!int.TryParse(Console.ReadLine(), out withdrawAmount) || withdrawAmount <= 0)
                {
                    Console.WriteLine("Please, enter a valid amount..");
                }
            } while (withdrawAmount <= 0);

            do
            {
                Console.WriteLine("Enter your account number: ");
                BankDetails.AccountNumber = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(BankDetails.AccountNumber))
                {
                    Console.WriteLine("Please, enter a valid account number..");
                }
            } while (string.IsNullOrWhiteSpace(BankDetails.AccountNumber));

            var DBPath =
            "Server=DESKTOP-6UQP3HM;Database=BankAccount;" +
            "Trusted_Connection=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

            var sqlSelectWithdraw = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "sqlSelectWithdraw&Deposit.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlSelectWithdraw, connection);

            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);

            connection.Open();
            Object? result = await command.ExecuteScalarAsync();



            if (result == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            int currentBalance = Convert.ToInt32(result);


            if (currentBalance < withdrawAmount)
            {
                Console.WriteLine("Insufficient funds...");
                return;
            }

            int Newbalance = currentBalance - withdrawAmount;

            var sqlUpdateWithdraw = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "sqlUpdateWithdraw&Deposit.sql")
            );

            using var updatecommand = new SqlCommand(sqlUpdateWithdraw, connection);

            updatecommand.Parameters.AddWithValue("@newbalance", Newbalance);
            updatecommand.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);

            int updateResult = await updatecommand.ExecuteNonQueryAsync();

            if (updateResult == 1)
            {
                Console.WriteLine($"\nWithdraw successfull. New balance R${Newbalance}\n");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again...");
            }
        }

        public async Task Deposit()
        {
            int depositAmount;
            do
            {
                Console.WriteLine("How much would you like to deposit? \n");
                if (!int.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
                {
                    Console.WriteLine("Enter a valid amount.. ");
                }
            } while (depositAmount <= 0);

            do
            {
                Console.WriteLine("Enter your account number: \n");
                BankDetails.AccountNumber = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(BankDetails.AccountNumber))
                {
                    Console.WriteLine("Please, enter a valid account number..");
                }
            } while (string.IsNullOrWhiteSpace(BankDetails.AccountNumber));

            var DBPath =
                "Server=DESKTOP-6UQP3HM;Database=BankAccount;" +
                "Trusted_Connection=True;" +
                "Encrypt=True;" +
                "TrustServerCertificate=True;";

            using var connection = new SqlConnection(DBPath);
            await connection.OpenAsync();

            var sqlSelectDeposit = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "sqlSelectWithdraw&Deposit.sql")
            );

            using var selectCommand = new SqlCommand(sqlSelectDeposit, connection);
            selectCommand.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);

            object? result = await selectCommand.ExecuteScalarAsync();

            if (result == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            int currentBalance = Convert.ToInt32(result);

            int newBalance = currentBalance + depositAmount;

            var sqlUpdateDeposit = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "sqlUpdateWithdraw&Deposit.sql")
            );

            using var updateCommand = new SqlCommand(sqlUpdateDeposit, connection);
            updateCommand.Parameters.AddWithValue("@newbalance", newBalance);
            updateCommand.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);

            int updateResult = await updateCommand.ExecuteNonQueryAsync();

            if (updateResult == 1)
            {
                Console.WriteLine($"\nDeposit made successfully. New balance: R${newBalance}\n");
            }
            else
            {
                Console.WriteLine("Something went wrong, try again..");
            }
        }

        public async Task DeleteAccount()
        {
            do
            {
                Console.WriteLine("Enter your Account Number: \n");
                BankDetails.AccountNumber = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(BankDetails.AccountNumber))
                {
                    Console.WriteLine("Enter a valid account number...");
                }
            } while (string.IsNullOrWhiteSpace(BankDetails.AccountNumber));

            var DBPath =
            "Server=DESKTOP-6UQP3HM;Database=BankAccount;" +
            "Trusted_Connection=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

            var sqlUpdate = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "SqlDelete.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlUpdate, connection);

            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);

            connection.Open();
            int result = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (result == 1)
            {
                Console.WriteLine("\nAccount deleted successfully.\n");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
            }
        }

    }
}