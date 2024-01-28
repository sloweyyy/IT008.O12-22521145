using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            InitializeComponent();
        }

        private class Account
        {
            public string AccountNumber { get; set; }
            public string CustomerName { get; set; }
            public string Address { get; set; }
            public decimal Balance { get; set; }
        }

        private List<Account> accounts = new List<Account>();

        private void AddOrUpdateButton_Click(object sender, EventArgs e)
        {
            string accountNumber = accountNumberTextBox.Text;
            string customerName = customerNameTextBox.Text;
            string address = addressTextBox.Text;
            if (string.IsNullOrWhiteSpace(accountNumber) || string.IsNullOrWhiteSpace(customerName) ||
                string.IsNullOrWhiteSpace(address) || !decimal.TryParse(balanceTextBox.Text, out decimal balance))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            Account existingAccount = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (existingAccount == null)
            {
                Account newAccount = new Account
                {
                    AccountNumber = accountNumber,
                    CustomerName = customerName,
                    Address = address,
                    Balance = balance
                };
                accounts.Add(newAccount);
                AddAccountToListView(newAccount);
                MessageBox.Show("Thêm mới dữ liệu thành công!");
            }
            else
            {
                existingAccount.CustomerName = customerName;
                existingAccount.Address = address;
                existingAccount.Balance = balance;
                UpdateAccountInListView(existingAccount);
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }

            ClearInputFields();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string accountNumber = accountNumberTextBox.Text;
            Account accountToDelete = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (accountToDelete == null)
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá thông tin người dùng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    accounts.Remove(accountToDelete);
                    RemoveAccountFromListView(accountToDelete);
                    MessageBox.Show("Xóa tài khoản thành công!");
                    ClearInputFields();
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void accountListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = accountListView.SelectedItems[0];
                accountNumberTextBox.Text = selectedItem.SubItems[1].Text;
                customerNameTextBox.Text = selectedItem.SubItems[2].Text;
                addressTextBox.Text = selectedItem.SubItems[3].Text;
                balanceTextBox.Text = selectedItem.SubItems[4].Text;
            }
        }


        private void AddAccountToListView(Account account)
        {
            ListViewItem item = new ListViewItem((accountListView.Items.Count + 1).ToString());
            item.SubItems.Add(account.AccountNumber);
            item.SubItems.Add(account.CustomerName);
            item.SubItems.Add(account.Address);
            item.SubItems.Add(account.Balance.ToString("C"));
            accountListView.Items.Add(item);
        }

        private void UpdateAccountInListView(Account account)
        {
            foreach (ListViewItem item in accountListView.Items)
            {
                if (item.SubItems[1].Text == account.AccountNumber)
                {
                    item.SubItems[2].Text = account.CustomerName;
                    item.SubItems[3].Text = account.Address;
                    item.SubItems[4].Text = account.Balance.ToString("C");
                    break;
                }
            }
        }

        private void RemoveAccountFromListView(Account account)
        {
            for (int i = accountListView.Items.Count - 1; i >= 0; i--)
            {
                if (accountListView.Items[i].SubItems[1].Text == account.AccountNumber)
                {
                    accountListView.Items.RemoveAt(i);

                    for (int j = i; j < accountListView.Items.Count; j++)
                    {
                        accountListView.Items[j].Text = (j + 1).ToString();
                    }
                    break;
                }
            }
        }


        private void ClearInputFields()
        {
            accountNumberTextBox.Clear();
            customerNameTextBox.Clear();
            addressTextBox.Clear();
            balanceTextBox.Clear();
        }


    }
}
