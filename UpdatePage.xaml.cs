/// Project: TMS
/// Filename: UpdatePage.cs
/// Author: Mariana Mozzer Arantes
/// Date: 27/11/2020
/// Description: This file defines classes and methods used to update contacts into the system


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
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        //Connection to the Database
        softwareEntities _db = new softwareEntities();
        public static DataGrid dataGrid;
        int id;


        /// Class: UpdatePage()
        /// Purpose: Initialize components of the page 
        public UpdatePage()
        {
            InitializeComponent();
            Load();
        }


        /// Class: UpdatePage(int employerId)
        /// Purpose: variable id receives employer id to be updated 
        public UpdatePage(int employerId)
        {
            id = employerId;
        }

        /// Class: Load()
        /// Purpose: Load the components of the Data Grid
        private void Load()
        {
            myDataGrid.ItemsSource = _db.employers.ToList();
            dataGrid = myDataGrid;
        }

        /// Class: btnUpdate_Click()
        /// Purpose: Button to update data of the actual contact based on the id 
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as employer).id;
            UpdatePage Upage = new UpdatePage(id);

            employer updateEmployer = (from m in _db.employers
                                       where m.id == id
                                       select m).Single();
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.employers.ToList();
            this.Hide();
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
