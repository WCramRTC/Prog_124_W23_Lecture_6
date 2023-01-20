using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_W23_Lecture_6
{
    class Account
    {
        string _accountNumber;
        string _firstName;
        string _lastName;
        decimal _balance;

        public Account(string firstName, string lastName, decimal balance)
        {
            Random rand = new Random();

            _accountNumber = rand.Next(100000000, 1000000000).ToString();
            _firstName = firstName;
            _lastName = lastName;
            _balance = balance;
        }

        public string AccountNumber { get => _accountNumber;}
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public decimal Balance { get => _balance; protected set => _balance = value; }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        // Virtual
        public virtual void Withdraw(decimal amount)
        {
            _balance -= amount;
        }


        // Override
        public override string ToString()
        {
            // Account Number - Type - Full Name - Balance Formatted

            return $"{AccountNumber} - {GetType().Name} - {FirstName} {LastName} - Balance {Balance.ToString("c")}";
        }

    }
}
