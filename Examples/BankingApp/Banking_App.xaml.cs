using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prog_124_W23_Lecture_6.Examples.BankingApp
{
    /// <summary>
    /// Interaction logic for Banking_App.xaml
    /// </summary>
    public partial class Banking_App : Window
    {
        int year = 2000;

        ObservableCollection<Account> accounts = new ObservableCollection<Account>();

        public Banking_App()
        {
            InitializeComponent();
            HideCanvas();
            ShowSavings();

            lblYear.Content = year.ToString();

            lbAccounts.ItemsSource = accounts;
        }


        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            decimal amount = ValidateMoney(txtBalance.Text);

            accounts.Add(new Account(fName, lName, amount));
            MessageBox.Show("This works");

        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = ValidateMoney(txtAmount.Text);

        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = ValidateMoney(txtAmount.Text);

        }

        private void btnAdvanceAYear_Click(object sender, RoutedEventArgs e)
        {
            lblYear.Content = year++ + "";
            
        }

        public decimal ValidateMoney(string amount)
        {
            decimal money = 0;

            if(!decimal.TryParse(amount, out money)) {
                return 0;
            }

            return money;
        }

        public void HideCanvas()
        {
            canChecking.Visibility = Visibility.Hidden;
            canSavings.Visibility = Visibility.Hidden;
        }

        public void ShowChecking()
        {
            canChecking.Visibility = Visibility.Visible;
        }

        public void ShowSavings()
        {
            canSavings.Visibility = Visibility.Visible;
        }


        private void SwitchPanels(object sender, RoutedEventArgs e)
        {
            HideCanvas();

            if (rbSavings.IsChecked.Value)
            {
                ShowSavings();
            }
            else
            {
                ShowChecking();
            }
        }
    }
}
