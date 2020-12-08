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
    /// Interaction logic for BillingUpdate.xaml
    /// </summary>
    public partial class BillingUpdate : Window
    {
        //Connection to the Database
        softwareEntities _db = new softwareEntities();
        public static DataGrid dataGrid;
        int id;

        /// Class: BillingUpdate()
        /// Purpose: Initialize components of the page 
        public BillingUpdate()
        {
            InitializeComponent();
            Load();
        }

        /// Class: UpdatePage(int employerId)
        /// Purpose: variable id receives employer id to be updated 
        public BillingUpdate(int billingId)
        {
            id = billingId;
        }


        /// Class: Load()
        /// Purpose: Load the components of the Data Grid
        private void Load()
        {
            myDataGrid.ItemsSource = _db.billings.ToList();
            dataGrid = myDataGrid;
        }


        /// Class: txtBack_Click
        /// Purpose: Button opens the Main application page
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }



        /// Class: btnUpdate_Click()
        /// Purpose: Button to update data of the actual contact based on the id 
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
