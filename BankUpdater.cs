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
    class BankUpdater
    {
        BankDetails BankDetails = new BankDetails();
        public async Task Updatename()
        {
            string Newname;
            do
            {
                Console.WriteLine("Enter a new name: ");
                Newname = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(Newname))
                {
                    Console.WriteLine("Enter a valid name...");
                }
            } while (string.IsNullOrWhiteSpace(Newname));

            do
            {
                Console.WriteLine("Enter your Account Number: ");
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

            var sqlUpdateName = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "Updatename.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlUpdateName, connection);

            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);
            command.Parameters.AddWithValue("@newname", Newname);


            connection.Open();
            int result = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (result == 1)
            {
                Console.WriteLine($"Name updated successfully. New name: {Newname}.");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
            }
        }

        public async Task UpdateAge()
        {
            int Newage;
            do
            {
                Console.WriteLine("Enter a new age: ");

                if (!int.TryParse(Console.ReadLine(), out Newage) && Newage <= 0)
                {
                    Console.WriteLine("Enter a valid age...");
                }
            } while (Newage <= 0);

            do
            {
                Console.WriteLine("Enter your Account Number: ");
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

            var sqlUpdateAge = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "Updateage.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlUpdateAge, connection);

            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);
            command.Parameters.AddWithValue("@newage", Newage);

            connection.Open();
            int result = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (result == 1)
            {
                Console.WriteLine($"Age updated successfully. New name: {Newage}.");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
            }
        }

        public async Task UpdateNationality()
        {
            string Newnationality;
            do
            {
                Console.WriteLine("Enter a new nationality: ");
                Newnationality = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(Newnationality))
                {
                    Console.WriteLine("Enter a valid nationality...");
                }
            } while (string.IsNullOrWhiteSpace(Newnationality));

            do
            {
                Console.WriteLine("Enter your Account Number: ");
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

            var sqlUpdateNationality = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "Updatenationality.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlUpdateNationality, connection);

            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);
            command.Parameters.AddWithValue("@newnationality", Newnationality);

            connection.Open();
            int result = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (result == 1)
            {
                Console.WriteLine($"Age updated successfully. New name: {Newnationality}.");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
            }
        }

        public async Task UpdateAccountNumber()
        {
            string Newaccountnumber;
            do
            {
                Console.WriteLine("Enter a new Account Number: ");
                Newaccountnumber = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(Newaccountnumber))
                {
                    Console.WriteLine("Enter a valid Account Number...");
                }
            } while (string.IsNullOrWhiteSpace(Newaccountnumber));

            do
            {
                Console.WriteLine("Enter your password: ");
                BankDetails.Password = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(BankDetails.Password))
                {
                    Console.WriteLine("Enter a valid password...");
                }
            } while (string.IsNullOrWhiteSpace(BankDetails.Password));

            var DBPath =
            "Server=DESKTOP-6UQP3HM;Database=BankAccount;" +
            "Trusted_Connection=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

            var sqlUpdateAccountNumber = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "Updateaccountnumber.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlUpdateAccountNumber, connection);

            command.Parameters.AddWithValue("@password", BankDetails.Password);
            command.Parameters.AddWithValue("@newaccountnumber", Newaccountnumber);

            connection.Open();
            int result = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (result == 1)
            {
                Console.WriteLine($"Age updated successfully. New name: {Newaccountnumber}.");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
            }
        }

        public async Task UpdateAgency()
        {
            string Newagency;
            do
            {
                Console.WriteLine("Enter a new agency: ");
                Newagency = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(Newagency))
                {
                    Console.WriteLine("Enter a valid agency...");
                }
            } while (string.IsNullOrWhiteSpace(Newagency));

            do
            {
                Console.WriteLine("Enter your Account Number: ");
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

            var sqlUpdateAgency = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "Updateagency.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlUpdateAgency, connection);

            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);
            command.Parameters.AddWithValue("@newagency", Newagency);

            connection.Open();
            int result = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (result == 1)
            {
                Console.WriteLine($"Age updated successfully. New name: {Newagency}.");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
            }
        }

        public async Task UpdatePassword()
        {
            string Newpassword;
            do
            {
                Console.WriteLine("Enter a new password: ");
                Newpassword = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(Newpassword))
                {
                    Console.WriteLine("Enter a valid password...");
                }
            } while (string.IsNullOrWhiteSpace(Newpassword));

            do
            {
                Console.WriteLine("Enter your Account Number: ");
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

            var sqlUpdatePassword = File.ReadAllText(
                Path.Combine(AppContext.BaseDirectory, "sql", "Updatepassword.sql")
            );

            using var connection = new SqlConnection(DBPath);
            using var command = new SqlCommand(sqlUpdatePassword, connection);

            command.Parameters.AddWithValue("@accountnumber", BankDetails.AccountNumber);
            command.Parameters.AddWithValue("@password", Newpassword);

            connection.Open();
            int result = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (result == 1)
            {
                Console.WriteLine($"Age updated successfully. New name: {Newpassword}.");
            }
            else
            {
                Console.WriteLine("Something went wrong, try it again..");
            }
        }
    }
}








