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
using AutoCompleteControl.ViewModels;

namespace AutoCompleteControl
{
    /// <summary>
    /// Interaction logic for AutoCompleteControl.xaml
    /// </summary>
    public partial class AutoCompleteControl : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(List<object>), typeof(AutoCompleteControl), new PropertyMetadata(default(List<object>)));

        public List<object> ItemsSource
        {
            get { return (List<object>)GetValue(ItemsSourceProperty); }
            set
            {
                if (_autoCompleteControlViewModel == null) return;
                SetValue(ItemsSourceProperty, value);
                _autoCompleteControlViewModel.ParentList = value;
            }
        }

        public static readonly DependencyProperty PropertyNameProperty = DependencyProperty.Register(
            "PropertyName", typeof(string), typeof(AutoCompleteControl), new PropertyMetadata(default(string)));


        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set
            {
                if (_autoCompleteControlViewModel == null) return;
                SetValue(PropertyNameProperty, value);
                _autoCompleteControlViewModel.PropertyName = value;
            }
        }

        public static readonly DependencyProperty MinSearchCharactersProperty = DependencyProperty.Register(
          "MinSearchCharacters", typeof(int), typeof(AutoCompleteControl), new PropertyMetadata(3));


        public int MinSearchCharacters
        {
            get { return (int)GetValue(MinSearchCharactersProperty); }
            set
            {
                if (_autoCompleteControlViewModel == null) return;
                SetValue(MinSearchCharactersProperty, value);
                _autoCompleteControlViewModel.MinSearchCharacters = value;
            }
        }
        private readonly AutoCompleteControlViewModel _autoCompleteControlViewModel;

        public AutoCompleteControl()
        {
            InitializeComponent();
            _autoCompleteControlViewModel = new AutoCompleteControlViewModel();
            DataContext = _autoCompleteControlViewModel;
        }
    }
}
