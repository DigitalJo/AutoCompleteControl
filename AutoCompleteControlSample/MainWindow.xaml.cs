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
using AutoCompleteControlSample.Classes;

namespace AutoCompleteControlSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<object> _listOfCustomers=new List<object>();
        public MainWindow()
        {
            InitializeComponent();

            var customer1=new Customers { FirstName = "John",LastName = "Papadopoulos"};
            var customer2 = new Customers { FirstName = "Mary", LastName = "Sinatsaki" };

            _listOfCustomers.Add(customer1);
            _listOfCustomers.Add(customer2);

            AutoCompleteControler.ItemsSource = _listOfCustomers;
            AutoCompleteControler.PropertyName = "FirstName";
            AutoCompleteControler.MinSearchCharacters = 2;

        }
    }
}
