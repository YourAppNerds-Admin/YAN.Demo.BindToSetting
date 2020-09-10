using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace YAN.Demo.BindToSetting.Framework.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string PropertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        private Properties.Settings Settings => Properties.Settings.Default;

        public string StringSetting
        {
            get => Settings.StringSetting;
            set
            {
                Settings.StringSetting = value;
                Settings.Save();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> StringCollectionSetting
        {
            get => Settings.StringCollectionSetting.ToObservableStringCollection();
            set
            {
                Settings.StringCollectionSetting = value.ToStringCollection();
                Settings.Save();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ListviewCheckboxItem> StringCollectionToObjectSetting
        {
            get => Settings.StringCollectionToObjectSetting.ToObservableListviewCheckboxCollection();
            set
            {
                Settings.StringCollectionToObjectSetting = value.ToStringCollection();
                Settings.Save();
                OnPropertyChanged();
            }
        }
    }
}
