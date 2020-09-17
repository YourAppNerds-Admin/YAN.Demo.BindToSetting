using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace YAN.Demo.BindToSetting.Core.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string PropertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        private Properties.Settings Settings => Properties.Settings.Default;

        public ICommand AddToStringCollectionSettingCommand { get; set; }
        public ICommand AddToStringCollectionToObjectSettingCommand { get; set; }

        private string StringSetting_;
        public string StringSetting
        {
            get => StringSetting_;
            set
            {
                StringSetting_ = value;
                Settings.StringSetting = StringSetting_;
                Settings.Save();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> StringCollectionSetting_;
        public ObservableCollection<string> StringCollectionSetting
        {
            get => StringCollectionSetting_;
            set
            {
                if (StringCollectionSetting_ != null) StringCollectionSetting_.CollectionChanged -= WhenStringCollectionSettingChanges;
                StringCollectionSetting_ = value;
                StringCollectionSetting_.CollectionChanged += WhenStringCollectionSettingChanges;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ListviewCheckboxItem> StringCollectionToObjectSetting_;
        public ObservableCollection<ListviewCheckboxItem> StringCollectionToObjectSetting
        {
            get => StringCollectionToObjectSetting_;
            set
            {
                if (StringCollectionToObjectSetting_ != null) StringCollectionToObjectSetting_.CollectionChanged -= WhenStringCollectionToObjectSettingChanges;
                StringCollectionToObjectSetting_ = value;
                StringCollectionToObjectSetting_.CollectionChanged += WhenStringCollectionToObjectSettingChanges;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            StringSetting = Settings.StringSetting;
            StringCollectionSetting = Settings.StringCollectionSetting.ToObservableStringCollection();
            StringCollectionToObjectSetting = Settings.StringCollectionToObjectSetting.ToObservableListviewCheckboxCollection();
            AddToStringCollectionSettingCommand = new ActionCommand(ExecuteAddToStringCollectionSettingCommand);
            AddToStringCollectionToObjectSettingCommand = new ActionCommand(ExecuteAddToStringCollectionToObjectSettingCommand);
        }

        private void ExecuteAddToStringCollectionSettingCommand(object Parameter) =>
            StringCollectionSetting.Add(DateTime.Now.ToString());

        private void ExecuteAddToStringCollectionToObjectSettingCommand(object Parameter) =>
            StringCollectionToObjectSetting.Add(new ListviewCheckboxItem(DateTime.Now.ToString(), true));

        private void WhenStringCollectionSettingChanges(object sender, NotifyCollectionChangedEventArgs e)
        {
            Settings.StringCollectionSetting = StringCollectionSetting.ToStringCollection();
            Settings.Save();
        }

        private void WhenStringCollectionToObjectSettingChanges(object sender, NotifyCollectionChangedEventArgs e)
        {
            Settings.StringCollectionToObjectSetting = StringCollectionToObjectSetting.ToStringCollection();
            Settings.Save();
        }

    }
}
