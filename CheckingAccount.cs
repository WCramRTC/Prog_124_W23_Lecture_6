using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prog_124_W23_Lecture_6
{
    class CheckingAccount : Account
    {

        decimal _overdraftFee;

        public CheckingAccount(string firstName, string lastName, decimal balance, decimal overdraftFee) : base(firstName, lastName, balance)
        {
            _overdraftFee = overdraftFee;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount < Balance)
            {
                Balance -= amount;
            }
            else
            {
                Balance -= _overdraftFee;
                MessageBox.Show("You have been overdrawn");
            }

        }


        // Override ToString
        public override string ToString()
        {
            return base.ToString() + $" - OverDraft Fee {_overdraftFee}";
        }

    }
}
