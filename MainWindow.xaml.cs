using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Baitap
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            users.Add(new User { FullName = "Nguyễn Đức Thắng", Age = 30, Email = "tn@example.com", Mobile = "1234567890" });
            users.Add(new User { FullName = "N S H", Age = 25, Email = "ts@example.com", Mobile = "9876543210" });
            listView.ItemsSource = users;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User
            {
                FullName = fullNameTextBox.Text,
                Age = int.Parse(ageTextBox.Text),
                Email = emailTextBox.Text,
                Mobile = mobileTextBox.Text
            };
            users.Add(newUser);
            ClearTextBoxes();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)listView.SelectedItem;
            if (selectedUser != null)
            {
                selectedUser.FullName = fullNameTextBox.Text;
                selectedUser.Age = int.Parse(ageTextBox.Text);
                selectedUser.Email = emailTextBox.Text;
                selectedUser.Mobile = mobileTextBox.Text;
                ClearTextBoxes();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)listView.SelectedItem;
            if (selectedUser != null)
            {
                users.Remove(selectedUser);
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            fullNameTextBox.Text = "";
            ageTextBox.Text = "";
            emailTextBox.Text = "";
            mobileTextBox.Text = "";
        }

        private void listView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            User selectedUser = (User)listView.SelectedItem;
            if (selectedUser != null)
            {
                fullNameTextBox.Text = selectedUser.FullName;
                ageTextBox.Text = selectedUser.Age.ToString();
                emailTextBox.Text = selectedUser.Email;
                mobileTextBox.Text = selectedUser.Mobile;
            }
        }
    }

    public class User
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
