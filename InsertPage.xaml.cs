/// Project: TMS
/// Filename: InsertPage.cs
/// Author: Mariana Mozzer Arantes
/// Date: 27/11/2020
/// Description: This file defines classes and methods used to insert contacts into the system


using System;
using System.Collections.Generic;
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

namespace MS3
{
    /// <summary>
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        //Connection to the Database
        softwareEntities _db = new softwareEntities();
        public static DataGrid dataGrid;


        // Class name: InsertPage()
        /// Purpose: Load page and initialize components

        public InsertPage()
        {
            InitializeComponent();
            Load();
        }


        /// Class name: Load()
        /// Purpose: Function to load Database informantion into Data Grid
        private void Load()
        {
            dataGridInsert.ItemsSource = _db.employers.ToList();
            dataGrid = dataGridInsert;
        }

        /// Class: btn_Insert_Click
        /// Purpose: Button function to insert user into the system
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            employer newEmployer = new employer()
            {

                name = txtName.Text,
                address = txtAddress.Text,
                dateOfBirth = txtDateOfBirth.Text,
                phone = txtPhone.Text,
                email = txtEmail.Text

            };
            _db.employers.Add(newEmployer);
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.employers.ToList();
            InsertPage.dataGrid.ItemsSource = _db.employers.ToList();
            this.Hide();

        }

        /// Class: btnUpdate_Click
        /// Purpose: Button function to update user into the system
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (dataGrid.SelectedItem as employer).id;
            UpdatePage Upage = new UpdatePage(id);
            Upage.ShowDialog();
        }

        /// Class: txtBack_Click
        /// Purpose: Button opens the Main application page
        private void txtBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }
    }
}
