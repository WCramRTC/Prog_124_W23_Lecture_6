using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_W23_Lecture_6.Examples.BankingApp
{
    internal class Account
    {
        string _id;
        string _firstName;
        string _lastName;
        decimal _balance;

        public Account(string firstName, string lastName, decimal balance)
        {
            Random rand = new Random();

            _id = rand.Next(100000000, 1000000000).ToString();

            _firstName = firstName;
            _lastName = lastName;
            _balance = balance;
        }

        public string Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public decimal Balance { get => _balance;  }

        public override string ToString()
        {
            return $"{_id} - {GetType().Name} - {FirstName} {LastName} - {Balance.ToString("c")}";
        }
    }
}
