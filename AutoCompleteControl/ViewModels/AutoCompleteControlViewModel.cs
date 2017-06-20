using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompleteControl.ViewModels
{
    public class AutoCompleteControlViewModel : INotifyPropertyChanged
    {
        public AutoCompleteControlViewModel()
        {
            SuggestionsSource = new ObservableCollection<string>();
        }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                SearchTextChanged();
                NotifyPropertyChanged("SearchText");
            }
        }

        private bool _suggestionsVisibility;
        public bool SuggestionsVisibility
        {
            get
            {
                return _suggestionsVisibility;
            }
            set
            {
                _suggestionsVisibility = value;
                NotifyPropertyChanged("SuggestionsVisibility");
            }
        }

        public List<object> ParentList { get; set; }

        public string PropertyName { get; set; }

        public int MinSearchCharacters { get; set; }
        private ObservableCollection<string> _suggestionsSource;
        public ObservableCollection<string> SuggestionsSource
        {
            get { return _suggestionsSource; }
            set
            {
                _suggestionsSource = value;
                NotifyPropertyChanged("SuggestionsSource");
            }
        }

        private void SearchTextChanged()
        {
            var typedString = SearchText;
            SuggestionsSource.Clear();
            SuggestionsVisibility = false;
            if (typedString.Length < MinSearchCharacters)
            {
                return;
            }

            foreach (var item in ParentList)
            {
                var properties = item.GetType().GetProperties();
                foreach (var property in properties.Where(x=>x.Name== PropertyName))
                {
                    var value = property.GetValue(item, null);
                    var valueStr = value?.ToString();
                    if (valueStr != null && valueStr.StartsWith(typedString))
                    {
                        SuggestionsSource.Add(valueStr);
                    }
                    break;
                }

            }

            SuggestionsVisibility = SuggestionsSource.Count != 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
