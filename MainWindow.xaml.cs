/// Project: TMS
/// Filename: MainWindown.cs
/// Author: Mariana Mozzer Arantes
/// Date: 27/11/2020
/// Description: This file defines the main page of the application for insert, update and delete


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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MS3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        softwareEntities _db = new softwareEntities();
        public static DataGrid dataGrid;

        public MainWindow()
        {
            InitializeComponent();
            Load();

        }
        /// Class: Load()
        /// Purpose: Load the Data of the Datagrid
        private void Load()
        {
            myDataGrid.ItemsSource = _db.employers.ToList();
            dataGrid = myDataGrid;
        }


        /// Class: btnUpdate_Click()
        /// Purpose: Button to redirect to the Update page
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
            UpdatePage Upage = new UpdatePage();
            Upage.ShowDialog();
        }

        /// Class: btnDelete_Click()
        /// Purpose: Button to redirect to the Delete page
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as employer).id;
            var deleteEmployer = _db.employers.Where(m => m.id == id).Single();
            _db.employers.Remove(deleteEmployer);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.employers.ToList();
        }

        /// Class: Button_Click()
        /// Purpose: Button to redirect to the Insert Page
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertPage lpage = new InsertPage();
            lpage.ShowDialog();
        }

        /// Class: btnBilling_Click
        /// Purpose: Button to redirect to the Billing Page
        private void btnBilling_Click(object sender, RoutedEventArgs e)
        {
            BillingInsert bpage = new BillingInsert();
            bpage.ShowDialog();
        }
    }
}
