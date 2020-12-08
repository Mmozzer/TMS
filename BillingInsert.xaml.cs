/// Project: TMS
/// Filename: BillingInsert.cs
/// Author: Mariana Mozzer Arantes
/// Date: 27/11/2020
/// Description: This file defines classes and methods used to insert billing into the system

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
    /// Interaction logic for BillingInsert.xaml
    /// </summary>
    public partial class BillingInsert : Window
    {
        //Connection to the Database
        softwareEntities _db = new softwareEntities();
        public static DataGrid dataGrid;

        /// Class: BillingInsert()
        /// Purpose: Initialize components of the page 
        public BillingInsert()
        {
            InitializeComponent();
            Load();
        }

        /// Class: Load()
        /// Purpose: Load the Data of the Datagrid
        private void Load()
        {
            myDataGrid.ItemsSource = _db.billings.ToList();
            dataGrid = myDataGrid;
        }



        /// Class: btnUpdate_Click
        /// Purpose: Button function to update billing into the system
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (dataGrid.SelectedItem as billing).id;
            BillingUpdate Bpage = new BillingUpdate(id);
            Bpage.ShowDialog();

        }

        /// Class: btn_Insert_Click
        /// Purpose: Button function to insert billings into the system
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            billing newBilling = new billing()
            {

                invoiceDate = txtInvoiceDate.Text,
                invoiceDueDate = txtInvoiceDue.Text,
                amount = txtAmount.Text

            };


            _db.billings.Add(newBilling);
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.billings.ToList();
            InsertPage.dataGrid.ItemsSource = _db.billings.ToList();
            this.Hide();
        }

        /// Class:  btnDelete_Click
        /// Purpose: Button function to delete billings into the system
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGrid.SelectedItem as billing).id;
            var deleteBilling = _db.billings.Where(m => m.id == id).Single();
            _db.billings.Remove(deleteBilling);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.billings.ToList();

        }
    }
}
