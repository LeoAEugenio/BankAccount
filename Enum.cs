using System;

namespace BankAccount
{
    public enum UpdateOptions
    {
        Name = 1,
        Age,
        Nationality,
        AccountNumber,
        Agency,
        Password,
        Returnmenu
    }

    public enum MenuOptions
    {
        CreateAccount = 1,
        UpdateAccount,
        Withdraw,
        Deposit,
        Delete,
        Exit
    }
}