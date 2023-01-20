using Prog_124_W23_Lecture_6.Examples.BankingApp;
using Prog_124_W23_Lecture_6.Examples.Inheirtance_Display;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog_124_W23_Lecture_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int year = 2000;
        // Observable Collection <T>
        ObservableCollection<Account> accounts = new ObservableCollection<Account>();

        public MainWindow()
        {
            InitializeComponent();
            HideCanvas();
            ShowSavings();

            lblYear.Content = year.ToString();

            // listBoxName.ItemsSource = collectionName
            lbAccounts.ItemsSource = accounts;

        }

        // Event to add a new Account
        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            decimal amount = ValidateMoney(txtBalance.Text);
            CheckingAccount account = null;

            if (rbChecking.IsChecked.Value)
            {
                decimal overDraft = ValidateMoney(txtODFee.Text);
                account = new CheckingAccount(fName, lName, amount , overDraft);
            }

            

            accounts.Add(account);
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = ValidateMoney(txtAmount.Text);

        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = ValidateMoney(txtAmount.Text);

            // Validates if an account is selected
            if(lbAccounts.SelectedIndex != -1)
            {
                int index = lbAccounts.SelectedIndex;
                Account account = accounts[index];

                account.Withdraw(amount);
                lbAccounts.Items.Refresh();
            }


        }

        private void btnAdvanceAYear_Click(object sender, RoutedEventArgs e)
        {
            lblYear.Content = year++ + "";

        }

        public decimal ValidateMoney(string amount)
        {
            decimal money = 0;

            if (!decimal.TryParse(amount, out money))
            {
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

        private void btnPachinko_Click(object sender, RoutedEventArgs e)
        {
            new Inheritance_Example().Show();
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
